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
            this.mleBuffer = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grbBuffer = new System.Windows.Forms.GroupBox();
            this.lblBufferLength = new System.Windows.Forms.Label();
            this.grbBuffer.SuspendLayout();
            this.SuspendLayout();
            // 
            // svdrpConnector
            // 
            this.svdrpConnector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.svdrpConnector.Location = new System.Drawing.Point(2, 2);
            this.svdrpConnector.Name = "svdrpConnector";
            this.svdrpConnector.Size = new System.Drawing.Size(1218, 79);
            this.svdrpConnector.TabIndex = 0;
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
            this.mleBuffer.Size = new System.Drawing.Size(390, 190);
            this.mleBuffer.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 50);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grbBuffer
            // 
            this.grbBuffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbBuffer.Controls.Add(this.lblBufferLength);
            this.grbBuffer.Controls.Add(this.mleBuffer);
            this.grbBuffer.Location = new System.Drawing.Point(814, 358);
            this.grbBuffer.Name = "grbBuffer";
            this.grbBuffer.Size = new System.Drawing.Size(406, 244);
            this.grbBuffer.TabIndex = 3;
            this.grbBuffer.TabStop = false;
            this.grbBuffer.Text = "Puffer";
            // 
            // lblBufferLength
            // 
            this.lblBufferLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBufferLength.Location = new System.Drawing.Point(308, 216);
            this.lblBufferLength.Name = "lblBufferLength";
            this.lblBufferLength.Size = new System.Drawing.Size(89, 20);
            this.lblBufferLength.TabIndex = 2;
            this.lblBufferLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SvdrpController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbBuffer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.svdrpConnector);
            this.Name = "SvdrpController";
            this.Size = new System.Drawing.Size(1228, 607);
            this.grbBuffer.ResumeLayout(false);
            this.grbBuffer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SvdrpConnector svdrpConnector;
        private System.Windows.Forms.TextBox mleBuffer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grbBuffer;
        private System.Windows.Forms.Label lblBufferLength;
    }
}
