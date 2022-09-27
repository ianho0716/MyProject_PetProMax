﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetproMax.Models;
using PagedList;
using System.Configuration;

namespace PetproMax.Controllers
{
    
    public class MembersController : Controller
    {
        private PetproContext db = new PetproContext();

        // GET: Members
        public ActionResult Index(int page = 1)
        {
            var members = db.Members.ToList();

            int pagesize = 15;


            var pagedList = members.ToPagedList(page, pagesize);

            return View(pagedList);
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,MemberName,Gender,MemberBirthday,CreatedDate,Account,Password")] Members members)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(members);
                db.SaveChanges();
                TempData["Message"] = "會員已註冊成功，請重新登入!!!";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // POST: Members/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Members members)
        {
            string sql = "update members set MemberName=@MemberName, Gender=@Gender, MemberBirthday=@MemberBirthday where MemberID=@MemberID";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetproConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MemberName", members.MemberName);
            cmd.Parameters.AddWithValue("@Gender", members.Gender);
            cmd.Parameters.AddWithValue("@MemberBirthday", members.MemberBirthday);
            cmd.Parameters.AddWithValue("@MemberID", members.MemberID);



            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                TempData["Message"] = "會員資料已修改成功，請重新登入!!!";
                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            conn.Close();

            return View(members);
            
            //if (ModelState.IsValid)
            //{
            //    db.Entry(members).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(members);
        }        

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Members members = db.Members.Find(id);
            db.Members.Remove(members);
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
