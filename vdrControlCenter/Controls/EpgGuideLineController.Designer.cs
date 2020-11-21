using System.Windows.Forms;

namespace vdrControlCenterUI.Controls
{
    partial class EpgGuideLineController : UserControl
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
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.panTimeLineControls = new vdrControlCenterUI.Controls.EpgGuideLinePanel();
            this.chbIgnorePast = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.BackColor = System.Drawing.Color.White;
            this.lblCurrentDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentDate.Location = new System.Drawing.Point(214, 5);
            this.lblCurrentDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(160, 23);
            this.lblCurrentDate.TabIndex = 3;
            this.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(446, 4);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(121, 27);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Suchen";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNext.Location = new System.Drawing.Point(376, 4);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(70, 27);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "u";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrevious.Location = new System.Drawing.Point(142, 2);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(70, 27);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "t";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUp.Location = new System.Drawing.Point(72, 2);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(70, 27);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "q";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDown.Location = new System.Drawing.Point(2, 2);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(70, 27);
            this.btnDown.TabIndex = 0;
            this.btnDown.Text = "p";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // panTimeLineControls
            // 
            this.panTimeLineControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTimeLineControls.Location = new System.Drawing.Point(5, 32);
            this.panTimeLineControls.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panTimeLineControls.Name = "panTimeLineControls";
            this.panTimeLineControls.Size = new System.Drawing.Size(1607, 644);
            this.panTimeLineControls.TabIndex = 6;
            this.panTimeLineControls.SizeChanged += new System.EventHandler(this.panTimeLineControls_SizeChanged);
            // 
            // chbIgnorePast
            // 
            this.chbIgnorePast.Location = new System.Drawing.Point(586, 6);
            this.chbIgnorePast.Name = "chbIgnorePast";
            this.chbIgnorePast.Size = new System.Drawing.Size(228, 24);
            this.chbIgnorePast.TabIndex = 8;
            this.chbIgnorePast.Text = "Vergangene Einträge nicht anzeigen";
            this.chbIgnorePast.UseVisualStyleBackColor = true;
            this.chbIgnorePast.CheckedChanged += new System.EventHandler(this.chbIgnorePast_CheckedChanged);
            // 
            // EpgGuideLineController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbIgnorePast);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.panTimeLineControls);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lblCurrentDate);
            this.Controls.Add(this.btnDown);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "EpgGuideLineController";
            this.Size = new System.Drawing.Size(1617, 681);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnDown;
        private Label lblCurrentDate;
        private Button btnUp;
        private Button btnPrevious;
        private Button btnNext;
        private Controls.EpgGuideLinePanel panTimeLineControls;
        private Button btnFind;
        private CheckBox chbIgnorePast;
    }
}
