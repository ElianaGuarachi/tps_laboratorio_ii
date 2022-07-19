using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public abstract class Persona
    {
        private int id;
        private int dni;
        private string nombre;
        private string apellido;
        
        public int Id { get => this.id; set => this.id = value; }
        public int Dni { get => this.dni; set => this.dni = value; }
        public string Nombre { get => this.nombre; set => this.nombre = value; }
        public string Apellido { get => this.apellido; set => this.apellido = value; }
       

        public Persona(int id, string nombre, string apellido, int dni)
           : this(nombre, apellido, dni)
        {
            this.id = id;
        }

        public Persona(string nombre, string apellido, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;            
        }

        
    }
}
