namespace AccessDatabaseComparer
{
    partial class TimeIntervalDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.AutoOneAtATimeCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 0;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(12, 38);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(200, 20);
            this.numericUpDown.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 99);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(137, 99);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AutoOneAtATimeCheck
            // 
            this.AutoOneAtATimeCheck.AutoSize = true;
            this.AutoOneAtATimeCheck.Location = new System.Drawing.Point(12, 70);
            this.AutoOneAtATimeCheck.Name = "AutoOneAtATimeCheck";
            this.AutoOneAtATimeCheck.Size = new System.Drawing.Size(152, 17);
            this.AutoOneAtATimeCheck.TabIndex = 4;
            this.AutoOneAtATimeCheck.Text = "Auto drop one file at a time";
            this.AutoOneAtATimeCheck.UseVisualStyleBackColor = true;
            this.AutoOneAtATimeCheck.CheckedChanged += new System.EventHandler(this.AutoOneAtATimeCheck_CheckedChanged);
            // 
            // TimeIntervalDialog
            // 
            this.ClientSize = new System.Drawing.Size(242, 134);
            this.Controls.Add(this.AutoOneAtATimeCheck);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "TimeIntervalDialog";
            this.Text = "Set Time and Interval";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox AutoOneAtATimeCheck;
    }
}