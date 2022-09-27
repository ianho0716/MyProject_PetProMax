using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetproMax.Models;

namespace PetproMax.Controllers
{

    public class HomeManagerController : Controller
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
        public ActionResult Login(VMLogin vMLogin)
        {
            //select * from Employee where account=@account and password=@password
            var admin = db.Employees.Where(m => m.Account == vMLogin.Account && m.Password == vMLogin.Password).FirstOrDefault();

            if (admin == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有錯!!";
                return View(vMLogin);
            }

            Session["admin"] = admin;
            return RedirectToAction("Index");


        }

        [LoginCheck]
        public ActionResult Logout()
        {

            Session["admin"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}