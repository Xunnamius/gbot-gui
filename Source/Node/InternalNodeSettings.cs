using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI.Node
{
    [Serializable()]
    public class InternalNodeSettings : ICloneable
    {
        private System.Windows.Forms.CheckState _enabled;
        private PriorityLevel _priority;
        private Int32 _runs;
        private Int32 _offsetX;
        private Int32 _offsetY;
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

        public Int32 OffsetX
        {
            get { return _offsetX; }
            set { _offsetX = value; }
        }

        public Int32 OffsetY
        {
            get { return _offsetY; }
            set { _offsetY = value; }
        }

        public MouseSpeed MouseSpeed
        {
            get { return _mouseSpeed; }
            set { _mouseSpeed = value; }
        }

        public InternalNodeSettings(System.Windows.Forms.CheckState enabled,
            PriorityLevel priority,
            Int32 repeat,
            Int32 offsetX,
            Int32 offsetY,
            MouseSpeed mouseSpeed)
        {
            _enabled = enabled;
            _priority = priority;
            _runs = repeat;
            _offsetX = offsetX;
            _offsetY = offsetY;
            _mouseSpeed = mouseSpeed;
        }

        public Object Clone()
        {
            return new InternalNodeSettings(Enabled, Priority, Runs, OffsetX, OffsetY, MouseSpeed);
        }
    }
}
