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
        Vendedor nuevoVendedor = null;
        bool cargaRealizada;

        public FrmMenuVendedores()
        {
            InitializeComponent();
            vendedores = new List<Vendedor>();
            cargaRealizada = false;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cargaRealizada)
                {
                    vendedores = DataBaseVendedor.ObtenerLista();
                    CompletarDataGridVendedores();
                    btnNuevoVendedor.Enabled = true;
                    btnModificarVendedor.Enabled = true;
                    btnEliminarVendedor.Enabled = true; 
                    cargaRealizada = true;
                    txtSueldo.Enabled = true;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AgregarCeldaDataGrid(Vendedor vendedor)
        {
            DataGridViewRow registroVendedor = new DataGridViewRow();
            registroVendedor.CreateCells(dgvVendedores);
            registroVendedor.Cells[0].Value = vendedor.Id;
            registroVendedor.Cells[1].Value = vendedor.Dni;
            registroVendedor.Cells[2].Value = vendedor.Nombre;
            registroVendedor.Cells[3].Value = vendedor.Apellido;
            registroVendedor.Cells[4].Value = vendedor.Sueldo;
            dgvVendedores.Rows.Add(registroVendedor);
        }

        private void CompletarDataGridVendedores()
        {
            if (this.vendedores is not null)
            {
                foreach (Vendedor item in this.vendedores)
                {
                    AgregarCeldaDataGrid(item);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool CasillerosVacios(string dni, string nombre, string apellido, string sueldo)
        {
            if (string.IsNullOrWhiteSpace(dni) ||
                    string.IsNullOrWhiteSpace(nombre) ||
                    string.IsNullOrWhiteSpace(apellido) ||
                    string.IsNullOrWhiteSpace(sueldo))
            {
                return true;
            }
            return false;
        }

        private void btnNuevoVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDni.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string sueldo = txtSueldo.Text;

                if (!CasillerosVacios(dni,nombre,apellido,sueldo) &&
                    int.TryParse(dni, out int dniAux) && 
                    double.TryParse(sueldo, out double sueldoAux))
                {
                    if (VerificarDniExistente(dniAux))
                    {
                        MessageBox.Show("El vendedor con el dni ingresado ya existe");
                    }
                    else
                    {
                        nuevoVendedor = new Vendedor(dniAux, nombre, apellido, sueldoAux);
                        DataBaseVendedor.Alta(nuevoVendedor);
                        nuevoVendedor = DataBaseVendedor.ObtenerVendedorPorDni(dniAux);
                        vendedores.Add(nuevoVendedor);
                        AgregarCeldaDataGrid(nuevoVendedor);
                    }
                }
                else
                {
                    throw new ParametrosVacios("Los casilleros deben estar completos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool VerificarDniExistente(int dni)
        {
            foreach (Vendedor item in this.vendedores)
            {
                if (item.Dni == dni)
                {
                    return true;
                }
            }
            return false;
        }

        private void HabitarTextBox()
        {
            txtDni.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtSueldo.Enabled = true;
        }

        private void LimpiarTextBox()
        {
            txtId.Text = "";
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtSueldo.Text = "";
        }

        private void btnModificarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text != string.Empty)
                {
                    string sueldoAux = txtSueldo.Text;
                    if (double.TryParse(sueldoAux, out double sueldo))
                    {
                        this.vendedorSeleccionado.Sueldo = sueldo;
                        DataBaseVendedor.Modificar(this.vendedorSeleccionado);
                        this.vendedores = DataBaseVendedor.ObtenerLista();
                        dgvVendedores.Rows.Clear();
                        CompletarDataGridVendedores();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text != string.Empty)
                {
                    DataBaseVendedor.Eliminar(this.vendedorSeleccionado);
                    dgvVendedores.Rows.Remove(dgvVendedores.CurrentRow);
                    if (this.vendedores.Remove(this.vendedorSeleccionado))
                    {
                        MessageBox.Show("El vendedor ha sido eliminado");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Vendedor ObtenerVendedorSeleccionado()
        {
            if (cargaRealizada)
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
            return null;
        }

        private void InformacionVendedorSeleccionado()
        {
            try
            {
                Vendedor vendedor = ObtenerVendedorSeleccionado();
                if (vendedor is not null)
                {
                    vendedorSeleccionado = vendedor;
                    txtId.Text = vendedor.Id.ToString();
                    txtDni.Text = vendedor.Dni.ToString();
                    txtNombre.Text = vendedor.Nombre;
                    txtApellido.Text = vendedor.Apellido;
                    txtSueldo.Text = vendedor.Sueldo.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Debe seleccionar un vendedor de la lista");
            }            
        }

        private void dgvVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            InformacionVendedorSeleccionado();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTextBox();
            HabitarTextBox();
        }
    }
}
