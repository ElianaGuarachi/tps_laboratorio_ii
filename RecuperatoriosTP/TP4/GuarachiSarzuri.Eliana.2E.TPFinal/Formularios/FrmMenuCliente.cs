using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    public partial class FrmMenuCliente : Form
    {
        List<Cliente> clientes;
        bool cargaRealizada;

        public FrmMenuCliente()
        {
            InitializeComponent();
            clientes = new List<Cliente>();
            cargaRealizada = false;
        }

        /// <summary>
        /// Busca en la lista de clientes el cliente que es seleccionado en el dataGridView
        /// </summary>
        /// <returns>Retorna al cliente o null en el caso que no haya seleccionado a uno</returns>
        private Cliente ObtenerClienteSeleccionado()
        {
            try
            {
                int dniCliente = (int)dgvClientes.CurrentRow.Cells[1].Value;
                foreach (Cliente item in this.clientes)
                {
                    if (item.Dni == dniCliente)
                    {
                        return item;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Debe seleccionar un cliente de la lista");
            }
            return null;
        }

        /// <summary>
        /// Se accede al formulario donde se realizara el alta a un cliente, luego de realizar el alta
        /// incorpora al nuevo cliente en el dataGridView y en la lista de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmAltaCliente altaCliente = new FrmAltaCliente(this.clientes);
            DialogResult resultado = altaCliente.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Cliente nuevoCliente = altaCliente.ClienteNuevo;
                AgregarCelda(nuevoCliente);
                clientes.Add(nuevoCliente);
            }
            else
            {
                MessageBox.Show("No se realizo ningun alta");
            }
        }

        /// <summary>
        /// Se accede al formulario que realizara la modificacion en el cliente seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = ObtenerClienteSeleccionado();
                if (cliente is not null)
                {
                    FrmModificarCliente modificarCliente = new FrmModificarCliente(cliente);
                    DialogResult resultado = modificarCliente.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        dgvClientes.CurrentRow.Cells[4].Value = cliente.Telefono;
                        dgvClientes.CurrentRow.Cells[5].Value = cliente.Direccion;
                    }
                }
                else
                {
                    throw new Exception("Debe seleccionar un cliente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Elimininara la informacion del cliente seleccionado tanto en la lista de clientes 
        /// como en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = ObtenerClienteSeleccionado();
                if (cliente is not null)
                {
                    DialogResult respuesta = MessageBox.Show($"Esta seguro que desea eliminar al cliente: \n" +
                        $"{cliente.MostrarInformacionParcial()}?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        dgvClientes.Rows.Remove(dgvClientes.CurrentRow);
                        DataBaseCliente.Eliminar(cliente);
                        if (clientes.Remove(cliente))
                        {
                            MessageBox.Show("El cliente fue eliminado con exito");
                        }
                    }
                }
                else
                {
                    throw new Exception("Debe seleccionar un cliente");
                }
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cerrara el formulario actual volviendo al anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Obtendra la lista de todos los clientes de la base de datos guardandolos en una lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cargaRealizada)
                {
                    this.clientes = DataBaseCliente.ObtenerLista();
                    CompletarDataGridConListaDeClientes();
                    HabilitarControles();
                    cargaRealizada = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Habilitara los botones restantes del formulario
        /// </summary>
        private void HabilitarControles()
        {
            btnBuscar.Enabled = true;
            btnModificarCliente.Enabled = true;
            btnNuevoCliente.Enabled = true;
            btnEliminarCliente.Enabled = true;
            btnRefrescar.Enabled = true;
            btnImprimir.Enabled = true;
        }

        /// <summary>
        /// Recorrera la lista de clientes para completar el dataGridView
        /// </summary>
        private void CompletarDataGridConListaDeClientes()
        {
            foreach (Cliente item in this.clientes)
            {
                if (item is not null)
                {
                    AgregarCelda(item);
                }
            }            
        }

        /// <summary>
        /// Agrega una celda al dataGridView con la informacion de un cliente
        /// </summary>
        /// <param name="cliente">Parametro de tipo cliente</param>
        private void AgregarCelda(Cliente cliente)
        {
            DataGridViewRow registroCliente = new DataGridViewRow();
            registroCliente.CreateCells(dgvClientes);
            registroCliente.Cells[0].Value = cliente.Id;
            registroCliente.Cells[1].Value = cliente.Dni;
            registroCliente.Cells[2].Value = cliente.Nombre;
            registroCliente.Cells[3].Value = cliente.Apellido;
            registroCliente.Cells[4].Value = cliente.Telefono;
            registroCliente.Cells[5].Value = cliente.Direccion;
            dgvClientes.Rows.Add(registroCliente);
        }

        /// <summary>
        /// Buscara en la base de datos la informacion del cliente a traves del DNI ingresado, 
        /// o notificara que no existe el mismo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int dni = Convert.ToInt32(txtBuscarPorDni.Text);
                if (dni != 0)
                {                    
                    Cliente cliente = DataBaseCliente.ObtenerClientePorDni(dni);
                    if (cliente is not null)
                    {
                        dgvClientes.Rows.Clear();
                        AgregarCelda(cliente);
                    }
                    else
                    {
                        MessageBox.Show("No hay un cliente con el DNI ingresado");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        /// <summary>
        /// Limpia el dataGridView y completa con nueva informacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            dgvClientes.Rows.Clear();
            CompletarDataGridConListaDeClientes();
        }

        /// <summary>
        /// Se crea una carpeta en el escritorio con la informacion de los clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (this.clientes is not null)
                {
                    foreach (Cliente item in this.clientes)
                    {
                        sb.AppendLine(item.MostrarDatosCompletos());
                    }
                    FileManager.GuardarArchivosGenericos(sb.ToString(), "ListaDeCliente.txt");
                    FileManager.GuardarArchivosGenericos(clientes, "ListaDeCliente.xml");
                    FileManager.GuardarArchivosGenericos(clientes, "ListaDeCliente.json");
                    MessageBox.Show("El archivo se encuentra listo para imprimir");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
