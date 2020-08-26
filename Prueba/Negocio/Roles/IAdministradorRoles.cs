using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Roles
{
    public interface IAdministradorRoles
    {
        List<AccesoDatos.Modelos.Roles> Roles();
    }
}
