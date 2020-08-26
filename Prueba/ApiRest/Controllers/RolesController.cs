using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Roles;
using System.Collections.Generic;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        IAdministradorRoles administrador;

        public RolesController(IAdministradorRoles administrador)
        {
            this.administrador = administrador;
        }

        [HttpGet]
        [Authorize]
        [Route("Listado")]
        public List<AccesoDatos.Modelos.Roles> Listado()
        {
            return administrador.Roles();
        }
    }
}