using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace GameBotGUI
{
    internal partial class GBGClickCreateModify : Form
    {
        private GBGMain parent;
        private int mouseTracking = 0;
        private Dictionary<String, Object> nodeSettings;
        private Dictionary<String, Object> timeSettings;
        private ClickNode generatedNode = null;
        private Stopwatch stopwatch = new Stopwatch();

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        protected Boolean inCreateMode;
        internal ObservableCollection<MacroRecordBase> Records;

        public GBGClickCreateModify(GBGMain parent)
        {
            InitializeComponent();
            this.parent = parent;
            inCreateMode = false;

            Records = new ObservableCollection<MacroRecordBase>();
            nodeSettings = SettingsUtilities.GenerateDefaultNodeSettingsDictionary();
            timeSettings = SettingsUtilities.GenerateDefaultTimeSettingsDictionary();
        }

        public GBGClickCreateModify(GBGMain mainForm, ClickNode clickNode)
        {
            InitializeComponent();
            parent = mainForm;
            inCreateMode = true;

            ClickNode newNode = new ClickNode(txbName.Text.Length > 0 ? txbName.Text : null);
            newNode.SetOption("records", Records.ToList<MacroRecordBase>());
            newNode.SetOption("nodeSettings", nodeSettings);
            newNode.SetOption("timeSettings", timeSettings);

            txbName.Text = clickNode.Name;
            Records = new ObservableCollection<MacroRecordBase>((List<MacroRecordBase>) clickNode.GetOption("records"));
            nodeSettings = new Dictionary<string, object>((Dictionary<string, object>) clickNode.GetOption("nodeSettings"));
            timeSettings = new Dictionary<string, object>((Dictionary<string, object>) clickNode.GetOption("timeSettings"));
        }

        private void setDefaultTitle()
        {
            if(inCreateMode) Text = "Node Creator";
            else Text = "Modify Node";
        }

        private void GBGCreateAndModify_Load(object sender, EventArgs e)
        {
            long frequency = Stopwatch.Frequency;
            long nanosecPerTick = (1000L*1000L*1000L) / frequency;
            parent.WriteLogLine("**Timer frequency in ticks per second = ", frequency);
            parent.WriteLogLine("*-*Duration stopwatch estimated to be accurate to within ",
                nanosecPerTick, " nanoseconds on this system");

            lbRecords.DisplayMember = "Display";
            setDefaultTitle();

            Records.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler((send, evarg) =>
            {
                if(Records.Count > 0)
                    btnClear.Enabled = true;
                else
                {
                    btnModifyRecord.Enabled = false;
                    btnMoveUp.Enabled = false;
                    btnMoveDown.Enabled = false;
                    btnDeleteRecord.Enabled = false;
                    btnClear.Enabled = false;
                }

                object ndx = lbRecords.SelectedItem;
                lbRecords.Items.Clear();
                lbRecords.Items.AddRange(Records.ToArray<MacroRecordBase>());

                try { lbRecords.SelectedItem = ndx; }
                catch(Exception ignore) { }
            });

            Records.Clear();
        }

        internal ClickNode GetGeneratedNode()
        {
            return generatedNode;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Records.Clear();
        }

        private void lbRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteRecord.Enabled = true;
            btnMoveUp.Enabled = true;
            btnMoveDown.Enabled = true;
            btnModifyRecord.Enabled = true;
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            Records.Remove((MacroRecordBase) lbRecords.SelectedItem);

            btnModifyRecord.Enabled = false;
            btnMoveUp.Enabled = false;
            btnMoveDown.Enabled = false;
            btnDeleteRecord.Enabled = false;
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MacroRecordBase record2, record1 = (MacroRecordBase) lbRecords.SelectedItem;
            int ndx1 = Records.IndexOf(record1);
            int ndx2 = ndx1 - 1;

            if(ndx2 >= 0)
            {
                record2 = Records[ndx2];
                Records.RemoveAt(ndx1);
                Records.RemoveAt(ndx2);
                Records.Insert(ndx2, record1);
                Records.Insert(ndx1, record2);

                lbRecords.SelectedIndex = ndx2;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MacroRecordBase record2, record1 = (MacroRecordBase) lbRecords.SelectedItem;
            int ndx1 = Records.IndexOf(record1);
            int ndx2 = ndx1 + 1;

            if(ndx2 < Records.Count)
            {
                record2 = Records[ndx2];
                Records.RemoveAt(ndx2);
                Records.RemoveAt(ndx1);
                Records.Insert(ndx1, record2);
                Records.Insert(ndx2, record1);

                lbRecords.SelectedIndex = ndx2;
            }
        }

        private void btnCaptureClicks_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "You are about to begin capturing clicks. "
                + "You will be alerted by a tray notification both when you begin "
                + "and end mouse tracking. Press any key after you close this "
                + "window to begin.");

            Text = "PRE-CAPTURE MODE [PRESS ANY KEY TO BEGIN]";
            Enabled = false;
            mouseTracking = 1;
        }

        private void mkListener_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(mouseTracking == 1)
            {
                mouseTracking = 2;
                e.Handled = true;

                Text = "CAPTURE MODE [PRESS ANY KEY TO END]";

                parent.trayNotif.BalloonTipTitle = "Tracking has begun!";
                parent.trayNotif.BalloonTipText = "You may now click about the screen and have your "
                    + "left/right/middle clicks recorded. When you are satisfied, press ANY "
                    + "KEY to end mouse tracking.";
                parent.trayNotif.ShowBalloonTip(10000);
            }

            else if(mouseTracking == 2)
            {
                mouseTracking = 0;
                stopwatch.Stop();

                parent.trayNotif.BalloonTipTitle = "Tracking has ended!";
                parent.trayNotif.BalloonTipText = "You have ended mouse tracking successfully.";
                parent.trayNotif.ShowBalloonTip(7000);

                setDefaultTitle();
                e.Handled = true;
                Enabled = true;
                Focus();
            }
        }

        private void mkListener_MouseClickExt(object sender, MouseKeyboardActivityMonitor.MouseEventExtArgs e)
        {
            if(mouseTracking == 2)
            {
                MacroRecordType clickType = MacroRecordType.NoClick;

                switch(e.Button)
                {
                    case MouseButtons.Left:
                        clickType = MacroRecordType.LeftClick;
                        break;

                    case MouseButtons.Middle:
                        clickType = MacroRecordType.MiddleClick;
                        break;

                    case MouseButtons.Right:
                        clickType = MacroRecordType.RightClick;
                        break;
                }

                if(stopwatch.IsRunning)
                {
                    Records.Add(new DurationMacroRecord(new Dictionary<String, Object>() { { "duration", stopwatch.ElapsedMilliseconds } }));
                    stopwatch.Restart();
                }

                else stopwatch.Start();

                Records.Add(new ClickMacroRecord(new Dictionary<String, Object>(){ { "point", Cursor.Position } }, clickType));
            }
        }

        private void btnNodeSettings_Click(object sender, EventArgs e)
        {
            using(GBGNodeSettings nodeSettingsForm = new GBGNodeSettings(this, nodeSettings))
            {
                nodeSettingsForm.ShowDialog(this);
                if(nodeSettingsForm.OkExit)
                {
                    nodeSettings = nodeSettingsForm.GetGeneratedSettings();
                    parent.WriteLogLine("Settings applied successfully!");
                }

                else parent.WriteLogLine("Record modification attempt cancelled.");
            }
        }

        private void btnTimeSettings_Click(object sender, EventArgs e)
        {
            using(GBGTimeSettings timeSettingsForm = new GBGTimeSettings(this, timeSettings))
            {
                timeSettingsForm.ShowDialog(this);
                if(timeSettingsForm.OkExit)
                {
                    timeSettings = timeSettingsForm.GetGeneratedSettings();
                    parent.WriteLogLine("Settings applied successfully!");
                }

                else parent.WriteLogLine("Record modification attempt cancelled.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txbName.Text.Length > 0)
            {
                generatedNode = new ClickNode(txbName.Text.Length > 0 ? txbName.Text : null);
                generatedNode.SetOption("records", Records);
                generatedNode.SetOption("nodeSettings", nodeSettings);
                generatedNode.SetOption("timeSettings", timeSettings);

                _okExit = true;
                Close();
            }

            else MessageBox.Show("Your node cannot be nameless, mortal!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnModifyRecord_Click(object sender, EventArgs e)
        {
            MacroRecordBase record = (MacroRecordBase) lbRecords.SelectedItem;
            int ndx = Records.IndexOf(record);

            using(GBGClickAddModifyRecord modForm = new GBGClickAddModifyRecord(record))
            {
                modForm.ShowDialog(this);
                if(modForm.OkExit)
                {
                    MacroRecordBase gen = modForm.GetGeneratedRecord();

                    Records.RemoveAt(ndx);
                    Records.Insert(ndx, gen);
                    parent.WriteLogLine("Record modification accepted (at the bottom of the queue)!");
                }

                else parent.WriteLogLine("Record modification attempt cancelled.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using(GBGClickAddModifyRecord modForm = new GBGClickAddModifyRecord())
            {
                modForm.ShowDialog(this);
                if(modForm.OkExit)
                {
                    Records.Add(modForm.GetGeneratedRecord());
                    parent.WriteLogLine("New record accepted!");
                }

                else parent.WriteLogLine("Record creation cancelled.");
            }
        }
    }
}
