using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Venda.ViewModel;

namespace Sistema_de_Venda.Controllers
{
    [Route("api/produtos")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(INotificador notificador, IProdutoService produtoService, IMapper mapper) : base(notificador)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> CadastrarProduto(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [HttpPut]
        public async Task<ActionResult<ProdutoViewModel>> EditarProduto(ProdutoViewModel produtoViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produto = _mapper.Map<Produto>(produtoViewModel);

            await _produtoService.Atualizar(produto);

            return CustomResponse(produtoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _produtoService.Remover(id);
            return Ok("Produto removido com sucesso");
        }

        [HttpGet("{listarProdutos}")]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> ObterTodos()
        {
            return Ok(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.ObterTodos()));
        }
    }
}
