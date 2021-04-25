
namespace vdrControlCenterUI.Controls
{
    partial class ServiceController
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
            this.serviceConnector = new vdrControlCenterUI.Controls.ServiceConnectorView();
            this.panBox = new System.Windows.Forms.Panel();
            this.splFileCommander = new System.Windows.Forms.SplitContainer();
            this.cvLocal = new vdrControlCenterUI.Controls.CommanderView();
            this.cvRemote = new vdrControlCenterUI.Controls.CommanderView();
            this.tmConnector = new System.Windows.Forms.Timer(this.components);
            this.panBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splFileCommander)).BeginInit();
            this.splFileCommander.Panel1.SuspendLayout();
            this.splFileCommander.Panel2.SuspendLayout();
            this.splFileCommander.SuspendLayout();
            this.SuspendLayout();
            // 
            // serviceConnector
            // 
            this.serviceConnector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceConnector.Location = new System.Drawing.Point(4, 4);
            this.serviceConnector.Name = "serviceConnector";
            this.serviceConnector.Size = new System.Drawing.Size(1182, 47);
            this.serviceConnector.TabIndex = 0;
            // 
            // panBox
            // 
            this.panBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBox.Controls.Add(this.splFileCommander);
            this.panBox.Location = new System.Drawing.Point(4, 54);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(1182, 374);
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
            this.splFileCommander.Panel1.Controls.Add(this.cvLocal);
            // 
            // splFileCommander.Panel2
            // 
            this.splFileCommander.Panel2.Controls.Add(this.cvRemote);
            this.splFileCommander.Size = new System.Drawing.Size(1172, 366);
            this.splFileCommander.SplitterDistance = 550;
            this.splFileCommander.TabIndex = 4;
            // 
            // cvLocal
            // 
            this.cvLocal.Controller = null;
            this.cvLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvLocal.Location = new System.Drawing.Point(0, 0);
            this.cvLocal.Name = "cvLocal";
            this.cvLocal.Size = new System.Drawing.Size(550, 366);
            this.cvLocal.TabIndex = 0;
            // 
            // cvRemote
            // 
            this.cvRemote.Controller = null;
            this.cvRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvRemote.Location = new System.Drawing.Point(0, 0);
            this.cvRemote.Name = "cvRemote";
            this.cvRemote.Size = new System.Drawing.Size(618, 366);
            this.cvRemote.TabIndex = 0;
            // 
            // tmConnector
            // 
            this.tmConnector.Interval = 10000;
            this.tmConnector.Tick += new System.EventHandler(this.tmConnector_Tick);
            // 
            // ServiceController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panBox);
            this.Controls.Add(this.serviceConnector);
            this.Name = "ServiceController";
            this.Size = new System.Drawing.Size(1189, 471);
            this.panBox.ResumeLayout(false);
            this.splFileCommander.Panel1.ResumeLayout(false);
            this.splFileCommander.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splFileCommander)).EndInit();
            this.splFileCommander.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ServiceConnectorView serviceConnector;
        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.Timer tmConnector;
        private System.Windows.Forms.SplitContainer splFileCommander;
        private CommanderView cvLocal;
        private CommanderView cvRemote;
    }
}
