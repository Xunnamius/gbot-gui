using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI
{
    class ClickMacroRecord : MacroRecordBase
    {
        public ClickMacroRecord(Dictionary<String, Object> data, MacroRecordType clickType)
            : base(data, clickType)
        {

        }

        public override String ToString()
        {
            return Type.ToString() + " @ " + GetData()["point"].ToString();
        }
    }
}
