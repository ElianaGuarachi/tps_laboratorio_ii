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
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Evento que controla por DialogResult si se quiere cerrar o no la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = true;
            if (respuesta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
        }

        /// <summary>
        /// Evento en el cual se controla por DialogResult si se quiere cerrar o no la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se accede al Formulario de pedidos (FrmPedidos)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FrmPedidos realizarPedido = new FrmPedidos();
            realizarPedido.ShowDialog();            
        }
               
        /// <summary>
        /// Se accede al Formulario del menu de clientes (FrmMenuCliente)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmMenuCliente menuCliente = new FrmMenuCliente();
            menuCliente.ShowDialog();
        }

        /// <summary>
        /// Se accede al Formulario del menu de vendedores (FrmMenuVendedores)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVendedores_Click(object sender, EventArgs e)
        {
            FrmMenuVendedores menuVendedores = new FrmMenuVendedores();
            menuVendedores.ShowDialog();
        }

        /// <summary>
        /// Se accede al formulario donde se podra ver todas las ventas y los detalles de los mismos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVentas_Click(object sender, EventArgs e)
        {
            FrmVentas ventas = new FrmVentas();
            ventas.ShowDialog();
        }
    }
}
