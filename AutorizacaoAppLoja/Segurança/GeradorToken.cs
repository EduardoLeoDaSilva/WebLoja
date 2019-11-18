using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AutorizacaoAppLoja.Segurança
{
    public class GeradorToken : IGeradorToken
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationContext _context;
        public GeradorToken(IConfiguration configuration, ApplicationContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public string ObterTokenJwt(string email, string senha)
        {

            var usuario = _context.Set<Usuario>().Where(x => x.Email == email && x.Senha == senha).SingleOrDefault();


            if (usuario != null)
            {

                var segredoLogin = Encoding.UTF8.GetBytes(_configuration["SegredoLogin"]);


                var tokenManipulador = new JwtSecurityTokenHandler();

                var descricaoToken = new SecurityTokenDescriptor
                {
                    Audience = "Web",
                    Issuer = "WebLojaApp",
                    Expires = DateTime.UtcNow.AddMinutes(2),
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Email, email)
                    }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(segredoLogin), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenManipulador.CreateToken(descricaoToken);

                
                return tokenManipulador.WriteToken(token);
            }
            return null;
        }

    }
}
