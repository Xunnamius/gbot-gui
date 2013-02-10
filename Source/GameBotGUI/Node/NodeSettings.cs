using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GameBotGUI.Record;

namespace GameBotGUI.Node
{
    class NodeSettings : ICloneable
    {
        private String _name;
        private NodeType _type;
        private ObservableCollection<RecordBase> _records;
        private InternalNodeSettings _internalNodeSettings;
        private InternalTimeSettings _internalTimeSettings;

        public String Name
        {
            get { return _name; }
            set { _name = value ?? Properties.Settings.Default.defaultNodeName; }
        }

        public NodeType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public ObservableCollection<RecordBase> Records
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
            ObservableCollection<RecordBase> records,
            InternalNodeSettings itNodeSettings,
            InternalTimeSettings itTimeSettings)
        {
            _name = name;
            _type = type;
            _records = records;
            _internalNodeSettings = itNodeSettings;
            _internalTimeSettings = itTimeSettings;
        }

        public object Clone()
        {
            return new NodeSettings(Name, Type,
                new ObservableCollection<RecordBase>(_records.ToList()),
                (InternalNodeSettings) internalNodeSettings.Clone(),
                (InternalTimeSettings) internalTimeSettings.Clone());
        }
    }
}
