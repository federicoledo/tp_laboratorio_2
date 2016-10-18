using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo : Producto
    {
        protected ESaborJugo _sabor;
        protected static bool DeConsumo;

        public enum ESaborJugo
        {
            Asqueroso,
            Pasable,
        }
        #region Constructores
        /// <summary>
        /// Constructor que invoca al base e inicializa el atributo sabor
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="sabor"></param>
        public Jugo(int codigo, float precio, EMarcaProducto marca, ESaborJugo sabor) :
            base(codigo, marca, precio)
        {
            this._sabor = sabor;
        }
        /// <summary>
        /// Inicializa el atributo DeConsumo como true
        /// </summary>
        static Jugo()
        {
            DeConsumo = true;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Devuelve el valor del costo de produccion de Jugo
        /// </summary>
        /// <returns></returns>
        public override float CalcularCostoDeProduccion()
        {
            return (float)(0.4 * _precio);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de Jugo
        /// </summary>
        /// <returns></returns>
        private string MostrarJugo()
        {
            StringBuilder sb = new StringBuilder();
            string algo = this;
            sb.Append(algo);
            sb.AppendLine("SABOR: " + this._sabor.ToString());
            return sb.ToString();
        }
        /// <summary>
        /// Invoca a MostrarJugo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarJugo();
        }
        /// <summary>
        /// Devuelve el texto "Bebible"
        /// </summary>
        /// <returns></returns>
        public override string Consumir()
        {
            return ("Bebible");
        }
        #endregion
    }
}
