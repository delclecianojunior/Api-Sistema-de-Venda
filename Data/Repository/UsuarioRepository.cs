using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Contexto db) : base(db){}

        public async Task<Usuario> Autenticar(string email, string senha)
        {
            try
            {
                var usuario = await DbSet.SingleOrDefaultAsync(u => u.Email == email);

                Console.WriteLine("Usuário: " + usuario);

                if (usuario == null)
                {
                    // Usuário não encontrado pelo e-mail
                    Console.WriteLine($"Usuário não encontrado para o email: {email}");
                    return null;
                }

                // Verificar a senha
                if (!VerificarSenha(senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    // Senha incorreta
                    Console.WriteLine($"Senha incorreta para o usuário: {email}");
                    return null;
                }

                // Autenticação bem-sucedida, usuário encontrado
                Console.WriteLine($"Usuário autenticado com sucesso: {email}");
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao autenticar usuário ({email}): {ex.Message}");
                // Trate o erro de acordo com sua necessidade
                throw; // Re-throw a exceção para manter o fluxo de controle
            }
        }

        private bool VerificarSenha(string senha, byte[] senhaHashArmazenada, byte[] salt)
        {
            Console.WriteLine($"Senha recebida: {senha}");
            Console.WriteLine($"Salt recebido: {BitConverter.ToString(salt)}");

            if (salt == null)
            {
                // Tratar o caso em que o salt é nulo
                return false;
            }

            using (var hmac = new HMACSHA512(salt))
            {
                var senhaHashCalculada = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

                // Comparando os hashes
                return senhaHashCalculada.SequenceEqual(senhaHashArmazenada);
            }
        }

    }
}
