namespace vdrControlCenterUI.Dialogs
{
    using System;
    using DataLayer.Models;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using System.Linq;

    public partial class dlgFindEPG : Form
    {
        private const int ENTRY_UNSELECTED = 0;
        private const int ENTRY_SELECTED = 4;
        private const int IS_EPG_ENTRY = 0;
        
        private ImageList _imageList;
        private List<long> _selectedItems = new List<long>();
        private List<Epg> _foundList;

        private List<FindEntry> _unfiltered;
        private List<FindEntry> _filtered;

        private int _hitRow = -1;
        private int _hitCol = -1;
        private ToolTip _toolTip;

        public List<long> SelectedItems
        {
            get { return _selectedItems; }
        }

        public bool EnableTimerButton
        {
            set { btnTimer.Enabled = value; }
        }
        
        public List<Epg> FoundList
        {
            get
            {
                List<Epg> epgs = new List<Epg>();

                foreach (DataGridViewRow row in dgvFind.Rows)
                {
                    if ((int)row.Cells["SymbolIndex"].Value == ENTRY_SELECTED)
                    {
                        long recId = (long)row.Cells["RecId"].Value;
                        string channelName = (string)row.Cells["ChannelName"].Value;
                        if (!string.IsNullOrWhiteSpace(channelName))
                        {
                            Epg epg = new Epg()
                            {
                                RecId = recId
                            };
                            epgs.Add(epg);
                        }
                    }
                }

                return epgs;
            }
            set
            {
                _foundList = value;
                PreSelect();
            }
        }

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

            _imageList = Globals.LoadImageList(Enums.ImageListType.SvdrpEpgView);

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

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "·";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
            imageColumn.Name = "DisplaySymbol";
            imageColumn.Width = 30;
            imageColumn.DisplayIndex = 0;
            imageColumn.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.EmptyPng}");
            dgvFind.Columns.Add(imageColumn);

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Kanal";
            textColumn.DataPropertyName = "ChannelName";
            textColumn.Name = "ChannelName";
            textColumn.Width = 150;
            textColumn.DisplayIndex = 1;
            dgvFind.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Start";
            textColumn.DataPropertyName = "StartTime";
            textColumn.Name = "StartTime";
            textColumn.Width = 120;
            textColumn.DisplayIndex = 2;
            dgvFind.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Dauer";
            textColumn.DataPropertyName = "DurationMinutes";
            textColumn.Name = "DurationMinutes";
            textColumn.Width = 70;
            textColumn.DisplayIndex = 3;
            dgvFind.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Titel";
            textColumn.DataPropertyName = "Title";
            textColumn.Name = "Title";
            textColumn.Width = 350;
            textColumn.DisplayIndex = 4;
            dgvFind.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Kurzbeschreibung";
            textColumn.DataPropertyName = "ShortDescription";
            textColumn.Name = "ShortDescription";
            textColumn.Width = 550;
            textColumn.DisplayIndex = 5;
            dgvFind.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "RecId";
            textColumn.Name = "RecId";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 6;
            textColumn.Visible = false;
            dgvFind.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "SymbolIndex";
            textColumn.Name = "SymbolIndex";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 7;
            textColumn.Visible = false;
            dgvFind.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "Description";
            textColumn.Name = "Description";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 8;
            textColumn.Visible = false;
            dgvFind.Columns.Add(textColumn);

            btnFind.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.Find_FindPng}");
            btnOK.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.Find_OkPng}");
            btnTimer.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.Find_TimerPng}");
            btnCancel.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.Find_CancelPng}");

            _hitRow = -1;
            _hitCol = -1;
            _toolTip = new ToolTip();
            _toolTip.InitialDelay = 1000;
            _toolTip.ShowAlways = true;
            _toolTip.IsBalloon = true;

            tbFind_TextChanged(null, null);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            dgvFind.DataSource = null;

            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                _unfiltered = context.FindEntries(tbFind.Text,
                                                         dtpStartTime.Value,
                                                         chbTitle.Checked,
                                                         chbSortDescription.Checked,
                                                         chbDescription.Checked,
                                                         chbTimers.Checked,
                                                         chbRecordings.Checked,
                                                         chbFindInPast.Checked);

                dgvFind.DataSource = _unfiltered;

                lblNotFound.Visible = (dgvFind.Rows.Count == 0);
                PreSelect();
            }
            Cursor = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgvFind_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            if (e.ColumnIndex == dgvFind.Columns["DurationMinutes"].Index)
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            else if (e.ColumnIndex == dgvFind.Columns["StartTime"].Index)
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvFind_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
            if (e.RowIndex > -1 && e.ColumnIndex == dgvFind.Columns["DisplaySymbol"].Index)
            {

                int i = (int)dgvFind.Rows[e.RowIndex].Cells["SymbolIndex"].Value;
                if (i < 0 || i >= _imageList.Images.Count)
                    i = 0;

                Image cellImage = _imageList.Images[i];
                if (cellImage != null)
                {
                    SolidBrush gridBrush = new SolidBrush(dgvFind.GridColor);
                    Pen gridLinePen = new Pen(gridBrush);
                    SolidBrush backColorBrush = new SolidBrush(e.CellStyle.BackColor);
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    // Draw lines over cell  
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    // Draw the image over cell at specific location.  
                    Point point = new Point(e.CellBounds.X + 7, e.CellBounds.Y + 3);
                    e.Graphics.DrawImage(cellImage, point);
                    dgvFind.Rows[e.RowIndex].Cells["DisplaySymbol"].ReadOnly = true; // make cell readonly so below text will not display on double click over cell.  
                }

                e.Handled = true;
            }
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = (tbFind.Text.Length > 0);
        }

        private void chbFindInPast_CheckedChanged(object sender, EventArgs e)
        {
            dtpStartTime.Enabled = (!chbFindInPast.Checked);
        }

        private void btnTimer_Click(object sender, EventArgs e)
        {

            GetSelectedItems();
            DialogResult = DialogResult.Yes;  // DialogResult.Yes wird hier "missbraucht"
        }

        private void GetSelectedItems()
        {
            _selectedItems.Clear();
            foreach (DataGridViewRow row in dgvFind.Rows)
            {
                if ((int)row.Cells["SymbolIndex"].Value == ENTRY_SELECTED)
                    _selectedItems.Add((long)row.Cells["RecId"].Value);
            }
        }

        private void dgvFind_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int rowIndex = e.RowIndex;
                DateTime start = (DateTime)dgvFind.Rows[rowIndex].Cells["StartTime"].Value;
                if (start.CompareTo(DateTime.Now) < 0)
                    return;

                int i = (int)dgvFind.Rows[rowIndex].Cells["SymbolIndex"].Value;
                if (i == ENTRY_SELECTED || i == ENTRY_UNSELECTED)
                {
                    dgvFind.Rows[rowIndex].Cells["SymbolIndex"].Value = (i == ENTRY_UNSELECTED ? ENTRY_SELECTED : ENTRY_UNSELECTED);

                    dgvFind.InvalidateCell(dgvFind.Rows[rowIndex].Cells["DisplaySymbol"]);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Markieren
            GetSelectedItems();
            DialogResult = DialogResult.OK; // DialogResult.Yes wird hier "missbraucht"
        }

        private void PreSelect()
        {
            if (_foundList == null)
                return;

            foreach (DataGridViewRow row in dgvFind.Rows)
            {
                if ((int)row.Cells["SymbolIndex"].Value == ENTRY_UNSELECTED)
                {
                    

                    long recId = (long)row.Cells["RecId"].Value;
                    if (_foundList.Exists(x => x.RecId == recId))
                    {
                        row.Cells["SymbolIndex"].Value = ENTRY_SELECTED;
                    }
                }
            }
        }

        private void dgvFind_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && e.RowIndex > -1)
            {
                if (_filtered != null)
                {
                    foreach (DataGridViewColumn column in dgvFind.Columns)
                    {
                        column.HeaderCell.Style.BackColor = Color.SteelBlue;
                        column.HeaderCell.Style.ForeColor = Color.WhiteSmoke;
                    }
                    dgvFind.DataSource = _unfiltered;
                    _filtered = null;
                    return;
                }


                int columnIndex = e.ColumnIndex;
                if (columnIndex > 0)
                {
                    dgvFind.Columns[columnIndex].HeaderCell.Style.BackColor = Color.Bisque;
                    dgvFind.Columns[columnIndex].HeaderCell.Style.ForeColor = Color.Black;

                    if (columnIndex == dgvFind.Columns["ChannelName"].Index)
                    {

                        string search = (string)dgvFind.Rows[e.RowIndex].Cells[columnIndex].Value;
                        _filtered = _unfiltered.Where(x => x.ChannelName == search).ToList();
                    }
                    else if (columnIndex == dgvFind.Columns["StartTime"].Index)
                    {
                        DateTime search = (DateTime)dgvFind.Rows[e.RowIndex].Cells[columnIndex].Value;
                        _filtered = _unfiltered.Where(x => x.StartTime.GetValueOrDefault().CompareTo(search) == 0).ToList();
                    }
                    else if (columnIndex == dgvFind.Columns["DurationMinutes"].Index)
                    {
                        int search = (int)dgvFind.Rows[e.RowIndex].Cells[columnIndex].Value;
                        _filtered = _unfiltered.Where(x => x.DurationMinutes.GetValueOrDefault().CompareTo(search) == 0).ToList();
                    }
                    else if (columnIndex == dgvFind.Columns["Title"].Index)
                    {
                        string search = (string)dgvFind.Rows[e.RowIndex].Cells[columnIndex].Value;
                        _filtered = _unfiltered.Where(x => x.Title == search).ToList();
                    }
                    else if (columnIndex == dgvFind.Columns["ShortDescription"].Index)
                    {
                        string search = (string)dgvFind.Rows[e.RowIndex].Cells[columnIndex].Value;
                        _filtered = _unfiltered.Where(x => x.ShortDescription == search).ToList();
                    }

                    if (_filtered != null)
                        dgvFind.DataSource = _filtered;
                }
            }
        }

        private void dgvFind_MouseMove(object sender, MouseEventArgs e)
        {
            var hti = dgvFind.HitTest(e.X, e.Y);
            if (hti.Type == DataGridViewHitTestType.Cell && (hti.RowIndex != _hitRow || hti.ColumnIndex != _hitCol))
            { //new hit row 
                _hitRow = hti.RowIndex;
                _hitCol = hti.ColumnIndex;
                if (_toolTip != null && _toolTip.Active)
                    _toolTip.Active = false;
                {
                    var channel = (string)dgvFind.Rows[_hitRow].Cells["ChannelName"].Value;
                    var start = (DateTime)dgvFind.Rows[_hitRow].Cells["StartTime"].Value;
                    var duration = (int)dgvFind.Rows[_hitRow].Cells["DurationMinutes"].Value;
                    var title = (string)dgvFind.Rows[_hitRow].Cells["Title"].Value;
                    var shortDescription = (string)dgvFind.Rows[_hitRow].Cells["ShortDescription"].Value;
                    var description = (string)dgvFind.Rows[_hitRow].Cells["Description"].Value;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(channel);
                    sb.AppendLine($"{start:dd.MM.yyyy HH:mm} {duration} min");
                    sb.AppendLine(title);
                    sb.AppendLine();
                    sb.AppendLine(shortDescription);
                    sb.AppendLine();
                    sb.Append(RaX.Extensions.Data.StringHelper.SpliceText(description, 40));

                    _toolTip.SetToolTip(dgvFind, sb.ToString());
                }
                _toolTip.Active = true;
            }
        }
    }
}

