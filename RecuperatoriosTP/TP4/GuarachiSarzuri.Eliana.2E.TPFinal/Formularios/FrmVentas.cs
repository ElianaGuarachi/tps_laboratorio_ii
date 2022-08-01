using Entidades;
using Entidades.BaseDeDatos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmVentas : Form
    {
        List<Venta> listaVentas;
        public FrmVentas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obtiene la lista de las ventas desde la base de datos
        /// </summary>
        public void ObtenerListaVentas()
        {
            this.listaVentas = DataBaseProductos.ObtenerListaVentas();
            if (this.listaVentas is not null)
            {
                dgvVentas.DataSource = this.listaVentas;
                dgvVentas.AutoResizeColumns();
                txtTotalVentas.Text = listaVentas.GetTotalVentas();
            }
            
        }

        /// <summary>
        /// Mantiene actualizado la lista de ventas en el dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                ObtenerListaVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Se selecciona una de las ventas, y con el id de la misma busca el detalle de la misma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvVentas.CurrentRow.Cells[0].Value);
                ObtenerDetalleVenta(id);
                if (id == 0)
                {
                    throw new ParametrosVaciosException("Debe seleccionar una venta para poder ver su detalle");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Busca en la base de datos con el id de la venta el detalle de la venta
        /// </summary>
        /// <param name="idVenta">Parametro de tipo entero que representa el id</param>
        public void ObtenerDetalleVenta(int idVenta)
        {
            dgvDetalleVenta.DataSource = DataBaseProductos.ObtenerDetalleVentaPorIdVenta(idVenta);
            dgvDetalleVenta.AutoResizeColumns();
        }
    }
}
