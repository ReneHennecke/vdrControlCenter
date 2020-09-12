namespace vdrControlCenterUI.Controls
{
    partial class SvdrpController
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
            this.svdrpConnector = new vdrControlCenterUI.Controls.SvdrpConnector();
            this.SuspendLayout();
            // 
            // svdrpConnector
            // 
            this.svdrpConnector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.svdrpConnector.Location = new System.Drawing.Point(2, 2);
            this.svdrpConnector.Name = "svdrpConnector";
            this.svdrpConnector.Owner = null;
            this.svdrpConnector.Size = new System.Drawing.Size(1470, 79);
            this.svdrpConnector.TabIndex = 0;
            // 
            // SvdrpController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.svdrpConnector);
            this.Name = "SvdrpController";
            this.Size = new System.Drawing.Size(1476, 590);
            this.ResumeLayout(false);

        }

        #endregion

        private SvdrpConnector svdrpConnector;
    }
}
