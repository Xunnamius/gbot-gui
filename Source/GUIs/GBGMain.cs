using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DarkGray.Forms.Decorators;
using GameBotGUI.Node;
using GameBotGUI.Node.Types;
using GameBotGUI.Node.Types.Click;
using GameBotGUI.Profile;
using GameBotGUI.Record;
using GameBotGUI.Record.Types.Click;
using GameBotGUI.Record.Types.Duration;
using MovablePython;

namespace GameBotGUI
{
    public partial class GBGMain : Form
    {
        /* Constants */
        public const Int32 CURRENT_ACTION_CHARLIMIT = 110;
        public const Int32 DURATION_ITERATION_INTERVAL = 250;
        public const Int32 DURATION_ITERATION_MARGIN = 4;
        //

        /* User Configurables */
        private ProfileController profileController;
        private ApplicationSettings applicationSettings;
        //

        /* Helpers */
        internal ExtendedListControl<GenericNode> elbNodes;
        private ListChangedEventHandler lbNodesListChangedEventHandler;
        private int globalruns = 0;
        //

        /* Background Worker */
        private BackgroundWorker bgw = new BackgroundWorker();
        private RecordBase activeRecord;
        private Int32 activeRepeats;
        private String activeString;
        private GenericNode activeNode;
        private Int32 itr = 0;
        //

        /* Timers and Stopwatches */
        private Stopwatch totalRunTime = new Stopwatch();
        private Timer ttUpdater = new Timer();
        //

        /* Text Control Scrollers and Helpers */
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;
        //

        /* Load/Save Dialog */
        SaveFileDialog saveFileDialog;
        OpenFileDialog openFileDialog;

        public static readonly string ASMVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public GBGMain()
        {
            InitializeComponent();

            profileController = new ProfileController("GBotGUI");

            applicationSettings = new ApplicationSettings(
                (EntropyLevel) Properties.Settings.Default.ApplicationInternodeEntropy,
                Properties.Settings.Default.ApplicationIntranodeForcePauseEnabled,
                Properties.Settings.Default.ApplicationIntranodeEntropyEnabled,
                (ExecutionScheme) Properties.Settings.Default.ApplicationExecutionScheme,
                Properties.Settings.Default.ApplicationTotalRuns,
                Properties.Settings.Default.ApplicationRunInfinityTimes,
                Properties.Settings.Default.ApplicationGlobalOffsetX,
                Properties.Settings.Default.ApplicationGlobalOffsetY,
                Properties.Settings.Default.ApplicationMinimizeWindowOnRun);
        }

        private void GBGMain_Load(Object sender, EventArgs e)
        {
            ttUpdater.Interval = 500;
            ttUpdater.Tick += new EventHandler((o, ev) =>
            {
                long mil = totalRunTime.ElapsedMilliseconds,
                     seconds = mil / 1000,
                     minutes = seconds / 60 % 60,
                     hours = minutes / 60,
                     days = hours / 24;

                lblCurrentRunTime.Text = "Approx. " + days + "d " + (hours % 24) + "h " + (minutes % 60) + "m " + (seconds % 60) + "s";
            });

            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += new DoWorkEventHandler(RunBot_Work);
            bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);

            Hotkey hkRunBot = new Hotkey(Keys.F12, false, true, true, false);

            hkRunBot.Pressed += delegate
            {
                if (btnStopBot.Enabled)
                    StopBot();
                else if (btnRunBot.Enabled)
                    RunBot();
            };

            hkRunBot.Register(this);

            Text += ASMVersion;

            WriteLogLine("Version: ", ASMVersion);
            WriteLogLine("Disclaimer: if you get caught, it's not my nor anyone else's problem. "
                         + "This understanding should be tacit. Deal with it (or don't use the "
                         + "program). By using this program you are agreeing to hold no one "
                         + "other than your cheating self responsible if anything goes wrong. "
                         + "Don't even attempt to contact me.");
            WriteLogLine("Oh, and you should probably consider disabling the UAC when running ",
                "this bot, especially if you're encountering problems.");
            WriteLogLine("Finishing initialization...");
            ResetRunStatistics();

            long frequency = Stopwatch.Frequency;
            long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
            WriteLogLine("**Timer frequency in ticks per second = ", frequency);
            WriteLogLine("*-*Duration stopwatch estimated to be accurate to within ",
                nanosecPerTick, " nanoseconds on this system");

            // Load/Save dialogs
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Choose Profile Location...";

            openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Profile...";

            saveFileDialog.InitialDirectory = openFileDialog.InitialDirectory = profileController.DefaultSaveDirectory;
            saveFileDialog.DefaultExt = openFileDialog.DefaultExt = Properties.Settings.Default.ProfileFileExtension;
            saveFileDialog.Filter = openFileDialog.Filter = "profiles (*."
                + Properties.Settings.Default.ProfileFileExtension
                + ")|*."
                + Properties.Settings.Default.ProfileFileExtension
                + "|All files (*.*)|*.*";

            // Set up MouseTracker
            Timer mouseTrackerTimer = new Timer();
            mouseTrackerTimer.Interval = 200;
            mouseTrackerTimer.Tick += new EventHandler(mouseTrackerTimer_Tick);

            // Set up events
            profileController.Profiles.ListChanged += new ListChangedEventHandler((o, ev) =>
            {
                if(profileController.Profiles.Count > 0)
                    cbProfileSelector.Enabled = true;
                else
                    cbProfileSelector.Enabled = false;
            });
            
            lbNodesListChangedEventHandler = new ListChangedEventHandler(nodeList_ListChanged);

            // ListControls
            cbProfileSelector.DataSource = profileController.Profiles;
            lbNodes.DisplayMember = "Display";
            cbProfileSelector.DisplayMember = "Display";

            // Load/Create the default profile
            profileController.ProfileControllerAction +=
                new ProfileController.ProfileControllerActionHandler(profileController_ProfileControllerAction);

            String errpath = "(unknown location)";
            mouseTrackerTimer.Enabled = true;

            try
            {
                EnableInitialControls();

                if(File.Exists(profileController.PathOfDefaultProfile))
                    profileController.LoadProfile(errpath = profileController.PathOfDefaultProfile);
                    
                else
                {
                    NodeProfile profile =
                        new NodeProfile("default", profileController.DefaultSaveDirectory, new BindingList<GenericNode>());

                    errpath = profile.FilePath;
                    profileController.SaveProfile(profile);
                    profileController.LoadProfile(profile.FilePath);
                }

                SetCurrentAction("Idle (fully initialized)");
                elbNodes = new ExtendedListControl<GenericNode>(lbNodes);
                profileController.Profiles.ResetBindings();
            }

            catch(System.Runtime.Serialization.SerializationException ouch)
            {
                WriteLogLine(
                    "ERROR: Failed to mutate your default profile.",
                    "If you continue to see this error, please  ",
                    "delete the following file: \"", errpath, "\".");
                WriteLogLine("WARNING: Due to Profile functionality being unavailable for the duration ",
                    "of this session, program functionality has become limited.");

                menuStripMain.Enabled = false;
                SetCurrentAction("Idle (bad startup; check logs)");
            }
        }

        [System.Diagnostics.DebuggerStepThrough()]
        void mouseTrackerTimer_Tick(object sender, EventArgs e)
        {
            sslblMouseTracker.Text = "Mouse Position: " + Cursor.Position.X + ", " + Cursor.Position.Y;
        }

        void profileController_ProfileControllerAction(Object sender, ProfileControllerActionEventArgs e)
        {
            if(e.Profile != null)
            {
                switch(e.Action)
                {
                    case ProfileControllerAction.AlreadyLoaded:
                        WriteLogLine("ERROR: Profile \"", e.Profile.Name, "\" has already been loaded and cannot be loaded twice.");
                        WriteLogLine("If you want to reload your profiles, restart the bot. ",
                            "May make this process more user friendly in the future.");
                        break;

                    case ProfileControllerAction.Save:
                        WriteLogLine("Successfully saved profile: \"",  e.Profile.Name, "\"");
                        break;

                    case ProfileControllerAction.Load:
                        WriteLogLine("Loaded new profile: \"", e.Profile.Name, "\"");
                        cbProfileSelector.SelectedIndex = -1;
                        cbProfileSelector.SelectedIndex = profileController.IndexOfProfileWithFilePath(e.Profile.FilePath);
                        break;

                    case ProfileControllerAction.Activated:
                        WriteLogLine("Activated profile: \"", e.Profile.Name, "\"");
                        BindingList<GenericNode> nodeList = e.Profile.NodeList;

                        if(lbNodes.DataSource is BindingList<GenericNode> && lbNodes.DataSource != null)
                            ((BindingList<GenericNode>) lbNodes.DataSource).ListChanged -= lbNodesListChangedEventHandler;

                        lbNodes.DataSource = nodeList;

                        // Extend ListControl
                        elbNodes = new ExtendedListControl<GenericNode>(lbNodes);

                        nodeList.ListChanged += lbNodesListChangedEventHandler;
                        
                        lblCurrentProfile.Text = e.Profile.ToString();
                        nodeList.ResetBindings(); // Trigger event initially
                        break;
                }
            }
        }

        void nodeList_ListChanged(Object sender, ListChangedEventArgs e)
        {
            BindingList<GenericNode> nodeList = (BindingList<GenericNode>) sender;

            lblNodeCount.Text = nodeList.Count.ToString();

            if(nodeList.Count > 0)
                EnableInitialRunControls();
            else
                DisableRunControls();
        }

        /* UI Methods */

        internal void WriteLogLine(params object[] segments)
        {
            txbLog.AppendText(Environment.NewLine + String.Join("", segments));

            // XXX: Scroll the text control to the bottom each time
            SendMessage(txbLog.Handle, WM_VSCROLL, (IntPtr) SB_BOTTOM, IntPtr.Zero);
        }

        internal void SetCurrentAction(String action)
        {
            lblCurrentAction.Text = action.Substring(0, CURRENT_ACTION_CHARLIMIT > action.Length ? action.Length : CURRENT_ACTION_CHARLIMIT);
            lblLastActionTime.Text = DateTime.Now.ToLocalTime().ToString();
        }

        internal void ResetRunStatistics()
        {
            lblCurrentRunTime.Text = "N/A";
            lblLastActionTime.Text = "N/A";
            lblTotalClicks.Text = "0";
            lblTotalRuns.Text = "0";
        }

        internal void EnableInitialControls()
        {
            EnableInitialRunControls();
            menuStripMain.Enabled = true;
            btnCreateNode.Enabled = true;
        }

        internal void DisableAllControls()
        {
            DisableRunControls();
            btnCreateNode.Enabled = false;
            btnModifyNode.Enabled = false;
            btnDestroyNode.Enabled = false;
            btnMoveNodeUp.Enabled = false;
            btnMoveNodeDown.Enabled = false;
        }

        internal void EnableInitialRunControls()
        {
            btnRunBot.Enabled = true;
            runBotToolStripMenuItem.Enabled = true;
        }

        internal void DisableRunControls()
        {
            btnRunBot.Enabled = false;
            btnStopBot.Enabled = false;
            runBotToolStripMenuItem.Enabled = false;
        }

        /* Bot Methods */

        private void RunBot()
        {
            Boolean fail = true;
            foreach(GenericNode node in profileController.ActiveProfile.NodeList)
            {
                if(node.Settings.internalNodeSettings.Enabled != CheckState.Unchecked)
                    fail = false;
            }

            if(fail)
                WriteLogLine("WARNING: Bot failed to start because there are no enabled nodes. Create or enable a node and try again.");

            else
            {
                if(applicationSettings.MinimizeWindowOnRun != CheckState.Unchecked)
                    this.WindowState = FormWindowState.Minimized;

                try
                {
                    lblTotalRuns.Text = (Int32.Parse(lblTotalRuns.Text) + 1).ToString();
                }

                catch(FormatException ignore) { }

                DisableAllControls();
                lbNodes.Enabled = false;
                btnStopBot.Enabled = true;
                runBotToolStripMenuItem.Text = "Stop Bot";
                runBotToolStripMenuItem.Enabled = true;

                profilesToolStripMenuItem.Enabled = false;
                helpToolStripMenuItem.Enabled = false;
                settingsToolStripMenuItem.Enabled = false;
                resetRunStatsToolStripMenuItem.Enabled = false;
                clearNodesToolStripMenuItem.Enabled = false;
                clearProcessLogToolStripMenuItem.Enabled = false;

                totalRunTime.Start();
                ttUpdater.Start();

                SetCurrentAction("Executing sequence...");
                globalruns = applicationSettings.TotalRuns;
                StartBGW();
            }
        }
        
        private void StartBGW()
        {
            if(applicationSettings.RunInfinityTimes == CheckState.Unchecked && globalruns-- <= 0)
                StopBot();
            bgw.RunWorkerAsync();
        }

        private void bgw_ProgressChanged(Object sender, ProgressChangedEventArgs e)
        {
            if(bgw.CancellationPending) return; // Do not update the UI in this manner if we're going to cancel

            Int32 prog = e.ProgressPercentage;
            Int32 nodeIndex = (int) Math.Floor((double)prog / 4);
            Int32 multiNodeIndex = nodeIndex*4;

            if(prog == multiNodeIndex)
                SetCurrentAction("Executing record " + activeRecord.ToString() + "...");
                                
            else if(prog == multiNodeIndex + 1)
                SetCurrentAction("Executing record " + activeRecord.ToString() + " (" + activeRepeats + " node repeats remaining)...");

            else if(prog == multiNodeIndex + 2)
                lblTotalClicks.Text = (Int32.Parse(lblTotalClicks.Text)+1).ToString();

            else if(prog == multiNodeIndex + 3)
                SetCurrentAction("Sleeping on " + activeString + " entropy...");

            else if(prog == multiNodeIndex + 3)
                SetCurrentAction("Skipping node \"" + activeNode + "\"...");
        }
            
        private void bgw_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled || e.Error != null)
            {
                itr = 0;
                EnableInitialRunControls();
                lbNodes.Enabled = true;
                btnCreateNode.Enabled = true;
                runBotToolStripMenuItem.Text = "Run Bot";

                profilesToolStripMenuItem.Enabled = true;
                helpToolStripMenuItem.Enabled = true;
                settingsToolStripMenuItem.Enabled = true;
                resetRunStatsToolStripMenuItem.Enabled = true;
                clearNodesToolStripMenuItem.Enabled = true;
                clearProcessLogToolStripMenuItem.Enabled = true;

                if(e.Error != null)
                    SetCurrentAction("(Stopped) Error: " + e.Error.Message);

                else
                    SetCurrentAction("Idle (Stopped)");
            }

            else
            {
                itr++;
                itr = itr % profileController.ActiveProfile.NodeList.Count;
                SetCurrentAction("Executing next node (" + (itr + 1) + "/" + profileController.ActiveProfile.NodeList.Count + ")...");

                if(!bgw.CancellationPending)
                    StartBGW();
            }
        }

        private void RunBot_Work(Object sender, DoWorkEventArgs e)
        {
            if(bgw.CancellationPending)
                e.Cancel = true;

            else if(itr < profileController.ActiveProfile.NodeList.Count)
            {
                GenericNode node = profileController.ActiveProfile.NodeList[itr];
                activeNode = node;

                InternalNodeSettings nodeSettings = node.Settings.internalNodeSettings;
                InternalTimeSettings timeSettings = node.Settings.internalTimeSettings;
                BindingList<RecordBase> records = node.Settings.Records;

                Int32 runs = nodeSettings.Runs;
                
                if(nodeSettings.Enabled != CheckState.Unchecked)
                {
                    while(!bgw.CancellationPending && runs-- > 0)
                    {
                        foreach(RecordBase record in records)
                        {
                            if(bgw.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }

                            activeRecord = record;
                            bgw.ReportProgress(itr * 4);

                            if(runs > 0)
                            {
                                activeRepeats = runs;
                                bgw.ReportProgress(itr * 4 + 1);
                            }

                            if(record.Type == RecordType.DurationRecord)
                            {
                                // This code allows users to stop the bot during long sleeps
                                Int32 duration = ((DurationRecord) record).Duration,
                                      iterations = duration / DURATION_ITERATION_INTERVAL,
                                      remainder = duration % DURATION_ITERATION_INTERVAL;

                                if(duration > DURATION_ITERATION_INTERVAL * DURATION_ITERATION_MARGIN)
                                {
                                    for(Int32 i = 0; i < iterations; ++i)
                                    {
                                        System.Threading.Thread.Sleep(DURATION_ITERATION_INTERVAL);
                                        if(bgw.CancellationPending)
                                        {
                                            e.Cancel = true;
                                            return;
                                        }
                                    }

                                    System.Threading.Thread.Sleep(remainder);
                                }

                                else System.Threading.Thread.Sleep(duration);
                            }

                            else if(record.Type == RecordType.ClickRecord)
                            {
                                bgw.ReportProgress(itr * 4 + 2);

                                Random rand = new Random();
                                Int32 mouseMoveDuration = rand.Next(1000);

                                switch(nodeSettings.MouseSpeed)
                                {
                                    case MouseSpeed.Slow:
                                        mouseMoveDuration = rand.Next(800, 1500);
                                        break;

                                    case MouseSpeed.Medium:
                                        mouseMoveDuration = rand.Next(500, 900);
                                        break;

                                    case MouseSpeed.Fast:
                                        mouseMoveDuration = rand.Next(100, 600);
                                        break;

                                    case MouseSpeed.Random:
                                        mouseMoveDuration = rand.Next(rand.Next(100, 600), rand.Next(700, 1500));
                                        break;
                                }

                                ClickRecord clickRecord = (ClickRecord) record;

                                // Take into account the global and local offsets (they do indeed stack)
                                Point targetPoint = clickRecord.TargetPoint;
                                targetPoint.X += (applicationSettings.GlobalOffsetX + nodeSettings.OffsetX);
                                targetPoint.Y += (applicationSettings.GlobalOffsetY + nodeSettings.OffsetY);

                                MouseController.SmoothClickMouseTo(targetPoint, mouseMoveDuration, clickRecord.SubType);
                            }

                            activeString = "intranode";
                            bgw.ReportProgress(itr * 4 + 3);

                            Int32 sleeptimeIntranode = 0; // seconds

                            if(applicationSettings.IntranodeForcedPauseEnabled != CheckState.Unchecked)
                                sleeptimeIntranode = timeSettings.ForcedPause;

                            if(applicationSettings.IntranodeEntropyEnabled != CheckState.Unchecked)
                            {
                                Random rand = new Random();

                                switch(timeSettings.Entropy)
                                {
                                    case EntropyLevel.Low:
                                        sleeptimeIntranode += rand.Next(100);
                                        break;

                                    case EntropyLevel.Medium:
                                        sleeptimeIntranode += rand.Next(500);
                                        break;

                                    case EntropyLevel.High:
                                        sleeptimeIntranode += rand.Next(1000);
                                        break;
                                }
                            }

                            System.Threading.Thread.Sleep(sleeptimeIntranode);
                        }
                    }

                    if(bgw.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    activeString = "internode";
                    bgw.ReportProgress(itr * 4 + 3);

                    Int32 sleeptimeInternode = 10000; // milliseconds
                    Random randInternode = new Random();
                    
                    switch(applicationSettings.InternodeEntropy)
                    {
                        case EntropyLevel.Low:
                            sleeptimeInternode += randInternode.Next(10000);
                            break;

                        case EntropyLevel.Medium:
                            sleeptimeInternode += randInternode.Next(30000);
                            break;

                        case EntropyLevel.High:
                            sleeptimeInternode += randInternode.Next(90000);
                            break;
                    }

                    System.Threading.Thread.Sleep(sleeptimeInternode);
                }

                else bgw.ReportProgress(itr * 4 + 4);
            }

            if(bgw.CancellationPending)
                e.Cancel = true;
        }

        private void StopBot()
        {
            btnStopBot.Enabled = false;
            bgw.CancelAsync();
            SetCurrentAction("Stopping bot (please wait)...");

            ttUpdater.Stop();
            totalRunTime.Reset();
        }

        /* Control Methods */

        private void btnRunBot_Click(Object sender, EventArgs e)
        {
            RunBot();
        }

        private void btnStopBot_Click(Object sender, EventArgs e)
        {
            StopBot();
        }

        private void runBotToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if(runBotToolStripMenuItem.Text == "Run Bot") RunBot();
            else StopBot();
        }

        private void resetRunStatsToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            ResetRunStatistics();
        }

        private void clearNodesToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            profileController.ActiveProfile.NodeList.Clear();
        }

        private void clearProcessLogToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            txbLog.Text = "-- Cleared --";
        }

        private void exitToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreateNode_Click(Object sender, EventArgs e)
        {
            // TODO: Generalize this for the creation of many types of
            // nodes, not just ClickNodes
            GenericNode newNode = new ClickNode(null);
            using(GBGNodeCreateModify creatorForm = new GBGNodeCreateModify(this, newNode, true))
            {
                creatorForm.ShowDialog(this);
                
                if(creatorForm.OkExit)
                {
                    if(elbNodes.RelativeAdd(newNode, 1))
                        WriteLogLine("Successfully added new node.");
                    else
                        WriteLogLine("New node was rejected?");
                }

                else WriteLogLine("Node creation cancelled.");
            }
        }

        private void btnModifyNode_Click(Object sender, EventArgs e)
        {
            using(GBGNodeCreateModify modForm = new GBGNodeCreateModify(this, (GenericNode) lbNodes.SelectedItem, false))
            {
                modForm.ShowDialog(this);

                if(modForm.OkExit)
                {
                    if(elbNodes.SelectedReplace(modForm.InternalNode))
                        WriteLogLine("Node modification accepted.");
                    else
                        WriteLogLine("Node modification rejected?");
                }

                else WriteLogLine("Node modification cancelled.");
            }
        }

        private void btnDestroyNode_Click(Object sender, EventArgs e)
        {
            elbNodes.SelectedDelete();
        }

        private void btnMoveNodeUp_Click(Object sender, EventArgs e)
        {
            elbNodes.SelectedShiftUp();
        }

        private void btnMoveNodeDown_Click(Object sender, EventArgs e)
        {
            elbNodes.SelectedShiftDown();
        }

        private void aboutToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            using(GBGAbout aboutForm = new GBGAbout())
            {
                aboutForm.ShowDialog(this);
            }
        }

        private void applicationSettingsToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            using(GBGApplicationSettings applicationSettingsForm = new GBGApplicationSettings(this, applicationSettings))
            {
                applicationSettingsForm.ShowDialog(this);
                if(applicationSettingsForm.OkExit)
                    WriteLogLine("Settings applied successfully.");
                else WriteLogLine("Action cancelled.");
            }
        }

        private void lbNodes_SelectedValueChanged(Object sender, EventArgs e)
        {
            if(lbNodes.SelectedIndex != -1)
            {
                btnModifyNode.Enabled = true;
                btnDestroyNode.Enabled = true;
                btnMoveNodeUp.Enabled = true;
                btnMoveNodeDown.Enabled = true;
            }

            else
            {
                btnModifyNode.Enabled = false;
                btnDestroyNode.Enabled = false;
                btnMoveNodeUp.Enabled = false;
                btnMoveNodeDown.Enabled = false;
            }
        }

        private void lbNodes_DataSourceChanged(object sender, EventArgs e)
        {
            lbNodes.SelectedIndex = -1;
        }

        private void GBGMain_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ApplicationInternodeEntropy = (Int32) applicationSettings.InternodeEntropy;
            Properties.Settings.Default.ApplicationIntranodeForcePauseEnabled = applicationSettings.IntranodeForcedPauseEnabled;
            Properties.Settings.Default.ApplicationIntranodeEntropyEnabled = applicationSettings.IntranodeEntropyEnabled;
            Properties.Settings.Default.ApplicationExecutionScheme = (Int32) applicationSettings.ExecScheme;
            Properties.Settings.Default.ApplicationTotalRuns = applicationSettings.TotalRuns;
            Properties.Settings.Default.ApplicationRunInfinityTimes = applicationSettings.RunInfinityTimes;
            Properties.Settings.Default.ApplicationGlobalOffsetX = applicationSettings.GlobalOffsetX;
            Properties.Settings.Default.ApplicationGlobalOffsetY = applicationSettings.GlobalOffsetY;
            Properties.Settings.Default.ApplicationMinimizeWindowOnRun = applicationSettings.MinimizeWindowOnRun;
            //Properties.Settings.Default.ProfileDefaultSaveLocation = applicationSettings.ProfileDefaultSaveLocation;

            Properties.Settings.Default.Save();
        }

        private void cbProfileSelector_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if(cbProfileSelector.SelectedIndex != -1)
                profileController.ActiveProfile = (NodeProfile) cbProfileSelector.SelectedItem;
        }

        private void saveProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    NodeProfile newProfile = (NodeProfile) profileController.ActiveProfile.Clone(
                        Path.GetFileNameWithoutExtension(saveFileDialog.FileName),
                        Path.GetDirectoryName(saveFileDialog.FileName));

                    profileController.SaveProfile(newProfile);
                }

                catch(System.Runtime.Serialization.SerializationException ouch)
                {
                    WriteLogLine(
                        "ERROR: Failed to save profile at the specified located \"",
                        saveFileDialog.FileName,
                        "\". Make sure your file doesn't already exist, ",
                        "you have with read/write permissions, ",
                        "the file name is valid, you've TURNED OFF THE UAC, ",
                        "and the file is not corrupt before trying again.");
                }
            }

            else WriteLogLine("Action cancelled.");
        }

        private void loadProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    profileController.LoadProfile(openFileDialog.FileName);
                }

                catch(System.Runtime.Serialization.SerializationException ouch)
                {
                    WriteLogLine(
                        "ERROR: Failed to load profile located at \"",
                        openFileDialog.FileName,
                        "\". Make sure your file already exists, ",
                        "you have with read/write permissions, ",
                        "the file name is valid, you've TURNED OFF THE UAC, ",
                        "and the file is not corrupt before trying again.");
                }
            }

            else WriteLogLine("Action cancelled.");
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();

            if(MessageBox.Show(
                "Are you sure you want to reset all your settings?",
                "Confirmation",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("Your application's settings have been reset. The application will now close.", "Factory Reset");
                Application.Exit();
            }

            else WriteLogLine("Action cancelled.");
        }
    }
}
