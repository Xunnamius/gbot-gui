using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBotGUI.Record;
using System.ComponentModel;

namespace GameBotGUI.Node
{
    [Serializable()]
    public class NodeSettings : ICloneable
    {
        private String _name;
        private NodeType _type;

        // XXX: For serializability
        private BindingList<RecordBase> _records { get; set; }
        private InternalNodeSettings _internalNodeSettings { get; set; }
        private InternalTimeSettings _internalTimeSettings { get; set; }
        //

        public String Name
        {
            get { return _name; }
            set { _name = value ?? Properties.Settings.Default.DefaultNodeName; }
        }

        public NodeType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public BindingList<RecordBase> Records
        {
            get { return _records; }
            set { _records = value; }
        }

        public InternalNodeSettings internalNodeSettings
        {
            get { return _internalNodeSettings; }
            set { _internalNodeSettings = value; }
        }

        public InternalTimeSettings internalTimeSettings
        {
            get { return _internalTimeSettings; }
            set { _internalTimeSettings = value; }
        }

        public NodeSettings(String name,
            NodeType type,
            BindingList<RecordBase> records,
            InternalNodeSettings itNodeSettings,
            InternalTimeSettings itTimeSettings)
        {
            _name = name;
            _type = type;
            _records = records;
            _internalNodeSettings = itNodeSettings;
            _internalTimeSettings = itTimeSettings;
        }

        public Object Clone()
        {
            BindingList<RecordBase> bl = new BindingList<RecordBase>();
            foreach(RecordBase record in _records)
                bl.Add((RecordBase) record.Clone());

            return new NodeSettings(Name, Type, bl,
                (InternalNodeSettings) internalNodeSettings.Clone(),
                (InternalTimeSettings) internalTimeSettings.Clone());
        }
    }
}
