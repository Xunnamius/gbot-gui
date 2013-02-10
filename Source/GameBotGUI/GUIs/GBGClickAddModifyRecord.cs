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
        RecordBase newRecord = null;

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        public GBGClickAddModifyRecord()
        {
            InitializeComponent();
        }

        public GBGClickAddModifyRecord(RecordBase record)
        {
            InitializeComponent();
            newRecord = record;
        }

        private void GBGClickAddModifyRecord_Load(object sender, EventArgs e)
        {
            cbRecordType.DisplayMember = "Key";
            cbRecordType.ValueMember = "Value";

            foreach(ClickRecordType recordType in Enum.GetValues(typeof(ClickRecordType)))
                cbRecordType.Items.Add(new KeyValuePair<String, ClickRecordType>(recordType.ToString(), recordType));

            cbRecordType.SelectedIndexChanged += new EventHandler((sendr, evtargs) =>
            {
                KeyValuePair<String, ClickRecordType> selection =
                    (KeyValuePair<String, ClickRecordType>) cbRecordType.SelectedItem;

                if(selection.Value == ClickRecordType.Duration)
                    showMS();
                else
                    showXY();

                btnOk.Enabled = true;
            });

            if(newRecord != null)
            {
                Text = "Modify a record";
                cbRecordType.SelectedIndex = (Int32) newRecord.Type;

                KeyValuePair<String, ClickRecordType> selection =
                    (KeyValuePair<String, ClickRecordType>) cbRecordType.SelectedItem;

                if(selection.Value == ClickRecordType.Duration)
                    GUIUtilities.SetNumericUpDownValue(numDuration, newRecord.GetData()["duration"]);

                else
                {
                    Point point = (Point) newRecord.GetData()["point"];
                    numX.Value = point.X;
                    numY.Value = point.Y;
                }
            }

            else Text = "Add a record";
        }

        public RecordBase GetGeneratedRecord()
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
            KeyValuePair<String, ClickRecordType> selection =
                    (KeyValuePair<String, ClickRecordType>) cbRecordType.SelectedItem;

            if(selection.Value == ClickRecordType.Duration)
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
            Dispose();
        }
    }
}
