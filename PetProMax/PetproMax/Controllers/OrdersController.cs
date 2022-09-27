using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetproMax.Models;

namespace PetproMax.Controllers
{
    public class OrdersController : Controller
    {
        private PetproContext db = new PetproContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Employee).Include(o => o.Member).Include(o => o.PayType).Include(o => o.Shipper);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        //// GET: Orders/Create
        //public ActionResult Create()
        //{
        //    ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
        //    ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName");
        //    ViewBag.PayTypeID = new SelectList(db.PayTypes, "PayTypeID", "PayTypeName");
        //    ViewBag.ShipID = new SelectList(db.Shippers, "ShipID", "ShipVia");
        //    return View();
        //}

        //// POST: Orders/Create
        //// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        //// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "OrderID,OrderDate,ShipName,ShipAddress,ShippedDate,ShipID,PayTypeID,EmployeeID,MemberID")] Orders orders)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Orders.Add(orders);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", orders.EmployeeID);
        //    ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", orders.MemberID);
        //    ViewBag.PayTypeID = new SelectList(db.PayTypes, "PayTypeID", "PayTypeName", orders.PayTypeID);
        //    ViewBag.ShipID = new SelectList(db.Shippers, "ShipID", "ShipVia", orders.ShipID);
        //    return View(orders);
        //}

        // GET: Orders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", orders.EmployeeID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", orders.MemberID);
            ViewBag.PayTypeID = new SelectList(db.PayTypes, "PayTypeID", "PayTypeName", orders.PayTypeID);
            ViewBag.ShipID = new SelectList(db.Shippers, "ShipID", "ShipVia", orders.ShipID);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderDate,ShipName,ShipAddress,ShippedDate,ShipID,PayTypeID,EmployeeID,MemberID")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", orders.EmployeeID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", orders.MemberID);
            ViewBag.PayTypeID = new SelectList(db.PayTypes, "PayTypeID", "PayTypeName", orders.PayTypeID);
            ViewBag.ShipID = new SelectList(db.Shippers, "ShipID", "ShipVia", orders.ShipID);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
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
