using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillsTracker.Controllers;
using SkillsTracker.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using SkillsTracker.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace SkillsTracker.Tests.Controllers
{
    [TestClass()]
    public class SkillsControllerTests
    {
        public TestContext TestContext { get; set; }

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
        public void CreateTest()
        {
            Assert.Fail();
        }

        [Ignore]
        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [Ignore]
        [TestMethod()]
        public void EditTestGet()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void EditPostDeleteParentTest()
        {
            // Remove a random skill
            // 1. retrieve the random skill,
            // 2. create VM with all ParentSkills that one
            // 3. create a controller and then call edit with the VM
            // 4. retrieve the same skill from the DB and make sure
            // that it no longer has parent 7.
            int childSkillId;
            int parentSkillId;

            Skill testChildSkill;
            Skill testParentSkill;
            List<int> excludeList = new List<int>();
            using (var context = new SkillsDatabaseEntities())

            {
                // Arrange
                // Get random skill.  Select another randome skill to be its parent.

                testChildSkill = ModelHelper.GetRandomSkillExcluding(context.Skills,1, new int[] { }).FirstOrDefault();
                childSkillId = testChildSkill.Id;
                excludeList.Add(childSkillId);
                excludeList.AddRange(testChildSkill.ParentSkill.Select(s => s.Id));
                TestContext.WriteLine($"Test child skill: {testChildSkill.name}, Id: {childSkillId} and parents: {string.Join(",",testChildSkill.ParentSkill.Select(s => s.Id))}");

                testParentSkill = ModelHelper.GetRandomSkillExcluding(context.Skills, 1, excludeList).FirstOrDefault();
                Assert.IsNotNull(testParentSkill, "No parent skill determined.  Check skills exist in DB.");
                parentSkillId = testParentSkill.Id;

                testChildSkill.ParentSkill.Add(testParentSkill);
                context.SaveChanges();
                TestContext.WriteLine($"Randomly selected to be parent: {parentSkillId}");                

                TestContext.WriteLine($"Pretest Parents: {string.Join(",", testChildSkill.ParentSkill.Select(s => s.Id))}");
            }

            var controller = new SkillsController();
            var model = new SkillEditViewModel()
            {
                TheSkill = testChildSkill,

                SelectedParents = testChildSkill.ParentSkill
                                    .Where(j => j.Id != parentSkillId) // Exclude our selected parent skill
                                    .Select(s => s.Id),  

                PotentialParents = null
            };

            // Act
            var result = controller.Edit(model);

            // Assert
            Assert.IsInstanceOfType(result,typeof(RedirectToRouteResult));
            // How to check this?
            //Assert.AreEqual("Index", result.["action"]);
            using (var context = new SkillsDatabaseEntities())
            {
                // Assert
                var updatedChild = context.Skills.Where(s => s.Id == childSkillId).FirstOrDefault();
                Assert.IsNotNull(updatedChild);
                TestContext.WriteLine($"POST test Parents: {string.Join(",", updatedChild.ParentSkill.Select(s => s.Id))}");
                var removedParent = updatedChild.ParentSkill.Where(s => s.Id == parentSkillId).FirstOrDefault();
                Assert.IsNull(removedParent);
            }

            // Cleanup
            using (var context = new SkillsDatabaseEntities())
            {
                // TODOSKILL iterating elements of a collection in linq.
                // TODOSKILL learn when you should use explicit loading versus lazy loading to
                // reduce database trips and make execution more efficient, such as when you know you
                // are going to need the data immediately.  As seen here using explicit loading with the .Include().
                //var skill = context.Skills.Where(s => s.Id == childSkillId).FirstOrDefault();
                var skill = context.Skills.Include(s => s.ParentSkill).FirstOrDefault(s => s.Id == childSkillId);

                var parentSkillsToRemove = skill.ParentSkill.Where(ps => testParentSkill.Id == ps.Id).ToList();

                foreach (var parentSkill in parentSkillsToRemove)
                {
                    skill.ParentSkill.Remove(parentSkill);
                }

                context.SaveChanges();
                TestContext.WriteLine($"Cleanup added Parents: {string.Join(",", testParentSkill.Id)}");
            }
        }
        [TestMethod()]
        public void EditPostAddMultiParentTest()
        {
            int childSkillId;
            Skill testChildSkill;
            List<int> parentIds = new List<int>();
            List<int> addedParents = new List<int>();
            using (var context = new SkillsDatabaseEntities())

            {
                // Arrange
                // Get random skill
                testChildSkill = ModelHelper.GetRandomSkillExcluding(context.Skills, 1, new int[] { }).FirstOrDefault();
                childSkillId = testChildSkill.Id;
                TestContext.WriteLine($"Test child skill: {testChildSkill.name}, Id: {childSkillId} and parents: {string.Join(",", testChildSkill.ParentSkill.Select(s => s.Id))}");

                // Get 3 other skills not currently parents
                addedParents.AddRange(ModelHelper.GetRandomSkillExcluding(context.Skills, 3, 
                    testChildSkill.ParentSkill.Select(s => s.Id).ToList()).Select(s => s.Id));

                parentIds.AddRange(addedParents);
                parentIds.AddRange(testChildSkill.ParentSkill.Select(s => s.Id));

                TestContext.WriteLine($"With Added Parents: {string.Join(",", parentIds)}");
            }

            var controller = new SkillsController();
            var model = new SkillEditViewModel()
            {
                TheSkill = testChildSkill,

                SelectedParents = parentIds,

                PotentialParents = null
            };
            
            // Act
            var result = controller.Edit(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            using (var context = new SkillsDatabaseEntities())
            {
                var updatedChild = context.Skills.Where(s => s.Id == childSkillId).FirstOrDefault();
                Assert.IsNotNull(updatedChild);

                TestContext.WriteLine($"POST test Parents: {string.Join(",", updatedChild.ParentSkill.Select(s => s.Id))}");

                bool bAll = parentIds.All(id => updatedChild.ParentSkill.Select(s => s.Id).Contains(id));
                
                Assert.IsTrue(bAll, $"Added parent skill is not present");
            }

            // Cleanup
            using (var context = new SkillsDatabaseEntities())
            {

                // TODOSKILL iterating elements of a collection in linq.
                // TODOSKILL learn when you should use explicit loading versus lazy loading to
                // reduce database trips and make execution more efficient, such as when you know you
                // are going to need the data immediately.  As seen here using explicit loading with the .Include().
                //var skill = context.Skills.Where(s => s.Id == childSkillId).FirstOrDefault();
                var skill = context.Skills.Include(s => s.ParentSkill).FirstOrDefault(s => s.Id == childSkillId);

                var parentSkillsToRemove = skill.ParentSkill.Where(ps => addedParents.Contains(ps.Id)).ToList();

                foreach (var parentSkill in parentSkillsToRemove)
                {
                    skill.ParentSkill.Remove(parentSkill);
                }

                context.SaveChanges();
                TestContext.WriteLine($"Cleanup added Parents: {string.Join(",", addedParents)}");
            }
        }
        [TestMethod()]
        public void EditPostInvalidModelStateTest()
        {
            // Arrange
            var controller = new SkillsController();
            var model = new SkillEditViewModel();
            controller.ModelState.AddModelError("KEY", "An Error Message");

            // Act
            var result = controller.Edit(model);

            // Assert
            Assert.IsFalse(controller.ModelState.IsValid);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [Ignore]
        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        // Test various delete scenarios
        // Self parent, delete parent, delete child
        [Ignore]
        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            
            Assert.Fail();
        }
    }
}