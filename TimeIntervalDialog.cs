using System;
using System.Windows.Forms;

namespace AccessDatabaseComparer
{
    public partial class TimeIntervalDialog : Form
    {
        public DateTime StartTime { get; private set; }
        public int Interval { get; private set; }

        public TimeIntervalDialog()
        {
            InitializeComponent();
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
    }
}