using AccesoDatos.Repositorio.Interfaces;
using AccesoDatos.Servicio.Interfaces;
using System;
using System.Collections.Generic;

namespace AccesoDatos.Servicio
{
    public class BaseServicioBusqueda<T> : IBaseServicioBusqueda<T> where T : class
    {
        private readonly IBaseRepositorioBusqueda<T> repositorio;

        public BaseServicioBusqueda(IBaseRepositorioBusqueda<T> repositorio)
        {
            this.repositorio = repositorio;
        }

        public T Consultar(int identificacion)
        {
            throw new NotImplementedException();
        }

        public List<T> ListaCompleta()
        {
            return repositorio.ListadoCompleto();
        }
    }
}
