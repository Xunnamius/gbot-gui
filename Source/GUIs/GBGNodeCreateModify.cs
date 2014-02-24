using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Forms;
using DarkGray.Forms.Decorators;
using GameBotGUI.Node.Types;
using GameBotGUI.Record;
using GameBotGUI.Record.Types.Click;
using GameBotGUI.Record.Types.Duration;
using System.ComponentModel;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace GameBotGUI
{
    internal partial class GBGNodeCreateModify : Form
    {
        private GBGMain parent;
        private int mouseTracking = 0;
        private GenericNode _internalNode = null;
        private Stopwatch stopwatch = new Stopwatch();

        private Boolean _okExit = false;
        private ExtendedListControl<RecordBase> elbRecords;

        public Boolean OkExit
        {
            get { return _okExit; }
        }

        public GenericNode InternalNode
        {
            get { return _internalNode; }
        }

        protected Boolean inCreateMode;
        protected ListChangedEventHandler recordListChangedHandler;

        private readonly KeyboardHookListener m_KeyboardHookManager;
        private readonly MouseHookListener m_MouseHookManager;

        public GBGNodeCreateModify(GBGMain parent, GenericNode internalNode, Boolean createMode)
        {
            InitializeComponent();

            this.parent = parent;
            inCreateMode = createMode;
            _internalNode = internalNode;

            m_KeyboardHookManager = new KeyboardHookListener(new GlobalHooker());
            m_KeyboardHookManager.Enabled = true;

            m_MouseHookManager = new MouseHookListener(new GlobalHooker());
            m_MouseHookManager.Enabled = true;

            m_MouseHookManager.MouseClick += HookManager_MouseClick;
            m_KeyboardHookManager.KeyPress += HookManager_KeyPress;
        }

        private void HookManager_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (mouseTracking == 1)
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

            else if (mouseTracking == 2)
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

        private void HookManager_MouseClick(object sender, MouseEventArgs e)
        {
            if (mouseTracking == 2)
            {
                ClickRecordType clickType = ClickRecordType.NoClick;

                switch (e.Button)
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

                if (stopwatch.IsRunning)
                {
                    InternalNode.Settings.Records.Add(new DurationRecord(GUIUtilities.ToInt32(stopwatch.ElapsedMilliseconds)));
                    stopwatch.Restart();
                }

                else stopwatch.Start();

                InternalNode.Settings.Records.Add(new ClickRecord(clickType, Cursor.Position));
            }
        }

        private void setDefaultTitle()
        {
            if(inCreateMode) Text = "Node Creator";
            else Text = "Modify Node";
        }

        private void GBGCreateAndModify_Load(Object sender, EventArgs e)
        {
            txbName.Text = _internalNode.Name;
            lbRecords.DataSource = InternalNode.Settings.Records;
            elbRecords = new ExtendedListControl<RecordBase>(lbRecords);
            recordListChangedHandler = new ListChangedEventHandler(Records_ListChanged);

            lbRecords.DisplayMember = "Display";
            setDefaultTitle();

            InternalNode.Settings.Records.ListChanged += recordListChangedHandler;
            InternalNode.Settings.Records.ResetBindings();
        }

        void Records_ListChanged(Object sender, ListChangedEventArgs e)
        {
            BindingList<RecordBase> recordList = (BindingList<RecordBase>) sender;

            if(recordList.Count > 0)
            {
                btnClear.Enabled = true;

                if(!lbRecords.Focused)
                    lbRecords.TopIndex = Math.Max(lbRecords.Items.Count - 1, 0);
            }

            else
            {
                btnModifyRecord.Enabled = false;
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = false;
                btnDeleteRecord.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void GBGNodeCreateModify_FormClosing(Object sender, FormClosingEventArgs e)
        {
            InternalNode.Settings.Records.ListChanged -= recordListChangedHandler;
            m_MouseHookManager.MouseClick -= HookManager_MouseClick;
            m_KeyboardHookManager.KeyPress -= HookManager_KeyPress;
            m_MouseHookManager.Enabled = false;
            m_KeyboardHookManager.Enabled = false;

            if(stopwatch.IsRunning)
                stopwatch.Stop();
        }

        private void btnClear_Click(Object sender, EventArgs e)
        {
            InternalNode.Settings.Records.Clear();
        }

        private void lbRecords_SelectedValueChanged(Object sender, EventArgs e)
        {
            if(lbRecords.SelectedIndex == -1)
            {
                btnDeleteRecord.Enabled = false;
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = false;
                btnModifyRecord.Enabled = false;
            }

            else
            {
                btnDeleteRecord.Enabled = true;
                btnMoveUp.Enabled = true;
                btnMoveDown.Enabled = true;
                btnModifyRecord.Enabled = true;
            }
        }

        private void btnDeleteRecord_Click(Object sender, EventArgs e)
        {
            elbRecords.SelectedDelete();
        }

        private void btnMoveUp_Click(Object sender, EventArgs e)
        {
            elbRecords.SelectedShiftUp();
        }

        private void btnMoveDown_Click(Object sender, EventArgs e)
        {
            elbRecords.SelectedShiftDown();
        }

        private void btnCaptureClicks_Click(Object sender, EventArgs e)
        {
            MessageBox.Show(this, "You are about to begin capturing clicks. "
                + "You will be alerted by a tray notification both when you begin "
                + "and end mouse tracking. Press any key after you close this "
                + "window to begin.");

            Text = "PRE-CAPTURE MODE [PRESS ANY KEY TO BEGIN]";
            Enabled = false;
            mouseTracking = 1;
        }

        private void btnNodeSettings_Click(Object sender, EventArgs e)
        {
            using(GBGNodeSettings nodeSettingsForm = new GBGNodeSettings(this, InternalNode.Settings.internalNodeSettings))
            {
                nodeSettingsForm.ShowDialog(this);

                if(nodeSettingsForm.OkExit)
                    parent.WriteLogLine("New node settings applied successfully.");
                else parent.WriteLogLine("Node settings modification cancelled.");
            }
        }

        private void btnTimeSettings_Click(Object sender, EventArgs e)
        {
            using(GBGTimeSettings timeSettingsForm = new GBGTimeSettings(this, InternalNode.Settings.internalTimeSettings))
            {
                timeSettingsForm.ShowDialog(this);

                if(timeSettingsForm.OkExit)
                    parent.WriteLogLine("New time settings applied successfully.");
                else parent.WriteLogLine("Time settings modification cancelled.");
            }
        }

        private void btnSave_Click(Object sender, EventArgs e)
        {
            if(txbName.Text.Length > 0)
            {
                _internalNode.Settings.Name = txbName.Text;
                _okExit = true;
                Close();
            }

            else MessageBox.Show("Your node cannot be nameless, mortal!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnModifyRecord_Click(Object sender, EventArgs e)
        {
            RecordBase record = (RecordBase) lbRecords.SelectedItem;
            
            using(GBGNodeAddModifyRecord modForm = new GBGNodeAddModifyRecord(record))
            {
                modForm.ShowDialog(this);

                if(modForm.OkExit)
                {
                    elbRecords.SelectedReplace(modForm.GetRecord());
                    parent.WriteLogLine("Record modification accepted.");
                }

                else
                    parent.WriteLogLine("Record modification attempt cancelled.");
            }
        }

        private void btnAdd_Click(Object sender, EventArgs e)
        {
            using(GBGNodeAddModifyRecord modForm = new GBGNodeAddModifyRecord())
            {
                modForm.ShowDialog(this);

                if(modForm.OkExit)
                {
                    elbRecords.RelativeAdd(modForm.GetRecord(), 1);
                    parent.WriteLogLine("New record accepted.");
                }

                else parent.WriteLogLine("Record creation cancelled.");
            }
        }
    }
}
