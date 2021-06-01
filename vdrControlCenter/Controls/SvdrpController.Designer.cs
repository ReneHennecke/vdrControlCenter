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
            this.tmTimeOut = new System.Windows.Forms.Timer(this.components);
            this.mleBuffer = new System.Windows.Forms.TextBox();
            this.lblBufferLength = new System.Windows.Forms.Label();
            this.grbBuffer = new System.Windows.Forms.GroupBox();
            this.svdrpConnector = new vdrControlCenterUI.Controls.SvdrpConnectorView();
            this.svdrpChannelsView = new vdrControlCenterUI.Controls.SvdrpChannelsView();
            this.svdrpTimersView = new vdrControlCenterUI.Controls.SvdrpTimersView();
            this.svdrpRecordingsView = new vdrControlCenterUI.Controls.SvdrpRecordingsView();
            this.svdrpEpgListView = new vdrControlCenterUI.Controls.SvdrpEpgView();
            this.svdrpStatusInfoView = new vdrControlCenterUI.Controls.SvdrpStatusInfoView();
            this.grbBuffer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmTimeOut
            // 
            this.tmTimeOut.Interval = 5000;
            this.tmTimeOut.Tick += new System.EventHandler(this.tmTimeOut_Tick);
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
            this.mleBuffer.Size = new System.Drawing.Size(390, 174);
            this.mleBuffer.TabIndex = 1;
            // 
            // lblBufferLength
            // 
            this.lblBufferLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBufferLength.Location = new System.Drawing.Point(308, 200);
            this.lblBufferLength.Name = "lblBufferLength";
            this.lblBufferLength.Size = new System.Drawing.Size(89, 20);
            this.lblBufferLength.TabIndex = 2;
            this.lblBufferLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbBuffer
            // 
            this.grbBuffer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grbBuffer.Controls.Add(this.lblBufferLength);
            this.grbBuffer.Controls.Add(this.mleBuffer);
            this.grbBuffer.Location = new System.Drawing.Point(1086, 470);
            this.grbBuffer.Name = "grbBuffer";
            this.grbBuffer.Size = new System.Drawing.Size(406, 228);
            this.grbBuffer.TabIndex = 3;
            this.grbBuffer.TabStop = false;
            this.grbBuffer.Text = "Puffer";
            // 
            // svdrpConnector
            // 
            this.svdrpConnector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.svdrpConnector.Location = new System.Drawing.Point(2, 4);
            this.svdrpConnector.Name = "svdrpConnector";
            this.svdrpConnector.Size = new System.Drawing.Size(1673, 79);
            this.svdrpConnector.TabIndex = 4;
            // 
            // svdrpChannelsView
            // 
            this.svdrpChannelsView.Location = new System.Drawing.Point(2, 86);
            this.svdrpChannelsView.Name = "svdrpChannelsView";
            this.svdrpChannelsView.RequestEnable = false;
            this.svdrpChannelsView.Size = new System.Drawing.Size(450, 252);
            this.svdrpChannelsView.TabIndex = 5;
            // 
            // svdrpTimersView
            // 
            this.svdrpTimersView.Location = new System.Drawing.Point(454, 86);
            this.svdrpTimersView.Name = "svdrpTimersView";
            this.svdrpTimersView.RequestEnable = false;
            this.svdrpTimersView.Size = new System.Drawing.Size(552, 252);
            this.svdrpTimersView.TabIndex = 6;
            // 
            // svdrpRecordingsView
            // 
            this.svdrpRecordingsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.svdrpRecordingsView.Location = new System.Drawing.Point(1008, 86);
            this.svdrpRecordingsView.Name = "svdrpRecordingsView";
            this.svdrpRecordingsView.RequestEnable = false;
            this.svdrpRecordingsView.Size = new System.Drawing.Size(668, 252);
            this.svdrpRecordingsView.TabIndex = 7;
            // 
            // svdrpEpgListView
            // 
            this.svdrpEpgListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.svdrpEpgListView.Location = new System.Drawing.Point(4, 340);
            this.svdrpEpgListView.Name = "svdrpEpgListView";
            this.svdrpEpgListView.RequestEnable = false;
            this.svdrpEpgListView.Size = new System.Drawing.Size(1078, 375);
            this.svdrpEpgListView.TabIndex = 8;
            // 
            // svdrpStatusInfoView
            // 
            this.svdrpStatusInfoView.Location = new System.Drawing.Point(1084, 340);
            this.svdrpStatusInfoView.Name = "svdrpStatusInfoView";
            this.svdrpStatusInfoView.RequestEnable = false;
            this.svdrpStatusInfoView.Size = new System.Drawing.Size(175, 123);
            this.svdrpStatusInfoView.TabIndex = 9;
            // 
            // SvdrpController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.svdrpStatusInfoView);
            this.Controls.Add(this.svdrpEpgListView);
            this.Controls.Add(this.svdrpRecordingsView);
            this.Controls.Add(this.svdrpTimersView);
            this.Controls.Add(this.svdrpChannelsView);
            this.Controls.Add(this.svdrpConnector);
            this.Controls.Add(this.grbBuffer);
            this.Name = "SvdrpController";
            this.Size = new System.Drawing.Size(1679, 729);
            this.Load += new System.EventHandler(this.SvdrpController_Load);
            this.grbBuffer.ResumeLayout(false);
            this.grbBuffer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmTimeOut;
        private System.Windows.Forms.TextBox mleBuffer;
        private System.Windows.Forms.Label lblBufferLength;
        private System.Windows.Forms.GroupBox grbBuffer;
        private SvdrpConnectorView svdrpConnector;
        private SvdrpChannelsView svdrpChannelsView;
        private SvdrpTimersView svdrpTimersView;
        private SvdrpRecordingsView svdrpRecordingsView;
        private SvdrpEpgView svdrpEpgListView;
        private SvdrpStatusInfoView svdrpStatusInfoView;
    }
}
