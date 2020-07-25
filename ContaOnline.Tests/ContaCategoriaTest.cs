using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContaOnline.Domain.Models;
using ContaOnline.Domain.Interfaces ;
using ContaOnline.Repository;

namespace ContaOnline.Tests
{
    [TestClass]
    public class ContaCategoriaTes
    {
        ContaCategoriaRepository repositorio = new ContaCategoriaRepository();

        [TestMethod]
        public void IncluirTest()
        {
            var conta = new ContaCategoria() { Id = "12345", Nome = "testContaCat", UsuarioId = "abc" };
            repositorio.Incluir(conta);
        }

        [TestMethod]
        public void AlterarTest()
        {
            var conta = new ContaCategoria() { Id = "12345", Nome = "alteradotestContaCat", UsuarioId = "abc" };
            repositorio.Alterar(conta);
        }

        [TestMethod]
        public void ExcluirTest()
        {
            repositorio.Excluir("12345");
        }

        [TestMethod]
        public void ObterTodosTest()
        {
            var lista = repositorio.ObterTodos("abc");
            foreach(var conta in lista)
            {
                Console.WriteLine(conta.Id);
                Console.WriteLine(conta.Nome);
                Console.WriteLine(conta.UsuarioId);
            }
        }

        [TestMethod]
        public void ObterPorIdTest()
        {
            var conta = repositorio.ObterPorId("12345");
            if (conta != null)
            {
                Console.WriteLine(conta.Id);
                Console.WriteLine(conta.Nome);
                Console.WriteLine(conta.UsuarioId);
            }
        }
    }
}
