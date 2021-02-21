namespace vdrControlCenterUI.Dialogs
{
    using System;
    using System.Windows.Forms;
    using vdrControlCenterUI.Controls;
    using vdrControlService.Models;

    public partial class dlgEditor : Form
    {
        public dlgEditor()
        {
            InitializeComponent();
        }

        public void PostInit(ServiceController controller, bool local, FileSystemEntry fse, string content, bool readOnly = true)
        {
            string text = readOnly ? "View" : "Edit";
            Text = $"{readOnly} ¤ [{fse.FullPath}]";
            teEditor.Text = content;
            teEditor.Select(0, 0);
            teEditor.ReadOnly = readOnly;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
