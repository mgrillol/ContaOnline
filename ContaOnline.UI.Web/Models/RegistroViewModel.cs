using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ContaOnline.UI.Web.Models
{
    public class RegistroViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
    }
}