using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IComissaoRepository : IRepository<Comissao>
    {
        Task AdicionarRange(IEnumerable<Comissao> comissoes);
    }
}
