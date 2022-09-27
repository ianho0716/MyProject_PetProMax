using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetproMax.Models;

namespace PetproMax.Controllers
{
    public class HomeController : Controller
    {
        PetproContext db = new PetproContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuyAdmin()
        {
            return View();
        }

        [LoginCheck]
        public ActionResult ProductList()
        {
            var products = db.Products.Where(p => p.Discontinued == false).ToList();

            return View(products);
        }

        [LoginCheck]
        public ActionResult MyCart()
        {

            return View();
        }

    }
}