
/*
This script was created by Visual Studio on 4/1/2024 at 1:29 PM.
Run this script on (localdb)\ProjectModels.SkillsDatabaseEmpty (JBOLED\jackb) to make it the same as (localdb)\ProjectModels.SkillsDatabase (JBOLED\jackb).
This script performs its actions in the following order:
1. Disable foreign-key constraints.
2. Perform DELETE commands. 
3. Perform UPDATE commands.
4. Perform INSERT commands.
5. Re-enable foreign-key constraints.
Please back up your target database before running this script.
*/

SET NUMERIC_ROUNDABORT OFF
GO
SET XACT_ABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
/*Pointer used for text / image updates. This might not be needed, but is declared here just in case*/
DECLARE @pv binary(16)
BEGIN TRANSACTION
ALTER TABLE [dbo].[DeveloperSkill] DROP CONSTRAINT [FK_DeveloperId_Id]
ALTER TABLE [dbo].[DeveloperSkill] DROP CONSTRAINT [FK_SkillId_Skill_Id]
ALTER TABLE [dbo].[SkillParents] DROP CONSTRAINT [FK_SkillParents_SkillParent]
ALTER TABLE [dbo].[SkillParents] DROP CONSTRAINT [FK_SkillParents_Skill]
SET IDENTITY_INSERT [dbo].[Skill] ON
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (1, N'Visual Studio Code', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (2, N'SQL', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (3, N'Visual Studio', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (4, N'Docker', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (5, N'Azure', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (6, N'Database Development', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (7, N'asp.NET', N'.net Framework web application development libraries and technologies.', N'https://learn.microsoft.com/en-us/aspnet/overview')
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (8, N'web.api', N'Web services library and technology not from Microsoft Communication Foundation.', NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (9, N'c#', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (10, N'Entity Framework', NULL, N'https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application')
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (11, N'Linq', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (12, N'Razor Pages', N'Razor pages in .net.', N'https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-8.0&tabs=visual-studio')
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (13, N'HTML & CSS', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (14, N'QA Methodology', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (15, N'Development Methodology', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (16, N'JavaScript', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (17, N'Scaffolding', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (18, N'Git and GitHub', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (19, N'Test Automation', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (20, N'ApplicationBuilder', NULL, NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (21, N'Web Application Developement', N'Technologies related to build web based applications.  This is a top level category.', N'https://learn.microsoft.com/en-us/windows/web/')
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (36, N'ViewModel Usage', N'How to use a custom object as a ViewModel to pass precisely the data required to the View', NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (37, N'IOC/DI', N'Inversion of Control and Dependency Injection Patterns', N'https://www.tutorialsteacher.com/core/internals-of-builtin-ioc-container-in-aspnet-core')
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (38, N'.net Framework', N'The Microsoft Windows technology for developing applications for Windows.', N'https://learn.microsoft.com/en-us/dotnet/framework/')
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (39, N'Microsoft Learning Web Site', N'A link to the high level Microsoft documentation.', N'https://learn.microsoft.com/en-us/docs/')
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (40, N'asp.NET MVC', N'.net web development technology that implements the MVC pattern.', N'https://dotnet.microsoft.com/en-us/apps/aspnet/mvc')
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (41, N'Data Migration', N'Update the database based on changes to the schema or data made during development.', N'https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application')
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (1044, N'Development Frameworks', N'Any top level technology used for application development', NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (1045, N'.net Core', N'Cross platform .net technology', NULL)
INSERT INTO [dbo].[Skill] ([Id], [name], [description], [link]) VALUES (1046, N'.net Architecture', N'Architecture and design concepts for building applictions on .net.', N'https://learn.microsoft.com/en-us/dotnet/architecture/')
SET IDENTITY_INSERT [dbo].[Skill] OFF
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (2, 21)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (3, 21)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (5, 21)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (7, 9)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (7, 20)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (7, 21)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (7, 36)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (7, 37)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (7, 38)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (8, 7)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (8, 9)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (8, 37)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (8, 38)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (9, 21)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (10, 3)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (10, 6)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (11, 21)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (12, 7)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (12, 1045)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (13, 21)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (16, 21)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (17, 3)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (17, 7)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (19, 21)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (20, 37)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (36, 7)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (36, 21)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (36, 40)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (37, 15)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (37, 21)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (38, 1044)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (40, 7)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (41, 3)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (41, 6)
INSERT INTO [dbo].[SkillParents] ([childId], [parentId]) VALUES (1045, 1044)
SET IDENTITY_INSERT [dbo].[Developer] ON
INSERT INTO [dbo].[Developer] ([Id], [name], [nickname]) VALUES (1, N'Frederick Pohl', N'HeeCheeMan')
INSERT INTO [dbo].[Developer] ([Id], [name], [nickname]) VALUES (2, N'Frank Herbert', N'SpiceMan')
INSERT INTO [dbo].[Developer] ([Id], [name], [nickname]) VALUES (3, N'Piers Anytony', N'XanthMan')
SET IDENTITY_INSERT [dbo].[Developer] OFF
INSERT INTO [dbo].[DeveloperSkill] ([DeveloperId], [SkillId], [SkillLevel], [Notes]) VALUES (1, 1, 3, NULL)
INSERT INTO [dbo].[DeveloperSkill] ([DeveloperId], [SkillId], [SkillLevel], [Notes]) VALUES (2, 2, NULL, NULL)
INSERT INTO [dbo].[DeveloperSkill] ([DeveloperId], [SkillId], [SkillLevel], [Notes]) VALUES (3, 3, NULL, NULL)
ALTER TABLE [dbo].[DeveloperSkill]
    ADD CONSTRAINT [FK_DeveloperId_Id] FOREIGN KEY ([DeveloperId]) REFERENCES [dbo].[Developer] ([Id])
ALTER TABLE [dbo].[DeveloperSkill]
    ADD CONSTRAINT [FK_SkillId_Skill_Id] FOREIGN KEY ([SkillId]) REFERENCES [dbo].[Skill] ([Id])
ALTER TABLE [dbo].[SkillParents]
    ADD CONSTRAINT [FK_SkillParents_SkillParent] FOREIGN KEY ([parentId]) REFERENCES [dbo].[Skill] ([Id])
ALTER TABLE [dbo].[SkillParents]
    ADD CONSTRAINT [FK_SkillParents_Skill] FOREIGN KEY ([childId]) REFERENCES [dbo].[Skill] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
COMMIT TRANSACTION
