using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewsWebApp.Models;

namespace NewsWebApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PostTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PostTypes
        public ActionResult Index()
        {
            return View(db.PostTypes.ToList());
        }

        // GET: PostTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostType postType = db.PostTypes.Find(id);
            if (postType == null)
            {
                return HttpNotFound();
            }
            return View(postType);
        }

        // GET: PostTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ArticleType")] PostType postType)
        {
            if (ModelState.IsValid)
            {
                db.PostTypes.Add(postType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postType);
        }

        // GET: PostTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostType postType = db.PostTypes.Find(id);
            if (postType == null)
            {
                return HttpNotFound();
            }
            return View(postType);
        }

        // POST: PostTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ArticleType")] PostType postType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postType);
        }

        // GET: PostTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostType postType = db.PostTypes.Find(id);
            if (postType == null)
            {
                return HttpNotFound();
            }
            return View(postType);
        }

        // POST: PostTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostType postType = db.PostTypes.Find(id);
            db.PostTypes.Remove(postType);
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
