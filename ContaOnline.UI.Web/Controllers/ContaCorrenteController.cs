using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContaCorrenteController : Controller
    {
        private IContaCorrenteRepository repositorio;
        private Usuario usuario;

        public ContaCorrenteController()
        {
            repositorio = AppHelper.ObterContaCorrenteRepository();
            usuario = AppHelper.ObterUsuarioLogado();
        }

        public ActionResult Excluir(string id)
        {
            var contaCorrente = repositorio.ObterPorId(id);

            return View(contaCorrente);
        }

        [HttpPost]
        public ActionResult Excluir(string id, FormCollection form)
        {
            repositorio.Excluir(id);

            return RedirectToAction("Inicio");
        }

        public ActionResult Alterar(string id)
        {
            var contaCorrente = repositorio.ObterPorId(id);

            return View(contaCorrente);
        }

        [HttpPost]
        public ActionResult Alterar(ContaCorrente contaCorrente)
        {
            if (string.IsNullOrEmpty(contaCorrente.Descricao))
            {
                ModelState.AddModelError("Descricao", "A descrição deve ser informada");
            }
            if (ModelState.IsValid)
            {
                repositorio.Alterar(contaCorrente);
                return RedirectToAction("Inicio");
            }

            return View(contaCorrente);
        }

        public ActionResult Incluir()
        {
            var contaCorrente = new ContaCorrente();
            return View(contaCorrente);
        }

        [HttpPost]
        public ActionResult Incluir(ContaCorrente contaCorrente)
        {
            if (string.IsNullOrEmpty(contaCorrente.Descricao))
            {
                ModelState.AddModelError("Descricao", "A descrição deve ser informada");
            }
            if (ModelState.IsValid)
            {
                contaCorrente.Id = Guid.NewGuid().ToString();
                contaCorrente.UsuarioId = usuario.Id;
                repositorio.Incluir(contaCorrente);
                return RedirectToAction("Inicio");
            }
            return View(contaCorrente);
        }

        // GET: ContaCorrente
        public ActionResult Inicio()
        {
            if (usuario == null) return RedirectToAction("Login", "App");

            var lista = repositorio.ObterTodos(usuario.Id);
            return View(lista);
        }
    }
}