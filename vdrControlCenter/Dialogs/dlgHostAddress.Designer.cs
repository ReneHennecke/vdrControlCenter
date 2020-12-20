
namespace vdrControlCenterUI.Dialogs
{
    partial class dlgHostAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgHostAddress));
            this.grbBox = new System.Windows.Forms.GroupBox();
            this.teHostAddress = new System.Windows.Forms.TextBox();
            this.lblHostAddress = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grbBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox
            // 
            this.grbBox.Controls.Add(this.teHostAddress);
            this.grbBox.Controls.Add(this.lblHostAddress);
            this.grbBox.Location = new System.Drawing.Point(6, 8);
            this.grbBox.Name = "grbBox";
            this.grbBox.Size = new System.Drawing.Size(312, 66);
            this.grbBox.TabIndex = 0;
            this.grbBox.TabStop = false;
            // 
            // teHostAddress
            // 
            this.teHostAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.teHostAddress.Location = new System.Drawing.Point(134, 26);
            this.teHostAddress.MaxLength = 15;
            this.teHostAddress.Name = "teHostAddress";
            this.teHostAddress.Size = new System.Drawing.Size(164, 23);
            this.teHostAddress.TabIndex = 8;
            this.teHostAddress.TextChanged += new System.EventHandler(this.teHostAddress_TextChanged);
            // 
            // lblHostAddress
            // 
            this.lblHostAddress.Location = new System.Drawing.Point(12, 26);
            this.lblHostAddress.Name = "lblHostAddress";
            this.lblHostAddress.Size = new System.Drawing.Size(118, 22);
            this.lblHostAddress.TabIndex = 7;
            this.lblHostAddress.Text = "Host-Adresse:";
            this.lblHostAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(222, 78);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(122, 78);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 24);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dlgHostAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 116);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grbBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgHostAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Host-Address  hinzufügen";
            this.grbBox.ResumeLayout(false);
            this.grbBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox;
        private System.Windows.Forms.TextBox teHostAddress;
        private System.Windows.Forms.Label lblHostAddress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}