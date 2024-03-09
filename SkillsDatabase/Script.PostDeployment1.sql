/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/*
USE [MASTER]
ALTER DATABASE [SkillsDatabase] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE [SkillsDatabase];
GO
*/
/*
DELETE FROM DeveloperSkill;
DELETE FROM SkillParents;
DELETE FROM Developer;
DELETE FROM Skill;
*/

SET IDENTITY_INSERT Developer ON;

MERGE INTO Developer AS target
USING (VALUES
(1,'Frederick Pohl','HeeCheeMan'),
(2,'Frank Herbert','SpiceMan'),
(3,'Piers Anytony','XanthMan')
) AS src(Id,name,nickname)
ON target.Id = src.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, name, nickname)
VALUES (Id, name, nickname);

SET IDENTITY_INSERT Developer OFF;

SET IDENTITY_INSERT Skill ON

MERGE INTO Skill AS sk
USING (
    VALUES (1, 'Visual Studio Code Skills'),
        (2,'SQL Skills'),
        (3,'Visual Studio Skills'),
        (4,'Docker Skills'),
        (5,'Azure Skills'),
        (6,'Database Development Skills'),
        (7,'asp.NET MVC skills'),
        (8,'web.api Skills'),
        (9,'c# Skills'),
        (10,'Entity Framework Skills'),
        (11,'Linq Skills'),
        (12,'Razor Pages Skills'),
        (13,'HTML & CSS Skills'),
        (14,'QA Methodology'),
        (15,'Development Methodology Skills'),
        (16,'JavaScript'),
        (17,'Scaffolding Skills'),
        (18,'Git and GitHub SKills'),
        (19,'Test Automatin Skills'),
        (20,'ApplicationBuilder'),
        (21,'Web Developement')
    ) AS src(Id, skill)
ON sk.Id = src.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, skill)
VALUES (Id, skill);

SET IDENTITY_INSERT Skill OFF

MERGE INTO DeveloperSkill AS ds
USING ( Values
(1,1),
(2,2),
(3,3)) AS src(developerId,skillId)
ON src.developerId = ds.developerId AND src.skillId = ds.skillId
WHEN NOT MATCHED BY TARGET THEN
INSERT (developerId, skillId)
VALUES (developerId, skillId);

MERGE INTO SkillParents AS skp
USING (VALUES
(7,21),
(13,21),
(13,7)) AS vals(skillId,skillParentId)
ON vals.skillId = skp.skillId AND vals.skillParentId = skp.skillParentId
WHEN NOT MATCHED BY TARGET THEN
INSERT (skillId,skillParentId)
VALUES (skillId,skillParentId);