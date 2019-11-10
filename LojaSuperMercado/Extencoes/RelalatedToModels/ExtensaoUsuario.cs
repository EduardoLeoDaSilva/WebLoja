using LojaSuperMercado.ViewModels;
using Microsoft.AspNetCore.Http;
using Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LojaSuperMercado.Extencoes.RelalatedToModels
{
    public static class ExtensaoUsuario
    {
        public static Usuario ParaModelo(this UsuarioViewModel usuarioViewModel)
        {
            var usuario = new Usuario
            {
                Nome = usuarioViewModel.Nome,
                CPF = usuarioViewModel.CPF,
                Email = usuarioViewModel.Email,
                Enderecos = usuarioViewModel.Enderecos,
                Pedidos = usuarioViewModel.Pedidos,
                Senha = usuarioViewModel.Senha,
                Foto = usuarioViewModel.Foto.ObterBytesFoto(),
                UsuarioId = usuarioViewModel.UsuarioId


            };

            return usuario;
        }


        private static byte[] ObterBytesFoto(this IFormFile file)
        {

            byte[] foto;
            using (var sr = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                sr.CopyTo(memoryStream);
                foto = memoryStream.ToArray();
            }
            return foto;
        }
    }
}
