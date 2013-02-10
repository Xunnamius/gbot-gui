using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI.Node
{
    interface INode
    {
        String Name { get; }
        NodeType Type { get; }
        void SetOptions(Dictionary<String, Object> dict);
        Dictionary<String, Object> getNonDefaultOptions();
    }
}
