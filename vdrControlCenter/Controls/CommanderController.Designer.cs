
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
            this.cmvRight = new vdrControlCenterUI.Controls.CommanderView();
            this.cmvLeft = new vdrControlCenterUI.Controls.CommanderView();
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
            this.splFileCommander.Panel1.Controls.Add(this.cmvLeft);
            // 
            // splFileCommander.Panel2
            // 
            this.splFileCommander.Panel2.Controls.Add(this.cmvRight);
            this.splFileCommander.Size = new System.Drawing.Size(1172, 414);
            this.splFileCommander.SplitterDistance = 550;
            this.splFileCommander.TabIndex = 4;
            // 
            // cmvRight
            // 
            this.cmvRight.Controller = null;
            this.cmvRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmvRight.Location = new System.Drawing.Point(0, 0);
            this.cmvRight.Name = "cmvRight";
            this.cmvRight.Size = new System.Drawing.Size(618, 414);
            this.cmvRight.TabIndex = 0;
            // 
            // cmvLeft
            // 
            this.cmvLeft.Controller = null;
            this.cmvLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmvLeft.Location = new System.Drawing.Point(0, 0);
            this.cmvLeft.Name = "cmvLeft";
            this.cmvLeft.Size = new System.Drawing.Size(550, 414);
            this.cmvLeft.TabIndex = 0;
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
        private CommanderView cmvLeft;
        private CommanderView cmvRight;
    }
}
