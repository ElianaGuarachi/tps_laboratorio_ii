using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FileSerializerException: Exception
    {
        /// <summary>
        /// Excepcion que surge cuando hubo un error al serializar
        /// </summary>
        /// <param name="message">Parametro de tipo string</param>
        public FileSerializerException(string message):base(message)
        {

        }

        /// <summary>
        /// Excepcion que surge cuando hubo un error al serializar
        /// </summary>
        /// <param name="message">Parametro de tipo string</param>
        /// <param name="innerException">Parametro de tipo Exception</param>
        public FileSerializerException(string message, Exception innerException):base(message, innerException)
        {

        }
    }
}
