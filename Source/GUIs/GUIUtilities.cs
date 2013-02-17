using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameBotGUI
{
    static class GUIUtilities
    {
        // Depending on the max limit of the NumericUpDown,
        // it might be a long or a decimal...
        public static void SetNumericUpDownValue(NumericUpDown control, Object value)
        {
            control.Value = ToInt32(value);
        }

        public static Int32 ToInt32(Object value)
        {
            return Convert.ToInt32(value);
        }
    }
}
