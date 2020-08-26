using AccesoDatos.Modelos;
using AccesoDatos.Repositorio;
using AccesoDatos.Repositorio.Interfaces;
using AccesoDatos.Servicio;
using AccesoDatos.Servicio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Negocio.ProgramasTV;
using Negocio.Roles;
using Negocio.Usuarios;

namespace ApiRest
{
    public class Installer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBaseRepositorio< Usuarios>, BaseRepositorio<Usuarios>>();
            services.AddTransient<IBaseRepositorioBusqueda<Usuarios>, RepositorioConsultarUsuario>();
            services.AddTransient<IBaseServicioBusqueda<Usuarios>, BaseServicioUsuarios>();
            services.AddTransient<IbaseServicio<Usuarios>, BaseServicio<Usuarios>>();
            services.AddTransient<IAdministradorUsuarios, AdministradorUsuarios>();

            services.AddTransient<IBaseRepositorioBusqueda<Roles>, RepositorioRoles>();
            services.AddTransient<IBaseServicioBusqueda<Roles>, BaseServicioRoles>();
            services.AddTransient<IAdministradorRoles, AdministradorRoles>();
            
            services.AddTransient<IAdministradorProgramasTV, AdministradorProgramasTV>();
            services.AddTransient<IBaseRepositorio<ProgramasTv>, BaseRepositorio<ProgramasTv>>();
            services.AddTransient<IBaseRepositorioBusqueda<ProgramasTv>, BaseRepositorioBusqueda<ProgramasTv>>();
            services.AddTransient<IbaseServicio<ProgramasTv>, BaseServicio<ProgramasTv>>();
            services.AddTransient<IBaseServicioBusqueda<ProgramasTv>, BaseServicioBusqueda<ProgramasTv>>();

            services.AddTransient<IRepositorioLogin, RepositorioLogin>();
            services.AddTransient<IServicioLogin, BaseServicioUsuarios>();
            services.AddTransient<IAdministradorUsuarios, AdministradorUsuarios>();

        }
    }
}
