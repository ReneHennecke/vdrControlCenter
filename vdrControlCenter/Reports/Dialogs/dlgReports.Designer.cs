
namespace vdrControlCenterUI.Dialogs
{
    partial class dlgReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgReports));
            this.tabReport = new System.Windows.Forms.TabControl();
            this.pageParameters = new System.Windows.Forms.TabPage();
            this.pagePreview = new System.Windows.Forms.TabPage();
            this.rptViewer = new vdrControlCenterUI.Controls.ReportView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.tabReport.SuspendLayout();
            this.pagePreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabReport
            // 
            this.tabReport.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabReport.Controls.Add(this.pageParameters);
            this.tabReport.Controls.Add(this.pagePreview);
            this.tabReport.Location = new System.Drawing.Point(4, 4);
            this.tabReport.Name = "tabReport";
            this.tabReport.SelectedIndex = 0;
            this.tabReport.Size = new System.Drawing.Size(1172, 520);
            this.tabReport.TabIndex = 0;
            // 
            // pageParameters
            // 
            this.pageParameters.Location = new System.Drawing.Point(4, 4);
            this.pageParameters.Name = "pageParameters";
            this.pageParameters.Padding = new System.Windows.Forms.Padding(3);
            this.pageParameters.Size = new System.Drawing.Size(1164, 492);
            this.pageParameters.TabIndex = 0;
            this.pageParameters.Text = "Parameter";
            this.pageParameters.UseVisualStyleBackColor = true;
            // 
            // pagePreview
            // 
            this.pagePreview.Controls.Add(this.rptViewer);
            this.pagePreview.Location = new System.Drawing.Point(4, 4);
            this.pagePreview.Name = "pagePreview";
            this.pagePreview.Padding = new System.Windows.Forms.Padding(3);
            this.pagePreview.Size = new System.Drawing.Size(1164, 492);
            this.pagePreview.TabIndex = 1;
            this.pagePreview.Text = "Voransicht";
            this.pagePreview.UseVisualStyleBackColor = true;
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(3, 3);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.Size = new System.Drawing.Size(1158, 486);
            this.rptViewer.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1076, 530);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Schliessen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProgress.Location = new System.Drawing.Point(6, 530);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(128, 13);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgress.Visible = false;
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.ForeColor = System.Drawing.Color.LimeGreen;
            this.pbProgress.Location = new System.Drawing.Point(6, 546);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(128, 10);
            this.pbProgress.Step = 1;
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgress.TabIndex = 12;
            this.pbProgress.Visible = false;
            // 
            // dlgReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 560);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgReports";
            this.Text = "Ausgabe ";
            this.tabReport.ResumeLayout(false);
            this.pagePreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabReport;
        private System.Windows.Forms.TabPage pageParameters;
        private System.Windows.Forms.TabPage pagePreview;
        private System.Windows.Forms.Button btnClose;
        private Controls.ReportView rptViewer;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}