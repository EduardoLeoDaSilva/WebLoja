using System;
using System.Collections.Generic;
using  file =System.IO ;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Newtonsoft.Json;
using Repositories;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace LojaSuperMercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

    [Authorize]
        [HttpGet]
        public IActionResult ObterTodos()
        {
            var listaProdutosBd = _produtoRepository.ObterTodos();
            if(listaProdutosBd != null)
            {
                return Ok(listaProdutosBd);
            }
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("obterFoto")]
        public IActionResult ObterFotoProduto(int codigo)
        {
            
            try
            {
                var t = file.File.ReadAllBytes($"./wwwroot/imagens/produtos/produto-{codigo}.jfif");

                    return File(t, "img/png");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}