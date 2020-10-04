CREATE TABLE [dbo].[EPG] (
    [RecId]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [Modtime]          DATETIME       CONSTRAINT [DF_EPG_Modtime] DEFAULT (sysdatetime()) NULL,
    [ChannelRecId]     BIGINT         NULL,
    [EventID]          INT            NULL,
    [StartTime]        DATETIME       NULL,
    [Duration]         INT            NULL,
    [TableID]          NVARCHAR (10)  NULL,
    [Version]          NVARCHAR (10)  NULL,
    [Title]            NVARCHAR (256) NULL,
    [ShortDescription] NVARCHAR (256) NULL,
    [Description]      NVARCHAR (MAX) NULL,
    [GenreCodes]       NVARCHAR (100) NULL,
    [ParentalRating]   INT            NULL,
    [Stream]           NVARCHAR (255) NULL,
    [VPS]              DATETIME       NULL,
    [DurationComputed] AS             ([Duration]/(60)),
    [EndTimeComputed]  AS             (dateadd(second,isnull([Duration],(0)),[StartTime])),
    CONSTRAINT [PK_EPG] PRIMARY KEY CLUSTERED ([RecId] ASC),
    CONSTRAINT [FK_EPG_Channels] FOREIGN KEY ([ChannelRecId]) REFERENCES [dbo].[Channels] ([RecId]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [NCI_EventID]
    ON [dbo].[EPG]([ChannelRecId] ASC, [EventID] ASC);


GO
CREATE NONCLUSTERED INDEX [NCI_ChannelRecId_StartTime]
    ON [dbo].[EPG]([ChannelRecId] ASC, [StartTime] ASC);

