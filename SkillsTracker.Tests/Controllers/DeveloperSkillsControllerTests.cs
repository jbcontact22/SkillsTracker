using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillsTracker.Controllers;
using SkillsTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SkillsTracker.Tests.Controllers
{
    [TestClass()]
    public class DeveloperSkillsControllerTests
    {

        [TestMethod()]
        public void CreateTest1()
        {
            // Arrange
            DeveloperSkillsController controller = new DeveloperSkillsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Ignore]
        [TestMethod()]
        public void CreateTest2()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void CreateTest()
        {
            DeveloperSkill existingToCreate;
            int skillLevel = 0, incrementby = 1;
            using (var context = new SkillsDatabaseEntities())
            {
                // Arrange
                // Create a detached entity with PK of an existing entity.
                // Send this entity to the Create action.  The action should 
                // update the skill level on that entity.

                var current = context.DeveloperSkills.FirstOrDefault();

                Assert.IsNotNull(current, "The database must have at least one developerskill row to test with.");
                skillLevel = current.SkillLevel ?? 0;

                existingToCreate = new DeveloperSkill()
                {
                    DeveloperId = current.DeveloperId,
                    SkillId = current.SkillId,
                    SkillLevel = skillLevel + incrementby
                };
            }
            // TODO find the way to force the context to go back to the database for the 
            using (var context = new SkillsDatabaseEntities())
            {
                DeveloperSkillsController controller = new DeveloperSkillsController();

                // Act
                var result = controller.Create(existingToCreate) as RedirectToRouteResult;

                // Assert
                Assert.AreEqual("Index",result.RouteValues["action"]);

                var skillLevelAfter = context.DeveloperSkills.Find(1, 1).SkillLevel;
                Assert.AreEqual(skillLevel + incrementby, skillLevelAfter);
            }
        }

        [Ignore]
        [TestMethod()]
        public void IndexTest()
        {
            Assert.Fail();
        }

        [Ignore]
        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [Ignore]
        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [Ignore]
        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [Ignore]
        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [Ignore]
        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }
    }
}