using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EscoTestGaston.DAL;
using EscoTestGaston.Models;

namespace EscoTestGaston.Controllers
{
    public class AutoController : Controller
    {
        private EscoTestGastonContext db = new EscoTestGastonContext();

        // GET: Auto
        public ActionResult Index()
        {
            var autos = db.Autos.Include(a => a.Propietario).Include(a => a.Servicio);
            return View(autos.ToList());
        }

        // GET: Auto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autos.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: Auto/Create
        public ActionResult Create()
        {
            ViewBag.PropietarioID = new SelectList(db.Propietarios, "ID", "Apellido");
            ViewBag.ServicioID = new SelectList(db.Servicios, "ID", "TipoServicio");
            return View();
        }

        // POST: Auto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ServicioID,PropietarioID,Marca,Anio,Patente")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Autos.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropietarioID = new SelectList(db.Propietarios, "ID", "Apellido", auto.PropietarioID);
            ViewBag.ServicioID = new SelectList(db.Servicios, "ID", "TipoServicio", auto.ServicioID);
            return View(auto);
        }

        // GET: Auto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autos.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropietarioID = new SelectList(db.Propietarios, "ID", "Apellido", auto.PropietarioID);
            ViewBag.ServicioID = new SelectList(db.Servicios, "ID", "TipoServicio", auto.ServicioID);
            return View(auto);
        }

        // POST: Auto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ServicioID,PropietarioID,Marca,Anio,Patente")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropietarioID = new SelectList(db.Propietarios, "ID", "Apellido", auto.PropietarioID);
            ViewBag.ServicioID = new SelectList(db.Servicios, "ID", "TipoServicio", auto.ServicioID);
            return View(auto);
        }

        // GET: Auto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autos.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Auto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto auto = db.Autos.Find(id);
            db.Autos.Remove(auto);
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
