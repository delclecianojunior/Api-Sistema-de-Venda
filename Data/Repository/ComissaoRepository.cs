using Business.Interfaces;
using Business.Models;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ComissaoRepository : Repository<Comissao>, IComissaoRepository
    {
        public ComissaoRepository(Contexto db) : base(db)
        {
        }

        public async Task AdicionarRange(IEnumerable<Comissao> comissoes)
        {
            await DbSet.AddRangeAsync(comissoes);
            await SaveChanges();
        }
    }
}
