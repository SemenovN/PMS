using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.Projects.Include(o => o.ProjectVelue);
            ViewBag.ProjectVelueId = new SelectList(db.ProjectVelues, "ProjectVelueId", "StatusVel", "All");
            return View(projects.ToList());
        }

        // POST: Projects
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? ProjectVelueId, DateTime PrjctBegining, DateTime PrjctEnding)
        {
            var projects = db.Projects.Include(o => o.ProjectVelue);
            if (ProjectVelueId != null && ProjectVelueId != 0) 
            {           
                projects = projects.Where(o => o.ProjectVelueId == ProjectVelueId);        
            }

            if (PrjctBegining != null)
            {
                projects = projects.Where(o => o.PrjctBegining >= PrjctBegining);
            }
            if (PrjctEnding != null)
            {
                projects = projects.Where(o => o.PrjctEnding >= PrjctEnding);
            }
            ViewBag.ProjectVelueId = new SelectList(db.ProjectVelues, "ProjectVelueId", "StatusVel");
            return View(projects);
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
           
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.ProjctManadger = new SelectList(db.Employees, "EmployeeId", "Name");
            ViewBag.ProjctWorkgroup = new MultiSelectList(db.Employees, "EmployeeId", "Name");
            ViewBag.ProjectVelueId = new SelectList(db.ProjectVelues, "ProjectVelueId", "StatusVel");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrjctId,PrjctTitle,PrjctDesc,ProjectVelueId,PrjctPriority,ProjctManadger,PrjctCustomer,PrjctExecuter,PrjctBegining,PrjctEnding,PrjctStatus")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjctManadger = new SelectList(db.Employees, "EmployeeId", "Name", project.ProjctManadger);
            ViewBag.ProjectVelueId = new SelectList(db.ProjectVelues, "ProjectVelueId", "StatusVel", project.ProjectVelueId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjctManadger = new SelectList(db.Employees, "EmployeeId", "Name", project.ProjctManadger);
            ViewBag.ProjectVelueId = new SelectList(db.ProjectVelues, "ProjectVelueId", "StatusVel", project.ProjectVelueId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrjctId,PrjctTitle,PrjctDesc,PrjctPriority,PrjctCustomer,PrjctExecuter,PrjctBegining,PrjctEnding,PrjctStatus")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjctManadger = new SelectList(db.Employees, "EmployeeId", "Name", project.ProjctManadger);
            ViewBag.ProjectVelueId = new SelectList(db.ProjectVelues, "ProjectVelueId", "StatusVel", project.ProjectVelueId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
