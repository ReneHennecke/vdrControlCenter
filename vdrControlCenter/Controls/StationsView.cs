namespace vdrControlCenterUI.Controls
{
    using System.Drawing;
    using System.Data;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using System.Drawing.Drawing2D;
    using DataLayer.Models;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public partial class StationsView : UserControl
    {
       

        public StationsView()
        {
            InitializeComponent();
        }

        public async void PopulateData()
        {
            livStations.BeginUpdate();
            livStations.Items.Clear();
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                var stations = await context.Stations.OrderBy(s => s.HostAddress).ToListAsync();
                foreach (var station in stations)
                {
                    ListViewItem item = new ListViewItem()
                    {
                        Text = $"   {station.HostAddress}",
                        Tag = station,
                        ImageIndex = 0
                    };
                    livStations.Items.Add(item);
                }
            }
            livStations.EndUpdate();
        }
    }
}
