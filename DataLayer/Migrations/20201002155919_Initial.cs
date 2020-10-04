using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
	public partial class Initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var sql = @"CREATE TABLE [dbo].[Channels](
	[RecId] [bigint] IDENTITY(1,1) NOT NULL,
	[Modtime] [datetime] NOT NULL,
	[Number] [int] NULL,
	[ChannelID] [nvarchar](50) NOT NULL,
	[ChannelName] [nvarchar](100) NULL,
	[ProviderName] [nvarchar](50) NULL,
	[Frequency] [int] NULL,
	[Parameter] [nvarchar](50) NULL,
	[SignalSource] [nvarchar](10) NULL,
	[SymbolRate] [int] NULL,
	[VPID] [nvarchar](50) NULL,
	[APID] [nvarchar](50) NULL,
	[TPID] [nvarchar](50) NULL,
	[CAID] [nvarchar](50) NULL,
	[SID] [nvarchar](50) NULL,
	[NID] [nvarchar](50) NULL,
	[TID] [nvarchar](50) NULL,
	[RID] [nvarchar](50) NULL,
	[Params] [nvarchar](256) NULL,
	[Favourite] [bit] NULL,
 CONSTRAINT [PK_Channels] PRIMARY KEY CLUSTERED 
(
	[RecId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Channels] ADD  CONSTRAINT [DF_Channels_Modtime]  DEFAULT (sysdatetime()) FOR [Modtime]
GO";

			migrationBuilder.Sql(sql);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			var sql = "DROP DATABASE vdrControlcenter_Test;";

			migrationBuilder.Sql(sql);
		}
	}
}
