using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaExcepcion:Exception
    {
        #region Constructores

        public NacionalidadInvalidaExcepcion() :
            base()
        {

        }

        public NacionalidadInvalidaExcepcion(string message) :
            base(message)
        {

        }

        #endregion

    }
}
