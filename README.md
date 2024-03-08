# SkillsTracker2
I have recently been trying to get a development job using Microsoft technology.  It had been a while (2019) 
since I had really looked at the Microsoft technology stack in any detail.  I started taking the online tutorials
and working on the exerciese.  As I got job interviews I realized how rusty my coding skills have gotten.  Most
serious interviews that I have had have had a timed coding test as a component and I have not excelled at them 
(still looking for a job.)  

I decided that I needed to really study harder and to incorporate timed coding practice to be able to perform during interviews.
That's how this project was born.  I really like the Microsoft online documentation and the various "Paths", "Skills" etc.
However, it is fairly vast and deep and keeping track of where I was with various skills started to become an issue.  I decided
to use the timed exercise training and this project to help me keep track of where I was with each skill I wanted to develop.

This is a work in progress.  I've never really done an open source project before so feel free to give me pointers and tips
with how I'm managing it as well as how I'm solving the technical problems.  The initial checkin is the code after four days
of iterating over the problem, deleting the full project and starting from scratch the next day.  It's amazing how many issues
you create for yourself when you do this, and how much you learn.

I've been keeping notes on my activities in a Jupyter Notebook  That I'll attach to the project at some point.  Here is a brief 
summary.

## Summary
SkillsTracker has 3 projects.
	1. The .net Framework asp.net MVC application for the user interface.  I really wanted to use a database first approach and found 
out the hard way that .net core only supports a code first approach.  So I switched to .net framework.
	2. The MSTest project for automated tests.  I strongly believe in automated tests and think that it should be part of the 
process, not a bolt on after the fact to try to save product quality when it's already low.
	3. The database project.  This is great.  The SQL Server Management Studio interface in Visual Studio community edition, 
need I say more?

## Vision
I envision this project to facillitate keeping track of a complex set of interrelated technology skills.  The Microsoft
documentation online is vast and it will keep track of the exercises you've completed, but I wanted to map the hierarchy
on my own to get a better sense for where I am in all of it and where I needed to focus.  We will see if this is
just an exercise or if the project ends up being actually useful.  No idea yet.  Sometimes a great exercise is enough.


## Changes
Much of this first commit will change as I am doing just enough design to get the exercises that 
I'm interested in.  I wanted to get this codebase saved just as part of the exercise.  Now that task
is done and I'm on to making the database more robust.  Skills will have a skillsparent table to
better keep track of the skills hierarchy and allow for multiple parent skills.  I'm not sure this
is the wisest design, but I'm trying to focus on building codeing muscle at this point.