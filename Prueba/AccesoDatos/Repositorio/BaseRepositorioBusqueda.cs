using AccesoDatos.Contexto;
using AccesoDatos.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Repositorio
{
    public class BaseRepositorioBusqueda<T> : IBaseRepositorioBusqueda<T> where T : class
    {
        private readonly DataContext contexto;
        private readonly DbSet<T> entidades;

        public BaseRepositorioBusqueda(DataContext contexto)
        {
            this.contexto = contexto;
            entidades = contexto.Set<T>();
        }

        public T Consultar(int identificacion)
        {
            throw new NotImplementedException();
        }

        public List<T> ListadoCompleto()
        {
            return entidades.ToList();
        }
    }
}
