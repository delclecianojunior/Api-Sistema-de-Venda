using Business.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sistema_de_Venda.Configurations
{
    public class TokenService
    {
        public string GerarToken(Usuario usuario, TimeSpan? tempoDeVida = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("MEUTOKENVERIFICACAO2024**");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, usuario.Email.ToString())
                    // Você pode adicionar mais claims aqui se necessário
                }),
                Expires = DateTime.UtcNow.Add(tempoDeVida ?? TimeSpan.FromMinutes(30)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
