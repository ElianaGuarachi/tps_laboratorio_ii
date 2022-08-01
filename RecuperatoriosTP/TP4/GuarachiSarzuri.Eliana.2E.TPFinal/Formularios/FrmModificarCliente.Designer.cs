
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
            this.lblSeleccionar = new System.Windows.Forms.Label();
            this.txtNuevoTelefono = new System.Windows.Forms.TextBox();
            this.txtNuevaDireccion = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.cbxTelefono = new System.Windows.Forms.CheckBox();
            this.cbxModificarDireccion = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSeleccionar
            // 
            this.lblSeleccionar.AutoSize = true;
            this.lblSeleccionar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblSeleccionar.Location = new System.Drawing.Point(182, 155);
            this.lblSeleccionar.Name = "lblSeleccionar";
            this.lblSeleccionar.Size = new System.Drawing.Size(339, 20);
            this.lblSeleccionar.TabIndex = 3;
            this.lblSeleccionar.Text = "*Solo se puede modificar el telefono y/o la direccion";
            // 
            // txtNuevoTelefono
            // 
            this.txtNuevoTelefono.Enabled = false;
            this.txtNuevoTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtNuevoTelefono.Location = new System.Drawing.Point(314, 62);
            this.txtNuevoTelefono.Name = "txtNuevoTelefono";
            this.txtNuevoTelefono.Size = new System.Drawing.Size(256, 27);
            this.txtNuevoTelefono.TabIndex = 1;
            // 
            // txtNuevaDireccion
            // 
            this.txtNuevaDireccion.Enabled = false;
            this.txtNuevaDireccion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtNuevaDireccion.Location = new System.Drawing.Point(314, 110);
            this.txtNuevaDireccion.Name = "txtNuevaDireccion";
            this.txtNuevaDireccion.Size = new System.Drawing.Size(256, 27);
            this.txtNuevaDireccion.TabIndex = 3;
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.Location = new System.Drawing.Point(307, 192);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(112, 51);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // cbxTelefono
            // 
            this.cbxTelefono.AutoSize = true;
            this.cbxTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxTelefono.Location = new System.Drawing.Point(133, 64);
            this.cbxTelefono.Name = "cbxTelefono";
            this.cbxTelefono.Size = new System.Drawing.Size(161, 24);
            this.cbxTelefono.TabIndex = 0;
            this.cbxTelefono.Text = "Modificar Telefono:";
            this.cbxTelefono.UseVisualStyleBackColor = true;
            this.cbxTelefono.CheckedChanged += new System.EventHandler(this.cbxTelefono_CheckedChanged);
            // 
            // cbxModificarDireccion
            // 
            this.cbxModificarDireccion.AutoSize = true;
            this.cbxModificarDireccion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbxModificarDireccion.Location = new System.Drawing.Point(133, 110);
            this.cbxModificarDireccion.Name = "cbxModificarDireccion";
            this.cbxModificarDireccion.Size = new System.Drawing.Size(167, 24);
            this.cbxModificarDireccion.TabIndex = 2;
            this.cbxModificarDireccion.Text = "Modificar Direccion:";
            this.cbxModificarDireccion.UseVisualStyleBackColor = true;
            this.cbxModificarDireccion.CheckedChanged += new System.EventHandler(this.cbxModificarDireccion_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(182, 192);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 51);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Location = new System.Drawing.Point(435, 192);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(112, 51);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(81, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 21;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCliente.Location = new System.Drawing.Point(25, 19);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(56, 20);
            this.lblCliente.TabIndex = 22;
            this.lblCliente.Text = "Cliente";
            // 
            // FrmModificarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 256);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cbxModificarDireccion);
            this.Controls.Add(this.cbxTelefono);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtNuevaDireccion);
            this.Controls.Add(this.txtNuevoTelefono);
            this.Controls.Add(this.lblSeleccionar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSeleccionar;
        private System.Windows.Forms.TextBox txtNuevoTelefono;
        private System.Windows.Forms.TextBox txtNuevaDireccion;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.CheckBox cbxTelefono;
        private System.Windows.Forms.CheckBox cbxModificarDireccion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCliente;
    }
}