using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosExcepcion:Exception
    {
        #region Constructores

        public ArchivosExcepcion(Exception InnerException) :
            base("Message", InnerException)
        {

        }

        #endregion
    }
}
