using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.IO;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Gimnasio
    {
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        public enum EClases { CrossFit = 0, Natacion = 1, Pilates = 2, Yoga = 3 };

        public List<Alumno> LsAlumno
        {
            get
            { return this._alumnos; }
            set
            { this._alumnos = value; }
        }

        public List<Instructor> LsInstr
        {
            get { return this._instructores; }
            set { this._instructores = value; }
        }
        public List<Jornada> LsJorn
        {
            get { return this._jornada; }
            set { this._jornada = value; }
        }
        
        #region Constructores

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// indexador
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this._jornada.Count)
                {
                    return this._jornada[i];
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion  

        #region Metodos
        /// <summary>
        /// Guarda los datos del gimnasio en un archivo xml
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio gim)
        {
            bool aux = false;
            try
            {
                Archivos.cs.Xml<Gimnasio> archivoXml = new Archivos.cs.Xml<Gimnasio>();
                aux = archivoXml.guardar("Gimnasio.xml", gim);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return aux;
        }


        public static Gimnasio Leer()
        {
            Gimnasio gim;
            try
            {
                Archivos.cs.Xml<Gimnasio> auxLeer = new Archivos.cs.Xml<Gimnasio>();
                auxLeer.leer("Gimnasio.xml", out gim);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return gim;
        }



        /// <summary>
        /// Muestra los datos del gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private static string MostrarDatos(Gimnasio g)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in g._jornada)
            {
                sb.AppendLine(jornada.ToString());
            }
            return sb.ToString();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Invoca al metodo mostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
        /// <summary>
        /// Verifica si un gimnasio es igual a un alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            foreach (Alumno item in g._alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Verifica si un gimnasio es distinto a un alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Verifica si un gimnasio es igual a un instructor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item == i)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Verifica si un gimnasio es distinto a un instructor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Verifica si un gimnasio es igual a una clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item == clase)
                    return item;
            }
            throw new SinInstructorException();
        }
        /// <summary>
        /// Verifica si un gimnasio es igual distinto a una clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            Instructor instructorAux = null;
            foreach (Instructor item in g._instructores)
            {
                if (item != clase)
                {
                    instructorAux = item;
                    break;
                }
            }
            return instructorAux;            
        }
        /// <summary>
        /// Agrega un alumno al gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g != a)
                g._alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return g;
        }
        /// <summary>
        /// Agrega un instructor al gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g != i)
                g._instructores.Add(i);
            return g;
        }
        /// <summary>
        /// Agrega una clase al gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Gimnasio.EClases clase)
        {
            try
            {
                Jornada jornada = new Jornada(clase, (g == clase));
                g._jornada.Add(jornada);
                foreach (Alumno item in g._alumnos)
                {
                    if (item == clase)
                        jornada._alumnos.Add(item);
                }
                return g;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
