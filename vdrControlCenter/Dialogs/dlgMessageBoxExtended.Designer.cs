namespace vdrControlCenterUI.Dialogs
{
    partial class dlgMessageBoxExtended
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgMessageBoxExtended));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tmTimer = new System.Windows.Forms.Timer(this.components);
            this.mleMessage = new System.Windows.Forms.TextBox();
            this.btnOKOnly = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(150, 110);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(230, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tmTimer
            // 
            this.tmTimer.Interval = 1000;
            this.tmTimer.Tick += new System.EventHandler(this.tmTimout_Tick);
            // 
            // mleMessage
            // 
            this.mleMessage.Location = new System.Drawing.Point(8, 10);
            this.mleMessage.Multiline = true;
            this.mleMessage.Name = "mleMessage";
            this.mleMessage.ReadOnly = true;
            this.mleMessage.Size = new System.Drawing.Size(298, 94);
            this.mleMessage.TabIndex = 2;
            // 
            // btnOKOnly
            // 
            this.btnOKOnly.Location = new System.Drawing.Point(118, 110);
            this.btnOKOnly.Name = "btnOKOnly";
            this.btnOKOnly.Size = new System.Drawing.Size(75, 23);
            this.btnOKOnly.TabIndex = 3;
            this.btnOKOnly.Text = "OK";
            this.btnOKOnly.UseVisualStyleBackColor = true;
            this.btnOKOnly.Click += new System.EventHandler(this.btnOKOnly_Click);
            // 
            // dlgMessageBoxExtended
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 143);
            this.Controls.Add(this.btnOKOnly);
            this.Controls.Add(this.mleMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgMessageBoxExtended";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.dlgMessageBoxExtended_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer tmTimer;
        private System.Windows.Forms.TextBox mleMessage;
        private System.Windows.Forms.Button btnOKOnly;
    }
}