using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Domain.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public List<string> Validar()
        {
            var list = new List<String>();

            if (string.IsNullOrEmpty(Nome))
            {
                list.Add("O nome deve ser informado");
            }
            if (string.IsNullOrEmpty(Email))
            {
                list.Add("O Email deve ser informado");
            }
            if (string.IsNullOrEmpty(Senha) || Senha.Length<5)
            {
                list.Add("A senha deve ter 5 caracteres no minimo");
            }

            return list;
        }
    }
}
