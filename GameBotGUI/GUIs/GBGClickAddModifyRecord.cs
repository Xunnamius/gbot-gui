using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameBotGUI
{
    internal partial class GBGClickAddModifyRecord : Form
    {
        MacroRecordBase newRecord = null;

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        public GBGClickAddModifyRecord()
        {
            InitializeComponent();
        }

        public GBGClickAddModifyRecord(MacroRecordBase record)
        {
            InitializeComponent();
            newRecord = record;
        }

        private void GBGClickAddModifyRecord_Load(object sender, EventArgs e)
        {
            cbRecordType.DisplayMember = "Key";
            cbRecordType.ValueMember = "Value";

            foreach(MacroRecordType recordType in Enum.GetValues(typeof(MacroRecordType)))
                cbRecordType.Items.Add(new KeyValuePair<String, MacroRecordType>(recordType.ToString(), recordType));

            cbRecordType.SelectedIndexChanged += new EventHandler((sendr, evtargs) =>
            {
                KeyValuePair<String, MacroRecordType> selection =
                    (KeyValuePair<String, MacroRecordType>) cbRecordType.SelectedItem;

                if(selection.Value == MacroRecordType.Duration)
                    showMS();
                else
                    showXY();

                btnOk.Enabled = true;
            });

            if(newRecord != null)
            {
                Text = "Modify a record";
                cbRecordType.SelectedIndex = (Int32) newRecord.Type;

                KeyValuePair<String, MacroRecordType> selection =
                    (KeyValuePair<String, MacroRecordType>) cbRecordType.SelectedItem;

                if(selection.Value == MacroRecordType.Duration)
                    numDuration.Value = (Int32) newRecord.GetData()["duration"];
                else
                {
                    Point point = (Point) newRecord.GetData()["point"];
                    numX.Value = point.X;
                    numY.Value = point.Y;
                }
            }

            else Text = "Add a record";
        }

        public MacroRecordBase GetGeneratedRecord()
        {
            return newRecord;
        }

        private void showXY()
        {
            lblData.Visible = true;
            numDuration.Visible = false;
            lblMilliseconds.Visible = false;
            lblX.Visible = true;
            lblY.Visible = true;
            numX.Visible = true;
            numY.Visible = true;
        }

        private void showMS()
        {
            lblData.Visible = true;
            numDuration.Visible = true;
            lblMilliseconds.Visible = true;
            lblX.Visible = false;
            lblY.Visible = false;
            numX.Visible = false;
            numY.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            KeyValuePair<String, MacroRecordType> selection =
                    (KeyValuePair<String, MacroRecordType>) cbRecordType.SelectedItem;

            if(selection.Value == MacroRecordType.Duration)
                newRecord = new DurationMacroRecord(new Dictionary<string,object>(){ { "duration", (Int32) numDuration.Value } });
            else
            {
                newRecord = new ClickMacroRecord(new Dictionary<string, object>()
                {
                    { "point", new Point((Int32) numX.Value, (Int32) numY.Value) }
                }, selection.Value);
            }

            _okExit = true;
            Close();
        }
    }
}
