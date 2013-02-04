using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI
{
    interface IBotNode
    {
        String Name { get; set; }
        BotNodeType Type { get; set; }
        void SetOptions(Dictionary<String, Object> dict);
        Dictionary<String, Object> getNonDefaultOptions();
    }
}
