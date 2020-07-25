using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContaOnline.UI.Web
{
    public static class AppHelper
    {
        public static ContaRepository ObterContaRepository()
        {
            return new ContaRepository();
        }

        public static ContatoRepository ObterContatoRepository()
        {
            return new ContatoRepository();
        }

        public static ContaCategoriaRepository ObterContaCategoriaRepository()
        {
            return new ContaCategoriaRepository();
        }

        public static ContaCorrenteRepository ObterContaCorrenteRepository()
        {
            return new ContaCorrenteRepository();
        }

        public static Usuario ObterUsuarioLogado()
        {
            return (Usuario)HttpContext.Current.Session["usuario"];
        }

        public static void RegistrarUsuario(Usuario usuario)
        {
            HttpContext.Current.Session["usuario"] = usuario;
        }

        public static UsuarioRepository ObterUsuarioRepository()
        {
            return new UsuarioRepository();
        }
    }
}