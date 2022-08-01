using Entidades.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto:IMostrarInformacion
    {
        private int id;
        private string codigo;
        private string descripcion;
        private int stock;
        private double precio;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Stock {   get => this.stock; set => this.stock = value; }
        public double Precio { get => precio; set => precio = value; }

        public Producto()
        {

        }

        public Producto(string codigo, string descripcion, int stock, double precio)
        {
            this.Codigo = codigo;
            this.Descripcion = descripcion;
            this.Stock = stock;
            this.Precio = precio;
        }

        public Producto(int id, string codigo, string producto, int stock, double precio)
            :this(codigo, producto, stock, precio)
        {
            this.Id = id;
        }

        /// <summary>
        /// Metodo de interfaz que permite mostrar toda la informacion de un producto
        /// </summary>
        /// <returns>Un string con la informacion</returns>
        public string MostrarDatosCompletos()
        {
            return $"COD: {Codigo} - DESCRIPCION: {Descripcion} - STOCK: {Stock} - PRECIO: {Precio}";
        }

        /// <summary>
        /// Meotdo de interfaz que permite mostrar informacion parcial de un producto
        /// </summary>
        /// <returns>Un string con la informacion</returns>
        public string MostrarInformacionParcial()
        {
            return $"COD: {Codigo} - DESCRIPCION: {Descripcion}";
        }
    }
}
