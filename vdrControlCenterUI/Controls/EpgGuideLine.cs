namespace vdrControlCenterUI.Controls;

    public partial class EpgGuideLine : UserControl
    {
        private List<EpgGuideLineEntry> _epgGuideLineEntries = new List<EpgGuideLineEntry>();

        private List<FakeEpg> _epgList;
        private List<DataLayer.Models.Timer> _timerList;
        private List<Recording> _recordingList;
        private List<Epg> _foundList;
        private bool _enableRequest = false;
        private long _channelRecId;
        private bool _forceRedraw = false;

        private delegate void DrawTimeLineEntriesDelegate();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnableRequest
        {
            get => _enableRequest;
            set
            {
                _enableRequest = value;

                foreach (EpgGuideLineEntry timeLineEntry in lblTimeLineTable.Controls)
                {
                    timeLineEntry.EnableRequest = _enableRequest;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long ChannelRecId
        {
            get => _channelRecId;
            set
            {
                _channelRecId = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ForceRedraw
        {
            get => _forceRedraw;
            set => _forceRedraw = value;
        }

        public EpgGuideLine()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {
            DoubleBuffered = true;
        }

        private int CalcPositionByDateTime(DateTime dateTime)
        {
            return dateTime.Hour * 60 + dateTime.Minute;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ChannelName
        {
            get 
            { 
                return lblChannelName.Text; 
            }
            set 
            { 
                lblChannelName.Text = value;
                lblChannelName.Image = null;
    
                string svg = $"{Globals.LogoFolder}{lblChannelName.Text}.svg";
                if (File.Exists(svg))
                {
                    SvgDocument svgDocument = null;
                    try
                    {
                        svgDocument = SvgDocument.Open(svg);
                    }
                    catch
                    {

                    }

                    if (svgDocument != null)
                    {
                        Image image = svgDocument.Draw(32, 16);
                        if (image != null)
                            lblChannelName.Image = image;
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<FakeEpg> EpgList
        {
            get { return _epgList; }
            set 
            { 
                _epgList = value;
                BuildEpgGuideLineEntries();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<DataLayer.Models.Timer> TimerList
        {
            get { return _timerList; }
            set 
            { 
                _timerList = value;

                bool refresh = false;
                _timerList.ForEach(x =>
                {
                    EpgGuideLineEntry epgle = FindEntryFromTimer(x.ChannelRecId.Value, x.Title, x.StartTime.Value);
                    if (epgle != null)
                    {
                        epgle.IsTimer = true;
                        refresh = true;
                    }
                });
                if (_forceRedraw && refresh)
                    DrawTimeLineEntries();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Recording> RecordingList
        {
            get { return _recordingList; }
            set 
            { 
                _recordingList = value;

                bool refresh = false;
                _recordingList.ForEach(x =>
                {
                    EpgGuideLineEntry epgle = FindEntryFromRecording(x.Title);
                    if (epgle != null)
                    {
                        epgle.IsTimer = true;
                        refresh = true;
                    }
                });
                if (_forceRedraw && refresh)
                    DrawTimeLineEntries();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Epg> FoundList
        {
            get { return _foundList; }
            set 
            { 
                _foundList = value;

                bool refresh = false;
                _foundList.ForEach(x =>
                {
                    EpgGuideLineEntry epgle = FindEntry(x.RecId);
                    if (epgle != null)
                    {
                        epgle.IsTimer = true;
                        refresh = true;
                    }
                });
                if (_forceRedraw && refresh)
                    DrawTimeLineEntries();
            }
        }

        private async void BuildEpgGuideLineEntries()
        {
            await Task.Run(() =>
            {
                _epgGuideLineEntries.Clear();

                if (_epgList == null)
                    return;

                int x1;
                int y1 = 0;
                int x2;
                int y2 = lblTimeLineTable.Size.Height;

                foreach (FakeEpg epg in _epgList)
                {
                    x1 = CalcPositionByDateTime(epg.StartTime.Value);
                    x2 = CalcPositionByDateTime(epg.StartTime.Value.AddSeconds((double)epg.Duration));
                    EpgGuideLineEntry epgGuideLineEntry = new EpgGuideLineEntry();
                    epgGuideLineEntry.EnableRequest = _enableRequest;
                    epgGuideLineEntry.Location = new Point(x1, y1);
                    epgGuideLineEntry.Size = new Size(x2 - x1, y2);
                    epgGuideLineEntry.Epg = epg;
                    epgGuideLineEntry.IsTimer = _timerList == null ? false : _timerList.Exists(x => x.ChannelRecId == epg.ChannelRecId && x.Title == epg.Title && x.StartTime.Value.CompareTo(epg.StartTime) == 0);
                    epgGuideLineEntry.IsRecording = _recordingList == null ? false : _recordingList.Exists(x => x.Title == epg.Title);
                    epgGuideLineEntry.IsFound = _foundList == null ? false : _foundList.Exists(x => x.RecId == epg.RecId);

                    _epgGuideLineEntries.Add(epgGuideLineEntry);
                }
            });
        }

        private void DrawTimeLineEntries()
        {
            if (lblTimeLineTable.InvokeRequired)
            {
                var d = new DrawTimeLineEntriesDelegate(DrawTimeLineEntries);
                lblTimeLineTable.Invoke(d);
            }
            else
            {
                _forceRedraw = false;

                lblTimeLineTable.SuspendLayout();
                ClearTimeLineEntries();

                if (_epgGuideLineEntries.Count > 0)
                    lblTimeLineTable.Controls.AddRange(_epgGuideLineEntries.ToArray());

                lblTimeLineTable.ResumeLayout();
                lblTimeLineTable.Update();
            }
        }

        private EpgGuideLineEntry FindEntryFromTimer(long channelRecId, string title, DateTime startTime)
        {
            return _epgGuideLineEntries.FirstOrDefault(x => x.Epg.ChannelRecId == channelRecId && x.Epg.Title == title && x.Epg.StartTime.Value.CompareTo(startTime) == 0);
        }

        private EpgGuideLineEntry FindEntryFromRecording(string title)
        {
            return _epgGuideLineEntries.FirstOrDefault(x => x.Epg.Title == title);
        }

        private EpgGuideLineEntry FindEntry(long recId)
        {
            return _epgGuideLineEntries.FirstOrDefault(x => x.Epg.RecId == recId);
        }

        public void ClearTimeLineEntries()
        {
            lblTimeLineTable.Controls.Clear();
            lblTimeLineTable.Update();
        }

        public void DrawEpgEntries()
        {
            DrawTimeLineEntries();
        }
    }

