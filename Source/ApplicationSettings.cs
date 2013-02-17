using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameBotGUI
{
    public class ApplicationSettings : ICloneable
    {
        private GameBotGUI.Node.EntropyLevel _internodeEntropy;
        private CheckState _intranodeForcedPauseEnabled;
        private CheckState _intranodeEntropyEnabled;
        private ExecutionScheme _executionScheme;
        private Int32 _totalRuns;
        private CheckState _runInfinityTimes;
        private Int32 _globalOffsetX;
        private Int32 _globalOffsetY;
        private CheckState _minimizeWindowOnRun;

        public GameBotGUI.Node.EntropyLevel InternodeEntropy
        {
            get { return _internodeEntropy; }
            set { _internodeEntropy = value; }
        }

        public CheckState IntranodeForcedPauseEnabled
        {
            get { return _intranodeForcedPauseEnabled; }
            set { _intranodeForcedPauseEnabled = value; }
        }

        public CheckState IntranodeEntropyEnabled
        {
            get { return _intranodeEntropyEnabled; }
            set { _intranodeEntropyEnabled = value; }
        }

        public ExecutionScheme ExecScheme
        {
            get { return _executionScheme; }
            set { _executionScheme = value; }
        }

        public Int32 TotalRuns
        {
            get { return _totalRuns; }
            set { _totalRuns = value; }
        }

        public CheckState RunInfinityTimes
        {
            get { return _runInfinityTimes; }
            set { _runInfinityTimes = value; }
        }

        public Int32 GlobalOffsetX
        {
            get { return _globalOffsetX; }
            set { _globalOffsetX = value; }
        }

        public Int32 GlobalOffsetY
        {
            get { return _globalOffsetY; }
            set { _globalOffsetY = value; }
        }

        public CheckState MinimizeWindowOnRun
        {
            get { return _minimizeWindowOnRun; }
            set { _minimizeWindowOnRun = value; }
        }

        public ApplicationSettings(
            GameBotGUI.Node.EntropyLevel internodeEntropy,
            CheckState intranodeForcedPauseEnabled,
            CheckState intranodeEntropyEnabled,
            ExecutionScheme executionScheme,
            Int32 totalRuns,
            CheckState runInfinityTimes,
            Int32 globalOffsetX,
            Int32 globalOffsetY,
            CheckState minimizeWindowOnRun)
        {
            _internodeEntropy = internodeEntropy;
            _intranodeForcedPauseEnabled = intranodeForcedPauseEnabled;
            _intranodeEntropyEnabled = intranodeEntropyEnabled;
            _executionScheme = executionScheme;
            _totalRuns = totalRuns;
            _runInfinityTimes = runInfinityTimes;
            _globalOffsetX = globalOffsetX;
            _globalOffsetY = globalOffsetY;
            _minimizeWindowOnRun = minimizeWindowOnRun;
        }

        public Object Clone()
        {
            return new ApplicationSettings(
                InternodeEntropy,
                IntranodeForcedPauseEnabled,
                IntranodeEntropyEnabled,
                ExecScheme,
                TotalRuns,
                RunInfinityTimes,
                GlobalOffsetX,
                GlobalOffsetY,
                MinimizeWindowOnRun);
        }
    }
}
