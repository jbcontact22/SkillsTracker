CREATE TABLE [dbo].[SkillParents]
(
	[skillId] INT NOT NULL , 
    [skillParentId] INT NOT NULL, 
    PRIMARY KEY ([skillId], [skillParentId]), 
    CONSTRAINT [FK_SkillParents_Skill] FOREIGN KEY ([skillId]) REFERENCES [Skill]([Id]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_SkillParents_SkillParent] FOREIGN KEY ([skillParentId]) REFERENCES [Skill]([Id])
)
