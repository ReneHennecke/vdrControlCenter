namespace vdrControlCenterUI.Controls
{
    partial class SshConnectorView
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
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnConnect_Disconnect = new System.Windows.Forms.Button();
            this.lblSshAddressValue = new System.Windows.Forms.Label();
            this.lblSshAddress = new System.Windows.Forms.Label();
            this.panBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBox
            // 
            this.panBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBox.Controls.Add(this.lblConnectionString);
            this.panBox.Controls.Add(this.lblStatus);
            this.panBox.Controls.Add(this.btnConnect_Disconnect);
            this.panBox.Controls.Add(this.lblSshAddressValue);
            this.panBox.Controls.Add(this.lblSshAddress);
            this.panBox.Location = new System.Drawing.Point(6, 4);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(1080, 72);
            this.panBox.TabIndex = 0;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnectionString.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblConnectionString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConnectionString.Location = new System.Drawing.Point(564, 8);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(510, 22);
            this.lblConnectionString.TabIndex = 4;
            this.lblConnectionString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStatus.Location = new System.Drawing.Point(490, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(72, 22);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConnect_Disconnect
            // 
            this.btnConnect_Disconnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect_Disconnect.Location = new System.Drawing.Point(4, 36);
            this.btnConnect_Disconnect.Name = "btnConnect_Disconnect";
            this.btnConnect_Disconnect.Size = new System.Drawing.Size(122, 23);
            this.btnConnect_Disconnect.TabIndex = 2;
            this.btnConnect_Disconnect.Text = "Verbinden";
            this.btnConnect_Disconnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnect_Disconnect.UseVisualStyleBackColor = true;
            this.btnConnect_Disconnect.Click += new System.EventHandler(this.btnConnect_Disconnect_Click);
            // 
            // lblSshAddressValue
            // 
            this.lblSshAddressValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSshAddressValue.Location = new System.Drawing.Point(110, 8);
            this.lblSshAddressValue.Name = "lblSshAddressValue";
            this.lblSshAddressValue.Size = new System.Drawing.Size(376, 23);
            this.lblSshAddressValue.TabIndex = 1;
            this.lblSshAddressValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSshAddress
            // 
            this.lblSshAddress.Location = new System.Drawing.Point(6, 8);
            this.lblSshAddress.Name = "lblSshAddress";
            this.lblSshAddress.Size = new System.Drawing.Size(100, 23);
            this.lblSshAddress.TabIndex = 1;
            this.lblSshAddress.Text = "SSH-Adresse:";
            this.lblSshAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SshConnectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panBox);
            this.Name = "SshConnectorView";
            this.Size = new System.Drawing.Size(1092, 81);
            this.panBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.Label lblSshAddress;
        private System.Windows.Forms.Button btnConnect_Disconnect;
        private System.Windows.Forms.Label lblSshAddressValue;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.Label lblStatus;
    }
}
