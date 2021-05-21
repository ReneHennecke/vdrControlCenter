namespace vdrControlCenterUI.Dialogs
{
    partial class dlgFindEPG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgFindEPG));
            this.panEPGFind = new System.Windows.Forms.Panel();
            this.lblNotFound = new System.Windows.Forms.Label();
            this.grbBox = new System.Windows.Forms.GroupBox();
            this.chbRecordings = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.chbTitle = new System.Windows.Forms.CheckBox();
            this.chbFindInPast = new System.Windows.Forms.CheckBox();
            this.chbTimers = new System.Windows.Forms.CheckBox();
            this.chbDescription = new System.Windows.Forms.CheckBox();
            this.chbSortDescription = new System.Windows.Forms.CheckBox();
            this.dgvFind = new System.Windows.Forms.DataGridView();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.btnTimer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panEPGFind.SuspendLayout();
            this.grbBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).BeginInit();
            this.SuspendLayout();
            // 
            // panEPGFind
            // 
            this.panEPGFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panEPGFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panEPGFind.Controls.Add(this.lblNotFound);
            this.panEPGFind.Controls.Add(this.grbBox);
            this.panEPGFind.Controls.Add(this.dgvFind);
            this.panEPGFind.Controls.Add(this.tbFind);
            this.panEPGFind.Controls.Add(this.lblFind);
            this.panEPGFind.Location = new System.Drawing.Point(4, 4);
            this.panEPGFind.Name = "panEPGFind";
            this.panEPGFind.Size = new System.Drawing.Size(1138, 446);
            this.panEPGFind.TabIndex = 0;
            // 
            // lblNotFound
            // 
            this.lblNotFound.BackColor = System.Drawing.Color.Transparent;
            this.lblNotFound.Location = new System.Drawing.Point(400, 294);
            this.lblNotFound.Name = "lblNotFound";
            this.lblNotFound.Size = new System.Drawing.Size(424, 23);
            this.lblNotFound.TabIndex = 11;
            this.lblNotFound.Text = "Es wurden keine Einträge mit den angegebenen Suchkritierien gefunden.";
            this.lblNotFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbBox
            // 
            this.grbBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbBox.Controls.Add(this.chbRecordings);
            this.grbBox.Controls.Add(this.btnFind);
            this.grbBox.Controls.Add(this.dtpStartTime);
            this.grbBox.Controls.Add(this.lblStartTime);
            this.grbBox.Controls.Add(this.chbTitle);
            this.grbBox.Controls.Add(this.chbFindInPast);
            this.grbBox.Controls.Add(this.chbTimers);
            this.grbBox.Controls.Add(this.chbDescription);
            this.grbBox.Controls.Add(this.chbSortDescription);
            this.grbBox.Location = new System.Drawing.Point(4, 30);
            this.grbBox.Name = "grbBox";
            this.grbBox.Size = new System.Drawing.Size(1130, 138);
            this.grbBox.TabIndex = 8;
            this.grbBox.TabStop = false;
            this.grbBox.Text = "Suche erweitern";
            // 
            // chbRecordings
            // 
            this.chbRecordings.Location = new System.Drawing.Point(196, 84);
            this.chbRecordings.Name = "chbRecordings";
            this.chbRecordings.Size = new System.Drawing.Size(89, 19);
            this.chbRecordings.TabIndex = 9;
            this.chbRecordings.Text = "Aufnahmen";
            this.chbRecordings.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Enabled = false;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFind.Location = new System.Drawing.Point(458, 30);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(103, 50);
            this.btnFind.TabIndex = 10;
            this.btnFind.Text = "Suche starten";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "dddd, dd.MM.yyyy HH:mm";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(84, 28);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(200, 23);
            this.dtpStartTime.TabIndex = 3;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Location = new System.Drawing.Point(12, 28);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(68, 22);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "Start:";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbTitle
            // 
            this.chbTitle.Checked = true;
            this.chbTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTitle.Location = new System.Drawing.Point(43, 59);
            this.chbTitle.Name = "chbTitle";
            this.chbTitle.Size = new System.Drawing.Size(98, 19);
            this.chbTitle.TabIndex = 5;
            this.chbTitle.Text = "Titel";
            this.chbTitle.UseVisualStyleBackColor = true;
            // 
            // chbFindInPast
            // 
            this.chbFindInPast.Location = new System.Drawing.Point(290, 30);
            this.chbFindInPast.Name = "chbFindInPast";
            this.chbFindInPast.Size = new System.Drawing.Size(156, 19);
            this.chbFindInPast.TabIndex = 4;
            this.chbFindInPast.Text = "In Vergangenheit suchen";
            this.chbFindInPast.UseVisualStyleBackColor = true;
            this.chbFindInPast.CheckedChanged += new System.EventHandler(this.chbFindInPast_CheckedChanged);
            // 
            // chbTimers
            // 
            this.chbTimers.Location = new System.Drawing.Point(197, 60);
            this.chbTimers.Name = "chbTimers";
            this.chbTimers.Size = new System.Drawing.Size(56, 19);
            this.chbTimers.TabIndex = 8;
            this.chbTimers.Text = "Timer";
            this.chbTimers.UseVisualStyleBackColor = true;
            // 
            // chbDescription
            // 
            this.chbDescription.Location = new System.Drawing.Point(43, 81);
            this.chbDescription.Name = "chbDescription";
            this.chbDescription.Size = new System.Drawing.Size(98, 19);
            this.chbDescription.TabIndex = 6;
            this.chbDescription.Text = "Beschreibung";
            this.chbDescription.UseVisualStyleBackColor = true;
            // 
            // chbSortDescription
            // 
            this.chbSortDescription.Location = new System.Drawing.Point(42, 104);
            this.chbSortDescription.Name = "chbSortDescription";
            this.chbSortDescription.Size = new System.Drawing.Size(121, 19);
            this.chbSortDescription.TabIndex = 7;
            this.chbSortDescription.Text = "Kurzbeschreibung";
            this.chbSortDescription.UseVisualStyleBackColor = true;
            // 
            // dgvFind
            // 
            this.dgvFind.AllowUserToAddRows = false;
            this.dgvFind.AllowUserToDeleteRows = false;
            this.dgvFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFind.EnableHeadersVisualStyles = false;
            this.dgvFind.Location = new System.Drawing.Point(4, 172);
            this.dgvFind.MultiSelect = false;
            this.dgvFind.Name = "dgvFind";
            this.dgvFind.ReadOnly = true;
            this.dgvFind.RowHeadersVisible = false;
            this.dgvFind.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFind.Size = new System.Drawing.Size(1128, 268);
            this.dgvFind.TabIndex = 7;
            this.dgvFind.Text = "dataGridView1";
            this.dgvFind.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFind_CellFormatting);
            this.dgvFind.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFind_CellMouseClick);
            this.dgvFind.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFind_CellMouseDoubleClick);
            this.dgvFind.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvFind_CellPainting);
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.Location = new System.Drawing.Point(108, 4);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(752, 23);
            this.tbFind.TabIndex = 1;
            this.tbFind.TextChanged += new System.EventHandler(this.tbFind_TextChanged);
            // 
            // lblFind
            // 
            this.lblFind.Location = new System.Drawing.Point(4, 6);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(100, 20);
            this.lblFind.TabIndex = 0;
            this.lblFind.Text = "Suche nach:";
            this.lblFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTimer
            // 
            this.btnTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimer.Location = new System.Drawing.Point(950, 456);
            this.btnTimer.Name = "btnTimer";
            this.btnTimer.Size = new System.Drawing.Size(94, 23);
            this.btnTimer.TabIndex = 1;
            this.btnTimer.Text = "Timer";
            this.btnTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimer.UseVisualStyleBackColor = true;
            this.btnTimer.Click += new System.EventHandler(this.btnTimer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(1048, 456);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(852, 456);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Markieren";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dlgFindEPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 490);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTimer);
            this.Controls.Add(this.panEPGFind);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgFindEPG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einträge suchen";
            this.panEPGFind.ResumeLayout(false);
            this.panEPGFind.PerformLayout();
            this.grbBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panEPGFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.CheckBox chbFindInPast;
        private System.Windows.Forms.CheckBox chbDescription;
        private System.Windows.Forms.CheckBox chbSortDescription;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnTimer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvFind;
        private System.Windows.Forms.GroupBox grbBox;
        private System.Windows.Forms.CheckBox chbTitle;
        private System.Windows.Forms.CheckBox chbTimers;
        private System.Windows.Forms.CheckBox chbRecordings;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblNotFound;
    }
}