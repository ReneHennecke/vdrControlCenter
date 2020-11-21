namespace vdrControlCenterUI.Controls
{
    partial class SshController
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
            this.bccConsole = new vdrControlCenterUI.Controls.BashColorConsole();
            this.teCommand = new System.Windows.Forms.TextBox();
            this.sshConnector = new vdrControlCenterUI.Controls.SshConnectorView();
            this.SuspendLayout();
            // 
            // bccConsole
            // 
            this.bccConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bccConsole.BackColor = System.Drawing.Color.Black;
            this.bccConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bccConsole.ForeColor = System.Drawing.Color.White;
            this.bccConsole.Location = new System.Drawing.Point(4, 84);
            this.bccConsole.Name = "bccConsole";
            this.bccConsole.ReadOnly = true;
            this.bccConsole.Size = new System.Drawing.Size(1303, 304);
            this.bccConsole.TabIndex = 0;
            this.bccConsole.Text = "";
            // 
            // teCommand
            // 
            this.teCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teCommand.Location = new System.Drawing.Point(4, 400);
            this.teCommand.Name = "teCommand";
            this.teCommand.ReadOnly = true;
            this.teCommand.Size = new System.Drawing.Size(1302, 23);
            this.teCommand.TabIndex = 1;
            this.teCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teCommand_KeyDown);
            // 
            // sshConnector
            // 
            this.sshConnector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sshConnector.Location = new System.Drawing.Point(4, 4);
            this.sshConnector.Name = "sshConnector";
            this.sshConnector.Size = new System.Drawing.Size(1302, 76);
            this.sshConnector.TabIndex = 2;
            // 
            // SshController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sshConnector);
            this.Controls.Add(this.teCommand);
            this.Controls.Add(this.bccConsole);
            this.Name = "SshController";
            this.Size = new System.Drawing.Size(1312, 431);
            this.Load += new System.EventHandler(this.SshController_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BashColorConsole bccConsole;
        private System.Windows.Forms.TextBox teCommand;
        private SshConnectorView sshConnector;
    }
}
