using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameBotGUI.Record.Types.Click
{
    class ClickRecord : RecordBase
    {
        private ClickRecordType _subType;
        public ClickRecordType SubType { get { return _subType; } }
        public Point TargetPoint { get; set; }

        public ClickRecord(ClickRecordType clickType, Point point)
            : base(RecordType.ClickRecord)
        {
            _subType = clickType;
            TargetPoint = point;
        }

        public override String ToString()
        {
            return Type.ToString() + " @ " + TargetPoint.ToString();
        }

        public override object Clone()
        {
            return new ClickRecord(SubType, TargetPoint);
        }
    }
}
