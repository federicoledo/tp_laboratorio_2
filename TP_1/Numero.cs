using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    class Numero
    {
        public double num;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Numero()
        {
            this.num = 0;
        }
        /// <summary>
        /// Constructor que recibe un parametro double y lo guarda
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.num = numero;
        }
        /// <summary>
        /// Constructor que recibe un string y lo setea a double
        /// </summary>
        /// <param name="sNumero"></param>
        public Numero(string sNumero)
        {
            this.setNumero(sNumero);
        }
        /// <summary>
        /// Valida el numero pasado por parametro, si se puede lo parsea si no retorna 0
        /// </summary>
        /// <param name="sNumero"></param>
        /// <returns>Retorna el numero parseado o 0</returns>
        private static double validarNumero(string sNumero)
        {
            double final = 0;
            double.TryParse(sNumero, out final);
            return final;
        }
        /// <summary>
        /// Retorna el valor de num
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this.num;
        }
        /// <summary>
        /// Valida el numero pasado por parametro y lo setea 
        /// </summary>
        /// <param name="sNumero"></param>
        private void setNumero(string sNumero)
        {
            this.num = validarNumero(sNumero);
        }
    }
}
