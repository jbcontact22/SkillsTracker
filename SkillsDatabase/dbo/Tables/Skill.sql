CREATE TABLE [dbo].[Skill] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [skill]       NVARCHAR (50)  NOT NULL,
    [description] NVARCHAR (200) NULL,
    [link] NVARCHAR(200) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
);

