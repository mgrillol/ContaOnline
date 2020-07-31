using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Domain.Models
{
    public class ContaListViewModel
    {
        public List<ContaListItem> ContaList { get; set; }
        public ContaFiltro Filtro { get; set; }
        public List<ContaCategoria> CategoriaList { get; set; }
        public List<ContaCorrente> ContaCorrenteList { get; set; }

        public ContaListViewModel()
        {
            this.ContaList = new List<ContaListItem>();
            this.Filtro = new ContaFiltro();
            this.CategoriaList = new List<ContaCategoria>();
            this.ContaCorrenteList = new List<ContaCorrente>();
        }
    }
}
