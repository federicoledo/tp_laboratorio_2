using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    class Calculadora
    {
        /// <summary>
        /// Realiza la operacion que se indica con los valores que se pasan
        /// </summary>
        /// <param name="num1">Primer numero con el que se realiza la operacion</param>
        /// <param name="num2">Segundo numero con el que se realiza la operacion</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        public static double operar(Numero num1, Numero num2, string operador)
        {
            double resultado;

            switch (operador)
            {
                case "+":
                    resultado = num1.getNumero() + num2.getNumero();
                    break;
                case "-":
                    resultado = num1.getNumero() - num2.getNumero();
                    break;
                case "*":
                    resultado = num1.getNumero() * num2.getNumero();
                    break;
                case "/":
                    if (num2.getNumero() == 0)
                        resultado = 0;
                    else
                        resultado = num1.getNumero() / num2.getNumero();
                    break;
                default:
                    resultado = 0;
                    break;
            }
            return resultado;
        }
        /// <summary>
        /// Valida que el operador es correcto
        /// </summary>
        /// <param name="operador">operador </param>
        /// <returns>Si es un operador valido retorna el operador, de lo contrario retorla "+"</returns>
        public static string validarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                operador = "+";

            return operador;
        } 
    }
}
