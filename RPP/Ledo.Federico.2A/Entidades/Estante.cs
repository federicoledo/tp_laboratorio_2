using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estante
    {
        protected byte _capacidad;
        protected List<Producto> _productos;

        #region Constructores
        /// <summary>
        /// Constructor que inicializa la lista de productos
        /// </summary>
        private Estante()
        {
            _productos = new List<Producto>();
        }
        /// <summary>
        /// Constructor que inicializa la capacidad del estante con la que recibe por parametro
        /// </summary>
        /// <param name="capacidad"></param>
        public Estante(byte capacidad)
            : this()
        {
            this._capacidad = capacidad;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Retorna el valor total del estante
        /// </summary>
        public float ValorEstanteTotal
        {
            get
            {
                return this.GetValorEstante();
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna la lista de productos
        /// </summary>
        /// <returns></returns>
        public List<Producto> GetProductos()
        {
            return this._productos;
        }
        /// <summary>
        /// Devuelve el valor de todos los productos del estante
        /// </summary>
        /// <returns></returns>
        public float GetValorEstante()
        {
            return this.GetValorEstante(Producto.ETipoProducto.Todos);
        }
        /// <summary>
        /// Devuelve el valor de la suma de los productos del tipo pasado por parametro
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float acum = 0;
            foreach (Producto item in this._productos)
            {
                if (item is Galletita && (tipo == Producto.ETipoProducto.Galletita || tipo == Producto.ETipoProducto.Todos))
                    acum += item.Precio;
                if (item is Jugo && (tipo == Producto.ETipoProducto.Jugo || tipo == Producto.ETipoProducto.Todos))
                    acum += item.Precio;
                if (item is Gaseosa && (tipo == Producto.ETipoProducto.Gaseosa || tipo == Producto.ETipoProducto.Todos))
                    acum += item.Precio;
                if (item is Harina && (tipo == Producto.ETipoProducto.Harina || tipo == Producto.ETipoProducto.Todos))
                    acum += item.Precio;
            }
            return acum;
        }
        /// <summary>
        /// Muestra la informacion del estante que recibe por parametro
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CAPACIDAD: " + e._capacidad);
            foreach (var item in e._productos)
            {
                if (item is Galletita)
                    sb.AppendLine(((Galletita)item).ToString());
                if (item is Jugo)
                    sb.AppendLine(((Jugo)item).ToString());
                if (item is Gaseosa)
                    sb.AppendLine(((Gaseosa)item).ToString());
                if (item is Harina)
                    sb.AppendLine(((Harina)item).ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Se fija si el producto se encuentra ya cargado en el estante
        /// </summary>
        /// <param name="e"></param>
        /// <param name="prod"></param>
        /// <returns>Devuelve true si el producto se encuentra en el estante, de lo contrario devuelve false</returns>
        public static bool operator ==(Estante e, Producto prod)
        {
            foreach (Producto item in e._productos)
            {
                if (item == prod)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Realiza la operacion contraria al == que recibe como parametros un estante y un producto
        /// </summary>
        /// <param name="e"></param>
        /// <param name="prod"></param>
        /// <returns></returns>
        public static bool operator !=(Estante e, Producto prod)
        {
            return !(e == prod);
        }
        /// <summary>
        /// Se fija si el producto esta en el estante, y si no esta lo agrega
        /// </summary>
        /// <param name="e"></param>
        /// <param name="prod"></param>
        /// <returns></returns>
        public static bool operator +(Estante e, Producto prod)
        {
            if (e._capacidad > e._productos.Count() && (e != prod))
            {
                e._productos.Add(prod);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Se fija si el producto esta cargado en el estante, si esta lo borra
        /// </summary>
        /// <param name="e"></param>
        /// <param name="prod"></param>
        /// <returns></returns>
        public static Estante operator -(Estante e, Producto prod)
        {
            if (e == prod)
            {
                e._productos.Remove(prod);
                return e;
            }
            else
                return null;
        }
        /// <summary>
        /// Elimina los productos del estante que coinciden con el tipo de producto pasado por parametro
        /// </summary>
        /// <param name="est"></param>
        /// <param name="tipo"></param>
        /// <returns>Devuelve un nuevo estante sin los productos eliminados</returns>
        public static Estante operator -(Estante est, Producto.ETipoProducto tipo)
        {
            Estante estAux = new Estante();
            estAux._capacidad = est._capacidad;
            estAux._productos = new List<Producto>(est._productos);
            foreach (Producto item in est._productos)
            {
                if (item is Galletita && tipo == Producto.ETipoProducto.Galletita)
                {
                    estAux = estAux - item;
                }
                else if (item is Gaseosa && tipo == Producto.ETipoProducto.Gaseosa)
                {
                    estAux = estAux - item;
                }
                else if (item is Jugo && tipo == Producto.ETipoProducto.Jugo)
                {
                    estAux = estAux - item;
                }
                else if (item is Harina && tipo == Producto.ETipoProducto.Harina)
                {
                    estAux = estAux - item;
                }
                else if (tipo == Producto.ETipoProducto.Todos)
                {
                    estAux._productos.Clear();
                    break;
                }
            }
            return estAux;
        }
#endregion
    }
}
