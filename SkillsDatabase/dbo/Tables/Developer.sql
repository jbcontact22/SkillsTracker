CREATE TABLE [dbo].[Developer] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [name]     NVARCHAR (50) NOT NULL,
    [nickname] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

