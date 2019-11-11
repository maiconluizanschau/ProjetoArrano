using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Data;
using PorjetoUfsmArrano.Models;

namespace PorjetoUfsmArrano.Controllers
{
    public class HomeController : Controller
    {
        private UsuarioContext db = new UsuarioContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string senha)
        {
            //trata o login
            if (ModelState.IsValid)
            {
                //verifica se e valido
                Usuario v = db.Usuario.Where(a => a.login.Equals(login) &&
                    a.senha.Equals(senha)).FirstOrDefault();
                if (v != null)
                {
                    //-sessao
                    Session["usuarioLogadoID"] = v.id_usuario.ToString();
                    Session["nomeUsuarioLogado"] = v.login.ToString(); //(v.nome != null ? v.nome.ToString() : v.usuario);
                    Session["UsuarioLogado_Master"] = v.master;
                    Session["UsuarioLogado_Base"] = v.id_base;
                    

                    //--------------ideia nome implementacao -----------
                    //Session["ChaveEstrangeira"] = v.chaveestrangeira;
                    //Session["UsuarioLogado_TipoUsuario"] = v.TipoUsuario;
                  //---------------------------------------------------------

                    //cokkie
                    HttpCookie MyCookie = new HttpCookie("LastVisit");
                    DateTime now = DateTime.Now;
                    MyCookie.Value = now.ToString();
                    MyCookie.Expires = now.AddHours(1);
                    Response.Cookies.Add(MyCookie);

                    //se tudo estiver de acordo manda para a tela principal do sistema a index da home view
                    return RedirectToAction("index");
                }
            }
            ViewBag.Message = "Login e Senha Incorretos!";
            return View();
        }

        public bool estaLogado(Controller a)
        {
            if (a.Session["nomeUsuarioLogado"] == null)
            {
                if (a.Response.RedirectLocation == null)
                    a.Response.Redirect("~/Home/Login", true);
                return false;
            } return true;
        }
        public bool Master(Controller a)
        {
            if (estaLogado(a))
                return (bool)a.Session["UsuarioLogado_Master"];
            return false;
        }
        public int Base(Controller a)
        {
            if (estaLogado(a))
            {
                return (int)a.Session["UsuarioLogado_Base"];

            }
            return -1;
        }

        public ActionResult Login()
        {
            return View();

        }
        public ActionResult Logout()
        {
            //sessao
            Session["usuarioLogadoID"] = null;
            Session["nomeUsuarioLogado"] = null;
            Session["UsuarioLogado_Base"] = null;
            Session["UsuarioLogado_Master"] = null;
            return RedirectToAction("Login");
            //fim  sessao 
        }



        public ActionResult SemPermissao()
        {
            return View();
        }

    }
}


        