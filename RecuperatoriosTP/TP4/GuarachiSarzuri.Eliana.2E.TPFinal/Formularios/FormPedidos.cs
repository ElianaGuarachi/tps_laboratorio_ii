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
using Entidades;
using Entidades.BaseDeDatos;
using Excepciones;

namespace Formularios
{
    public partial class FormPedidos : Form
    {
        Vendedor vendedor = null;
        Cliente cliente = null;
        Producto producto = null;
        Venta venta = null;
        List<Producto> listaDeProductos;
        List<DetalleVenta> listaDeProductosVendidos;
        CancellationTokenSource cancellationTokenSource;
        CancellationToken token;
        double precio = 0;

        public FormPedidos()
        {
            InitializeComponent();
            listaDeProductos = new List<Producto>();
            listaDeProductosVendidos = new List<DetalleVenta>();
            this.cancellationTokenSource = new CancellationTokenSource();
            this.token = cancellationTokenSource.Token;
            this.venta = new Venta();
        }

        private void btnBuscarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtDniVendedor.Text, out int numDni))
                {
                    Vendedor vendedorAux = DataBaseVendedor.ObtenerVendedorPorDni(numDni);
                    if (vendedorAux is not null)
                    {
                        this.vendedor = vendedorAux;
                        txtVendedor.Text = vendedor.MostrarInformacionParcial();
                        gbDatosCliente.Enabled = true;
                    }
                    else
                    {
                        MostrarMensajeAdvertencia("No hay un vendedor con el DNI ingresado");
                        txtVendedor.Text = "";
                        txtDniVendedor.Text = "";
                        gbDatosCliente.Enabled = false;
                        gbProducto.Enabled = false;
                        LimpiarInformacionCliente();
                    }
                }
                else
                {
                    MostrarMensajeAdvertencia("Debe ingresar solamente numeros para el DNI");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarMensajeAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtDni.Text, out int numDni))
                {
                    Cliente clienteAux = DataBaseCliente.ObtenerClientePorDni(numDni);
                    if (clienteAux is not null)
                    {
                        this.cliente = clienteAux;
                        txtInfoCliente.Text = $"{cliente.Nombre} {cliente.Apellido}";
                        txtCodCliente.Text = cliente.Id.ToString();
                        txtTelefono.Text = cliente.Telefono;
                        txtDireccion.Text = cliente.Direccion;
                        btnPagar.Enabled = true;
                        gbProducto.Enabled = true;
                    }
                    else
                    {
                        MostrarMensajeAdvertencia("No hay un cliente con el DNI ingresado");
                        LimpiarInformacionCliente();
                    }
                }
                else
                {
                    MostrarMensajeAdvertencia("Debe ingresar solamente numeros para el DNI");
                    txtDni.Text = "";
                    txtInfoCliente.Text = "";
                    gbProducto.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cancellationTokenSource.Cancel();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                this.producto = BuscarProductoEnLista();
                if (this.producto is not null)
                {
                    txtIdProducto.Text = producto.Id.ToString();
                    txtDescripcion.Text = producto.Descripcion;
                    txtStock.Text = producto.Stock.ToString();
                    txtPrecio.Text = producto.Precio.ToString();
                    btnAgregar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private Producto BuscarProductoEnLista()
        {
            foreach (Producto item in listaDeProductos)
            {
                if (item.Descripcion == cbxListaProductos.SelectedItem.ToString())
                {
                    return item;
                }
            }
            throw new Exception("Error, el producto no fue encontrado");
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {            
            double precio;
            DetalleVenta detalleVenta;
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCantidadProductos.Text) &&
                    producto is not null &&
                    int.TryParse(txtCantidadProductos.Text, out int cantidad) &&
                    cantidad <= producto.Stock)
                {
                    precio = producto.Precio * cantidad;
                    CalcularMontoTotal(precio);
                    detalleVenta = AgregarProductoAlDetalleDeVenta(cantidad, precio);
                    if (detalleVenta is not null)
                    {
                        listaDeProductosVendidos.Add(detalleVenta);
                    }
                    CompletarDataGridProductos(producto, precio);
                    btnEliminar.Enabled = true;
                    LimpiarInformacionProducto();
                }
                else
                {
                    MostrarMensajeAdvertencia("Debe ingresar una cantidad valida");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DetalleVenta AgregarProductoAlDetalleDeVenta(int cantidad, double subtotal)
        {
            DetalleVenta detalleVenta = new DetalleVenta();
            detalleVenta.Producto = this.producto.Descripcion;
            detalleVenta.PrecioVenta = this.producto.Precio;
            detalleVenta.Cantidad = cantidad;
            detalleVenta.Subtotal = subtotal;
            detalleVenta.FechaRegistro = DateTime.Now.Date.ToShortDateString();
            return detalleVenta;
        }

        private void CompletarDataGridProductos(Producto producto, double precio)
        {
            DataGridViewRow filaPedido = new DataGridViewRow();
            filaPedido.CreateCells(dgvProductos);
            filaPedido.Cells[0].Value = producto.Codigo;
            filaPedido.Cells[1].Value = producto.Descripcion;
            filaPedido.Cells[2].Value = txtCantidadProductos.Text;
            filaPedido.Cells[3].Value = producto.Precio;
            filaPedido.Cells[4].Value = precio.ToString();
            dgvProductos.Rows.Add(filaPedido);
        }

        private void CalcularMontoTotal(double precio)
        {
            this.precio += precio;
            txtTotal.Text = this.precio.ToString();
        }

        private void LimpiarInformacionProducto()
        {
            txtIdProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtCantidadProductos.Text = "";
        }

        private void LimpiarInformacionCliente()
        {
            txtDni.Text = "";
            txtCodCliente.Text = "";
            txtInfoCliente.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            CompletarVenta();
            FrmPagoPedido realizarPago = new FrmPagoPedido(this.venta, this.listaDeProductos);
            realizarPago.ShowDialog();
            if (realizarPago.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("La venta ha sido realizada con exito");
                Serializadora.GuardarArchivosGenericos<Venta>(venta, "venta1.txt");
                this.listaDeProductos = realizarPago.ListaProductos;
                foreach (Producto item in this.listaDeProductos)
                {
                    DataBaseProductos.ActualizarStock(item);
                }
            }
        }

        private void ImprimirTicket()
        {

        }

        private void CompletarVenta()
        {
            venta.Vendedor = this.vendedor;
            venta.Cliente = this.cliente;
            venta.DetalleVentas = this.listaDeProductosVendidos;
            venta.PrecioTotal = this.precio;
            venta.FechaRegistro = DateTime.Now.Date.ToShortDateString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {                
                string precio = dgvProductos.CurrentRow.Cells[4].Value.ToString();
                string producto = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                dgvProductos.Rows.Remove(dgvProductos.CurrentRow);
                if (double.TryParse(precio, out double precioAux))
                {
                    this.precio -= precioAux;
                    txtTotal.Text = this.precio.ToString();
                }

                foreach (DetalleVenta item in this.listaDeProductosVendidos)
                {
                    if (producto == item.Producto)
                    {
                        this.listaDeProductosVendidos.Remove(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => AsignarHora(cancellationTokenSource), token);

                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarProductos()
        {
            this.listaDeProductos = DataBaseProductos.ObtenerLista();
            if (listaDeProductos is not null)
            {
                foreach (Producto item in listaDeProductos)
                {
                    cbxListaProductos.Items.Add(item.Descripcion);
                }
            }
        }

        public void AsignarHora(CancellationTokenSource cancellation)
        {
            do
            {
                this.ActualizarHora(DateTime.Now);
                Thread.Sleep(1000);
            } while (!cancellation.IsCancellationRequested);
        }

        private void ActualizarHora(DateTime dateTime)
        {
            if (this.InvokeRequired)
            {
                Action<DateTime> callback = new Action<DateTime>(ActualizarHora);
                object[] arrayCallback = { dateTime };
                this.BeginInvoke(callback, arrayCallback);
            }
            else
            {
                this.Text = $"{dateTime}";
            }
        }
    }
}
