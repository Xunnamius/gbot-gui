using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI.Node
{
    class InternalTimeSettings : ICloneable
    {
        private EntropyLevel _entropy;
        private Int32 _forcedPause;

        public EntropyLevel Entropy
        {
            get { return _entropy; }
            set { _entropy = value; }
        }

        public Int32 ForcedPause
        {
            get { return _forcedPause; }
            set { _forcedPause = value < 0 ? 0 : value; }
        }

        public InternalTimeSettings(EntropyLevel entropy, Int32 forcedPause)
        {
            _entropy = entropy;
            _forcedPause = forcedPause;
        }

        public object Clone()
        {
            return new InternalTimeSettings(Entropy, ForcedPause);
        }
    }
}
