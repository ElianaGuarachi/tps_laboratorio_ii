using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        public delegate void DelegadoPagoRealizado();
        public event DelegadoPagoRealizado RealizarPago;

        private int idVenta;
        private string vendedor;
        private string comprador;
        private List<DetalleVenta> detalleVentas;
        private double precioTotal;
        private bool pagoRealizado;
        private string fechaRegistro;

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public string Vendedor { get => vendedor; set => vendedor = value; }
        public string Comprador { get => comprador; set => comprador = value; }
        public List<DetalleVenta> DetalleVentas { get => detalleVentas; set => detalleVentas = value; }
        public double PrecioTotal { get => precioTotal; set => precioTotal = value; }
        public string FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

        public bool PagoRealizado 
        {
            get => this.pagoRealizado;
            set
            {
                this.pagoRealizado = value;
                if (RealizarPago is not null)
                {
                    RealizarPago.Invoke();
                }
            }
        }

        public Venta()
        {
            this.detalleVentas = new List<DetalleVenta>();
            this.pagoRealizado = false;
        }
        
        public Venta(int codigo, string vendedor, string comprador, double precio, bool pagoRealizado, string fecha)
        {
            this.idVenta = codigo;
            this.vendedor = vendedor;
            this.comprador = comprador;
            this.precioTotal = precio;
            this.pagoRealizado = pagoRealizado;
            this.fechaRegistro = fecha;
        }
    }
}
