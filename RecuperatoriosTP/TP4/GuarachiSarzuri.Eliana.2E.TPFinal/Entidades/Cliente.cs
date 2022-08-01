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
                    throw new ParametrosVaciosException("No puede dejar el espacio vacio");
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
                    throw new ParametrosVaciosException("No puede dejar el espacio vacio");
                }
                this.direccion = value;
            }
        }

        public Cliente()
        {

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

        /// <summary>
        /// Metodo de interfaz que permite mostrar toda la informacion de un cliente
        /// </summary>
        /// <returns>Un string con la informacion</returns>
        public string MostrarDatosCompletos()
        {
            return $"Id: {Id} \t DNI: {Dni} \t {Apellido}, {Nombre} \t Dir: {Direccion} \t Tel: {Telefono}";
        }

        /// <summary>
        /// Metodo de interfaz que muestra el DNI y nombre completo del cliente
        /// </summary>
        /// <returns>Un string con la informacion</returns>
        public string MostrarInformacionParcial()
        {
            return $"DNI: {Dni} - {Apellido}, {Nombre}";
        }
                
    }
}
