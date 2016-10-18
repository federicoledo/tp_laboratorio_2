using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using TestEstante;

using System.IO;
using System.Xml;


namespace FormEstante
{
    public partial class FormEstante : Form
    {
        public FormEstante()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Guarda el estante en un archivo txt
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="est"></param>
        private static void GuardarEstante(string nombre, Estante est)
        {
            using (TextWriter writer = new StreamWriter(nombre, false))
            {
                string dato;
                for (int i = 0; i < est.GetProductos().Count; i++)
                {
                    dato = est.GetProductos()[i].ToString();
                    writer.WriteLine(dato);
                }
            }
        }

        /*
         * No funciona correctamente
         * 
         * private static void SerializarEstante(string nombre, Estante est)
        {
            XmlTextWriter writer = new XmlTextWriter(nombre, null);
            string dato;
            for (int i = 0; i < est.GetProductos().Count; i++)
			{
                dato = est.GetProductos()[i].ToString();
                writer.WriteString(dato);
			}            
        }*/


        private void CargarEstante(out Estante est1, out Estante est2)
        {
            const string estante1TXT = "../../../Estante1.txt";
            const string estante2TXT = "../../../Estante2.txt";
           // const string estante1XML = "../../../Estante1.xml";
           // const string estante2XML = "../../../Estante2.xml";
            est1 = new Estante(4);
            est2 = new Estante(3);
            Harina h1 = new Harina(102, 37.5f, Producto.EMarcaProducto.Favorita,
            Harina.ETipoHarina.CuatroCeros);
            Harina h2 = new Harina(103, 40.25f, Producto.EMarcaProducto.Favorita,
            Harina.ETipoHarina.Integral);
            Galletita g1 = new Galletita(113, 33.65f, Producto.EMarcaProducto.Pitusas, 250f);
            Galletita g2 = new Galletita(111, 56f, Producto.EMarcaProducto.Diversión, 500f);
            Jugo j1 = new Jugo(112, 25f, Producto.EMarcaProducto.Naranjú, Jugo.ESaborJugo.Pasable);
            Jugo j2 = new Jugo(333, 33f, Producto.EMarcaProducto.Swift, Jugo.ESaborJugo.Asqueroso);
            Gaseosa g = new Gaseosa(j2, 2250f);
            if (!(est1 + h1))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est1 + g1))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est1 + g2))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est1 + g1))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est1 + j1))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est2 + h2))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est2 + j2))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est2 + g))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est2 + g1))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }

            GuardarEstante(estante1TXT, est1);
            GuardarEstante(estante2TXT, est2);
          //  SerializarEstante(estante1XML, est1);
          //  SerializarEstante(estante2XML, est2);
        }
        /// <summary>
        /// Ordena los productos por marca
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private static int OrdenarProductos(Producto p1, Producto p2)
        {
            return String.Compare((p1.Marca).ToString(), (p2.Marca).ToString());
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            rtxtSalida.Text = "";
            Estante est1;
            Estante est2;
            this.CargarEstante(out est1, out est2);
            rtxtSalida.Text += String.Format("Valor total Estante1: {0}", est1.ValorEstanteTotal);
            rtxtSalida.Text += String.Format("Valor Estante1 sólo de Galletitas: {0}",
            est1.GetValorEstante(Producto.ETipoProducto.Galletita));
            rtxtSalida.Text += String.Format("Contenido Estante1:\n{0}",
            Estante.MostrarEstante(est1));
            rtxtSalida.Text += "Estante ordenado por Marca....\n";
            est1.GetProductos().Sort(FormEstante.OrdenarProductos);
            rtxtSalida.Text += Estante.MostrarEstante(est1);
            est1 = est1 - Producto.ETipoProducto.Galletita;
            rtxtSalida.Text += String.Format("Estante1 sin Galletitas: {0}",
            Estante.MostrarEstante(est1));
            rtxtSalida.Text += String.Format("Contenido Estante2:\n{0}",
            Estante.MostrarEstante(est2));
            est2 -= Producto.ETipoProducto.Todos;
            rtxtSalida.Text += String.Format("Contenido Estante2:\n{0}",
            Estante.MostrarEstante(est2));
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            rtxtSalida.Text = "";
            Estante est1;
            Estante est2;
            this.CargarEstante(out est1, out est2);
            rtxtSalida.Text += "Estante 1 ordenado por Marca....\n";
            est1.GetProductos().Sort(FormEstante.OrdenarProductos);
            rtxtSalida.Text += Estante.MostrarEstante(est1);
            rtxtSalida.Text += "Estante 2 ordenado por Marca....\n";
            est2.GetProductos().Sort(FormEstante.OrdenarProductos);
            rtxtSalida.Text += Estante.MostrarEstante(est2);
        }
    }
}
