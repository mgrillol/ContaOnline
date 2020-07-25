using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContaOnline.UI.Web.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public string Mensagem { get; set; }

    }
}