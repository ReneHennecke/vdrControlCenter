
namespace vdrControlCenterUI.Dialogs
{
    partial class dlgDebug
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
            this.teMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // teMsg
            // 
            this.teMsg.Location = new System.Drawing.Point(30, 24);
            this.teMsg.Multiline = true;
            this.teMsg.Name = "teMsg";
            this.teMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.teMsg.Size = new System.Drawing.Size(730, 390);
            this.teMsg.TabIndex = 0;
            // 
            // dlgDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.teMsg);
            this.Name = "dlgDebug";
            this.Text = "dlgDebug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox teMsg;
    }
}