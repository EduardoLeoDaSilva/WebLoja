using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutorizacaoAppLoja.Segurança;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Newtonsoft.Json;

namespace AutorizacaoAppLoja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginJwtController : ControllerBase
    {
        private readonly IGeradorToken _geradorToken;
        public LoginJwtController(IGeradorToken geradorToken)
        {
            _geradorToken = geradorToken;
        }

        [HttpPost]
        public IActionResult Login([FromBody]Usuario usuario)
        {
            var token = _geradorToken.ObterTokenJwt(usuario.Email, usuario.Senha);
            if(token != null)
            {
            return Content(JsonConvert.SerializeObject(token));

            }
            return NoContent();

        }

        [HttpGet]
        public IActionResult Logoff()
        {

            return null;
        }
    }
}