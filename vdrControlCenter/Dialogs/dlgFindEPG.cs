using System;
namespace vdrControlCenterUI.Dialogs
{
    using System.Drawing;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

    public partial class dlgFindEPG : Form
    {
        public dlgFindEPG()
        {
            InitializeComponent();

            PostInit();
        }

        private void PostInit()
        {
            dgvFind.AutoGenerateColumns = false;
            dgvFind.RowTemplate.Height = 25;
            dgvFind.AllowUserToResizeRows = false;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.SteelBlue,
                ForeColor = Color.WhiteSmoke,
                SelectionBackColor = Color.LightSteelBlue,
                SelectionForeColor = Color.WhiteSmoke,
                Font = new Font("Calibri", 8.0f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvFind.ColumnHeadersDefaultCellStyle = headerStyle;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                SelectionBackColor = Color.LightGray,
                SelectionForeColor = Color.Black,
                Font = new Font("Segoe UI", 8.0f, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            dgvFind.RowsDefaultCellStyle = cellStyle;


            DataGridViewCellStyle cellCenterStyle = new DataGridViewCellStyle(cellStyle);
            cellCenterStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Kanal";
            textColumn.DataPropertyName = "ChannelNameComputed";
            textColumn.Name = "ChannelName";
            textColumn.Width = 150;
            textColumn.DisplayIndex = 0;
            dgvFind.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Start";
            textColumn.DataPropertyName = "StartTime";
            textColumn.Name = "StartTime";
            textColumn.Width = 120;
            textColumn.DisplayIndex = 1;
            dgvFind.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Ende";
            textColumn.DataPropertyName = "EndTimeComputed";
            textColumn.Name = "EndTimeComputed";
            textColumn.Width = 120;
            textColumn.DisplayIndex = 2;
            dgvFind.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Dauer";
            textColumn.DataPropertyName = "DurationComputed";
            textColumn.Name = "DurationComputed";
            textColumn.Width = 70;
            textColumn.DisplayIndex = 3;
            dgvFind.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Titel";
            textColumn.DataPropertyName = "Title";
            textColumn.Name = "Title";
            textColumn.Width = 250;
            textColumn.DisplayIndex = 4;
            dgvFind.Columns.Add(textColumn);

            btnFind.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.Find_FindPng}");
            btnOK.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.Find_OkPng}");
            btnCancel.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.Find_CancelPng}");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
