using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using GameBotGUI.Record;

namespace GameBotGUI.Node.Types
{
    [Serializable()]
    class GenericNode : INode, ICloneable
    {
        public NodeSettings Settings { get; set; }

        public String Name { get { return Settings.Name; } }
        public NodeType Type { get { return Settings.Type; } }
        public String Display { get { return ToString(); } }

        public GenericNode(String name, NodeType type)
        {
            // Initialize with default settings
            Settings = new NodeSettings(name, type,
                new ObservableCollection<RecordBase>(),
                new InternalNodeSettings(Properties.Settings.Default.defaultEnabled,
                    (PriorityLevel) Properties.Settings.Default.defaultPriorityLevel,
                    Properties.Settings.Default.defaultNodeRuns,
                    Properties.Settings.Default.defaultVOffset,
                    Properties.Settings.Default.defaultHOffset,
                    (MouseSpeed) Properties.Settings.Default.defaultMouseSpeed),
                new InternalTimeSettings(
                    (EntropyLevel) Properties.Settings.Default.defaultNodeEntropy,
                    Properties.Settings.Default.defaultForcedPause));
        }

        public virtual Object Clone()
        {
            GenericNode newNode = new GenericNode(Name, Type);
            newNode.Settings = (NodeSettings) Settings.Clone();
            return newNode;
        }

        public virtual new String ToString()
        {
            return "[" + Type + "]: " + Name;
        }
    }
}
