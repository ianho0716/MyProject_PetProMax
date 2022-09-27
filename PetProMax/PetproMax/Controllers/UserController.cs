using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetproMax.Models;

namespace PetproMax.Controllers
{

    public class UserController : Controller
    {
        PetproContext db = new PetproContext();

        [LoginCheck]
        public ActionResult Index()
        {

            return View();
        }
               

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MMLogin mMLogin)
        {
            //select * from Employee where account=@account and password=@password
            var user = db.Members.Where(m => m.Account == mMLogin.Account && m.Password == mMLogin.Password).FirstOrDefault();

            if (user == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有錯!!";
                return View(mMLogin);
            }

            Session["user"] = user;
            return RedirectToAction("Index","User");


        }

        [LoginCheck]
        public ActionResult Logout()
        {

            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}