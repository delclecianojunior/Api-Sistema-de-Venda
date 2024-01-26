using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task Adicionar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Remover(Guid id);
        Task<List<Usuario>> ObterTodos();
    }
}
