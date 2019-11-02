using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Repositories;

namespace LojaSuperMercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly ApplicationContext _context;

        public UsuarioController(UsuarioRepository usuarioRepository, ApplicationContext context)
        {
            _usuarioRepository = usuarioRepository;
            _context = context;
        }

        [HttpPost]
        public ActionResult Salvar([FromBody]Usuario usuario)
        {
            try
            {
                _usuarioRepository.Gravar(usuario);
                _context.SaveChanges();
                return Ok(new { msg = "Usuario cadastrado com sucesso" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult VerTodos()
        {
            try
            {
                var usuariosBd = _usuarioRepository.findAll();
                return Ok(usuariosBd);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
            
        }


    }
}