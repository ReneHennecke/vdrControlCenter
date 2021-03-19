namespace DataLayer.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public partial class vdrControlCenterContext
    {
        public virtual DbSet<FakeTimer> FakeTimers { get; set; }

        public List<FakeTimer> GetFakeTimers()
        {

            List<FakeTimer> timers = new List<FakeTimer>();

            timers = FakeTimers.FromSqlRaw("EXECUTE dbo.GetFakeTimer").ToList();

            return timers;
        }
    }
}