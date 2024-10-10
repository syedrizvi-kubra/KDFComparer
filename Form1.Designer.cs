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
            this.components = new System.ComponentModel.Container();
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBoxBeforeZip = new System.Windows.Forms.TextBox();
            this.textBoxAfterZip = new System.Windows.Forms.TextBox();
            this.labelBeforeZip = new System.Windows.Forms.Label();
            this.labelAfterZip = new System.Windows.Forms.Label();
            this.comboBoxEnvironment = new System.Windows.Forms.ComboBox();
            this.comboBoxCANUS = new System.Windows.Forms.ComboBox();
            this.checkBoxArchivedJobs = new System.Windows.Forms.CheckBox();
            this.labelSelectEnvironment = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabManualSelection.SuspendLayout();
            this.tabZipSelection.SuspendLayout();
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
            this.textBoxBeforeDbPath.Size = new System.Drawing.Size(327, 20);
            this.textBoxBeforeDbPath.TabIndex = 0;
            // 
            // textBoxAfterDbPath
            // 
            this.textBoxAfterDbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAfterDbPath.Location = new System.Drawing.Point(135, 68);
            this.textBoxAfterDbPath.Name = "textBoxAfterDbPath";
            this.textBoxAfterDbPath.Size = new System.Drawing.Size(327, 20);
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
            this.buttonCompare.Location = new System.Drawing.Point(219, 176);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(285, 33);
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
            this.listBoxProgress.Location = new System.Drawing.Point(20, 215);
            this.listBoxProgress.Name = "listBoxProgress";
            this.listBoxProgress.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxProgress.Size = new System.Drawing.Size(484, 173);
            this.listBoxProgress.TabIndex = 5;
            // 
            // checkBoxDocData
            // 
            this.checkBoxDocData.AutoSize = true;
            this.checkBoxDocData.Checked = true;
            this.checkBoxDocData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDocData.Location = new System.Drawing.Point(20, 184);
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
            this.checkBoxDocumentIndex.Location = new System.Drawing.Point(110, 184);
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
            this.tabControl.Size = new System.Drawing.Size(488, 150);
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
            this.tabManualSelection.Size = new System.Drawing.Size(480, 124);
            this.tabManualSelection.TabIndex = 0;
            this.tabManualSelection.Text = "Manual Selection";
            this.tabManualSelection.UseVisualStyleBackColor = true;
            // 
            // tabZipSelection
            // 
            this.tabZipSelection.Controls.Add(this.linkLabel1);
            this.tabZipSelection.Controls.Add(this.textBoxBeforeZip);
            this.tabZipSelection.Controls.Add(this.textBoxAfterZip);
            this.tabZipSelection.Controls.Add(this.labelBeforeZip);
            this.tabZipSelection.Controls.Add(this.labelAfterZip);
            this.tabZipSelection.Controls.Add(this.comboBoxEnvironment);
            this.tabZipSelection.Controls.Add(this.comboBoxCANUS);
            this.tabZipSelection.Controls.Add(this.checkBoxArchivedJobs);
            this.tabZipSelection.Controls.Add(this.labelSelectEnvironment);
            this.tabZipSelection.Location = new System.Drawing.Point(4, 22);
            this.tabZipSelection.Name = "tabZipSelection";
            this.tabZipSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabZipSelection.Size = new System.Drawing.Size(480, 124);
            this.tabZipSelection.TabIndex = 1;
            this.tabZipSelection.Text = "Job ID Selection";
            this.tabZipSelection.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(403, 45);
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
            this.textBoxBeforeZip.Location = new System.Drawing.Point(122, 48);
            this.textBoxBeforeZip.Name = "textBoxBeforeZip";
            this.textBoxBeforeZip.Size = new System.Drawing.Size(246, 20);
            this.textBoxBeforeZip.TabIndex = 0;
            // 
            // textBoxAfterZip
            // 
            this.textBoxAfterZip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAfterZip.Location = new System.Drawing.Point(122, 80);
            this.textBoxAfterZip.Name = "textBoxAfterZip";
            this.textBoxAfterZip.Size = new System.Drawing.Size(246, 20);
            this.textBoxAfterZip.TabIndex = 1;
            // 
            // labelBeforeZip
            // 
            this.labelBeforeZip.AutoSize = true;
            this.labelBeforeZip.Location = new System.Drawing.Point(5, 52);
            this.labelBeforeZip.Name = "labelBeforeZip";
            this.labelBeforeZip.Size = new System.Drawing.Size(115, 13);
            this.labelBeforeZip.TabIndex = 2;
            this.labelBeforeZip.Text = "Before - PROD Job ID:";
            // 
            // labelAfterZip
            // 
            this.labelAfterZip.AutoSize = true;
            this.labelAfterZip.Location = new System.Drawing.Point(24, 84);
            this.labelAfterZip.Name = "labelAfterZip";
            this.labelAfterZip.Size = new System.Drawing.Size(96, 13);
            this.labelAfterZip.TabIndex = 3;
            this.labelAfterZip.Text = "After - Test Job ID:";
            // 
            // comboBoxEnvironment
            // 
            this.comboBoxEnvironment.FormattingEnabled = true;
            this.comboBoxEnvironment.Items.AddRange(new object[] {
        "TEST",
        "PREP"});
            this.comboBoxEnvironment.Location = new System.Drawing.Point(122, 16);
            this.comboBoxEnvironment.Name = "comboBoxEnvironment";
            this.comboBoxEnvironment.Size = new System.Drawing.Size(52, 21);
            this.comboBoxEnvironment.TabIndex = 4;
            this.comboBoxEnvironment.Text = "TEST";
            this.comboBoxEnvironment.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEnvironment_SelectedIndexChanged);
            // 
            // comboBoxCANUS
            // 
            this.comboBoxCANUS.FormattingEnabled = true;
            this.comboBoxCANUS.Items.AddRange(new object[] {
        "US",
        "CAN"});
            this.comboBoxCANUS.Location = new System.Drawing.Point(180, 16);
            this.comboBoxCANUS.Name = "comboBoxCANUS";
            this.comboBoxCANUS.Size = new System.Drawing.Size(70, 21);
            this.comboBoxCANUS.TabIndex = 8;
            this.comboBoxCANUS.Text = "US"; // Default to US
            this.comboBoxCANUS.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCANUS_SelectedIndexChanged);
            // 
            // checkBoxArchivedJobs
            // 
            this.checkBoxArchivedJobs.AutoSize = true;
            this.checkBoxArchivedJobs.Location = new System.Drawing.Point(336, 18);
            this.checkBoxArchivedJobs.Name = "checkBoxArchivedJobs";
            this.checkBoxArchivedJobs.Size = new System.Drawing.Size(134, 17);
            this.checkBoxArchivedJobs.TabIndex = 5;
            this.checkBoxArchivedJobs.Text = "Use Old Archived Jobs";
            this.checkBoxArchivedJobs.UseVisualStyleBackColor = true;
            this.checkBoxArchivedJobs.CheckedChanged += new System.EventHandler(this.checkBoxArchivedJobs_CheckedChanged);
            // 
            // labelSelectEnvironment
            // 
            this.labelSelectEnvironment.AutoSize = true;
            this.labelSelectEnvironment.Location = new System.Drawing.Point(18, 20);
            this.labelSelectEnvironment.Name = "labelSelectEnvironment";
            this.labelSelectEnvironment.Size = new System.Drawing.Size(102, 13);
            this.labelSelectEnvironment.TabIndex = 7;
            this.labelSelectEnvironment.Text = "Select Environment:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 400);
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
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
