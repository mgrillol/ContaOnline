using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        public void Alterar(Contato contato)
        {
            Db.Execute("ContatoAlterar", contato);
        }

        public void Excluir(string id)
        {
            Db.Execute("ContatoExcluir", new { Id = id });
        }

        public void Incluir(Contato contato)
        {
            Db.Execute("ContatIncluir", contato);
        }

        public Contato ObterPorId(string id)
        {
            return Db.QueryEntidade<Contato>("ContatoObterPorId", new { Id = id });
        }

        public IEnumerable<Contato> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<Contato>("ContatoObterTodos", new { UsuarioId = usuarioId });
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
