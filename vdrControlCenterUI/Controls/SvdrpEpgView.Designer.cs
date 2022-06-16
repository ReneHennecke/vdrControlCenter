namespace vdrControlCenterUI.Controls
{
    partial class SvdrpEpgView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panBox = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblRequestInfo = new System.Windows.Forms.Label();
            this.dgvEPG = new System.Windows.Forms.DataGridView();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnTimer = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.panBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEPG)).BeginInit();
            this.SuspendLayout();
            // 
            // panBox
            // 
            this.panBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBox.Controls.Add(this.dtpDate);
            this.panBox.Controls.Add(this.lblRequestInfo);
            this.panBox.Controls.Add(this.dgvEPG);
            this.panBox.Controls.Add(this.btnRequest);
            this.panBox.Controls.Add(this.btnTimer);
            this.panBox.Controls.Add(this.btnFind);
            this.panBox.Location = new System.Drawing.Point(2, 2);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(678, 336);
            this.panBox.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpDate.Location = new System.Drawing.Point(200, 306);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(196, 23);
            this.dtpDate.TabIndex = 4;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblRequestInfo
            // 
            this.lblRequestInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRequestInfo.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRequestInfo.Location = new System.Drawing.Point(2, 310);
            this.lblRequestInfo.Name = "lblRequestInfo";
            this.lblRequestInfo.Size = new System.Drawing.Size(142, 16);
            this.lblRequestInfo.TabIndex = 1;
            this.lblRequestInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvEPG
            // 
            this.dgvEPG.AllowUserToAddRows = false;
            this.dgvEPG.AllowUserToDeleteRows = false;
            this.dgvEPG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEPG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvEPG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEPG.EnableHeadersVisualStyles = false;
            this.dgvEPG.Location = new System.Drawing.Point(2, 2);
            this.dgvEPG.MultiSelect = false;
            this.dgvEPG.Name = "dgvEPG";
            this.dgvEPG.ReadOnly = true;
            this.dgvEPG.RowHeadersVisible = false;
            this.dgvEPG.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvEPG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEPG.ShowCellToolTips = false;
            this.dgvEPG.Size = new System.Drawing.Size(670, 300);
            this.dgvEPG.TabIndex = 0;
            this.dgvEPG.Text = "dataGridView1";
            this.dgvEPG.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEPG_CellFormatting);
            this.dgvEPG.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEPG_CellMouseClick);
            this.dgvEPG.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvEPG_CellPainting);
            this.dgvEPG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvEPG_MouseMove);
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequest.Enabled = false;
            this.btnRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRequest.Location = new System.Drawing.Point(596, 306);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 3;
            this.btnRequest.Text = "Abfrage";
            this.btnRequest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnTimer
            // 
            this.btnTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimer.Location = new System.Drawing.Point(516, 306);
            this.btnTimer.Name = "btnTimer";
            this.btnTimer.Size = new System.Drawing.Size(75, 23);
            this.btnTimer.TabIndex = 2;
            this.btnTimer.Text = "Timer";
            this.btnTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimer.UseVisualStyleBackColor = true;
            this.btnTimer.Click += new System.EventHandler(this.btnTimer_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(436, 306);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Suchen";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // SvdrpEpgView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panBox);
            this.Name = "SvdrpEpgView";
            this.Size = new System.Drawing.Size(684, 342);
            this.panBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEPG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnTimer;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridView dgvEPG;
        private System.Windows.Forms.Label lblRequestInfo;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}
