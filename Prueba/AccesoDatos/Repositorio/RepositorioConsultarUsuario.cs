using AccesoDatos.Contexto;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Repositorio
{
    public class RepositorioConsultarUsuario : IBaseRepositorioBusqueda<Usuarios>
    {
        private readonly DataContext contexto;

        public RepositorioConsultarUsuario(DataContext contexto)
        {
            this.contexto = contexto;
        }
        public Usuarios Consultar(int identificacion)
        {
            return contexto.Usuarios.FirstOrDefault(i => i.Identificacion == identificacion);
        }

        public List<Usuarios> ListadoCompleto()
        {
            return contexto.Usuarios.ToList();

        }
    }
}
