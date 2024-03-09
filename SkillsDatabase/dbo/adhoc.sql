USE [SkillsDatabase]
SELECT * FROM Skill AS sk
LEFT JOIN SkillParents as p ON p.skillParentId = sk.Id;