CREATE TABLE [dbo].[StationTypes] (
    [RecId]       INT           IDENTITY (1, 1) NOT NULL,
    [StationType] NVARCHAR (20) NULL,
    CONSTRAINT [PK_StationTypes] PRIMARY KEY CLUSTERED ([RecId] ASC)
);

