using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class DataBaseManagerException: Exception
    {
        /// <summary>
        /// Excepcion que surge cuando hubo un error en la conexion a la base de datos
        /// </summary>
        /// <param name="mensaje"></param>
        public DataBaseManagerException(string mensaje) : base(mensaje)
        {

        }

        public DataBaseManagerException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
