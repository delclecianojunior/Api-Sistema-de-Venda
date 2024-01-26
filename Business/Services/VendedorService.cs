using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class VendedorService : IVendedorService
    {
        private readonly IVendedorRepository _vendedorRepository;

        public VendedorService(IVendedorRepository vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;
        }

        public async Task Adicionar(Vendedor vendedor)
        {
            await _vendedorRepository.Adicionar(vendedor);
        }

        public async Task Atualizar(Vendedor vendedor)
        {
           await _vendedorRepository.Atualizar(vendedor);
        }

        public void Dispose()
        {
            _vendedorRepository?.Dispose();
        }

        public async Task<Vendedor> ObterPorId(Guid id)
        {
            return await _vendedorRepository.ObterPorId(id);
        }

        public async Task<List<Vendedor>> ObterTodos()
        {
            return await _vendedorRepository.ObterTodos();
        }

        public async Task Remover(Guid id)
        {
          await _vendedorRepository.Remover(id);
        }
    }
}
