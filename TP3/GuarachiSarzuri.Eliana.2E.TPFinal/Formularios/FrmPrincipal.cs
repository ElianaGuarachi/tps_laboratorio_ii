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
    public partial class FrmPrincipal : Form
    {
        private List<Cliente> listaClientes;

        public List<Cliente> ListaClientes
        {
            get
            {
                return this.listaClientes;
            }
        }
        public FrmPrincipal()
        {
            InitializeComponent();
            this.listaClientes = new List<Cliente>();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarDatos();
           
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmAltaCliente altaCliente = new FrmAltaCliente();
            DialogResult resultado = altaCliente.ShowDialog();

            if (resultado == DialogResult.OK)
            {             
                this.listaClientes.Add(altaCliente.RetornarCliente);                
                ActualizarDatos();
            }
            else
            {
                MessageBox.Show("No se realizo el alta de un cliente nuevo");
            }

        }
               

        public void ActualizarDatos()
        {
            ltbMuestra.DataSource = null;
            ltbMuestra.DataSource = listaClientes;
        }                      

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            FrmModificarCliente modificarCliente = new FrmModificarCliente();
            DialogResult resultado = modificarCliente.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                
                ActualizarDatos();
            }
            else
            {
                MessageBox.Show("No se realizo la modificacion del cliente seleccionado");
            }
        }

        private void btnArchivar_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("El archivo esta listo para imprimir");

        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = true;
            if (respuesta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
