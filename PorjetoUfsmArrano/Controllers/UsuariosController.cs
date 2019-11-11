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
    public class UsuariosController : Controller
    {
        private UsuarioContext db = new UsuarioContext();

        // GET: Usuarios
        /// <summary>
        /// 
        /// nesta index apenas vai retornar os seguintes casos se for master mostra todos os usuarios cadastrados se nao apenas os 
        /// de qual base militar o usuario vai estar relacionado caso contrario vai dar pagina de erro, com a msg sem permissao
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? pagina)
        {
            if (!new HomeController().Master(this))
            {
                int idbasemilitar = new HomeController().Base(this);
                var consultar = from Usuario in db.Usuario
                                join c in db.BasesMilitares on Usuario.id_usuario equals c.id_BasesMilitares
                                where c.id_BasesMilitares == idbasemilitar
                                select Usuario;
                int tamanhoPagina = 10;
                int numeroPagina = pagina ?? 1;
                //mostra apenas os operadores de determinada base militar
                return View(consultar.OrderBy(p => p.nome).ToPagedList(numeroPagina, tamanhoPagina));
            }
            //lista todos os usuarios das bases militares
            return View(db.Usuario.ToList());
        }


        // GET: Usuarios/Detalhes/5
        //apenas pode ver detalhes 
        public ActionResult Detalhes(int? id)
        {
           
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuario.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
             ViewBag.id_base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia");
                return View(usuario);
            }

        

        // GET: Usuarios/Cadastrar
        public ActionResult Cadastrar()
        {
            if (!new HomeController().Master(this))
            {

                int idbase = new HomeController().Base(this);
                //mostra apenas as bases de qual o usuario e relacionado a base
                ViewBag.id_base = new SelectList(db.BasesMilitares.Where(a => a.id_BasesMilitares == idbase), "id_basesMilitares", "Nomefantasia");
            }
            //mostra todas as bases no caso de ser master
            else ViewBag.id_base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia");
            return View();
        }

        // POST: Usuarios/Cadastrar
        // To proteger contra alguns ataques pre definidos uso  que ajuda no controle bind chamar um ponto expecifico
        // [ValidateAntiForgeryToken]-Valida que os dados de entrada a partir de um campo de formulário HTML vem do usuário que enviou os dados.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "id_usuario,nome,sobrenome,senha,id_base,master,email,telefone,data,login")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // var v = db.Usuario.Where(a => a.usuario.Equals(usuario.usuario));
                //if (!new HomeController().Master(this))
                //{
                //    // ModelState.AddModelError("Usuario", "Este usuário já foi cadastrado para outra Pessoa.");
                //    int idbasemilitar = new HomeController().Base(this);
                //    ViewBag.id_base = new SelectList(db.BasesMilitares.Where(a => a.id_BasesMilitares == idbasemilitar), "id_basesMilitares", "Nomefantasia");
                //}
                //else
                //   if (!new HomeController().Master(this))
                //    {

                //   int idbase = new HomeController().Base(this);
                //mostra apenas as bases de qual o usuario e relacionado a base
                //     ViewBag.id_base = new SelectList(db.BasesMilitares.Where(a => a.id_BasesMilitares == idbase), "id_basesMilitares", "Nomefantasia");
                //   }
                //mostra todas as bases no caso de ser master
                //   else ViewBag.id_base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia");
                //  return View();
                //{


                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (!new HomeController().Master(this))
            {
                int idbase = new HomeController().Base(this);
                ViewBag.id_base = new SelectList(db.BasesMilitares.Where(a => a.id_BasesMilitares == idbase), "id_basesMilitares", "Nomefantasia");
            }
            else

                ViewBag.id_base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia");

            // }
            //  ViewBag.id_base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia");
            return View(usuario);
        }

        // GET: Usuarios/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }


            if (!new HomeController().Master(this))
            {
                int idbasemilitar = new HomeController().Base(this);
                ViewBag.id_base = new SelectList(db.BasesMilitares.Where(a => a.id_BasesMilitares == idbasemilitar), "id_basesMilitares", "Nomefantasia");
            }
            else
                ViewBag.id_base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia");
            return View(usuario);
        }



        // POST: Usuarios/Ediart/5
        // To proteger contra alguns ataques pre definidos uso  que ajuda no controle bind chamar um ponto expecifico
        // [ValidateAntiForgeryToken]-Valida que os dados de entrada a partir de um campo de formulário HTML vem do usuário que enviou os dados.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id_usuario,senha,id_base,master,email,telefone,nome,sobrenome,data,login")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (!new HomeController().Master(this))
            {
                int idbasemilitar = new HomeController().Base(this);
                var consultar = from uh in db.Usuario
                                join c in db.BasesMilitares on uh.id_base equals c.id_BasesMilitares
                                where c.id_BasesMilitares == idbasemilitar
                                select uh;
                ViewBag.id_base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia", usuario.id_base);
            }
            else
                ViewBag.id_base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia");
            return View(usuario);
        }


        //public ActionResult FormUsuariosPeriodo()
        //{
        //    switch (!new HomeController().Master(this))
        //    {
        //        case 0: ViewBag.id_base = new SelectList(db.BasesMilitares, "id_basesMilitares", "Nomefantasia"); break;
        //        case 1:


        //    }
        //    return View();
        //}


        ////gerar pdf
        //public ActionResult Relatorio(DateTime data,DateTime fim, int id_base, int? pagina)
        //{
        //    List<Usuario> ListagemUsuarios;
        //    switch (!new HomeController().Master(this))
        //    {
        //        case 1:
        //        case 0:
        //            ListagemUsuarios = db.Usuario.SqlQuery(@"select * from usuario where id_basesMilitares=" + id_base + "and data between '" + data.ToString("yyyy-MM-dd HH:mm:ss") + "' and '"
        //                     + fim.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("yyyy-MM-dd HH:mm:ss") + "'").ToList();

        //            break;
        //        default:
        //            ListagemUsuarios = null;
        //            break;
        //    }
        //    int paginaQtdeRegistros = 10;
        //    int paginaNumeroNavegacao = (pagina ?? 1);

        //    ViewBag.inicio = data.ToString("dd/MM/yyyy");
        //    return View(ListagemUsuarios.ToList());
        //}




        // GET: Usuarios/Deletar/5
        public ActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             Usuario usuario = db.Usuario.Find(id);
            
                 if (usuario == null)
                 {
                     return HttpNotFound();
                 }
                 return View(usuario);
             }
           
        // POST: Usuarios/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarConfirmed(int id)
        {
              Usuario usuario = db.Usuario.Find(id);
                db.Usuario.Remove(usuario);
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
            return View("RelatorioUsuarios");
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
                ViewName = "RelatorioUsuarios"
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
                ViewName = "RelatorioUsuarios",
                FileName = "RelatorioUsuarios.pdf",
                PageSize = Size.A4,
                IsGrayScale = true,
                PageMargins = new Margins { Bottom = 5, Left = 5, Right = 5, Top = 5 },
            };
            return pdf;
        }

        public ActionResult ListagemUsuarios(int? pagina, Boolean? gerarPDF)
        {
            var listagemUsuarios = db.Usuario.OrderBy(n => n.id_usuario).ToList<Usuario>();

            if (gerarPDF != true)
            {
                //Definindo a paginação              
                int paginaQdteRegistros = 10;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(listagemUsuarios.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "ListagemUsuarios",
                    PageSize = Size.A4,
                    IsGrayScale = true,
                    Model = listagemUsuarios.ToPagedList(paginaNumero, listagemUsuarios.Count)
                };
                return pdf;
            }
        }



        //pesquisar por tempo mostra view 
        public ActionResult FormUsuariosFormPeriodo()
        {
            return View();
        }


        public ActionResult UsuariosPorPeriodo(DateTime dataInicial, DateTime dataFinal, int? pagina, Boolean? gerarPDF)
        {
            var usuario = db.Usuario.Where(i => i.Data >= dataInicial && i.Data <= dataFinal).OrderBy(p => p.nome).ToList<Usuario>();

            ViewBag.dataInicial = dataInicial;
            ViewBag.dataFinal = dataFinal;

            if (gerarPDF != true)
            {
                //Definindo a paginação      
                int paginaQdteRegistros = 2;
                int paginaNumeroNavegacao = (pagina ?? 1);

                return View(usuario.ToPagedList(paginaNumeroNavegacao, paginaQdteRegistros));
            }
            else
            {
                int paginaNumero = 1;

                var pdf = new ViewAsPdf
                {
                    ViewName = "RelUsuariosPorPeriodo",
                    PageSize = Size.A4,
                    IsGrayScale = true,
                    Model = usuario.ToPagedList(paginaNumero, usuario.Count),
                };
                return pdf;
            }
        }




    }
}
