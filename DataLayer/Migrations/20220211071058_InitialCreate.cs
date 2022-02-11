using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modtime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())"),
                    Number = table.Column<int>(type: "int", nullable: true),
                    ChannelID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChannelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProviderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    Parameter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SignalSource = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SymbolRate = table.Column<int>(type: "int", nullable: true),
                    VPID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    APID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TPID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CAID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Params = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Favourite = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "DataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FakeEpgGuide",
                columns: table => new
                {
                    CurrentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlockCounter = table.Column<int>(type: "int", nullable: false),
                    RowCounter = table.Column<int>(type: "int", nullable: false),
                    ChannelRecId_1 = table.Column<long>(type: "bigint", nullable: true),
                    ChannelName_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelImage_1 = table.Column<bool>(type: "bit", nullable: true),
                    EpgRecId_1 = table.Column<long>(type: "bigint", nullable: true),
                    EpgEventId_1 = table.Column<int>(type: "int", nullable: true),
                    EpgStartTime_1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EpgDuration_1 = table.Column<int>(type: "int", nullable: true),
                    EpgTitle_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgShortDescription_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgDescription_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelRecId_2 = table.Column<long>(type: "bigint", nullable: true),
                    ChannelImage_2 = table.Column<bool>(type: "bit", nullable: true),
                    ChannelName_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgRecId_2 = table.Column<long>(type: "bigint", nullable: true),
                    EpgEventId_2 = table.Column<int>(type: "int", nullable: true),
                    EpgStartTime_2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EpgDuration_2 = table.Column<int>(type: "int", nullable: true),
                    EpgTitle_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgShortDescription_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgDescription_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelRecId_3 = table.Column<long>(type: "bigint", nullable: true),
                    ChannelName_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelImage_3 = table.Column<bool>(type: "bit", nullable: true),
                    EpgRecId_3 = table.Column<long>(type: "bigint", nullable: true),
                    EpgEventId_3 = table.Column<int>(type: "int", nullable: true),
                    EpgStartTime_3 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EpgDuration_3 = table.Column<int>(type: "int", nullable: true),
                    EpgTitle_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgShortDescription_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgDescription_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelRecId_4 = table.Column<long>(type: "bigint", nullable: true),
                    ChannelName_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelImage_4 = table.Column<bool>(type: "bit", nullable: true),
                    EpgRecId_4 = table.Column<long>(type: "bigint", nullable: true),
                    EpgEventId_4 = table.Column<int>(type: "int", nullable: true),
                    EpgStartTime_4 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EpgDuration_4 = table.Column<int>(type: "int", nullable: true),
                    EpgTitle_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgShortDescription_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgDescription_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelRecId_5 = table.Column<long>(type: "bigint", nullable: true),
                    ChannelName_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelImage_5 = table.Column<bool>(type: "bit", nullable: true),
                    EpgRecId_5 = table.Column<long>(type: "bigint", nullable: true),
                    EpgEventId_5 = table.Column<int>(type: "int", nullable: true),
                    EpgStartTime_5 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EpgDuration_5 = table.Column<int>(type: "int", nullable: true),
                    EpgTitle_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgShortDescription_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgDescription_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelRecId_6 = table.Column<long>(type: "bigint", nullable: true),
                    ChannelName_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelImage_6 = table.Column<bool>(type: "bit", nullable: true),
                    EpgRecId_6 = table.Column<long>(type: "bigint", nullable: true),
                    EpgEventId_6 = table.Column<int>(type: "int", nullable: true),
                    EpgStartTime_6 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EpgDuration_6 = table.Column<int>(type: "int", nullable: true),
                    EpgTitle_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgShortDescription_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgDescription_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelRecId_7 = table.Column<long>(type: "bigint", nullable: true),
                    ChannelName_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelImage_7 = table.Column<bool>(type: "bit", nullable: true),
                    EpgRecId_7 = table.Column<long>(type: "bigint", nullable: true),
                    EpgEventId_7 = table.Column<int>(type: "int", nullable: true),
                    EpgStartTime_7 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EpgDuration_7 = table.Column<int>(type: "int", nullable: true),
                    EpgTitle_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgShortDescription_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpgDescription_7 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FakeEpgs",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modtime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChannelRecId = table.Column<long>(type: "bigint", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    TableId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreCodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentalRating = table.Column<int>(type: "int", nullable: true),
                    Stream = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VPS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Favourite = table.Column<bool>(type: "bit", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DurationMinutes = table.Column<int>(type: "int", nullable: true),
                    ChannelId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelsRecId = table.Column<long>(type: "bigint", nullable: false),
                    VPID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimersRecId = table.Column<long>(type: "bigint", nullable: false),
                    RecordingsRecId = table.Column<long>(type: "bigint", nullable: false),
                    SymbolIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FakeTimers",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modtime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    ChannelRecId = table.Column<long>(type: "bigint", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FoundEntries",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SymbolIndex = table.Column<int>(type: "int", nullable: false),
                    ChannelRecId = table.Column<long>(type: "bigint", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DurationMinutes = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VPS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChannelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreCodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentalRating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Recordings",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modtime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())"),
                    Number = table.Column<int>(type: "int", nullable: true),
                    RecordingTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RecordingPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordings", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    HostAddress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    StationType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSHPort = table.Column<int>(type: "int", nullable: true),
                    SSHUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SSHPassword = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    SVDRPPort = table.Column<int>(type: "int", nullable: true),
                    SambaUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SambaPassword = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    PathToRecordings = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VdrControlServicePort = table.Column<int>(type: "int", nullable: true),
                    MacAddress = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    EnableWOL = table.Column<bool>(type: "bit", nullable: true),
                    VDRAdminPort = table.Column<int>(type: "int", nullable: true),
                    VDRAdminUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VDRAdminPassword = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, defaultValueSql: "('')"),
                    ChannelListType = table.Column<short>(type: "smallint", nullable: true),
                    FavouritesOnly = table.Column<bool>(type: "bit", nullable: true),
                    SaveBufferToFile = table.Column<bool>(type: "bit", nullable: true),
                    EnableLogging = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdateChannels = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateEPG = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateTimers = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateRecordings = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateStatus = table.Column<DateTime>(type: "datetime", nullable: true),
                    PathToChannelLogos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPnPDownloadPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OverwriteUPnPDownload = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "EPG",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modtime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(sysdatetime())"),
                    ChannelRecId = table.Column<long>(type: "bigint", nullable: true),
                    EventID = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    TableID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Version = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreCodes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParentalRating = table.Column<int>(type: "int", nullable: true),
                    Stream = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    VPS = table.Column<DateTime>(type: "datetime", nullable: true),
                    Favourite = table.Column<bool>(type: "bit", nullable: true),
                    DurationComputed = table.Column<int>(type: "int", nullable: true, computedColumnSql: "([Duration] / (60))"),
                    EndTimeComputed = table.Column<DateTime>(type: "datetime", nullable: true, computedColumnSql: "(dateadd(second, isnull([Duration], (0)), [StartTime])")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPG", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_EPG_Channels",
                        column: x => x.ChannelRecId,
                        principalTable: "Channels",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timers",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modtime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    ChannelRecId = table.Column<long>(type: "bigint", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timers", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Timers_Channels",
                        column: x => x.ChannelRecId,
                        principalTable: "Channels",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusInfo",
                columns: table => new
                {
                    RecId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalDiskSpace = table.Column<int>(type: "int", nullable: true),
                    FreeDiskSpace = table.Column<int>(type: "int", nullable: true),
                    UsedPercent = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    SystemSettingsRecId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusInfo", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_StatusInfo_SystemSettingsRecId",
                        column: x => x.SystemSettingsRecId,
                        principalTable: "SystemSettings",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "NCI_ChannelRecId_StartTime",
                table: "EPG",
                columns: new[] { "ChannelRecId", "StartTime" });

            migrationBuilder.CreateIndex(
                name: "NCI_EventID",
                table: "EPG",
                columns: new[] { "ChannelRecId", "EventID" });

            migrationBuilder.CreateIndex(
                name: "IX_Stations",
                table: "Stations",
                column: "HostAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "NCI_StationType",
                table: "Stations",
                column: "StationType");

            migrationBuilder.CreateIndex(
                name: "IX_StatusInfo_SystemSettingsRecId",
                table: "StatusInfo",
                column: "SystemSettingsRecId");

            migrationBuilder.CreateIndex(
                name: "NCI_ChannelRecId",
                table: "Timers",
                column: "ChannelRecId");

            migrationBuilder.CreateIndex(
                name: "NCI_Title_StartTime_EndTime",
                table: "Timers",
                columns: new[] { "Title", "StartTime", "EndTime" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataProtectionKeys");

            migrationBuilder.DropTable(
                name: "EPG");

            migrationBuilder.DropTable(
                name: "FakeEpgGuide");

            migrationBuilder.DropTable(
                name: "FakeEpgs");

            migrationBuilder.DropTable(
                name: "FakeTimers");

            migrationBuilder.DropTable(
                name: "FoundEntries");

            migrationBuilder.DropTable(
                name: "Recordings");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "StatusInfo");

            migrationBuilder.DropTable(
                name: "Timers");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "Channels");
        }
    }
}
