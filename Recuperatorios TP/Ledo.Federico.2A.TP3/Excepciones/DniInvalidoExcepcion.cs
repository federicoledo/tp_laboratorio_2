using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoExcepcion:Exception
    {

        private string mensajeBase;
        //Revisar, estan todos mal los constructores
        #region Constructores

        public DniInvalidoExcepcion() :
            base()
        {
            
        }

        public DniInvalidoExcepcion(Exception e):
            base()
        {
            
        }

        public DniInvalidoExcepcion(string mensaje) :
            base(mensaje)
        {

        }

        public DniInvalidoExcepcion(string mensaje, Exception e) :
            base()
        {

        }

        #endregion

    }
}
