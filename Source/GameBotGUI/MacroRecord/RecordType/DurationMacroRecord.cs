using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI
{
    class DurationMacroRecord : MacroRecordBase
    {
        public DurationMacroRecord(Dictionary<String, Object> data)
            : base(data, MacroRecordType.Duration)
        {

        }

        public override String ToString()
        {
            return "-- " + Type.ToString() + " for " + GetData()["duration"].ToString() + " ms --";
        }

        public override object Clone()
        {
            return new DurationMacroRecord(GetData());
        }
    }
}
