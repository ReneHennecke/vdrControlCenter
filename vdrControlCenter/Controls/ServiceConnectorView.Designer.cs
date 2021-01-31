namespace vdrControlCenterUI.Controls
{
    partial class ServiceConnectorView
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
            this.lblServiceAddressValue = new System.Windows.Forms.Label();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblServiceAddress = new System.Windows.Forms.Label();
            this.panBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBox
            // 
            this.panBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBox.Controls.Add(this.lblServiceAddressValue);
            this.panBox.Controls.Add(this.lblConnectionString);
            this.panBox.Controls.Add(this.lblStatus);
            this.panBox.Controls.Add(this.lblServiceAddress);
            this.panBox.Location = new System.Drawing.Point(6, 4);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(1080, 39);
            this.panBox.TabIndex = 0;
            // 
            // lblServiceAddressValue
            // 
            this.lblServiceAddressValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblServiceAddressValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblServiceAddressValue.Location = new System.Drawing.Point(108, 8);
            this.lblServiceAddressValue.Name = "lblServiceAddressValue";
            this.lblServiceAddressValue.Size = new System.Drawing.Size(638, 22);
            this.lblServiceAddressValue.TabIndex = 4;
            this.lblServiceAddressValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnectionString.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblConnectionString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConnectionString.Location = new System.Drawing.Point(824, 8);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(250, 22);
            this.lblConnectionString.TabIndex = 3;
            this.lblConnectionString.Text = "Getrennt";
            this.lblConnectionString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStatus.Location = new System.Drawing.Point(750, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(72, 22);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblServiceAddress
            // 
            this.lblServiceAddress.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblServiceAddress.Location = new System.Drawing.Point(6, 8);
            this.lblServiceAddress.Name = "lblServiceAddress";
            this.lblServiceAddress.Size = new System.Drawing.Size(100, 23);
            this.lblServiceAddress.TabIndex = 0;
            this.lblServiceAddress.Text = "Service-Adresse:";
            this.lblServiceAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ServiceConnectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panBox);
            this.Name = "ServiceConnectorView";
            this.Size = new System.Drawing.Size(1092, 47);
            this.panBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.Label lblServiceAddress;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblServiceAddressValue;
    }
}
