namespace DataLayer.Classes
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore.Storage;
    using Newtonsoft.Json;
    using System;
    using System.Linq;


    public static class ConfigurationHelper
    {
        public static Configuration CurrentConfig
        {
            get
            {
                Configuration configuration = null;
                using (vdrControlCenterContext context = new vdrControlCenterContext())
                {
                    SystemSettings systemSettings = context.SystemSettings.FirstOrDefault(x => x.MachineName == Environment.MachineName);
                    if (systemSettings == null)
                        systemSettings = new SystemSettings();

                    if (!string.IsNullOrWhiteSpace(systemSettings.Configuration))
                    {
                        try
                        {
                            configuration = JsonConvert.DeserializeObject<Configuration>(systemSettings.Configuration);
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
                if (value == null)
                    return;

                using (vdrControlCenterContext context = new vdrControlCenterContext())
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    { 
                        bool exists = true;
                        SystemSettings systemSettings = context.SystemSettings.FirstOrDefault(x => x.MachineName == Environment.MachineName);
                        if (systemSettings == null)
                        {
                            systemSettings = new SystemSettings();
                            exists = false;
                        }
                        else
                            systemSettings.Configuration = JsonConvert.SerializeObject(value, Formatting.Indented);

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
}
