namespace BRL_SVentas.Forms
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModuloProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.ModuloUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.ModuloEmpresa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.facturarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btnCobrosPagos = new System.Windows.Forms.ToolStripSplitButton();
            this.cobrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.btnReportes = new System.Windows.Forms.ToolStripSplitButton();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cXCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cobrosCxCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.btnMantenimiento = new System.Windows.Forms.ToolStripSplitButton();
            this.registroDeProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajusteDeInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtUsuario = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripLabel1,
            this.toolStripSplitButton2,
            this.toolStripLabel2,
            this.btnCobrosPagos,
            this.toolStripLabel5,
            this.btnReportes,
            this.toolStripLabel3,
            this.btnMantenimiento,
            this.toolStripLabel4});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(796, 39);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.ModuloProveedores,
            this.ModuloUsuarios,
            this.ModuloEmpresa});
            this.toolStripSplitButton1.Image = global::BRL_SVentas.Properties.Resources.adim;
            this.toolStripSplitButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(48, 36);
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.ToolStripSplitButton1_ButtonClick);
            this.toolStripSplitButton1.MouseLeave += new System.EventHandler(this.toolStripSplitButton1_MouseLeave);
            this.toolStripSplitButton1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripSplitButton1_MouseMove);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Image = global::BRL_SVentas.Properties.Resources.user;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.ClientesToolStripMenuItem_Click);
            // 
            // ModuloProveedores
            // 
            this.ModuloProveedores.Image = global::BRL_SVentas.Properties.Resources.adim;
            this.ModuloProveedores.Name = "ModuloProveedores";
            this.ModuloProveedores.Size = new System.Drawing.Size(139, 22);
            this.ModuloProveedores.Text = "Proveedores";
            this.ModuloProveedores.Click += new System.EventHandler(this.ProveedoresToolStripMenuItem_Click);
            // 
            // ModuloUsuarios
            // 
            this.ModuloUsuarios.Image = global::BRL_SVentas.Properties.Resources.users;
            this.ModuloUsuarios.Name = "ModuloUsuarios";
            this.ModuloUsuarios.Size = new System.Drawing.Size(139, 22);
            this.ModuloUsuarios.Text = "Usuarios";
            this.ModuloUsuarios.Click += new System.EventHandler(this.UsuariosToolStripMenuItem_Click);
            // 
            // ModuloEmpresa
            // 
            this.ModuloEmpresa.Image = global::BRL_SVentas.Properties.Resources.empresa;
            this.ModuloEmpresa.Name = "ModuloEmpresa";
            this.ModuloEmpresa.Size = new System.Drawing.Size(139, 22);
            this.ModuloEmpresa.Text = "Empresa";
            this.ModuloEmpresa.Click += new System.EventHandler(this.EmpresaToolStripMenuItem_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(85, 36);
            this.toolStripLabel1.Text = "Entidades";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturarToolStripMenuItem});
            this.toolStripSplitButton2.Image = global::BRL_SVentas.Properties.Resources.preferences;
            this.toolStripSplitButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(48, 36);
            this.toolStripSplitButton2.ButtonClick += new System.EventHandler(this.ToolStripSplitButton2_ButtonClick);
            this.toolStripSplitButton2.MouseLeave += new System.EventHandler(this.toolStripSplitButton2_MouseLeave);
            this.toolStripSplitButton2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripSplitButton2_MouseMove);
            // 
            // facturarToolStripMenuItem
            // 
            this.facturarToolStripMenuItem.Image = global::BRL_SVentas.Properties.Resources.ImagenCaja;
            this.facturarToolStripMenuItem.Name = "facturarToolStripMenuItem";
            this.facturarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.facturarToolStripMenuItem.Text = "Facturar";
            this.facturarToolStripMenuItem.Click += new System.EventHandler(this.FacturarToolStripMenuItem_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(61, 36);
            this.toolStripLabel2.Text = "Ventas";
            // 
            // btnCobrosPagos
            // 
            this.btnCobrosPagos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCobrosPagos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cobrosToolStripMenuItem,
            this.comprasToolStripMenuItem});
            this.btnCobrosPagos.Image = ((System.Drawing.Image)(resources.GetObject("btnCobrosPagos.Image")));
            this.btnCobrosPagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCobrosPagos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCobrosPagos.Name = "btnCobrosPagos";
            this.btnCobrosPagos.Size = new System.Drawing.Size(48, 36);
            this.btnCobrosPagos.Text = "toolStripSplitButton5";
            this.btnCobrosPagos.ButtonClick += new System.EventHandler(this.ToolStripSplitButton5_ButtonClick);
            this.btnCobrosPagos.MouseLeave += new System.EventHandler(this.btnCobrosPagos_MouseLeave);
            this.btnCobrosPagos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCobrosPagos_MouseMove);
            // 
            // cobrosToolStripMenuItem
            // 
            this.cobrosToolStripMenuItem.Image = global::BRL_SVentas.Properties.Resources.IconoPagos;
            this.cobrosToolStripMenuItem.Name = "cobrosToolStripMenuItem";
            this.cobrosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cobrosToolStripMenuItem.Text = "Cobros CxC";
            this.cobrosToolStripMenuItem.Click += new System.EventHandler(this.CobrosToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.Image = global::BRL_SVentas.Properties.Resources.IconoPagos;
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.comprasToolStripMenuItem.Text = "Compras";
            this.comprasToolStripMenuItem.Click += new System.EventHandler(this.ComprasToolStripMenuItem_Click);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(126, 36);
            this.toolStripLabel5.Text = "Cobros y Pagos";
            // 
            // btnReportes
            // 
            this.btnReportes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem,
            this.cXCToolStripMenuItem,
            this.cobrosCxCToolStripMenuItem,
            this.comprasToolStripMenuItem1,
            this.inventarioToolStripMenuItem});
            this.btnReportes.Image = global::BRL_SVentas.Properties.Resources.app_chart;
            this.btnReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReportes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(48, 36);
            this.btnReportes.ButtonClick += new System.EventHandler(this.ToolStripSplitButton3_ButtonClick);
            this.btnReportes.MouseLeave += new System.EventHandler(this.btnReportes_MouseLeave);
            this.btnReportes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnReportes_MouseMove);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Image = global::BRL_SVentas.Properties.Resources.ReportVenta;
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.VentasToolStripMenuItem_Click);
            // 
            // cXCToolStripMenuItem
            // 
            this.cXCToolStripMenuItem.Image = global::BRL_SVentas.Properties.Resources.ReporteEfectivo;
            this.cXCToolStripMenuItem.Name = "cXCToolStripMenuItem";
            this.cXCToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cXCToolStripMenuItem.Text = "CXC";
            this.cXCToolStripMenuItem.Click += new System.EventHandler(this.CXCToolStripMenuItem_Click);
            // 
            // cobrosCxCToolStripMenuItem
            // 
            this.cobrosCxCToolStripMenuItem.Image = global::BRL_SVentas.Properties.Resources.ReporteEfectivo;
            this.cobrosCxCToolStripMenuItem.Name = "cobrosCxCToolStripMenuItem";
            this.cobrosCxCToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cobrosCxCToolStripMenuItem.Text = "Cobros CxC";
            this.cobrosCxCToolStripMenuItem.Click += new System.EventHandler(this.cobrosCxCToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem1
            // 
            this.comprasToolStripMenuItem1.Image = global::BRL_SVentas.Properties.Resources.ReporteEfectivo;
            this.comprasToolStripMenuItem1.Name = "comprasToolStripMenuItem1";
            this.comprasToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.comprasToolStripMenuItem1.Text = "Compras";
            this.comprasToolStripMenuItem1.Click += new System.EventHandler(this.comprasToolStripMenuItem1_Click);
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.Image = global::BRL_SVentas.Properties.Resources.business_inventory_maintenance_product_box_boxes_2326;
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            this.inventarioToolStripMenuItem.Click += new System.EventHandler(this.InventarioToolStripMenuItem_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(77, 36);
            this.toolStripLabel3.Text = "Reportes";
            // 
            // btnMantenimiento
            // 
            this.btnMantenimiento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroDeProductoToolStripMenuItem,
            this.ajusteDeInventarioToolStripMenuItem,
            this.informacionDelSistemaToolStripMenuItem});
            this.btnMantenimiento.Image = global::BRL_SVentas.Properties.Resources.config;
            this.btnMantenimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMantenimiento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMantenimiento.Name = "btnMantenimiento";
            this.btnMantenimiento.Size = new System.Drawing.Size(48, 36);
            this.btnMantenimiento.ButtonClick += new System.EventHandler(this.ToolStripSplitButton4_ButtonClick);
            this.btnMantenimiento.MouseLeave += new System.EventHandler(this.btnMantenimiento_MouseLeave);
            this.btnMantenimiento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMantenimiento_MouseMove);
            // 
            // registroDeProductoToolStripMenuItem
            // 
            this.registroDeProductoToolStripMenuItem.Image = global::BRL_SVentas.Properties.Resources.producto;
            this.registroDeProductoToolStripMenuItem.Name = "registroDeProductoToolStripMenuItem";
            this.registroDeProductoToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.registroDeProductoToolStripMenuItem.Text = "Registro de Producto";
            this.registroDeProductoToolStripMenuItem.Click += new System.EventHandler(this.RegistroDeProductoToolStripMenuItem_Click);
            // 
            // ajusteDeInventarioToolStripMenuItem
            // 
            this.ajusteDeInventarioToolStripMenuItem.Image = global::BRL_SVentas.Properties.Resources.business_inventory_maintenance_product_box_boxes_2326;
            this.ajusteDeInventarioToolStripMenuItem.Name = "ajusteDeInventarioToolStripMenuItem";
            this.ajusteDeInventarioToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ajusteDeInventarioToolStripMenuItem.Text = "Ajuste de Inventario";
            this.ajusteDeInventarioToolStripMenuItem.Click += new System.EventHandler(this.AjusteDeInventarioToolStripMenuItem_Click);
            // 
            // informacionDelSistemaToolStripMenuItem
            // 
            this.informacionDelSistemaToolStripMenuItem.Image = global::BRL_SVentas.Properties.Resources.about;
            this.informacionDelSistemaToolStripMenuItem.Name = "informacionDelSistemaToolStripMenuItem";
            this.informacionDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.informacionDelSistemaToolStripMenuItem.Text = "Informacion del Sistema";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(129, 36);
            this.toolStripLabel4.Text = "Mantenimiento";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(796, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(339, 431);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(445, 23);
            this.txtUsuario.TabIndex = 7;
            this.txtUsuario.Text = "Nombre Usuario";
            this.txtUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 453);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.IsMdiContainer = true;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Practica UAPA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModuloProveedores;
        private System.Windows.Forms.ToolStripMenuItem ModuloUsuarios;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSplitButton btnReportes;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSplitButton btnMantenimiento;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripMenuItem facturarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cXCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajusteDeInventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacionDelSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripMenuItem cobrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModuloEmpresa;
        private System.Windows.Forms.Label txtUsuario;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cobrosCxCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        public System.Windows.Forms.ToolStripSplitButton btnCobrosPagos;
    }
}



