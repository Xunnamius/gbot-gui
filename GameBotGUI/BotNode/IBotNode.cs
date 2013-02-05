using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI
{
    interface IBotNode
    {
        String Name { get; }
        BotNodeType Type { get; }
        void SetOptions(Dictionary<String, Object> dict);
        Dictionary<String, Object> getNonDefaultOptions();
    }
}
