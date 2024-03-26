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

        [TestMethod()]
        public void IndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

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
            using (var context = new SkillsDatabaseEntities())

            {
                // Arrange
                // Ga random skill
                testChildSkill = ModelHelper.GetRandomSkillExcluding(context.Skills,1, new int[] { }).FirstOrDefault();
                childSkillId = testChildSkill.Id;
                TestContext.WriteLine($"Test child skill: {testChildSkill.name}, Id: {childSkillId} and parents: {string.Join(",",testChildSkill.ParentSkill.Select(s => s.Id))}");

                // Are there any parent Skills, pick a random one to delete or if none, add one.
                if(testChildSkill.ParentSkill.Count() > 0)
                {
                    parentSkillId = ModelHelper.GetRandomSkillFromCollection(testChildSkill.ParentSkill).FirstOrDefault().Id;
                    TestContext.WriteLine($"Randomly selected to be parent: {parentSkillId}");
                }
                else
                {
                    testParentSkill = ModelHelper.GetRandomSkillExcluding(context.Skills, 1, new int[] { childSkillId }).FirstOrDefault();
                    Assert.IsNotNull(testParentSkill, "No parent skill determined.  Check skills in DB exist.");
                    parentSkillId = testParentSkill.Id;

                    testChildSkill.ParentSkill.Add(testParentSkill);
                    context.SaveChanges();
                    TestContext.WriteLine($"Randomly selected to be parent: {parentSkillId}");
                }

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
            var retVal = controller.Edit(model);
            Assert.IsInstanceOfType(retVal,typeof(RedirectToRouteResult));
            // How to check this?
            //Assert.AreEqual("Index", retVal.["action"]);
            using (var context = new SkillsDatabaseEntities())
            {
                // Assert
                var updatedChild = context.Skills.Where(s => s.Id == childSkillId).FirstOrDefault();
                Assert.IsNotNull(updatedChild);
                TestContext.WriteLine($"POST test Parents: {string.Join(",", updatedChild.ParentSkill.Select(s => s.Id))}");
                var removedParent = updatedChild.ParentSkill.Where(s => s.Id == parentSkillId).FirstOrDefault();
                Assert.IsNull(removedParent);
            }
        }
        [TestMethod()]
        public void EditPostAddMultiParentTest()
        {
            int childSkillId;
            Skill testChildSkill;
            List<int> parentIds = new List<int>();
            using (var context = new SkillsDatabaseEntities())

            {
                // Arrange
                // Get random skill
                testChildSkill = ModelHelper.GetRandomSkillExcluding(context.Skills, 1, new int[] { }).FirstOrDefault();
                childSkillId = testChildSkill.Id;
                TestContext.WriteLine($"Test child skill: {testChildSkill.name}, Id: {childSkillId} and parents: {string.Join(",", testChildSkill.ParentSkill.Select(s => s.Id))}");

                // Get 3 other skills
                parentIds.AddRange(ModelHelper.GetRandomSkillExcluding(context.Skills, 3, 
                    testChildSkill.ParentSkill.Select(s => s.Id).ToList()).Select(s => s.Id));

                parentIds.AddRange(testChildSkill.ParentSkill.Select(s => s.Id));

                TestContext.WriteLine($"Pretest Parents: {string.Join(",", parentIds)}");
            }

            // Act
            var controller = new SkillsController();
            var model = new SkillEditViewModel()
            {
                TheSkill = testChildSkill,

                SelectedParents = parentIds,

                PotentialParents = null
            };            
            var retVal = controller.Edit(model);

            Assert.IsInstanceOfType(retVal, typeof(RedirectToRouteResult));
            // How to check this?
            //Assert.AreEqual("Index", retVal.["action"]);

            using (var context = new SkillsDatabaseEntities())
            {
                // Assert
                var updatedChild = context.Skills.Where(s => s.Id == childSkillId).FirstOrDefault();
                Assert.IsNotNull(updatedChild);

                TestContext.WriteLine($"POST test Parents: {string.Join(",", updatedChild.ParentSkill.Select(s => s.Id))}");

                bool bAll = parentIds.All(id => updatedChild.ParentSkill.Select(s => s.Id).Contains(id));
                
                Assert.IsTrue(bAll, $"Added parent skill is not present");
                
            }
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }
    }
}