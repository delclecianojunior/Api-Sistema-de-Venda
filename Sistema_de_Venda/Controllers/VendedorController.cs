using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Venda.ViewModel;

namespace Sistema_de_Venda.Controllers
{
    [Route("api/vendedores")]
    public class VendedorController : MainController
    {
        private readonly IVendedorService _vendedorService;
        private readonly IMapper _mapper;
        private readonly IVendedorRepository _vendedorRepository;

        public VendedorController(INotificador notificador, IVendedorService vendedorService, IMapper mapper, IVendedorRepository vendedorRepository) : base(notificador)
        {
            _vendedorService = vendedorService;
            _mapper = mapper;
            _vendedorRepository = vendedorRepository;
        }

        [HttpPost]
        public async Task<ActionResult<VendedorViewModel>> CadastrarVendedor(VendedorViewModel vendedorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _vendedorService.Adicionar(_mapper.Map<Vendedor>(vendedorViewModel));

            return CustomResponse(vendedorViewModel);
        }

        [HttpPut]
        public async Task<ActionResult<VendedorViewModel>> EditarVendedor(VendedorViewModel vendedorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _vendedorService.Atualizar(_mapper.Map<Vendedor>(vendedorViewModel));
            return CustomResponse(vendedorViewModel);
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            try
            {
                await _vendedorRepository.RemoverProdutosVendedor(id);
                return Ok("Vendedor e seus produtos foram removidos com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir vendedor e seus produtos: {ex.Message}");
                Console.WriteLine($"Erro ao excluir vendedor e seus produtos: {ex}");
                throw; // Rejoga a exceção para manter o comportamento original (enviando o erro 500)
            }
        }

        [HttpGet("{listarVendedores}")]
        public async Task<ActionResult<IEnumerable<VendedorViewModel>>> ObterTodos()
        {
            return Ok(_mapper.Map<IEnumerable<VendedorViewModel>>(await _vendedorService.ObterTodos()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Vendedor>> ObterVendedorPorId(Guid id)
        {
            var vendedor = await _vendedorRepository.ObterVendedorComProdutos(id);

            if (vendedor == null)
            {
                return NotFound("Vendedor não encontrado");
            }

            return Ok(vendedor);
        }
    }
}
