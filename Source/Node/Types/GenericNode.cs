using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBotGUI.Record;
using System.ComponentModel;

namespace GameBotGUI.Node.Types
{
    [Serializable()]
    public class GenericNode : INode, ICloneable
    {
        public NodeSettings Settings { get; set; }

        public String Name { get { return Settings.Name; } }
        public NodeType Type { get { return Settings.Type; } }
        public String Display { get { return ToString(); } }

        public GenericNode(String name, NodeType type)
        {
            // Initialize with default settings
            Settings = new NodeSettings(name, type,
                new BindingList<RecordBase>(),
                new InternalNodeSettings(Properties.Settings.Default.DefaultEnabled,
                    (PriorityLevel) Properties.Settings.Default.DefaultPriorityLevel,
                    Properties.Settings.Default.DefaultNodeRuns,
                    Properties.Settings.Default.DefaultVOffset,
                    Properties.Settings.Default.DefaultHOffset,
                    (MouseSpeed) Properties.Settings.Default.DefaultMouseSpeed),
                new InternalTimeSettings(
                    (EntropyLevel) Properties.Settings.Default.DefaultNodeEntropy,
                    Properties.Settings.Default.DefaultForcedPause));
        }

        public virtual Object Clone()
        {
            GenericNode newNode = new GenericNode(Name, Type);
            newNode.Settings = (NodeSettings) Settings.Clone();
            return newNode;
        }

        public override String ToString()
        {
            return "[" + Type + "]: " + Name;
        }
    }
}
