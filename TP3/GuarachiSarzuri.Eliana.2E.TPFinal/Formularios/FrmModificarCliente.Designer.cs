
namespace Formularios
{
    partial class FrmModificarCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBuscador = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblClienteEncontrado = new System.Windows.Forms.Label();
            this.lblSeleccionar = new System.Windows.Forms.Label();
            this.txtBuscarPorDni = new System.Windows.Forms.TextBox();
            this.txtNuevoTelefono = new System.Windows.Forms.TextBox();
            this.txtNuevaDireccion = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtClienteEncontrado = new System.Windows.Forms.TextBox();
            this.cbxTelefono = new System.Windows.Forms.CheckBox();
            this.cbxModificarDireccion = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBuscador
            // 
            this.lblBuscador.AutoSize = true;
            this.lblBuscador.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBuscador.Location = new System.Drawing.Point(22, 24);
            this.lblBuscador.Name = "lblBuscador";
            this.lblBuscador.Size = new System.Drawing.Size(95, 20);
            this.lblBuscador.TabIndex = 0;
            this.lblBuscador.Text = "Ingrese Dni: ";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCliente.Location = new System.Drawing.Point(23, 75);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(60, 20);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblClienteEncontrado
            // 
            this.lblClienteEncontrado.AutoSize = true;
            this.lblClienteEncontrado.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblClienteEncontrado.Location = new System.Drawing.Point(102, 75);
            this.lblClienteEncontrado.Name = "lblClienteEncontrado";
            this.lblClienteEncontrado.Size = new System.Drawing.Size(0, 20);
            this.lblClienteEncontrado.TabIndex = 2;
            // 
            // lblSeleccionar
            // 
            this.lblSeleccionar.AutoSize = true;
            this.lblSeleccionar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblSeleccionar.Location = new System.Drawing.Point(43, 128);
            this.lblSeleccionar.Name = "lblSeleccionar";
            this.lblSeleccionar.Size = new System.Drawing.Size(325, 20);
            this.lblSeleccionar.TabIndex = 3;
            this.lblSeleccionar.Text = "*Solo se puede modificar el telefono y la direccion";
            // 
            // txtBuscarPorDni
            // 
            this.txtBuscarPorDni.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBuscarPorDni.Location = new System.Drawing.Point(135, 21);
            this.txtBuscarPorDni.Name = "txtBuscarPorDni";
            this.txtBuscarPorDni.Size = new System.Drawing.Size(150, 27);
            this.txtBuscarPorDni.TabIndex = 4;
            // 
            // txtNuevoTelefono
            // 
            this.txtNuevoTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtNuevoTelefono.Location = new System.Drawing.Point(215, 190);
            this.txtNuevoTelefono.Name = "txtNuevoTelefono";
            this.txtNuevoTelefono.Size = new System.Drawing.Size(255, 27);
            this.txtNuevoTelefono.TabIndex = 7;
            // 
            // txtNuevaDireccion
            // 
            this.txtNuevaDireccion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtNuevaDireccion.Location = new System.Drawing.Point(215, 247);
            this.txtNuevaDireccion.Name = "txtNuevaDireccion";
            this.txtNuevaDireccion.Size = new System.Drawing.Size(255, 27);
            this.txtNuevaDireccion.TabIndex = 8;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAceptar.Location = new System.Drawing.Point(308, 325);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(97, 40);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtClienteEncontrado
            // 
            this.txtClienteEncontrado.Enabled = false;
            this.txtClienteEncontrado.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtClienteEncontrado.Location = new System.Drawing.Point(135, 72);
            this.txtClienteEncontrado.Name = "txtClienteEncontrado";
            this.txtClienteEncontrado.Size = new System.Drawing.Size(150, 27);
            this.txtClienteEncontrado.TabIndex = 12;
            // 
            // cbxTelefono
            // 
            this.cbxTelefono.AutoSize = true;
            this.cbxTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxTelefono.Location = new System.Drawing.Point(34, 190);
            this.cbxTelefono.Name = "cbxTelefono";
            this.cbxTelefono.Size = new System.Drawing.Size(161, 24);
            this.cbxTelefono.TabIndex = 13;
            this.cbxTelefono.Text = "Modificar Telefono:";
            this.cbxTelefono.UseVisualStyleBackColor = true;
            // 
            // cbxModificarDireccion
            // 
            this.cbxModificarDireccion.AutoSize = true;
            this.cbxModificarDireccion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxModificarDireccion.Location = new System.Drawing.Point(34, 247);
            this.cbxModificarDireccion.Name = "cbxModificarDireccion";
            this.cbxModificarDireccion.Size = new System.Drawing.Size(167, 24);
            this.cbxModificarDireccion.TabIndex = 14;
            this.cbxModificarDireccion.Text = "Modificar Direccion:";
            this.cbxModificarDireccion.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(80, 325);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 40);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmModificarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 394);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cbxModificarDireccion);
            this.Controls.Add(this.cbxTelefono);
            this.Controls.Add(this.txtClienteEncontrado);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNuevaDireccion);
            this.Controls.Add(this.txtNuevoTelefono);
            this.Controls.Add(this.txtBuscarPorDni);
            this.Controls.Add(this.lblSeleccionar);
            this.Controls.Add(this.lblClienteEncontrado);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblBuscador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar datos del Cliente";
            this.Load += new System.EventHandler(this.FrmModificarCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBuscador;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblClienteEncontrado;
        private System.Windows.Forms.Label lblSeleccionar;
        private System.Windows.Forms.TextBox txtBuscarPorDni;
        private System.Windows.Forms.TextBox txtNuevoTelefono;
        private System.Windows.Forms.TextBox txtNuevaDireccion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtClienteEncontrado;
        private System.Windows.Forms.CheckBox cbxTelefono;
        private System.Windows.Forms.CheckBox cbxModificarDireccion;
        private System.Windows.Forms.Button btnCancelar;
    }
}