namespace DataLayer.Models
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public partial class vdrControlCenterContext
    {
        public virtual DbSet<FakeEpgGuide> FakeEpgGuide { get; set; }

        public List<FakeEpgGuide> GetFakeEpgGuide(DateTime startTime, DateTime endTime, bool favouritesOnly)
        {
            var startTimePrm = new SqlParameter()
            {
                ParameterName = "@start",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = startTime
            };

            var endTimePrm = new SqlParameter()
            {
                ParameterName = "@ende",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = endTime
            };

            var favouritesOnlyPrm = new SqlParameter()
            {
                ParameterName = "@favouritesOnly",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = favouritesOnly
            };

            List<FakeEpgGuide> fakeEpgGuide = new List<FakeEpgGuide>();

            fakeEpgGuide = FakeEpgGuide.FromSqlRaw("EXECUTE dbo.BuildEpgGuide {0}, {1}, {2}", startTimePrm, endTimePrm, favouritesOnly).ToList();

            return fakeEpgGuide;
        }
    }
}
