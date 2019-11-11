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


//no  momento o sistema apresenta 2 niveis de acesso para usuarios master e gerentes que estao
//relacionados a alguma base militar
namespace PorjetoUfsmArrano.Controllers
{
    public class TreinamentosController : Controller
    {
        private TreinamentosContext db = new TreinamentosContext();

        // GET: Treinamentos
        public ActionResult Index()
        {
            if (!new HomeController().Master(this))
            {
                int id_Base = new HomeController().Base(this);
                ViewBag.id_Base = new SelectList(db.BasesMilitares.Where(a => a.id_BasesMilitares == id_Base), "id_basesMilitares", "Nomefantasia");
            }
            else ViewBag.id_Base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia");
            return View(db.Treinamentos.ToList());
        }

        // GET: Treinamentos/Details/5
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treinamentos treinamentos = db.Treinamentos.Find(id);
            if (treinamentos == null)
            {

                return HttpNotFound();
            }
            return View(treinamentos);
        }

        // GET: Treinamentos/Create
        public ActionResult Cadastrar()
        {
            if(!new HomeController().Master(this)){
                int id_Base = new HomeController().Base(this);
                ViewBag.id_Base = new SelectList(db.BasesMilitares.Where(a => a.id_BasesMilitares == id_Base), "id_basesMilitares", "Nomefantasia");
            }
            else ViewBag.id_Base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia");
            return View();
        }

        // POST: Treinamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "id_treinamentos,nome,descricao,data,datainicio,datafim,duracao,statustreinamento,hora,tipotreinamento,id_basemilitar")] Treinamentos treinamentos)
        {
            if (ModelState.IsValid)
            {
                db.Treinamentos.Add(treinamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(treinamentos);
        }

        // GET: Treinamentos/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treinamentos treinamentos = db.Treinamentos.Find(id);
            if (treinamentos == null)
            {
                return HttpNotFound();
            }
            if (!new HomeController().Master(this))
            {
                int id_Base = new HomeController().Base(this);
                ViewBag.id_Base = new SelectList(db.BasesMilitares.Where(a => a.id_BasesMilitares == id_Base), "id_basesMilitares", "Nomefantasia");
            }
            else ViewBag.id_Base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia");
            return View(treinamentos);
        }

        // POST: Treinamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id_treinamentos,nome,descricao,data,datainicio,datafim,duracao,statustreinamento,hora,tipotreinamento,id_basemilitar")] Treinamentos treinamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treinamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (!new HomeController().Master(this))
            {
                int id_Base = new HomeController().Base(this);
                ViewBag.id_Base = new SelectList(db.BasesMilitares.Where(a => a.id_BasesMilitares == id_Base), "id_basesMilitares", "Nomefantasia");
            }
            else ViewBag.id_Base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia");
            return View(treinamentos);
        }

        // GET: Treinamentos/Delete/5
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treinamentos treinamentos = db.Treinamentos.Find(id);
            if (treinamentos == null)
            {
                return HttpNotFound();
            }
            return View(treinamentos);
        }

        // POST: Treinamentos/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarConfirmed(int id)
        {
            Treinamentos treinamentos = db.Treinamentos.Find(id);
            db.Treinamentos.Remove(treinamentos);
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

        //gerar pdf
        /*
        * Retorna a view simples em HTML, usada como modelo para gerar o PDF
        */
        public ActionResult ModeloHTML()
        {
            return View("RelatorioTreinamentoRealizados");
        }

        /*
         * Retorna um PDF diretamente no browser com as configurações padrões
         * ViewName é setado somente para utilizar o próprio Modelo anterior
         * Caso não queira setar o ViewName, você deve gerar a view com o mesmo nome da action
         */
        public ActionResult PDFPadrao()
        {
            var pdf = new ViewAsPdf
            {
                ViewName = "RelatorioTreinamentoRealizados"
            };
            return pdf;
        }

        /*
         * Configura algumas propriedades do PDF, inclusive o nome do arquivo gerado,
         * Porem agora ele baixa o pdf ao invés de mostrar no browser
         */
        public ActionResult PDFConfigurado()
        {
            var pdf = new ViewAsPdf
            {
                ViewName = "RelatorioTreinamentoRealizados",
                FileName = "RelatorioTreinamentoRealizados.pdf",
                PageSize = Size.A4,
                IsGrayScale = true,
                PageMargins = new Margins { Bottom = 5, Left = 5, Right = 5, Top = 5 },
            };
            return pdf;
        }

        public ActionResult RelatorioTreinamentoRealizados(int? pagina, Boolean? gerarPDF)
        {
            var RelatorioTreinamentoRealizados = db.Treinamentos.OrderBy(n => n.id_treinamentos).ToList<Treinamentos>();

            if (gerarPDF != true)
            {
                //Definindo a paginação              
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(RelatorioTreinamentoRealizados.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "RelatorioTreinamentoRealizados",
                    PageSize = Size.A4,
                    IsGrayScale = true,
                    Model = RelatorioTreinamentoRealizados.ToPagedList(paginaNumero, RelatorioTreinamentoRealizados.Count)
                };
                return pdf;
            }
        }



        //pesquisar por tempo mostra view 
        public ActionResult FormUsuariosFormPeriodo()
        {
            return View();
        }


        //public ActionResult TreinamentosPorPeriodo(DateTime dataInicial, DateTime dataFinal, int? pagina, Boolean? gerarPDF)
        //{
        //    var Treimento = db.Treinamentos.Where(i => i.datainicio>= dataInicial && i.datafim <= dataFinal).OrderBy(p => p.nome).ToList<Usuario>();

        //    ViewBag.dataInicial = dataInicial;
        //    ViewBag.dataFinal = dataFinal;

        //    if (gerarPDF != true)
        //    {
        //        //Definindo a paginação      
        //        int paginaQdteRegistros = 2;
        //        int paginaNumeroNavegacao = (pagina ?? 1);

        //        return View(Treinamentos.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
        //    }
        //    else
        //    {
        //        int paginaNumero = 1;

        //        var pdf = new ViewAsPdf
        //        {
        //            ViewName = "RelUsuariosPorPeriodo",
        //            PageSize = Size.A4,
        //            IsGrayScale = true,
        //            Model = Treinamentos.ToPagedList(paginaNumero, Treinamentos.Count),
        //        };
        //        return pdf;
        //    }
        //}



    }
}
