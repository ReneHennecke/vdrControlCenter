CREATE TABLE [dbo].[SystemSettings] (
    [RecId]                BIGINT        IDENTITY (1, 1) NOT NULL,
    [MachineName]          NVARCHAR (15) CONSTRAINT [DF_System_MachineName] DEFAULT ('') NOT NULL,
    [ChannelListType]      SMALLINT      NULL,
    [FavouritesOnly]       BIT           NULL,
    [SaveBufferToFile]     BIT           NULL,
    [EnableLogging]        BIT           NULL,
    [LastUpdateChannels]   DATETIME      NULL,
    [LastUpdateEPG]        DATETIME      NULL,
    [LastUpdateTimers]     DATETIME      NULL,
    [LastUpdateRecordings] DATETIME      NULL,
    [LastUpdateStatus]     DATETIME      NULL,
    CONSTRAINT [PK_SystemSettings] PRIMARY KEY CLUSTERED ([RecId] ASC)
);

