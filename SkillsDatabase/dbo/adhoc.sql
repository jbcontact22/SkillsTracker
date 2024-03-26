USE [SkillsDatabase]
SELECT 
Id, name, description, link
, p.childId AS Id
, p.parentId AS Parent
FROM Skill AS sk
LEFT JOIN SkillParents as p ON p.childId = sk.Id;

--select * from SkillParents;