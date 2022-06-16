
namespace vdrControlCenterUI.Dialogs
{
    partial class dlgEditor
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rtbEditor = new System.Windows.Forms.RichTextBox();
            this.rtbLineNumbers = new System.Windows.Forms.RichTextBox();
            this.panBox = new System.Windows.Forms.Panel();
            this.panBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(596, 358);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(154, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(438, 358);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(154, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Speichern / Schliessen";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rtbEditor
            // 
            this.rtbEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbEditor.Location = new System.Drawing.Point(58, 0);
            this.rtbEditor.Name = "rtbEditor";
            this.rtbEditor.Size = new System.Drawing.Size(684, 340);
            this.rtbEditor.TabIndex = 7;
            this.rtbEditor.Text = "";
            this.rtbEditor.SelectionChanged += new System.EventHandler(this.rtbEditor_SelectionChanged);
            this.rtbEditor.VScroll += new System.EventHandler(this.rtbEditor_VScroll);
            this.rtbEditor.FontChanged += new System.EventHandler(this.rtbEditor_FontChanged);
            this.rtbEditor.TextChanged += new System.EventHandler(this.rtbEditor_TextChanged);
            this.rtbEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbEditor_MouseDown);
            this.rtbEditor.Resize += new System.EventHandler(this.rtEditor_Resize);
            // 
            // rtbLineNumbers
            // 
            this.rtbLineNumbers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbLineNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLineNumbers.Cursor = System.Windows.Forms.Cursors.PanNE;
            this.rtbLineNumbers.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtbLineNumbers.ForeColor = System.Drawing.Color.Black;
            this.rtbLineNumbers.Location = new System.Drawing.Point(0, 0);
            this.rtbLineNumbers.Name = "rtbLineNumbers";
            this.rtbLineNumbers.ReadOnly = true;
            this.rtbLineNumbers.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbLineNumbers.Size = new System.Drawing.Size(56, 340);
            this.rtbLineNumbers.TabIndex = 8;
            this.rtbLineNumbers.Text = "";
            // 
            // panBox
            // 
            this.panBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBox.Controls.Add(this.rtbLineNumbers);
            this.panBox.Controls.Add(this.rtbEditor);
            this.panBox.Location = new System.Drawing.Point(6, 6);
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(744, 340);
            this.panBox.TabIndex = 9;
            // 
            // dlgEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 392);
            this.Controls.Add(this.panBox);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "dlgEditor";
            this.Load += new System.EventHandler(this.dlgEditor_Load);
            this.panBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RichTextBox rtbEditor;
        private System.Windows.Forms.RichTextBox rtbLineNumbers;
        private System.Windows.Forms.Panel panBox;
    }
}