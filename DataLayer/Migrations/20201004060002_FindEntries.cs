using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class FindEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoundEntries",
                columns: table => new
                {
                    RecId = table.Column<long>(nullable: false),
                    SymbolIndex = table.Column<int>(nullable: false),
                    ChannelRecId = table.Column<long>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    DurationMinutes = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    VPS = table.Column<DateTime>(nullable: true),
                    ChannelName = table.Column<string>(nullable: true),
                    GenreCodes = table.Column<string>(nullable: true),
                    ParentalRating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoundEntries");
        }
    }
}
