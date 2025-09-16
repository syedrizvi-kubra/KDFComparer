using System.Windows.Forms;

namespace AccessDatabaseComparer
{
    public partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBoxBeforeDbPath;
        private System.Windows.Forms.TextBox textBoxAfterDbPath;
        private System.Windows.Forms.Button buttonSelectBeforeDb;
        private System.Windows.Forms.Button buttonSelectAfterDb;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.ListBox listBoxProgress;
        private System.Windows.Forms.CheckBox checkBoxDocData;
        private System.Windows.Forms.CheckBox checkBoxDocumentIndex;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabManualSelection;
        private System.Windows.Forms.TabPage tabZipSelection;
        private System.Windows.Forms.TextBox textBoxBeforeZip;
        private System.Windows.Forms.TextBox textBoxAfterZip;
        private System.Windows.Forms.Label labelBeforeZip;
        private System.Windows.Forms.Label labelAfterZip;
        private System.Windows.Forms.ComboBox comboBoxEnvironment;
        private System.Windows.Forms.ComboBox comboBoxCANUS;
        private System.Windows.Forms.CheckBox checkBoxArchivedJobs;
        private System.Windows.Forms.Label labelSelectEnvironment;
        private System.Windows.Forms.LinkLabel linkLabel1;

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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBoxBeforeDbPath = new System.Windows.Forms.TextBox();
            this.textBoxAfterDbPath = new System.Windows.Forms.TextBox();
            this.buttonSelectBeforeDb = new System.Windows.Forms.Button();
            this.buttonSelectAfterDb = new System.Windows.Forms.Button();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.listBoxProgress = new System.Windows.Forms.ListBox();
            this.checkBoxDocData = new System.Windows.Forms.CheckBox();
            this.checkBoxDocumentIndex = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabManualSelection = new System.Windows.Forms.TabPage();
            this.tabZipSelection = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxCANUS = new System.Windows.Forms.ComboBox();
            this.labelSelectEnvironment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxEnvironment2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxEnvironment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderComboBox = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBoxBeforeZip = new System.Windows.Forms.TextBox();
            this.textBoxAfterZip = new System.Windows.Forms.TextBox();
            this.labelBeforeZip = new System.Windows.Forms.Label();
            this.labelAfterZip = new System.Windows.Forms.Label();
            this.checkBoxArchivedJobs = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabManualSelection.SuspendLayout();
            this.tabZipSelection.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // textBoxBeforeDbPath
            // 
            this.textBoxBeforeDbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBeforeDbPath.Location = new System.Drawing.Point(135, 28);
            this.textBoxBeforeDbPath.Name = "textBoxBeforeDbPath";
            this.textBoxBeforeDbPath.Size = new System.Drawing.Size(461, 20);
            this.textBoxBeforeDbPath.TabIndex = 0;
            // 
            // textBoxAfterDbPath
            // 
            this.textBoxAfterDbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAfterDbPath.Location = new System.Drawing.Point(135, 68);
            this.textBoxAfterDbPath.Name = "textBoxAfterDbPath";
            this.textBoxAfterDbPath.Size = new System.Drawing.Size(461, 20);
            this.textBoxAfterDbPath.TabIndex = 1;
            // 
            // buttonSelectBeforeDb
            // 
            this.buttonSelectBeforeDb.Location = new System.Drawing.Point(29, 27);
            this.buttonSelectBeforeDb.Name = "buttonSelectBeforeDb";
            this.buttonSelectBeforeDb.Size = new System.Drawing.Size(100, 23);
            this.buttonSelectBeforeDb.TabIndex = 2;
            this.buttonSelectBeforeDb.Text = "Select Before DB";
            this.buttonSelectBeforeDb.UseVisualStyleBackColor = true;
            this.buttonSelectBeforeDb.Click += new System.EventHandler(this.buttonSelectBeforeDb_Click);
            // 
            // buttonSelectAfterDb
            // 
            this.buttonSelectAfterDb.Location = new System.Drawing.Point(29, 67);
            this.buttonSelectAfterDb.Name = "buttonSelectAfterDb";
            this.buttonSelectAfterDb.Size = new System.Drawing.Size(100, 23);
            this.buttonSelectAfterDb.TabIndex = 3;
            this.buttonSelectAfterDb.Text = "Select After DB";
            this.buttonSelectAfterDb.UseVisualStyleBackColor = true;
            this.buttonSelectAfterDb.Click += new System.EventHandler(this.buttonSelectAfterDb_Click);
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(219, 245);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(354, 33);
            this.buttonCompare.TabIndex = 4;
            this.buttonCompare.Text = "Compare";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // listBoxProgress
            // 
            this.listBoxProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxProgress.FormattingEnabled = true;
            this.listBoxProgress.HorizontalScrollbar = true;
            this.listBoxProgress.Location = new System.Drawing.Point(20, 293);
            this.listBoxProgress.Name = "listBoxProgress";
            this.listBoxProgress.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxProgress.Size = new System.Drawing.Size(557, 199);
            this.listBoxProgress.TabIndex = 5;
            // 
            // checkBoxDocData
            // 
            this.checkBoxDocData.AutoSize = true;
            this.checkBoxDocData.Checked = true;
            this.checkBoxDocData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDocData.Location = new System.Drawing.Point(20, 253);
            this.checkBoxDocData.Name = "checkBoxDocData";
            this.checkBoxDocData.Size = new System.Drawing.Size(72, 17);
            this.checkBoxDocData.TabIndex = 6;
            this.checkBoxDocData.Text = "Doc Data";
            this.checkBoxDocData.UseVisualStyleBackColor = true;
            // 
            // checkBoxDocumentIndex
            // 
            this.checkBoxDocumentIndex.AutoSize = true;
            this.checkBoxDocumentIndex.Checked = true;
            this.checkBoxDocumentIndex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDocumentIndex.Location = new System.Drawing.Point(110, 253);
            this.checkBoxDocumentIndex.Name = "checkBoxDocumentIndex";
            this.checkBoxDocumentIndex.Size = new System.Drawing.Size(104, 17);
            this.checkBoxDocumentIndex.TabIndex = 7;
            this.checkBoxDocumentIndex.Text = "Document Index";
            this.checkBoxDocumentIndex.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabManualSelection);
            this.tabControl.Controls.Add(this.tabZipSelection);
            this.tabControl.Location = new System.Drawing.Point(20, 20);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(557, 219);
            this.tabControl.TabIndex = 8;
            // 
            // tabManualSelection
            // 
            this.tabManualSelection.Controls.Add(this.textBoxBeforeDbPath);
            this.tabManualSelection.Controls.Add(this.textBoxAfterDbPath);
            this.tabManualSelection.Controls.Add(this.buttonSelectBeforeDb);
            this.tabManualSelection.Controls.Add(this.buttonSelectAfterDb);
            this.tabManualSelection.Location = new System.Drawing.Point(4, 22);
            this.tabManualSelection.Name = "tabManualSelection";
            this.tabManualSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabManualSelection.Size = new System.Drawing.Size(549, 193);
            this.tabManualSelection.TabIndex = 0;
            this.tabManualSelection.Text = "Manual Selection";
            this.tabManualSelection.UseVisualStyleBackColor = true;
            // 
            // tabZipSelection
            // 
            this.tabZipSelection.Controls.Add(this.panel2);
            this.tabZipSelection.Controls.Add(this.panel1);
            this.tabZipSelection.Controls.Add(this.label1);
            this.tabZipSelection.Controls.Add(this.folderComboBox);
            this.tabZipSelection.Controls.Add(this.linkLabel1);
            this.tabZipSelection.Controls.Add(this.textBoxBeforeZip);
            this.tabZipSelection.Controls.Add(this.textBoxAfterZip);
            this.tabZipSelection.Controls.Add(this.labelBeforeZip);
            this.tabZipSelection.Controls.Add(this.labelAfterZip);
            this.tabZipSelection.Controls.Add(this.checkBoxArchivedJobs);
            this.tabZipSelection.Location = new System.Drawing.Point(4, 22);
            this.tabZipSelection.Name = "tabZipSelection";
            this.tabZipSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabZipSelection.Size = new System.Drawing.Size(549, 193);
            this.tabZipSelection.TabIndex = 1;
            this.tabZipSelection.Text = "Job ID Selection";
            this.tabZipSelection.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.comboBoxCANUS);
            this.panel2.Controls.Add(this.labelSelectEnvironment);
            this.panel2.Location = new System.Drawing.Point(409, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(89, 54);
            this.panel2.TabIndex = 15;
            // 
            // comboBoxCANUS
            // 
            this.comboBoxCANUS.FormattingEnabled = true;
            this.comboBoxCANUS.Items.AddRange(new object[] {
            "US",
            "CAN"});
            this.comboBoxCANUS.Location = new System.Drawing.Point(10, 25);
            this.comboBoxCANUS.Name = "comboBoxCANUS";
            this.comboBoxCANUS.Size = new System.Drawing.Size(70, 21);
            this.comboBoxCANUS.TabIndex = 8;
            this.comboBoxCANUS.Text = "US";
            this.comboBoxCANUS.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCANUS_SelectedIndexChanged);
            // 
            // labelSelectEnvironment
            // 
            this.labelSelectEnvironment.AutoSize = true;
            this.labelSelectEnvironment.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectEnvironment.Location = new System.Drawing.Point(7, 4);
            this.labelSelectEnvironment.Name = "labelSelectEnvironment";
            this.labelSelectEnvironment.Size = new System.Drawing.Size(79, 17);
            this.labelSelectEnvironment.TabIndex = 7;
            this.labelSelectEnvironment.Text = "Environment:";
            this.labelSelectEnvironment.Click += new System.EventHandler(this.labelSelectEnvironment_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBoxEnvironment2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxEnvironment);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(250, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 54);
            this.panel1.TabIndex = 14;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBoxEnvironment2
            // 
            this.comboBoxEnvironment2.FormattingEnabled = true;
            this.comboBoxEnvironment2.Items.AddRange(new object[] {
            "TEST",
            "PREP",
            "PROD"});
            this.comboBoxEnvironment2.Location = new System.Drawing.Point(85, 25);
            this.comboBoxEnvironment2.Name = "comboBoxEnvironment2";
            this.comboBoxEnvironment2.Size = new System.Drawing.Size(52, 21);
            this.comboBoxEnvironment2.TabIndex = 11;
            this.comboBoxEnvironment2.Text = "TEST";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "vs";
            // 
            // comboBoxEnvironment
            // 
            this.comboBoxEnvironment.FormattingEnabled = true;
            this.comboBoxEnvironment.Items.AddRange(new object[] {
            "TEST",
            "PREP",
            "PROD"});
            this.comboBoxEnvironment.Location = new System.Drawing.Point(6, 25);
            this.comboBoxEnvironment.Name = "comboBoxEnvironment";
            this.comboBoxEnvironment.Size = new System.Drawing.Size(52, 21);
            this.comboBoxEnvironment.TabIndex = 4;
            this.comboBoxEnvironment.Text = "TEST";
            this.comboBoxEnvironment.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEnvironment_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Comparison:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Client Name:";
            // 
            // folderComboBox
            // 
            this.folderComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.folderComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.folderComboBox.FormattingEnabled = true;
            this.folderComboBox.Location = new System.Drawing.Point(6, 31);
            this.folderComboBox.Name = "folderComboBox";
            this.folderComboBox.Size = new System.Drawing.Size(221, 21);
            this.folderComboBox.TabIndex = 0;
            this.folderComboBox.SelectedIndexChanged += new System.EventHandler(this.FolderComboBox_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(478, 87);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 26);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Auto Drop\nProd to Test";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBoxBeforeZip
            // 
            this.textBoxBeforeZip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBeforeZip.Location = new System.Drawing.Point(6, 93);
            this.textBoxBeforeZip.Name = "textBoxBeforeZip";
            this.textBoxBeforeZip.Size = new System.Drawing.Size(466, 20);
            this.textBoxBeforeZip.TabIndex = 0;
            // 
            // textBoxAfterZip
            // 
            this.textBoxAfterZip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAfterZip.Location = new System.Drawing.Point(6, 138);
            this.textBoxAfterZip.Name = "textBoxAfterZip";
            this.textBoxAfterZip.Size = new System.Drawing.Size(466, 20);
            this.textBoxAfterZip.TabIndex = 1;
            // 
            // labelBeforeZip
            // 
            this.labelBeforeZip.AutoSize = true;
            this.labelBeforeZip.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBeforeZip.Location = new System.Drawing.Point(6, 72);
            this.labelBeforeZip.Name = "labelBeforeZip";
            this.labelBeforeZip.Size = new System.Drawing.Size(235, 17);
            this.labelBeforeZip.TabIndex = 2;
            this.labelBeforeZip.Text = "Before - PROD Job IDs (Comma separated):";
            // 
            // labelAfterZip
            // 
            this.labelAfterZip.AutoSize = true;
            this.labelAfterZip.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAfterZip.Location = new System.Drawing.Point(6, 117);
            this.labelAfterZip.Name = "labelAfterZip";
            this.labelAfterZip.Size = new System.Drawing.Size(218, 17);
            this.labelAfterZip.TabIndex = 3;
            this.labelAfterZip.Text = "After - Test Job IDs (Comma separated):";
            // 
            // checkBoxArchivedJobs
            // 
            this.checkBoxArchivedJobs.AutoSize = true;
            this.checkBoxArchivedJobs.Location = new System.Drawing.Point(409, 170);
            this.checkBoxArchivedJobs.Name = "checkBoxArchivedJobs";
            this.checkBoxArchivedJobs.Size = new System.Drawing.Size(134, 17);
            this.checkBoxArchivedJobs.TabIndex = 5;
            this.checkBoxArchivedJobs.Text = "Use Old Archived Jobs";
            this.checkBoxArchivedJobs.UseVisualStyleBackColor = true;
            this.checkBoxArchivedJobs.CheckedChanged += new System.EventHandler(this.checkBoxArchivedJobs_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 513);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.checkBoxDocumentIndex);
            this.Controls.Add(this.checkBoxDocData);
            this.Controls.Add(this.listBoxProgress);
            this.Controls.Add(this.buttonCompare);
            this.Name = "Form1";
            this.Text = "KDF Database Comparer";
            this.tabControl.ResumeLayout(false);
            this.tabManualSelection.ResumeLayout(false);
            this.tabManualSelection.PerformLayout();
            this.tabZipSelection.ResumeLayout(false);
            this.tabZipSelection.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private ComboBox folderComboBox;
        private ComboBox comboBoxEnvironment2;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Panel panel2;
    }
}
