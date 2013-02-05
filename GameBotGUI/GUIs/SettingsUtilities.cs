using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameBotGUI
{
    static class SettingsUtilities
    {
        public static Dictionary<String, Object> GenerateDefaultApplicationSettingsDictionary()
        {
            return new Dictionary<string, object>()
            {
                { "cbInternodeEntropy", 1 },
                { "chbxEnableIntranodeEntropy", 1 },
                { "chbxEnableIntranodeForcedPause", 1 },
                { "cbExecutionScheme", 0 }
            };
        }

        public static Dictionary<String, Object> GenerateDefaultProfileSettingsDictionary()
        {
            return new Dictionary<string, object>()
            {

            };
        }

        public static Dictionary<String, Object> GenerateDefaultNodeSettingsDictionary()
        {
            return new Dictionary<string, object>()
            {
                { "chbxEnabled", 1 },
                { "cbPriority", 1 },
                { "numRepeat", 1 },
                { "cbMouseSpeed", 1 }
            };
        }

        public static Dictionary<String, Object> GenerateDefaultTimeSettingsDictionary()
        {
            return new Dictionary<string, object>()
            {
                { "cbEntropy", 1 },
                { "numForcedPause", 0 }
            };
        }

        public static void ProcessSettingsData(Form form, Dictionary<String, Object> settings)
        {
            foreach(KeyValuePair<String, Object> setting in settings)
            {
                Control[] controls = form.Controls.Find(setting.Key, false);
                if(controls.Length == 1)
                {
                    Control control = controls[0];
                    if(control is ComboBox)
                        ((ComboBox) control).SelectedIndex = (Int32) setting.Value;

                    else if(control is CheckBox)
                    {
                        CheckState state = CheckState.Unchecked;
                        Int32 val = (Int32) setting.Value;

                        if(val == 1)      state = CheckState.Indeterminate;
                        else if(val == 2) state = CheckState.Checked;
                        ((CheckBox) control).CheckState = state;
                    }

                    else if(control is NumericUpDown)
                        SetNumericUpDownValue((NumericUpDown) control, setting.Value);
                }
            }
        }

        public static Int32 CheckState2Int32(CheckState state)
        {
            Int32 stateInt32 = 0;
            if(state == CheckState.Indeterminate) stateInt32 = 1;
            else if(state == CheckState.Checked)  stateInt32 = 2;
            return stateInt32;
        }

        // Depending on the max limit of the NumericUpDown,
        // it might be a long or a decimal...
        public static void SetNumericUpDownValue(NumericUpDown control, object value)
        {
            control.Value = ToInt32(value);
        }

        public static Int32 ToInt32(object value)
        {
            try
            {
                return (Int32) value;
            }

            catch(InvalidCastException edgecase)
            {
                return (Int32) ((long) value);
            }
        }
    }
}
