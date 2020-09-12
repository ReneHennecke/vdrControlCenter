namespace vdrControlCenterUI.Controls
{
    partial class SvdrpConnector
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
            this.lblSvdrpAddress = new System.Windows.Forms.Label();
            this.lblSvdrpAddressValue = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblStateValue = new System.Windows.Forms.Label();
            this.panBox = new System.Windows.Forms.Panel();
            this.btnConnect_Disconnect = new System.Windows.Forms.Button();
            this.panBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSvdrpAddress
            // 
            this.lblSvdrpAddress.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSvdrpAddress.Location = new System.Drawing.Point(6, 6);
            this.lblSvdrpAddress.Name = "lblSvdrpAddress";
            this.lblSvdrpAddress.Size = new System.Drawing.Size(118, 22);
            this.lblSvdrpAddress.TabIndex = 0;
            this.lblSvdrpAddress.Text = "SVDRP-Adresse:";
            this.lblSvdrpAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSvdrpAddressValue
            // 
            this.lblSvdrpAddressValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSvdrpAddressValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSvdrpAddressValue.Location = new System.Drawing.Point(128, 6);
            this.lblSvdrpAddressValue.Name = "lblSvdrpAddressValue";
            this.lblSvdrpAddressValue.Size = new System.Drawing.Size(240, 22);
            this.lblSvdrpAddressValue.TabIndex = 1;
            this.lblSvdrpAddressValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblState.Location = new System.Drawing.Point(374, 6);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(118, 22);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "Status:";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStateValue
            // 
            this.lblStateValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStateValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStateValue.Location = new System.Drawing.Point(496, 6);
            this.lblStateValue.Name = "lblStateValue";
            this.lblStateValue.Size = new System.Drawing.Size(492, 22);
            this.lblStateValue.TabIndex = 3;
            this.lblStateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panBox
            // 
            this.panBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBox.Controls.Add(this.btnConnect_Disconnect);
            this.panBox.Controls.Add(this.lblStateValue);
            this.panBox.Controls.Add(this.lblSvdrpAddress);
            this.panBox.Controls.Add(this.lblState);
            this.panBox.Controls.Add(this.lblSvdrpAddressValue);
            this.panBox.Location = new System.Drawing.Point(2, 4);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(996, 70);
            this.panBox.TabIndex = 0;
            // 
            // btnConnect_Disconnect
            // 
            this.btnConnect_Disconnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect_Disconnect.Location = new System.Drawing.Point(4, 32);
            this.btnConnect_Disconnect.Name = "btnConnect_Disconnect";
            this.btnConnect_Disconnect.Size = new System.Drawing.Size(122, 23);
            this.btnConnect_Disconnect.TabIndex = 4;
            this.btnConnect_Disconnect.Text = "Verbinden";
            this.btnConnect_Disconnect.UseVisualStyleBackColor = true;
            this.btnConnect_Disconnect.Click += new System.EventHandler(this.btnConnect_Disconnect_Click);
            // 
            // SvdrpConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panBox);
            this.Name = "SvdrpConnector";
            this.Size = new System.Drawing.Size(1003, 79);
            this.panBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSvdrpAddress;
        private System.Windows.Forms.Label lblSvdrpAddressValue;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblStateValue;
        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.Button btnConnect_Disconnect;
    }
}
