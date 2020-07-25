using ContaOnline.UI.Web.Models;
using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class AppController : Controller
    {
        public ActionResult Registro()
        {
            var registro = new RegistroViewModel();

            return View(registro);
        }

        [HttpPost]
        public ActionResult Registro(RegistroViewModel registroViewModel)
        {
            if (string.IsNullOrEmpty(registroViewModel.Email))
            {
                ModelState.AddModelError("Email", "O email deve ser informado");
            }

            if (string.IsNullOrEmpty(registroViewModel.Senha))
            {
                ModelState.AddModelError("Senha", "A senha deve ser informado");
            }
            else
            {
                if (registroViewModel.Senha != registroViewModel.ConfirmarSenha)
                {
                    ModelState.AddModelError("ConfirmarSenha", "A senha deve ser igual");
                }
            }

            if (ModelState.IsValid)
            {
                //criando um usuario
                var usuario = new Usuario();
                usuario.Email = registroViewModel.Email;
                usuario.Senha = registroViewModel.Senha;
                usuario.Nome = registroViewModel.Nome;
                usuario.Id = Guid.NewGuid().ToString();

                //registrando este usuario criado no banco
                var usuarioRep = AppHelper.ObterUsuarioRepository();
                usuarioRep.Incluir(usuario);

                //reggistrando o usuario na sessão
                AppHelper.RegistrarUsuario(usuario);

                //redirecionando o usuario
                return RedirectToAction("inicio");
            }
            return View(registroViewModel);
        }


        public ActionResult Login()
        {var loginViewModel = new LoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            IUsuarioRepository repositorio = AppHelper.ObterUsuarioRepository();
            Usuario usuario = repositorio.ObterPorEmailSenha(loginViewModel.Email, loginViewModel.Senha);
            if (usuario == null)
            {
                loginViewModel.Mensagem = "Usuario ou senha inexistente";
            }
            else{
                AppHelper.RegistrarUsuario(usuario);
                return RedirectToAction("inicio");
            }

            return View(loginViewModel);
        }

        /// <summary>
        /// Tela Inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Inicio()
        {
            var usuario = AppHelper.ObterUsuarioLogado();
            if (usuario == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        /// <summary>
        /// Sobre este aplicativo
        /// </summary>
        /// <returns></returns>
        public ActionResult Sobre()
        {
            return View();
        }
    }
}