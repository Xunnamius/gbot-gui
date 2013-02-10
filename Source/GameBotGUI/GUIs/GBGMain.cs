using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MovablePython;

namespace GameBotGUI
{
    public partial class GBGMain : Form
    {
        private int CURRENT_ACTION_CHARLIMIT = 110;
        
        private ObservableCollection<Profile> Profiles = new ObservableCollection<Profile>();
        private ObservableCollection<GBGBotNode> Nodes = new ObservableCollection<GBGBotNode>();
        private Dictionary<String, Object> applicationSettings = GUIUtilities.GenerateDefaultApplicationSettingsDictionary();
        private Dictionary<String, Object> profileSettings = GUIUtilities.GenerateDefaultProfileSettingsDictionary();
        private int itr = 0;
        private BackgroundWorker bgw = new BackgroundWorker();

        private RecordBase activeRecord;
        private int activeRepeats;
        private String activeString;

        /* Timers & Stopwatches */
        Stopwatch totalRunTime = new Stopwatch();
        Timer ttUpdater = new Timer();
        //

        public static readonly string ASMVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public GBGMain()
        {
            InitializeComponent();
            ttUpdater.Interval = 500;
            ttUpdater.Tick += new EventHandler((o, e) =>
            {
                long mil = totalRunTime.ElapsedMilliseconds,
                     seconds = mil / 1000,
                     minutes = seconds / 60 % 60,
                     hours = minutes / 60,
                     days = hours / 24;

                lblTotalRunTime.Text = "Approx. " + days + "d " + (hours % 24) + "h " + (minutes % 60) + "m " + (seconds % 60) + "s";
            });

            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += new DoWorkEventHandler(RunBot_Work);
            bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);

            Hotkey hkRunBot = new Hotkey(Keys.F12, false, true, true, false);

            hkRunBot.Pressed += delegate
            {
                if(btnStopBot.Enabled)
                    StopBot();
                else if(btnRunBot.Enabled)
                    RunBot();
            };

            hkRunBot.Register(this);
        }

        internal void WriteLogLine(params object[] segments)
        {
            txbLog.Text += Environment.NewLine + String.Join("", segments);

            if(!txbLog.Focused)
            {
                txbLog.SelectionStart = txbLog.Text.Length;
                txbLog.ScrollToCaret();
                txbLog.Refresh();
            }
        }

        internal void SetCurrentAction(String action)
        {
            lblCurrentAction.Text = action.Substring(0, CURRENT_ACTION_CHARLIMIT > action.Length ? action.Length : CURRENT_ACTION_CHARLIMIT);
            lblLastActionTime.Text = DateTime.Now.ToLocalTime().ToString();
        }

        internal Profile LoadProfile(String path)
        {
            throw new NotImplementedException();
        }

        internal bool LoadProfile(Profile profile)
        {
            throw new NotImplementedException();
        }

        internal bool SaveProfile(Profile profile)
        {
            throw new NotImplementedException();
        }

        internal void ResetRunStatistics()
        {
            lblTotalRunTime.Text = "N/A";
            lblLastActionTime.Text = "N/A";
            lblTotalClicks.Text = "0";
            lblTotalRuns.Text = "0";
            lblNodeCount.Text = "0";
            lblCurrentProfile.Text = "No profile loaded or saved";
        }

        internal void EnableInitialControls()
        {
            EnableInitialRunControls();
            menuStripMain.Enabled = true;
            btnCreateNode.Enabled = true;
            cbProfileSelector.Enabled = true;
            runBotToolStripMenuItem.Enabled = true;
        }

        internal void DisableAllControls()
        {
            DisableRunControls();
            btnCreateNode.Enabled = false;
            //btnDuplicateNode.Enabled = false;
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

        private void RunBot()
        {
            try
            {
                lblTotalRuns.Text = (Int32.Parse(lblTotalRuns.Text) + 1).ToString();
            }

            catch(FormatException fex) { }

            DisableAllControls();
            lbNodes.Enabled = false;
            btnStopBot.Enabled = true;
            runBotToolStripMenuItem.Text = "Stop Bot";

            totalRunTime.Start();
            ttUpdater.Start();

            SetCurrentAction("Executing first node...");
            bgw.RunWorkerAsync();
        }

        private void bgw_ProgressChanged(Object sender, ProgressChangedEventArgs e)
        {
            if(bgw.CancellationPending) return; // Do not update the UI in this manner if we're going to cancel

            int prog = e.ProgressPercentage;
            int nodeIndex = (int) Math.Floor((double)prog / 4);
            int multiNodeIndex = nodeIndex*4;

            if(prog == multiNodeIndex)
                SetCurrentAction("Executing record " + activeRecord.ToString() + "...");
                                
            else if(prog == multiNodeIndex+1)
                SetCurrentAction("Executing record " + activeRecord.ToString() + " (" + activeRepeats + " repeats remaining)...");

            else if(prog == multiNodeIndex+2)
                lblTotalClicks.Text = (Int32.Parse(lblTotalClicks.Text)+1).ToString();

            else if(prog == multiNodeIndex + 3)
                SetCurrentAction("Sleeping on " + activeString + " entropy...");
        }
            
        private void bgw_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled || !(e.Error == null))
            {
                itr = 0;
                EnableInitialRunControls();
                lbNodes.Enabled = true;
                btnCreateNode.Enabled = true;
                runBotToolStripMenuItem.Text = "Run Bot";

                if(!(e.Error == null))
                    SetCurrentAction("(Stopped) Error: " + e.Error.Message);

                else
                    SetCurrentAction("Idle (Stopped)");
            }

            else
            {
                itr++;
                itr = itr % Nodes.Count;
                SetCurrentAction("Executing next node (" + (itr+1) + "/" + Nodes.Count + ")...");
                if(!bgw.CancellationPending) bgw.RunWorkerAsync();
            }
        }

        private void RunBot_Work(Object sender, DoWorkEventArgs e)
        {
            if(itr < Nodes.Count)
            {
                GBGBotNode node = Nodes[itr];

                if(bgw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                Dictionary<String, Object> nodeSettings = (Dictionary<String, Object>) node.GetOption("nodeSettings"),
                                            timeSettings = (Dictionary<String, Object>) node.GetOption("timeSettings");
                ObservableCollection<RecordBase> records =
                    (ObservableCollection<RecordBase>) node.GetOption("records");

                int repeats = (int) nodeSettings["numRepeat"],
                    forcedPauseTime = (int) timeSettings["numForcedPause"],
                    intranodeEntropy = (int) timeSettings["cbEntropy"],
                    mouseSpeed = (int) nodeSettings["cbMouseSpeed"],
                    internodeEntropy = (int) applicationSettings["cbInternodeEntropy"];

                bool intranodeEntropyEnabled = (int) applicationSettings["chbxEnableIntranodeEntropy"] != 0,
                     intranodeForcedPauseEnabled = (int) applicationSettings["chbxEnableIntranodeForcedPause"] != 0;
                    
                if((int) nodeSettings["chbxEnabled"] != 0)
                {
                    while(!bgw.CancellationPending && repeats-- > 0)
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

                            if(repeats > 1)
                            {
                                activeRepeats = repeats;
                                bgw.ReportProgress(itr * 4 + 1);
                            }

                            if(record.Type == ClickRecordType.Duration)
                                System.Threading.Thread.Sleep(GUIUtilities.ToInt32(record.GetData()["duration"]));

                            else if(record is ClickMacroRecord)
                            {
                                bgw.ReportProgress(itr*4 + 2);

                                ClickNodeSubType type = ClickNodeSubType.NoClick;
                                switch(record.Type)
                                {
                                    case ClickRecordType.LeftClick:
                                        type = ClickNodeSubType.LeftClick;
                                        break;

                                    case ClickRecordType.MiddleClick:
                                        type = ClickNodeSubType.MiddleClick;
                                        break;

                                    case ClickRecordType.RightClick:
                                        type = ClickNodeSubType.RightClick;
                                        break;
                                }

                                if(bgw.CancellationPending)
                                {
                                    e.Cancel = true;
                                    return;
                                }

                                int mouseMoveDuration;
                                Random rand = new Random();

                                switch(mouseSpeed)
                                {
                                    case 0:
                                        mouseMoveDuration = rand.Next(800, 2000);
                                        break;

                                    case 1:
                                        mouseMoveDuration = rand.Next(350, 900);
                                        break;

                                    case 2:
                                        mouseMoveDuration = rand.Next(100, 600);
                                        break;

                                    default:
                                        mouseMoveDuration = rand.Next(100, 2000);
                                        break;
                                }

                                MouseController.SmoothClickMouseTo((Point) record.GetData()["point"], mouseMoveDuration, type);
                            }

                            activeString = "intranode";
                            bgw.ReportProgress(itr * 4 + 3);

                            int sleeptimeIntranode = 0; // seconds

                            if(intranodeForcedPauseEnabled)
                                sleeptimeIntranode = forcedPauseTime;

                            if(intranodeEntropyEnabled)
                            {
                                Random rand = new Random();

                                switch(intranodeEntropy)
                                {
                                    case 0:
                                        sleeptimeIntranode += rand.Next(100);
                                        break;

                                    case 1:
                                        sleeptimeIntranode += rand.Next(500);
                                        break;

                                    case 2:
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

                    int sleeptimeInternode = 10000; // milliseconds
                    Random randInternode = new Random();

                    switch(internodeEntropy)
                    {
                        case 0:
                            sleeptimeInternode += randInternode.Next(10000);
                            break;

                        case 1:
                            sleeptimeInternode += randInternode.Next(30000);
                            break;

                        case 2:
                            sleeptimeInternode += randInternode.Next(90000);
                            break;
                    }

                    System.Threading.Thread.Sleep(sleeptimeInternode);
                }

                else bgw.ReportProgress(itr * 4 + 3);
            }

            if(bgw.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        private void StopBot()
        {
            btnStopBot.Enabled = false;
            bgw.CancelAsync();
            SetCurrentAction("Stopping bot (please wait)...");

            ttUpdater.Stop();
            totalRunTime.Stop();
            totalRunTime.Reset();
        }
        
        private void GBGMain_Load(object sender, EventArgs e)
        {
            Text += ASMVersion;

            WriteLogLine("Version: ", ASMVersion);
            WriteLogLine("Made with Wakfu in mind, but can be used with any game, really.");
            WriteLogLine("Disclaimer: if you get caught, it's not my nor anyone else's problem. "
                         + "This understanding should be tacit. Deal with it (or don't use the "
                         + "program). By using this program you are agreeing to hold no one "
                         + "other than your cheating self responsible if anything goes wrong. "
                         + "Don't even attempt to contact me.");
            WriteLogLine("Really.");
            WriteLogLine("Now, to finish initializing...");
            ResetRunStatistics();

            long frequency = Stopwatch.Frequency;
            long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
            WriteLogLine("**Timer frequency in ticks per second = ", frequency);
            WriteLogLine("*-*Duration stopwatch estimated to be accurate to within ",
                nanosecPerTick, " nanoseconds on this system");

            // Set up MouseTracker
            Timer mouseTrackerTimer = new Timer();
            mouseTrackerTimer.Interval = 200;
            mouseTrackerTimer.Tick += new EventHandler((send, evarg) =>
            {
                sslblMouseTracker.Text = "Mouse Position: " + Cursor.Position.X
                    + ", " + Cursor.Position.Y;
            });

            // Enable initial controls
            EnableInitialControls();

            // Tacitly bind the ListBox to the Nodes Collection
            lbNodes.DisplayMember = "Display";
            Nodes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler((send, evarg) =>
            {
                lblNodeCount.Text = Nodes.Count.ToString();

                if(Nodes.Count > 0)
                    EnableInitialRunControls();

                else
                    DisableRunControls();

                lbNodes.Items.Clear();
                lbNodes.Items.AddRange(Nodes.ToArray<GBGBotNode>());
            });

            Nodes.Clear(); // Trigger CollectionChanged initially

            // Tacitly bind the ComboBox to the Profiles Collection
            Profiles.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler((send, evarg) =>
            {
                if(Profiles.Count > 0)
                    cbProfileSelector.Enabled = true;
                else
                    cbProfileSelector.Enabled = false;

                object ndx = cbProfileSelector.SelectedItem;
                cbProfileSelector.Items.Clear();
                cbProfileSelector.Items.AddRange(Profiles.ToArray<Profile>());

                try { cbProfileSelector.SelectedItem = ndx; }
                catch(Exception ignore) { }
            });

            Profiles.Clear(); // Trigger CollectionChanged initially

            // The Rest
            mouseTrackerTimer.Enabled = true;
            SetCurrentAction("Idle (fully initialized)");
        }

        private void btnRunBot_Click(object sender, EventArgs e)
        {
            RunBot();
        }

        private void btnStopBot_Click(object sender, EventArgs e)
        {
            StopBot();
        }

        private void runBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(runBotToolStripMenuItem.Text == "Run Bot") RunBot();
            else StopBot();
        }

        private void resetRunStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetRunStatistics();
        }

        private void clearNodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nodes.Clear();
        }

        private void clearProcessLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txbLog.Text = "-- Cleared --";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreateNode_Click(object sender, EventArgs e)
        {
            using(GBGClickCreateModify creatorForm = new GBGClickCreateModify(this))
            {
                creatorForm.ShowDialog(this);
                if(creatorForm.OkExit)
                {
                    ClickNode node = creatorForm.GetGeneratedNode();

                    if(lbNodes.SelectedIndex >= 0)
                        Nodes.Insert(lbNodes.SelectedIndex + 1, node);
                    else
                        Nodes.Add(node);

                    lbNodes.SelectedIndex = Nodes.IndexOf(node);
                    WriteLogLine("Successfully added new node!");
                }

                else WriteLogLine("Node creation cancelled.");
            }
        }


        private void btnModifyNode_Click(object sender, EventArgs e)
        {
            using(GBGClickCreateModify modForm = new GBGClickCreateModify(this, (ClickNode) lbNodes.SelectedItem))
            {
                modForm.ShowDialog(this);
                if(modForm.OkExit)
                {
                    int ndx = lbNodes.SelectedIndex;
                    Nodes.RemoveAt(ndx);
                    Nodes.Insert(ndx, modForm.GetGeneratedNode());
                    lbNodes.SelectedIndex = ndx;
                    WriteLogLine("Node modification accepted!");
                }

                else WriteLogLine("Node modification attempt cancelled.");
            }
        }

        private void btnDuplicateNode_Click(object sender, EventArgs e)
        {
            ClickNode node = (ClickNode) ((ClickNode) lbNodes.SelectedItem).Clone();
            int ndx = lbNodes.SelectedIndex + 1;
            Nodes.Insert(ndx, node);
            lbNodes.SelectedIndex = ndx;
            WriteLogLine("Successfully duplicated node!");
        }

        private void btnDestroyNode_Click(object sender, EventArgs e)
        {
            int ndx = lbNodes.SelectedIndex;
            Nodes.RemoveAt(ndx);
            if(ndx > 0) lbNodes.SelectedIndex = ndx - 1;
        }

        private void btnMoveNodeUp_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveNodeDown_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(GBGAbout aboutForm = new GBGAbout())
            {
                aboutForm.ShowDialog(this);
            }
        }

        private void applicationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(GBGApplicationSettings applicationSettingsForm = new GBGApplicationSettings(this, applicationSettings))
            {
                applicationSettingsForm.ShowDialog(this);
                if(applicationSettingsForm.OkExit)
                {
                    applicationSettings = applicationSettingsForm.GetGeneratedSettings();
                    WriteLogLine("Settings applied successfully!");
                }

                else WriteLogLine("Action cancelled.");
            }
        }

        private void profileSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(GBGProfileSettings profileSettingsForm = new GBGProfileSettings(this, profileSettings))
            {
                profileSettingsForm.ShowDialog(this);
                if(profileSettingsForm.OkExit)
                {
                    profileSettings = profileSettingsForm.GetGeneratedSettings();
                    WriteLogLine("Settings applied successfully!");
                }

                else WriteLogLine("Action Cancelled.");
            }
        }

        private void lbNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbNodes.SelectedIndex != -1)
            {
                //btnDuplicateNode.Enabled = true;
                btnModifyNode.Enabled = true;
                btnDestroyNode.Enabled = true;
                btnMoveNodeUp.Enabled = true;
                btnMoveNodeDown.Enabled = true;
            }

            else
            {
                //btnDuplicateNode.Enabled = false;
                btnModifyNode.Enabled = false;
                btnDestroyNode.Enabled = false;
                btnMoveNodeUp.Enabled = false;
                btnMoveNodeDown.Enabled = false;
            }
        }

        private void GBGMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
