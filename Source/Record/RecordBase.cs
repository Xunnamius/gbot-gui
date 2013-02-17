using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GameBotGUI.Record.Types.Click;

namespace GameBotGUI.Record
{
    [Serializable()]
    public abstract class RecordBase
    {
        public RecordType Type { get; set; }
        public String Display { get { return ToString(); } }

        public RecordBase(RecordType type)
        {
            Type = type;
        }

        public override String ToString()
        {
            return Type.ToString();
        }

        public virtual Object Clone()
        {
            return null;
        }
    }
}
