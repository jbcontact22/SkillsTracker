# SkillsTracker2
This application is an attempt to enable tracking a hierarchy of skills and a developer's level for each skill.  The hierarchy
exists naturally, for example .net framework is related to c# which is reated to various major groups of c# functionality.  .net
core is also related to c# and to an overlapping set of functionality.  The model design is basically a single of table things
that are related and a mapping table that has a many to many relationship to the main table.

## Summary
SkillsTracker has 3 projects.
	1. The .net Framework asp.net MVC application for the user interface.  I really wanted to use a database first approach and found 
out the hard way that .net core only supports a code first approach.  So I switched to .net framework.
	2. The MSTest project for automated tests.  I strongly believe in automated tests and think that it should be part of the 
process from the beginning, not a bolt on after the fact when quality is already low.
	3. The database project.  This is fantastic, I really like it.  The SQL Server Management Studio interface in Visual Studio 
community edition, need I say more?

## Vision
I envision this project to facillitate keeping track of a complex set of interrelated technologies and related skills.  The Microsoft
documentation online will keep track of the exercises you've completed, but I want a hierarchy may to get a better sense for where 
I am and where I need to focus.  Enable the tracking of developers to skills with a skill level.  It also keeps track of skill
relationships and stores links to each skill.  Later I'll add reports.