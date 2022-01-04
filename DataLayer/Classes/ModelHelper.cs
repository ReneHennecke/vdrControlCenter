namespace DataLayer.Classes;

using DataLayer.Models;
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
                SystemSetting systemSettings = context.SystemSettings.FirstOrDefault();
                p = systemSettings?.PathToChannelLogos;

                if (!string.IsNullOrWhiteSpace(p) && Directory.Exists(p))
                    retval = p + (p.EndsWith("/") ? string.Empty : "/");
            }

            return retval;
        }
    }
}

