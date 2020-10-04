CREATE TABLE [dbo].[Stations] (
    [RecId]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [MachineName]           NVARCHAR (15)  NOT NULL,
    [HostAddress]           NVARCHAR (15)  NOT NULL,
    [StationType]           INT            NOT NULL,
    [Description]           NVARCHAR (MAX) NULL,
    [SSHPort]               INT            NULL,
    [SSHUserName]           NVARCHAR (30)  NULL,
    [SSHPassword]           NVARCHAR (30)  NULL,
    [SVDRPPort]             INT            NULL,
    [SambaUserName]         NVARCHAR (30)  NULL,
    [SambaPassword]         NVARCHAR (30)  NULL,
    [PathToRecordings]      NVARCHAR (255) NULL,
    [VdrControlServicePort] INT            NULL,
    [MacAddress]            NVARCHAR (17)  NULL,
    [EnableWOL]             BIT            NULL,
    [VDRAdminPort]          INT            NULL,
    [VDRAdminUserName]      NVARCHAR (30)  NULL,
    [VDRAdminPassword]      NVARCHAR (30)  NULL,
    CONSTRAINT [PK_Stations] PRIMARY KEY CLUSTERED ([RecId] ASC),
    CONSTRAINT [FK_Stations_StationTypes] FOREIGN KEY ([StationType]) REFERENCES [dbo].[StationTypes] ([RecId]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Stations]
    ON [dbo].[Stations]([HostAddress] ASC);


GO
CREATE NONCLUSTERED INDEX [NCI_StationType]
    ON [dbo].[Stations]([StationType] ASC);

