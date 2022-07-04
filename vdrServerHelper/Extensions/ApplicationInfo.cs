using System.Reflection;

namespace vdrServerHelper.Extensions;

/// <summary>
/// Klasse zur Ermittlung verschiedener Info's zur Applikation 
/// </summary>
public static class ApplicationInfo
{
    /// <summary>
    /// Liefert die Version
    /// </summary>
    public static Version? Version { get { return Assembly.GetCallingAssembly().GetName().Version; } }

    /// <summary>
    /// Liefert den Titel
    /// </summary>
    public static string Title
    {
        get
        {
            object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title.Length > 0) return titleAttribute.Title;
            }
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
        }
    }

    /// <summary>
    /// Liefert den Produktnamen
    /// </summary>
    public static string ProductName
    {
        get
        {
            object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
        }
    }

    /// <summary>
    /// Liefert die Produktbeschreibung
    /// </summary>
    public static string Description
    {
        get
        {
            object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }
    }

    /// <summary>
    /// Liefert den CopyRight-Eintrag
    /// </summary>
    public static string CopyrightHolder
    {
        get
        {
            object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }
    }

    /// <summary>
    /// Liefert den Namen der Herstellerfirma
    /// </summary>
    public static string CompanyName
    {
        get
        {
            object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
    }
}

