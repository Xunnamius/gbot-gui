using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameBotGUI
{
    internal partial class GBGNodeSettings : Form
    {
        private GBGClickCreateModify parent;
        private Dictionary<String, Object> nodeSettings;

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        public GBGNodeSettings(GBGClickCreateModify parent, Dictionary<string, object> nodeSettings)
        {
            InitializeComponent();
            this.parent = parent;
            this.nodeSettings = nodeSettings;
        }

        private void GBGNodeSettings_Load(object sender, EventArgs e)
        {
            SettingsUtilities.ProcessSettingsData(this, nodeSettings);
        }

        public Dictionary<String, Object> GetGeneratedSettings()
        {
            return nodeSettings.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            nodeSettings["chbxEnabled"] = SettingsUtilities.CheckState2Int32(chbxEnabled.CheckState);
            nodeSettings["cbPriority"] = cbPriority.SelectedIndex;
            nodeSettings["numRepeat"] = (Int32) numRepeat.Value;
            nodeSettings["cbMouseSpeed"] = cbMouseSpeed.SelectedIndex;

            _okExit = true;
            Close();
            Dispose();
        }
    }
}
