using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.Domain.ViewModels;
using ContaOnline.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContaOnline.Services.Controllers
{
    public class ContaServiceController : ApiController
    {
        private IContaRepository repositorio;

        // GET api/<controller>
        public List<ContaListItem> Get()
        {
            ContaListViewModel viewModel = new ContaListViewModel();

            viewModel.Filtro.UsuarioId = "123Teste";
            viewModel.Filtro.DataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            viewModel.Filtro.DataFinal = DateTime.Now;

            viewModel.ContaList = repositorio.ObterPorFiltro(viewModel.Filtro).ToList();

            return viewModel.ContaList;
        }
    }
}