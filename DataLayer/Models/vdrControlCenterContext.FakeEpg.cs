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
        public virtual DbSet<FakeEpg> FakeEpgs { get; set; }

        public List<FakeEpg> GetFakeEpgs(DateTime startTime, short channelType, bool favouritesOnly)
        {

            var startTimePrm = new SqlParameter()
            {
                ParameterName = "@startTime",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = startTime
            };


            var channelTypePrm = new SqlParameter()
            {
                ParameterName = "@channelType",
                SqlDbType = SqlDbType.SmallInt,
                Direction = ParameterDirection.Input,
                Value = channelType
            };

            var favouritesOnlyPrm = new SqlParameter()
            {
                ParameterName = "@favouritesOnly",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = favouritesOnly
            };

            List<FakeEpg> epgs = new List<FakeEpg>();

            epgs = FakeEpgs.FromSqlRaw("EXECUTE dbo.GetFakeEpg {0}, {1}, {2}", startTimePrm, channelTypePrm, favouritesOnlyPrm).ToList();
            
            return epgs;
        }
    }
}
