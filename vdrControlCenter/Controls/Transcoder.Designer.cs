namespace vdrControlCenterUI.Controls
{
    partial class Transcoder
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
            this.grbTranscode = new System.Windows.Forms.GroupBox();
            this.lblFrameValue = new System.Windows.Forms.Label();
            this.lblFrame = new System.Windows.Forms.Label();
            this.lblProcessedDurationValue = new System.Windows.Forms.Label();
            this.lblTotalDurationValue = new System.Windows.Forms.Label();
            this.lblSizeValue = new System.Windows.Forms.Label();
            this.lblFpsValue = new System.Windows.Forms.Label();
            this.lblBitrateValue = new System.Windows.Forms.Label();
            this.lblOutputValue = new System.Windows.Forms.Label();
            this.lblInputValue = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblProcessedDuration = new System.Windows.Forms.Label();
            this.lblTotalDuration = new System.Windows.Forms.Label();
            this.lblFps = new System.Windows.Forms.Label();
            this.lblBitrate = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.livInput = new System.Windows.Forms.ListView();
            this.colFileName = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colTimestamp = new System.Windows.Forms.ColumnHeader();
            this.btnTranscode = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.grbTranscode.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbTranscode
            // 
            this.grbTranscode.Controls.Add(this.lblFrameValue);
            this.grbTranscode.Controls.Add(this.lblFrame);
            this.grbTranscode.Controls.Add(this.lblProcessedDurationValue);
            this.grbTranscode.Controls.Add(this.lblTotalDurationValue);
            this.grbTranscode.Controls.Add(this.lblSizeValue);
            this.grbTranscode.Controls.Add(this.lblFpsValue);
            this.grbTranscode.Controls.Add(this.lblBitrateValue);
            this.grbTranscode.Controls.Add(this.lblOutputValue);
            this.grbTranscode.Controls.Add(this.lblInputValue);
            this.grbTranscode.Controls.Add(this.lblSize);
            this.grbTranscode.Controls.Add(this.lblProcessedDuration);
            this.grbTranscode.Controls.Add(this.lblTotalDuration);
            this.grbTranscode.Controls.Add(this.lblFps);
            this.grbTranscode.Controls.Add(this.lblBitrate);
            this.grbTranscode.Controls.Add(this.lblOutput);
            this.grbTranscode.Controls.Add(this.lblInput);
            this.grbTranscode.Location = new System.Drawing.Point(28, 229);
            this.grbTranscode.Name = "grbTranscode";
            this.grbTranscode.Size = new System.Drawing.Size(578, 259);
            this.grbTranscode.TabIndex = 0;
            this.grbTranscode.TabStop = false;
            this.grbTranscode.Text = "Transcode";
            // 
            // lblFrameValue
            // 
            this.lblFrameValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFrameValue.Location = new System.Drawing.Point(123, 169);
            this.lblFrameValue.Name = "lblFrameValue";
            this.lblFrameValue.Size = new System.Drawing.Size(126, 17);
            this.lblFrameValue.TabIndex = 9;
            this.lblFrameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFrame
            // 
            this.lblFrame.Location = new System.Drawing.Point(17, 169);
            this.lblFrame.Name = "lblFrame";
            this.lblFrame.Size = new System.Drawing.Size(100, 17);
            this.lblFrame.TabIndex = 8;
            this.lblFrame.Text = "Frame:";
            this.lblFrame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProcessedDurationValue
            // 
            this.lblProcessedDurationValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblProcessedDurationValue.Location = new System.Drawing.Point(123, 223);
            this.lblProcessedDurationValue.Name = "lblProcessedDurationValue";
            this.lblProcessedDurationValue.Size = new System.Drawing.Size(126, 17);
            this.lblProcessedDurationValue.TabIndex = 6;
            this.lblProcessedDurationValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalDurationValue
            // 
            this.lblTotalDurationValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTotalDurationValue.Location = new System.Drawing.Point(123, 197);
            this.lblTotalDurationValue.Name = "lblTotalDurationValue";
            this.lblTotalDurationValue.Size = new System.Drawing.Size(126, 17);
            this.lblTotalDurationValue.TabIndex = 7;
            this.lblTotalDurationValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSizeValue
            // 
            this.lblSizeValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSizeValue.Location = new System.Drawing.Point(123, 142);
            this.lblSizeValue.Name = "lblSizeValue";
            this.lblSizeValue.Size = new System.Drawing.Size(126, 17);
            this.lblSizeValue.TabIndex = 6;
            this.lblSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFpsValue
            // 
            this.lblFpsValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFpsValue.Location = new System.Drawing.Point(123, 113);
            this.lblFpsValue.Name = "lblFpsValue";
            this.lblFpsValue.Size = new System.Drawing.Size(126, 17);
            this.lblFpsValue.TabIndex = 6;
            this.lblFpsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBitrateValue
            // 
            this.lblBitrateValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblBitrateValue.Location = new System.Drawing.Point(123, 85);
            this.lblBitrateValue.Name = "lblBitrateValue";
            this.lblBitrateValue.Size = new System.Drawing.Size(126, 17);
            this.lblBitrateValue.TabIndex = 5;
            this.lblBitrateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOutputValue
            // 
            this.lblOutputValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutputValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblOutputValue.Location = new System.Drawing.Point(123, 56);
            this.lblOutputValue.Name = "lblOutputValue";
            this.lblOutputValue.Size = new System.Drawing.Size(439, 17);
            this.lblOutputValue.TabIndex = 5;
            this.lblOutputValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInputValue
            // 
            this.lblInputValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInputValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblInputValue.Location = new System.Drawing.Point(123, 30);
            this.lblInputValue.Name = "lblInputValue";
            this.lblInputValue.Size = new System.Drawing.Size(439, 17);
            this.lblInputValue.TabIndex = 4;
            this.lblInputValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSize
            // 
            this.lblSize.Location = new System.Drawing.Point(17, 142);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(100, 17);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "Größe:";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProcessedDuration
            // 
            this.lblProcessedDuration.Location = new System.Drawing.Point(17, 223);
            this.lblProcessedDuration.Name = "lblProcessedDuration";
            this.lblProcessedDuration.Size = new System.Drawing.Size(100, 17);
            this.lblProcessedDuration.TabIndex = 1;
            this.lblProcessedDuration.Text = "Verarbeitet:";
            this.lblProcessedDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDuration
            // 
            this.lblTotalDuration.Location = new System.Drawing.Point(17, 197);
            this.lblTotalDuration.Name = "lblTotalDuration";
            this.lblTotalDuration.Size = new System.Drawing.Size(100, 17);
            this.lblTotalDuration.TabIndex = 1;
            this.lblTotalDuration.Text = "Total:";
            this.lblTotalDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFps
            // 
            this.lblFps.Location = new System.Drawing.Point(17, 113);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(100, 17);
            this.lblFps.TabIndex = 2;
            this.lblFps.Text = "FPS:";
            this.lblFps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBitrate
            // 
            this.lblBitrate.Location = new System.Drawing.Point(17, 85);
            this.lblBitrate.Name = "lblBitrate";
            this.lblBitrate.Size = new System.Drawing.Size(100, 17);
            this.lblBitrate.TabIndex = 1;
            this.lblBitrate.Text = "Bitrate:";
            this.lblBitrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOutput
            // 
            this.lblOutput.Location = new System.Drawing.Point(17, 56);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(100, 17);
            this.lblOutput.TabIndex = 1;
            this.lblOutput.Text = "Ziel:";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInput
            // 
            this.lblInput.Location = new System.Drawing.Point(17, 30);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(100, 17);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Quelle:";
            this.lblInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // livInput
            // 
            this.livInput.CheckBoxes = true;
            this.livInput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colSize,
            this.colTimestamp});
            this.livInput.GridLines = true;
            this.livInput.Location = new System.Drawing.Point(28, 43);
            this.livInput.Name = "livInput";
            this.livInput.Size = new System.Drawing.Size(578, 144);
            this.livInput.TabIndex = 1;
            this.livInput.UseCompatibleStateImageBehavior = false;
            this.livInput.View = System.Windows.Forms.View.Details;
            // 
            // colFileName
            // 
            this.colFileName.Text = "Datei";
            this.colFileName.Width = 300;
            // 
            // colSize
            // 
            this.colSize.Text = "Größe";
            this.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSize.Width = 100;
            // 
            // colTimestamp
            // 
            this.colTimestamp.Text = "Datum";
            this.colTimestamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTimestamp.Width = 150;
            // 
            // btnTranscode
            // 
            this.btnTranscode.Location = new System.Drawing.Point(498, 195);
            this.btnTranscode.Name = "btnTranscode";
            this.btnTranscode.Size = new System.Drawing.Size(108, 28);
            this.btnTranscode.TabIndex = 2;
            this.btnTranscode.Text = "Transcode";
            this.btnTranscode.UseVisualStyleBackColor = true;
            this.btnTranscode.Click += new System.EventHandler(this.btnTranscode_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(384, 195);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(108, 28);
            this.btnInput.TabIndex = 3;
            this.btnInput.Text = "Datei(en) holen";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // Transcoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnTranscode);
            this.Controls.Add(this.livInput);
            this.Controls.Add(this.grbTranscode);
            this.Name = "Transcoder";
            this.Size = new System.Drawing.Size(940, 625);
            this.grbTranscode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grbTranscode;
        private Label lblProcessedDuration;
        private Label lblTotalDuration;
        private Label lblFps;
        private Label lblBitrate;
        private Label lblOutput;
        private Label lblInput;
        private Label lblProcessedDurationValue;
        private Label lblTotalDurationValue;
        private Label lblSizeValue;
        private Label lblFpsValue;
        private Label lblBitrateValue;
        private Label lblOutputValue;
        private Label lblInputValue;
        private Label lblSize;
        private ListView livInput;
        private ColumnHeader colFileName;
        private Button btnTranscode;
        private Button btnInput;
        private ColumnHeader colSize;
        private ColumnHeader colTimestamp;
        private Label lblFrameValue;
        private Label lblFrame;
    }
}
