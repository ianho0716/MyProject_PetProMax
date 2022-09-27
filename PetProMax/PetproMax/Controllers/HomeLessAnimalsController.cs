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
    public class HomeLessAnimalsController : Controller
    {
        private PetproContext db = new PetproContext();

        // GET: HomeLessAnimals
        public ActionResult Index(int page = 1)
        {
            var homeLessAnimals = db.HomeLessAnimals.ToList();

            int pagesize = 15;


            var pagedList = homeLessAnimals.ToPagedList(page, pagesize);

            return View(pagedList);
        }       
        
        public ActionResult Show(int page = 1)
        {
            var homeLessAnimals = db.HomeLessAnimals.ToList();

            int pagesize = 15;


            var pagedList = homeLessAnimals.ToPagedList(page, pagesize);

            return View(pagedList);
        }

        // GET: HomeLessAnimals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeLessAnimal homeLessAnimal = db.HomeLessAnimals.Find(id);
            if (homeLessAnimal == null)
            {
                return HttpNotFound();
            }
            return View(homeLessAnimal);
        }

        // GET: HomeLessAnimals/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName");
            return View();
        }

        // POST: HomeLessAnimals/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HomeLessAnimalID,HomeLessAnimalName,AnimalSex,Type,Breed,Tsmc,AnimalPhotoFile,GetDate,HLADescription,ExpireDate,FamilyName,MemberID")] HomeLessAnimal homeLessAnimal, HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                if (photo.ContentLength > 0)
                {
                    string extensionName = System.IO.Path.GetExtension(photo.FileName);
                    if (extensionName == ".jpg" || extensionName == ".png")
                    {
                        photo.SaveAs(Server.MapPath("~/AnimalPhotos/" + homeLessAnimal.HomeLessAnimalName + extensionName));

                        homeLessAnimal.AnimalPhotoFile = homeLessAnimal.HomeLessAnimalName + extensionName;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                homeLessAnimal.MemberID = ((Members)Session["user"]).MemberID;
                db.HomeLessAnimals.Add(homeLessAnimal);
                db.SaveChanges();
                TempData["Message"] = "中途寵物資料已新增成功，感謝您的愛心!!!";
                return RedirectToAction("Show");
            }

            return View();
        }
        //if (ModelState.IsValid)
        //{
        //    db.HomeLessAnimals.Add(homeLessAnimal);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", homeLessAnimal.MemberID);
        //return View(homeLessAnimal);
    

        // GET: HomeLessAnimals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeLessAnimal homeLessAnimal = db.HomeLessAnimals.Find(id);
            if (homeLessAnimal == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", homeLessAnimal.MemberID);
            return View(homeLessAnimal);
        }

        // POST: HomeLessAnimals/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HomeLessAnimalID,HomeLessAnimalName,AnimalSex,Type,Breed,Tsmc,AnimalPhotoFile,GetDate,HLADescription,ExpireDate,FamilyName,MemberID")] HomeLessAnimal homeLessAnimal, HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                if (photo.ContentLength > 0)
                {
                    string extensionName = System.IO.Path.GetExtension(photo.FileName);
                    if (extensionName == ".jpg" || extensionName == ".png")
                    {
                        photo.SaveAs(Server.MapPath("~/AnimalPhotos/" + homeLessAnimal.HomeLessAnimalName + extensionName));

                        homeLessAnimal.AnimalPhotoFile = homeLessAnimal.HomeLessAnimalName + extensionName;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                homeLessAnimal.MemberID = ((Members)Session["user"]).MemberID;
                db.Entry(homeLessAnimal).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "中途寵物資料已修改成功，感謝您的愛心!!!";
                return RedirectToAction("Show");
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", homeLessAnimal.MemberID);
            return View(homeLessAnimal);
        }

        // GET: HomeLessAnimals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeLessAnimal homeLessAnimal = db.HomeLessAnimals.Find(id);
            if (homeLessAnimal == null)
            {
                return HttpNotFound();
            }
            return View(homeLessAnimal);
        }

        // POST: HomeLessAnimals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeLessAnimal homeLessAnimal = db.HomeLessAnimals.Find(id);
            db.HomeLessAnimals.Remove(homeLessAnimal);
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
