using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Domain.Models
{
    public class Empresa:Contato
    {
        public string CNPJ { get; set; }
    }
}
