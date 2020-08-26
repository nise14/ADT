using System;
using System.Collections.Generic;

namespace AccesoDatos.Modelos
{
    public partial class Roles
    {
        public Roles()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string NombreRol { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
