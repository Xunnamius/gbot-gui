using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBotGUI
{
    static class BotNodeUtilities
    {
        public static Dictionary<String, Object> GenerateDefaultOptionsDictionary()
        {
            return new Dictionary<string, object>()
            {
                {"name", "(no name)"},
                {"type", BotNodeType.GenericNode},
                {"records", new List<MacroRecordBase>()},
                {"nodeSettings", SettingsUtilities.GenerateDefaultNodeSettingsDictionary() },
                {"timeSettings", SettingsUtilities.GenerateDefaultTimeSettingsDictionary() }
            };
        }
    }
}
