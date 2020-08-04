using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsExemploClient
{
    public enum PagarReceber { Pagar = 1, Receber = 2}
    class ContaListItem
    {
        public DateTime Data { get; set; }
        public PagarReceber Tipo { get; set; }
        public string Descricao { get; set; }
        public string Contato { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
    }
}
