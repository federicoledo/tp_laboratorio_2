using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class PersonaGimnasio:Persona
    {
        public enum EClases { }
        public enum EEstadoCuenta { }

        private int _identificador;

        public int ID
        {
            get { return this._identificador; }
            set { this._identificador = value; }
        }

        public PersonaGimnasio() { }



        #region Constructores

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :
            base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de persona gimnasio
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("CARNET NÚMERO: " + this._identificador);
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Verifica si dos personas son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.GetType() == pg2.GetType() && (pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador))
                return true;
            return false;
        }
        /// <summary>
        /// Verifica si dos personas son distintas
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
