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

        public Venta Venta { get => this.venta; }

        public FrmPagoPedido(Venta venta, List<Producto> listaDeProductos)
        {
            InitializeComponent();
            this.venta = venta;
            this.listaDeProductos = listaDeProductos;
            this.venta.RealizarPago += RecalcularStockProductos;
        }

        /// <summary>
        /// Evento que mostrara el monto total de la venta que se debe pagar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPagoPedido_Load(object sender, EventArgs e)
        {
            txtPrecio.Text = venta.PrecioTotal.ToString("0.00");
        }

        /// <summary>
        /// Si el radiobutton actual esta siendo seleccionado, habiliara el groupbox de efectivo, 
        /// sino lo deshabilitara
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Si el radiobutton actual esta siendo seleccionado, habiliara el groupbox de la tarjeta,
        /// sino lo deshabilitara
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Controla que el monto en efectivo sea mayor o igual al monto a pagar, o que los datos de la tarjeta
        /// haya sido completado correctamente para procesar el pago
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcesarPago_Click(object sender, EventArgs e)
        {
            try
            {                
                if (gbEfectivo.Enabled && !string.IsNullOrWhiteSpace(txtMonto.Text))
                {
                    double monto = Convert.ToDouble(txtMonto.Text);
                    if (monto != 0 && monto >= venta.PrecioTotal)
                    {
                        this.venta.PagoRealizado = true;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("El monto no puede ser inferior al total de la venta");
                    }
                }

                if (gbTarjetas.Enabled)
                {                    
                    if (!VerificarDatos())
                    {
                        this.venta.PagoRealizado = true;
                        Thread.Sleep(new Random().GetRandom(3000));
                        MessageBox.Show($"Se cobro en la tarjeta la suma de ${venta.PrecioTotal}");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Los datos de la tarjeta deben estar completos");
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Metodo que recorre la lista de productos y el detalle de la venta en ventas, haciendo match y disminuyendo
        /// el stock del producto de acuerdo a la cantidad del detalle de venta
        /// </summary>
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

        /// <summary>
        /// Calcula el cambio a partir del monto ingresado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Evento que solo permite ingresar numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Verifica que los datos de la tarjeta deben estar completos
        /// </summary>
        /// <returns>False si hay informacion</returns>
        /// <exception cref="ParametrosVaciosException"></exception>
        private bool VerificarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtDigitos.Text) ||
                string.IsNullOrWhiteSpace(txtTitular.Text) ||
                string.IsNullOrWhiteSpace(txtCodigoSeguridad.Text) ||
                string.IsNullOrWhiteSpace(txtVencimiento.Text))
            {
                throw new ParametrosVaciosException("Debe completar los casilleros");
            }
            return false;
        }

        /// <summary>
        /// Evento que solo permite ingresar numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCodigoSeguridad_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
