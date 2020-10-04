CREATE TABLE [dbo].[Timers] (
    [RecId]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Modtime]      DATETIME       NULL,
    [Number]       INT            NULL,
    [Active]       BIT            NULL,
    [ChannelRecId] BIGINT         NULL,
    [StartTime]    DATETIME       NULL,
    [EndTime]      DATETIME       NULL,
    [Priority]     INT            NULL,
    [Duration]     INT            NULL,
    [Title]        NVARCHAR (100) NULL,
    CONSTRAINT [PK_Timers] PRIMARY KEY CLUSTERED ([RecId] ASC),
    CONSTRAINT [FK_Timers_Channels] FOREIGN KEY ([ChannelRecId]) REFERENCES [dbo].[Channels] ([RecId]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [NCI_ChannelRecId]
    ON [dbo].[Timers]([ChannelRecId] ASC);


GO
CREATE NONCLUSTERED INDEX [NCI_Title_StartTime_EndTime]
    ON [dbo].[Timers]([Title] ASC, [StartTime] ASC, [EndTime] ASC);

