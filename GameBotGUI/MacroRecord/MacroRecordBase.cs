using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GameBotGUI
{
    abstract class MacroRecordBase
    {
        private Dictionary<String, Object> Data;
        public readonly MacroRecordType Type;
        public String Display { get { return ToString(); } }

        internal static ObservableCollection<MacroRecordBase> DeepCopy(ObservableCollection<MacroRecordBase> Records)
        {
            ObservableCollection<MacroRecordBase> nc = new ObservableCollection<MacroRecordBase>();

            foreach(MacroRecordBase record in Records)
            {
                nc.Add((MacroRecordBase) record.Clone());
            }

            return nc;
        }

        public MacroRecordBase(Dictionary<String, Object> data, MacroRecordType type)
        {
            Data = data;
            Type = type;
        }

        public Dictionary<String, Object> GetData()
        {
            return Data.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        public virtual new String ToString()
        {
            return Type.ToString();
        }

        public virtual object Clone()
        {
            return null;
        }
    }
}
