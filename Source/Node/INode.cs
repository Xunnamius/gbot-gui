using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI.Node
{
    public interface INode
    {
        String Name { get; }
        NodeType Type { get; }
    }
}
