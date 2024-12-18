namespace BRL_SVentas
{
    partial class FormPagoCompra
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMontoCheque = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoCheque = new System.Windows.Forms.TextBox();
            this.txtMontoTarjeta = new System.Windows.Forms.TextBox();
            this.txtNoBoucher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEfectivoCaja = new System.Windows.Forms.TextBox();
            this.lb_pago = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.txtEfectivoOtros = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BRL_SVentas.Properties.Resources.gris_1;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 77);
            this.panel1.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::BRL_SVentas.Properties.Resources.Dinero;
            this.pictureBox1.Location = new System.Drawing.Point(17, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Gestion de Pago";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(12, 298);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(136, 29);
            this.txtTotal.TabIndex = 44;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 272);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 24);
            this.label8.TabIndex = 45;
            this.label8.Text = "TOTAL:";
            // 
            // txtMontoCheque
            // 
            this.txtMontoCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoCheque.Location = new System.Drawing.Point(13, 106);
            this.txtMontoCheque.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMontoCheque.Name = "txtMontoCheque";
            this.txtMontoCheque.Size = new System.Drawing.Size(136, 29);
            this.txtMontoCheque.TabIndex = 40;
            this.txtMontoCheque.Text = "0.00";
            this.txtMontoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMontoCheque_KeyPress);
            this.txtMontoCheque.Validated += new System.EventHandler(this.TxtMontoCheque_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(166, 85);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 43;
            this.label6.Text = "No. Cheque:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 41;
            this.label5.Text = "Monto Cheque:";
            // 
            // txtNoCheque
            // 
            this.txtNoCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoCheque.Location = new System.Drawing.Point(169, 106);
            this.txtNoCheque.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNoCheque.Name = "txtNoCheque";
            this.txtNoCheque.Size = new System.Drawing.Size(136, 29);
            this.txtNoCheque.TabIndex = 42;
            this.txtNoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoCheque_KeyPress);
            // 
            // txtMontoTarjeta
            // 
            this.txtMontoTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoTarjeta.Location = new System.Drawing.Point(13, 168);
            this.txtMontoTarjeta.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMontoTarjeta.Name = "txtMontoTarjeta";
            this.txtMontoTarjeta.Size = new System.Drawing.Size(136, 29);
            this.txtMontoTarjeta.TabIndex = 38;
            this.txtMontoTarjeta.Text = "0.00";
            this.txtMontoTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMontoTarjeta_KeyPress);
            this.txtMontoTarjeta.Validated += new System.EventHandler(this.TxtMontoTarjeta_Validated);
            // 
            // txtNoBoucher
            // 
            this.txtNoBoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoBoucher.Location = new System.Drawing.Point(169, 168);
            this.txtNoBoucher.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNoBoucher.Name = "txtNoBoucher";
            this.txtNoBoucher.Size = new System.Drawing.Size(136, 29);
            this.txtNoBoucher.TabIndex = 36;
            this.txtNoBoucher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoBoucher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoBoucher_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(169, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "No. Voucher:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 147);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "Monto Tarjeta:";
            // 
            // txtEfectivoCaja
            // 
            this.txtEfectivoCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivoCaja.Location = new System.Drawing.Point(13, 233);
            this.txtEfectivoCaja.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEfectivoCaja.Name = "txtEfectivoCaja";
            this.txtEfectivoCaja.Size = new System.Drawing.Size(136, 29);
            this.txtEfectivoCaja.TabIndex = 34;
            this.txtEfectivoCaja.Text = "0.00";
            this.txtEfectivoCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivoCaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMontoEfectivo_KeyPress);
            this.txtEfectivoCaja.Validated += new System.EventHandler(this.TxtPagoCon_Validated);
            // 
            // lb_pago
            // 
            this.lb_pago.AutoSize = true;
            this.lb_pago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pago.Location = new System.Drawing.Point(10, 214);
            this.lb_pago.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_pago.Name = "lb_pago";
            this.lb_pago.Size = new System.Drawing.Size(108, 17);
            this.lb_pago.TabIndex = 35;
            this.lb_pago.Text = "Efectivo Caja:";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::BRL_SVentas.Properties.Resources.gris_1;
            this.panel2.Controls.Add(this.btnCobrar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 345);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 47);
            this.panel2.TabIndex = 48;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.Image = global::BRL_SVentas.Properties.Resources.apply;
            this.btnCobrar.Location = new System.Drawing.Point(102, 2);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(110, 43);
            this.btnCobrar.TabIndex = 0;
            this.btnCobrar.Text = "Aplicar";
            this.btnCobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.BtnCobrar_Click);
            // 
            // txtEfectivoOtros
            // 
            this.txtEfectivoOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivoOtros.Location = new System.Drawing.Point(169, 233);
            this.txtEfectivoOtros.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEfectivoOtros.Name = "txtEfectivoOtros";
            this.txtEfectivoOtros.Size = new System.Drawing.Size(136, 29);
            this.txtEfectivoOtros.TabIndex = 0;
            this.txtEfectivoOtros.Text = "0.00";
            this.txtEfectivoOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivoOtros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivoOtros_KeyPress);
            this.txtEfectivoOtros.Validated += new System.EventHandler(this.txtEfectivoOtros_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(166, 214);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 50;
            this.label4.Text = "Efectivo Otros:";
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(169, 298);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(136, 29);
            this.txtMonto.TabIndex = 51;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(168, 272);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 24);
            this.label7.TabIndex = 52;
            this.label7.Text = "MONTO:";
            // 
            // FormPagoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 392);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEfectivoOtros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMontoCheque);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNoCheque);
            this.Controls.Add(this.txtMontoTarjeta);
            this.Controls.Add(this.txtNoBoucher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEfectivoCaja);
            this.Controls.Add(this.lb_pago);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FormPagoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago Compra";
            this.Load += new System.EventHandler(this.FormPagoCompra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtMontoCheque;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtNoCheque;
        public System.Windows.Forms.TextBox txtMontoTarjeta;
        public System.Windows.Forms.TextBox txtNoBoucher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtEfectivoCaja;
        private System.Windows.Forms.Label lb_pago;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnCobrar;
        public System.Windows.Forms.TextBox txtEfectivoOtros;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label7;
    }
}