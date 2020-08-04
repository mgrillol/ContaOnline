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
        // GET api/<controller>
        public List<ContaListItem> Get()
        {
            var repositorio = new ContaRepository();
            ContaListViewModel viewModel = new ContaListViewModel();

            viewModel.Filtro.UsuarioId = "admin";
            viewModel.Filtro.DataInicial = new DateTime(DateTime.Now.Year, 6, 1);
            viewModel.Filtro.DataFinal = DateTime.Now;

            viewModel.ContaList = repositorio.ObterPorFiltro(viewModel.Filtro).ToList();

            return viewModel.ContaList;
        }
    }
}