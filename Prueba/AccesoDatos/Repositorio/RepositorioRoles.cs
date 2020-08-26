using AccesoDatos.Contexto;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Repositorio
{
    public class RepositorioRoles : IBaseRepositorioBusqueda<Roles>
    {
        private readonly DataContext contexto;

        public RepositorioRoles(DataContext contexto)
        {
            this.contexto = contexto;
        }

        public Roles Consultar(int identificacion)
        {
            return contexto.Roles.FirstOrDefault(i => i.Id == identificacion);
        }

        public List<Roles> ListadoCompleto()
        {
            return contexto.Roles.ToList();

        }
    }
}
