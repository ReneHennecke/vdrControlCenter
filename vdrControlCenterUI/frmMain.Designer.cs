namespace vdrControlCenterUI
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.spcLeft = new System.Windows.Forms.SplitContainer();
            this.trvNavigation = new System.Windows.Forms.TreeView();
            this.spcBottom = new System.Windows.Forms.SplitContainer();
            this.viewStations = new vdrControlCenterUI.Controls.StationsView();
            this.teMessages = new System.Windows.Forms.TextBox();
            this.tabWorkspace = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft)).BeginInit();
            this.spcLeft.Panel1.SuspendLayout();
            this.spcLeft.Panel2.SuspendLayout();
            this.spcLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcBottom)).BeginInit();
            this.spcBottom.Panel1.SuspendLayout();
            this.spcBottom.Panel2.SuspendLayout();
            this.spcBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.spcLeft);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.tabWorkspace);
            this.spcMain.Size = new System.Drawing.Size(1806, 706);
            this.spcMain.SplitterDistance = 250;
            this.spcMain.TabIndex = 0;
            this.spcMain.Text = "splitContainer1";
            // 
            // spcLeft
            // 
            this.spcLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcLeft.Location = new System.Drawing.Point(0, 0);
            this.spcLeft.Name = "spcLeft";
            this.spcLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcLeft.Panel1
            // 
            this.spcLeft.Panel1.Controls.Add(this.trvNavigation);
            // 
            // spcLeft.Panel2
            // 
            this.spcLeft.Panel2.Controls.Add(this.spcBottom);
            this.spcLeft.Size = new System.Drawing.Size(250, 706);
            this.spcLeft.SplitterDistance = 331;
            this.spcLeft.TabIndex = 0;
            this.spcLeft.Text = "splitContainer1";
            // 
            // trvNavigation
            // 
            this.trvNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvNavigation.Location = new System.Drawing.Point(0, 0);
            this.trvNavigation.Name = "trvNavigation";
            this.trvNavigation.ShowNodeToolTips = true;
            this.trvNavigation.Size = new System.Drawing.Size(250, 331);
            this.trvNavigation.TabIndex = 0;
            this.trvNavigation.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvNavigation_BeforeSelect);
            this.trvNavigation.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvNavigation_NodeMouseClick);
            // 
            // spcBottom
            // 
            this.spcBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcBottom.Location = new System.Drawing.Point(0, 0);
            this.spcBottom.Name = "spcBottom";
            this.spcBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcBottom.Panel1
            // 
            this.spcBottom.Panel1.Controls.Add(this.viewStations);
            // 
            // spcBottom.Panel2
            // 
            this.spcBottom.Panel2.Controls.Add(this.teMessages);
            this.spcBottom.Size = new System.Drawing.Size(250, 371);
            this.spcBottom.SplitterDistance = 200;
            this.spcBottom.TabIndex = 0;
            this.spcBottom.Text = "splitContainer1";
            // 
            // viewStations
            // 
            this.viewStations.BackColor = System.Drawing.Color.White;
            this.viewStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewStations.Location = new System.Drawing.Point(0, 0);
            this.viewStations.Name = "viewStations";
            this.viewStations.Size = new System.Drawing.Size(250, 200);
            this.viewStations.TabIndex = 0;
            // 
            // teMessages
            // 
            this.teMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teMessages.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.teMessages.ForeColor = System.Drawing.Color.CadetBlue;
            this.teMessages.Location = new System.Drawing.Point(0, 0);
            this.teMessages.Multiline = true;
            this.teMessages.Name = "teMessages";
            this.teMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.teMessages.Size = new System.Drawing.Size(250, 167);
            this.teMessages.TabIndex = 0;
            // 
            // tabWorkspace
            // 
            this.tabWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabWorkspace.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabWorkspace.Location = new System.Drawing.Point(0, 0);
            this.tabWorkspace.Name = "tabWorkspace";
            this.tabWorkspace.SelectedIndex = 0;
            this.tabWorkspace.Size = new System.Drawing.Size(1552, 706);
            this.tabWorkspace.TabIndex = 0;
            this.tabWorkspace.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabWorkspace_DrawItem);
            this.tabWorkspace.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabWorkspace_MouseClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 706);
            this.Controls.Add(this.spcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.spcLeft.Panel1.ResumeLayout(false);
            this.spcLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft)).EndInit();
            this.spcLeft.ResumeLayout(false);
            this.spcBottom.Panel1.ResumeLayout(false);
            this.spcBottom.Panel2.ResumeLayout(false);
            this.spcBottom.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcBottom)).EndInit();
            this.spcBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.SplitContainer spcLeft;
        private System.Windows.Forms.SplitContainer spcBottom;
        private System.Windows.Forms.TreeView trvNavigation;
        private System.Windows.Forms.TabControl tabWorkspace;
        private System.Windows.Forms.TextBox teMessages;
        private Controls.StationsView viewStations;
    }
}

