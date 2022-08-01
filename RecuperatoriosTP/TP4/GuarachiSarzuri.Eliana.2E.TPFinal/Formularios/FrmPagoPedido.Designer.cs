
namespace Formularios
{
    partial class FrmPagoPedido
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
            this.gbOpcionPago = new System.Windows.Forms.GroupBox();
            this.rbtTarjeta = new System.Windows.Forms.RadioButton();
            this.rbtEfectivo = new System.Windows.Forms.RadioButton();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblCambio = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.btnProcesarPago = new System.Windows.Forms.Button();
            this.txtCodigoSeguridad = new System.Windows.Forms.TextBox();
            this.txtVencimiento = new System.Windows.Forms.TextBox();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.txtDigitos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.lblTitular = new System.Windows.Forms.Label();
            this.lblDigitos = new System.Windows.Forms.Label();
            this.gbTarjetas = new System.Windows.Forms.GroupBox();
            this.gbEfectivo = new System.Windows.Forms.GroupBox();
            this.gbOpcionPago.SuspendLayout();
            this.gbTarjetas.SuspendLayout();
            this.gbEfectivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOpcionPago
            // 
            this.gbOpcionPago.Controls.Add(this.rbtTarjeta);
            this.gbOpcionPago.Controls.Add(this.rbtEfectivo);
            this.gbOpcionPago.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbOpcionPago.Location = new System.Drawing.Point(13, 73);
            this.gbOpcionPago.Name = "gbOpcionPago";
            this.gbOpcionPago.Size = new System.Drawing.Size(430, 75);
            this.gbOpcionPago.TabIndex = 0;
            this.gbOpcionPago.TabStop = false;
            this.gbOpcionPago.Text = "Opcion de pago";
            // 
            // rbtTarjeta
            // 
            this.rbtTarjeta.AutoSize = true;
            this.rbtTarjeta.Location = new System.Drawing.Point(191, 35);
            this.rbtTarjeta.Name = "rbtTarjeta";
            this.rbtTarjeta.Size = new System.Drawing.Size(180, 24);
            this.rbtTarjeta.TabIndex = 1;
            this.rbtTarjeta.TabStop = true;
            this.rbtTarjeta.Text = "Tarjeta Debito/ Credito";
            this.rbtTarjeta.UseVisualStyleBackColor = true;
            this.rbtTarjeta.CheckedChanged += new System.EventHandler(this.rbtTarjeta_CheckedChanged);
            // 
            // rbtEfectivo
            // 
            this.rbtEfectivo.AutoSize = true;
            this.rbtEfectivo.Location = new System.Drawing.Point(20, 35);
            this.rbtEfectivo.Name = "rbtEfectivo";
            this.rbtEfectivo.Size = new System.Drawing.Size(80, 24);
            this.rbtEfectivo.TabIndex = 0;
            this.rbtEfectivo.TabStop = true;
            this.rbtEfectivo.Text = "Efectivo";
            this.rbtEfectivo.UseVisualStyleBackColor = true;
            this.rbtEfectivo.CheckedChanged += new System.EventHandler(this.rbEfectivo_CheckedChanged);
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrecioTotal.Location = new System.Drawing.Point(13, 27);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(56, 20);
            this.lblPrecioTotal.TabIndex = 1;
            this.lblPrecioTotal.Text = "Precio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtPrecio.Location = new System.Drawing.Point(82, 23);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(130, 29);
            this.txtPrecio.TabIndex = 2;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMonto.Location = new System.Drawing.Point(6, 28);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(59, 20);
            this.lblMonto.TabIndex = 3;
            this.lblMonto.Text = "Monto:";
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCambio.Location = new System.Drawing.Point(220, 28);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(65, 20);
            this.lblCambio.TabIndex = 4;
            this.lblCambio.Text = "Cambio:";
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMonto.Location = new System.Drawing.Point(80, 24);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(125, 29);
            this.txtMonto.TabIndex = 6;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // txtCambio
            // 
            this.txtCambio.Enabled = false;
            this.txtCambio.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCambio.Location = new System.Drawing.Point(294, 24);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(125, 29);
            this.txtCambio.TabIndex = 7;
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnProcesarPago
            // 
            this.btnProcesarPago.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProcesarPago.Location = new System.Drawing.Point(149, 434);
            this.btnProcesarPago.Name = "btnProcesarPago";
            this.btnProcesarPago.Size = new System.Drawing.Size(133, 35);
            this.btnProcesarPago.TabIndex = 8;
            this.btnProcesarPago.Text = "Procesar pago";
            this.btnProcesarPago.UseVisualStyleBackColor = true;
            this.btnProcesarPago.Click += new System.EventHandler(this.btnProcesarPago_Click);
            // 
            // txtCodigoSeguridad
            // 
            this.txtCodigoSeguridad.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCodigoSeguridad.Location = new System.Drawing.Point(342, 129);
            this.txtCodigoSeguridad.Name = "txtCodigoSeguridad";
            this.txtCodigoSeguridad.Size = new System.Drawing.Size(67, 29);
            this.txtCodigoSeguridad.TabIndex = 18;
            this.txtCodigoSeguridad.Text = "***";
            this.txtCodigoSeguridad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoSeguridad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoSeguridad_KeyPress);
            // 
            // txtVencimiento
            // 
            this.txtVencimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtVencimiento.Location = new System.Drawing.Point(125, 129);
            this.txtVencimiento.Name = "txtVencimiento";
            this.txtVencimiento.Size = new System.Drawing.Size(77, 29);
            this.txtVencimiento.TabIndex = 17;
            this.txtVencimiento.Text = "MM/AA";
            this.txtVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTitular
            // 
            this.txtTitular.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTitular.Location = new System.Drawing.Point(172, 81);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(237, 29);
            this.txtTitular.TabIndex = 16;
            // 
            // txtDigitos
            // 
            this.txtDigitos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDigitos.Location = new System.Drawing.Point(172, 34);
            this.txtDigitos.Name = "txtDigitos";
            this.txtDigitos.Size = new System.Drawing.Size(237, 29);
            this.txtDigitos.TabIndex = 15;
            this.txtDigitos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigitos_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(268, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "Codigo:";
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVencimiento.Location = new System.Drawing.Point(14, 132);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(105, 21);
            this.lblVencimiento.TabIndex = 13;
            this.lblVencimiento.Text = "Vencimiento:";
            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitular.Location = new System.Drawing.Point(14, 84);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(150, 21);
            this.lblTitular.TabIndex = 12;
            this.lblTitular.Text = "Titular de la tarjeta:";
            // 
            // lblDigitos
            // 
            this.lblDigitos.AutoSize = true;
            this.lblDigitos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDigitos.Location = new System.Drawing.Point(14, 37);
            this.lblDigitos.Name = "lblDigitos";
            this.lblDigitos.Size = new System.Drawing.Size(143, 21);
            this.lblDigitos.TabIndex = 11;
            this.lblDigitos.Text = "Ingrese 16 digitos:";
            // 
            // gbTarjetas
            // 
            this.gbTarjetas.Controls.Add(this.lblDigitos);
            this.gbTarjetas.Controls.Add(this.lblVencimiento);
            this.gbTarjetas.Controls.Add(this.txtCodigoSeguridad);
            this.gbTarjetas.Controls.Add(this.lblTitular);
            this.gbTarjetas.Controls.Add(this.txtVencimiento);
            this.gbTarjetas.Controls.Add(this.label4);
            this.gbTarjetas.Controls.Add(this.txtTitular);
            this.gbTarjetas.Controls.Add(this.txtDigitos);
            this.gbTarjetas.Enabled = false;
            this.gbTarjetas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbTarjetas.Location = new System.Drawing.Point(13, 233);
            this.gbTarjetas.Name = "gbTarjetas";
            this.gbTarjetas.Size = new System.Drawing.Size(430, 183);
            this.gbTarjetas.TabIndex = 19;
            this.gbTarjetas.TabStop = false;
            this.gbTarjetas.Text = "Tarjetas";
            // 
            // gbEfectivo
            // 
            this.gbEfectivo.Controls.Add(this.lblMonto);
            this.gbEfectivo.Controls.Add(this.txtMonto);
            this.gbEfectivo.Controls.Add(this.lblCambio);
            this.gbEfectivo.Controls.Add(this.txtCambio);
            this.gbEfectivo.Enabled = false;
            this.gbEfectivo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbEfectivo.Location = new System.Drawing.Point(13, 161);
            this.gbEfectivo.Name = "gbEfectivo";
            this.gbEfectivo.Size = new System.Drawing.Size(430, 66);
            this.gbEfectivo.TabIndex = 20;
            this.gbEfectivo.TabStop = false;
            this.gbEfectivo.Text = "Efectivo";
            // 
            // FrmPagoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 493);
            this.Controls.Add(this.gbEfectivo);
            this.Controls.Add(this.gbTarjetas);
            this.Controls.Add(this.btnProcesarPago);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.gbOpcionPago);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPagoPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmPagoPedido_Load);
            this.gbOpcionPago.ResumeLayout(false);
            this.gbOpcionPago.PerformLayout();
            this.gbTarjetas.ResumeLayout(false);
            this.gbTarjetas.PerformLayout();
            this.gbEfectivo.ResumeLayout(false);
            this.gbEfectivo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOpcionPago;
        private System.Windows.Forms.RadioButton rbtTarjeta;
        private System.Windows.Forms.RadioButton rbtEfectivo;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Button btnProcesarPago;
        private System.Windows.Forms.TextBox txtCodigoSeguridad;
        private System.Windows.Forms.TextBox txtVencimiento;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.TextBox txtDigitos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.Label lblDigitos;
        private System.Windows.Forms.GroupBox gbTarjetas;
        private System.Windows.Forms.GroupBox gbEfectivo;
    }
}