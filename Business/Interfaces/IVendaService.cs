using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IVendaService : IDisposable
    {
        Task Adicionar(Venda venda);
        Task Atualizar(Venda venda);
        Task Remover(Guid id);
        Task<List<Venda>> ObterTodos();

        Task<List<Comissao>> CalcularComissoes(Venda venda, Guid VendedorId);
    }
}
