using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBotGUI.Node;

namespace GameBotGUI
{
    internal partial class GBGNodeSettings : Form
    {
        private GBGNodeCreateModify parent;
        private InternalNodeSettings nodeSettings;

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        public GBGNodeSettings(GBGNodeCreateModify parent, InternalNodeSettings nodeSettings)
        {
            InitializeComponent();
            this.parent = parent;
            this.nodeSettings = nodeSettings;
        }

        private void GBGNodeSettings_Load(Object sender, EventArgs e)
        {
            cbPriority.Items.AddRange(Enum.GetNames(typeof(PriorityLevel)));
            cbMouseSpeed.Items.AddRange(Enum.GetNames(typeof(MouseSpeed)));

            chbxEnabled.CheckState = nodeSettings.Enabled;
            cbPriority.SelectedIndex = (Int32) nodeSettings.Priority;
            numLRuns.Value = nodeSettings.Runs;
            cbMouseSpeed.SelectedIndex = (Int32) nodeSettings.MouseSpeed;
            numLOffsetX.Value = nodeSettings.OffsetX;
            numLOffsetY.Value = nodeSettings.OffsetY;
        }

        public InternalNodeSettings GetSettings()
        {
            return nodeSettings;
        }

        private void btnOk_Click(Object sender, EventArgs e)
        {
            nodeSettings.Enabled = chbxEnabled.CheckState;
            nodeSettings.Priority = (PriorityLevel) cbPriority.SelectedIndex;
            nodeSettings.Runs = GUIUtilities.ToInt32(numLRuns.Value);
            nodeSettings.MouseSpeed = (MouseSpeed) cbMouseSpeed.SelectedIndex;
            nodeSettings.OffsetX = GUIUtilities.ToInt32(numLOffsetX.Value);
            nodeSettings.OffsetY = GUIUtilities.ToInt32(numLOffsetY.Value);

            _okExit = true;
            Close();
            Dispose();
        }
    }
}
