using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos.cs
{
    public class Xml<T>:IArchivo<T> where T : class
    {
        public bool guardar(string archivo, T datos)
        {
            bool aux = true;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(writer, datos);
                }
            }
            catch
            {
                aux = false;
                throw new Exception("No se pudo guardar el archivo como Xml.");
            }
            return aux;
        }

        public bool leer(string archivo, out T datos)
        {
            bool aux = true;
            try
            {
                using (XmlTextReader lector = new XmlTextReader(archivo))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    datos = (T)serializador.Deserialize(lector);
                }
            }
            catch
            {
                aux = false;
                datos = null;
                throw new Exception("No se pudo leer del archivo.");
            }
            return aux;
        }
    }
}
