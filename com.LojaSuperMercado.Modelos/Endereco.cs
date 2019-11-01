using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Usuario Usuario { get; set; }


    }
}
