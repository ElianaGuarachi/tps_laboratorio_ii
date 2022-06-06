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
        Cliente clienteNuevo;

        public Cliente RetornarCliente
        {
            get
            {
                return this.clienteNuevo;
            }
        }

        public FrmAltaCliente()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
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
                    Serializadora.EscribirArchivoTxt("ListaClientes.txt", auxCliente, true);
                    this.clienteNuevo = auxCliente;
                    this.DialogResult = DialogResult.OK;
                }                
            }
            catch(ParametrosVacios ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                if (int.TryParse(dni, out int numDni) && int.TryParse(telefono, out int numTelefono))
                {
                    cliente = new Cliente(nombre, apellido, numDni, numTelefono, direccion);
                }
            }                       

            return cliente;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool VerificarDatos(string nombre, string apellido, string dni, string telefono, string direccion)
        {
            bool retorno = false;
            if (string.IsNullOrWhiteSpace(nombre) ||
               string.IsNullOrWhiteSpace(apellido) ||
               string.IsNullOrWhiteSpace(dni) ||
               string.IsNullOrWhiteSpace(telefono) ||
               string.IsNullOrWhiteSpace(direccion))
            {
                retorno = true;
            }
                                    
            return retorno;
        }
    }
}
