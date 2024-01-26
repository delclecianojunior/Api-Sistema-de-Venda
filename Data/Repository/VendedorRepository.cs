using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class VendedorRepository : Repository<Vendedor>, IVendedorRepository
    {
        private readonly Contexto _context;
        public VendedorRepository(Contexto db, Contexto context) : base(db)
        {
            _context = context;
        }

        public async Task<Vendedor> ObterVendedorComProdutos(Guid id)
        {
              var vendedor = await _context.Vendedores
             .Where(v => v.Id == id)
             .Include(v => v.Produtos) // Certifique-se de incluir os produtos se estiver usando Eager Loading
             .FirstOrDefaultAsync();

                if (vendedor == null)
                {
                    return null;
                }

                // Configuração da serialização para evitar ciclos
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    MaxDepth = 256 // Ajuste conforme necessário
                };

                var json = JsonSerializer.Serialize(vendedor, options);
                return JsonSerializer.Deserialize<Vendedor>(json, options);
        }

        public async Task RemoverProdutosVendedor(Guid id)
        {
            var vendedor = await Db.Vendedores.Include(v => v.Produtos).SingleAsync(v => v.Id == id);

            // Remover produtos individualmente
            foreach (var produto in vendedor.Produtos.ToList())
            {
                Db.Produtos.Remove(produto);
            }

            // Agora remover o vendedor
            Db.Vendedores.Remove(vendedor);
            await Db.SaveChangesAsync();
        }
    }
}
