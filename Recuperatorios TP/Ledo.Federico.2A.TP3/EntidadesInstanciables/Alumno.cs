using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
[Serializable]
    public sealed class Alumno:PersonaGimnasio
    {
        public enum EEstadoCuenta { Deudor, AlDia, MesPrueba }

        private Gimnasio.EClases _clasesQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno()
        { }

        public Gimnasio.EClases ClaseQueToma
        {
            get
            { return this._clasesQueToma; }
            set
            { this._clasesQueToma = value; }

        }
        public EEstadoCuenta EstadoCuenta
        {
            get
            { return this._estadoCuenta; }
            set
            { this._estadoCuenta = value; }
        }

        #region Constructores 
       
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma) :
            this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.MesPrueba)
        {
            
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._estadoCuenta = estadoCuenta;
            this._clasesQueToma = claseQueToma;
        }

#endregion

        #region Sobrecargas
        /// <summary>
        /// Retorna las clases que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TOMA CLASES DE " + this._clasesQueToma.ToString());
            return sb.ToString();
        }
        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Invoca al metodo mostrardatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Verifica si un alumno es igual a una clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (a._clasesQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }
        /// <summary>
        /// Verifica si un alumno es distinto a una clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (a._clasesQueToma != clase)
                return true;
            return false;
        }

        #endregion
    }
}
