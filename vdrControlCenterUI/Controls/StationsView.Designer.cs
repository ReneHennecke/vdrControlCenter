namespace vdrControlCenterUI.Controls
{
    partial class StationsView
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
            this.components = new System.ComponentModel.Container();
            vdrControlCenterUI.Classes.ItemDesignConfig itemDesignConfig1 = new vdrControlCenterUI.Classes.ItemDesignConfig();
            this.pcPing = new vdrControlCenterUI.Controls.PingControl();
            this.tmTimer = new System.Windows.Forms.Timer(this.components);
            this.livStations = new vdrControlCenterUI.Controls.ListViewStations();
            this.SuspendLayout();
            // 
            // pcPing
            // 
            this.pcPing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pcPing.Location = new System.Drawing.Point(4, 128);
            this.pcPing.Name = "pcPing";
            this.pcPing.Size = new System.Drawing.Size(16, 19);
            this.pcPing.TabIndex = 1;
            this.pcPing.Visible = false;
            this.pcPing.PingReply += new vdrControlCenterUI.Controls.PingControl.PingReplyEventHandler(this.pcPing_PingReply);
            // 
            // tmTimer
            // 
            this.tmTimer.Interval = 10000;
            this.tmTimer.Tick += new System.EventHandler(this.tmTimer_Tick);
            // 
            // livStations
            // 
            this.livStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.livStations.FullRowSelect = true;
            this.livStations.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.livStations.HideSelection = false;
            itemDesignConfig1.BackColor = System.Drawing.SystemColors.Window;
            itemDesignConfig1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            itemDesignConfig1.ForeColor = System.Drawing.SystemColors.WindowText;
            itemDesignConfig1.SelectedBackground1 = System.Drawing.Color.LightGray;
            itemDesignConfig1.SelectedBackground2 = System.Drawing.Color.White;
            this.livStations.ItemDesignConfig = itemDesignConfig1;
            this.livStations.Location = new System.Drawing.Point(0, 0);
            this.livStations.MultiSelect = false;
            this.livStations.Name = "livStations";
            this.livStations.OwnerDraw = true;
            this.livStations.ShowItemToolTips = true;
            this.livStations.Size = new System.Drawing.Size(150, 150);
            this.livStations.TabIndex = 2;
            this.livStations.UseCompatibleStateImageBehavior = false;
            this.livStations.View = System.Windows.Forms.View.Details;
            // 
            // StationsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.livStations);
            this.Controls.Add(this.pcPing);
            this.Name = "StationsView";
            this.ResumeLayout(false);

        }

        #endregion
        private PingControl pcPing;
        private System.Windows.Forms.Timer tmTimer;
        private ListViewStations livStations;
    }
}
