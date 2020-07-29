using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.Domain.ViewModels;
using ContaOnline.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContaController : Controller
    {
        private IContaRepository repositorio;
        private Usuario usuario;

        public ContaController()
        {
            repositorio = AppHelper.ObterContaRepository();
            usuario = AppHelper.ObterUsuarioLogado();
        }

        public ActionResult Incluir()
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var viewModel = new ContaViewModel();

            var contaCorrenteRepositorio = AppHelper.ObterContaCorrenteRepository();
            viewModel.ContaCorrenteList = contaCorrenteRepositorio.ObterTodos(usuario.Id).ToList();



            return View(viewModel);
        }

        public ActionResult Inicio()
        {
            if (usuario == null) return RedirectToAction("Login", "App");

            var lista = repositorio.ObterPorUsuario(usuario.Id);
            return View(lista);
        }
    }
}