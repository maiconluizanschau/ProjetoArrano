using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PagedList;
using Rotativa;
using Rotativa.Options;
using RazorPDF;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using PorjetoUfsmArrano.Models;

namespace PorjetoUfsmArrano.Controllers
{
    public class AvaliarController : Controller
    {
        private AvaliarContext db = new AvaliarContext();

        // GET: Avaliar
        public ActionResult Index(int? pagina)
        { 
             int idbasemilitar = new HomeController().Base(this);
            if (!new HomeController().Master(this))
            {
           

            var consultar = from Usuario in db.Avaliars
                            join c in db.basemilitar on Usuario.id_basemilitar equals c.id_BasesMilitares
                            where c.id_BasesMilitares == idbasemilitar
                            select Usuario;
                             int tamanhoPagina = 10;

                int numeroPagina = pagina ?? 1;
                return View(consultar.OrderBy(p => p.descricao).ToPagedList(numeroPagina, tamanhoPagina));  
        } 
            return View(db.Avaliars.ToList());
        }

        // GET: Avaliar/Details/5
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliar avaliar = db.Avaliars.Find(id);
            if (avaliar == null)
            {
                return HttpNotFound();
            }
            return View(avaliar);
        }

        // GET: Avaliar/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Avaliar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "id_avaliacao,nome,descricao,nota,id_militar,id_treinamento,id_basemilitar")] Avaliar avaliar)
        {
            if (ModelState.IsValid)
            {
                db.Avaliars.Add(avaliar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avaliar);
        }

        // GET: Avaliar/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliar avaliar = db.Avaliars.Find(id);
            if (avaliar == null)
            {
                return HttpNotFound();
            }
            return View(avaliar);
        }

        // POST: Avaliar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id_avaliacao,nome,descricao,nota,id_militar,id_treinamento,id_basemilitar")] Avaliar avaliar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avaliar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(avaliar);
        }

        // GET: Avaliar/Delete/5
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliar avaliar = db.Avaliars.Find(id);
            if (avaliar == null)
            {
                return HttpNotFound();
            }
            return View(avaliar);
        }

        // POST: Avaliar/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarConfirmed(int id)
        {
            Avaliar avaliar = db.Avaliars.Find(id);
            db.Avaliars.Remove(avaliar);
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



        //graficos
        public ActionResult notas()
        {
            if (!new HomeController().Master(this))
            {
                int idbasemilitar = new HomeController().Base(this);
                var consultar = from uh in db.Avaliars
                                join c in db.Avaliars on uh.id_basemilitar equals c.id_basemilitar
                                
                                where c.id_basemilitar == idbasemilitar
                                select uh;
                ViewBag.id_base = new SelectList(db.Avaliars, "id_basesMilitares", "Nomefantasia");
            }
           
            return View();
        }
    }
}
