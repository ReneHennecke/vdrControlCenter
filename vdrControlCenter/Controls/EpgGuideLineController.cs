namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    //using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using vdrControlCenterUI.Dialogs;

    public partial class EpgGuideLineController : UserControl
    {
        private DateTime _currentDateTime;
        private List<Channels> _channelList;
        private int _lastChannelIndex;
        private bool _enableRequest = false;
        private vdrControlCenterContext _context;
        private List<Epg> _foundList;

        private int _countTimeLines;
        private bool _init;

        private const int EPG_GUIDE_LINE_HEIGHT = 30;

        public frmMain MainForm { get; set; }

        public bool EnableRequest
        {
            get { return _enableRequest; }
            set
            {
                _enableRequest = value;

                foreach (EpgGuideLine timeLine in panTimeLineControls.Controls.OfType<EpgGuideLine>())
                {
                    timeLine.EnableRequest = _enableRequest;
                }
            }
        }

        public bool InInit
        {
            get { return _init; }
            set { _init = value; }
        }

        public EpgGuideLineController()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {
            _init = true;

            //Disposed += OnDispose;

            _enableRequest = true;

            // Nur das Datum ist interessant
            _currentDateTime = DateTime.Now.Date;
            _lastChannelIndex = 0;

            _context = new vdrControlCenterContext();

            LoadChannels();
        }

        private void OnDispose(object sender, EventArgs e)
        {
            _context?.Dispose();
        }

        private void RefreshDisplay()
        {
            lblCurrentDate.Text = $"{_currentDateTime:dddd, dd.MM.yyyy}";

            DrawTimeLines();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (_lastChannelIndex - _countTimeLines > 0)
                _lastChannelIndex -= _countTimeLines;
            else
                _lastChannelIndex = 0;

            DrawTimeLines();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (_lastChannelIndex + _countTimeLines < _channelList.Count - 1)
                _lastChannelIndex += _countTimeLines;

            DrawTimeLines();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _currentDateTime = _currentDateTime.AddDays(-1);
            RefreshDisplay();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentDateTime = _currentDateTime.AddDays(1);
            RefreshDisplay();
        }

        private async void DrawTimeLines()
        {
            panTimeLineControls.SuspendLayout();
            ClearTimeLineControls();

            DateTime dtStart = new DateTime(_currentDateTime.Year, _currentDateTime.Month, _currentDateTime.Day, 0, 0, 0);
            if (!chbIgnorePast.Checked)
            {
                DateTime now = DateTime.Now;
                switch (_currentDateTime.Date.CompareTo(now.Date))
                {
                    case -1:
                        panTimeLineControls.ResumeLayout();
                        return;
                    case 0:
                        dtStart = new DateTime(_currentDateTime.Year, _currentDateTime.Month, _currentDateTime.Day, now.Hour, now.Minute, 0);
                        break;
                    default:
                        break;
                }
            }
            DateTime dtEnde = new DateTime(_currentDateTime.Year, _currentDateTime.Month, _currentDateTime.Day, 23, 59, 59);

            int y = EPG_GUIDE_LINE_HEIGHT + 2;

            int ende;
            if (_lastChannelIndex + _countTimeLines < _channelList.Count - 1)
                ende = _lastChannelIndex + _countTimeLines;
            else
                ende = _channelList.Count;

            List<Epg> epg;

            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                for (int i = _lastChannelIndex; i < ende; i++)
                {
                    long channelRecId = _channelList[i].RecId;

                    epg = await context.Epg.Where(x => x.ChannelRecId == channelRecId && x.StartTime >= dtStart && x.StartTime <= dtEnde)
                                            .ToListAsync();

                    EpgGuideLine timeLine = new EpgGuideLine();
                    timeLine.ChannelName = _channelList[i].ChannelName;
                    timeLine.Location = new Point(2, y);
                    timeLine.TabIndex = i;
                    timeLine.EnableRequest = _enableRequest;
                    timeLine.ChannelRecId = channelRecId;
                    timeLine.TimerList = await context.Timers.Where(x => x.ChannelRecId == channelRecId).ToListAsync();
                    timeLine.RecordingList = await context.Recordings.ToListAsync();
                    timeLine.FoundList = _foundList;
                    timeLine.EpgList = epg;

                    panTimeLineControls.Controls.Add(timeLine);

                    y += timeLine.Size.Height + 2;
                }
            }
            btnDown.Enabled = _lastChannelIndex >= 0;
            btnUp.Enabled = _lastChannelIndex + _countTimeLines < _channelList.Count - 1;

            panTimeLineControls.ResumeLayout();

            RefreshTimeLines();
        }

        public async void LoadChannels()
        {
            CleanUp();

            _channelList = _context.Channels.OrderBy(x => x.ChannelName).ToList();

            SystemSettings systemSetting = await _context.SystemSettings.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName);
            //if (systemSetting.ChannelListType == (short)DataLayer.Enums.ChannelType.Video)
            //    _channelList = _channelList.Where(x => x.ChannelType == DataLayer.Enums.ChannelType.Video).ToList();
            //else if (systemSetting.ChannelListType == (short)DataLayer.Enums.ChannelType.Audio)
            //    _channelList = _channelList.Where(x => x.ChannelType == DataLayer.Enums.ChannelType.Audio).ToList();
        }

        private void CalcCountTimeLines()
        {
            const int EPG_GUIDE_HEADER_AREA = 3; // Entspricht 3 EPG-Zeilen

            _countTimeLines = panTimeLineControls.Size.Height / EPG_GUIDE_LINE_HEIGHT - EPG_GUIDE_HEADER_AREA;
        }

        private async void RefreshTimeLines()
        {
            foreach (EpgGuideLine timeLine in panTimeLineControls.Controls)
            {
            //    MainForm.AddMessage($"EPG-Daten von {timeLine.ChannelName}...");
                await Task.Run(() => timeLine.DrawTimeLineEntries());
            }
        }

        private  void CleanUp()
        {
            _context.Timers.RemoveRange(_context.Timers.Where(x => x.StartTime.Value.CompareTo(DateTime.Now) <= 0));
            _context.SaveChanges();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dlgFindEPG dlg = new dlgFindEPG();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _foundList = dlg.FoundList;
                RefreshDisplay();
            }
        }

        private void CalculcateAndRedrawDisplay()
        {
            CalcCountTimeLines();
            RefreshDisplay();
        }

        private void panTimeLineControls_SizeChanged(object sender, EventArgs e)
        {
            if (_init)
            {
                _init = false;
                return;
            }

            CalculcateAndRedrawDisplay();
        }

        private void ClearTimeLineControls()
        {
            foreach (EpgGuideLine line in panTimeLineControls.Controls.OfType<EpgGuideLine>())
            {
                // Elemente der Line löschen
                line.ClearEpgEntries();
                // Zeile selbst freigeben
                line.Dispose();
            }
            panTimeLineControls.Controls.Clear();
        }

        private void chbIgnorePast_CheckedChanged(object sender, EventArgs e)
        {
            panTimeLineControls_SizeChanged(null, null);
        }
    }
}
