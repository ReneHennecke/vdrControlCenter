namespace DataLayer.Classes
{
    using DataLayer.Models;
    using System;
    using System.IO;
    using System.Linq;

    public static class ModelHelper
    {
        public static string PathToChannelLogos
        {
            get
            {
                string retval = string.Empty;

                using (vdrControlCenterContext context = new vdrControlCenterContext())
                {
                    string p;
                    Stations stations = context.Stations.FirstOrDefault(x => x.MachineName == Environment.MachineName);
                    p = stations?.PathToChannelLogos;
                    if (string.IsNullOrWhiteSpace(p))
                    {
                        SystemSettings systemSettings = context.SystemSettings.FirstOrDefault();
                        p = systemSettings?.PathToChannelLogos;
                    }

                    if (!string.IsNullOrWhiteSpace(p) && Directory.Exists(p))
                        retval = p + (p.EndsWith("/") ? string.Empty : "/");
                }

                return retval;
            }
        }
    }
}
