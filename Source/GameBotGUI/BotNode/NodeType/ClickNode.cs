using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI
{
    class ClickNode : GBGBotNode
    {
        public ClickNode(String name)
            : base(name, BotNodeType.ClickNode)
        {
            
        }

        public override Object Clone()
        {
            ClickNode newNode = new ClickNode(Name);
            newNode.SetOptions(getNonDefaultOptions());
            return newNode;
        }
    }
}
