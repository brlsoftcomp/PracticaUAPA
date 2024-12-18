namespace BRL_SVentas
{
    partial class FormReporteCobros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReporteCobros));
            this.btnCancelar = new System.Windows.Forms.PictureBox();
            this.btnBuscarClientes = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAgrupar = new System.Windows.Forms.ComboBox();
            this.txtFiltroFecha = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrdenarPor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesde = new System.Windows.Forms.DateTimePicker();
            this.txtHasta = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarClientes)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = global::BRL_SVentas.Properties.Resources.delete;
            this.btnCancelar.Location = new System.Drawing.Point(243, 280);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(27, 27);
            this.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancelar.TabIndex = 72;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscarClientes
            // 
            this.btnBuscarClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarClientes.Image = global::BRL_SVentas.Properties.Resources.find;
            this.btnBuscarClientes.Location = new System.Drawing.Point(213, 280);
            this.btnBuscarClientes.Name = "btnBuscarClientes";
            this.btnBuscarClientes.Size = new System.Drawing.Size(27, 27);
            this.btnBuscarClientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBuscarClientes.TabIndex = 71;
            this.btnBuscarClientes.TabStop = false;
            this.btnBuscarClientes.Click += new System.EventHandler(this.btnBuscarClientes_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 70;
            this.label7.Text = "Buscar por Cliente:";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(12, 281);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(198, 26);
            this.txtNombre.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 68;
            this.label6.Text = "Agrupar por:";
            // 
            // txtAgrupar
            // 
            this.txtAgrupar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtAgrupar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgrupar.FormattingEnabled = true;
            this.txtAgrupar.Items.AddRange(new object[] {
            "NO AGRUPADO",
            "NO. FACTURA",
            "NOMBRE CLIENTE"});
            this.txtAgrupar.Location = new System.Drawing.Point(12, 228);
            this.txtAgrupar.Name = "txtAgrupar";
            this.txtAgrupar.Size = new System.Drawing.Size(245, 28);
            this.txtAgrupar.TabIndex = 67;
            this.txtAgrupar.SelectedIndexChanged += new System.EventHandler(this.txtAgrupar_SelectedIndexChanged);
            // 
            // txtFiltroFecha
            // 
            this.txtFiltroFecha.AutoSize = true;
            this.txtFiltroFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroFecha.Location = new System.Drawing.Point(13, 70);
            this.txtFiltroFecha.Name = "txtFiltroFecha";
            this.txtFiltroFecha.Size = new System.Drawing.Size(147, 24);
            this.txtFiltroFecha.TabIndex = 66;
            this.txtFiltroFecha.Text = "Filtrar por fechas";
            this.txtFiltroFecha.UseVisualStyleBackColor = true;
            this.txtFiltroFecha.CheckedChanged += new System.EventHandler(this.txtFiltroFecha_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 65;
            this.label5.Text = "Ordenado por:";
            // 
            // txtOrdenarPor
            // 
            this.txtOrdenarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtOrdenarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdenarPor.FormattingEnabled = true;
            this.txtOrdenarPor.Items.AddRange(new object[] {
            "FECHA",
            "NO. FACTURA",
            "NOMBRE CLIENTE"});
            this.txtOrdenarPor.Location = new System.Drawing.Point(12, 176);
            this.txtOrdenarPor.Name = "txtOrdenarPor";
            this.txtOrdenarPor.Size = new System.Drawing.Size(245, 28);
            this.txtOrdenarPor.TabIndex = 64;
            this.txtOrdenarPor.SelectedIndexChanged += new System.EventHandler(this.txtOrdenarPor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(151, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 61;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "Desde:";
            // 
            // txtDesde
            // 
            this.txtDesde.Enabled = false;
            this.txtDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDesde.Location = new System.Drawing.Point(13, 119);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(104, 26);
            this.txtDesde.TabIndex = 58;
            // 
            // txtHasta
            // 
            this.txtHasta.Enabled = false;
            this.txtHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtHasta.Location = new System.Drawing.Point(155, 119);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(104, 26);
            this.txtHasta.TabIndex = 59;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::BRL_SVentas.Properties.Resources.gris_1;
            this.panel2.Controls.Add(this.btnConsultar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 327);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 51);
            this.panel2.TabIndex = 57;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.Color.Black;
            this.btnConsultar.Image = global::BRL_SVentas.Properties.Resources.print_preview;
            this.btnConsultar.Location = new System.Drawing.Point(85, 6);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(125, 38);
            this.btnConsultar.TabIndex = 1;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BRL_SVentas.Properties.Resources.gris_1;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 62);
            this.panel1.TabIndex = 56;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(76, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "Reportes de Cobros";
            // 
            // FormReporteCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 378);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscarClientes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAgrupar);
            this.Controls.Add(this.txtFiltroFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOrdenarPor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDesde);
            this.Controls.Add(this.txtHasta);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(293, 417);
            this.MinimumSize = new System.Drawing.Size(293, 417);
            this.Name = "FormReporteCobros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Cobros";
            this.Load += new System.EventHandler(this.FormReporteCobros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarClientes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnCancelar;
        private System.Windows.Forms.PictureBox btnBuscarClientes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtAgrupar;
        private System.Windows.Forms.CheckBox txtFiltroFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtOrdenarPor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDesde;
        private System.Windows.Forms.DateTimePicker txtHasta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
    }
}