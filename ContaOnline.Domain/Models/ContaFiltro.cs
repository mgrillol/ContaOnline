using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Domain.Models
{
    public class ContaFiltro
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        public string UsuarioId { get; set; }

        public string ContaCorrenteId { get; set; }
        public string CategoriaId { get; set; }

    }
}
