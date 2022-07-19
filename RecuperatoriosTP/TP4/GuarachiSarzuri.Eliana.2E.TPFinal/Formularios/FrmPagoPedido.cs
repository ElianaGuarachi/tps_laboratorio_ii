using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmPagoPedido : Form
    {
        List<Producto> listaDeProductos;
        Venta venta;

        public List<Producto> ListaProductos
        {
            get { return this.listaDeProductos; }
        }

        public FrmPagoPedido(Venta venta, List<Producto> listaDeProductos)
        {
            InitializeComponent();
            this.venta = venta;
            this.listaDeProductos = listaDeProductos;
            this.venta.RealizarPago += RecalcularStockProductos;
        }

        private void FrmPagoPedido_Load(object sender, EventArgs e)
        {
            txtPrecio.Text = venta.PrecioTotal.ToString("0.00");
        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEfectivo.Checked)
            {
                gbEfectivo.Enabled = true;
                txtMonto.Enabled = true;
            }
            else
            {
                gbEfectivo.Enabled = false;
                txtMonto.Enabled = false;
                txtMonto.Text = "";
                txtCambio.Text = "";
            }
        }

        private void rbtTarjeta_CheckedChanged(object sender, EventArgs e)
        {            
            if (rbtTarjeta.Checked)
            {
                gbTarjetas.Enabled = true;
            }
            else
            {
                gbTarjetas.Enabled = false;
            }
        }

        private void btnProcesarPago_Click(object sender, EventArgs e)
        {
            try
            {              
                if (gbEfectivo.Enabled && !string.IsNullOrWhiteSpace(txtMonto.Text))
                {
                    this.venta.PagoRealizado = true;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (gbTarjetas.Enabled && !VerificarDatos())
                    {
                        this.venta.PagoRealizado = true;
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void RecalcularStockProductos()
        {            
            foreach (DetalleVenta detalleVenta in this.venta.DetalleVentas)
            {
                foreach (Producto item in this.listaDeProductos)
                {
                    if (detalleVenta.Producto == item.Descripcion)
                    {
                        item.Stock -= detalleVenta.Cantidad;
                    }
                }
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (double.TryParse(txtMonto.Text, out double monto) && monto >= venta.PrecioTotal)
            {
                double cambio = monto - venta.PrecioTotal;
                if (e.KeyChar == (char)13)
                {
                    txtCambio.Text = cambio.ToString("0.00");
                }
            }
        }

        private void txtDigitos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private bool VerificarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtDigitos.Text) ||
                string.IsNullOrWhiteSpace(txtTitular.Text) ||
                string.IsNullOrWhiteSpace(txtCodigoSeguridad.Text) ||
                string.IsNullOrWhiteSpace(txtVencimiento.Text))
            {
                return true;
            }
            throw new ParametrosVacios("Debe completar los casilleros");
        }
    }
}
