using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        protected int _codigoBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        public enum EMarcaProducto
        {
            Manaos,
            Pitusas,
            Naranjú,
            Diversión,
            Swift,
            Favorita
        }

        public enum ETipoProducto
        {
            Galletita,
            Gaseosa,
            Jugo,
            Harina,
            Todos
        }

        #region Constructores
        /// <summary>
        /// Inicializa el constructor con los parametros recibidos
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="marca"></param>
        /// <param name="precio"></param>
        public Producto(int codigo, EMarcaProducto marca, float precio)
        {
            this._codigoBarra = codigo;
            this._precio = precio;
            this._marca = marca;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Devuelve el valor marca
        /// </summary>
        public EMarcaProducto Marca
        {
            get
            {
                return this._marca;
            }
        }
        /// <summary>
        /// Devuelve el valor precio
        /// </summary>
        public float Precio
        {
            get
            {
                return this._precio;
            }
        }

        public abstract float CalcularCostoDeProduccion();
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve los datos del producto
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        private static string MostrarProducto(Producto prod)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MARCA: " + prod._marca.ToString());
            sb.AppendLine("CODIGO DE BARRAS: " + prod._codigoBarra.ToString());
            sb.AppendLine("PRECIO: " + prod._precio.ToString());
            return sb.ToString();
        }
        /// <summary>
        /// Devuelve el texto "Parte de una mezcla"
        /// </summary>
        /// <returns></returns>
        public virtual string Consumir()
        {
            return ("Parte de una mezcla");
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Compara si dos productos son iguales
        /// </summary>
        /// <param name="prod1"></param>
        /// <param name="prod2"></param>
        /// <returns>retorna true si son iguales, caso contrario devuelve false</returns>
        public static bool operator ==(Producto prod1, Producto prod2)
        {
            if (prod1._codigoBarra == prod2._codigoBarra && prod1._marca == prod2._marca)
                return true;
            return false;
        }
        /// <summary>
        /// Realiza la operacion contraria al ==
        /// </summary>
        /// <param name="prod1"></param>
        /// <param name="prod2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto prod1, Producto prod2)
        {
            return !(prod1 == prod2);
        }
        /// <summary>
        /// evalua si la marca de un producto es igual a la recibida por parametro
        /// </summary>
        /// <param name="prod"></param>
        /// <param name="marca"></param>
        /// <returns>retorna true si son iguales, caso contrario devuelve false</returns>
        public static bool operator ==(Producto prod, EMarcaProducto marca)
        {
            if (prod._marca == marca)
                return true;
            return false;
        }
        /// <summary>
        /// Realiza operacion contraria al ==
        /// </summary>
        /// <param name="prod"></param>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static bool operator !=(Producto prod, EMarcaProducto marca)
        {
            return !(prod == marca);
        }
        /// <summary>
        /// Devuelve el codigo del producto
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public static explicit operator int(Producto prod)
        {
            return prod._codigoBarra;
        }
        /// <summary>
        /// Invoca a MostrarProducto
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static implicit operator string(Producto p)
        {
            return Producto.MostrarProducto(p);
        }

        /// <summary>
        /// Se fija si los objetos son iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj == this);
        }
        #endregion
    }
}
