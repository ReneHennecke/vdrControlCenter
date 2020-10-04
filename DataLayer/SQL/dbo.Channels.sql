CREATE TABLE [dbo].[Channels] (
    [RecId]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Modtime]      DATETIME       CONSTRAINT [DF_Channels_Modtime] DEFAULT (sysdatetime()) NOT NULL,
    [Number]       INT            NULL,
    [ChannelID]    NVARCHAR (50)  NOT NULL,
    [ChannelName]  NVARCHAR (100) NULL,
    [ProviderName] NVARCHAR (50)  NULL,
    [Frequency]    INT            NULL,
    [Parameter]    NVARCHAR (50)  NULL,
    [SignalSource] NVARCHAR (10)  NULL,
    [SymbolRate]   INT            NULL,
    [VPID]         NVARCHAR (50)  NULL,
    [APID]         NVARCHAR (50)  NULL,
    [TPID]         NVARCHAR (50)  NULL,
    [CAID]         NVARCHAR (50)  NULL,
    [SID]          NVARCHAR (50)  NULL,
    [NID]          NVARCHAR (50)  NULL,
    [TID]          NVARCHAR (50)  NULL,
    [RID]          NVARCHAR (50)  NULL,
    [Params]       NVARCHAR (256) NULL,
    [Favourite]    BIT            NULL,
    CONSTRAINT [PK_Channels] PRIMARY KEY CLUSTERED ([RecId] ASC)
);

