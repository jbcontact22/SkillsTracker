using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkillsTracker.Models;

namespace SkillsTracker.Controllers
{
    public class DeveloperSkillsController : Controller
    {
        private SkillsDatabaseEntities db = new SkillsDatabaseEntities();

        // GET: DeveloperSkills
        public ActionResult Index()
        {
            ViewBag.DeveloperList = new SelectList(db.Developers, "Id", "name");
            var developerSkills = db.DeveloperSkills.Include(d => d.Developer).Include(d => d.Skill);
            return View(developerSkills.ToList());
        }

        // Post: DeveloperSkills
        [HttpPost]
        public ActionResult Index(string developerId)
        {
            int devId = int.Parse(developerId);
            ViewBag.DeveloperList = new SelectList(db.Developers, "Id", "name");
            var developerSkills = db.DeveloperSkills.Include(d => d.Developer).Include(d => d.Skill);
            if (null != developerId)
            {
                developerSkills = developerSkills.Where(x => x.DeveloperId == devId);
            }
            return View(developerSkills.ToList());
        }
        
        // GET: DeveloperSkills/Details/5
        public ActionResult Details(int? developerId, int? skillId)
        {
            if (developerId == null || skillId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeveloperSkill developerSkill = db.DeveloperSkills.Find(developerId,skillId);
            if (developerSkill == null)
            {
                return HttpNotFound();
            }
            return View(developerSkill);
        }

        // GET: DeveloperSkills/Create
        public ActionResult Create()
        {
            ViewBag.DeveloperId = new SelectList(db.Developers, "Id", "name");
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "skill1");
            return View();
        }

        // POST: DeveloperSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeveloperId,SkillId,SkillLevel")] DeveloperSkill developerSkill)
        {
            //var exists = db.DeveloperSkills.Find(new object[] { developerSkill.DeveloperId, developerSkill.SkillId});
            var exists = db.DeveloperSkills.Find(developerSkill.DeveloperId, developerSkill.SkillId);
            if (null != exists)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(exists).CurrentValues["SkillLevel"] = developerSkill.SkillLevel;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            if (ModelState.IsValid)
            {
                db.DeveloperSkills.Add(developerSkill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(db.Developers, "Id", "name", developerSkill.DeveloperId);
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "skill1", developerSkill.SkillId);
            return View(developerSkill);
        }

        // GET: DeveloperSkills/Edit/5
        public ActionResult Edit(int? developerId, int? skillId)
        {
            if (developerId == null || skillId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeveloperSkill developerSkill = db.DeveloperSkills.Find(developerId,skillId);
            if (developerSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeveloperId = new SelectList(db.Developers, "Id", "name", developerSkill.DeveloperId);
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "skill1", developerSkill.SkillId);
            return View(developerSkill);
        }

        // POST: DeveloperSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeveloperId,SkillId,SkillLevel")] DeveloperSkill developerSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(developerSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeveloperId = new SelectList(db.Developers, "Id", "name", developerSkill.DeveloperId);
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "skill1", developerSkill.SkillId);
            return View(developerSkill);
        }

        // GET: DeveloperSkills/Delete/5
        public ActionResult Delete(int? developerId, int? skillId)
        {
            if (developerId == null || skillId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeveloperSkill developerSkill = db.DeveloperSkills.Find(developerId,skillId);
            if (developerSkill == null)
            {
                return HttpNotFound();
            }
            return View(developerSkill);
        }

        // POST: DeveloperSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int developerId,int skillId)
        {
            DeveloperSkill developerSkill = db.DeveloperSkills.Find(developerId,skillId);
            db.DeveloperSkills.Remove(developerSkill);
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
