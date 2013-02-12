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
using GameBotGUI.Node.Types;
using GameBotGUI.Record;
using GameBotGUI.Node;
using GameBotGUI.Record.Types.Click;
using GameBotGUI.Record.Types.Duration;

namespace GameBotGUI
{
    internal partial class GBGClickCreateModify : Form
    {
        private GBGMain parent;
        private int mouseTracking = 0;
        private GenericNode generatedNode = null;
        private Stopwatch stopwatch = new Stopwatch();

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        protected Boolean inCreateMode;
        protected ObservableCollection<RecordBase> records;

        public GBGClickCreateModify(GBGMain parent)
        {
            InitializeComponent();
            this.parent = parent;
            inCreateMode = true;
            records = new ObservableCollection<RecordBase>();
        }

        public GBGClickCreateModify(GBGMain mainForm, GenericNode genericNode)
        {
            InitializeComponent();
            parent = mainForm;
            inCreateMode = false;
            generatedNode = genericNode;
            // XXX: We clone it (in preparation) for duplication functionality
            records = ((NodeSettings) genericNode.Settings.Clone()).Records;
            txbName.Text = genericNode.Name;
        }

        private void setDefaultTitle()
        {
            if(inCreateMode) Text = "Node Creator";
            else Text = "Modify Node";
        }

        private void GBGCreateAndModify_Load(object sender, EventArgs e)
        {
            lbRecords.DisplayMember = "Display";
            setDefaultTitle();

            records.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler((send, evarg) =>
            {
                if(records.Count > 0)
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
                lbRecords.Items.AddRange(records.ToArray<RecordBase>());

                try { lbRecords.SelectedItem = ndx; }
                catch(Exception ignore) { }
            });

            // XXX: Force the change event
            if(records.Count > 0) records.Move(0, 0);
            else records.Clear();
        }

        internal GenericNode GetGeneratedNode()
        {
            return generatedNode;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            records.Clear();
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
            records.Remove((RecordBase) lbRecords.SelectedItem);

            btnModifyRecord.Enabled = false;
            btnMoveUp.Enabled = false;
            btnMoveDown.Enabled = false;
            btnDeleteRecord.Enabled = false;
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            RecordBase record2, record1 = (RecordBase) lbRecords.SelectedItem;
            int ndx1 = records.IndexOf(record1);
            int ndx2 = ndx1 - 1;

            if(ndx2 >= 0)
            {
                record2 = records[ndx2];
                records.RemoveAt(ndx1);
                records.RemoveAt(ndx2);
                records.Insert(ndx2, record1);
                records.Insert(ndx1, record2);

                lbRecords.SelectedIndex = ndx2;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            RecordBase record2, record1 = (RecordBase) lbRecords.SelectedItem;
            int ndx1 = records.IndexOf(record1);
            int ndx2 = ndx1 + 1;

            if(ndx2 < records.Count)
            {
                record2 = records[ndx2];
                records.RemoveAt(ndx2);
                records.RemoveAt(ndx1);
                records.Insert(ndx1, record2);
                records.Insert(ndx2, record1);

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
                ClickRecordType clickType = ClickRecordType.NoClick;

                switch(e.Button)
                {
                    case MouseButtons.Left:
                        clickType = ClickRecordType.LeftClick;
                        break;

                    case MouseButtons.Middle:
                        clickType = ClickRecordType.MiddleClick;
                        break;

                    case MouseButtons.Right:
                        clickType = ClickRecordType.RightClick;
                        break;
                }

                if(stopwatch.IsRunning)
                {
                    records.Add(new DurationRecord(GUIUtilities.ToInt32(stopwatch.ElapsedMilliseconds)));
                    stopwatch.Restart();
                }

                else stopwatch.Start();

                records.Add(new ClickRecord(clickType, Cursor.Position));
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
                generatedNode.SetOption("records", RecordBase.DeepCopy(records));
                generatedNode.SetOption("nodeSettings", nodeSettings.ToDictionary(e => e.Key, e => e.Value));
                generatedNode.SetOption("timeSettings", timeSettings.ToDictionary(e => e.Key, e => e.Value));

                _okExit = true;
                Close();
            }

            else MessageBox.Show("Your node cannot be nameless, mortal!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnModifyRecord_Click(object sender, EventArgs e)
        {
            int ndx = lbRecords.SelectedIndex;
            RecordBase record = (RecordBase) lbRecords.SelectedItem;
            

            using(GBGClickAddModifyRecord modForm = new GBGClickAddModifyRecord(record))
            {
                modForm.ShowDialog(this);
                if(modForm.OkExit)
                {
                    RecordBase gen = modForm.GetGeneratedRecord();

                    records.RemoveAt(ndx);
                    records.Insert(ndx, gen);
                    lbRecords.SelectedIndex = ndx;
                    parent.WriteLogLine("Record modification accepted!");
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
                    RecordBase mac = modForm.GetGeneratedRecord();

                    if(lbRecords.SelectedIndex >= 0)
                        records.Insert(lbRecords.SelectedIndex+1, mac);
                    else
                        records.Add(mac);

                    parent.WriteLogLine("New record accepted!");
                }

                else parent.WriteLogLine("Record creation cancelled.");
            }
        }
    }
}
