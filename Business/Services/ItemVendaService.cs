using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ItemVendaService : IItemVendaService
    {
        private readonly IItemVendaRepository _itemVendaRepository;

        public ItemVendaService(IItemVendaRepository itemVendaRepository = null)
        {
            _itemVendaRepository = itemVendaRepository;
        }

        public async Task Adicionar(ItemVenda itemvenda)
        {
            await _itemVendaRepository.Adicionar(itemvenda);
        }

        public async Task Atualizar(ItemVenda itemvenda)
        {
            await _itemVendaRepository.Atualizar(itemvenda);
        }

        public void Dispose()
        {
            _itemVendaRepository?.Dispose();
        }

        public async Task<ItemVenda> ObterPorId(Guid id)
        {
            return await _itemVendaRepository.ObterPorId(id);
        }

        public async Task<List<ItemVenda>> ObterTodos()
        {
            return await _itemVendaRepository.ObterTodos();
        }

        public async Task Remover(Guid id)
        {
            await _itemVendaRepository.ObterPorId(id);
        }
    }
}
