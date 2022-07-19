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


namespace Formularios
{
    public partial class FrmPrincipal : Form
    {

        CancellationTokenSource cancellationTokenSource;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
                     
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

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FormPedidos realizarPedido = new FormPedidos();
            DialogResult resultado = realizarPedido.ShowDialog();

            if (resultado == DialogResult.OK)
            {

            }
            else
            {
                MessageBox.Show("No se realizo ningun pedido");
            }
        }

        

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmMenuCliente menuCliente = new FrmMenuCliente();
            DialogResult resultado = menuCliente.ShowDialog();
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            FrmMenuVendedores menuVendedores = new FrmMenuVendedores();
            DialogResult resultado = menuVendedores.ShowDialog();
        }
    }
}
