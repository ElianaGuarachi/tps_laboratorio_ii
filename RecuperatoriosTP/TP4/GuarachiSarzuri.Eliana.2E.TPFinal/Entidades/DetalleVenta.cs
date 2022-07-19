using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVenta
    {
        private int idDetalleVenta;
        private string producto;
        private double precioVenta;
        private int cantidad;
        private double subtotal;
        private string fechaRegistro;

        public int IdDetalleVenta { get => idDetalleVenta; set => idDetalleVenta = value; }
        public string Producto { get => producto; set => producto = value; }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public string FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    }
}
