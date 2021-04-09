
namespace vdrControlCenterUI.Controls
{
    partial class CommanderController
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
            this.splFileCommander = new System.Windows.Forms.SplitContainer();
            this.cvLeft = new vdrControlCenterUI.Controls.CommanderView();
            this.cvRight = new vdrControlCenterUI.Controls.CommanderView();
            this.cmbRight = new System.Windows.Forms.ComboBox();
            this.lblLeft = new System.Windows.Forms.Label();
            this.panBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splFileCommander)).BeginInit();
            this.splFileCommander.Panel1.SuspendLayout();
            this.splFileCommander.Panel2.SuspendLayout();
            this.splFileCommander.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBox
            // 
            this.panBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBox.Controls.Add(this.splFileCommander);
            this.panBox.Location = new System.Drawing.Point(4, 6);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(1182, 422);
            this.panBox.TabIndex = 1;
            // 
            // splFileCommander
            // 
            this.splFileCommander.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splFileCommander.Location = new System.Drawing.Point(4, 4);
            this.splFileCommander.Name = "splFileCommander";
            // 
            // splFileCommander.Panel1
            // 
            this.splFileCommander.Panel1.Controls.Add(this.lblLeft);
            this.splFileCommander.Panel1.Controls.Add(this.cvLeft);
            // 
            // splFileCommander.Panel2
            // 
            this.splFileCommander.Panel2.Controls.Add(this.cmbRight);
            this.splFileCommander.Panel2.Controls.Add(this.cvRight);
            this.splFileCommander.Size = new System.Drawing.Size(1172, 414);
            this.splFileCommander.SplitterDistance = 550;
            this.splFileCommander.TabIndex = 4;
            // 
            // cvLeft
            // 
            this.cvLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cvLeft.Controller = null;
            this.cvLeft.FileSystemEntry = null;
            this.cvLeft.IsLocal = false;
            this.cvLeft.Location = new System.Drawing.Point(0, 30);
            this.cvLeft.Name = "cvLeft";
            this.cvLeft.Size = new System.Drawing.Size(550, 384);
            this.cvLeft.TabIndex = 0;
            // 
            // cvRight
            // 
            this.cvRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cvRight.Controller = null;
            this.cvRight.FileSystemEntry = null;
            this.cvRight.IsLocal = false;
            this.cvRight.Location = new System.Drawing.Point(0, 30);
            this.cvRight.Name = "cvRight";
            this.cvRight.Size = new System.Drawing.Size(618, 384);
            this.cvRight.TabIndex = 0;
            // 
            // cmbRight
            // 
            this.cmbRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRight.FormattingEnabled = true;
            this.cmbRight.Location = new System.Drawing.Point(0, 4);
            this.cmbRight.Name = "cmbRight";
            this.cmbRight.Size = new System.Drawing.Size(618, 23);
            this.cmbRight.TabIndex = 1;
            // 
            // lblLeft
            // 
            this.lblLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeft.Location = new System.Drawing.Point(2, 6);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(546, 20);
            this.lblLeft.TabIndex = 1;
            this.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CommanderController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panBox);
            this.Name = "CommanderController";
            this.Size = new System.Drawing.Size(1189, 471);
            this.panBox.ResumeLayout(false);
            this.splFileCommander.Panel1.ResumeLayout(false);
            this.splFileCommander.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splFileCommander)).EndInit();
            this.splFileCommander.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.SplitContainer splFileCommander;
        private CommanderView cvLeft;
        private CommanderView cvRight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.ComboBox cmbRight;
    }
}
