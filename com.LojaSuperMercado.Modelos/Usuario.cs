using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte[] Foto { get; set; }

        public List<Endereco> Enderecos { get; set; }
    }
}
