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
            this.grbBox = new System.Windows.Forms.GroupBox();
            this.chbSortDescription = new System.Windows.Forms.CheckBox();
            this.chbDescription = new System.Windows.Forms.CheckBox();
            this.chbFindInPast = new System.Windows.Forms.CheckBox();
            this.dgvFind = new System.Windows.Forms.DataGridView();
            this.btnFind = new System.Windows.Forms.Button();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panEPGFind.SuspendLayout();
            this.grbBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFind)).BeginInit();
            this.SuspendLayout();
            // 
            // panEPGFind
            // 
            this.panEPGFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panEPGFind.Controls.Add(this.grbBox);
            this.panEPGFind.Controls.Add(this.dgvFind);
            this.panEPGFind.Controls.Add(this.btnFind);
            this.panEPGFind.Controls.Add(this.tbFind);
            this.panEPGFind.Controls.Add(this.lblFind);
            this.panEPGFind.Location = new System.Drawing.Point(8, 4);
            this.panEPGFind.Name = "panEPGFind";
            this.panEPGFind.Size = new System.Drawing.Size(636, 354);
            this.panEPGFind.TabIndex = 0;
            // 
            // grbBox
            // 
            this.grbBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbBox.Controls.Add(this.chbSortDescription);
            this.grbBox.Controls.Add(this.chbDescription);
            this.grbBox.Controls.Add(this.chbFindInPast);
            this.grbBox.Location = new System.Drawing.Point(4, 30);
            this.grbBox.Name = "grbBox";
            this.grbBox.Size = new System.Drawing.Size(628, 106);
            this.grbBox.TabIndex = 8;
            this.grbBox.TabStop = false;
            this.grbBox.Text = "Suche erweitern";
            // 
            // chbSortDescription
            // 
            this.chbSortDescription.AutoSize = true;
            this.chbSortDescription.Location = new System.Drawing.Point(14, 30);
            this.chbSortDescription.Name = "chbSortDescription";
            this.chbSortDescription.Size = new System.Drawing.Size(121, 19);
            this.chbSortDescription.TabIndex = 2;
            this.chbSortDescription.Text = "Kurzbeschreibung";
            this.chbSortDescription.UseVisualStyleBackColor = true;
            // 
            // chbDescription
            // 
            this.chbDescription.AutoSize = true;
            this.chbDescription.Location = new System.Drawing.Point(14, 50);
            this.chbDescription.Name = "chbDescription";
            this.chbDescription.Size = new System.Drawing.Size(98, 19);
            this.chbDescription.TabIndex = 3;
            this.chbDescription.Text = "Beschreibung";
            this.chbDescription.UseVisualStyleBackColor = true;
            // 
            // chbFindInPast
            // 
            this.chbFindInPast.AutoSize = true;
            this.chbFindInPast.Location = new System.Drawing.Point(14, 70);
            this.chbFindInPast.Name = "chbFindInPast";
            this.chbFindInPast.Size = new System.Drawing.Size(156, 19);
            this.chbFindInPast.TabIndex = 4;
            this.chbFindInPast.Text = "In Vergangenheit suchen";
            this.chbFindInPast.UseVisualStyleBackColor = true;
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
            this.dgvFind.Location = new System.Drawing.Point(4, 140);
            this.dgvFind.Name = "dgvFind";
            this.dgvFind.ReadOnly = true;
            this.dgvFind.RowHeadersVisible = false;
            this.dgvFind.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFind.Size = new System.Drawing.Size(626, 208);
            this.dgvFind.TabIndex = 7;
            this.dgvFind.Text = "dataGridView1";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(556, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Suchen";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.Location = new System.Drawing.Point(108, 4);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(444, 23);
            this.tbFind.TabIndex = 1;
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
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(454, 364);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(552, 364);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlgFindEPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 390);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
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
            this.grbBox.PerformLayout();
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
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvFind;
        private System.Windows.Forms.GroupBox grbBox;
    }
}