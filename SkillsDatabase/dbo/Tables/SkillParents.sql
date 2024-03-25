CREATE TABLE [dbo].[SkillParents]
(
	[childId] INT NOT NULL , 
    [parentId] INT NOT NULL, 
    PRIMARY KEY ([childId], [parentId]), 
    CONSTRAINT [FK_SkillParents_Skill] FOREIGN KEY ([childId]) REFERENCES [Skill]([Id]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_SkillParents_SkillParent] FOREIGN KEY ([parentId]) REFERENCES [Skill]([Id])
)
