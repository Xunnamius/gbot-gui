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
    internal partial class GBGNodeAddModifyRecord : Form
    {
        RecordBase newRecord = null;

        private Boolean _okExit = false;
        public Boolean OkExit { get { return _okExit; } }

        public GBGNodeAddModifyRecord()
        {
            InitializeComponent();
        }

        public GBGNodeAddModifyRecord(RecordBase record)
        {
            InitializeComponent();
            newRecord = record;
        }

        private void GBGClickAddModifyRecord_Load(Object sender, EventArgs e)
        {
            cbRecordType.DisplayMember = "Key";
            cbRecordType.ValueMember = "Value";
            
            foreach(ClickRecordType recordType in Enum.GetValues(typeof(ClickRecordType)))
                cbRecordType.Items.Add(new KeyValuePair<String, Type>(recordType.ToString(), typeof(ClickRecordType)));

            // Tack on "Duration" at the end as well
            cbRecordType.Items.Add(
                new KeyValuePair<String, Type>(
                    DurationRecordType.Duration.ToString(), typeof(DurationRecordType)));

            cbRecordType.SelectedIndexChanged += new EventHandler((sendr, evtargs) =>
            {
                KeyValuePair<String, Type> selection =
                    (KeyValuePair<String, Type>) cbRecordType.SelectedItem;

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

        public RecordBase GetRecord()
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

        private void btnOk_Click(Object sender, EventArgs e)
        {
            KeyValuePair<String, Type> selection =
                (KeyValuePair<String, Type>) cbRecordType.SelectedItem;

            if(selection.Key == DurationRecordType.Duration.ToString())
                newRecord = new DurationRecord(GUIUtilities.ToInt32(numDuration.Value));
            else
                newRecord = new ClickRecord((ClickRecordType) Enum.Parse(selection.Value, selection.Key),
                    new Point(GUIUtilities.ToInt32(numX.Value), GUIUtilities.ToInt32(numY.Value)));

            _okExit = true;
            Close();
            Dispose();
        }
    }
}
