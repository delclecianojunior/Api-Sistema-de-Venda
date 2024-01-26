using Sistema_de_Venda.Configurations;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Venda.ViewModel;
using Data.Repository;

namespace Sistema_de_Venda.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : MainController
    {
        private readonly UsuarioService _usuarioService;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public UsuarioController(UsuarioService usuarioService, IMapper mapper, INotificador notificador, UsuarioRepository usuarioRepository, TokenService tokenService) : base(notificador)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> CadastrarUsuario(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid || usuarioViewModel.Senha == null)
            {
                return CustomResponse(ModelState);
            }

            await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioViewModel>> EditarUsuario(UsuarioViewModel usuarioViewModel)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            await _usuarioService.Atualizar(_mapper.Map<Usuario>(usuarioViewModel));
            return CustomResponse(usuarioViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _usuarioService.Remover(id);
            return Ok("Usuario removido com sucesso");
        }

        [HttpGet("{listarUsuarios}")]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> ObterTodos()
        {
            return Ok(_mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioService.ObterTodos()));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            var usuario = await _usuarioRepository.Autenticar(loginViewModel.Email, loginViewModel.Senha);

            if (usuario == null)
            {
                return Unauthorized("Email ou senha inválidos");
            }

            // Configurando o tempo de vida para derrubar a sessão do usuario em 30 minutos
            var tempoDeVida = TimeSpan.FromMinutes(30);

            // Gerando o token com tempo de vida configurado
            var token = _tokenService.GerarToken(usuario, tempoDeVida);

            return Ok(new { token });
        }


    }
}


