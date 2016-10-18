using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Harina : Producto
    {
        protected ETipoHarina _tipo;
        protected static bool DeConsumo;

        public enum ETipoHarina
        {
            CuatroCeros,
            TresCeros,
            Integral
        }

        #region Constructores
        /// <summary>
        /// Constructor que invoca al base e inicializa el atributo tipo
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="tipo"></param>
        public Harina(int codigo, float precio, EMarcaProducto marca, ETipoHarina tipo) :
            base(codigo, marca, precio)
        {
            this._tipo = tipo;
        }
        /// <summary>
        /// Inicializa el atributo DeConsumo como true
        /// </summary>
        static Harina()
        {
            DeConsumo = false;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Devuelve el valor del costo de produccion de Harina
        /// </summary>
        /// <returns></returns>
        public override float CalcularCostoDeProduccion()
        {
            return (float)(0.6 * _precio);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de Harina
        /// </summary>
        /// <returns></returns>
        private string MostrarHarina()
        {
            StringBuilder sb = new StringBuilder();
            string algo = this;
            sb.Append(algo);
            sb.AppendLine("TIPO: " + this._tipo);
            return sb.ToString();
        }
        /// <summary>
        /// Invoca a MostrarHarina
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarHarina();
        }
        #endregion
    }
}
