using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Repository
{
    public class ContaRepository : IContaRepository
    {
        public void Alterar(Conta conta)
        {
            Db.Execute("ContaAlterar", conta);
        }

        public void Excluir(string id)
        {
            Db.Execute("ContaExcluir", new { Id = id });
        }

        public void Incluir(Conta conta)
        {
            Db.Execute("ContaIncluir", conta);
        }

        public Conta ObterPorId(string id)
        {
            return Db.QueryEntidade<Conta>("ContaObterPorId", new { Id = id});
        }

        public IEnumerable<ContaListItem> ObterPorUsuario(string usuarioid)
        {
            return Db.QueryColecao<ContaListItem>("ContaObterTodos", new { UsuarioId = usuarioid});
        }

        public IEnumerable<Conta> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<Conta>("ObterTodos", new { UsuarioId = usuarioId});
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }

        IEnumerable<ContaListItem> IContaRepository.ObterPorFiltro(ContaFiltro filtro)
        {
            throw new NotImplementedException();
        }
    }
}
