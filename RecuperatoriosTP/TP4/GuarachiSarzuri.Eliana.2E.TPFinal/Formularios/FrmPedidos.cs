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

namespace Formularios
{
    public partial class FrmPedidos : Form
    {
        Vendedor vendedor = null;
        Cliente cliente = null;
        Producto producto = null;
        Venta venta;
        List<Producto> listaDeProductos;
        List<DetalleVenta> listaDeProductosVendidos;
        CancellationTokenSource cancellationTokenSource;
        CancellationToken token;
        double precio = 0;

        public FrmPedidos()
        {
            InitializeComponent();
            listaDeProductos = new List<Producto>();
            listaDeProductosVendidos = new List<DetalleVenta>();
            this.cancellationTokenSource = new CancellationTokenSource();
            this.token = cancellationTokenSource.Token;
            this.venta = new Venta();
        }

        /// <summary>
        /// Busca en la base de datos la informacion de un vendedor con la informacion ingresada del dni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtDniVendedor.Text, out int numDni))
                {
                    this.vendedor = DataBaseVendedor.ObtenerVendedorPorDni(numDni);
                    if (this.vendedor is not null)
                    {
                        CompletarInformacionVendedor();
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

        /// <summary>
        /// Muestra informacion parcial del vendedor si se encuentra activo
        /// </summary>
        private void CompletarInformacionVendedor()
        {
            if (this.vendedor.EsActivo)
            {
                txtVendedor.Text = vendedor.MostrarInformacionParcial();
                gbDatosCliente.Enabled = true;
            }
            else
            {
                MostrarMensajeAdvertencia("El vendedor no se escuentra activo");
            }
        }

        /// <summary>
        /// Vacia los textbox que contiene la informacion del cliente
        /// </summary>
        private void LimpiarInformacionCliente()
        {
            txtDni.Text = "";
            txtCodCliente.Text = "";
            txtInfoCliente.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        /// <summary>
        /// Muestra un modelo de mensaje de advertencia con el messegebox
        /// </summary>
        /// <param name="mensaje"></param>
        private void MostrarMensajeAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        /// <summary>
        /// Muestra un modelo de mensaje de informacion con el massegebox
        /// </summary>
        /// <param name="mensaje"></param>
        private void MostrarMensajeInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Obtiene un cliente desde la base de datos a traves del dni ingresado en el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtDni.Text, out int numDni))
                {
                    this.cliente = DataBaseCliente.ObtenerClientePorDni(numDni);
                    if (this.cliente is not null)
                    {
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

        /// <summary>
        /// Cancela el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Evento que permite que habilita el boton de agregar producto una vez obtenido el mismo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                this.producto = BuscarProductoEnLista();
                if (this.producto is not null)
                {
                    CompletarInformacionProducto();
                    btnAgregar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        /// <summary>
        /// Busca el producto seleccionado en el combobox en la lista de productos
        /// </summary>
        /// <returns>El producto de la lista seleccionado</returns>
        /// <exception cref="Exception"></exception>
        private Producto BuscarProductoEnLista()
        {
            foreach (Producto item in this.listaDeProductos)
            {
                if (item.Descripcion == cbxListaProductos.SelectedItem.ToString())
                {
                    return item;
                }
            }
            throw new Exception("Error, el producto no fue encontrado");
        }

        /// <summary>
        /// Completa los textbox del producto con la informacion del mismo
        /// </summary>
        private void CompletarInformacionProducto()
        {            
            txtIdProducto.Text = producto.Id.ToString();
            txtDescripcion.Text = producto.Descripcion;            
            txtStock.Text = producto.Stock.ToString();
            txtPrecio.Text = producto.Precio.ToString();
        }

        /// <summary>
        /// Agregar la informacion del producto a comprar al dataGridView realizando el calculo del subtotal
        /// y el total
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {            
            double subtotal;
            DetalleVenta detalleVenta;
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCantidadProductos.Text) &&
                    this.producto is not null &&
                    int.TryParse(txtCantidadProductos.Text, out int cantidad) &&
                    cantidad <= this.producto.Stock)
                {
                    subtotal = this.producto.Precio * cantidad;
                    CalcularMontoTotal(subtotal);
                    detalleVenta = AgregarProductoAlDetalleDeVenta(cantidad, subtotal);
                    if (detalleVenta is not null)
                    {
                        listaDeProductosVendidos.Add(detalleVenta);
                    }
                    CompletarDataGridProductos(this.producto, subtotal);
                    btnEliminar.Enabled = true;
                    LimpiarInformacionProducto();
                }
                else
                {
                    MostrarMensajeAdvertencia("Debe seleccionar y/o completar toda informacion del producto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Intancia un DetalleVenta con la informacion del producto elegido, la cantidad y el subtotal
        /// </summary>
        /// <param name="cantidad">Parametro de tipo entero</param>
        /// <param name="subtotal">Parametro de tipo double</param>
        /// <returns>Un DetalleVenta instanciado</returns>
        private DetalleVenta AgregarProductoAlDetalleDeVenta(int cantidad, double subtotal)
        {
            DetalleVenta detalleVenta = new DetalleVenta(this.producto.Descripcion, this.producto.Precio,
                cantidad, subtotal, DateTime.Today.ToShortDateString());            
            return detalleVenta;
        }

        /// <summary>
        /// Instancia un fila del DataGridView von la informacion de un producto y el subtotal de la compra del mismo
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="subtotal"></param>
        private void CompletarDataGridProductos(Producto producto, double subtotal)
        {
            DataGridViewRow filaPedido = new DataGridViewRow();
            filaPedido.CreateCells(dgvProductos);
            filaPedido.Cells[0].Value = producto.Codigo;
            filaPedido.Cells[1].Value = producto.Descripcion;
            filaPedido.Cells[2].Value = txtCantidadProductos.Text;
            filaPedido.Cells[3].Value = producto.Precio;
            filaPedido.Cells[4].Value = subtotal.ToString();
            dgvProductos.Rows.Add(filaPedido);
        }

        /// <summary>
        /// Metodo que calcula el monto total de la compra sumando el monto recibido por parametro
        /// </summary>
        /// <param name="precio">Parametro de tipo double</param>
        private void CalcularMontoTotal(double precio)
        {
            this.precio += precio;
            txtTotal.Text = this.precio.ToString();
        }

        /// <summary>
        /// Limpia los textbox que contiene la informacion del producto
        /// </summary>
        private void LimpiarInformacionProducto()
        {
            txtIdProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtCantidadProductos.Text = "";
        }
               
        /// <summary>
        /// Intancia una Venta y un nuevo formulario para procesar el pago, si se realizo el mismo se guardara la informacion 
        /// en la base de datos y actualizara los nuevos stocks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                CompletarVenta();
                if (this.listaDeProductosVendidos.Count > 0)
                {
                    FrmPagoPedido frmRealizarPago = new FrmPagoPedido(this.venta, this.listaDeProductos);
                    DialogResult respuesta = frmRealizarPago.ShowDialog();
                    if (respuesta == DialogResult.OK)
                    {
                        this.venta = frmRealizarPago.Venta;
                        DataBaseProductos.AgregarVenta(this.venta);
                        int idVenta = DataBaseProductos.ObtenerIdVenta(this.venta);

                        foreach (DetalleVenta item in this.listaDeProductosVendidos)
                        {
                            item.IdVenta = idVenta;
                            DataBaseProductos.AgregarDetalleDeProducto(item);
                        }

                        this.listaDeProductos = frmRealizarPago.ListaProductos;
                        foreach (Producto item in this.listaDeProductos)
                        {
                            DataBaseProductos.ActualizarStock(item);
                        }
                        MessageBox.Show("La venta ha sido realizada con exito");

                        LimpiarOrdenDePedidos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Limpia la orden de pedidos para iniciar una nueva compra
        /// </summary>
        private void LimpiarOrdenDePedidos()
        {
            LimpiarInformacionCliente();
            LimpiarInformacionProducto();
            dgvProductos.Rows.Clear();
            gbDatosCliente.Enabled = false;
            gbProducto.Enabled = false;
            listaDeProductosVendidos.Clear();
            this.precio = 0;
        }

        /// <summary>
        /// Completa a traves de las propiedades la instancia de una venta
        /// </summary>
        private void CompletarVenta()
        {
            venta.Vendedor = this.vendedor.MostrarInformacionParcial();
            venta.Comprador = this.cliente.MostrarInformacionParcial();
            venta.DetalleVentas = this.listaDeProductosVendidos;
            venta.PrecioTotal = this.precio;
            venta.FechaRegistro = DateTime.Today.ToShortDateString();
        }

        /// <summary>
        /// Elimina del detalle de venta, una de los productos que al final no se compra, recalculando el total
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Evento que permite tener el horario en el sistema en un segundo hilo, mientras se realiza la carga 
        /// de productos en el hilo principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Obtiene la lista de productos de la base de datos, en el caso que un producto no cuente con stock suficiente,
        /// se abrira un hilo que incrementara el stock, actualizando la indormacion en la base de datos y la lista de productos
        /// </summary>
        private void CargarProductos()
        {
            this.listaDeProductos = DataBaseProductos.ObtenerLista();
            if (listaDeProductos is not null)
            {
                foreach (Producto item in listaDeProductos)
                {
                    cbxListaProductos.Items.Add(item.Descripcion);
                    if (item.Stock <= 15)
                    {
                        Task.Run(() =>
                        {
                            MostrarMensajeInformacion($"Se esta realizando un aumento del stock de {item.Descripcion}");
                            Thread.Sleep(new Random().GetRandom(5000));
                            item.Stock += 100;
                            DataBaseProductos.ActualizarStock(item);
                            MostrarMensajeInformacion("Stock actualizado");
                        });
                    }
                }
            }
        }

        /// <summary>
        /// Iteracion actualizando la hora mientras no haya un cancelacion
        /// </summary>
        /// <param name="cancellation"></param>
        public void AsignarHora(CancellationTokenSource cancellation)
        {
            do
            {
                this.ActualizarHora(DateTime.Now);
                Thread.Sleep(1000);
            } while (!cancellation.IsCancellationRequested);
        }

        /// <summary>
        /// Muestra la hora en el textbox
        /// </summary>
        /// <param name="dateTime"></param>
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
