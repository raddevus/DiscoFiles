namespace DaylightComputers
{
    partial class DiscoFilesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscoFilesForm));
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.startSpyButton = new System.Windows.Forms.Button();
            this.stopSpyButton = new System.Windows.Forms.Button();
            this.addExclusionButton = new System.Windows.Forms.Button();
            this.infoListView = new System.Windows.Forms.ListView();
            this.pathMonitorButton = new System.Windows.Forms.Button();
            this.pathMonitorTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fileRenamedCheckBox = new System.Windows.Forms.CheckBox();
            this.fileDeletedCheckBox = new System.Windows.Forms.CheckBox();
            this.fileCreatedCheckBox = new System.Windows.Forms.CheckBox();
            this.fileChangedCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.excludePathsComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.discoPathFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.changeEventBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ExtraWorkTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.IncludeSubdirectories = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Created);
            this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Deleted);
            this.fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher_Renamed);
            // 
            // startSpyButton
            // 
            this.startSpyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startSpyButton.Location = new System.Drawing.Point(12, 353);
            this.startSpyButton.Name = "startSpyButton";
            this.startSpyButton.Size = new System.Drawing.Size(75, 23);
            this.startSpyButton.TabIndex = 1;
            this.startSpyButton.Text = "Start Spying";
            this.startSpyButton.UseVisualStyleBackColor = true;
            this.startSpyButton.Click += new System.EventHandler(this.startSpyButton_Click);
            // 
            // stopSpyButton
            // 
            this.stopSpyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stopSpyButton.Enabled = false;
            this.stopSpyButton.Location = new System.Drawing.Point(540, 353);
            this.stopSpyButton.Name = "stopSpyButton";
            this.stopSpyButton.Size = new System.Drawing.Size(75, 23);
            this.stopSpyButton.TabIndex = 4;
            this.stopSpyButton.Text = "Stop Spying";
            this.stopSpyButton.UseVisualStyleBackColor = true;
            this.stopSpyButton.Click += new System.EventHandler(this.stopSpyButton_Click);
            // 
            // addExclusionButton
            // 
            this.addExclusionButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addExclusionButton.Location = new System.Drawing.Point(397, 353);
            this.addExclusionButton.Name = "addExclusionButton";
            this.addExclusionButton.Size = new System.Drawing.Size(94, 23);
            this.addExclusionButton.TabIndex = 3;
            this.addExclusionButton.Text = "Add Exclusion";
            this.addExclusionButton.UseVisualStyleBackColor = true;
            this.addExclusionButton.Click += new System.EventHandler(this.addExclusionButton_Click);
            // 
            // infoListView
            // 
            this.infoListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoListView.FullRowSelect = true;
            this.infoListView.GridLines = true;
            this.infoListView.Location = new System.Drawing.Point(12, 120);
            this.infoListView.Name = "infoListView";
            this.infoListView.Size = new System.Drawing.Size(603, 227);
            this.infoListView.TabIndex = 4;
            this.infoListView.UseCompatibleStateImageBehavior = false;
            this.infoListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.infoListView_ColumnClick);
            this.infoListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.infoListView_MouseDoubleClick);
            // 
            // pathMonitorButton
            // 
            this.pathMonitorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pathMonitorButton.Location = new System.Drawing.Point(587, 85);
            this.pathMonitorButton.Name = "pathMonitorButton";
            this.pathMonitorButton.Size = new System.Drawing.Size(30, 23);
            this.pathMonitorButton.TabIndex = 10;
            this.pathMonitorButton.Text = "...";
            this.pathMonitorButton.UseVisualStyleBackColor = true;
            this.pathMonitorButton.Click += new System.EventHandler(this.pathMonitorButton_Click);
            // 
            // pathMonitorTextBox
            // 
            this.pathMonitorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathMonitorTextBox.Location = new System.Drawing.Point(105, 87);
            this.pathMonitorTextBox.Name = "pathMonitorTextBox";
            this.pathMonitorTextBox.Size = new System.Drawing.Size(476, 20);
            this.pathMonitorTextBox.TabIndex = 9;
            this.pathMonitorTextBox.Text = "c:\\";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fileRenamedCheckBox);
            this.groupBox1.Controls.Add(this.fileDeletedCheckBox);
            this.groupBox1.Controls.Add(this.fileCreatedCheckBox);
            this.groupBox1.Controls.Add(this.fileChangedCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 43);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Events";
            // 
            // fileRenamedCheckBox
            // 
            this.fileRenamedCheckBox.AutoSize = true;
            this.fileRenamedCheckBox.Location = new System.Drawing.Point(296, 20);
            this.fileRenamedCheckBox.Name = "fileRenamedCheckBox";
            this.fileRenamedCheckBox.Size = new System.Drawing.Size(91, 17);
            this.fileRenamedCheckBox.TabIndex = 8;
            this.fileRenamedCheckBox.Text = "File Renamed";
            this.fileRenamedCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileDeletedCheckBox
            // 
            this.fileDeletedCheckBox.AutoSize = true;
            this.fileDeletedCheckBox.Location = new System.Drawing.Point(207, 20);
            this.fileDeletedCheckBox.Name = "fileDeletedCheckBox";
            this.fileDeletedCheckBox.Size = new System.Drawing.Size(82, 17);
            this.fileDeletedCheckBox.TabIndex = 7;
            this.fileDeletedCheckBox.Text = "File Deleted";
            this.fileDeletedCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileCreatedCheckBox
            // 
            this.fileCreatedCheckBox.AutoSize = true;
            this.fileCreatedCheckBox.Location = new System.Drawing.Point(118, 20);
            this.fileCreatedCheckBox.Name = "fileCreatedCheckBox";
            this.fileCreatedCheckBox.Size = new System.Drawing.Size(82, 17);
            this.fileCreatedCheckBox.TabIndex = 6;
            this.fileCreatedCheckBox.Text = "File Created";
            this.fileCreatedCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileChangedCheckBox
            // 
            this.fileChangedCheckBox.AutoSize = true;
            this.fileChangedCheckBox.Checked = true;
            this.fileChangedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fileChangedCheckBox.Location = new System.Drawing.Point(7, 20);
            this.fileChangedCheckBox.Name = "fileChangedCheckBox";
            this.fileChangedCheckBox.Size = new System.Drawing.Size(88, 17);
            this.fileChangedCheckBox.TabIndex = 5;
            this.fileChangedCheckBox.Text = "File Changed";
            this.fileChangedCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Path to spy on:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "(includes subdirs)";
            // 
            // excludePathsComboBox
            // 
            this.excludePathsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.excludePathsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.excludePathsComboBox.DropDownWidth = 300;
            this.excludePathsComboBox.FormattingEnabled = true;
            this.excludePathsComboBox.IntegralHeight = false;
            this.excludePathsComboBox.Location = new System.Drawing.Point(195, 355);
            this.excludePathsComboBox.Name = "excludePathsComboBox";
            this.excludePathsComboBox.Size = new System.Drawing.Size(196, 21);
            this.excludePathsComboBox.Sorted = true;
            this.excludePathsComboBox.TabIndex = 2;
            this.excludePathsComboBox.DropDown += new System.EventHandler(this.excludePathsComboBox_DropDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Exclude Paths:";
            // 
            // changeEventBackgroundWorker
            // 
            this.changeEventBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.changeEventBackgroundWorker_DoWork);
            // 
            // ExtraWorkTimer
            // 
            this.ExtraWorkTimer.Enabled = true;
            this.ExtraWorkTimer.Interval = 750;
            this.ExtraWorkTimer.Tick += new System.EventHandler(this.ExtraWorkTimer_Tick);
            // 
            // DiscoFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 388);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.excludePathsComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pathMonitorTextBox);
            this.Controls.Add(this.pathMonitorButton);
            this.Controls.Add(this.infoListView);
            this.Controls.Add(this.addExclusionButton);
            this.Controls.Add(this.stopSpyButton);
            this.Controls.Add(this.startSpyButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DiscoFilesForm";
            this.Text = "DiscoFiles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiscoFilesForm_FormClosing);
            this.Load += new System.EventHandler(this.DiscoFilesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.Button startSpyButton;
        private System.Windows.Forms.Button stopSpyButton;
        private System.Windows.Forms.Button addExclusionButton;
        private System.Windows.Forms.ListView infoListView;
        private System.Windows.Forms.TextBox pathMonitorTextBox;
        private System.Windows.Forms.Button pathMonitorButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox fileDeletedCheckBox;
        private System.Windows.Forms.CheckBox fileCreatedCheckBox;
        private System.Windows.Forms.CheckBox fileChangedCheckBox;
        private System.Windows.Forms.CheckBox fileRenamedCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox excludePathsComboBox;
        private System.Windows.Forms.FolderBrowserDialog discoPathFolderBrowser;
        private System.ComponentModel.BackgroundWorker changeEventBackgroundWorker;
        private System.Windows.Forms.Timer ExtraWorkTimer;
    }
}

