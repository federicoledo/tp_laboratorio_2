using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public string archivo;
        /// <summary>
        /// Constructor del archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        public Texto(string archivo)
        {
            this.archivo = archivo;   
        }
        /// <summary>
        /// Guarda los datos que se le pasan por parametro en un archivo de texto
        /// </summary>
        /// <param name="datos">datos que se van a guardar en el archivo de texto</param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(this.archivo, true))
                {
                    writer.WriteLine(datos);
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Lee los datos desde el archivo de texto y los guarda en la lista
        /// </summary>
        /// <param name="datos">Lista donde se almacenaran los datos leidos</param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            string cadena;
            try
            {
                using (StreamReader reader = new StreamReader(this.archivo))
                {
                    while (null != (cadena = reader.ReadLine()))
                    {
                        datos.Add(cadena);
                    }
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
