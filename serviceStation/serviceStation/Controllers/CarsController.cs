using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using serviceStation.Models;
using serviceStation.DAL;

namespace serviceStation.Controllers
{
    public class CarsController : Controller
    {
        private ServiceStationContext db = new ServiceStationContext();

        // GET: Cars/Details/5
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            HttpCookie cookie = new HttpCookie("Client", id.ToString());
            Response.Cookies.Add(cookie);
            return View(client);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            if (Request.Cookies["Client"] != null)
            {
                ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", Convert.ToInt32(Request.Cookies["Client"].Value));
                return View();
            }
            else return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Cars/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,Make,Model,Year,Vin,ClientId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = car.ClientId});
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", car.ClientId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", car.ClientId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarId,Make,Model,Year,Vin,ClientId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = car.ClientId});
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", car.ClientId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            if (car.Orders.Count == 0)
            { 
                db.Cars.Remove(car);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = car.ClientId });
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
