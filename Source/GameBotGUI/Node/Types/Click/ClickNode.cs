using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBotGUI.Node.Types;

namespace GameBotGUI.Node.Types.Click
{
    class ClickNode : GenericNode
    {
        public ClickNode(String name)
            : base(name, NodeType.ClickNode)
        {
            
        }

        public override Object Clone()
        {
            ClickNode newNode = new ClickNode(Name);
            newNode.Settings = (NodeSettings) Settings.Clone();
            return newNode;
        }
    }
}
