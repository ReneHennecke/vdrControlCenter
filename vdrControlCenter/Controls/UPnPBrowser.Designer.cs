namespace vdrControlCenterUI.Controls
{
    partial class UPnPBrowser
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
            this.trvBrowser = new System.Windows.Forms.TreeView();
            this.grbDetails = new System.Windows.Forms.GroupBox();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblTotalBytesDownLoaded = new System.Windows.Forms.Label();
            this.lblTotalFileSize = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lblDurationValue = new System.Windows.Forms.Label();
            this.lblMrlValue = new System.Windows.Forms.Label();
            this.lblNameValue = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblMrl = new System.Windows.Forms.Label();
            this.grbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvBrowser
            // 
            this.trvBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trvBrowser.Location = new System.Drawing.Point(3, 3);
            this.trvBrowser.Name = "trvBrowser";
            this.trvBrowser.Size = new System.Drawing.Size(374, 326);
            this.trvBrowser.TabIndex = 4;
            this.trvBrowser.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvBrowser_NodeMouseClick);
            // 
            // grbDetails
            // 
            this.grbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDetails.Controls.Add(this.pbProgress);
            this.grbDetails.Controls.Add(this.lblTotalBytesDownLoaded);
            this.grbDetails.Controls.Add(this.lblTotalFileSize);
            this.grbDetails.Controls.Add(this.btnDownload);
            this.grbDetails.Controls.Add(this.lblDurationValue);
            this.grbDetails.Controls.Add(this.lblMrlValue);
            this.grbDetails.Controls.Add(this.lblNameValue);
            this.grbDetails.Controls.Add(this.lblName);
            this.grbDetails.Controls.Add(this.lblDuration);
            this.grbDetails.Controls.Add(this.lblMrl);
            this.grbDetails.Location = new System.Drawing.Point(383, 3);
            this.grbDetails.Name = "grbDetails";
            this.grbDetails.Size = new System.Drawing.Size(821, 326);
            this.grbDetails.TabIndex = 5;
            this.grbDetails.TabStop = false;
            this.grbDetails.Text = "Details";
            // 
            // pbProgress
            // 
            this.pbProgress.ForeColor = System.Drawing.Color.LimeGreen;
            this.pbProgress.Location = new System.Drawing.Point(246, 224);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(145, 10);
            this.pbProgress.TabIndex = 9;
            // 
            // lblTotalBytesDownLoaded
            // 
            this.lblTotalBytesDownLoaded.BackColor = System.Drawing.Color.White;
            this.lblTotalBytesDownLoaded.Location = new System.Drawing.Point(41, 255);
            this.lblTotalBytesDownLoaded.Name = "lblTotalBytesDownLoaded";
            this.lblTotalBytesDownLoaded.Size = new System.Drawing.Size(173, 23);
            this.lblTotalBytesDownLoaded.TabIndex = 8;
            this.lblTotalBytesDownLoaded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalFileSize
            // 
            this.lblTotalFileSize.BackColor = System.Drawing.Color.White;
            this.lblTotalFileSize.Location = new System.Drawing.Point(41, 217);
            this.lblTotalFileSize.Name = "lblTotalFileSize";
            this.lblTotalFileSize.Size = new System.Drawing.Size(173, 23);
            this.lblTotalFileSize.TabIndex = 7;
            this.lblTotalFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(41, 180);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(118, 23);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "Start Dowload";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lblDurationValue
            // 
            this.lblDurationValue.Location = new System.Drawing.Point(93, 82);
            this.lblDurationValue.Name = "lblDurationValue";
            this.lblDurationValue.Size = new System.Drawing.Size(342, 23);
            this.lblDurationValue.TabIndex = 5;
            this.lblDurationValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMrlValue
            // 
            this.lblMrlValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMrlValue.Location = new System.Drawing.Point(93, 59);
            this.lblMrlValue.Name = "lblMrlValue";
            this.lblMrlValue.Size = new System.Drawing.Size(714, 23);
            this.lblMrlValue.TabIndex = 4;
            this.lblMrlValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNameValue
            // 
            this.lblNameValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNameValue.Location = new System.Drawing.Point(93, 36);
            this.lblNameValue.Name = "lblNameValue";
            this.lblNameValue.Size = new System.Drawing.Size(714, 23);
            this.lblNameValue.TabIndex = 3;
            this.lblNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(15, 36);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDuration
            // 
            this.lblDuration.Location = new System.Drawing.Point(15, 82);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(56, 23);
            this.lblDuration.TabIndex = 1;
            this.lblDuration.Text = "Dauer:";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMrl
            // 
            this.lblMrl.Location = new System.Drawing.Point(15, 59);
            this.lblMrl.Name = "lblMrl";
            this.lblMrl.Size = new System.Drawing.Size(56, 23);
            this.lblMrl.TabIndex = 0;
            this.lblMrl.Text = "MRL:";
            this.lblMrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UPnPBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbDetails);
            this.Controls.Add(this.trvBrowser);
            this.Name = "UPnPBrowser";
            this.Size = new System.Drawing.Size(1213, 335);
            this.grbDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TreeView trvBrowser;
        private GroupBox grbDetails;
        private Label lblMrl;
        private Label lblName;
        private Label lblDuration;
        private Label lblDurationValue;
        private Label lblMrlValue;
        private Label lblNameValue;
        private Button btnDownload;
        private Label lblTotalFileSize;
        private Label lblTotalBytesDownLoaded;
        private ProgressBar pbProgress;
    }
}
