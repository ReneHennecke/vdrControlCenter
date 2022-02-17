namespace vdrControlCenterUI.Controls;

public partial class SvdrpRecordingView : UserControl
{
    private SvdrpController _controller;
    private vdrControlCenterContext _context;
    private ImageList _imageList;

    private const int ILE_EMPTY = 0;
    private const int ILE_CUT = 1;

    public bool RequestEnable
    {
        get { return btnRequest.Enabled; }
        set { 
                btnNew.Enabled = btnDel.Enabled = btnRequest.Enabled = value;  // btnNew => btnCut
            }
    }

    public SvdrpRecordingView()
    {
        InitializeComponent();

        if (!DesignMode)
            PostInit();
    }

    private void PostInit()
    {
        _imageList = Globals.LoadImageList(Enums.ImageListType.SvdrpRecordingsView);

        dgvRecordings.AutoGenerateColumns = false;
        dgvRecordings.RowTemplate.Height = 25;
        dgvRecordings.AllowUserToResizeRows = false;

        DataGridViewCellStyle headerStyle = new DataGridViewCellStyle()
        {
            BackColor = Color.SteelBlue,
            ForeColor = Color.WhiteSmoke,
            SelectionBackColor = Color.LightSteelBlue,
            SelectionForeColor = Color.WhiteSmoke,
            Font = new Font("Calibri", 8.0f, FontStyle.Bold),
            Alignment = DataGridViewContentAlignment.MiddleCenter
        };
        dgvRecordings.ColumnHeadersDefaultCellStyle = headerStyle;

        DataGridViewCellStyle cellStyle = new DataGridViewCellStyle()
        {
            BackColor = Color.WhiteSmoke,
            ForeColor = Color.Black,
            SelectionBackColor = Color.LightGray,
            SelectionForeColor = Color.Black,
            Font = new Font("Segoe UI", 8.0f, FontStyle.Regular),
            Alignment = DataGridViewContentAlignment.MiddleLeft
        };
        dgvRecordings.RowsDefaultCellStyle = cellStyle;

        DataGridViewCellStyle cellCenterStyle = new DataGridViewCellStyle(cellStyle);
        cellCenterStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
        imageColumn.HeaderText = "·";
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
        imageColumn.Name = "DisplayCut";
        imageColumn.Width = 30;
        imageColumn.DisplayIndex = 0;
        dgvRecordings.Columns.Add(imageColumn);

        DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Ordner";
        textColumn.DataPropertyName = "RecordingPath";
        textColumn.Name = "RecordingPath";
        textColumn.Width = 80;
        textColumn.DisplayIndex = 1;
        dgvRecordings.Columns.Add(textColumn);


        textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Titel";
        textColumn.DataPropertyName = "Title";
        textColumn.Name = "Title";
        textColumn.Width = 350;
        textColumn.DisplayIndex = 2;
        dgvRecordings.Columns.Add(textColumn);

        textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Aufnahme am";
        textColumn.DataPropertyName = "RecordingTime";
        textColumn.Name = "RecordingTime";
        textColumn.Width = 120;
        textColumn.DisplayIndex = 3;
        dgvRecordings.Columns.Add(textColumn);

        textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Dauer";
        textColumn.DataPropertyName = "Duration";
        textColumn.Name = "Duration";
        textColumn.Width = 70;
        textColumn.DisplayIndex = 4;
        dgvRecordings.Columns.Add(textColumn);

        textColumn = new DataGridViewTextBoxColumn();
        textColumn.DataPropertyName = "RecId";
        textColumn.Name = "RecId";
        textColumn.Width = 100;
        textColumn.DisplayIndex = 5;
        textColumn.Visible = false;
        dgvRecordings.Columns.Add(textColumn);


        btnNew.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SrvNewPng}");
        btnDel.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SrvDelPng}");
        btnRequest.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SrvRequestPng}");
    }

    public void LoadData(SvdrpController controller)
    {
        _controller = controller;

        if (_context == null)
            _context = new vdrControlCenterContext();

        ReLoad();

        btnRequest.Enabled = btnDel.Enabled = false;
    }

    public async void RefreshData(SvdrpRecordingList recordingList)
    {
        bool reload = false;
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {
                _context.Recordings.RemoveRange(_context.Recordings);

                await _context.Recordings.AddRangeAsync(recordingList.Recordings);

                SystemSetting settings = await _context.SystemSettings.FirstOrDefaultAsync(e => e.MachineName == Environment.MachineName);
                if (settings != null)
                {
                    settings.LastUpdateRecordings = DateTime.Now;
                    _context.Entry(settings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                reload = true;
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        if (reload)
            ReLoad();
    }


    private void btnRequest_Click(object sender, System.EventArgs e)
    {
        _controller.SendGetRecordingsRequest();
    }

    private async void ReLoad()
    {
        var owner = (SvdrpController)Parent;
        owner.ForwardMessage("LOAD RECORDINGS");

        dgvRecordings.DataSource = null;

        SystemSetting systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(e => e.MachineName == Environment.MachineName);
        if (systemSettings != null)
        {
            lblRequestInfo.Text = $"{systemSettings.LastUpdateRecordings:dd.MM.yyyy HH:mm:ss}";

            dgvRecordings.DataSource = await _context.Recordings.OrderBy(e => e.RecordingPath)
                                                                .ThenBy(e => e.Title)
                                                                .ToListAsync();
        }
    }

    private void dgvChannels_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex > -1)
        {
            if (e.ColumnIndex == dgvRecordings.Columns["DisplayCut"].Index)
            {
                string title = (string)dgvRecordings.Rows[e.RowIndex].Cells["Title"].Value;
                SolidBrush gridBrush = new SolidBrush(dgvRecordings.GridColor);
                Pen gridLinePen = new Pen(gridBrush);
                SolidBrush backColorBrush = new SolidBrush(e.CellStyle.BackColor);
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                // Draw lines over cell  
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                // Draw the image over cell at specific location.  
                Point point = new Point(e.CellBounds.X + 7, e.CellBounds.Y + 3);
                e.Graphics.DrawImage(title.StartsWith("%") ? _imageList.Images[ILE_CUT] : _imageList.Images[ILE_EMPTY], point);
                dgvRecordings.Rows[e.RowIndex].Cells["DisplayCut"].ReadOnly = true; // make cell readonly so below text will not dispaly on double click over cell.  

                e.Handled = true;
            }
        }
    }

    private void dgvRecordings_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value == null)
            return;

        if (e.ColumnIndex == dgvRecordings.Columns["Duration"].Index)
        {
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        else if (e.ColumnIndex == dgvRecordings.Columns["RecordingTime"].Index)
        {
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}

