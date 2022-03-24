﻿namespace vdrControlCenterUI.Controls;

public partial class EpgGuideLineController : UserControl
{
    private DateTime _currentDateTime;
    private List<Channel> _channelList;
    private int _lastChannelIndex;
    private bool _enableRequest = false;
    private vdrControlCenterContext _context;

    private List<FakeEpg> _epg;
    private List<Epg> _foundList = new List<Epg>();
    private List<DataLayer.Models.Timer> _timerList = new List<DataLayer.Models.Timer>();

    private int _countTimeLines;

    private const int EPG_GUIDE_LINE_HEIGHT = 34; // Höhe der EpgGuideLine + 4 Pixel Rand oben und unten

    private frmMain _frmMain;
    private DateTime _startDateTime;

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

    public frmMain MainForm
    {
        set => _frmMain = value;
    }

    public EpgGuideLineController()
    {
        InitializeComponent();

        if (!DesignMode)
            PostInit();
    }


    private void PostInit()
    {
        _enableRequest = true;

        // Nur das Datum ist interessant
        _startDateTime = _currentDateTime = DateTime.Now.Date;
        _lastChannelIndex = 0;

        if (_context == null)
            _context = new vdrControlCenterContext();
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
        int lastIndex = _lastChannelIndex;
        if (_lastChannelIndex - _countTimeLines > 0)
            _lastChannelIndex -= _countTimeLines;
        else
            _lastChannelIndex = 0;

        if (lastIndex != _lastChannelIndex)
            RefreshList();
    }

    private void btnUp_Click(object sender, EventArgs e)
    {
        int lastIndex = _lastChannelIndex;
        if (_lastChannelIndex + _countTimeLines < _channelList.Count - 1)
            _lastChannelIndex += _countTimeLines;

        if (lastIndex != _lastChannelIndex)
            RefreshList();
    }

    private void btnPrevious_Click(object sender, EventArgs e)
    {
        RefreshDay(EpgRefreshState.Backward);
    }


    private void btnNext_Click(object sender, EventArgs e)
    {
        RefreshDay(EpgRefreshState.Forward);
    }

    private void RefreshList()
    {
        DrawTimeLines(true);
        DrawEpgGuideLineEntries();
    }

    private void RefreshDay(EpgRefreshState state)
    {
        if (state != EpgRefreshState.Current)
            _currentDateTime = _currentDateTime.AddDays((int)state);

        lblCurrentDate.Text = $"{_currentDateTime:dddd, dd.MM.yyyy}";
        gcClock.CurrentDate = _currentDateTime;

        DrawTimeLines(false);
    }

    private void DrawTimeLines(bool refreshChannels)
    {
        if (_channelList == null)
            return;

        _frmMain.AddMessage("BUILD EPG-ENTRIES");

        panTimeLineControls.SuspendLayout();
        if (refreshChannels)
            ClearTimeLineControls();

        DateTime dtStart = _currentDateTime.Date;
        DateTime dtEnde = dtStart.AddDays(1).AddMilliseconds(-1);
        if (!chbEntriesFromPast.Checked)
        {
            DateTime now = DateTime.Now;
            if (dtStart.CompareTo(now) < 0)
                dtStart = now;
        }
            
        int y = 2;

        int ende;
        if (_lastChannelIndex + _countTimeLines < _channelList.Count - 1)
            ende = _lastChannelIndex + _countTimeLines;
        else
            ende = _channelList.Count;

        for (int i = _lastChannelIndex; i < ende; i++)
        {
            long channelRecId = _channelList[i].RecId;

            var epg = _epg.Where(x => x.ChannelRecId == channelRecId && x.StartTime.Value.CompareTo(dtStart) >= 0 && x.StartTime.Value.CompareTo(dtEnde) <= 0).ToList();

            EpgGuideLine timeLine = GetEpgGuideLine(channelRecId, _channelList[i].ChannelName);
            timeLine.Location = new Point(2, y);
            timeLine.TabIndex = i;
            timeLine.EnableRequest = _enableRequest;
            //timeLine.TimerList = await _context.Timers.Where(x => x.ChannelRecId == channelRecId).ToListAsync();
            //timeLine.RecordingList = await _context.Recordings.ToListAsync();
            timeLine.FoundList = _foundList;
            timeLine.EpgList = epg;

            panTimeLineControls.Controls.Add(timeLine);

            y += timeLine.Size.Height + 4;
        }

        btnDown.Enabled = _lastChannelIndex >= 0;
        btnUp.Enabled = _lastChannelIndex + _countTimeLines < _channelList.Count - 1;

        panTimeLineControls.ResumeLayout();
    }

    private EpgGuideLine GetEpgGuideLine(long channelRecId, string channelName)
    {
        EpgGuideLine epgGuideLine = panTimeLineControls.Controls.OfType<EpgGuideLine>().FirstOrDefault(x => x.ChannelRecId == channelRecId);
        if (epgGuideLine == null)
        {
            epgGuideLine = new EpgGuideLine()
            {
                ChannelRecId = channelRecId,
                ChannelName = channelName
            };
        }
        else
            epgGuideLine.ClearTimeLineEntries();

        return epgGuideLine;
    }

    private void LoadChannels()
    {
        CleanUp();

        short channelType = (short)ChannelType.Alle;
        bool favourites = false;

        SystemSetting systemSettings = _context.SystemSettings.FirstOrDefault(x => x.MachineName == Environment.MachineName);
        if (systemSettings != null)
        {
            if (systemSettings.ChannelListType.HasValue)
                channelType = systemSettings.ChannelListType.Value;
            if (systemSettings.FavouritesOnly.HasValue)
                favourites = systemSettings.FavouritesOnly.Value;
        }

        _frmMain.AddMessage("GET CHANNELS");
        _channelList = _context.Channels
                                .OrderBy(x => x.ChannelName)
                                .ToList();

        if (channelType == (short)ChannelType.TV)
            _channelList = _channelList.Where(x => x.Vpid.Contains("=")).ToList();
        else if (channelType == (short)ChannelType.Radio)
            _channelList = _channelList.Where(x => !x.Vpid.Contains("=")).ToList();

        if (favourites)
            _channelList = _channelList.Where(x => x.Favourite.Value).ToList();
    }

    private void LoadEpg()
    {
        _frmMain.AddMessage("GET EPG-DATA");
        string channelList = string.Empty;
        _channelList.ForEach(x =>
        {
            channelList += $"{x.RecId},";
        });

        _epg = _context.GetFakeEpgForChannels(channelList, _startDateTime);
    }

    private  void CleanUp()
    {
        _context.Timers.RemoveRange(_context.Timers.Where(x => x.StartTime.Value.CompareTo(DateTime.Now) <= 0));
        _context.SaveChanges();
    }

    private async void btnFind_Click(object sender, EventArgs e)
    {
        dlgFindEPG dlg = new dlgFindEPG();
        dlg.FoundList = _foundList;
        dlg.EnableTimerButton = true;
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK || result == DialogResult.Yes)
        {
            _foundList = dlg.FoundList;
            if (result == DialogResult.OK) // Markieren
            {
                List<Task> tasks = new List<Task>();
                panTimeLineControls.Controls.OfType<EpgGuideLine>().ToList().ForEach(x =>
                {
                    Task t = Task.Run(() =>
                    {
                        x.ForceRedraw = true;
                        x.FoundList = _foundList;
                    });
                    tasks.Add(t);
                });
                await Task.WhenAll(tasks);
            }
            else // Timer
            {
                //_timerList = dlg.FoundList;
                List<Task> tasks = new List<Task>();
                panTimeLineControls.Controls.OfType<EpgGuideLine>().ToList().ForEach(x =>
                {
                    Task t = Task.Run(() =>
                    {
                        x.ForceRedraw = true;
                        x.TimerList = _timerList;
                    });
                    tasks.Add(t);
                });
                await Task.WhenAll(tasks);

            }
        }
    }

    private void CalculcateAndRedrawDisplay()
    {
        int countLines = _countTimeLines;
        _countTimeLines = panTimeLineControls.Size.Height / EPG_GUIDE_LINE_HEIGHT;

        if (countLines != _countTimeLines)
        {
            DrawTimeLines(true);
            DrawEpgGuideLineEntries();
        }
    }

    private void ClearTimeLineControls()
    {
        foreach (EpgGuideLine epgGuideLine in panTimeLineControls.Controls.OfType<EpgGuideLine>())
        {
            // Elemente der Line löschen
            epgGuideLine.ClearTimeLineEntries();
            // Zeile selbst freigeben
            epgGuideLine.Dispose();
        }
        panTimeLineControls.Controls.Clear();
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        dlgReports dlg = new dlgReports();
        dlg.PostInit(Enums.ReportType.EpgGuide, _context);
        dlg.ShowDialog();
    }

    public void LoadData()
    {
        ClearTimeLineControls();
        LoadChannels();
        LoadEpg();
        RefreshDay(EpgRefreshState.Current);
    }

    private void lblCurrentDate_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            dlgStart dlg = new dlgStart();
            dlg.Start = _startDateTime;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _startDateTime = dlg.Start;
                LoadData();
            }
        }
    }

    private void chbEntriesFromPast_CheckedChanged(object sender, EventArgs e)
    {
        LoadData();
    }

    private async void DrawEpgGuideLineEntries()
    {
        List<Task> tasks = new List<Task>();
        panTimeLineControls.Controls.OfType<EpgGuideLine>().ToList().ForEach(x =>
        {
            Task t = Task.Run(() =>
            {
                x.DrawEpgEntries();
            });
            tasks.Add(t);
        });

        await Task.WhenAll(tasks);
    }

    public void Redraw()
    {
        CalculcateAndRedrawDisplay();
    }
}

