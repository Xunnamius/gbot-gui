using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBotGUI.Record;

namespace GameBotGUI.Record.Types.Duration
{
    [Serializable()]
    public class DurationRecord : RecordBase
    {
        private Int32 _duration;
        public Int32 Duration
        {
            get { return _duration; }
            set { _duration = value < 0 ? 0 : value; }
        }

        public DurationRecord(Int32 duration)
            : base(RecordType.DurationRecord)
        {
            _duration = duration;
        }

        public override String ToString()
        {
            return "-- " + Type.ToString() + " for " + Duration.ToString() + " ms --";
        }

        public override Object Clone()
        {
            return new DurationRecord(Duration);
        }
    }
}
