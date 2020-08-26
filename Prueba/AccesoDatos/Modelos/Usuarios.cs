using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccesoDatos.Modelos
{
    public partial class Usuarios
    {
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public int? RolId { get; set; }

        public Roles Rol { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
