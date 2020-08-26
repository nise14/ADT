using System.Collections.Generic;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorio.Interfaces;
using AccesoDatos.Servicio.Interfaces;

namespace AccesoDatos.Servicio
{
    public class BaseServicioUsuarios: IBaseServicioBusqueda<Usuarios>, IServicioLogin
    {
        IBaseRepositorioBusqueda<Usuarios> repositorio;
        IRepositorioLogin repositorioLogin;

        public BaseServicioUsuarios(IBaseRepositorioBusqueda<Usuarios> repositorio, IRepositorioLogin repositorioLogin)
        {
            this.repositorio = repositorio;
            this.repositorioLogin = repositorioLogin;
        }

        public Usuarios Consultar(int identificacion)
        {
            return repositorio.Consultar(identificacion);
        }

        public List<Usuarios> ListaCompleta()
        {
            return repositorio.ListadoCompleto();
        }

        public Usuarios Login(Usuarios usuario)
        {
            return repositorioLogin.Login(usuario);
        }
    }
}
