namespace DataLayer.Models;

public partial class vdrControlCenterContext
{
    public virtual DbSet<FindEntry> FoundEntries { get; set; }

    public List<FindEntry> FindEntries(string expression, DateTime startTime, bool seekInTitle, bool seekInShortDescriptions, bool seekInDescriptions, bool seekInTimers, bool seekInRecordings,
                                        bool seekInPast)
    {
        var expressionPrm = new SqlParameter()
        {
            ParameterName = "@expression",
            SqlDbType = SqlDbType.NVarChar,
            Size = 50,
            Direction = ParameterDirection.Input,
            Value = expression
        };

        var startTimePrm = new SqlParameter()
        {
            ParameterName = "@startTime",
            SqlDbType = SqlDbType.DateTime,
            Direction = ParameterDirection.Input,
            Value = startTime
        };


        var seekInTitlePrm = new SqlParameter()
        {
            ParameterName = "@seekInTitle",
            SqlDbType = SqlDbType.Bit,
            Direction = ParameterDirection.Input,
            Value = seekInTitle
        };

        var seekInShortDescriptionsPrm = new SqlParameter()
        {
            ParameterName = "@seekInShortDescriptions",
            SqlDbType = SqlDbType.Bit,
            Direction = ParameterDirection.Input,
            Value = seekInShortDescriptions
        };

        var seekInDescriptionsPrm = new SqlParameter()
        {
            ParameterName = "@seekInDescriptions",
            SqlDbType = SqlDbType.Bit,
            Direction = ParameterDirection.Input,
            Value = seekInDescriptions
        };

        var seekInTimersPrm = new SqlParameter()
        {
            ParameterName = "@seekInTimers",
            SqlDbType = SqlDbType.Bit,
            Direction = ParameterDirection.Input,
            Value = seekInTimers
        };

        var seekInRecordingsPrm = new SqlParameter()
        {
            ParameterName = "@seekInRecordings",
            SqlDbType = SqlDbType.Bit,
            Direction = ParameterDirection.Input,
            Value = seekInRecordings
        };

        var seekInPastPrm = new SqlParameter()
        {
            ParameterName = "@seekInPast",
            SqlDbType = SqlDbType.Bit,
            Direction = ParameterDirection.Input,
            Value = seekInPast
        };

        List<FindEntry> entries = new List<FindEntry>();

        entries = FoundEntries.FromSqlRaw("EXECUTE dbo.FindEntries {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                                            expressionPrm,
                                            startTimePrm,
                                            seekInTitlePrm,
                                            seekInShortDescriptionsPrm,
                                            seekInDescriptionsPrm,
                                            seekInTimersPrm,
                                            seekInRecordingsPrm,
                                            seekInPastPrm).ToList();
            
        return entries;
    }
}

