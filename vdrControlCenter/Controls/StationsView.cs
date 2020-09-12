namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

    public partial class StationsView : UserControl
    {
        public StationsView()
        {
            InitializeComponent();
        }

        public async void PopulateData()
        {
            tmTimer.Enabled = false;

            livStations.BeginUpdate();
            livStations.Items.Clear();
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                var stations = await context.Stations.OrderBy(s => s.HostAddress).ToListAsync();
                foreach (var station in stations)
                {
                    ListViewItem item = new ListViewItem()
                    {
                        Text = $"{station.HostAddress}",
                        Tag = station,
                        ImageIndex = 0
                    };
                    livStations.Items.Add(item);
                }
            }
            livStations.EndUpdate();

            if (livStations.Items.Count > 0)
                tmTimer.Enabled = true;
        }

        private void tmTimer_Tick(object sender, System.EventArgs e)
        {
            tmTimer.Enabled = false;

            List<string> hostAdresses = new List<string>();
            foreach (ListViewItem item in livStations.Items)
            {
                Stations station = (Stations)item.Tag;
                if (!string.IsNullOrWhiteSpace(station.HostAddress))
                    hostAdresses.Add(station.HostAddress.Trim());
            }

            pcPing.PingList(hostAdresses);

            tmTimer.Enabled = true;
        }

        private void pcPing_PingReply(object sender, Classes.PingReplyEventArgsRaX e)
        {
            List<PingReplyRaX> replyList = e.ReplyList;
            livStations.RefreshPingStatus(replyList);
        }
    }
}
