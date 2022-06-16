
namespace vdrControlCenterUI.Controls
{
    partial class MediaController
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
            this.grbInfo = new System.Windows.Forms.GroupBox();
            this.lblDisplayDuration = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.btnOpenMediaFromLocation = new System.Windows.Forms.Button();
            this.btnOpenMedia = new System.Windows.Forms.Button();
            this.tbPosition = new System.Windows.Forms.TrackBar();
            this.lblTime = new System.Windows.Forms.Label();
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
            this.btnBackwardChapter = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.videoViewer)).BeginInit();
            this.panController.SuspendLayout();
            this.grbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).BeginInit();
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
            this.videoViewer.Size = new System.Drawing.Size(958, 468);
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
            this.panController.Controls.Add(this.grbInfo);
            this.panController.Controls.Add(this.btnOpenMediaFromLocation);
            this.panController.Controls.Add(this.btnOpenMedia);
            this.panController.Controls.Add(this.tbPosition);
            this.panController.Controls.Add(this.lblTime);
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
            this.panController.Controls.Add(this.btnBackwardChapter);
            this.panController.Controls.Add(this.btnClose);
            this.panController.Location = new System.Drawing.Point(0, 0);
            this.panController.Name = "panController";
            this.panController.Size = new System.Drawing.Size(959, 132);
            this.panController.TabIndex = 1;
            this.panController.Visible = false;
            // 
            // grbInfo
            // 
            this.grbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbInfo.Controls.Add(this.lblDisplayDuration);
            this.grbInfo.Controls.Add(this.lblDuration);
            this.grbInfo.Location = new System.Drawing.Point(566, 36);
            this.grbInfo.Name = "grbInfo";
            this.grbInfo.Size = new System.Drawing.Size(385, 88);
            this.grbInfo.TabIndex = 16;
            this.grbInfo.TabStop = false;
            this.grbInfo.Text = "Medium - Info";
            // 
            // lblDisplayDuration
            // 
            this.lblDisplayDuration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblDisplayDuration.Location = new System.Drawing.Point(142, 26);
            this.lblDisplayDuration.Name = "lblDisplayDuration";
            this.lblDisplayDuration.Size = new System.Drawing.Size(170, 18);
            this.lblDisplayDuration.TabIndex = 1;
            this.lblDisplayDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDuration
            // 
            this.lblDuration.Location = new System.Drawing.Point(12, 26);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(126, 18);
            this.lblDuration.TabIndex = 0;
            this.lblDuration.Text = "Dauer  (hh:mm:ss):";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOpenMediaFromLocation
            // 
            this.btnOpenMediaFromLocation.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnOpenMediaFromLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMediaFromLocation.Font = new System.Drawing.Font("font bottons music", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpenMediaFromLocation.ForeColor = System.Drawing.Color.Black;
            this.btnOpenMediaFromLocation.Location = new System.Drawing.Point(80, 4);
            this.btnOpenMediaFromLocation.Name = "btnOpenMediaFromLocation";
            this.btnOpenMediaFromLocation.Size = new System.Drawing.Size(36, 28);
            this.btnOpenMediaFromLocation.TabIndex = 15;
            this.btnOpenMediaFromLocation.Text = "J";
            this.btnOpenMediaFromLocation.UseVisualStyleBackColor = true;
            this.btnOpenMediaFromLocation.Click += new System.EventHandler(this.btnOpenMediaFromLocation_Click);
            // 
            // btnOpenMedia
            // 
            this.btnOpenMedia.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnOpenMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMedia.Font = new System.Drawing.Font("font bottons music", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpenMedia.ForeColor = System.Drawing.Color.Black;
            this.btnOpenMedia.Location = new System.Drawing.Point(42, 4);
            this.btnOpenMedia.Name = "btnOpenMedia";
            this.btnOpenMedia.Size = new System.Drawing.Size(36, 28);
            this.btnOpenMedia.TabIndex = 14;
            this.btnOpenMedia.Text = "I";
            this.btnOpenMedia.UseVisualStyleBackColor = true;
            this.btnOpenMedia.Click += new System.EventHandler(this.btnOpenMedia_Click);
            // 
            // tbPosition
            // 
            this.tbPosition.AutoSize = false;
            this.tbPosition.Location = new System.Drawing.Point(4, 66);
            this.tbPosition.Maximum = 100;
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(226, 18);
            this.tbPosition.TabIndex = 13;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Black;
            this.lblTime.Font = new System.Drawing.Font("DS-Digital", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTime.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblTime.Location = new System.Drawing.Point(478, 38);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(52, 18);
            this.lblTime.TabIndex = 12;
            this.lblTime.Text = "00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLength
            // 
            this.lblLength.BackColor = System.Drawing.Color.Black;
            this.lblLength.Font = new System.Drawing.Font("DS-Digital", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.lblEndTime.Font = new System.Drawing.Font("DS-Digital", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.lblStartTime.Font = new System.Drawing.Font("DS-Digital", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.lblAction.Font = new System.Drawing.Font("DS-Digital", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.lblMedia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMedia.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMedia.Location = new System.Drawing.Point(118, 6);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(834, 23);
            this.lblMedia.TabIndex = 7;
            this.lblMedia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMute
            // 
            this.btnMute.Enabled = false;
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
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // btnForwardChapter
            // 
            this.btnForwardChapter.Enabled = false;
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
            this.btnForwardChapter.Click += new System.EventHandler(this.btnForwardChapter_Click);
            // 
            // btnForward
            // 
            this.btnForward.Enabled = false;
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
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnPlayStop
            // 
            this.btnPlayStop.Enabled = false;
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
            this.btnPlayStop.Click += new System.EventHandler(this.btnPlayStop_Click);
            // 
            // btnBackward
            // 
            this.btnBackward.Enabled = false;
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
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // btnBackwardChapter
            // 
            this.btnBackwardChapter.Enabled = false;
            this.btnBackwardChapter.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnBackwardChapter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackwardChapter.Font = new System.Drawing.Font("font bottons music", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBackwardChapter.ForeColor = System.Drawing.Color.Black;
            this.btnBackwardChapter.Location = new System.Drawing.Point(4, 34);
            this.btnBackwardChapter.Name = "btnBackwardChapter";
            this.btnBackwardChapter.Size = new System.Drawing.Size(36, 28);
            this.btnBackwardChapter.TabIndex = 1;
            this.btnBackwardChapter.Text = "F";
            this.btnBackwardChapter.UseVisualStyleBackColor = true;
            this.btnBackwardChapter.Click += new System.EventHandler(this.btnBackwardChapter_Click);
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
            this.Size = new System.Drawing.Size(958, 468);
            ((System.ComponentModel.ISupportInitialize)(this.videoViewer)).EndInit();
            this.panController.ResumeLayout(false);
            this.grbInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoViewer;
        private System.Windows.Forms.Panel panController;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBackwardChapter;
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
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TrackBar tbPosition;
        private System.Windows.Forms.Button btnOpenMedia;
        private System.Windows.Forms.Button btnOpenMediaFromLocation;
        private System.Windows.Forms.GroupBox grbInfo;
        private System.Windows.Forms.Label lblDisplayDuration;
        private System.Windows.Forms.Label lblDuration;
    }
}
