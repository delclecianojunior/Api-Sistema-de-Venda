using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ComissaoService : IComissaoService
    {
        private readonly IComissaoRepository _comissaoRepository;

        public ComissaoService(IComissaoRepository comissaoRepository)
        {
            _comissaoRepository = comissaoRepository;
        }


        public void Dispose()
        {
            _comissaoRepository?.Dispose();
        }

        public async Task<List<Comissao>> ObterTodos()
        {
            return await _comissaoRepository.ObterTodos();
        }
    }
}
