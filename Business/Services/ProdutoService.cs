﻿using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Produto produto)
        {
          await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
         await _produtoRepository.Atualizar(produto);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        public async Task<List<Produto>> ObterTodos()
        {
           return await _produtoRepository.ObterTodos();
        }

        public async Task Remover(Guid id)
        {
           await _produtoRepository.Remover(id);
        }
    }
}
