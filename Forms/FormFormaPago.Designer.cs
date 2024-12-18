namespace BRL_SVentas.Forms
{
    partial class FormFormaPago
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
            this.lb_pago = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMontoEfectivo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.txtImprimir = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_pago
            // 
            this.lb_pago.AutoSize = true;
            this.lb_pago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pago.Location = new System.Drawing.Point(7, 140);
            this.lb_pago.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_pago.Name = "lb_pago";
            this.lb_pago.Size = new System.Drawing.Size(120, 17);
            this.lb_pago.TabIndex = 13;
            this.lb_pago.Text = "Monto Efectivo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cobrar Factura";
            // 
            // txtMontoEfectivo
            // 
            this.txtMontoEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoEfectivo.Location = new System.Drawing.Point(10, 159);
            this.txtMontoEfectivo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMontoEfectivo.Name = "txtMontoEfectivo";
            this.txtMontoEfectivo.Size = new System.Drawing.Size(136, 29);
            this.txtMontoEfectivo.TabIndex = 0;
            this.txtMontoEfectivo.Text = "0.00";
            this.txtMontoEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMontoEfectivo_KeyPress);
            this.txtMontoEfectivo.Validated += new System.EventHandler(this.TxtPagoCon_Validated);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::BRL_SVentas.Properties.Resources.ImagenCajapng;
            this.pictureBox1.Location = new System.Drawing.Point(17, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.Image = global::BRL_SVentas.Properties.Resources.dollar1;
            this.btnCobrar.Location = new System.Drawing.Point(101, 2);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(110, 43);
            this.btnCobrar.TabIndex = 0;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.BtnCobrar_Click);
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
            this.panel1.TabIndex = 18;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::BRL_SVentas.Properties.Resources.gris_1;
            this.panel2.Controls.Add(this.btnCobrar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 387);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 47);
            this.panel2.TabIndex = 19;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(318, 310);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtImprimir);
            this.tabPage1.Controls.Add(this.txtTotal);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtMontoCheque);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtNoCheque);
            this.tabPage1.Controls.Add(this.txtMontoTarjeta);
            this.tabPage1.Controls.Add(this.txtNoBoucher);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtMontoEfectivo);
            this.tabPage1.Controls.Add(this.lb_pago);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(310, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MONTOS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(163, 159);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(136, 29);
            this.txtTotal.TabIndex = 30;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(162, 133);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 24);
            this.label8.TabIndex = 31;
            this.label8.Text = "TOTAL:";
            // 
            // txtMontoCheque
            // 
            this.txtMontoCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoCheque.Location = new System.Drawing.Point(10, 30);
            this.txtMontoCheque.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMontoCheque.Name = "txtMontoCheque";
            this.txtMontoCheque.Size = new System.Drawing.Size(136, 29);
            this.txtMontoCheque.TabIndex = 1;
            this.txtMontoCheque.Text = "0.00";
            this.txtMontoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMontoCheque_KeyPress);
            this.txtMontoCheque.Validated += new System.EventHandler(this.TxtMontoCheque_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(163, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "No. Cheque:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Monto Cheque:";
            // 
            // txtNoCheque
            // 
            this.txtNoCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoCheque.Location = new System.Drawing.Point(166, 30);
            this.txtNoCheque.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNoCheque.Name = "txtNoCheque";
            this.txtNoCheque.Size = new System.Drawing.Size(136, 29);
            this.txtNoCheque.TabIndex = 2;
            this.txtNoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoCheque_KeyPress);
            // 
            // txtMontoTarjeta
            // 
            this.txtMontoTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoTarjeta.Location = new System.Drawing.Point(10, 92);
            this.txtMontoTarjeta.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMontoTarjeta.Name = "txtMontoTarjeta";
            this.txtMontoTarjeta.Size = new System.Drawing.Size(136, 29);
            this.txtMontoTarjeta.TabIndex = 3;
            this.txtMontoTarjeta.Text = "0.00";
            this.txtMontoTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMontoTarjeta_KeyPress);
            this.txtMontoTarjeta.Validated += new System.EventHandler(this.TxtMontoTarjeta_Validated);
            // 
            // txtNoBoucher
            // 
            this.txtNoBoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoBoucher.Location = new System.Drawing.Point(166, 92);
            this.txtNoBoucher.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNoBoucher.Name = "txtNoBoucher";
            this.txtNoBoucher.Size = new System.Drawing.Size(136, 29);
            this.txtNoBoucher.TabIndex = 4;
            this.txtNoBoucher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoBoucher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoBoucher_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(166, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "No. Voucher:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Monto Tarjeta:";
            // 
            // txtImprimir
            // 
            this.txtImprimir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImprimir.FormattingEnabled = true;
            this.txtImprimir.Items.AddRange(new object[] {
            "IMPRIMIR",
            "NO IMPRIMIR"});
            this.txtImprimir.Location = new System.Drawing.Point(10, 234);
            this.txtImprimir.Name = "txtImprimir";
            this.txtImprimir.Size = new System.Drawing.Size(175, 32);
            this.txtImprimir.TabIndex = 32;
            this.txtImprimir.SelectedIndexChanged += new System.EventHandler(this.txtImprimir_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 208);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 24);
            this.label9.TabIndex = 33;
            this.label9.Text = "Imprimir en:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // FormFormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 434);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(334, 473);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(334, 473);
            this.Name = "FormFormaPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobrar Factura";
            this.Load += new System.EventHandler(this.FormCobrarFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Label lb_pago;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtMontoEfectivo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TextBox txtMontoCheque;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtNoCheque;
        public System.Windows.Forms.TextBox txtMontoTarjeta;
        public System.Windows.Forms.TextBox txtNoBoucher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox txtImprimir;
    }
}