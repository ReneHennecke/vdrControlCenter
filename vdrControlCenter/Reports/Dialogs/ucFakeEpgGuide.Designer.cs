
namespace vdrControlCenterUI.Reports.Dialogs
{
    partial class ucFakeEpgGuide
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
            this.grbParameters = new System.Windows.Forms.GroupBox();
            this.chbHideDescription = new System.Windows.Forms.CheckBox();
            this.lblHideDescription = new System.Windows.Forms.Label();
            this.chbHideShortDescription = new System.Windows.Forms.CheckBox();
            this.lblHideShortDescription = new System.Windows.Forms.Label();
            this.dtpEnde = new System.Windows.Forms.DateTimePicker();
            this.lblEnde = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblFavouritesOnly = new System.Windows.Forms.Label();
            this.chbFavouritesOnly = new System.Windows.Forms.CheckBox();
            this.grbParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbParameters
            // 
            this.grbParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbParameters.Controls.Add(this.chbFavouritesOnly);
            this.grbParameters.Controls.Add(this.lblFavouritesOnly);
            this.grbParameters.Controls.Add(this.chbHideDescription);
            this.grbParameters.Controls.Add(this.lblHideDescription);
            this.grbParameters.Controls.Add(this.chbHideShortDescription);
            this.grbParameters.Controls.Add(this.lblHideShortDescription);
            this.grbParameters.Controls.Add(this.dtpEnde);
            this.grbParameters.Controls.Add(this.lblEnde);
            this.grbParameters.Controls.Add(this.dtpStart);
            this.grbParameters.Controls.Add(this.lblStart);
            this.grbParameters.Location = new System.Drawing.Point(4, 6);
            this.grbParameters.Name = "grbParameters";
            this.grbParameters.Size = new System.Drawing.Size(406, 174);
            this.grbParameters.TabIndex = 0;
            this.grbParameters.TabStop = false;
            this.grbParameters.Text = "Parameter";
            // 
            // chbHideDescription
            // 
            this.chbHideDescription.AutoSize = true;
            this.chbHideDescription.Checked = true;
            this.chbHideDescription.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHideDescription.Location = new System.Drawing.Point(188, 114);
            this.chbHideDescription.Name = "chbHideDescription";
            this.chbHideDescription.Size = new System.Drawing.Size(15, 14);
            this.chbHideDescription.TabIndex = 7;
            this.chbHideDescription.UseVisualStyleBackColor = true;
            // 
            // lblHideDescription
            // 
            this.lblHideDescription.Location = new System.Drawing.Point(16, 110);
            this.lblHideDescription.Name = "lblHideDescription";
            this.lblHideDescription.Size = new System.Drawing.Size(166, 22);
            this.lblHideDescription.TabIndex = 6;
            this.lblHideDescription.Text = "Beschreibung verbergen:";
            this.lblHideDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbHideShortDescription
            // 
            this.chbHideShortDescription.AutoSize = true;
            this.chbHideShortDescription.Checked = true;
            this.chbHideShortDescription.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHideShortDescription.Location = new System.Drawing.Point(188, 90);
            this.chbHideShortDescription.Name = "chbHideShortDescription";
            this.chbHideShortDescription.Size = new System.Drawing.Size(15, 14);
            this.chbHideShortDescription.TabIndex = 5;
            this.chbHideShortDescription.UseVisualStyleBackColor = true;
            // 
            // lblHideShortDescription
            // 
            this.lblHideShortDescription.Location = new System.Drawing.Point(16, 84);
            this.lblHideShortDescription.Name = "lblHideShortDescription";
            this.lblHideShortDescription.Size = new System.Drawing.Size(166, 22);
            this.lblHideShortDescription.TabIndex = 4;
            this.lblHideShortDescription.Text = "Kurzbeschreibung verbergen:";
            this.lblHideShortDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEnde
            // 
            this.dtpEnde.Location = new System.Drawing.Point(188, 58);
            this.dtpEnde.Name = "dtpEnde";
            this.dtpEnde.Size = new System.Drawing.Size(200, 23);
            this.dtpEnde.TabIndex = 3;
            this.dtpEnde.ValueChanged += new System.EventHandler(this.dtpEnde_ValueChanged);
            // 
            // lblEnde
            // 
            this.lblEnde.Location = new System.Drawing.Point(16, 58);
            this.lblEnde.Name = "lblEnde";
            this.lblEnde.Size = new System.Drawing.Size(166, 22);
            this.lblEnde.TabIndex = 2;
            this.lblEnde.Text = "Bis Datum:";
            this.lblEnde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(188, 32);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 23);
            this.dtpStart.TabIndex = 1;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(16, 32);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(166, 22);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Von Datum:";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFavouritesOnly
            // 
            this.lblFavouritesOnly.Location = new System.Drawing.Point(16, 136);
            this.lblFavouritesOnly.Name = "lblFavouritesOnly";
            this.lblFavouritesOnly.Size = new System.Drawing.Size(166, 22);
            this.lblFavouritesOnly.TabIndex = 8;
            this.lblFavouritesOnly.Text = "Nur Favoriten verwenden:";
            this.lblFavouritesOnly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbFavouritesOnly
            // 
            this.chbFavouritesOnly.AutoSize = true;
            this.chbFavouritesOnly.Checked = true;
            this.chbFavouritesOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbFavouritesOnly.Location = new System.Drawing.Point(188, 140);
            this.chbFavouritesOnly.Name = "chbFavouritesOnly";
            this.chbFavouritesOnly.Size = new System.Drawing.Size(15, 14);
            this.chbFavouritesOnly.TabIndex = 9;
            this.chbFavouritesOnly.UseVisualStyleBackColor = true;
            // 
            // ucFakeEpgGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbParameters);
            this.Name = "ucFakeEpgGuide";
            this.Size = new System.Drawing.Size(417, 184);
            this.grbParameters.ResumeLayout(false);
            this.grbParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbParameters;
        private System.Windows.Forms.CheckBox chbHideDescription;
        private System.Windows.Forms.Label lblHideDescription;
        private System.Windows.Forms.CheckBox chbHideShortDescription;
        private System.Windows.Forms.Label lblHideShortDescription;
        private System.Windows.Forms.DateTimePicker dtpEnde;
        private System.Windows.Forms.Label lblEnde;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.CheckBox chbFavouritesOnly;
        private System.Windows.Forms.Label lblFavouritesOnly;
    }
}
