using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IComissaoRepository _comissaoRepository;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IItemVendaRepository _itemVendaRepository;

        public VendaService(IVendaRepository vendaRepository, IComissaoRepository comissaoRepository, IVendedorRepository vendedorRepository, IItemVendaRepository itemVendaRepository)
        {
            _vendaRepository = vendaRepository;
            _comissaoRepository = comissaoRepository;
            _vendedorRepository = vendedorRepository;
            _itemVendaRepository = itemVendaRepository;
        }

        public async Task Adicionar(Venda venda)
        {
            await _vendaRepository.Adicionar(venda);
        }

        public async Task Atualizar(Venda venda)
        {
            await _vendaRepository.Atualizar(venda);
        }

        public async Task<List<Comissao>> CalcularComissoes(Venda venda, Guid VendedorId)
        {
            var comissoes = new List<Comissao>();
          
            var ItensDaVenda = await _itemVendaRepository.ObterItensDaVenda(venda.ItensVenda.Select(i => i.Id).ToList());
           
            // Calcula a comissão para o vendedor (5% do valor da venda)
            var valorComissao = ItensDaVenda.Sum(iv => iv.Produto.Preco * iv.Quantidade) * 0.05m;

            // Adiciona a comissão à lista
            comissoes.Add(new Comissao
            {
                VendaId = venda.Id,
                VendedorId = VendedorId,
                ValorComissao = valorComissao,
                DataCalculo = DateTime.Now // Data atual, ajuste conforme necessário
            });

            // Armazena as comissões no banco de dados
            await _comissaoRepository.AdicionarRange(comissoes); // Método fictício, ajuste conforme necessário

            return comissoes;
        }

        public void Dispose()
        {
            _vendaRepository?.Dispose();
        }

        public async Task<List<Venda>> ObterTodos()
        {
            return await _vendaRepository.ObterTodos();
        }

        public async Task Remover(Guid id)
        {
            await _vendaRepository.Remover(id);
        }
    }
}
