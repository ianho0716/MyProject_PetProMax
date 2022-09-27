using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetproMax.Models;

namespace PetproMax.Controllers
{
    public class MemberOrderController : Controller
    {
        private PetproContext db = new PetproContext();

        [ChildActionOnly]
        public ActionResult _Order()
        {
            ViewBag.PayTypeID = new SelectList(db.PayTypes, "PayTypeID", "PayTypeName");
            ViewBag.ShipID = new SelectList(db.Shippers, "ShipID", "ShipVia");
            return View();
        }

        [HttpPost]
        public ActionResult Order(string ShipName, string ShipAddress, int ShipID, int PayTypeID, string data)
        {
            //如果沒登入,導去登入
            //if (Session["user"] == null)
            //    return RedirectToAction("Login", "Home");

            int memberID = ((Members)Session["user"]).MemberID;

            //如果已登入,就寫入資料庫
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("ShipName",ShipName),
                new SqlParameter("ShipAddress",ShipAddress),
                new SqlParameter("ShipID",ShipID),
                new SqlParameter("PayTypeID",PayTypeID),
                new SqlParameter("MemberID",memberID),
                new SqlParameter("cart",data)
            };
            SetData sd = new SetData();
            sd.executeSqlBySP("addOrders", list);

            TempData["cartFlag"] = "OK";

            return RedirectToAction("MyCart", "Home");
        }
    }
}