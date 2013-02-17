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
    internal partial class GBGTimeSettings : Form
    {
        private GBGNodeCreateModify parent;
        private InternalTimeSettings timeSettings;

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        public GBGTimeSettings(GBGNodeCreateModify parent, InternalTimeSettings timeSettings)
        {
            InitializeComponent();
            this.parent = parent;
            this.timeSettings = timeSettings;
        }

        private void GBGTimeSettings_Load(Object sender, EventArgs e)
        {
            cbEntropy.Items.AddRange(Enum.GetNames(typeof(EntropyLevel)));

            cbEntropy.SelectedIndex = (Int32) timeSettings.Entropy;
            numForcedPause.Value = timeSettings.ForcedPause;
        }

        public InternalTimeSettings GetSettings()
        {
            return timeSettings;
        }

        private void btnOk_Click(Object sender, EventArgs e)
        {
            timeSettings.Entropy = (EntropyLevel) cbEntropy.SelectedIndex;
            timeSettings.ForcedPause = GUIUtilities.ToInt32(numForcedPause.Value);

            _okExit = true;
            Close();
            Dispose();
        }
    }
}
