using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI
{
    class GBGBotNode : IBotNode, ICloneable
    {
        private String _name;
        private BotNodeType _type;
        protected Dictionary<String, Object> defaultOptions = BotNodeUtilities.GenerateDefaultOptionsDictionary();
        private Dictionary<String, Object> options = BotNodeUtilities.GenerateDefaultOptionsDictionary();

        public String Name { get { return _name; } set {} }
        public BotNodeType Type { get { return _type; } set {} }

        public GBGBotNode(String name, BotNodeType type)
        {
            _name = name ?? (String) defaultOptions["name"];
            _type = type;
        }

        public Object Clone()
        {
            GBGBotNode newNode = new GBGBotNode(Name, Type);
            newNode.SetOptions(getNonDefaultOptions());
            return newNode;
        }

        public void SetOptions(Dictionary<String, Object> dict)
        {
            options = dict;
        }

        public void SetOption(String key, Object value)
        {
            options[key] = value;
        }

        public Dictionary<String, Object> getNonDefaultOptions()
        {
            return options.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        public Object GetOption(String key)
        {
            if(options.ContainsKey(key))
                return options[key];

            else if(defaultOptions.ContainsKey(key))
                return defaultOptions[key];

            throw new ArgumentOutOfRangeException();
        }
    }
}
