using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PorjetoUfsmArrano.Models
{
    public class LembretesController : Controller
    {
        private LembretesContext db = new LembretesContext();

        // GET: Lembretes
        public ActionResult Index()
        {
            return View(db.Lembretes.ToList());
        }

        // GET: Lembretes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lembretes lembretes = db.Lembretes.Find(id);
            if (lembretes == null)
            {
                return HttpNotFound();
            }
            return View(lembretes);
        }

        // GET: Lembretes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lembretes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_lembretes,titulo,descricaosimples,DescricaoCompleta,Data,Gravado,tipolembrete,id_militar,DataInicio,DataFim")] Lembretes lembretes)
        {
            if (ModelState.IsValid)
            {
                db.Lembretes.Add(lembretes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lembretes);
        }

        // GET: Lembretes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lembretes lembretes = db.Lembretes.Find(id);
            if (lembretes == null)
            {
                return HttpNotFound();
            }
            return View(lembretes);
        }

        // POST: Lembretes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_lembretes,titulo,descricaosimples,DescricaoCompleta,Data,Gravado,tipolembrete,id_militar,DataInicio,DataFim")] Lembretes lembretes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lembretes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lembretes);
        }

        // GET: Lembretes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lembretes lembretes = db.Lembretes.Find(id);
            if (lembretes == null)
            {
                return HttpNotFound();
            }
            return View(lembretes);
        }

        // POST: Lembretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lembretes lembretes = db.Lembretes.Find(id);
            db.Lembretes.Remove(lembretes);
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
