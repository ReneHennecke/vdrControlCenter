namespace DataLayer.Models;

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

    public List<FakeEpg> GetFakeEpgForChannels(string channelList, DateTime startTime)
    {
        var channelListPrm = new SqlParameter()
        {
            ParameterName = "@channelList",
            SqlDbType = SqlDbType.NVarChar,
            Size = 4000,
            Direction = ParameterDirection.Input,
            Value = channelList
        };


        var startTimePrm = new SqlParameter()
        {
            ParameterName = "@startTime",
            SqlDbType = SqlDbType.DateTime,
            Direction = ParameterDirection.Input,
            Value = startTime
        };

        List<FakeEpg> epgs = new List<FakeEpg>();

        epgs = FakeEpgs.FromSqlRaw("EXECUTE dbo.GetFakeEpgForChannel {0}, {1}", channelListPrm, startTimePrm).ToList();

        return epgs;
    }
}

