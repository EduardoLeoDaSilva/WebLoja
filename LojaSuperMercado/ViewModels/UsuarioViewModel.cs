using Microsoft.AspNetCore.Http;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaSuperMercado.ViewModels
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public IFormFile Foto { get; set; }

        public List<Endereco> Enderecos { get; set; }

        public List<Pedido> Pedidos { get; set; }
    }
}
