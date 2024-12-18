namespace BRL_SVentas
{
    partial class FormConfVentas
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtImprimir = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContizLogo = new System.Windows.Forms.ComboBox();
            this.txtNotificacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNCF = new System.Windows.Forms.ComboBox();
            this.btnVentasNcf = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCopiaFactura = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.txtCopiaFactura);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtImprimir);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtContizLogo);
            this.panel1.Controls.Add(this.txtNotificacion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNCF);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 253);
            this.panel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 155);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 24);
            this.label9.TabIndex = 35;
            this.label9.Text = "Imprimir en:";
            // 
            // txtImprimir
            // 
            this.txtImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImprimir.FormattingEnabled = true;
            this.txtImprimir.Items.AddRange(new object[] {
            "PAPEL ROLLO",
            "MEDIA PAGINA",
            "DIGITAL",
            "NO IMPRIMIR"});
            this.txtImprimir.Location = new System.Drawing.Point(193, 152);
            this.txtImprimir.Name = "txtImprimir";
            this.txtImprimir.Size = new System.Drawing.Size(175, 32);
            this.txtImprimir.TabIndex = 34;
            this.txtImprimir.SelectedIndexChanged += new System.EventHandler(this.txtImprimir_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cotizacion con Logo:";
            // 
            // txtContizLogo
            // 
            this.txtContizLogo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtContizLogo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtContizLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContizLogo.FormattingEnabled = true;
            this.txtContizLogo.Items.AddRange(new object[] {
            "APLICADO",
            "NO APLICADO"});
            this.txtContizLogo.Location = new System.Drawing.Point(193, 117);
            this.txtContizLogo.Name = "txtContizLogo";
            this.txtContizLogo.Size = new System.Drawing.Size(142, 28);
            this.txtContizLogo.TabIndex = 4;
            // 
            // txtNotificacion
            // 
            this.txtNotificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotificacion.Location = new System.Drawing.Point(193, 68);
            this.txtNotificacion.Name = "txtNotificacion";
            this.txtNotificacion.Size = new System.Drawing.Size(100, 26);
            this.txtNotificacion.TabIndex = 3;
            this.txtNotificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNotificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNotificacion_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tope Notificacion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "NCF:";
            // 
            // txtNCF
            // 
            this.txtNCF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtNCF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtNCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNCF.FormattingEnabled = true;
            this.txtNCF.Items.AddRange(new object[] {
            "APLICADO",
            "NO APLICADO"});
            this.txtNCF.Location = new System.Drawing.Point(193, 27);
            this.txtNCF.Name = "txtNCF";
            this.txtNCF.Size = new System.Drawing.Size(142, 28);
            this.txtNCF.TabIndex = 0;
            // 
            // btnVentasNcf
            // 
            this.btnVentasNcf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentasNcf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasNcf.Image = global::BRL_SVentas.Properties.Resources.save;
            this.btnVentasNcf.Location = new System.Drawing.Point(277, 268);
            this.btnVentasNcf.Name = "btnVentasNcf";
            this.btnVentasNcf.Size = new System.Drawing.Size(114, 51);
            this.btnVentasNcf.TabIndex = 85;
            this.btnVentasNcf.Text = "Guardar";
            this.btnVentasNcf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVentasNcf.UseVisualStyleBackColor = true;
            this.btnVentasNcf.Click += new System.EventHandler(this.btnVentasNcf_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 200);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 24);
            this.label4.TabIndex = 36;
            this.label4.Text = "Imprimir Copia:";
            // 
            // txtCopiaFactura
            // 
            this.txtCopiaFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.txtCopiaFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopiaFactura.FormattingEnabled = true;
            this.txtCopiaFactura.Items.AddRange(new object[] {
            "NO",
            "SI"});
            this.txtCopiaFactura.Location = new System.Drawing.Point(193, 192);
            this.txtCopiaFactura.Name = "txtCopiaFactura";
            this.txtCopiaFactura.Size = new System.Drawing.Size(100, 32);
            this.txtCopiaFactura.TabIndex = 37;
            // 
            // FormConfVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 321);
            this.Controls.Add(this.btnVentasNcf);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FormConfVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormConfVentas";
            this.Load += new System.EventHandler(this.FormConfVentas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtNCF;
        private System.Windows.Forms.Button btnVentasNcf;
        private System.Windows.Forms.TextBox txtNotificacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtContizLogo;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox txtImprimir;
        public System.Windows.Forms.ComboBox txtCopiaFactura;
        private System.Windows.Forms.Label label4;
    }
}