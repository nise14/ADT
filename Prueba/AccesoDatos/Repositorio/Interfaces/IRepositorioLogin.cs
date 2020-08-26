using AccesoDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Repositorio.Interfaces
{
    public interface IRepositorioLogin
    {
        Usuarios Login(Usuarios usuario);
    }
}
