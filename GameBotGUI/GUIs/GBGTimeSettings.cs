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
    internal partial class GBGTimeSettings : Form
    {
        private GBGClickCreateModify parent;
        private Dictionary<String, Object> timeSettings;

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        public GBGTimeSettings(GBGClickCreateModify parent, Dictionary<string, object> timeSettings)
        {
            InitializeComponent();
            this.parent = parent;
            this.timeSettings = timeSettings;
        }

        private void GBGTimeSettings_Load(object sender, EventArgs e)
        {
            SettingsUtilities.ProcessSettingsData(this, timeSettings);
        }

        public Dictionary<String, Object> GetGeneratedSettings()
        {
            return timeSettings.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            timeSettings["cbEntropy"] = cbEntropy.SelectedIndex;
            timeSettings["numForcedPause"] = (Int32) numForcedPause.Value;

            _okExit = true;
            Close();
        }
    }
}
