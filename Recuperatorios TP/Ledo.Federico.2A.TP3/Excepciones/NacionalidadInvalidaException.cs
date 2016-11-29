using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        private static string message = "La nacionalidad no se condice con el numero de DNI";
        #region Constructores

        public NacionalidadInvalidaException() :
            this(message)
        {

        }

        public NacionalidadInvalidaException(string message) :
            base(message)
        {

        }

        #endregion
    }
}
