namespace vdrControlCenterUI.Controls;

public partial class SvdrpEpgView : UserControl
{
    private SvdrpController _controller;
    private vdrControlCenterContext _context;
    private ImageList _imageList;
    private List<FakeEpg> _unfiltered;
    private List<FakeEpg> _filtered;

    private int _hitRow = -1;
    private int _hitCol = -1;
    private ToolTip _toolTip;

    private const int ILE_EMPTY = 0;
    private const int ILE_FAVOURITE = 1;
    private const int ILE_TIMER = 2;
    private const int ILE_RECORD = 2;
    private const int ILE_SELECT = 3;

    public bool RequestEnable
    {
        get { return btnRequest.Enabled; }
        set { 
                btnRequest.Enabled = btnTimer.Enabled = value;
            }
    }

    public SvdrpEpgView()
    {
        InitializeComponent();

        if (!DesignMode)
            PostInit();
    }

    private void PostInit()
    {
        _imageList = Globals.LoadImageList(Enums.ImageListType.SvdrpEpgView);

        dgvEPG.AutoGenerateColumns = false;
        dgvEPG.RowTemplate.Height = 25;
        dgvEPG.AllowUserToResizeRows = false;

        DataGridViewCellStyle headerStyle = new DataGridViewCellStyle()
        {
            BackColor = Color.SteelBlue,
            ForeColor = Color.WhiteSmoke,
            SelectionBackColor = Color.LightSteelBlue,
            SelectionForeColor = Color.WhiteSmoke,
            Font = new Font("Calibri", 8.0f, FontStyle.Bold),
            Alignment = DataGridViewContentAlignment.MiddleCenter
        };
        dgvEPG.ColumnHeadersDefaultCellStyle = headerStyle;

        DataGridViewCellStyle cellStyle = new DataGridViewCellStyle()
        {
            BackColor = Color.WhiteSmoke,
            ForeColor = Color.Black,
            SelectionBackColor = Color.LightGray,
            SelectionForeColor = Color.Black,
            Font = new Font("Segoe UI", 8.0f, FontStyle.Regular),
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            NullValue = string.Empty
        };
        dgvEPG.RowsDefaultCellStyle = cellStyle;

        DataGridViewCellStyle cellCenterStyle = new DataGridViewCellStyle(cellStyle);
        cellCenterStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
        imageColumn.HeaderText = "·";
        imageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
        imageColumn.Name = "DisplaySymbol";
        imageColumn.Width = 30;
        imageColumn.DisplayIndex = 0;
        imageColumn.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.EmptyPng}");
        dgvEPG.Columns.Add(imageColumn);

        DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Kanal";
        textColumn.DataPropertyName = "ChannelName";
        textColumn.Name = "ChannelName";
        textColumn.Width = 150;
        textColumn.DisplayIndex = 1;
        dgvEPG.Columns.Add(textColumn);

        textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Start";
        textColumn.DataPropertyName = "StartTime";
        textColumn.Name = "StartTime";
        textColumn.Width = 120;
        textColumn.DisplayIndex = 2;
        textColumn.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
        dgvEPG.Columns.Add(textColumn);

        textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Ende";
        textColumn.DataPropertyName = "EndTime";
        textColumn.Name = "EndTime";
        textColumn.Width = 120;
        textColumn.DisplayIndex = 3;
        textColumn.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
        dgvEPG.Columns.Add(textColumn);

        textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Dauer";
        textColumn.DataPropertyName = "DurationMinutes";
        textColumn.Name = "DurationMinutes";
        textColumn.Width = 70;
        textColumn.DisplayIndex = 4;
        dgvEPG.Columns.Add(textColumn);

        textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Titel";
        textColumn.DataPropertyName = "Title";
        textColumn.Name = "Title";
        textColumn.Width = 250;
        textColumn.DisplayIndex = 5;
        dgvEPG.Columns.Add(textColumn);

        textColumn = new DataGridViewTextBoxColumn();
        textColumn.HeaderText = "Kurzbeschreibung";
        textColumn.DataPropertyName = "ShortDescription";
        textColumn.Name = "ShortDescription";
        textColumn.Width = 300;
        textColumn.DisplayIndex = 6;
        dgvEPG.Columns.Add(textColumn);

        textColumn = new DataGridViewTextBoxColumn();
        textColumn.DataPropertyName = "RecId";
        textColumn.Name = "RecId";
        textColumn.Width = 100;
        textColumn.DisplayIndex = 7;
        textColumn.Visible = false;
        dgvEPG.Columns.Add(textColumn);

        textColumn = new DataGridViewTextBoxColumn();
        textColumn.DataPropertyName = "SymbolIndex";
        textColumn.Name = "SymbolIndex";
        textColumn.Width = 100;
        textColumn.DisplayIndex = 8;
        textColumn.Visible = false;
        dgvEPG.Columns.Add(textColumn);

        textColumn = new DataGridViewTextBoxColumn();
        textColumn.DataPropertyName = "Description";
        textColumn.Name = "Description";
        textColumn.Width = 100;
        textColumn.DisplayIndex = 9;
        textColumn.Visible = false;
        dgvEPG.Columns.Add(textColumn);

        btnFind.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SevFindPng}");
        btnTimer.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SevTimerPng}");
        btnRequest.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SevRequestPng}");

        _hitRow = -1;
        _hitCol = -1;
        _toolTip = new ToolTip();
        _toolTip.InitialDelay = 1000;
        _toolTip.ShowAlways = true;
        _toolTip.IsBalloon = true;
    }

    public void LoadData(SvdrpController controller)
    {
        _controller = controller;

        if (_context == null)
            _context = new vdrControlCenterContext();

        ReLoad();

        btnRequest.Enabled = btnTimer.Enabled = false;
    }

    public async void RefreshData(SvdrpEPGList epgList)
    {
        bool reload = false;
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {
                // Jüngsten Eintrag in empfangener Liste feststellen

                // EPG-Liste von zukünftigen Einträgen bereinigen
                _context.RemoveRange(_context.Epg.Where(e => e.StartTime.Value.CompareTo(DateTime.Now) >= 0));

                await _context.SaveChangesAsync();

                _context.Epg.AddRange(epgList.EPGList);

                SystemSetting settings = await _context.SystemSettings.FirstOrDefaultAsync(e => e.MachineName == Environment.MachineName);
                if (settings != null)
                {
                    settings.LastUpdateEpg = DateTime.Now;
                    _context.Entry(settings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                reload = true;
            }
            catch //(DbUpdateException ex)
            {
                await transaction.RollbackAsync();
            }
        }

        if (reload)
            ReLoad();
    }

    private void btnFind_Click(object sender, System.EventArgs e)
    {
        dlgFindEPG dlg = new dlgFindEPG();
        dlg.EnableTimerButton = btnTimer.Enabled;
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK) // Gehe zu
        {
            foreach (long recId in dlg.SelectedItems)
            {
                DataGridViewRow row = dgvEPG.Rows
                                            .Cast<DataGridViewRow>()
                                            .Where(r => (long)r.Cells["RecId"].Value == recId)
                                            .FirstOrDefault();
                if (row != null && (int)row.Cells["SymbolIndex"].Value == ILE_EMPTY)
                    row.Cells["SymbolIndex"].Value = ILE_SELECT;
            }
        }
        else if (result == DialogResult.Yes)
        {
            SaveTimers(dlg.SelectedItems);
        }
    }

    private void btnTimer_Click(object sender, System.EventArgs e)
    {
        DataGridViewRow currentRow = dgvEPG.CurrentRow;
        List<long> selectedItems = new List<long>();
        selectedItems.Add((long)dgvEPG.Rows[currentRow.Index].Cells["RecId"].Value);
        SaveTimers(selectedItems);
    }

    private void btnRequest_Click(object sender, System.EventArgs e)
    {
        _controller.SendEPGRequest();
    }

    private void dgvEPG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value == null)
            return;

        if (e.ColumnIndex == dgvEPG.Columns["DurationMinutes"].Index)
        {
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        else if (e.ColumnIndex == dgvEPG.Columns["StartTime"].Index)
        {
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        else if (e.ColumnIndex == dgvEPG.Columns["EndTime"].Index)
        {
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }

    private async void ReLoad()
    {
        var owner = (SvdrpController)Parent;
        owner.ForwardMessage("LOAD EPG-DATA");

        dgvEPG.DataSource = null;

        SystemSetting systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(e => e.MachineName == Environment.MachineName); 
        if (systemSettings != null)
        {
            lblRequestInfo.Text = $"{systemSettings.LastUpdateEpg:dd.MM.yyyy HH:mm:ss}";

            DateTime date = new DateTime(dtpDate.Value.Date.Year, dtpDate.Value.Month, dtpDate.Value.Day, 0, 0, 0);

            _unfiltered = _context.GetFakeEpg(date, 0, false);
            dgvEPG.DataSource = _unfiltered;
        }
    }

    private void dgvEPG_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex > -1)
        {
            if (e.ColumnIndex == dgvEPG.Columns["DisplaySymbol"].Index)
            {

                int i = (int)dgvEPG.Rows[e.RowIndex].Cells["SymbolIndex"].Value;
                if (i < 0 || i >= _imageList.Images.Count)
                    i = 0;

                Image cellImage = _imageList.Images[i];
                if (cellImage != null)
                {
                    SolidBrush gridBrush = new SolidBrush(dgvEPG.GridColor);
                    Pen gridLinePen = new Pen(gridBrush);
                    SolidBrush backColorBrush = new SolidBrush(e.CellStyle.BackColor);
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    // Draw lines over cell  
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    // Draw the image over cell at specific location.  
                    Point point = new Point(e.CellBounds.X + 7, e.CellBounds.Y + 3);
                    e.Graphics.DrawImage(cellImage, point);
                    dgvEPG.Rows[e.RowIndex].Cells["DisplaySymbol"].ReadOnly = true; // make cell readonly so below text will not dispaly on double click over cell.  
                }

                e.Handled = true;
            }
        }
    }

    private void SaveTimers(List<long> selectedItems)
    {
        _controller.SendAddTimerRequest(selectedItems);
    }

    private void dtpDate_ValueChanged(object sender, EventArgs e)
    {
        ReLoad();
    }

    private void dgvEPG_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.RowIndex == -1)
            return;

        if (e.Button == MouseButtons.Right)
        {
            if (_filtered != null)
            {
                foreach (DataGridViewColumn column in dgvEPG.Columns)
                {
                    column.HeaderCell.Style.BackColor = Color.SteelBlue;
                    column.HeaderCell.Style.ForeColor = Color.WhiteSmoke;
                }
                dgvEPG.DataSource = _unfiltered;
                _filtered = null;
                return;
            }


            int columnIndex = e.ColumnIndex;
            if (columnIndex > 0)
            {
                dgvEPG.Columns[columnIndex].HeaderCell.Style.BackColor = Color.Bisque;
                dgvEPG.Columns[columnIndex].HeaderCell.Style.ForeColor = Color.Black;

                if (columnIndex == dgvEPG.Columns["ChannelName"].Index)
                {

                    string search = (string)dgvEPG.Rows[e.RowIndex].Cells[columnIndex].Value;
                    _filtered = _unfiltered.Where(x => x.ChannelName == search).ToList();
                }
                else if (columnIndex == dgvEPG.Columns["StartTime"].Index)
                {
                    DateTime search = (DateTime)dgvEPG.Rows[e.RowIndex].Cells[columnIndex].Value;
                    _filtered = _unfiltered.Where(x => x.StartTime.GetValueOrDefault().CompareTo(search) == 0).ToList();
                }
                else if (columnIndex == dgvEPG.Columns["EndTime"].Index)
                {
                    DateTime search = (DateTime)dgvEPG.Rows[e.RowIndex].Cells[columnIndex].Value;
                    _filtered = _unfiltered.Where(x => x.EndTime.GetValueOrDefault().CompareTo(search) == 0).ToList();
                }
                else if (columnIndex == dgvEPG.Columns["DurationMinutes"].Index)
                {
                    int search = (int)dgvEPG.Rows[e.RowIndex].Cells[columnIndex].Value;
                    _filtered = _unfiltered.Where(x => x.DurationMinutes.GetValueOrDefault().CompareTo(search) == 0).ToList();
                }
                else if (columnIndex == dgvEPG.Columns["Title"].Index)
                {
                    string search = (string)dgvEPG.Rows[e.RowIndex].Cells[columnIndex].Value;
                    _filtered = _unfiltered.Where(x => x.Title == search).ToList();
                }
                else if (columnIndex == dgvEPG.Columns["ShortDescription"].Index)
                {
                    string search = (string)dgvEPG.Rows[e.RowIndex].Cells[columnIndex].Value;
                    _filtered = _unfiltered.Where(x => x.ShortDescription == search).ToList();
                }

                if (_filtered != null)
                    dgvEPG.DataSource = _filtered;
            }
        }
    }

    private void dgvEPG_MouseMove(object sender, MouseEventArgs e)
    {
        var hti = dgvEPG.HitTest(e.X, e.Y);
        if (hti.Type == DataGridViewHitTestType.Cell &&  (hti.RowIndex != _hitRow || hti.ColumnIndex != _hitCol))
        { //new hit row 
            _hitRow = hti.RowIndex;
            _hitCol = hti.ColumnIndex;
            if (_toolTip != null && _toolTip.Active)
                _toolTip.Active = false;
            {
                var channel = (string)dgvEPG.Rows[_hitRow].Cells["ChannelName"].Value;
                var start = (DateTime)dgvEPG.Rows[_hitRow].Cells["StartTime"].Value;
                var ende = (DateTime)dgvEPG.Rows[_hitRow].Cells["EndTime"].Value;
                var duration = (int)dgvEPG.Rows[_hitRow].Cells["DurationMinutes"].Value;
                var title = (string)dgvEPG.Rows[_hitRow].Cells["Title"].Value;
                var shortDescription = (string)dgvEPG.Rows[_hitRow].Cells["ShortDescription"].Value;
                var description = (string)dgvEPG.Rows[_hitRow].Cells["Description"].Value;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(channel);
                sb.AppendLine($"{start:dd.MM.yyyy HH:mm} - {ende:dd.MM.yyyy HH:mm}  {duration} min");
                sb.AppendLine(title);
                sb.AppendLine();
                sb.AppendLine(shortDescription);
                sb.AppendLine();
                sb.Append(RaX.Extensions.Data.StringHelper.SpliceText(description, 40));

                _toolTip.SetToolTip(dgvEPG, sb.ToString());
            }
            _toolTip.Active = true;
        }
    }
}
