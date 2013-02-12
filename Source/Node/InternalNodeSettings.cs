using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI.Node
{
    class InternalNodeSettings : ICloneable
    {
        private System.Windows.Forms.CheckState _enabled;
        private PriorityLevel _priority;
        private Int32 _runs;
        private Int32 _vOffset;
        private Int32 _hOffset;
        private MouseSpeed _mouseSpeed;

        public System.Windows.Forms.CheckState Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public PriorityLevel Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        public Int32 Runs
        {
            get { return _runs; }
            set { _runs = value < 1 ? 1 : value; }
        }

        public Int32 VOffset
        {
            get { return _vOffset; }
            set { _vOffset = value; }
        }

        public Int32 HOffset
        {
            get { return _hOffset; }
            set { _hOffset = value; }
        }

        public MouseSpeed MouseSpeed
        {
            get { return _mouseSpeed; }
            set { _mouseSpeed = value; }
        }

        public InternalNodeSettings(System.Windows.Forms.CheckState enabled,
            PriorityLevel priority,
            Int32 repeat,
            Int32 vOffset,
            Int32 hOffset,
            MouseSpeed mouseSpeed)
        {
            _enabled = enabled;
            _priority = priority;
            _runs = repeat;
            _vOffset = vOffset;
            _hOffset = hOffset;
            _mouseSpeed = mouseSpeed;
        }

        public object Clone()
        {
            return new InternalNodeSettings(Enabled, Priority, Runs, VOffset, HOffset, MouseSpeed);
        }
    }
}
