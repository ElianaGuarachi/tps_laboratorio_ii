using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vendedor:Persona, IMostrarInformacion
    {
        private double sueldo;
        private bool esActivo;
        private string fechaAlta;
        private string fechaBaja;

        public double Sueldo { get => this.sueldo; set => this.sueldo = value; }
        public bool EsActivo { get => esActivo; set => esActivo = value; }
        public string FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public string FechaBaja { get => fechaBaja; set => fechaBaja = value; }

        public Vendedor()
        {

        }

        public Vendedor(int dni, string nombre, string apellido, double sueldo, bool esActivo, string fechaAlta, string fechaBaja)
            : base(nombre, apellido, dni)
        {
            this.sueldo = sueldo;
            this.esActivo = esActivo;
            this.fechaAlta = fechaAlta;
            this.fechaBaja = fechaBaja;
        }

        public Vendedor(int id, int dni, string nombre, string apellido, double sueldo, bool esActivo, string fechaAlta, string fechaBaja)
            :this(dni, nombre, apellido, sueldo, esActivo, fechaAlta, fechaBaja)
        {
            this.Id = id;
        }

        /// <summary>
        /// Metodo de interfaz que permite mostrar los datos completos de un vendedor
        /// </summary>
        /// <returns>Un string con toda la informacion de un vendedor</returns>
        public string MostrarDatosCompletos()
        {
            return $"Dni: {Dni} - {Apellido}, {Nombre} - Sueldo: {Sueldo} - Fecha de alta: {fechaAlta}";
        }

        /// <summary>
        /// Metodo de interfaz que permite mostrar los datos parciales de un vendedor
        /// </summary>
        /// <returns>Un string con informacion</returns>
        public string MostrarInformacionParcial()
        {
            return $"Dni: {Dni} - {Apellido}, {Nombre}";
        }

    }
}
