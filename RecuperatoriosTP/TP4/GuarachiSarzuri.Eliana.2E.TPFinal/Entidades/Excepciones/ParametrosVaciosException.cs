using System;

namespace Excepciones
{
    public class ParametrosVaciosException:Exception
    {
        /// <summary>
        /// Excepcion que se produce cuando los parametros se encuentran vacios
        /// </summary>
        /// <param name="mensaje">Parametro de tipo string</param>
        public ParametrosVaciosException(string mensaje):base(mensaje)
        {

        }

        public ParametrosVaciosException(string mensaje, Exception innerExcepcion):base(mensaje, innerExcepcion)
        {

        }
    }
}
