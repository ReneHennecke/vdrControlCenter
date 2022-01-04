namespace DataLayer.Classes;

using DataLayer.Models;

public static class ConfigurationHelper
{ 
    public static Configuration CurrentConfig
    {
        get
        {
            Configuration configuration = null;
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                SystemSetting systemSettings = context.SystemSettings.FirstOrDefault(x => x.MachineName == Environment.MachineName);
                if (systemSettings == null)
                    systemSettings = new SystemSetting();

                if (!string.IsNullOrWhiteSpace(systemSettings.Configuration))
                {
                    try
                    {
                        configuration = JsonSerializer.Deserialize<Configuration>(systemSettings.Configuration);
                    }
                    catch //(Exception ex)
                    {

                    }
                }
            }

            return configuration;
        }
        set
        {
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    bool exists = true;
                    SystemSetting systemSettings = context.SystemSettings.FirstOrDefault(x => x.MachineName == Environment.MachineName);
                    if (systemSettings == null)
                    {
                        systemSettings = new SystemSetting();
                        exists = false;
                    }
                    else
                    {
                        var options = new JsonSerializerOptions
                        {
                            WriteIndented = true,
                        };
                        systemSettings.Configuration = JsonSerializer.Serialize(value, options);
                    }

                    if (exists)
                        context.Entry(systemSettings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    else
                        context.SystemSettings.Add(systemSettings);

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch //(Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}

