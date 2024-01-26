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
    public class ItemVendaRepository : Repository<ItemVenda>, IItemVendaRepository
    {
        private readonly Contexto _context;
        public ItemVendaRepository(Contexto db, Contexto context) : base(db)
        {
            _context = context;
        }

        public  async Task<List<ItemVenda>> ObterItensDaVenda(List<Guid> ItemVenda)
        {
            return await _context.ItensVenda.Where(i => ItemVenda.Contains(i.Id)).Include(i => i.Produto).ToListAsync();
        }
    }
}
