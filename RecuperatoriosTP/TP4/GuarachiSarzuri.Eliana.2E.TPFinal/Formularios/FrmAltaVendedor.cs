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
    public partial class FrmAltaVendedor : Form
    {
        List<Vendedor> vendedores;
        Vendedor vendedorNuevo;

        /// <summary>
        /// Propiedad de obtiene el vendedor nuevo desde la base de datos con el dni
        /// </summary>
        public Vendedor VendedorNuevo
        {
            get
            {
                if (vendedorNuevo is not null)
                {
                    return DataBaseVendedor.ObtenerVendedorPorDni(vendedorNuevo.Dni);
                }
                throw new Exception("No se registro un usuario nuevo");
            }
        }

        public FrmAltaVendedor(List<Vendedor> vendedores)
        {
            InitializeComponent();
            this.vendedores = vendedores;
        }

        /// <summary>
        /// Cancela el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Si la informacion es correcta, se dara de alta en la base de datos y enviara el DialogResult.Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Vendedor auxVendedor = CargarDatos();
                if (auxVendedor is not null)
                {
                    this.vendedorNuevo = auxVendedor;
                    DataBaseVendedor.Alta(vendedorNuevo);
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

        /// <summary>
        /// Obtiene la informacion de los textBox, verifica los mismos, si es correcto instancia un nuevo vendedor
        /// con la informacion
        /// </summary>
        /// <returns>Un vendedor con la informacion cargada, o null si la informacion era incorrecta</returns>
        private Vendedor CargarDatos()
        {
            Vendedor vendedor = null;

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = txtDni.Text;
            string sueldo = txtSueldo.Text;

            if (VerificarDatos(nombre, apellido, dni, sueldo))
            {
                throw new ParametrosVaciosException("No puede haber espacios vacios, por favor revise");
            }
            else
            {
                if (int.TryParse(dni, out int numDni) && double.TryParse(sueldo, out double numSueldo))
                {
                    if (BuscarVendedor(numDni))
                    {
                        MessageBox.Show("Ya existe un vendedor registrado con el numero de DNI ingresado",
                            "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCasilleros();
                    }
                    else
                    {
                        vendedor = new Vendedor(numDni, nombre, apellido, numSueldo, true, DateTime.Today.ToShortDateString(), "");
                    }
                }
            }

            return vendedor;
        }

        /// <summary>
        /// Metodo que verifica que los string no sea nulos ni vacios
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="sueldo"></param>
        /// <returns>True si uno o mas de los parametros es nulo o vacio, false si todos estan completos</returns>
        private bool VerificarDatos(string nombre, string apellido, string dni, string sueldo)
        {
            if (string.IsNullOrWhiteSpace(nombre) ||
               string.IsNullOrWhiteSpace(apellido) ||
               string.IsNullOrWhiteSpace(dni) ||
               string.IsNullOrWhiteSpace(sueldo))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Recorre la lista de vendedores, evaluando si algun dni de la lista coincide con el parametro
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>True si hay coincidencia, false si no lo hubo</returns>
        private bool BuscarVendedor(int dni)
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

        /// <summary>
        /// Borra la informacion de los textbox
        /// </summary>
        private void LimpiarCasilleros()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtSueldo.Text = "";
        }
    }
}
