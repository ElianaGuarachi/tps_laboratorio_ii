using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class FueraDeRangoException:Exception
    {
        /// <summary>
        /// Excepcion que se produce cuando los valores se encuentran fuera de un rando establecido
        /// </summary>
        /// <param name="mensaje">Parametro de tipo string</param>
        public FueraDeRangoException(string mensaje):base(mensaje)
        {
        }

        public FueraDeRangoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
