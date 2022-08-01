using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivoException:Exception
    {
        /// <summary>
        /// Excepcion que surge cuando no se puede archivar
        /// </summary>
        /// <param name="message">Parametro de tipo string</param>
        public ArchivoException(string message) : base(message)
        {
        }

        public ArchivoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
