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
    public partial class GBGProfileSettings : Form
    {
        private GBGMain parent;
        private Dictionary<String, Object> profileSettings;

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        public GBGProfileSettings(GBGMain parent, Dictionary<String, Object> profileSettings)
        {
            InitializeComponent();
            this.parent = parent;
            this.profileSettings = profileSettings;
        }

        private void GBGProfileSettings_Load(object sender, EventArgs e)
        {

        }

        public Dictionary<String, Object> GetGeneratedSettings()
        {
            return profileSettings.ToDictionary(entry => entry.Key, entry => entry.Value); ;
        }

        // _okExit = true;
    }
}
