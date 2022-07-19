using System;

namespace Excepciones
{
    public class ParametrosVacios:Exception
    {
        public ParametrosVacios(string mensaje):base(mensaje)
        {

        }

        public ParametrosVacios(string mensaje, Exception innerExcepcion):base(mensaje, innerExcepcion)
        {

        }
    }
}
