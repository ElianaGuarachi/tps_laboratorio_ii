using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrarInformacion
    {
        /// <summary>
        /// Metodo que interfaz que debera mostrar una informacion completa de una clase
        /// </summary>
        /// <returns>Un string</returns>
        public string MostrarDatosCompletos();

        /// <summary>
        /// Metodo de interfaz que mostrara los datos parciales de una clase
        /// </summary>
        /// <returns>Un string</returns>
        public string MostrarInformacionParcial();

    }
}
