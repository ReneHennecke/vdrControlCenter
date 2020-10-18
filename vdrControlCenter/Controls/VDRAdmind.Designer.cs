namespace vdrControlCenterUI.Controls
{
    partial class VDRAdmindView
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
            this.lblAddressValue = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.wcWebViewer = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBox
            // 
            this.panBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBox.Controls.Add(this.lblAddressValue);
            this.panBox.Controls.Add(this.lblAddress);
            this.panBox.Location = new System.Drawing.Point(2, 2);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(1202, 34);
            this.panBox.TabIndex = 0;
            // 
            // lblAddressValue
            // 
            this.lblAddressValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddressValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAddressValue.Location = new System.Drawing.Point(86, 6);
            this.lblAddressValue.Name = "lblAddressValue";
            this.lblAddressValue.Size = new System.Drawing.Size(1110, 20);
            this.lblAddressValue.TabIndex = 0;
            this.lblAddressValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(6, 6);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(76, 20);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Addresse:";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // wcWebViewer
            // 
            this.wcWebViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wcWebViewer.Location = new System.Drawing.Point(4, 38);
            this.wcWebViewer.Name = "wcWebViewer";
            this.wcWebViewer.Size = new System.Drawing.Size(1200, 522);
            this.wcWebViewer.Source = new System.Uri("about:blank", System.UriKind.Absolute);
            this.wcWebViewer.TabIndex = 1;
            this.wcWebViewer.Text = "webView21";
            this.wcWebViewer.ZoomFactor = 1D;
            // 
            // VDRAdmindView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wcWebViewer);
            this.Controls.Add(this.panBox);
            this.Name = "VDRAdmindView";
            this.Size = new System.Drawing.Size(1207, 563);
            this.panBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblAddressValue;
        private Microsoft.Web.WebView2.WinForms.WebView2 wcWebViewer;
    }
}
