using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class GetFakeEpg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FakeEpg");

            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[GetFakeEpg]
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
		T0.EventId,
		T0.StartTime,
		T0.Duration,
		T0.TableId,
		T0.[Version],
		T0.Title,
		T0.ShortDescription,
		T0.[Description],
		T0.GenreCodes,
		T0.ParentalRating,
		T0.Stream,
		T0.VPS,
		T0.Favourite,
		DATEADD(second, ISNULL(T0.Duration, 0), T0.StartTime) EndTime,
		T0.Duration / 60 DurationMinutes,
		T1.ChannelId,
		T1.ChannelName,
		ISNULL(T1.RecId, 0) ChannelsRecId,
		T1.VPID,
		ISNULL(T2.RecId, 0) TimersRecId,
		ISNULL(T3.RecID, 0) RecordingsRecId,
		dbo.fnSymbolIndex(ISNULL(T0.Favourite, 0), ISNULL(T2.RecID, 0), ISNULL(T3.RecID, 0)) SymbolIndex
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
END;
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[GetFakeEpg]");

            migrationBuilder.CreateTable(
                name: "FakeEpg",
                columns: table => new
                {
                    RecId = table.Column<long>(nullable: false)
                                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Modtime = table.Column<DateTime>(nullable: false),
                    ChannelRecId = table.Column<long>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    Duration = table.Column<DateTime>(nullable: true),
                    TableId = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    GenreCodes = table.Column<string>(nullable: false),
                    ParentRating = table.Column<int>(nullable: true),
                    Stream = table.Column<string>(nullable: false),
                    VPS = table.Column<DateTime>(nullable: true),
                    Favourite = table.Column<bool>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    DurationMinutes = table.Column<int>(nullable: true),
                    ChannelId = table.Column<string>(nullable: false),
                    ChannelName = table.Column<string>(nullable: false),
                    ChannelsRecId = table.Column<long>(nullable: false),
                    VPID = table.Column<string>(nullable: false),
                    TimersRecId = table.Column<long>(nullable: false),
                    RecordingsRecId = table.Column<long>(nullable: false),
                    SymbolIndex = table.Column<int>(nullable: false)
                });
        }
    }
}
