using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IItemVendaService : IDisposable
    {
        Task Adicionar(ItemVenda itemvenda);
        Task Atualizar(ItemVenda itemvenda);
        Task Remover(Guid id);
        Task<List<ItemVenda>> ObterTodos();
        Task<ItemVenda> ObterPorId(Guid id);
    }
}
