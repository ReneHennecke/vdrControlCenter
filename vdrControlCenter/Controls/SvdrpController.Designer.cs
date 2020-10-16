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
            this.components = new System.ComponentModel.Container();
            this.mleBuffer = new System.Windows.Forms.TextBox();
            this.grbBuffer = new System.Windows.Forms.GroupBox();
            this.lblBufferLength = new System.Windows.Forms.Label();
            this.tmTimeOut = new System.Windows.Forms.Timer(this.components);
            this.grbBuffer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mleBuffer
            // 
            this.mleBuffer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mleBuffer.BackColor = System.Drawing.Color.Black;
            this.mleBuffer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mleBuffer.ForeColor = System.Drawing.Color.Lime;
            this.mleBuffer.Location = new System.Drawing.Point(8, 22);
            this.mleBuffer.Multiline = true;
            this.mleBuffer.Name = "mleBuffer";
            this.mleBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mleBuffer.Size = new System.Drawing.Size(390, 68);
            this.mleBuffer.TabIndex = 1;
            // 
            // grbBuffer
            // 
            this.grbBuffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbBuffer.Controls.Add(this.lblBufferLength);
            this.grbBuffer.Controls.Add(this.mleBuffer);
            this.grbBuffer.Location = new System.Drawing.Point(990, 480);
            this.grbBuffer.Name = "grbBuffer";
            this.grbBuffer.Size = new System.Drawing.Size(406, 122);
            this.grbBuffer.TabIndex = 3;
            this.grbBuffer.TabStop = false;
            this.grbBuffer.Text = "Puffer";
            // 
            // lblBufferLength
            // 
            this.lblBufferLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBufferLength.Location = new System.Drawing.Point(308, 94);
            this.lblBufferLength.Name = "lblBufferLength";
            this.lblBufferLength.Size = new System.Drawing.Size(89, 20);
            this.lblBufferLength.TabIndex = 2;
            this.lblBufferLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmTimeOut
            // 
            this.tmTimeOut.Interval = 5000;
            this.tmTimeOut.Tick += new System.EventHandler(this.tmTimeOut_Tick);
            // 
            // SvdrpController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbBuffer);
            this.Name = "SvdrpController";
            this.Size = new System.Drawing.Size(1404, 607);
            this.grbBuffer.ResumeLayout(false);
            this.grbBuffer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox mleBuffer;
        private System.Windows.Forms.GroupBox grbBuffer;
        private System.Windows.Forms.Label lblBufferLength;
        private System.Windows.Forms.Timer tmTimeOut;
    }
}
