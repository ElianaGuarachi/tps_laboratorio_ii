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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        List<string> cuentas = new List<string>();

        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento de boton donde se evalua si el usuario quiere salir del programa o no
        /// </summary>
        /// <param name="sender">Parametro de tipo object</param>
        /// <param name="e">Parametro de tipo clase EventArgs</param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento de boton donde se llamara a otros metodos para realizar la conversion de un numero de base decimal a base binario
        /// </summary>
        /// <param name="sender">Parametro de tipo object</param>
        /// <param name="e">Parametro de tipo clase EventArgs</param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();
            string numBinario = numero.DecimalBinario(lblResultado.Text);
            cuentas.Add(numBinario);
            lstOperaciones.DataSource = null;
            lstOperaciones.DataSource = cuentas;
        }

        /// <summary>
        /// Evento de boton que llamara a otros metodos para realizar la conversion de un numero de base banario a base decimal
        /// </summary>
        /// <param name="sender">Parametro de tipo object</param>
        /// <param name="e">Parametro de tipo clase EventArgs</param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();
            string numDecimal = numero.BinarioDecimal(lblResultado.Text);
            cuentas.Add(numDecimal);
            lstOperaciones.DataSource = null;
            lstOperaciones.DataSource = cuentas;
        }

        /// <summary>
        /// Evento del boton limpiar que llama la metodo Limpiar
        /// </summary>
        /// <param name="sender">Parametro de tipo object</param>
        /// <param name="e">Parametro de tipo clase EventArgs</param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Evento del boton operar que llama al metodo operar para mostrar el resultado de las operaciones que se realian
        /// </summary>
        /// <param name="sender">Parametro de tipo object</param>
        /// <param name="e">Parametro de tipo clase EventArgs</param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            for (int i = 0; i < txtNumero1.Text.Length; i++)
            {
                if (txtNumero1.Text[i] > 57 || txtNumero1.Text[i] < 48)
                {
                    txtNumero1.Text = "0";
                    break;
                }
            }

            for (int i = 0; i < txtNumero2.Text.Length; i++)
            {
                if (txtNumero2.Text[i] > 57 || txtNumero2.Text[i] < 48)
                {
                    txtNumero2.Text = "0";
                    break;
                }
            }
            resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

            if (resultado != double.MinValue)
            {
                lblResultado.Text = resultado.ToString();

                cuentas.Add($"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {resultado}");
                lstOperaciones.DataSource = null;
                lstOperaciones.DataSource = cuentas;
            }
        }

        /// <summary>
        /// Evento Load donde se incorporan los items del combobox
        /// </summary>
        /// <param name="sender">Parametro de tipo object</param>
        /// <param name="e">Parametro de tipo clase EventArgs</param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add(' ');
            cmbOperador.Items.Add('+');
            cmbOperador.Items.Add('-');
            cmbOperador.Items.Add('/');
            cmbOperador.Items.Add('*');
            Limpiar();
        }

        /// <summary>
        /// Metodo que pone como vacio a los textboxs y label del form
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
        }

        /// <summary>
        /// Metodo privado y estatico que instancia objetos de tipo Operando para realizar alguna de las operaciones matematicas
        /// </summary>
        /// <param name="numero1">Parametro de tipo string que recibe un numero</param>
        /// <param name="numero2">Pamametro de tipo string que recibe un numero</param>
        /// <param name="operador">Parametro de tipo string que recibe un operador</param>
        /// <returns>Devuelve el resultado de la operacion resultada o 0 si no pudo realizarse</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando op1 = new Operando(numero1);
            Operando op2 = new Operando(numero2);
            char operando;
            double resultado = double.MinValue;

            if (char.TryParse(operador, out operando) && op1 is not null && op2 is not null)
            {
                resultado = Calculadora.Operar(op1, op2, operando);
            }
            
            return resultado;
        }

        /// <summary>
        /// Evento del FormClosing se evalua si el usuario quiere o no salir del programa
        /// </summary>
        /// <param name="sender">Parametro de tipo object</param>
        /// <param name="e">Parametro de tipo clase FormClosingEventArgs</param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            string mensaje = "¿Seguro de querer salir?";
            string titulo = "Salir";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
