namespace vdrControlCenterUI.Controls
{
    partial class SvdrpStatusInfoView
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
            this.panBox = new System.Windows.Forms.Panel();
            this.btnRequest = new System.Windows.Forms.Button();
            this.lblRequestInfo = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblPercentValue = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblFreeValue = new System.Windows.Forms.Label();
            this.lblFree = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBox
            // 
            this.panBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBox.Controls.Add(this.btnRequest);
            this.panBox.Controls.Add(this.lblRequestInfo);
            this.panBox.Controls.Add(this.lblGreen);
            this.panBox.Controls.Add(this.lblRed);
            this.panBox.Controls.Add(this.lblPercentValue);
            this.panBox.Controls.Add(this.lblPercent);
            this.panBox.Controls.Add(this.lblFreeValue);
            this.panBox.Controls.Add(this.lblFree);
            this.panBox.Controls.Add(this.lblTotalValue);
            this.panBox.Controls.Add(this.lblTotal);
            this.panBox.Location = new System.Drawing.Point(2, 2);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(170, 118);
            this.panBox.TabIndex = 0;
            // 
            // btnRequest
            // 
            this.btnRequest.Enabled = false;
            this.btnRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRequest.Location = new System.Drawing.Point(89, 89);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 3;
            this.btnRequest.Text = "Abfrage";
            this.btnRequest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // lblRequestInfo
            // 
            this.lblRequestInfo.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRequestInfo.Location = new System.Drawing.Point(4, 94);
            this.lblRequestInfo.Name = "lblRequestInfo";
            this.lblRequestInfo.Size = new System.Drawing.Size(78, 16);
            this.lblRequestInfo.TabIndex = 1;
            this.lblRequestInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGreen
            // 
            this.lblGreen.BackColor = System.Drawing.Color.Lime;
            this.lblGreen.Location = new System.Drawing.Point(84, 70);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(80, 12);
            this.lblGreen.TabIndex = 1;
            this.lblGreen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRed
            // 
            this.lblRed.BackColor = System.Drawing.Color.Red;
            this.lblRed.Location = new System.Drawing.Point(84, 70);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(80, 12);
            this.lblRed.TabIndex = 1;
            this.lblRed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPercentValue
            // 
            this.lblPercentValue.Location = new System.Drawing.Point(86, 48);
            this.lblPercentValue.Name = "lblPercentValue";
            this.lblPercentValue.Size = new System.Drawing.Size(78, 20);
            this.lblPercentValue.TabIndex = 1;
            this.lblPercentValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPercent
            // 
            this.lblPercent.Location = new System.Drawing.Point(4, 48);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(78, 20);
            this.lblPercent.TabIndex = 1;
            this.lblPercent.Text = "Belegt:";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFreeValue
            // 
            this.lblFreeValue.Location = new System.Drawing.Point(86, 26);
            this.lblFreeValue.Name = "lblFreeValue";
            this.lblFreeValue.Size = new System.Drawing.Size(78, 20);
            this.lblFreeValue.TabIndex = 1;
            this.lblFreeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFree
            // 
            this.lblFree.Location = new System.Drawing.Point(4, 26);
            this.lblFree.Name = "lblFree";
            this.lblFree.Size = new System.Drawing.Size(78, 20);
            this.lblFree.TabIndex = 1;
            this.lblFree.Text = "Frei:";
            this.lblFree.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Location = new System.Drawing.Point(86, 4);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(78, 20);
            this.lblTotalValue.TabIndex = 1;
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(3, 3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(78, 20);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Gesamt:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StatusInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panBox);
            this.Name = "StatusInfoView";
            this.Size = new System.Drawing.Size(175, 123);
            this.panBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblPercentValue;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblFreeValue;
        private System.Windows.Forms.Label lblFree;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Label lblRequestInfo;
    }
}
