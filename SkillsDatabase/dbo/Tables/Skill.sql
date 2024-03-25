CREATE TABLE [dbo].[Skill] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]       NVARCHAR (50)  NOT NULL,
    [description] NVARCHAR (200) NULL,
    [link] NVARCHAR(200) NULL, 
    CONSTRAINT [PK_Skill] PRIMARY KEY ([Id]) 
);

