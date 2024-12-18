namespace BRL_SVentas.Forms
{
    partial class FormReporteVentas
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtCondicionPago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesde = new System.Windows.Forms.DateTimePicker();
            this.txtHasta = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTipoComprob = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTipoBusqueda = new System.Windows.Forms.ComboBox();
            this.btnQuitarPorveedor = new System.Windows.Forms.PictureBox();
            this.btnProveedor = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.btnQuitarClieente = new System.Windows.Forms.PictureBox();
            this.btnBuscarCliente = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitarPorveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitarClieente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Condicion de Pago:";
            // 
            // txtCondicionPago
            // 
            this.txtCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCondicionPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondicionPago.FormattingEnabled = true;
            this.txtCondicionPago.Items.AddRange(new object[] {
            "AL CONTADO",
            "A CREDITO",
            "TODAS"});
            this.txtCondicionPago.Location = new System.Drawing.Point(14, 217);
            this.txtCondicionPago.Name = "txtCondicionPago";
            this.txtCondicionPago.Size = new System.Drawing.Size(229, 28);
            this.txtCondicionPago.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(134, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Desde:";
            // 
            // txtDesde
            // 
            this.txtDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDesde.Location = new System.Drawing.Point(14, 94);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(104, 26);
            this.txtDesde.TabIndex = 14;
            // 
            // txtHasta
            // 
            this.txtHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtHasta.Location = new System.Drawing.Point(139, 94);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(104, 26);
            this.txtHasta.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::BRL_SVentas.Properties.Resources.gris_1;
            this.panel2.Controls.Add(this.btnConsultar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 448);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(275, 51);
            this.panel2.TabIndex = 2;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.Color.Black;
            this.btnConsultar.Image = global::BRL_SVentas.Properties.Resources.print_preview;
            this.btnConsultar.Location = new System.Drawing.Point(78, 6);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(125, 38);
            this.btnConsultar.TabIndex = 1;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BRL_SVentas.Properties.Resources.gris_1;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 62);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::BRL_SVentas.Properties.Resources.ReportVenta;
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
            this.label4.Size = new System.Drawing.Size(194, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "Reportes de Ventas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(14, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tipo NCF:";
            // 
            // txtTipoComprob
            // 
            this.txtTipoComprob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTipoComprob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoComprob.FormattingEnabled = true;
            this.txtTipoComprob.Items.AddRange(new object[] {
            "TODOS",
            "(B01)-Valor Fiscal",
            "(B02)-Consumidor Final",
            "(B03)-Nota de Debito",
            "(B04)-Nota de Credito",
            "(B11)-Proveedor Informal",
            "(B13)-Gastos Menores",
            "(B14)-Especial",
            "(B15)-Gubernamental"});
            this.txtTipoComprob.Location = new System.Drawing.Point(14, 274);
            this.txtTipoComprob.Name = "txtTipoComprob";
            this.txtTipoComprob.Size = new System.Drawing.Size(229, 28);
            this.txtTipoComprob.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(14, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Tipo de Busqueda:";
            // 
            // txtTipoBusqueda
            // 
            this.txtTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTipoBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoBusqueda.FormattingEnabled = true;
            this.txtTipoBusqueda.Items.AddRange(new object[] {
            "VENTAS",
            "DEVOLUCIONES"});
            this.txtTipoBusqueda.Location = new System.Drawing.Point(14, 159);
            this.txtTipoBusqueda.Name = "txtTipoBusqueda";
            this.txtTipoBusqueda.Size = new System.Drawing.Size(229, 28);
            this.txtTipoBusqueda.TabIndex = 22;
            this.txtTipoBusqueda.SelectedIndexChanged += new System.EventHandler(this.txtTipoBusqueda_SelectedIndexChanged);
            // 
            // btnQuitarPorveedor
            // 
            this.btnQuitarPorveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarPorveedor.Image = global::BRL_SVentas.Properties.Resources.delete;
            this.btnQuitarPorveedor.Location = new System.Drawing.Point(245, 337);
            this.btnQuitarPorveedor.Name = "btnQuitarPorveedor";
            this.btnQuitarPorveedor.Size = new System.Drawing.Size(27, 27);
            this.btnQuitarPorveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnQuitarPorveedor.TabIndex = 63;
            this.btnQuitarPorveedor.TabStop = false;
            this.btnQuitarPorveedor.Click += new System.EventHandler(this.btnQuitarPorveedor_Click);
            // 
            // btnProveedor
            // 
            this.btnProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedor.Image = global::BRL_SVentas.Properties.Resources.find;
            this.btnProveedor.Location = new System.Drawing.Point(215, 337);
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(27, 27);
            this.btnProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnProveedor.TabIndex = 62;
            this.btnProveedor.TabStop = false;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(14, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 61;
            this.label8.Text = "Proveedor:";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.Location = new System.Drawing.Point(14, 338);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(198, 26);
            this.txtProveedor.TabIndex = 60;
            this.txtProveedor.Text = "TODOS";
            // 
            // btnQuitarClieente
            // 
            this.btnQuitarClieente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarClieente.Image = global::BRL_SVentas.Properties.Resources.delete;
            this.btnQuitarClieente.Location = new System.Drawing.Point(243, 404);
            this.btnQuitarClieente.Name = "btnQuitarClieente";
            this.btnQuitarClieente.Size = new System.Drawing.Size(27, 27);
            this.btnQuitarClieente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnQuitarClieente.TabIndex = 67;
            this.btnQuitarClieente.TabStop = false;
            this.btnQuitarClieente.Click += new System.EventHandler(this.btnQuitarClieente_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.Image = global::BRL_SVentas.Properties.Resources.find;
            this.btnBuscarCliente.Location = new System.Drawing.Point(213, 404);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(27, 27);
            this.btnBuscarCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBuscarCliente.TabIndex = 66;
            this.btnBuscarCliente.TabStop = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 65;
            this.label7.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(12, 405);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(198, 26);
            this.txtCliente.TabIndex = 64;
            this.txtCliente.Text = "TODOS";
            // 
            // FormReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 499);
            this.Controls.Add(this.btnQuitarClieente);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.btnQuitarPorveedor);
            this.Controls.Add(this.btnProveedor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTipoBusqueda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTipoComprob);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCondicionPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDesde);
            this.Controls.Add(this.txtHasta);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(291, 538);
            this.MinimumSize = new System.Drawing.Size(291, 538);
            this.Name = "FormReporteVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Ventas";
            this.Load += new System.EventHandler(this.FormReporteVentas_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitarPorveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitarClieente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtCondicionPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDesde;
        private System.Windows.Forms.DateTimePicker txtHasta;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtTipoComprob;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtTipoBusqueda;
        private System.Windows.Forms.PictureBox btnQuitarPorveedor;
        private System.Windows.Forms.PictureBox btnProveedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.PictureBox btnQuitarClieente;
        private System.Windows.Forms.PictureBox btnBuscarCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCliente;
    }
}