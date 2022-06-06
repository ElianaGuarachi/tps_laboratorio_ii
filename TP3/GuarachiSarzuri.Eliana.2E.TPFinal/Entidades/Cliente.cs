using System;
using Excepciones;

namespace Entidades
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private int dni;
        private int telefono;
        private string direccion;


        public string Nombre
        {
            get { return this.nombre; }            
        }

        public string Apellido
        {
            get { return this.apellido; }            
        }

        public int Dni
        {
            get { return this.dni; }            
        }

        public int Telefono
        {
            get { return this.telefono; }
            set 
            {
                if (value <= 0)
                {
                    throw new FueraDeRangoException("El telefono no puede ser igual o inferior a 0");
                }
                this.telefono = value; 
            }
        }

        public string Direccion
        {
            get { return this.direccion; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("No puede dejar el espacio vacio");
                }
                this.direccion = value; 
            }
        }

        public Cliente()
        {
        }

        public Cliente(string nombre, string apellido, int dni, int telefono, string direccion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;
            this.direccion = direccion;
        }

        public static bool operator ==(Cliente c1, Cliente c2)
        {
            bool retorno = false;
            if (c1 is not null && c2 is not null)
            {
                if (c1.Nombre == c2.Nombre && c1.Apellido == c2.Apellido && c1.Dni == c2.Dni)
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

        public override string ToString()
        {
            return $"{Apellido}, {Nombre} - Dni: {Dni} - Dir: {Direccion} - Tel: {Telefono}";
        }

    }
}
