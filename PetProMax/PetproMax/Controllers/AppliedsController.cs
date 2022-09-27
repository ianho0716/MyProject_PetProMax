using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetproMax.Models;
using PagedList;

namespace PetproMax.Controllers
{
    [LoginCheck]
    public class AppliedsController : Controller
    {
        private PetproContext db = new PetproContext();

        // GET: Applieds
        public ActionResult Index(int page = 1)
        {
            var applieds = db.Applied.ToList();

            int pagesize = 15;


            var pagedList = applieds.ToPagedList(page, pagesize);

            return View(pagedList);
        }
        
        public ActionResult Show(int page = 1)
        {
            var applieds = db.Applied.ToList();

            int pagesize = 15;


            var pagedList = applieds.ToPagedList(page, pagesize);

            return View(pagedList);
        }

        // GET: Applieds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applied applied = db.Applied.Find(id);
            if (applied == null)
            {
                return HttpNotFound();
            }
            return View(applied);
        }

        // GET: Applieds/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName");
            return View();
        }

        // POST: Applieds/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppliedID,AnimalID,FamiliesName,Description,MemberID")] Applied applied)
        {
            if (ModelState.IsValid)
            {
                applied.MemberID = ((Members)Session["user"]).MemberID;
                db.Applied.Add(applied);
                db.SaveChanges();
                TempData["Message"] = "認養申請資料已送出，請耐心等候管理員通知!!!";
                return RedirectToAction("Show");
            }

            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", applied.MemberID);
            return View(applied);
        }

        // GET: Applieds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applied applied = db.Applied.Find(id);
            if (applied == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", applied.MemberID);
            return View(applied);
        }

        // POST: Applieds/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppliedID,AnimalID,FamiliesName,Description,MemberID")] Applied applied)
        {
            if (ModelState.IsValid)
            {
                applied.MemberID = ((Members)Session["user"]).MemberID;
                db.Entry(applied).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "認養申請已更新成功，請耐心等候管理員通知!!!";
                return RedirectToAction("Show");
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", applied.MemberID);
            return View(applied);
        }

        // GET: Applieds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applied applied = db.Applied.Find(id);
            if (applied == null)
            {
                return HttpNotFound();
            }
            return View(applied);
        }

        // POST: Applieds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applied applied = db.Applied.Find(id);
            db.Applied.Remove(applied);
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
