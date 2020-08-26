using AccesoDatos.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.ProgramasTV;
using System.Collections.Generic;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramasTVController : ControllerBase
    {

        IAdministradorProgramasTV administrador;

        public ProgramasTVController(IAdministradorProgramasTV administrador)
        {
            this.administrador = administrador;
        }

        [HttpGet]
        [Authorize]
        [Route("CargarPeliculas")]

        public List<Programas> CargarPeliculas() {
            
                return administrador.CargarPeliculas();
        }

        [HttpGet]
        [Authorize]
        [Route("Buscar/{buscar}")]
        public List<Programas> Buscar(string buscar)
        {
            return administrador.Buscar(buscar);
        }
    }
}