
namespace Formularios
{
    partial class FrmMenuVendedores
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuVendedores));
            this.btnCargar = new System.Windows.Forms.Button();
            this.imgVendedores = new System.Windows.Forms.ImageList(this.components);
            this.dgvVendedores = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_ALTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_BAJA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminarVendedor = new System.Windows.Forms.Button();
            this.btnBajaVendedor = new System.Windows.Forms.Button();
            this.btnNuevoVendedor = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APELLIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUELDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCargar.ImageIndex = 1;
            this.btnCargar.ImageList = this.imgVendedores;
            this.btnCargar.Location = new System.Drawing.Point(732, 12);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(92, 66);
            this.btnCargar.TabIndex = 25;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // imgVendedores
            // 
            this.imgVendedores.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgVendedores.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgVendedores.ImageStream")));
            this.imgVendedores.TransparentColor = System.Drawing.Color.Transparent;
            this.imgVendedores.Images.SetKeyName(0, "AgregarCliente.png");
            this.imgVendedores.Images.SetKeyName(1, "cargar.png");
            this.imgVendedores.Images.SetKeyName(2, "EditarCliente.png");
            this.imgVendedores.Images.SetKeyName(3, "EliminarCliente.png");
            this.imgVendedores.Images.SetKeyName(4, "imprimir.png");
            // 
            // dgvVendedores
            // 
            this.dgvVendedores.AllowUserToAddRows = false;
            this.dgvVendedores.AllowUserToDeleteRows = false;
            this.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.FECHA_ALTA,
            this.FECHA_BAJA});
            this.dgvVendedores.Location = new System.Drawing.Point(12, 12);
            this.dgvVendedores.MultiSelect = false;
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.ReadOnly = true;
            this.dgvVendedores.RowTemplate.Height = 25;
            this.dgvVendedores.Size = new System.Drawing.Size(702, 384);
            this.dgvVendedores.TabIndex = 32;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "DNI";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "APELLIDO";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "SUELDO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // FECHA_ALTA
            // 
            this.FECHA_ALTA.HeaderText = "FECHA_ALTA";
            this.FECHA_ALTA.Name = "FECHA_ALTA";
            this.FECHA_ALTA.ReadOnly = true;
            // 
            // FECHA_BAJA
            // 
            this.FECHA_BAJA.HeaderText = "FECHA_BAJA";
            this.FECHA_BAJA.Name = "FECHA_BAJA";
            this.FECHA_BAJA.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Location = new System.Drawing.Point(732, 372);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 29);
            this.btnSalir.TabIndex = 24;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminarVendedor
            // 
            this.btnEliminarVendedor.Enabled = false;
            this.btnEliminarVendedor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminarVendedor.ImageIndex = 3;
            this.btnEliminarVendedor.ImageList = this.imgVendedores;
            this.btnEliminarVendedor.Location = new System.Drawing.Point(732, 228);
            this.btnEliminarVendedor.Name = "btnEliminarVendedor";
            this.btnEliminarVendedor.Size = new System.Drawing.Size(92, 66);
            this.btnEliminarVendedor.TabIndex = 28;
            this.btnEliminarVendedor.Text = "Eliminar";
            this.btnEliminarVendedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminarVendedor.UseVisualStyleBackColor = true;
            this.btnEliminarVendedor.Click += new System.EventHandler(this.btnEliminarVendedor_Click);
            // 
            // btnBajaVendedor
            // 
            this.btnBajaVendedor.Enabled = false;
            this.btnBajaVendedor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBajaVendedor.ImageIndex = 2;
            this.btnBajaVendedor.ImageList = this.imgVendedores;
            this.btnBajaVendedor.Location = new System.Drawing.Point(732, 156);
            this.btnBajaVendedor.Name = "btnBajaVendedor";
            this.btnBajaVendedor.Size = new System.Drawing.Size(92, 66);
            this.btnBajaVendedor.TabIndex = 27;
            this.btnBajaVendedor.Text = "Dar de baja";
            this.btnBajaVendedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBajaVendedor.UseVisualStyleBackColor = true;
            this.btnBajaVendedor.Click += new System.EventHandler(this.btnBajaVendedor_Click);
            // 
            // btnNuevoVendedor
            // 
            this.btnNuevoVendedor.Enabled = false;
            this.btnNuevoVendedor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNuevoVendedor.ImageIndex = 0;
            this.btnNuevoVendedor.ImageList = this.imgVendedores;
            this.btnNuevoVendedor.Location = new System.Drawing.Point(732, 84);
            this.btnNuevoVendedor.Name = "btnNuevoVendedor";
            this.btnNuevoVendedor.Size = new System.Drawing.Size(92, 66);
            this.btnNuevoVendedor.TabIndex = 26;
            this.btnNuevoVendedor.Text = "Agregar";
            this.btnNuevoVendedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoVendedor.UseVisualStyleBackColor = true;
            this.btnNuevoVendedor.Click += new System.EventHandler(this.btnNuevoVendedor_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnImprimir.ImageIndex = 4;
            this.btnImprimir.ImageList = this.imgVendedores;
            this.btnImprimir.Location = new System.Drawing.Point(732, 300);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 66);
            this.btnImprimir.TabIndex = 46;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.Width = 80;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.Width = 120;
            // 
            // APELLIDO
            // 
            this.APELLIDO.HeaderText = "APELLIDO";
            this.APELLIDO.Name = "APELLIDO";
            this.APELLIDO.Width = 120;
            // 
            // SUELDO
            // 
            this.SUELDO.HeaderText = "SUELDO";
            this.SUELDO.Name = "SUELDO";
            // 
            // FrmMenuVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 408);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.dgvVendedores);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminarVendedor);
            this.Controls.Add(this.btnBajaVendedor);
            this.Controls.Add(this.btnNuevoVendedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenuVendedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VENDEDORES";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.DataGridView dgvVendedores;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminarVendedor;
        private System.Windows.Forms.Button btnBajaVendedor;
        private System.Windows.Forms.Button btnNuevoVendedor;
        private System.Windows.Forms.ImageList imgVendedores;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn APELLIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUELDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_ALTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_BAJA;
    }
}