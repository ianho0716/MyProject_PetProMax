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
    public class FindPetsController : Controller
    {
        private PetproContext db = new PetproContext();

        // GET: FindPets
        public ActionResult Index(int page = 1)
        {
            var findPets = db.FindPets.ToList();

            int pagesize = 15;


            var pagedList = findPets.ToPagedList(page, pagesize);

            return View(pagedList);
        }
                
        public ActionResult Show(int page = 1)
        {
            var findPets = db.FindPets.ToList();

            int pagesize = 15;


            var pagedList = findPets.ToPagedList(page, pagesize);

            return View(pagedList);
        }

        // GET: FindPets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FindPet findPet = db.FindPets.Find(id);
            if (findPet == null)
            {
                return HttpNotFound();
            }
            return View(findPet);
        }

        // GET: FindPets/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName");
            return View();
        }

        // POST: FindPets/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FindPetID,PetName,PetSex,PetType,PetBreed,PetTsmc,PetPhotoFile,LostDate,PetDescription,MemberID")] FindPet findPet, HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                if (photo.ContentLength > 0)
                {
                    string extensionName = System.IO.Path.GetExtension(photo.FileName);
                    if (extensionName == ".jpg" || extensionName == ".png")
                    {
                        photo.SaveAs(Server.MapPath("~/PetPhotos/" + findPet.PetName + extensionName));

                        findPet.PetPhotoFile = findPet.PetName + extensionName;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                findPet.MemberID = ((Members)Session["user"]).MemberID;
                db.FindPets.Add(findPet);
                db.SaveChanges();
                TempData["Message"] = "走失寵物資料已新增成功，願早日重逢!!!";
                return RedirectToAction("Show");
            }

            return View();
        }


        // GET: FindPets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FindPet findPet = db.FindPets.Find(id);
            if (findPet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", findPet.MemberID);
            return View(findPet);
        }

        // POST: FindPets/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FindPetID,PetName,PetSex,PetType,PetBreed,PetTsmc,PetPhotoFile,LostDate,PetDescription,MemberID")] FindPet findPet, HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                if (photo.ContentLength > 0)
                {
                    string extensionName = System.IO.Path.GetExtension(photo.FileName);
                    if (extensionName == ".jpg" || extensionName == ".png")
                    {
                        photo.SaveAs(Server.MapPath("~/PetPhotos/" + findPet.PetName + extensionName));

                        findPet.PetPhotoFile = findPet.PetName + extensionName;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                findPet.MemberID = ((Members)Session["user"]).MemberID;
                db.Entry(findPet).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "走失寵物資料已更新成功，願早日重逢!!!";
                return RedirectToAction("Show");
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", findPet.MemberID);
            return View(findPet);
        }

        // GET: FindPets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FindPet findPet = db.FindPets.Find(id);
            if (findPet == null)
            {
                return HttpNotFound();
            }
            return View(findPet);
        }

        // POST: FindPets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FindPet findPet = db.FindPets.Find(id);
            db.FindPets.Remove(findPet);
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
