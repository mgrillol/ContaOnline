using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Domain.Models
{
    public class Pessoa:Contato
    {
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
