namespace vdrControlCenterUI.Controls
{
    partial class SvdrpTimersView
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
            this.lblRequestInfo = new System.Windows.Forms.Label();
            this.dgvTimers = new System.Windows.Forms.DataGridView();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimers)).BeginInit();
            this.SuspendLayout();
            // 
            // panBox
            // 
            this.panBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBox.Controls.Add(this.lblRequestInfo);
            this.panBox.Controls.Add(this.dgvTimers);
            this.panBox.Controls.Add(this.btnRequest);
            this.panBox.Controls.Add(this.btnDel);
            this.panBox.Controls.Add(this.btnNew);
            this.panBox.Location = new System.Drawing.Point(4, 4);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(472, 246);
            this.panBox.TabIndex = 1;
            // 
            // lblRequestInfo
            // 
            this.lblRequestInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRequestInfo.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRequestInfo.Location = new System.Drawing.Point(2, 220);
            this.lblRequestInfo.Name = "lblRequestInfo";
            this.lblRequestInfo.Size = new System.Drawing.Size(142, 16);
            this.lblRequestInfo.TabIndex = 1;
            this.lblRequestInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvTimers
            // 
            this.dgvTimers.AllowUserToAddRows = false;
            this.dgvTimers.AllowUserToDeleteRows = false;
            this.dgvTimers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvTimers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimers.EnableHeadersVisualStyles = false;
            this.dgvTimers.Location = new System.Drawing.Point(2, 2);
            this.dgvTimers.MultiSelect = false;
            this.dgvTimers.Name = "dgvTimers";
            this.dgvTimers.ReadOnly = true;
            this.dgvTimers.RowHeadersVisible = false;
            this.dgvTimers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTimers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimers.Size = new System.Drawing.Size(464, 208);
            this.dgvTimers.TabIndex = 0;
            this.dgvTimers.Text = "dataGridView1";
            this.dgvTimers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTimers_CellFormatting);
            this.dgvTimers.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTimers_CellPainting);
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequest.Enabled = false;
            this.btnRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRequest.Location = new System.Drawing.Point(390, 216);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 3;
            this.btnRequest.Text = "Abfrage";
            this.btnRequest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Enabled = false;
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(310, 216);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Löschen";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Enabled = false;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(230, 216);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "Neu";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // SvdrpTimersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panBox);
            this.Name = "SvdrpTimersView";
            this.Size = new System.Drawing.Size(480, 254);
            this.panBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvTimers;
        private System.Windows.Forms.Label lblRequestInfo;
    }
}
