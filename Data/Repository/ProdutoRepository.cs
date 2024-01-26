using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        private readonly Contexto _context;

        public ProdutoRepository(Contexto db, Contexto context) : base(db)
        {
            _context = context;
        }

        public async Task<List<Produto>> ObterProdutosPorVendedor(Guid vendedorId)
        {
            return await _context.Produtos.Where(p => p.VendedorId == vendedorId).ToListAsync();
        }
    }
}
