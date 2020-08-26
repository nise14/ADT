namespace Negocio.Usuarios
{
    public interface IAdministradorUsuarios
    {
        bool Insertar(AccesoDatos.Modelos.Usuarios usuario);

        AccesoDatos.Modelos.Usuarios Consultar(int identificacion);

        bool Eliminar(int identificacion);

        AccesoDatos.Modelos.Usuarios Login(AccesoDatos.Modelos.Usuarios usuario);
    }
}
