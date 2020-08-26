using System.Collections.Generic;

namespace AccesoDatos.Servicio.Interfaces
{
    public interface IBaseServicioBusqueda<T> where T:class
    {
        /// <summary>
        /// Metodo para consultar un registro por id
        /// </summary>
        /// <param name="identificacion">identificacion del usuario</param>
        /// <returns></returns>
        T Consultar(int identificacion);

        List<T> ListaCompleta();
    }
}
