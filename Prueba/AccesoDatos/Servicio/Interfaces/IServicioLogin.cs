using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Servicio.Interfaces
{
    public interface IServicioLogin
    {
        Usuarios Login(Usuarios usuario);
    }
}
