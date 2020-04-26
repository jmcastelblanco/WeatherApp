using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherA.Models;

namespace WeatherA.Controllers
{
    public class WeatherSummariesController : Controller
    {
        private WeatherAContext db = new WeatherAContext();

        // GET: WeatherSummaries
        public ActionResult Index()
        {
            return View(db.WeatherSummaries.FirstOrDefault());
        }

        // GET: WeatherSummaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeatherSummary weatherSummary = db.WeatherSummaries.Find(id);
            if (weatherSummary == null)
            {
                return HttpNotFound();
            }
            return View(weatherSummary);
        }

        // GET: WeatherSummaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeatherSummaries/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeatherSummaryID,humidity,temp,precipRate,obsTimeLocal,neighborhood,stationID")] WeatherSummary weatherSummary)
        {
            if (ModelState.IsValid)
            {
                db.WeatherSummaries.Add(weatherSummary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weatherSummary);
        }

        // GET: WeatherSummaries/Edit/5
        public ActionResult History()
        {
            return View();
        }

        // POST: WeatherSummaries/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeatherSummaryID,humidity,temp,precipRate,obsTimeLocal,neighborhood,stationID")] WeatherSummary weatherSummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weatherSummary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weatherSummary);
        }

        // GET: WeatherSummaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeatherSummary weatherSummary = db.WeatherSummaries.Find(id);
            if (weatherSummary == null)
            {
                return HttpNotFound();
            }
            return View(weatherSummary);
        }

        // POST: WeatherSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeatherSummary weatherSummary = db.WeatherSummaries.Find(id);
            db.WeatherSummaries.Remove(weatherSummary);
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
