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
        public int Stock { get => stock; set => stock = value; }
        public double Precio { get => precio; set => precio = value; }

        public Producto(string codigo, string descripcion, int stock, double precio)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.stock = stock;
            this.precio = precio;
        }

        public Producto(int id, string codigo, string producto, int stock, double precio)
            :this(codigo, producto, stock, precio)
        {
            this.id = id;
        }

        public string MostrarDatosCompletos()
        {
            return $"COD: {Codigo} - DESCRIPCION: {Descripcion} - STOCK: {Stock} - PRECIO: {Precio}";
        }

        public string MostrarInformacionParcial()
        {
            return $"COD: {Codigo} - DESCRIPCION: {Descripcion}";
        }
    }
}
