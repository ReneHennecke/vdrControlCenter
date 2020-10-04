using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
	public partial class spGetEPGList : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var sql = @"";

			sql = @"CREATE PROCEDURE [dbo].[spReadEPGList]
	@startDateTime datetime,
	@channelType smallint,
	@onlyFavourites bit
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		T0.RecId,
		T0.Modtime,
		T0.ChannelRecId,
		T0.EventID,
		T0.StartTime,
		T0.Duration,
		T0.TableID,
		T0.[Version],
		T0.Title,
		T0.ShortDescription,
		T0.[Description],
		T0.GenreCodes,
		T0.ParentalRating,
		T0.Stream,
		T0.VPS,
		T1.ChannelID,
		T1.ChannelName,
		ISNULL(T1.Favourite, 0) Favourite,
		T1.VPID,
		ISNULL(T2.RecId, 0) TimerRecId,
		ISNULL(T3.RecId, 0) RecordingsRecId,
		dbo.fnSymbolIndex(ISNULL(T1.Favourite, 0), ISNULL(T2.RecId, 0), ISNULL(T3.RecId, 0)) SymbolIndex
	FROM
		dbo.EPG T0
	INNER JOIN
		dbo.Channels T1 ON T0.ChannelRecId = T1.RecId
	LEFT JOIN
		dbo.Timers T2 ON T0.ChannelRecId = T2.ChannelRecId AND T0.StartTime = T2.StartTime AND T0.Title = T2.Title
	LEFT JOIN
		dbo.Recordings T3 ON T0.Title = T3.Title
	WHERE
		T0.StartTime >= @startDateTime AND 
		( @channelType = 0 OR ( @channelType = 1 AND CHARINDEX('=', T1.VPID) > 0 ) OR ( @channelType = 2 AND CHARINDEX('=', T1.VPID) = 0 ) ) AND
		( @onlyFavourites = 0 OR ( @onlyFavourites = 1 AND T1.Favourite = 1 ) )
	ORDER BY 
		T1.ChannelName, T0.StartTime;
END";

			migrationBuilder.Sql(sql);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			var sql = @"DROP PROCEDURE IF EXISTS dbo.spGetEPGList;
						DROP FUNCTION IF EXISTS dbo.fnSymbolIndex;
						GO";

			migrationBuilder.Sql(sql);
		}
	}
}
