using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class FueraDeRangoException:Exception
    {
        public FueraDeRangoException(string mensaje):base(mensaje)
        {
        }

        public FueraDeRangoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}
