namespace DataLayer.Classes;

using DataLayer.Models;

public class StoredProcedures
{
    public void GetEPGList()
    {
        using (vdrControlCenterContext context = new vdrControlCenterContext())
        {
            //System.Linq.IQueryable<Epg> epgs = context.Epg.FromSql("");
        }
    }
}

