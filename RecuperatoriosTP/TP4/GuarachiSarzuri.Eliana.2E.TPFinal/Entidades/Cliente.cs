using System;
using Excepciones;

namespace Entidades
{
    public class Cliente: Persona, IMostrarInformacion
    {
        private string telefono;
        private string direccion;

        public string Telefono
        {
            get { return this.telefono; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ParametrosVacios("No puede dejar el espacio vacio");
                }
                this.telefono = value;
            }
        }

        public string Direccion
        {
            get { return this.direccion; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ParametrosVacios("No puede dejar el espacio vacio");
                }
                this.direccion = value;
            }
        }

        
        public Cliente(int dni, string nombre, string apellido, string telefono, string direccion)
            : base(nombre, apellido, dni)
        {
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public Cliente(int id, int dni, string nombre, string apellido, string telefono, string direccion)
            :this(dni, nombre, apellido, telefono, direccion)
        {
            this.Id = id;
        }

        public static bool operator ==(Cliente c1, Cliente c2)
        {
            bool retorno = false;
            if (c1 is not null && c2 is not null)
            {
                if (c1.Dni == c2.Dni)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator != (Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }

        public string MostrarDatosCompletos()
        {
            return $"DNI: {Dni} - {Apellido}, {Nombre} - Dir: {Direccion} - Tel: {Telefono}";
        }

        public string MostrarInformacionParcial()
        {
            return $"DNI: {Dni} - {Apellido}, {Nombre}";
        }
    }
}
