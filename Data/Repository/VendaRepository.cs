using Business.Interfaces;
using Business.Models;
using Business.Models.Enum;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(Contexto db) : base(db)
        {
        }

        public async Task<List<Venda>> ObterTodasVendasRealizadas()
        {
            return await DbSet.Where(v => v.Status == StatusVenda.Realizada).Include(v => v.Usuario).Include(v => v.Vendedor).Include(v => v.ItensVenda).ThenInclude(v => v.Produto).ToListAsync();
        }
    }
}
