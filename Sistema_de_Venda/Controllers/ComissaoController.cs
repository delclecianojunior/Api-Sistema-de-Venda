using AutoMapper;
using Business.Interfaces;
using Business.Services;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Venda.ViewModel;

namespace Sistema_de_Venda.Controllers
{
    [Route("api/comissoes")]
    public class ComissaoController : MainController
    {
        private readonly ComissaoService _comissaoService;
        private readonly IMapper _mapper;

        public ComissaoController(INotificador notificador, ComissaoService comissaoService, IMapper mapper) : base(notificador)
        {
            _comissaoService = comissaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComissaoViewModel>>> ObterTodasComissoes()
        {
            var comissoes = await _comissaoService.ObterTodos();

            var comissoesViewModel = _mapper.Map<IEnumerable<ComissaoViewModel>>(comissoes);

            return Ok(comissoesViewModel);
        }
    }
}
