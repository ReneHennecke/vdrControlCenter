using System.Windows.Forms;

namespace vdrControlCenterUI.Controls
{
    partial class EpgGuideLine
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblChannelName = new System.Windows.Forms.Label();
            this.lblTimeLineTable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblChannelName
            // 
            this.lblChannelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChannelName.BackColor = System.Drawing.Color.White;
            this.lblChannelName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChannelName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChannelName.Location = new System.Drawing.Point(0, 0);
            this.lblChannelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(136, 32);
            this.lblChannelName.TabIndex = 0;
            this.lblChannelName.Text = "*****";
            this.lblChannelName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblTimeLineTable
            // 
            this.lblTimeLineTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeLineTable.BackColor = System.Drawing.Color.White;
            this.lblTimeLineTable.Location = new System.Drawing.Point(142, 0);
            this.lblTimeLineTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeLineTable.Name = "lblTimeLineTable";
            this.lblTimeLineTable.Size = new System.Drawing.Size(1440, 30);
            this.lblTimeLineTable.TabIndex = 1;
            // 
            // EpgGuideLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblTimeLineTable);
            this.Controls.Add(this.lblChannelName);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "EpgGuideLine";
            this.Size = new System.Drawing.Size(1583, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblChannelName;
        private Label lblTimeLineTable;
    }
}
