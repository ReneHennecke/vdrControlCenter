
namespace vdrControlCenterUI.Controls
{
    partial class MediaView
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
            this.videoViewer = new LibVLCSharp.WinForms.VideoView();
            this.panController = new System.Windows.Forms.Panel();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblMedia = new System.Windows.Forms.Label();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnForwardChapter = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnPlayStop = new System.Windows.Forms.Button();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnBackwardChanpter = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.videoViewer)).BeginInit();
            this.panController.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoViewer
            // 
            this.videoViewer.BackColor = System.Drawing.Color.Black;
            this.videoViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.videoViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoViewer.Location = new System.Drawing.Point(0, 0);
            this.videoViewer.MediaPlayer = null;
            this.videoViewer.Name = "videoViewer";
            this.videoViewer.Size = new System.Drawing.Size(823, 468);
            this.videoViewer.TabIndex = 0;
            this.videoViewer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.videoViewer_KeyDown);
            this.videoViewer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.videoViewer_KeyPress);
            this.videoViewer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.videoViewer_KeyUp);
            this.videoViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.videoViewer_MouseClick);
            // 
            // panController
            // 
            this.panController.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panController.Controls.Add(this.lblLength);
            this.panController.Controls.Add(this.lblEndTime);
            this.panController.Controls.Add(this.lblStartTime);
            this.panController.Controls.Add(this.lblAction);
            this.panController.Controls.Add(this.lblMedia);
            this.panController.Controls.Add(this.btnMute);
            this.panController.Controls.Add(this.btnForwardChapter);
            this.panController.Controls.Add(this.btnForward);
            this.panController.Controls.Add(this.btnPlayStop);
            this.panController.Controls.Add(this.btnBackward);
            this.panController.Controls.Add(this.btnBackwardChanpter);
            this.panController.Controls.Add(this.btnClose);
            this.panController.Location = new System.Drawing.Point(0, 0);
            this.panController.Name = "panController";
            this.panController.Size = new System.Drawing.Size(824, 92);
            this.panController.TabIndex = 1;
            this.panController.Visible = false;
            // 
            // lblLength
            // 
            this.lblLength.BackColor = System.Drawing.Color.Black;
            this.lblLength.Font = new System.Drawing.Font("DS-Digital", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLength.ForeColor = System.Drawing.Color.Gold;
            this.lblLength.Location = new System.Drawing.Point(262, 58);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(52, 18);
            this.lblLength.TabIndex = 11;
            this.lblLength.Text = "0";
            this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEndTime
            // 
            this.lblEndTime.BackColor = System.Drawing.Color.Black;
            this.lblEndTime.Font = new System.Drawing.Font("DS-Digital", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEndTime.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblEndTime.Location = new System.Drawing.Point(422, 38);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(52, 18);
            this.lblEndTime.TabIndex = 10;
            this.lblEndTime.Text = "00:00:00";
            this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStartTime
            // 
            this.lblStartTime.BackColor = System.Drawing.Color.Black;
            this.lblStartTime.Font = new System.Drawing.Font("DS-Digital", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStartTime.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblStartTime.Location = new System.Drawing.Point(366, 38);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(52, 18);
            this.lblStartTime.TabIndex = 9;
            this.lblStartTime.Text = "00:00:00";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAction
            // 
            this.lblAction.BackColor = System.Drawing.Color.Black;
            this.lblAction.Font = new System.Drawing.Font("DS-Digital", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAction.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblAction.Location = new System.Drawing.Point(262, 38);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(100, 18);
            this.lblAction.TabIndex = 8;
            this.lblAction.Text = "label1";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMedia
            // 
            this.lblMedia.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMedia.Location = new System.Drawing.Point(42, 6);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(776, 23);
            this.lblMedia.TabIndex = 7;
            this.lblMedia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMute
            // 
            this.btnMute.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMute.Font = new System.Drawing.Font("font bottons music", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMute.ForeColor = System.Drawing.Color.Black;
            this.btnMute.Location = new System.Drawing.Point(194, 34);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(36, 28);
            this.btnMute.TabIndex = 6;
            this.btnMute.Text = "Q";
            this.btnMute.UseVisualStyleBackColor = true;
            // 
            // btnForwardChapter
            // 
            this.btnForwardChapter.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnForwardChapter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForwardChapter.Font = new System.Drawing.Font("font bottons music", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnForwardChapter.ForeColor = System.Drawing.Color.Black;
            this.btnForwardChapter.Location = new System.Drawing.Point(156, 34);
            this.btnForwardChapter.Name = "btnForwardChapter";
            this.btnForwardChapter.Size = new System.Drawing.Size(36, 28);
            this.btnForwardChapter.TabIndex = 5;
            this.btnForwardChapter.Text = "E";
            this.btnForwardChapter.UseVisualStyleBackColor = true;
            // 
            // btnForward
            // 
            this.btnForward.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Font = new System.Drawing.Font("font bottons music", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnForward.ForeColor = System.Drawing.Color.Black;
            this.btnForward.Location = new System.Drawing.Point(118, 34);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(36, 28);
            this.btnForward.TabIndex = 4;
            this.btnForward.Text = "C";
            this.btnForward.UseVisualStyleBackColor = true;
            // 
            // btnPlayStop
            // 
            this.btnPlayStop.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPlayStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayStop.Font = new System.Drawing.Font("font bottons music", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPlayStop.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPlayStop.Location = new System.Drawing.Point(80, 34);
            this.btnPlayStop.Name = "btnPlayStop";
            this.btnPlayStop.Size = new System.Drawing.Size(36, 28);
            this.btnPlayStop.TabIndex = 3;
            this.btnPlayStop.Text = "A";
            this.btnPlayStop.UseVisualStyleBackColor = true;
            // 
            // btnBackward
            // 
            this.btnBackward.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackward.Font = new System.Drawing.Font("font bottons music", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBackward.ForeColor = System.Drawing.Color.Black;
            this.btnBackward.Location = new System.Drawing.Point(42, 34);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(36, 28);
            this.btnBackward.TabIndex = 2;
            this.btnBackward.Text = "D";
            this.btnBackward.UseVisualStyleBackColor = true;
            // 
            // btnBackwardChanpter
            // 
            this.btnBackwardChanpter.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnBackwardChanpter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackwardChanpter.Font = new System.Drawing.Font("font bottons music", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBackwardChanpter.ForeColor = System.Drawing.Color.Black;
            this.btnBackwardChanpter.Location = new System.Drawing.Point(4, 34);
            this.btnBackwardChanpter.Name = "btnBackwardChanpter";
            this.btnBackwardChanpter.Size = new System.Drawing.Size(36, 28);
            this.btnBackwardChanpter.TabIndex = 1;
            this.btnBackwardChanpter.Text = "F";
            this.btnBackwardChanpter.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("font bottons music", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "T";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MediaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panController);
            this.Controls.Add(this.videoViewer);
            this.Name = "MediaView";
            this.Size = new System.Drawing.Size(823, 468);
            ((System.ComponentModel.ISupportInitialize)(this.videoViewer)).EndInit();
            this.panController.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoViewer;
        private System.Windows.Forms.Panel panController;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBackwardChanpter;
        private System.Windows.Forms.Label lblMedia;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnForwardChapter;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnPlayStop;
        private System.Windows.Forms.Button btnBackward;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblLength;
    }
}
