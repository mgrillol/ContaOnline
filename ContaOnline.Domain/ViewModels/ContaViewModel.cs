using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Domain.ViewModels
{
    public class ContaViewModel
    {
        public Conta ContaInstancia { get; set; }
        public List<ContaCorrente> ContaCorrenteList { get; set; }
        public List<ContaCategoria> ContaCategoriaList { get; set; }
        public List<Contato> ContatoList { get; set; }

        public ContaViewModel()
        {
            this.ContaCategoriaList = new List<ContaCategoria>();
            this.ContaCorrenteList = new List<ContaCorrente>();
            this.ContatoList = new List<Contato>();
            this.ContaInstancia = new Conta();
        }
    }
}
