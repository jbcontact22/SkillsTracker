using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkillsTracker.Models;
using SkillsTracker.Models.ViewModels;

namespace SkillsTracker.Controllers
{
    public class SkillsController : Controller
    {
        private SkillsDatabaseEntities db = new SkillsDatabaseEntities();

        // GET: PotentialParents
        public ActionResult Index()
        {
            return View(db.Skills.OrderBy(s => s.name).ToList());
        }

        // GET: PotentialParents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var skill = db.Skills.Where(t => t.Id == id).FirstOrDefault();
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // GET: PotentialParents/Create
        public ActionResult Create()
        {
            var skillsList = db.Skills.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.name
            }).OrderBy(s => s.Text).ToList();

            var viewModel = new SkillCreateViewModel
            {
                PotentialParents = skillsList
            };

            return View(viewModel);
        }

        // POST: PotentialParents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SkillCreateViewModel skillVM)
        {
            if (ModelState.IsValid)
            {
                if (null != skillVM.SelectedParents)
                {
                    var selSkills = db.Skills.Where(s => skillVM.SelectedParents.Contains(s.Id));

                    foreach (var parent in selSkills)
                    {
                        skillVM.TheSkill.ParentSkill.Add(parent);
                    }
                }

                db.Skills.Add(skillVM.TheSkill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Reload PotentialParents if model validation fails
            var skillsList = db.Skills.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.name
            }).OrderBy(s => s.Text).ToList();

            var viewModel = new SkillCreateViewModel
            {
                PotentialParents = skillsList
            };

            return View(viewModel);
        }

        // GET: PotentialParents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Include(s => s.ParentSkill).Where(t => t.Id == id).FirstOrDefault();
            if (skill == null)
            {
                return HttpNotFound();
            }

            // Reload PotentialParents if model validation fails
            var skillsList = db.Skills.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.name
            }).OrderBy(s => s.Text).ToList();

            var evm = new SkillEditViewModel
            {
                TheSkill = skill,
                SelectedParents = skill.ParentSkill.Select(ps => ps.Id),
                PotentialParents = skillsList
            };
            return View(evm);
        }

        // POST: PotentialParents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SkillEditViewModel skillVM)
        {
            if (ModelState.IsValid)
            {
                var skillToUpdate = db.Skills.Include(s => s.ParentSkill).SingleOrDefault(s => s.Id == skillVM.TheSkill.Id);

                // Update skill fields here
                skillToUpdate.description = skillVM.TheSkill.description;
                skillToUpdate.name = skillVM.TheSkill.name;
                skillToUpdate.link = skillVM.TheSkill.link;

                // Update the ParentSkill field 
                skillToUpdate.ParentSkill.Clear();
                if (null != skillVM.SelectedParents)
                {
                    var selSkills = db.Skills.Where(s => skillVM.SelectedParents.Contains(s.Id));

                    foreach (var parent in selSkills)
                    {
                        skillToUpdate.ParentSkill.Add(parent);
                    }
                }

                db.Entry(skillToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Reload PotentialParents if model validation fails
            var skillsList = db.Skills.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.name
            }).OrderBy(s => s.Text).ToList();

            skillVM.PotentialParents = skillsList;

            return View(skillVM);
        }

        // GET: PotentialParents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var skill = db.Skills.Include(s => s.ParentSkill).Where(m => m.Id == id).FirstOrDefault();

            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: PotentialParents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skill skill = db.Skills.Find(id);
            db.Skills.Remove(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
