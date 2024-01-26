using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Venda.ViewModel;

namespace Sistema_de_Venda.Controllers
{
    [Route("api/item-venda")]
    public class ItemVendaController : MainController
    {
        private readonly IItemVendaService _itemVendaService;
        private readonly IMapper _mapper;

        public ItemVendaController(INotificador notificador, IItemVendaService itemVendaService, IMapper mapper) : base(notificador)
        {
            _itemVendaService = itemVendaService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ItemVendaViewModel>> CriarItemVenda(ItemVendaViewModel itemVendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _itemVendaService.Adicionar(_mapper.Map<ItemVenda>(itemVendaViewModel));

            return CustomResponse(itemVendaViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> RemoverItemVenda(Guid id)
        {
            var itemVendaViewModel = await _itemVendaService.ObterPorId(id);

            if (itemVendaViewModel == null)
            {
                BadRequest("Item de venda não encontrado.");
                return CustomResponse();
            }

            await _itemVendaService.Remover(id);

            return CustomResponse();
        }
    }
}
