CREATE TABLE [dbo].[DeveloperSkill] (
    [DeveloperId] INT NOT NULL,
    [SkillId]     INT NOT NULL,
    [SkillLevel]  INT NULL,
    CONSTRAINT [PK_DeveloperSkill] PRIMARY KEY CLUSTERED ([DeveloperId] ASC, [SkillId] ASC),
    CONSTRAINT [FK_DeveloperId_Id] FOREIGN KEY ([DeveloperId]) REFERENCES [dbo].[Developer] ([Id]),
    CONSTRAINT [FK_SkillId_Skill_Id] FOREIGN KEY ([SkillId]) REFERENCES [dbo].[Skill] ([Id])
);

