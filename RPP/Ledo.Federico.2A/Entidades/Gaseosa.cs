using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa : Producto
    {
        protected float _litros;
        protected static bool DeConsumo;

        #region Constructores
        /// <summary>
        /// Constructor que invoca al base e inicializa el atributo litros
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="litros"></param>
        public Gaseosa(int codigo, float precio, EMarcaProducto marca, float litros) :
            base(codigo, marca, precio)
        {
            this._litros = litros;
        }
        /// <summary>
        /// Constructor que invoca al constructor de gaseosa y le pasa los datos del objeto recibido
        /// </summary>
        /// <param name="prod"></param>
        /// <param name="litros"></param>
        public Gaseosa(Producto prod, float litros) :
            this((int)prod, prod.Precio, prod.Marca, litros)
        {

        }
        /// <summary>
        /// Inicializa el atributo DeConsumo como true
        /// </summary>
        static Gaseosa()
        {
            DeConsumo = true;
        }
#endregion

        #region Propiedades
        /// <summary>
        /// Devuelve el valor del costo de produccion de Gaseosa
        /// </summary>
        /// <returns></returns>
        public override float CalcularCostoDeProduccion()
        {
            return (float)(0.42 * _precio);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de gaseosa
        /// </summary>
        /// <returns></returns>
        private string MostrarGaseosa()
        {
            StringBuilder sb = new StringBuilder();
            string algo = this;
            sb.Append(algo);
            sb.AppendLine("LITROS: " + this._litros.ToString());
            return sb.ToString();
        }
        /// <summary>
        /// Invoca a MostrarGaseosa
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarGaseosa();
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
