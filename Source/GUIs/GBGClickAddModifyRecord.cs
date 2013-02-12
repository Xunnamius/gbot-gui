using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBotGUI.Record;
using GameBotGUI.Record.Types.Click;
using GameBotGUI.Record.Types.Duration;

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

            Array clickRecordTypeEnumValues = Enum.GetValues(typeof(ClickRecordType));

            foreach(ClickRecordType recordType in clickRecordTypeEnumValues)
                cbRecordType.Items.Add(new KeyValuePair<String, ClickRecordType>(recordType.ToString(), recordType));

            // Tack on "Duration" at the end as well
            cbRecordType.Items.Add(
                new KeyValuePair<String, DurationRecordType>(
                    DurationRecordType.Duration.ToString(), DurationRecordType.Duration));

            cbRecordType.SelectedIndexChanged += new EventHandler((sendr, evtargs) =>
            {
                KeyValuePair<String, Object> selection =
                    (KeyValuePair<String, Object>) cbRecordType.SelectedItem;

                if(selection.Key == DurationRecordType.Duration.ToString())
                    showMS();
                else
                    showXY();

                btnOk.Enabled = true;
            });

            if(newRecord != null)
            {
                Text = "Modify a record";

                if(newRecord.Type == RecordType.DurationRecord)
                {
                    cbRecordType.SelectedIndex = cbRecordType.Items.Count - 1;
                    GUIUtilities.SetNumericUpDownValue(numDuration, ((DurationRecord) newRecord).Duration);
                }

                else
                {
                    ClickRecord newRecordActual = (ClickRecord) newRecord;
                    cbRecordType.SelectedIndex = (Int32) newRecordActual.SubType;
                    Point point = newRecordActual.TargetPoint;
                    numX.Value = point.X;
                    numY.Value = point.Y;
                }
            }

            else Text = "Create a record";
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
            KeyValuePair<String, Object> selection =
                (KeyValuePair<String, Object>) cbRecordType.SelectedItem;

            if(selection.Key == DurationRecordType.Duration.ToString())
                newRecord = new DurationRecord(GUIUtilities.ToInt32(numDuration.Value));
            else
                newRecord = new ClickRecord((ClickRecordType) selection.Value,
                    new Point(GUIUtilities.ToInt32(numX.Value), GUIUtilities.ToInt32(numY.Value)));

            _okExit = true;
            Close();
            Dispose();
        }
    }
}
