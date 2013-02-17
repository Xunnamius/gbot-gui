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
    internal partial class GBGApplicationSettings : Form
    {
        private GBGMain parent;
        private ApplicationSettings applicationSettings;

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        public GBGApplicationSettings(GBGMain parent, ApplicationSettings applicationSettings)
        {
            InitializeComponent();
            this.parent = parent;
            this.applicationSettings = applicationSettings;
        }

        private void GBGApplicationSettings_Load(Object sender, EventArgs e)
        {
            cbInternodeEntropy.Items.AddRange(Enum.GetNames(typeof(EntropyLevel)));
            cbExecutionScheme.Items.AddRange(Enum.GetNames(typeof(ExecutionScheme)));

            cbInternodeEntropy.SelectedIndex = (Int32) applicationSettings.InternodeEntropy;
            chbxEnableIntranodeEntropy.CheckState = applicationSettings.IntranodeEntropyEnabled;
            chbxEnableIntranodeForcedPause.CheckState = applicationSettings.IntranodeForcedPauseEnabled;
            cbExecutionScheme.SelectedIndex = (Int32) applicationSettings.ExecScheme;
            numGOffsetX.Value = applicationSettings.GlobalOffsetX;
            numGOffsetY.Value = applicationSettings.GlobalOffsetY;
            numGlobalRuns.Value = applicationSettings.TotalRuns;
            chbxRunIndefinitely.CheckState = applicationSettings.RunInfinityTimes;
            chbxMinimizeOnRun.CheckState = applicationSettings.MinimizeWindowOnRun;
        }

        public ApplicationSettings GetSettings()
        {
            return applicationSettings;
        }

        private void btnOk_Click(Object sender, EventArgs e)
        {
            applicationSettings.InternodeEntropy = (EntropyLevel) cbInternodeEntropy.SelectedIndex;
            applicationSettings.IntranodeEntropyEnabled = chbxEnableIntranodeEntropy.CheckState;
            applicationSettings.IntranodeForcedPauseEnabled = chbxEnableIntranodeForcedPause.CheckState;
            applicationSettings.ExecScheme = (ExecutionScheme) cbExecutionScheme.SelectedIndex;
            applicationSettings.GlobalOffsetX = GUIUtilities.ToInt32(numGOffsetX.Value);
            applicationSettings.GlobalOffsetY = GUIUtilities.ToInt32(numGOffsetY.Value);
            applicationSettings.TotalRuns = GUIUtilities.ToInt32(numGlobalRuns.Value);
            applicationSettings.RunInfinityTimes = chbxRunIndefinitely.CheckState;
            applicationSettings.MinimizeWindowOnRun = chbxMinimizeOnRun.CheckState;

            _okExit = true;
            Close();
            Dispose();
        }

        private void chbxRunIndefinitely_CheckedChanged(Object sender, EventArgs e)
        {
            if(chbxRunIndefinitely.CheckState != CheckState.Unchecked)
                numGlobalRuns.Enabled = false;
            else
                numGlobalRuns.Enabled = true;
        }
    }
}
