
namespace vdrControlCenterUI.Controls
{
    partial class CommanderView
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
            this.panBox = new System.Windows.Forms.Panel();
            this.cmbFullPath = new System.Windows.Forms.ComboBox();
            this.livFileSystem = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colExtension = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colAttributes = new System.Windows.Forms.ColumnHeader();
            this.tmCheckConnect = new System.Windows.Forms.Timer(this.components);
            this.panBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBox
            // 
            this.panBox.Controls.Add(this.cmbFullPath);
            this.panBox.Controls.Add(this.livFileSystem);
            this.panBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBox.Location = new System.Drawing.Point(0, 0);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(594, 472);
            this.panBox.TabIndex = 0;
            // 
            // cmbFullPath
            // 
            this.cmbFullPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFullPath.BackColor = System.Drawing.SystemColors.Control;
            this.cmbFullPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFullPath.FormattingEnabled = true;
            this.cmbFullPath.Location = new System.Drawing.Point(2, 0);
            this.cmbFullPath.Name = "cmbFullPath";
            this.cmbFullPath.Size = new System.Drawing.Size(590, 23);
            this.cmbFullPath.TabIndex = 2;
            this.cmbFullPath.SelectionChangeCommitted += new System.EventHandler(this.cmbFullPath_SelectionChangeCommitted);
            // 
            // livFileSystem
            // 
            this.livFileSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.livFileSystem.BackColor = System.Drawing.SystemColors.Window;
            this.livFileSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.livFileSystem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colExtension,
            this.colSize,
            this.colAttributes});
            this.livFileSystem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.livFileSystem.FullRowSelect = true;
            this.livFileSystem.HideSelection = false;
            this.livFileSystem.Location = new System.Drawing.Point(2, 24);
            this.livFileSystem.Name = "livFileSystem";
            this.livFileSystem.Size = new System.Drawing.Size(590, 446);
            this.livFileSystem.TabIndex = 1;
            this.livFileSystem.UseCompatibleStateImageBehavior = false;
            this.livFileSystem.View = System.Windows.Forms.View.Details;
            this.livFileSystem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.livFileSystem_KeyDown);
            this.livFileSystem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.livFileSystem_MouseDoubleClick);
            // 
            // colName
            // 
            this.colName.Name = "colName";
            this.colName.Text = "Name";
            this.colName.Width = 360;
            // 
            // colExtension
            // 
            this.colExtension.Name = "colExtension";
            this.colExtension.Text = "Ext.";
            this.colExtension.Width = 70;
            // 
            // colSize
            // 
            this.colSize.Name = "colSize";
            this.colSize.Text = "Größe";
            this.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSize.Width = 70;
            // 
            // colAttributes
            // 
            this.colAttributes.Name = "colAttributes";
            this.colAttributes.Text = "Attr.";
            this.colAttributes.Width = 70;
            // 
            // tmCheckConnect
            // 
            this.tmCheckConnect.Interval = 10000;
            this.tmCheckConnect.Tick += new System.EventHandler(this.tmCheckConnect_Tick);
            // 
            // CommanderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panBox);
            this.Name = "CommanderView";
            this.Size = new System.Drawing.Size(594, 472);
            this.panBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBox;
        private System.Windows.Forms.ListView livFileSystem;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colExtension;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colAttributes;
        private System.Windows.Forms.ComboBox cmbFullPath;
        private System.Windows.Forms.Timer tmCheckConnect;
    }
}
