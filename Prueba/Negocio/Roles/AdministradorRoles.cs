using System;
using System.Collections.Generic;
using System.Text;
using AccesoDatos.Modelos;
using AccesoDatos.Servicio.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Utilidades.Archivo;
using Utilidades.Excepciones;

namespace Negocio.Roles
{
    public class AdministradorRoles : IAdministradorRoles
    {
        IBaseServicioBusqueda<AccesoDatos.Modelos.Roles> servicioBusqueda;
        private IOptions<AppSettings> settings;

        public AdministradorRoles(IBaseServicioBusqueda<AccesoDatos.Modelos.Roles> servicioBusqueda, IOptions<AppSettings> settings)
        {
            this.servicioBusqueda = servicioBusqueda;
            this.settings = settings;
        }

        public List<AccesoDatos.Modelos.Roles> Roles()
        {
            try
            {
                var rols = servicioBusqueda.ListaCompleta();
                
                Archivos.EscribirArchivo(settings.Value.Ruta, settings.Value.Nombre, JsonConvert.SerializeObject(rols), "Roles");

                return rols;
            }
            catch (Exception ex) {
                throw new ExcepcionNegocio("Error no se pueden cargar los roles", ex);
            }
        }
    }
}
