namespace vdrControlCenterUI.Reports.Dialogs
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Reporting.WinForms;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Dialogs;

    public partial class ucFakeEpgGuide : UserControl
    {
        private vdrControlCenterContext _context;
        private string _channelLogoPath = string.Empty;

        public string ChannelLogoPath
        {
            get => _channelLogoPath;
        }

        public DateTime Start
        {
            get => dtpStart.Value;
        }

        public DateTime Ende
        {
            get => dtpEnde.Value;
        }

        public bool FavouritesOnly
        {
            get => chbFavouritesOnly.Checked;
        }

        public bool HideDescription
        {
            get => chbHideDescription.Checked;
        }

        public bool HideShortDescription
        {
            get => chbHideShortDescription.Checked;
        }

        public string CheckedChannels
        {
            get
            {
                string checkedChannels = string.Empty;
                foreach (var checkedItem in clbChannels.CheckedItems)
                {
                    ListBoxItem item = (ListBoxItem)checkedItem;
                    Channels checkedChannel = (Channels)item.Value;

                    checkedChannels += $"{checkedChannel.RecId},";
                }

                if (checkedChannels.EndsWith(","))
                    checkedChannels = checkedChannels.Remove(checkedChannels.Length - 1);

                return checkedChannels;

            }
        }

        public ucFakeEpgGuide()
        {
            InitializeComponent();
        }

        public async void PostInit(vdrControlCenterContext context)
        {
            _context = context;
           
            DateTime max = (await _context.Epg.MaxAsync(x => x.StartTime)).GetValueOrDefault();

            dtpEnde.Value = dtpStart.Value.CompareTo(max) <= 0 ? max.AddDays(-1) : dtpStart.Value.AddDays(1);
            
            List<Channels> channels = await _context.Channels.OrderBy(x => x.ChannelName).ToListAsync();
            int index = 0;
            foreach (Channels channel in channels)
            {
                ListBoxItem item = new ListBoxItem();
                item.Text = channel.ChannelName;
                item.Value = channel;
                clbChannels.Items.Add(item);
                clbChannels.SetItemChecked(index, true);
                index++;
            }
        }

        private void dtpStart_ValueChanged(object sender, System.EventArgs e)
        {
            CheckDateValues();        }

        private void dtpEnde_ValueChanged(object sender, System.EventArgs e)
        {
            CheckDateValues();
        }

        private void CheckDateValues()
        {
            if (dtpStart.Value.CompareTo(dtpEnde.Value) > 0)
                dtpEnde.Value = dtpStart.Value;
        }

       

        private void btnStart_Click(object sender, EventArgs e)
        {
            GetOwner().StartReporting();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GetOwner().Cancel = true;
        }

        private dlgReports GetOwner()
        {
            return (dlgReports)Parent.Parent.Parent;
        }

        public void Enabler(bool startEnable, bool cancelEnable)
        {
            btnStart.Enabled = startEnable;
            btnCancel.Enabled = cancelEnable;
        }

        private void btnDoChecked_Click(object sender, EventArgs e)
        {
            DoChecked(true);
        }

        private void btnUndoChecked_Click(object sender, EventArgs e)
        {
            DoChecked(false);
        }

        private void DoChecked(bool isChecked)
        {
            for (int i = 0; i < clbChannels.Items.Count; i++)
            {
                clbChannels.SetItemChecked(i, isChecked);
            }
        }

        private void btnSwapChecked_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbChannels.Items.Count; i++)
            {
                clbChannels.SetItemChecked(i, !clbChannels.GetItemChecked(i));
            }
        }
    }
}
