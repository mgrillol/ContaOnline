using ContaOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaOnline.Domain.Interfaces
{
    public interface IContaRepository:IRepository<Conta>
    {
        ContaExibirViewModel ObterExibirPorId(string id);

        IEnumerable<ContaListItem> ObterPorUsuario(string usuarioid);

        IEnumerable<ContaListItem> ObterPorFiltro(ContaFiltro filtro);
    }
}
