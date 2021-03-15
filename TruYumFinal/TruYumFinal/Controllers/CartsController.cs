using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TruYumFinal.Models;

namespace TruYumFinal.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private TruYumContext1 db = new TruYumContext1();

        // GET: Carts
        public ActionResult Index()
        {
            var carts = db.Carts.Include(c => c.MenuItem);

            if (carts.Count() != 0)
            {

               var totalPrice = (from m in db.MenuItems
                                  join c in db.Carts on m.MenuItemId equals c.MenuItemId
                                  select m.Price).Sum();


                ViewBag.Msg = "Total Amount is Rs " + totalPrice;
            }
            
            return View(carts.ToList());
            
        }

        //// GET: Carts/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cart cart = db.Carts.Find(id);
        //    if (cart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cart);
        //}

        //// GET: Carts/Create
        //public ActionResult Create()
        //{
        //    ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "Name");
        //    return View();
        //}

        //// POST: Carts/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CartId,MenuItemId")] Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Carts.Add(cart);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "Name", cart.MenuItemId);
        //    return View(cart);
        //}

        //// GET: Carts/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cart cart = db.Carts.Find(id);
        //    if (cart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "Name", cart.MenuItemId);
        //    return View(cart);
        //}

        //// POST: Carts/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CartId,MenuItemId")] Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cart).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "Name", cart.MenuItemId);
        //    return View(cart);
        //}

        //// GET: Carts/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cart cart = db.Carts.Find(id);
        //    if (cart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cart);
        //}

        //// POST: Carts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Cart cart = db.Carts.Find(id);
        //    db.Carts.Remove(cart);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //deleteFromFrontEnd
        public ActionResult Del(int id)
        {
            Cart m = db.Carts.Find(id);
            db.Carts.Remove(m);
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
