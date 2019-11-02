using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(ApplicationContext context ) : base(context.Set<Usuario>())
        {

        }


    }
}
