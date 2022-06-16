
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
            this.btnDel = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
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
            this.panBox.Controls.Add(this.btnDel);
            this.panBox.Controls.Add(this.btnMove);
            this.panBox.Controls.Add(this.btnCopy);
            this.panBox.Controls.Add(this.cmbFullPath);
            this.panBox.Controls.Add(this.livFileSystem);
            this.panBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBox.Location = new System.Drawing.Point(0, 0);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(594, 472);
            this.panBox.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDel.Location = new System.Drawing.Point(286, 446);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(140, 22);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "<F8, Entf>=Löschen";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMove.Location = new System.Drawing.Point(144, 446);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(140, 22);
            this.btnMove.TabIndex = 4;
            this.btnMove.Text = "<F6>=Verschieben";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCopy.Location = new System.Drawing.Point(2, 446);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(140, 22);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "<F5>=Kopieren";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
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
            this.livFileSystem.Size = new System.Drawing.Size(590, 420);
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
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnCopy;
    }
}
