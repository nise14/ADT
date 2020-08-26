using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Usuarios;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IAdministradorUsuarios administrador;

        public UsuariosController(IAdministradorUsuarios administrador)
        {
            this.administrador = administrador;
        }

        [HttpGet]
        public bool Servicio() {
            return true;
        }

        [HttpPost]
        [Authorize]
        [Route("CrearUsuario")]
        public bool CrearUsuario([FromBody]AccesoDatos.Modelos.Usuarios usarios)
        {
            return administrador.Insertar(usarios);
        }

        [HttpGet]
        [Authorize]
        [Route("ConsultarUsuario/{identificacion}")]
        public AccesoDatos.Modelos.Usuarios ConsultarUsuario(int identificacion)
        {
            return administrador.Consultar(identificacion);
        }

        [HttpDelete]
        [Authorize]
        [Route("EliminarUsuario/{identificacion}")]
        public bool EliminarUsuario(int identificacion)
        {
            return administrador.Eliminar(identificacion);
        }

        [HttpPost]
        [Route("Login")]
        public AccesoDatos.Modelos.Usuarios Login([FromBody] AccesoDatos.Modelos.Usuarios usuario) {
            return administrador.Login(usuario);
        }
    }
}