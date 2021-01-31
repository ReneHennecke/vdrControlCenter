
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
            this.button2 = new System.Windows.Forms.Button();
            this.teResponse = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tmConnector = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.panBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // serviceConnector
            // 
            this.serviceConnector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceConnector.Location = new System.Drawing.Point(4, 4);
            this.serviceConnector.Name = "serviceConnector";
            this.serviceConnector.Size = new System.Drawing.Size(1092, 47);
            this.serviceConnector.TabIndex = 0;
            // 
            // panBox
            // 
            this.panBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBox.Controls.Add(this.button3);
            this.panBox.Controls.Add(this.button2);
            this.panBox.Controls.Add(this.teResponse);
            this.panBox.Controls.Add(this.button1);
            this.panBox.Location = new System.Drawing.Point(4, 54);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(1092, 404);
            this.panBox.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // teResponse
            // 
            this.teResponse.Location = new System.Drawing.Point(404, 172);
            this.teResponse.Multiline = true;
            this.teResponse.Name = "teResponse";
            this.teResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.teResponse.Size = new System.Drawing.Size(478, 168);
            this.teResponse.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tmConnector
            // 
            this.tmConnector.Interval = 10000;
            this.tmConnector.Tick += new System.EventHandler(this.tmConnector_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(788, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ServiceController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panBox);
            this.Controls.Add(this.serviceConnector);
            this.Name = "ServiceController";
            this.Size = new System.Drawing.Size(1099, 463);
            this.panBox.ResumeLayout(false);
            this.panBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ServiceConnectorView serviceConnector;
        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.Timer tmConnector;
        private System.Windows.Forms.TextBox teResponse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
