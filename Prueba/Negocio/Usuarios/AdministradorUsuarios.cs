using AccesoDatos.Modelos;
using AccesoDatos.Servicio.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utilidades.Archivo;
using Utilidades.Encripcion;
using Utilidades.Excepciones;

namespace Negocio.Usuarios
{
    public class AdministradorUsuarios : IAdministradorUsuarios
    {
        IbaseServicio<AccesoDatos.Modelos.Usuarios> servicio;
        IServicioLogin servicioLogin;
        IBaseServicioBusqueda<AccesoDatos.Modelos.Usuarios> servicioBusqueda;

        private IOptions<AppSettings> settings;

        public AdministradorUsuarios(IbaseServicio<AccesoDatos.Modelos.Usuarios> servicio, IBaseServicioBusqueda<AccesoDatos.Modelos.Usuarios> servicioBusqueda, IOptions<AppSettings> settings
            , IServicioLogin servicioLogin)
        {
            this.servicio = servicio;
            this.servicioBusqueda = servicioBusqueda;
            this.settings = settings;
            this.servicioLogin = servicioLogin;
        }

        /// <summary>
        /// Consultar un usuario
        /// </summary>
        /// <param name="identificacion">identificacion del usuario</param>
        /// <returns>usuarios</returns>
        public AccesoDatos.Modelos.Usuarios Consultar(int identificacion)
        {
            try
            {
                var consulta = servicioBusqueda.Consultar(identificacion); ;
                Archivos.EscribirArchivo(settings.Value.Ruta, settings.Value.Nombre, JsonConvert.SerializeObject(consulta), "Consultar");

                return consulta;
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error no se pueden consultar el usuario", ex);
            }
        }

        public bool Eliminar(int identificacion)
        {
            try
            {
                var usuarioEliminar = servicioBusqueda.Consultar(identificacion);

                return servicio.Eliminar(usuarioEliminar);
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error no se puede eliminar un usuario", ex);
            }
        }

        public bool Insertar(AccesoDatos.Modelos.Usuarios usuario)
        {
            try
            {
                usuario.Clave = Encripcion.ComputeSha256Hash(usuario.Clave);
                return servicio.Insertar(usuario);
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error no se puede insertar un usuario", ex);
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public AccesoDatos.Modelos.Usuarios Login(AccesoDatos.Modelos.Usuarios usuario)
        {
            AccesoDatos.Modelos.Usuarios lg = null;

            try
            {
                usuario.Clave = Encripcion.ComputeSha256Hash(usuario.Clave);

                lg = servicioLogin.Login(usuario);

                if (lg != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(settings.Value.SecretKey);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, lg.Identificacion.ToString()),
                            new Claim("RolId",lg.RolId.GetValueOrDefault().ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    lg.Token = tokenHandler.WriteToken(token);
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error no se puede insertar un usuario", ex);
            }

            return lg;
        }
    }
}
