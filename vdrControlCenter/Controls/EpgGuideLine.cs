namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Svg;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

    public partial class EpgGuideLine : UserControl
    {
        private List<Epg> _epgList;
        private List<Timers> _timerList;
        private List<Recordings> _recordingList;
        private List<Epg> _foundList;
        private bool _enableRequest = false;
        private long _channelRecId;

        private delegate bool DrawTimeLineEntriesDelegate();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnableRequest
        {
            get { return _enableRequest; }
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
            get { return _channelRecId; }
            set
            {
                _channelRecId = value;
            }
        }

        public EpgGuideLine()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {

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
        public List<Epg> EpgList
        {
            get { return _epgList; }
            set { _epgList = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Timers> TimerList
        {
            get { return _timerList; }
            set { _timerList = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Recordings> RecordingList
        {
            get { return _recordingList; }
            set { _recordingList = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Epg> FoundList
        {
            get { return _foundList; }
            set { _foundList = value; }
        }

        public bool DrawTimeLineEntries()
        {
            bool running = true;
            if (lblTimeLineTable.InvokeRequired)
            {
                var d = new DrawTimeLineEntriesDelegate(DrawTimeLineEntries);
                lblTimeLineTable.Invoke(d);
            }
            else
            {
                lblTimeLineTable.SuspendLayout();
                ClearEpgEntries();

                if (_epgList != null)
                {
                    int x1;
                    int y1 = 0;
                    int x2;
                    int y2 = lblTimeLineTable.Size.Height;

                    foreach (Epg epg in _epgList)
                    {
                        x1 = CalcPositionByDateTime(epg.StartTime.Value);
                        x2 = CalcPositionByDateTime(epg.StartTime.Value.AddSeconds((double)epg.Duration));
                        EpgGuideLineEntry timeLineEntry = new EpgGuideLineEntry();
                        timeLineEntry.EnableRequest = _enableRequest;
                        timeLineEntry.Location = new Point(x1, y1);
                        timeLineEntry.Size = new Size(x2 - x1, y2);
                        timeLineEntry.Epg = epg;
                        timeLineEntry.IsTimer = _timerList == null ? false : _timerList.Exists(x => x.ChannelRecId == epg.ChannelRecId && x.Title == epg.Title && x.StartTime.Value.CompareTo(epg.StartTime) == 0);
                        timeLineEntry.IsRecording = _recordingList == null ? false : _recordingList.Exists(x => x.Title == epg.Title);
                        timeLineEntry.IsFound = _foundList == null ? false : _foundList.Exists(x => x.RecId == epg.RecId);

                        lblTimeLineTable.Controls.Add(timeLineEntry);
                    }
                }

                lblTimeLineTable.ResumeLayout();

                running = false;
            }

            return running;
        }

        public void ClearEpgEntries()
        {
            foreach (EpgGuideLineEntry entry in lblTimeLineTable.Controls.OfType<EpgGuideLineEntry>())
            {
                entry.Dispose();
            }
            lblTimeLineTable.Controls.Clear();
        }
    }
}
