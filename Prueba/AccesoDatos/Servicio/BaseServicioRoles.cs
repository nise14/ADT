using AccesoDatos.Modelos;
using AccesoDatos.Repositorio.Interfaces;
using AccesoDatos.Servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Servicio
{
    public class BaseServicioRoles : IBaseServicioBusqueda<Roles>
    {

        IBaseRepositorioBusqueda<Roles> repositorio;

        public BaseServicioRoles(IBaseRepositorioBusqueda<Roles> repositorio)
        {
            this.repositorio = repositorio;
        }

        public Roles Consultar(int identificacion)
        {
            return repositorio.Consultar(identificacion);
        }

        public List<Roles> ListaCompleta()
        {
            return repositorio.ListadoCompleto();
        }
    }
}
