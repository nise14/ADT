using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.ProgramasTV
{
    public interface IAdministradorProgramasTV
    {
        List<Programas> CargarPeliculas();

        List<Programas> Buscar(string palabra);
    }
}
