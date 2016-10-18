using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita : Producto
    {
        protected float _peso;
        protected static bool DeConsumo;    

        #region Constructores
        /// <summary>
        /// Constructor que invoca al base e inicializa el atributo peso
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="peso"></param>
        public Galletita(int codigo, float precio, EMarcaProducto marca, float peso) :
            base(codigo, marca, precio)
        {
            this._peso = peso;
        }
        /// <summary>
        /// Constructor de clase que inicializa la variable DeConsumo en true
        /// </summary>
        static Galletita()
        {
            DeConsumo = true;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Devuelve el valor del costo de produccion de Galletita
        /// </summary>
        /// <returns></returns>
        public override float CalcularCostoDeProduccion()
        {
            return (float)(0.33 * _precio);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de galletita
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private string MostrarGalletita(Galletita g)
        {
            StringBuilder sb = new StringBuilder();
            string algo = this;
            sb.Append(algo);
            sb.AppendLine("PESO: " + this._peso);
            return sb.ToString();
        }
        /// <summary>
        /// Invoca a MostrarGalletita
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarGalletita(this);
        }
        /// <summary>
        /// Devuelve el texto "Comestible"
        /// </summary>
        /// <returns></returns>
        public override string Consumir()
        {
            return ("Comestible");
        }
        #endregion
    }
}
