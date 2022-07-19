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
        private Vendedor vendedor;
        private Cliente cliente;
        private int numeroBoleta;
        private List<DetalleVenta> detalleVentas;
        private double precioTotal;
        private bool pagadoRealizado;
        private string fechaRegistro;

        public int IdVenta { get => idVenta; set => idVenta = value; }
        public Vendedor Vendedor { get => vendedor; set => vendedor = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public List<DetalleVenta> DetalleVentas { get => detalleVentas; set => detalleVentas = value; }
        public double PrecioTotal { get => precioTotal; set => precioTotal = value; }
        public string FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public int NumeroBoleta { get => numeroBoleta; set => numeroBoleta = value; }

        public bool PagoRealizado 
        {
            set
            {
                this.pagadoRealizado = value;
                if (RealizarPago is not null)
                {
                    RealizarPago.Invoke();
                }
            }
        }

        public Venta()
        {
            this.detalleVentas = new List<DetalleVenta>();
            this.pagadoRealizado = false;
        }
    }
}
