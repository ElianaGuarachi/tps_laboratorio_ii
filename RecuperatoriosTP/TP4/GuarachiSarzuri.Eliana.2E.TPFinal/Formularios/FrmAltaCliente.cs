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

        /// <summary>
        /// Propiedad que retorna un cliente de la base de datos por el dni
        /// </summary>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Metodo que crea un cliente nuevo con la informacion ingresada y verificada
        /// </summary>
        /// <returns>Un cliente con su informacion completa, o null si no se realizo la carga</returns>
        /// <exception cref="ParametrosVaciosException"></exception>
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
                throw new ParametrosVaciosException("No puede haber espacios vacios, por favor revise");
            }
            else
            {
                if (int.TryParse(dni, out int numDni))
                {
                    if (BuscarCliente(numDni))
                    {
                        MessageBox.Show("Ya existe un cliente registrado con el numero de DNI ingresado", 
                            "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// Metodo que busca a traves del dni un cliente en la lista de clientes
        /// </summary>
        /// <param name="dni">Parametro entero que representa en dni</param>
        /// <returns>True si el cliente esta en la lista, o false si no esta</returns>
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

        /// <summary>
        /// Metodo que borra la informacion previamente ingresada en los textbox
        /// </summary>
        private void LimpiarCasilleros()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        /// <summary>
        /// Evento que cancelara el proceso de creacion de cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Metodo que verifica que los datos ingresados no sean nulos o vacios
        /// </summary>
        /// <param name="nombre">Parametro de tipo string</param>
        /// <param name="apellido">Parametro de tipo string</param>
        /// <param name="dni">Parametro de tipo string</param>
        /// <param name="telefono">Parametro de tipo string</param>
        /// <param name="direccion">Parametro de tipo string</param>
        /// <returns>True si un dato es nulo o vacio. Si todos estan completos devuelve false</returns>
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

        /// <summary>
        /// Metodo que guarda el cliente nuevo en la base de datos y notifica con un DialogResult.OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente auxCliente = CargarDatos();
                if (auxCliente is not null)
                {
                    this.clienteNuevo = auxCliente;
                    DataBaseCliente.Alta(clienteNuevo);
                    LimpiarCasilleros();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (ParametrosVaciosException ex)
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
