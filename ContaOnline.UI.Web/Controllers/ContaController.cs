using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.Domain.ViewModels;
using ContaOnline.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public ActionResult Excluir(string Id)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var conta = repositorio.ObterExibirPorId(Id);
            return View(conta);
        }

        [HttpPost]
        public ActionResult Excluir(String Id, ContaViewModel viewModel)
        {
            repositorio.Excluir(Id);
            return RedirectToAction("Inicio");
        }

        public ActionResult Alterar(string Id)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var viewModel = new ContaViewModel();

            viewModel.ContaInstancia = repositorio.ObterPorId(Id);

            PreencherViewModel(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Alterar(ContaViewModel viewModel)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            try
            {
                viewModel.ContaInstancia.UsuarioId = usuario.Id;
                repositorio.Alterar(viewModel.ContaInstancia);
                return RedirectToAction("Inicio");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        public ActionResult Incluir()
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            var viewModel = new ContaViewModel();

            PreencherViewModel(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Incluir(ContaViewModel viewModel)
        {
            if (usuario == null) return RedirectToAction("Login", "App");
            try
            {
                viewModel.ContaInstancia.UsuarioId = usuario.Id;
                viewModel.ContaInstancia.Id = Guid.NewGuid().ToString();
                repositorio.Incluir(viewModel.ContaInstancia);
                return RedirectToAction("Inicio");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        private void PreencherViewModel(ContaViewModel viewModel)
        {
            var contaCorrenteRepositorio = AppHelper.ObterContaCorrenteRepository();
            viewModel.ContaCorrenteList = contaCorrenteRepositorio.ObterTodos(usuario.Id).ToList();

            var contaCategoriaRepositorio = AppHelper.ObterContaCategoriaRepository();
            viewModel.ContaCategoriaList = contaCategoriaRepositorio.ObterTodos(usuario.Id).ToList();

            var contatoRepositorio = AppHelper.ObterContatoRepository();
            viewModel.ContatoList = contatoRepositorio.ObterTodos(usuario.Id).ToList();
        }

        public ActionResult Inicio()
        {
            if (usuario == null) return RedirectToAction("Login", "App");

            var lista = repositorio.ObterPorUsuario(usuario.Id);
            return View(lista);
        }
    }
}