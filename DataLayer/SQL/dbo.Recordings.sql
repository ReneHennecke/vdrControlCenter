CREATE TABLE [dbo].[Recordings] (
    [RecId]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [Modtime]       DATETIME       CONSTRAINT [DF_Recordings_Modtime] DEFAULT (sysdatetime()) NULL,
    [Number]        INT            NULL,
    [RecordingTime] DATETIME       NULL,
    [Duration]      INT            NULL,
    [Title]         NVARCHAR (100) NULL,
    [RecordingPath] NVARCHAR (255) NULL,
    CONSTRAINT [PK_Recordings] PRIMARY KEY CLUSTERED ([RecId] ASC)
);

