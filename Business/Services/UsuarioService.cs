using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Adicionar(Usuario usuario)
        {
            if (usuario.Senha == null)
            {
                throw new ArgumentNullException(nameof(usuario.Senha), "A senha não pode ser nula.");
            }

            // Gere um novo salt
            usuario.SenhaSalt = CriarSalt();

            // Calcule o hash da senha temporária usando o salt gerado
            usuario.SenhaHash = CriarHash(usuario.Senha, usuario.SenhaSalt);

            // Adicionando mensagens de log
            Console.WriteLine($"Senha do usuário {usuario.Email} hash: {string.Join("-", usuario.SenhaHash.Select(b => b.ToString("X2")))}");
            Console.WriteLine($"Salt do usuário {usuario.Email}: {string.Join("-", usuario.SenhaSalt.Select(b => b.ToString("X2")))}");

            // Agora, adicione o usuário ao repositório
            await _usuarioRepository.Adicionar(usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            await _usuarioRepository.Atualizar(usuario);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        public async Task<List<Usuario>> ObterTodos()
        {
            return await _usuarioRepository.ObterTodos();
        }

        public async Task Remover(Guid id)
        {
           await _usuarioRepository.Remover(id);
        }

        private byte[] CriarSalt()
        {
            var salt = new byte[64]; // Ajuste o tamanho conforme necessário
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public byte[] CriarHash(string senha, byte[] salt)
        {
            if (senha == null)
            {
                throw new ArgumentNullException(nameof(senha), "A senha não pode ser nula.");
            }

            using (var hmac = new HMACSHA512(salt))
            {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            }
        }
    }

}
