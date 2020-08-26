using System.Collections.Generic;

namespace AccesoDatos.Repositorio.Interfaces
{
    public interface IBaseRepositorioBusqueda<T> where T : class
    {

       /// <summary>
       /// Metodo para consultar un registro por id
       /// </summary>
       /// <param name="identificacion">identificacion del usuario</param>
       /// <returns></returns>
        T Consultar(int identificacion);

        List<T> ListadoCompleto();
    }
}
