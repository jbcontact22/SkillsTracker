# SkillsTracker2
I have recently been trying to get a development job as a web developer with Microsoft technology.  It had been a while (2019) 
since I have really looked at the Microsoft technology stack in any detail.  I started taking the online tutorials
and working on the exerciese.  As I got job interviews I realized how rusty my coding skills have gotten.  Most
serious interviews that I have had have a timed coding test as a component.  I have not excelled at these.

I think I need to study harder and to incorporate timed coding practice to be able to perform during interviews.
I really like the Microsoft online documentation and the various "Paths", "Skills" etc.  However, it is fairly vast and 
deep and keeping track of where I am with various skills is an issue.  I am using timed coding exercises as training and 
this project is to help me keep track of where I am with each skill I want to develop.

I've been keeping notes on my activities in a Jupyter Notebook that I will attach to the project at some point.  Here is a brief 
summary.

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

## Changes
Much of the first commit will change as I am doing just enough design to get the exercises that 
I'm interested in.  I wanted to get this codebase saved just as part of the exercise.  Now that task
is done and I'm on to making the database more robust.  Skills will have a skillsparent table to
better keep track of the skills hierarchy and allow for multiple parent skills.  I'm not sure this
is the wisest design, but I'm trying to focus on building codeing muscle at this point.