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
    public partial class FrmMenuVendedores : Form
    {
        List<Vendedor> vendedores;
        Vendedor vendedorSeleccionado = null;
        Vendedor vendedorNuevo = null;
        bool cargaRealizada;

        public FrmMenuVendedores()
        {
            InitializeComponent();
            vendedores = new List<Vendedor>();
            cargaRealizada = false;
        }

        /// <summary>
        /// Evento click que obtiene la lista de los vendedores de la base de datos,
        /// habilita el resto de los controladores y manda a completar el dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cargaRealizada)
                {
                    this.vendedores = DataBaseVendedor.ObtenerLista();
                    CompletarDataGridVendedores(this.vendedores);
                    btnNuevoVendedor.Enabled = true;
                    btnBajaVendedor.Enabled = true;
                    btnEliminarVendedor.Enabled = true;
                    btnImprimir.Enabled = true;
                    cargaRealizada = true;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Metodo que instancia una fila del dataGridView completando con la informacion de un vendedor
        /// </summary>
        /// <param name="vendedor">Parametro de tipo Vendedor</param>
        private void AgregarCeldaDataGrid(Vendedor vendedor)
        {
            DataGridViewRow registroVendedor = new DataGridViewRow();
            registroVendedor.CreateCells(dgvVendedores);
            registroVendedor.Cells[0].Value = vendedor.Id;
            registroVendedor.Cells[1].Value = vendedor.Dni;
            registroVendedor.Cells[2].Value = vendedor.Nombre;
            registroVendedor.Cells[3].Value = vendedor.Apellido;
            registroVendedor.Cells[4].Value = vendedor.Sueldo;
            registroVendedor.Cells[5].Value = vendedor.FechaAlta;
            registroVendedor.Cells[6].Value = vendedor.FechaBaja;
            dgvVendedores.Rows.Add(registroVendedor);
        }

        /// <summary>
        /// Metodo que recorre la lista de vendedores y agrega a cada uno al DataGridView
        /// </summary>
        /// <param name="vendedores"></param>
        private void CompletarDataGridVendedores(List<Vendedor> vendedores)
        {
            if (vendedores is not null)
            {
                foreach (Vendedor item in vendedores)
                {
                    AgregarCeldaDataGrid(item);
                }
            }
        }

        /// <summary>
        /// Cancela el formulario y lo cierra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Abre el formulario de alta, si la respuesta del formulario es OK, se incorpora al nuevo vendedor
        /// tanto a la lista del sistema como a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevoVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAltaVendedor altaVendedor = new FrmAltaVendedor(this.vendedores);
                DialogResult respuesta = altaVendedor.ShowDialog();

                if (respuesta == DialogResult.OK)
                {
                    vendedorNuevo = altaVendedor.VendedorNuevo;
                    vendedores.Add(vendedorNuevo);
                    AgregarCeldaDataGrid(vendedorNuevo);
                }
                else
                {
                    MessageBox.Show("No se registro ningun vendedor nuevo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       

        /// <summary>
        /// Metodo que busca en  la lista de vendedores, el vendedor que esta siendo seleccionado en el DataGridView
        /// </summary>
        /// <returns>El vendedor seleccionado, o null si no se selecciona a nadie del dataGridView</returns>
        private Vendedor ObtenerVendedorSeleccionado()
        {
            try
            {
                int dniVendedor = (int)dgvVendedores.CurrentRow.Cells[1].Value;
                foreach (Vendedor item in this.vendedores)
                {
                    if (item.Dni == dniVendedor)
                    {
                        return item;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Debe seleccionar un vendedor de la lista");
            }
            return null;
        }

        /// <summary>
        /// Gusrda la informacion de la lista de clientes en tres archivos con diferentes formatos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (this.vendedores is not null)
                {
                    foreach (Vendedor item in this.vendedores)
                    {
                        sb.AppendLine(item.MostrarDatosCompletos());
                    }
                    FileManager.GuardarArchivosGenericos(sb.ToString(), "ListaDeVendedores.txt");
                    FileManager.GuardarArchivosGenericos(vendedores, "ListaDeVendedores.xml");
                    FileManager.GuardarArchivosGenericos(vendedores, "ListaDeVendedores.json");
                    MessageBox.Show("El archivo se encuentra listo para imprimir");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Al vendedor seleccionado lo da de baja sumando la fecha, guardando la informacion en la lista
        /// de vendedores y en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBajaVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                this.vendedorSeleccionado = ObtenerVendedorSeleccionado();
                if (this.vendedorSeleccionado is not null && this.vendedorSeleccionado.EsActivo)
                {
                    this.vendedorSeleccionado.EsActivo = false;
                    this.vendedorSeleccionado.FechaBaja = DateTime.Today.ToShortDateString();
                    DataBaseVendedor.DarDeBaja(this.vendedorSeleccionado);
                    int index = vendedores.IndexOf(vendedorSeleccionado);
                    vendedores[index] = vendedorSeleccionado;
                    dgvVendedores.Rows.Clear();
                    CompletarDataGridVendedores(this.vendedores);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un vendedor");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Si el vendedor seleccionado fue dado de baja previamente, se lo podra eliminar de la base de datos y la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                this.vendedorSeleccionado = ObtenerVendedorSeleccionado();
                if (vendedorSeleccionado is not null)
                {
                    if (!vendedorSeleccionado.EsActivo)
                    {
                        DialogResult respuesta = MessageBox.Show($"Esta seguro/a que desea eliminar al vendedor/a: \n" +
                        $"{this.vendedorSeleccionado.MostrarInformacionParcial()}", "Alerta", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                        if (respuesta == DialogResult.Yes)
                        {
                            DataBaseVendedor.Eliminar(this.vendedorSeleccionado);
                            dgvVendedores.Rows.Remove(dgvVendedores.CurrentRow);
                            if (this.vendedores.Remove(this.vendedorSeleccionado))
                            {
                                MessageBox.Show("El vendedor ha sido eliminado");

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para eliminar al vendedor debe darlo de baja primero");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
