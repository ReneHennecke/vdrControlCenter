using System.Windows.Forms;

namespace vdrControlCenterUI.Controls
{
    partial class EpgGuideClock : UserControl
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
            this.components = new System.ComponentModel.Container();
            this.tmClock = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmClock
            // 
            this.tmClock.Interval = 60000;
            this.tmClock.Tick += new System.EventHandler(this.tmClock_Tick);
            // 
            // EpgGuideClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "EpgGuideClock";
            this.Size = new System.Drawing.Size(1036, 56);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmClock;
    }
}
