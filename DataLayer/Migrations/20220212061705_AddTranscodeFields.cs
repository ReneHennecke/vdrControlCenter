using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class AddTranscodeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TcAudioBitRate",
                table: "SystemSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TcAudioChannel",
                table: "SystemSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TcMaxVideoDuration",
                table: "SystemSettings",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TcPixelFormat",
                table: "SystemSettings",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TcRemoveAudio",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TcTarget",
                table: "SystemSettings",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TcThreads",
                table: "SystemSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TcVideoAspectRatio",
                table: "SystemSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TcVideoBitRate",
                table: "SystemSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TcVideoCodec",
                table: "SystemSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TcVideoFormat",
                table: "SystemSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TcVideoFps",
                table: "SystemSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TcVideoSize",
                table: "SystemSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TcVideoTimeScale",
                table: "SystemSettings",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TcAudioBitRate",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcAudioChannel",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcMaxVideoDuration",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcPixelFormat",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcRemoveAudio",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcTarget",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcThreads",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcVideoAspectRatio",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcVideoBitRate",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcVideoCodec",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcVideoFormat",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcVideoFps",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcVideoSize",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "TcVideoTimeScale",
                table: "SystemSettings");
        }
    }
}
