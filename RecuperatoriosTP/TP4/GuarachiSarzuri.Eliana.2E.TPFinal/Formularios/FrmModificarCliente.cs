using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Excepciones;
using Entidades;
using Excepciones;

namespace Formularios
{
    public partial class FrmModificarCliente : Form
    {
        public enum OpcionesParaModificar { OpcionTelefono, OpcionDireccion, Ambos}
        Cliente cliente = null;

 
        public FrmModificarCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            lblCliente.Text = this.cliente.MostrarDatosCompletos();
        }
        
        private void cbxTelefono_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTelefono.CheckState == CheckState.Checked)
            {
                txtNuevoTelefono.Enabled = true;
            }
            else
            {
                txtNuevoTelefono.Enabled = false;
                txtNuevoTelefono.Text = string.Empty;
            }
        }

        private void cbxModificarDireccion_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxModificarDireccion.CheckState == CheckState.Checked)
            {
                txtNuevaDireccion.Enabled = true;
            }
            else
            {
                txtNuevaDireccion.Enabled = false;
                txtNuevaDireccion.Text = string.Empty;
            }
        }

        private OpcionesParaModificar VerificarEstadoCheckBox()
        {            
            if (cbxModificarDireccion.CheckState == CheckState.Checked && cbxTelefono.CheckState == CheckState.Checked)
            {
                return OpcionesParaModificar.Ambos;
            }
            else if(cbxModificarDireccion.CheckState == CheckState.Checked)
            {
                return OpcionesParaModificar.OpcionDireccion;
            }
            else if (cbxTelefono.CheckState == CheckState.Checked)
            {
                return OpcionesParaModificar.OpcionTelefono;
            }
            throw new Exception("Debe seleccionar una opcion para modificar");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.cliente = null;
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {                
                switch (VerificarEstadoCheckBox())
                {
                    case OpcionesParaModificar.OpcionTelefono:
                        btnGuardar.Enabled = true;
                        cliente.Telefono = txtNuevoTelefono.Text;
                        lblCliente.Text = cliente.ToString();
                        break;

                    case OpcionesParaModificar.OpcionDireccion:
                        btnGuardar.Enabled = true;
                        cliente.Direccion = txtNuevaDireccion.Text;
                        lblCliente.Text = cliente.ToString();
                        break;

                    case OpcionesParaModificar.Ambos:
                        btnGuardar.Enabled = true;
                        cliente.Telefono = txtNuevoTelefono.Text;
                        cliente.Direccion = txtNuevaDireccion.Text;
                        lblCliente.Text = cliente.ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataBaseCliente.Modificar(this.cliente);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
