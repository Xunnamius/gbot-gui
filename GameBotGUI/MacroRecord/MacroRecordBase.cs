using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI
{
    abstract class MacroRecordBase
    {
        private Dictionary<String, Object> Data;
        public readonly MacroRecordType Type;
        public String Display { get { return ToString(); } }

        public MacroRecordBase(Dictionary<String, Object> data, MacroRecordType type)
        {
            Data = data;
            Type = type;
        }

        public Dictionary<String, Object> GetData()
        {
            return Data;
        }

        public virtual new String ToString()
        {
            return Type.ToString();
        }
    }
}
