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

namespace GameBotGUI
{
    public partial class GBGMain : Form
    {
        private int CURRENT_ACTION_CHARLIMIT = 110;

        private ObservableCollection<Profile> Profiles = new ObservableCollection<Profile>();
        private ObservableCollection<GBGBotNode> Nodes = new ObservableCollection<GBGBotNode>();
        private Dictionary<String, Object> applicationSettings = SettingsUtilities.GenerateDefaultApplicationSettingsDictionary();
        private Dictionary<String, Object> profileSettings = SettingsUtilities.GenerateDefaultProfileSettingsDictionary();

        public static readonly string ASMVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public GBGMain()
        {
            InitializeComponent();
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
            lblTotalRunTime.Text = "00:00:00";
            lblLastActionTime.Text = DateTime.Now.ToLocalTime().ToString();
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
            btnDuplicateNode.Enabled = false;
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
            DisableRunControls();
            btnStopBot.Enabled = true;
            runBotToolStripMenuItem.Text = "Stop Bot";
        }

        private void StopBot()
        {
            EnableInitialRunControls();
            btnStopBot.Enabled = false;
            runBotToolStripMenuItem.Text = "Run Bot";
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
            Nodes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler((send, evarg) =>
            {
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
                    Nodes.Add(creatorForm.GetGeneratedNode());
                    WriteLogLine("Successfully added new node!");
                }

                else WriteLogLine("Action cancelled.");
            }
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
    }
}
