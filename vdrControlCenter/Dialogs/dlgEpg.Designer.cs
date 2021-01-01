
namespace vdrControlCenterUI.Dialogs
{
    partial class dlgEpg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgEpg));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTimer = new System.Windows.Forms.Button();
            this.grbBox = new System.Windows.Forms.GroupBox();
            this.teDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblEventIdValue = new System.Windows.Forms.Label();
            this.lblEventId = new System.Windows.Forms.Label();
            this.lblVpsValue = new System.Windows.Forms.Label();
            this.lblVps = new System.Windows.Forms.Label();
            this.lblShortDescriptionValue = new System.Windows.Forms.Label();
            this.lblShortDescription = new System.Windows.Forms.Label();
            this.lblEndTimeValue = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblDurationValue = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblStartTimeValue = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblChannelNameValue = new System.Windows.Forms.Label();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.lblTitleValue = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grbBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(446, 369);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTimer
            // 
            this.btnTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimer.Location = new System.Drawing.Point(348, 369);
            this.btnTimer.Name = "btnTimer";
            this.btnTimer.Size = new System.Drawing.Size(94, 23);
            this.btnTimer.TabIndex = 3;
            this.btnTimer.Text = "Timer";
            this.btnTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimer.UseVisualStyleBackColor = true;
            this.btnTimer.Click += new System.EventHandler(this.btnTimer_Click);
            // 
            // grbBox
            // 
            this.grbBox.Controls.Add(this.teDescription);
            this.grbBox.Controls.Add(this.lblDescription);
            this.grbBox.Controls.Add(this.lblEventIdValue);
            this.grbBox.Controls.Add(this.lblEventId);
            this.grbBox.Controls.Add(this.lblVpsValue);
            this.grbBox.Controls.Add(this.lblVps);
            this.grbBox.Controls.Add(this.lblShortDescriptionValue);
            this.grbBox.Controls.Add(this.lblShortDescription);
            this.grbBox.Controls.Add(this.lblEndTimeValue);
            this.grbBox.Controls.Add(this.lblEndTime);
            this.grbBox.Controls.Add(this.lblDurationValue);
            this.grbBox.Controls.Add(this.lblDuration);
            this.grbBox.Controls.Add(this.lblStartTimeValue);
            this.grbBox.Controls.Add(this.lblStartTime);
            this.grbBox.Controls.Add(this.lblChannelNameValue);
            this.grbBox.Controls.Add(this.lblChannelName);
            this.grbBox.Controls.Add(this.lblTitleValue);
            this.grbBox.Controls.Add(this.lblTitle);
            this.grbBox.Location = new System.Drawing.Point(8, 8);
            this.grbBox.Name = "grbBox";
            this.grbBox.Size = new System.Drawing.Size(532, 354);
            this.grbBox.TabIndex = 5;
            this.grbBox.TabStop = false;
            // 
            // teDescription
            // 
            this.teDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.teDescription.Location = new System.Drawing.Point(134, 218);
            this.teDescription.Multiline = true;
            this.teDescription.Name = "teDescription";
            this.teDescription.ReadOnly = true;
            this.teDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.teDescription.Size = new System.Drawing.Size(378, 120);
            this.teDescription.TabIndex = 18;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(14, 218);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(116, 20);
            this.lblDescription.TabIndex = 17;
            this.lblDescription.Text = "Beschreibung:";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEventIdValue
            // 
            this.lblEventIdValue.Location = new System.Drawing.Point(134, 194);
            this.lblEventIdValue.Name = "lblEventIdValue";
            this.lblEventIdValue.Size = new System.Drawing.Size(74, 20);
            this.lblEventIdValue.TabIndex = 16;
            this.lblEventIdValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEventId
            // 
            this.lblEventId.Location = new System.Drawing.Point(14, 194);
            this.lblEventId.Name = "lblEventId";
            this.lblEventId.Size = new System.Drawing.Size(116, 20);
            this.lblEventId.TabIndex = 15;
            this.lblEventId.Text = "Event-ID:";
            this.lblEventId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVpsValue
            // 
            this.lblVpsValue.Location = new System.Drawing.Point(134, 170);
            this.lblVpsValue.Name = "lblVpsValue";
            this.lblVpsValue.Size = new System.Drawing.Size(152, 20);
            this.lblVpsValue.TabIndex = 14;
            this.lblVpsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVps
            // 
            this.lblVps.Location = new System.Drawing.Point(14, 170);
            this.lblVps.Name = "lblVps";
            this.lblVps.Size = new System.Drawing.Size(116, 20);
            this.lblVps.TabIndex = 13;
            this.lblVps.Text = "VPS:";
            this.lblVps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblShortDescriptionValue
            // 
            this.lblShortDescriptionValue.Location = new System.Drawing.Point(134, 146);
            this.lblShortDescriptionValue.Name = "lblShortDescriptionValue";
            this.lblShortDescriptionValue.Size = new System.Drawing.Size(378, 20);
            this.lblShortDescriptionValue.TabIndex = 12;
            this.lblShortDescriptionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShortDescription
            // 
            this.lblShortDescription.Location = new System.Drawing.Point(14, 146);
            this.lblShortDescription.Name = "lblShortDescription";
            this.lblShortDescription.Size = new System.Drawing.Size(116, 20);
            this.lblShortDescription.TabIndex = 11;
            this.lblShortDescription.Text = "Kurzbeschreibung:";
            this.lblShortDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEndTimeValue
            // 
            this.lblEndTimeValue.Location = new System.Drawing.Point(134, 122);
            this.lblEndTimeValue.Name = "lblEndTimeValue";
            this.lblEndTimeValue.Size = new System.Drawing.Size(152, 20);
            this.lblEndTimeValue.TabIndex = 10;
            this.lblEndTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndTime
            // 
            this.lblEndTime.Location = new System.Drawing.Point(14, 122);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(116, 20);
            this.lblEndTime.TabIndex = 9;
            this.lblEndTime.Text = "Ende:";
            this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDurationValue
            // 
            this.lblDurationValue.Location = new System.Drawing.Point(134, 98);
            this.lblDurationValue.Name = "lblDurationValue";
            this.lblDurationValue.Size = new System.Drawing.Size(62, 20);
            this.lblDurationValue.TabIndex = 8;
            this.lblDurationValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDuration
            // 
            this.lblDuration.Location = new System.Drawing.Point(14, 98);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(116, 20);
            this.lblDuration.TabIndex = 7;
            this.lblDuration.Text = "Dauer [min]:";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStartTimeValue
            // 
            this.lblStartTimeValue.Location = new System.Drawing.Point(134, 74);
            this.lblStartTimeValue.Name = "lblStartTimeValue";
            this.lblStartTimeValue.Size = new System.Drawing.Size(152, 20);
            this.lblStartTimeValue.TabIndex = 6;
            this.lblStartTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Location = new System.Drawing.Point(14, 74);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(116, 20);
            this.lblStartTime.TabIndex = 5;
            this.lblStartTime.Text = "Start:";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblChannelNameValue
            // 
            this.lblChannelNameValue.Location = new System.Drawing.Point(134, 50);
            this.lblChannelNameValue.Name = "lblChannelNameValue";
            this.lblChannelNameValue.Size = new System.Drawing.Size(378, 20);
            this.lblChannelNameValue.TabIndex = 4;
            this.lblChannelNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChannelName
            // 
            this.lblChannelName.Location = new System.Drawing.Point(14, 50);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(116, 20);
            this.lblChannelName.TabIndex = 3;
            this.lblChannelName.Text = "Kanal:";
            this.lblChannelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitleValue
            // 
            this.lblTitleValue.Location = new System.Drawing.Point(134, 26);
            this.lblTitleValue.Name = "lblTitleValue";
            this.lblTitleValue.Size = new System.Drawing.Size(378, 20);
            this.lblTitleValue.TabIndex = 2;
            this.lblTitleValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(14, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(116, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Titel:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dlgEpg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 404);
            this.Controls.Add(this.grbBox);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgEpg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EPG-Daten";
            this.grbBox.ResumeLayout(false);
            this.grbBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTimer;
        private System.Windows.Forms.GroupBox grbBox;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTitleValue;
        private System.Windows.Forms.TextBox teDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblEventIdValue;
        private System.Windows.Forms.Label lblEventId;
        private System.Windows.Forms.Label lblVpsValue;
        private System.Windows.Forms.Label lblVps;
        private System.Windows.Forms.Label lblShortDescriptionValue;
        private System.Windows.Forms.Label lblShortDescription;
        private System.Windows.Forms.Label lblEndTimeValue;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblDurationValue;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblStartTimeValue;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblChannelNameValue;
        private System.Windows.Forms.Label lblChannelName;
    }
}