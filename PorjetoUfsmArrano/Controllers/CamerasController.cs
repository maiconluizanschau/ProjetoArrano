using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PorjetoUfsmArrano.Models;

namespace PorjetoUfsmArrano.Controllers
{
    public class CamerasController : Controller
    {
        private CamerasContext db = new CamerasContext();

        // GET: Cameras
        public ActionResult Index()
        {
            return View(db.Cameras.ToList());
        }

        // GET: Cameras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cameras cameras = db.Cameras.Find(id);
            if (cameras == null)
            {
                return HttpNotFound();
            }
            return View(cameras);
        }

        // GET: Cameras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cameras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descricao,ip,login,senha,id_tipo,id_treinamentos")] Cameras cameras)
        {
            if (ModelState.IsValid)
            {
                db.Cameras.Add(cameras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cameras);
        }

        // GET: Cameras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cameras cameras = db.Cameras.Find(id);
            if (cameras == null)
            {
                return HttpNotFound();
            }
            return View(cameras);
        }

        // POST: Cameras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descricao,ip,login,senha,id_tipo,id_treinamentos")] Cameras cameras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cameras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cameras);
        }

        // GET: Cameras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cameras cameras = db.Cameras.Find(id);
            if (cameras == null)
            {
                return HttpNotFound();
            }
            return View(cameras);
        }

        // POST: Cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cameras cameras = db.Cameras.Find(id);
            db.Cameras.Remove(cameras);
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
