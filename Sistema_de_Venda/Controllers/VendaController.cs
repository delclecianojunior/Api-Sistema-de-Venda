using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Models.Enum;
using Business.Services;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Venda.ViewModel;

namespace Sistema_de_Venda.Controllers
{
    [Route("api/vendas")]
    public class VendaController : MainController
    {
        private readonly VendaService _vendaService;
        private readonly IMapper _mapper;
        private readonly VendaRepository _vendaRepository;

        public VendaController(INotificador notificador, VendaService vendaService, IMapper autoMapper, IMapper mapper, VendaRepository vendaRepository) : base(notificador)
        {
            _vendaService = vendaService;
            _mapper = mapper;
            _vendaRepository = vendaRepository;
        }

        [HttpPost]
        public async Task<ActionResult<VendaViewModel>> CriarVenda(VendaViewModel vendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            if (vendaViewModel.ItensVenda == null || vendaViewModel.ItensVenda.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "Uma venda deve ter pelo menos um item.");
                return CustomResponse();
            }

            // Converta a ViewModel para a entidade antes de chamar o serviço
            var venda = _mapper.Map<Venda>(vendaViewModel);
            venda.DataVenda = vendaViewModel.DataVenda;
            venda.Status = StatusVenda.Realizada;

            await _vendaService.Adicionar(venda);

            await _vendaService.CalcularComissoes(venda, venda.VendedorId);

            return CustomResponse(vendaViewModel);
        }



        [HttpGet("vendas-realizadas")]
        public async Task<ActionResult<IEnumerable<VendaViewModel>>> RegistroDeVendasRealizadas()
        {
            var vendas = await _vendaRepository.ObterTodasVendasRealizadas();

            var vendasViewModel = _mapper.Map<List<VendaViewModel>>(vendas);

            return CustomResponse(vendasViewModel);
        }



    }
}
