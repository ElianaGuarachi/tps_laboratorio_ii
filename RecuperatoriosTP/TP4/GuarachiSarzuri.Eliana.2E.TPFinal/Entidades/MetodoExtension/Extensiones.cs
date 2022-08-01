using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extensiones
    {
        /// <summary>
        /// Extension de la clase random
        /// </summary>
        /// <param name="value">Clase Random</param>
        /// <param name="hasta">Parametro de tipo entero</param>
        /// <returns>Un valor entero</returns>
        public static int GetRandom(this Random value, int hasta)
        {
            return value.Next(1000, hasta);
        }

        /// <summary>
        /// Extension de una coleccion de ventas
        /// </summary>
        /// <param name="lista">Clase de coleccion de Venta</param>
        /// <returns>La cantidad de elementos en formato string</returns>
        public static string GetTotalVentas(this List<Venta> lista)
        {
            return lista.Count().ToString();
        }
    }
}
