using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContaOnline.Domain.Models;
using ContaOnline.Repository;

namespace ContaOnline.Tests
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void UsuarioObterPorEmailSenhaTest()
        {
            var repositorio = new UsuarioRepository();
            var usuario = repositorio.ObterPorEmailSenha("Teste@teste.com.br", "123");
            if (usuario != null)
            {
                Console.WriteLine(usuario.Id);
                Console.WriteLine(usuario.Nome);
                Console.WriteLine(usuario.Email);
                Console.WriteLine(usuario.Senha);

            }
        }

        [TestMethod]
        public void UsuarioExcluirTest()
        {
            var repositorio = new UsuarioRepository();
            repositorio.Excluir("123Teste3");
        }

        [TestMethod]
        public void UsuarioAlterarTest()
        {
            var usuario = new Usuario
            {
                Id = "123Teste",
                Nome = "Teste alterado Rep",
                Email = "Testealterado@teste.com.br",
                Senha = "123alterado"
            };

            var repositorio = new UsuarioRepository();
            repositorio.Alterar(usuario);
        }

        [TestMethod]
        public void UsuarioObterPorIdTest()
        {
            var repositorio = new UsuarioRepository();
            var usuario = repositorio.ObterPorId("123Teste");
            if (usuario != null)
            {
                Console.WriteLine(usuario.Id);
                Console.WriteLine(usuario.Nome);
                Console.WriteLine(usuario.Email);
                Console.WriteLine(usuario.Senha);

            }
        }

        [TestMethod]
        public void UsuarioIncluirTest()
        {
            var usuario = new Usuario
            {
                Id = "123Teste3",
                Nome = "Teste Rep3",
                Email = "Teste@teste.com.br3",
                Senha = "1233"
            };
            var repositorio = new UsuarioRepository();
            repositorio.Incluir(usuario);
        }

        [TestMethod]
        public void UsuarioObterTodosTest()
        {
            var rep = new UsuarioRepository();
            var lista = rep.ObterTodos(null);
            foreach (var usuario in lista)
            {
                Console.WriteLine(usuario.Nome);
                Console.WriteLine(usuario.Email);
            }
        }

        [TestMethod]
        public void UsuarioValidarNomeTest()
        {
            var usuario = new Usuario()
            {
                Email = "teste@teste.com",
                Id = "123",
                Senha = "12345"
            };

            var erros = usuario.Validar();
            Assert.AreEqual(1, erros.Count, "Deveria retornar 1 erro");
        }

        [TestMethod]
        public void UsuarioValidarSenhaTest()
        {
            var usuario = new Usuario()
            {
                Nome = "Maria",
                Email = "teste@teste.com",
                Id = "123",
                Senha = "123"
            };

            var erros = usuario.Validar();
            Assert.AreEqual(1, erros.Count, "Deveria retornar 1 erro");
            Assert.AreEqual(erros[0], "A senha deve ter 5 caracteres no minimo", "Mensagem errada");
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtém ou define o contexto do teste que provê
        ///informação e funcionalidade da execução de teste atual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

    }
}
