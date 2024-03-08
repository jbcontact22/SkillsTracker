CREATE TABLE [dbo].[Skill] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [skill]       NVARCHAR (50)  NOT NULL,
    [description] NVARCHAR (200) NULL,
    [parentskill] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Skill_Skill] FOREIGN KEY ([parentskill]) REFERENCES [dbo].[Skill] ([Id])
);

