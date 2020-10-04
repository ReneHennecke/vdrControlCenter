CREATE TABLE [dbo].[StatusInfo] (
    [RecId]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [TotalDiskSpace]      INT            NULL,
    [FreeDiskSpace]       INT            NULL,
    [UsedPercent]         DECIMAL (6, 2) NULL,
    [SystemSettingsRecId] BIGINT         NOT NULL,
    CONSTRAINT [PK_StatusInfo] PRIMARY KEY CLUSTERED ([RecId] ASC),
    CONSTRAINT [FK_StatusInfo_SystemSettingsRecId] FOREIGN KEY ([SystemSettingsRecId]) REFERENCES [dbo].[SystemSettings] ([RecId]) ON DELETE CASCADE ON UPDATE CASCADE
);

