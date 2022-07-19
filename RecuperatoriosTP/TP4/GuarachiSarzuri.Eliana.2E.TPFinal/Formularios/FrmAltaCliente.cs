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
using Excepciones;

namespace Formularios
{
    public partial class FrmAltaCliente : Form
    {
        List<Cliente> clientes;
        Cliente clienteNuevo;

        public Cliente ClienteNuevo
        {
            get
            {
                if (clienteNuevo is not null)
                {
                    return DataBaseCliente.ObtenerClientePorDni(clienteNuevo.Dni);
                }
                throw new Exception("No se registro un usuario nuevo");
            }
        }

        public FrmAltaCliente(List<Cliente> clientes)
        {
            InitializeComponent();
            this.clientes = clientes;
        }

        private Cliente CargarDatos()
        {
            Cliente cliente = null;
           
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = txtDni.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;

            if (VerificarDatos(nombre, apellido, dni, telefono, direccion))
            {
                throw new ParametrosVacios("No puede haber espacios vacios, por favor revise");
            }
            else
            {
                if (int.TryParse(dni, out int numDni))
                {
                    if (BuscarCliente(numDni))
                    {
                        MessageBox.Show("Ya existe un cliente registrado con el numero de DNI ingresado", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCasilleros();                                                
                    }
                    else
                    {
                        cliente = new Cliente(numDni, nombre, apellido, telefono, direccion);
                    }
                }
            }                       

            return cliente;
        }

        private bool BuscarCliente(int dni)
        {
            foreach (Cliente item in this.clientes)
            {
                if (item.Dni == dni)
                {
                    return true;
                }
            }
            return false;
        }

        private void LimpiarCasilleros()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool VerificarDatos(string nombre, string apellido, string dni, string telefono, string direccion)
        {
            if (string.IsNullOrWhiteSpace(nombre) ||
               string.IsNullOrWhiteSpace(apellido) ||
               string.IsNullOrWhiteSpace(dni) ||
               string.IsNullOrWhiteSpace(telefono) ||
               string.IsNullOrWhiteSpace(direccion))
            {
                return true;
            }
                                    
            return false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente auxCliente = CargarDatos();
                if (auxCliente is null)
                {
                    throw new Exception("No se realizo la carga del cliente, intente de nuevo");
                }
                else
                {
                    this.clienteNuevo = auxCliente;
                    DataBaseCliente.Alta(clienteNuevo);
                    LimpiarCasilleros();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (ParametrosVacios ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
