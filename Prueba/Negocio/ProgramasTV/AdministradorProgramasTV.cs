using AccesoDatos.Modelos;
using AccesoDatos.Servicio.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Utilidades.Archivo;
using Utilidades.Excepciones;

namespace Negocio.ProgramasTV
{
    public class AdministradorProgramasTV : IAdministradorProgramasTV
    {
        IbaseServicio<ProgramasTv> servicio;
        IBaseServicioBusqueda<ProgramasTv> servicioBusqueda;
        private IOptions<AppSettings> settings;

        public AdministradorProgramasTV(IbaseServicio<ProgramasTv> servicio, IBaseServicioBusqueda<ProgramasTv> servicioBusqueda, IOptions<AppSettings> settings)
        {
            this.servicio = servicio;
            this.servicioBusqueda = servicioBusqueda;
            this.settings = settings;
        }

        /// <summary>
        /// Insertar programas
        /// </summary>
        /// <returns></returns>
        public List<Programas> CargarPeliculas()
        {
            var programas = new List<Programas>();

            try
            {
                using (var client = new HttpClient())
                {
                    var responseMessage = client.GetAsync("http://api.tvmaze.com/schedule").Result;
                    var result = responseMessage.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
                    var jsonResponse = (JArray)JsonConvert.DeserializeObject(result);

                    var shows = jsonResponse.ToList();

                    for (var i = 0; i < shows.Count; i++)
                    {
                        var programa = new Programas();
                        programa.id = Convert.ToInt32(shows[i]["show"]["id"]);
                        programa.name = Convert.ToString(shows[i]["show"]["name"]);
                        programa.language = Convert.ToString(shows[i]["show"]["language"]);
                        var hayImagenes = shows[i]["show"]["image"].ToList();
                        programa.image = hayImagenes.Count == 0 ? "" : shows[i]["show"]["image"]["medium"].ToString();
                        programas.Add(programa);
                    }

                    var buscar = servicioBusqueda.ListaCompleta();
                    if (buscar.Any())
                    {
                        servicio.Eliminar(buscar.FirstOrDefault());
                    }

                    var programaTv = new ProgramasTv();
                    programaTv.Id = 1;
                    programaTv.Programa = JsonConvert.SerializeObject(programas);
                    Archivos.EscribirArchivo(settings.Value.Ruta,settings.Value.Nombre, programaTv.Programa, "CargarPeliculas");

                    servicio.Insertar(programaTv);
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error no se pueden cargar las peliculas", ex);
            }

            return programas;
        }

        public List<Programas> Buscar(string palabra)
        {
            var programas = new List<Programas>();

            try
            {
                using (var client = new HttpClient())
                {
                    var responseMessage = client.GetAsync(string.Concat("http://api.tvmaze.com/singlesearch/shows?q=", palabra)).Result;
                    var result = responseMessage.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
                    var jsonResponse = (JObject)JsonConvert.DeserializeObject(result);

                    var shows = jsonResponse;

                    var programa = new Programas();
                    programa.id = Convert.ToInt32(shows["id"]);
                    programa.name = Convert.ToString(shows["name"]);
                    programa.language = Convert.ToString(shows["language"]);
                    var hayImagenes = shows["image"].ToList();
                    programa.image = hayImagenes.Count == 0 ? "" : shows["image"]["medium"].ToString();
                    programas.Add(programa);

                    var buscar = servicioBusqueda.ListaCompleta();
                    if (buscar.Any())
                    {
                        servicio.Eliminar(buscar.FirstOrDefault());
                    }

                    var programaTv = new ProgramasTv();
                    programaTv.Id = 1;
                    programaTv.Programa = JsonConvert.SerializeObject(programas);
                    Archivos.EscribirArchivo(settings.Value.Ruta, settings.Value.Nombre, programaTv.Programa, "Buscar");

                    servicio.Insertar(programaTv);
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio("Error no se pueden buscar las peliculas", ex);
            }

            return programas;
        }
    }
}
