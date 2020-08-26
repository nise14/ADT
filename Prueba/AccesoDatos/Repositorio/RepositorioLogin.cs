using AccesoDatos.Contexto;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorio.Interfaces;
using System.Linq;

namespace AccesoDatos.Repositorio
{
    public class RepositorioLogin: IRepositorioLogin
    {
        private readonly DataContext contexto;

        public RepositorioLogin(DataContext contexto)
        {
            this.contexto = contexto;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="usuario">modelo usuario</param>
        /// <returns></returns>
        public Usuarios Login(Usuarios usuario)
        {
            return contexto.Usuarios.FirstOrDefault(i => i.Identificacion == usuario.Identificacion && i.Clave == usuario.Clave);
        }
    }
}
