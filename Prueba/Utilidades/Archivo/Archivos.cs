using System;
using System.IO;

namespace Utilidades.Archivo
{
    public class Archivos
    {
        public static bool EscribirArchivo(string ruta, string nombre, string contenido, string metodo)
        {
            try
            {
                ruta = string.Format("{0}\\{1}", ruta, nombre);

                if (!File.Exists(@ruta))
                {
                    File.Create(@ruta).Dispose();
                }

                using (var escribir = new StreamWriter(@ruta, append: true))
                {
                    var texto = string.Format("{0} | {1} | {2}", DateTime.Today.ToString(), metodo, contenido);
                    escribir.WriteLine(texto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error creando el archivo", ex);
            }

            return true;
        }
    }
}
