using System;
using System.Windows.Forms;

namespace AccessDatabaseComparer
{
    public partial class TimeIntervalDialog : Form
    {
        public DateTime StartTime { get; private set; }
        public int Interval { get; private set; }
        public bool IsAutoOneAtATimeChecked => AutoOneAtATimeCheck.Checked;

        public TimeIntervalDialog()
        {
            InitializeComponent();
            AutoOneAtATimeCheck.CheckedChanged += AutoOneAtATimeCheck_CheckedChanged;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            StartTime = dateTimePicker.Value;
            Interval = (int)numericUpDown.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AutoOneAtATimeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoOneAtATimeCheck.Checked)
            {
                numericUpDown.Value = 0;
                dateTimePicker.Value = DateTime.Now;
                numericUpDown.Enabled = false;
                dateTimePicker.Enabled = false;
            }
            else
            {
                numericUpDown.Enabled = true;
                dateTimePicker.Enabled = true;
            }
        }
    }
}
