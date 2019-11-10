using System;
using LojaSuperMercado.Extencoes.RelalatedToModels;
using LojaSuperMercado.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositories;

namespace LojaSuperMercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ApplicationContext _context;

        public UsuarioController(IUsuarioRepository usuarioRepository, ApplicationContext context)
        {
            _usuarioRepository = usuarioRepository;
            _context = context;
        }

        [HttpPost]
        public ActionResult Salvar([FromForm]UsuarioViewModel usuario)
        {
            try
            {
                _usuarioRepository.Gravar(usuario.ParaModelo());
                _context.SaveChanges();
                return Content(JsonConvert.SerializeObject("Usuario cadastrado com sucesso"));
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