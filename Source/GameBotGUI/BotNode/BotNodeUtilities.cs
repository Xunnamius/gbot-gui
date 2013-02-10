using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

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
                {"records", new ObservableCollection<MacroRecordBase>()},
                {"nodeSettings", SettingsUtilities.GenerateDefaultNodeSettingsDictionary() },
                {"timeSettings", SettingsUtilities.GenerateDefaultTimeSettingsDictionary() }
            };
        }
    }
}
