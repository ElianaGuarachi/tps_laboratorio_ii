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

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = ObtenerClienteSeleccionado();
                if (cliente is not null)
                {
                    DialogResult respuesta = MessageBox.Show($"Esta seguro que desea eliminar al cliente: " +
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cargaRealizada)
                {
                    this.clientes = DataBaseCliente.ObtenerLista();
                    CompletarDataGridConClienteEncontrado();
                    btnBuscar.Enabled = true;
                    btnModificarCliente.Enabled = true;
                    btnNuevoCliente.Enabled = true;
                    btnEliminarCliente.Enabled = true;
                    btnRefrescar.Enabled = true;
                    cargaRealizada = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CompletarDataGridConClienteEncontrado()
        {
            foreach (Cliente item in this.clientes)
            {
                if (item is not null)
                {
                    AgregarCelda(item);
                }
            }            
        }

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

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            dgvClientes.Rows.Clear();
            CompletarDataGridConClienteEncontrado();
        }
    }
}
