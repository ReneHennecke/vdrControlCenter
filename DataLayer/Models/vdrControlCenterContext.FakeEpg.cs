namespace DataLayer.Models
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class vdrControlCenterContext
    {
        public virtual DbSet<FakeEpg> FakeEpgs { get; set; }

        public List<FakeEpg> GetFakeEpg(DateTime startTime, short channelType, bool favouritesOnly)
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

        public List<FakeEpg> GetFakeEpgForChannel(long channelRecId, DateTime startTime, DateTime endTime)
        {

            var channelRecIdPrm= new SqlParameter()
            {
                ParameterName = "@channelRecId",
                SqlDbType = SqlDbType.BigInt,
                Direction = ParameterDirection.Input,
                Value = channelRecId
            };

            var startTimePrm = new SqlParameter()
            {
                ParameterName = "@startTime",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = startTime
            };

            var endTimePrm = new SqlParameter()
            {
                ParameterName = "@endTime",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = endTime
            };

            List<FakeEpg> epgs = new List<FakeEpg>();

            epgs = FakeEpgs.FromSqlRaw("EXECUTE dbo.GetFakeEpgForChannel {0}, {1}, {2}", channelRecIdPrm, startTimePrm, endTimePrm).ToList();

            return epgs;
        }
    }
}
