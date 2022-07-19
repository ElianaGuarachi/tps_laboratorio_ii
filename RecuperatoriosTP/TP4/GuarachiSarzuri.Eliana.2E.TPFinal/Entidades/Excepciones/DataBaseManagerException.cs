using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class DataBaseManagerException: Exception
    {
        public DataBaseManagerException():base()
        {

        }

        public DataBaseManagerException(string mensaje) : base(mensaje)
        {

        }

        public DataBaseManagerException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
