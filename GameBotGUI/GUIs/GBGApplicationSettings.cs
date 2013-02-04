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
    public partial class GBGApplicationSettings : Form
    {
        private GBGMain parent;
        private Dictionary<String, Object> applicationSettings;

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        public GBGApplicationSettings(GBGMain parent, Dictionary<String, Object> applicationSettings)
        {
            InitializeComponent();
            this.parent = parent;
            this.applicationSettings = applicationSettings;
        }

        private void GBGApplicationSettings_Load(object sender, EventArgs e)
        {
            SettingsUtilities.ProcessSettingsData(this, applicationSettings);
        }

        public Dictionary<String, Object> GetGeneratedSettings()
        {
            return applicationSettings.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            applicationSettings["cbInternodeEntropy" ] = cbInternodeEntropy.SelectedIndex;
            applicationSettings["chbxEnableIntranodeEntropy" ] = SettingsUtilities.CheckState2Int32(chbxEnableIntranodeEntropy.CheckState);
            applicationSettings["chbxEnableIntranodeForcedPause" ] = SettingsUtilities.CheckState2Int32(chbxEnableIntranodeForcedPause.CheckState);
            applicationSettings["cbExecutionScheme" ] = cbExecutionScheme.SelectedIndex;

            _okExit = true;
            Close();
        }
    }
}
