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

        public double Sueldo { get => this.sueldo; set => this.sueldo = value; }

        public Vendedor(int dni, string nombre, string apellido, double sueldo)
            : base(nombre, apellido, dni)
        {
            this.sueldo = sueldo;
        }

        public Vendedor(int id, int dni, string nombre, string apellido, double sueldo)
            :this(dni, nombre, apellido, sueldo)
        {
            this.Id = id;
        }

        public string MostrarDatosCompletos()
        {
            return $"Dni: {Dni} - {Apellido}, {Nombre} - Sueldo: {Sueldo}";
        }

        public string MostrarInformacionParcial()
        {
            return $"Dni: {Dni} - {Apellido}, {Nombre}";
        }

        public static bool operator ==(Vendedor v1, Vendedor v2)
        {
            bool retorno = false;
            if (v1 is not null && v2 is not null)
            {
                if (v1.Dni == v2.Dni)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Vendedor v1, Vendedor v2)
        {
            return !(v1 == v2);
        }
    }
}
