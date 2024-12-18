using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRL_SVentas.Catalogos;
using BRL_SVentas.Model;
using BRL_SVentas.Servicios;
using DoctConsults;
using Microsoft.Reporting.WinForms;

namespace BRL_SVentas.Forms
{
    public partial class FormFacturacion : Form
    {
        private DataTable dt;
        private int IdCliente = 1;
        private int IdUsuario = 0;
        private int IdFactura = 0;
        private int IdCotizacion = 0;
        private int IdProducto = 0;
        private int IdFormaPago = 0;
        private int IdNCF = 1;
        private int CodigoProducto = 0;

        private decimal Total = 0;
        private decimal Itbis = 0;
        private decimal SubTotal = 0;
        private decimal gananciaProducto = 0;
        private decimal TotalGanancia = 0;

        private int obtener_num_fila = 0;
        private bool NCFDiponible = false;
        private bool dgvIndexSelecionado = false;
        private bool add_to_edit = false;//Indica cuando un articulo se extrae de la lista para editar si es true y false para registrar como nuevo.
        private string TipoCliente = string.Empty;
        public FormFacturacion()
        {
            InitializeComponent();
        }

        private void FormFacturacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
                var tblUsuario = new TblUsuario();
                var get = new _Usuario_get();
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out this.IdUsuario);
                tblUsuario = get.GetById(this.IdUsuario);
                txtUsuario.Text = tblUsuario.Nombre;
                txtCondicionPago.SelectedIndex = 0;
                GetListaRapida();
                var getPermiso = new _UsuarioPermiso_get();
                if (ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    btnEditarFactura.Visible = true;
                }
                txtBuscarProducto.Focus();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        #region SumarMontos
        private void SumarMontos()
        {
            try
            {
                var tbl = new TblProducto();
                var get = new _Producto_get();
                decimal precio = 0, monto = 0, ganacia = 0;
                int Id = 0, cantidad = 0;
                Total = 0;
                Itbis = 0;
                SubTotal = 0;
                TotalGanancia = 0;

                foreach (DataGridViewRow item in dgv.Rows)
                {
                    int.TryParse(item.Cells[0].Value.ToString(), out Id);
                    int.TryParse(item.Cells[3].Value.ToString(), out cantidad);
                    decimal.TryParse(item.Cells[4].Value.ToString(), out precio);
                    decimal.TryParse(item.Cells[5].Value.ToString(), out monto);
                    decimal.TryParse(item.Cells[6].Value.ToString(), out ganacia);
                    Total += monto;
                    TotalGanancia += ganacia;
                    tbl = get.GetById(Id);

                    Itbis += ((precio - (precio / (1 + (tbl.Itbis / 100)))) * cantidad);
                    //Itbis += (tbl.Itbis * cantidadFact);
                    SubTotal = Total - Itbis;
                   
                    txtSubTotal.Text = SubTotal.ToString("#,###.00;-#,###.00;0.00");
                    txtItbis.Text = Itbis.ToString("#,###.00;-#,###.00;0.00");
                    txtTotal.Text = Total.ToString("#,###.00;-#,###.00;0.00");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region AVISOS
        private void AVISOW(string mensaje)
        {
            MessageBox.Show(mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void AVISOI(string mensaje)
        {
            MessageBox.Show(mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Limpiar
        void Limpiar()
        {
            this.IdProducto = 0;
            this.CodigoProducto = 0;
            this.IdCliente = 1;
            this.IdFactura = 0;
            this.IdCotizacion = 0;
            this.IdFormaPago = 0;
            this.TotalGanancia = 0;
            this.gananciaProducto = 0;
            TipoCliente = string.Empty;

            Total = 0;
            Itbis = 0;
            SubTotal = 0;
            obtener_num_fila = 0;
            txtFecha.Value = DateTime.Now;
            dgvIndexSelecionado = false;
            txtCondicionPago.Text = "Al Contado";
            dgv.Rows.Clear();

            txtBuscarProducto.Text = String.Empty;
            txtBuscarProducto.Enabled = true;
            txtDescriccion.Text = String.Empty;
            txtPM.Text = String.Empty;
            txtCantidad.Text = String.Empty;
            txtPrecio.Text = String.Empty;
            txtSubTotal.Text = String.Empty;
            txtItbis.Text = String.Empty;
            txtTotal.Text = String.Empty;
            txtNota.Text = String.Empty;
            txtNombreCliente.Text = "CONSUMIDOR FINAL";
            txtNoFactura.Text = String.Empty;
            //txtNombreCliente.ReadOnly = false;

            //txtNombreCliente.Enabled = true;
            //txtTelefono.Enabled = true;
            txtNota.Enabled = true;
            txtBuscarProducto.Enabled = true;
            txtCantidad.Enabled = true;
            txtPrecio.Enabled = true;
            txtCondicionPago.Enabled = true;
            btnFacturar.Enabled = true;
            btnEliminar.Enabled = true;
            btnEditar.Enabled = true;
            btnImprimir.Enabled = false;
            btnBuscarFacturas.Enabled = true;
            btnBuscarClientes.Enabled = true;
            btnEditarFactura.Enabled = false;
            btnCxC.Enabled = true;
            dgv.Enabled = true;
            add_to_edit = false;

        }
        #endregion

        #region Limpiar2
        void Limpiar2()
        {
            this.gananciaProducto = 0;
            this.TotalGanancia = 0;
            this.NCFDiponible = false;
            Total = 0;
            Itbis = 0;
            SubTotal = 0;
            obtener_num_fila = 0;
            dgvIndexSelecionado = false;
            txtCondicionPago.Text = "Al Contado";
            dgv.Rows.Clear();

            txtBuscarProducto.Text = String.Empty;
            txtDescriccion.Text = String.Empty;
            txtPM.Text = String.Empty;
            txtCantidad.Text = String.Empty;
            txtPrecio.Text = String.Empty;
            txtSubTotal.Text = String.Empty;
            txtItbis.Text = String.Empty;
            txtTotal.Text = String.Empty;
            txtNota.Text = String.Empty;
            txtNombreCliente.Text = "Consumidor Final";
            txtNoFactura.Text = String.Empty;
            txtNombreCliente.ReadOnly = true;
            //txtNombreCliente.Enabled = true;
            //txtTelefono.Enabled = true;
            txtNota.Enabled = true;
            txtBuscarProducto.Enabled = true;
            txtCantidad.Enabled = true;
            txtPrecio.Enabled = true;
            txtCondicionPago.Enabled = true;
            btnFacturar.Enabled = true;
            btnEliminar.Enabled = true;
            btnEditar.Enabled = true;
            btnImprimir.Enabled = true;
            btnBuscarFacturas.Enabled = false;
            btnBuscarClientes.Enabled = false;
            btnEditarFactura.Enabled = false;
            dgv.Enabled = true;
            add_to_edit = false;
        }
        #endregion
      
        #region GetListaRapida
        private void GetListaRapida()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                var list = new List<TblListaRapida>();
                var factory = new _ListaRapida_get();
                list = factory.GetAll();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        var btn = new Button();
                        btn.Text = item.Descripcion;
                        btn.Tag = item.IdProducto.ToString();
                        btn.Size = new Size(210, 40);
                        btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btn.Click += new EventHandler(CargarProdListRapida);
                        flowLayoutPanel1.Controls.Add(btn);
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
        #endregion

        #region CargarProdListRapida
        public void CargarProdListRapida(object sender, System.EventArgs e)
        {
            try
            {
                if(this.IdProducto > 0)
                {
                    AVISOW("Para agregar productos por esta via, primero debe terminar el proceso con el producto que tiene selecionado.");
                    return;
                }
                //QUITAR LA IMAGEN CLICKEADA DEL CONTROL:
                Button p = (Button)sender;
                int getId = 0;
                int getIndexControl = 0;
                int.TryParse(p.Tag.ToString(), out getId);

                getIndexControl = flowLayoutPanel1.Controls.GetChildIndex(p);

                //Carcular el monto del articulo ha agregar:
                var tblProducto = new TblProducto();
                var get = new _Producto_get();
                tblProducto = get.GetById(getId);
                this.IdProducto = getId;
                decimal precio = 0, itbisAdelantado = 0;
                if (TipoCliente == "DISTRIBUIDOR")
                {
                    precio = tblProducto.PrecioMinimo;
                }
                else
                {
                    precio = tblProducto.PrecioVenta;
                }
                int cantidad = 1;
                itbisAdelantado = (tblProducto.PrecioCompra - (tblProducto.PrecioCompra / (1 + (tblProducto.Itbis / 100))));
                this.gananciaProducto = (precio - (tblProducto.PrecioCompra + (precio - (precio / (1 + (tblProducto.Itbis / 100)))))) + itbisAdelantado;

                //this.gananciaProducto = ((precio - tblProducto.PrecioCompra) * cantidad);
                //AGREGADO DE ARTICULO A LA LISTA DE LA FACTURA:
                if (!EditarProductLista(precio, this.gananciaProducto, cantidad))//Si el articula no esta en lista, proceder a anadir el articulo a la lista del Grid.
                {
                    dgv.Rows.Add(this.IdProducto.ToString(), tblProducto.Codigo.ToString(), tblProducto.Nombre, cantidad, precio, precio * cantidad, this.gananciaProducto.ToString("#,###.00;-#,###.00;0.00"));                 
                    dgv.ClearSelection();
                }
                dgv.Refresh();

                //Sumar los montos de la lista:
                SumarMontos();

                //Limpirar Id despues de terminar el proceso:
                this.IdProducto = 0;

                //Enfocar al texbox de busqueda:
                txtBuscarProducto.Focus();                                 
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
        #endregion

        #region Facturar
        private void Facturar()
        {
            try
            {
                //========COBRAR FACTURA=========//
                var form = new FormFormaPago();
                form.txtMontoEfectivo.Focus();
                form.IdNCF = this.IdNCF;
                if (txtCondicionPago.SelectedIndex == 0)
                {
                    form.txtMontoEfectivo.TabIndex = 1;
                    form.txtNoBoucher.TabIndex = 2;
                }
                else if (txtCondicionPago.SelectedIndex == 1)
                {
                    form.acredito = true;
                    form.btnCobrar.TabIndex = 1;
                    form.txtMontoEfectivo.TabIndex = 2;
                    form.txtNoBoucher.TabIndex = 3;
                }
                form.montoFactura = Convert.ToDecimal(txtTotal.Text);
                form.ShowDialog();

                if (form.pagado)
                {
                    //========REGISTRAR FORMA PAGO===========//
                    var tblFormaPago = new TblFormaPago();
                    tblFormaPago.IdUsuario = this.IdUsuario;
                    tblFormaPago.MontoEfectivo = form.MontoEfectivo - form.Devuelta;
                    tblFormaPago.MontoTarjeta = form.MontoTarjeta;
                    tblFormaPago.MontoCheque = form.MontoCheque;
                    tblFormaPago.NoBoucher = form.NoBoucher;
                    tblFormaPago.NoCheque = form.NoCheque;
                    tblFormaPago.MontoNotaCredito = form.MontoDevTransf;
                    tblFormaPago.Concepto = "FACTURACION";
                    this.IdFormaPago = _FormaPago.Save(tblFormaPago);
                    if (this.IdFormaPago == 0)
                    {
                        AVISOW("ERROR AL MOMENTO DE APLICAR EL PAGO DE LA FACTURA..");
                        return;
                    }
                    //========REGISTRAR FACTURA=========//
                    int valorInt = 0;
                    int IdSecuenciaNCF = 0;
                    decimal valorDecimal = 0;
                    txtFecha.Value = DateTime.Now;
                    var tblFactura = new TblFactura();
                    tblFactura.IdUsuario = this.IdUsuario;
                    tblFactura.IdCliente = this.IdCliente;
                    tblFactura.IdCajaApertura = ClaseGetCuenta.GetIdCajaApertura();
                    tblFactura.IdFormaPago = this.IdFormaPago;
                    tblFactura.Fecha = DateTime.Now;
                    tblFactura.CondicionPago = txtCondicionPago.Text;
                    decimal.TryParse(txtSubTotal.Text, out valorDecimal);
                    tblFactura.SubTotal = valorDecimal;
                    decimal.TryParse(txtItbis.Text, out valorDecimal);
                    tblFactura.Itbis = valorDecimal;
                    decimal.TryParse(txtTotal.Text, out valorDecimal);
                    tblFactura.Total = valorDecimal;
                    tblFactura.Nota = txtNota.Text;
                    tblFactura.Estado = "FACTURADO";
                    tblFactura.TotalGanancia = this.TotalGanancia;
                    this.IdFactura = _Factura.SaveXML(tblFactura);
                    if (this.IdFactura == 0)
                    {
                        AVISOW("ERROR AL MOMENTO DE GUARDAR LA FACTURA..");
                        return;
                    }

                    //========REGISTRAR DETALLE FACTURA===========//
                    var tblFacturaDetalle = new TblFacturaDetalle();
                    var tblProducto = new TblProducto();
                    var tblControlAlmacen = new TblControlAlmacen();
                    var get = new _Producto_get();
                    foreach (DataGridViewRow dgv in dgv.Rows)
                    {
                        //GET PRODUCTO:
                        int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);
                        tblProducto = get.GetById(valorInt);

                        tblFacturaDetalle.IdFactura = this.IdFactura;
                        int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);
                        tblFacturaDetalle.IdProducto = valorInt;
                        int.TryParse(dgv.Cells[3].Value.ToString(), out valorInt);

                        tblFacturaDetalle.CantidadFacturada = valorInt;
                        decimal.TryParse(dgv.Cells[4].Value.ToString(), out valorDecimal);
                        tblFacturaDetalle.PrecioFacturado = valorDecimal;
                        tblFacturaDetalle.ItbisFacturado = ((valorDecimal - (valorDecimal / (1 + (tblProducto.Itbis / 100)))) * valorInt);
                        decimal.TryParse(dgv.Cells[5].Value.ToString(), out valorDecimal);
                        tblFacturaDetalle.MontoFacturado = valorDecimal;
                        decimal.TryParse(dgv.Cells[6].Value.ToString(), out valorDecimal);
                        tblFacturaDetalle.Ganancia = valorDecimal;

                        _FacturaDetalle.Save(tblFacturaDetalle);

                        //ACTUALIZAR LA CANTIDAD EXISTENTE DEL PRODUCTO:
                        int valorInt2 = 0;
                        int.TryParse(dgv.Cells[3].Value.ToString(), out valorInt2);
                        if (valorInt == 0 || valorInt != valorInt2)
                        {
                            AVISOW("El valor a descontar del inventario es 0. ID = " + tblFacturaDetalle.IdProducto.ToString() + " valorInt = " + valorInt.ToString() + " valorInt2 = " + valorInt2.ToString());
                        } 
                        tblProducto.CantidadExistente -= valorInt;
                        _Productos.Update(tblProducto);

                        //=====REGISTRAR EL CONTROL DE ALMACEN======//
                        tblControlAlmacen.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                        tblControlAlmacen.IdRegistro = this.IdFactura;
                        int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);
                        tblControlAlmacen.IdProducto = valorInt;
                        tblControlAlmacen.Descripcion = tblProducto.Nombre;
                        tblControlAlmacen.Modulo = "FACTURACION";
                        tblControlAlmacen.Movimiento = "SALIDA";
                        int.TryParse(dgv.Cells[3].Value.ToString(), out valorInt);
                        tblControlAlmacen.Cantidad = valorInt;
                        tblControlAlmacen.Fecha = DateTime.Now;
                        _ControlAlmacen.Save(tblControlAlmacen);
                    }

                    //========REGISTRAR CXC===========//
                    var tblCaja = new TblCaja();
                    if (txtCondicionPago.SelectedIndex == 1)
                    {
                        //Registrar CxC:
                        int IdCxC = 0;
                        var tblCxC = new TblCxC();
                        tblCxC.IdUsuario = this.IdUsuario;
                        tblCxC.IdFactura = this.IdFactura;
                        tblCxC.IdCliente = this.IdCliente;
                        tblCxC.Fecha = DateTime.Now;
                        tblCxC.Concepto = "VENTA A CREDITO";
                        tblCxC.Monto = tblFactura.Total;
                        tblCxC.Balance = tblFactura.Total - form.pagoTotal;
                        tblCxC.Estado = "PENDIENTE";
                        tblCxC.Nota = txtNota.Text;
                        tblCxC.ClienteNombre = txtNombreCliente.Text;
                        IdCxC = _CxC.SaveXML(tblCxC);

                        //========REGISTRAR COBRO===========//
                        if (form.pagoTotal > 0)
                        {
                            var tblCobro = new TblCobro();
                            tblCobro.IdCxC = IdCxC;
                            tblCobro.IdUsuario = this.IdUsuario;
                            tblCobro.IdCajaApertura = valorInt;
                            tblCobro.Fecha = DateTime.Now;
                            tblCobro.Abono = form.pagoTotal;
                            decimal.TryParse(txtTotal.Text, out valorDecimal);
                            tblCobro.Monto = valorDecimal;
                            tblCobro.Balance = tblCobro.Monto - tblCobro.Abono;
                            tblCobro.Nota = txtNota.Text;
                            valorInt = _Cobros.SaveXML(tblCobro);

                            //Registrar en Movimeinto de Caja:
                            tblCaja.IdUsuario = this.IdUsuario;
                            tblCaja.Fecha = DateTime.Now;
                            tblCaja.Registro = valorInt;
                            tblCaja.Modulo = "COBRO CXC";
                            tblCaja.Monto = form.pagoTotal;
                            tblCaja.Caja = "#1";
                            tblCaja.Estado = "ABIERTA";
                            int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out valorInt);
                            tblCaja.IdCajaApertura = valorInt;
                            _Caja.Save(tblCaja);
                        }
                    }
                    else
                    {
                        //Registrar en Movimeinto de Caja:
                        tblCaja.IdUsuario = this.IdUsuario;
                        tblCaja.Fecha = DateTime.Now;
                        tblCaja.Registro = this.IdFactura;
                        tblCaja.Modulo = "FACTURACION";
                        tblCaja.Monto = form.pagoTotal;
                        tblCaja.Caja = "#1";
                        tblCaja.Estado = "ABIERTA";
                        int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out valorInt);
                        tblCaja.IdCajaApertura = valorInt;
                        _Caja.Save(tblCaja);
                    }

                    if(form.txtImprimir.Text == "IMPRIMIR")
                    ImprimirFactura(string.Empty);
                    var formDevuelta = new FormDevuelta();
                    formDevuelta.txtDevuelta.Text = form.Devuelta.ToString("#,###.00;-#,###.00;0.00");
                    formDevuelta.ShowDialog();
                    Limpiar();
                }             
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Cotizar
        private void Cotizar()
        {
            try
            {
                int valorInt = 0;
                decimal valorDecimal = 0;
                if (dgv.Rows.Count <= 0)//Verificar si hay registro en la fila para editar.
                {
                    MessageBox.Show("No hay registro en esta fila", "Editar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.IdCotizacion > 0)
                {
                    if (MessageBox.Show("Realmente desea guardar cambios en esta cotizacion?", "Cotizar Compra", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                    //Insertar los datos ingresado:
                    var tblCotizacion = new TblCotizacion();
                    tblCotizacion.IdCotizacion = this.IdCotizacion;
                    tblCotizacion.IdUsuario = this.IdUsuario;
                    tblCotizacion.Fecha = DateTime.Now;
                    tblCotizacion.IdCliente = this.IdCliente;
                    decimal.TryParse(txtTotal.Text, out valorDecimal);
                    tblCotizacion.Total = valorDecimal;
                    decimal.TryParse(txtSubTotal.Text, out valorDecimal);
                    tblCotizacion.SubTotal = valorDecimal;
                    decimal.TryParse(txtItbis.Text, out valorDecimal);
                    tblCotizacion.Itbis = valorDecimal;
                    tblCotizacion.Nota = txtNota.Text;
                    tblCotizacion.TotalGanancia = this.TotalGanancia;
                    this.IdCotizacion = _Cotizacion.SaveXML(tblCotizacion);
                    if (this.IdCotizacion <= 0)
                    {
                        AVISOW("ERROR EN EL GUARDADO DE DATOS.");
                        return;
                    }
                    var tblCotizacionDetalle = new TblCotizacionDetalle();
                    var tblProducto = new TblProducto();
                    var get = new _Producto_get();
                    _CotizacionDetalle.DeleteAll(this.IdCotizacion);

                    foreach (DataGridViewRow dgv in dgv.Rows)
                    {
                        //GET PRODUCTO:  
                        tblCotizacionDetalle.IdCotizacion = this.IdCotizacion;
                        int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);
                        tblCotizacionDetalle.IdProducto = valorInt;
                        tblProducto = get.GetById(valorInt);
                        int.TryParse(dgv.Cells[3].Value.ToString(), out valorInt);
                        tblCotizacionDetalle.CantidadCotizada = valorInt;
                        decimal.TryParse(dgv.Cells[4].Value.ToString(), out valorDecimal);
                        tblCotizacionDetalle.PrecioCotizado = valorDecimal;
                        tblCotizacionDetalle.ItbisCotizado = ((valorDecimal - (valorDecimal / (1 + (tblProducto.Itbis / 100)))) * valorInt);
                        decimal.TryParse(dgv.Cells[5].Value.ToString(), out valorDecimal);
                        tblCotizacionDetalle.MontoCotizado = valorDecimal;
                        decimal.TryParse(dgv.Cells[6].Value.ToString(), out valorDecimal);
                        tblCotizacionDetalle.Ganancia = valorDecimal;

                        if (!_CotizacionDetalle.Save(tblCotizacionDetalle))
                        {
                            AVISOW("ERROR EN EL GUARDADO DE DATOS.");
                            return;
                        }
                    }
                }
                if (this.IdCotizacion == 0)
                {
                    if (MessageBox.Show("Confirme que desea generar la cotizacion?", "Cotizar Compra", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                    //Insertar los datos ingresado:
                    var tblCotizacion = new TblCotizacion();
                    tblCotizacion.IdCotizacion = this.IdCotizacion;
                    tblCotizacion.IdUsuario = this.IdUsuario;
                    tblCotizacion.Fecha = DateTime.Now;
                    tblCotizacion.IdCliente = this.IdCliente;
                    decimal.TryParse(txtTotal.Text, out valorDecimal);
                    tblCotizacion.Total = valorDecimal;
                    decimal.TryParse(txtSubTotal.Text, out valorDecimal);
                    tblCotizacion.SubTotal = valorDecimal;
                    decimal.TryParse(txtItbis.Text, out valorDecimal);
                    tblCotizacion.Itbis = valorDecimal;
                    tblCotizacion.Nota = txtNota.Text;
                    tblCotizacion.TotalGanancia = this.TotalGanancia;
                    this.IdCotizacion = _Cotizacion.SaveXML(tblCotizacion);
                    if (this.IdCotizacion <= 0)
                    {
                        AVISOW("ERROR EN EL GUARDADO DE DATOS.");
                        return;
                    }
                    var tblCotizacionDetalle = new TblCotizacionDetalle();
                    var tblProducto = new TblProducto();
                    var get = new _Producto_get();
                    foreach (DataGridViewRow dgv in dgv.Rows)
                    {
                        //GET PRODUCTO:
                        tblCotizacionDetalle.IdCotizacion = this.IdCotizacion;
                        int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);
                        tblCotizacionDetalle.IdProducto = valorInt;
                        tblProducto = get.GetById(valorInt);
                        int.TryParse(dgv.Cells[3].Value.ToString(), out valorInt);
                        tblCotizacionDetalle.CantidadCotizada = valorInt;
                        decimal.TryParse(dgv.Cells[4].Value.ToString(), out valorDecimal);
                        tblCotizacionDetalle.PrecioCotizado = valorDecimal;
                        tblCotizacionDetalle.ItbisCotizado = ((valorDecimal - (valorDecimal / (1 + (tblProducto.Itbis / 100)))) * valorInt);
                        decimal.TryParse(dgv.Cells[5].Value.ToString(), out valorDecimal);
                        tblCotizacionDetalle.MontoCotizado = valorDecimal;
                        decimal.TryParse(dgv.Cells[6].Value.ToString(), out valorDecimal);
                        tblCotizacionDetalle.Ganancia = valorDecimal;
                        int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);

                        if (!_CotizacionDetalle.Save(tblCotizacionDetalle))
                        {
                            AVISOW("ERROR EN EL GUARDADO DE DATOS.");
                            return;
                        }
                    }
                }

                ImprimirCotizacion();
                Limpiar();
                AVISOI("DATOS GUARDADOS.");             
            }
            catch (Exception)
            {

                throw;
            }           
        }
        #endregion

        #region Editar
        private void Editar()
        {
            try
            {
                if (add_to_edit)
                {
                    MessageBox.Show("Solo puede editar un registro a la ves.", "Editar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgv.Rows.Count > 0)//Verificar si hay registro en la fila para editar.
                {
                    var tbl = new TblProducto();
                    var get = new _Producto_get();
                    int valorInt = 0;
                    decimal monto = 0, precio = 0;
                    int.TryParse(dgv[0, obtener_num_fila].Value.ToString(), out valorInt);
                    this.IdProducto = valorInt;
                    tbl = get.GetById(valorInt);               
                    int.TryParse(dgv[1, obtener_num_fila].Value.ToString(), out valorInt);
                    CodigoProducto = valorInt;
                    txtBuscarProducto.Text = dgv[1, obtener_num_fila].Value.ToString();
                    txtDescriccion.Text = dgv[2, obtener_num_fila].Value.ToString();
                    txtCantidad.Text = dgv[3, obtener_num_fila].Value.ToString();
                    txtPrecio.Text = dgv[4, obtener_num_fila].Value.ToString();
                    txtPM.Text = tbl.PrecioMinimo.ToString();

                    //Restar valores del registro antes de sacarlo de la lista:
                    int.TryParse(dgv[3, obtener_num_fila].Value.ToString(), out valorInt);
                    decimal.TryParse(dgv[4, obtener_num_fila].Value.ToString(), out precio);
                    decimal.TryParse(dgv[5, obtener_num_fila].Value.ToString(), out monto);
                    Itbis -= (precio - (precio / (1 + (tbl.Itbis / 100)))) * valorInt;
                    TotalGanancia -= Convert.ToDecimal(dgv[6, obtener_num_fila].Value.ToString());
                    
                    Total -= monto;
                    SubTotal = Total - Itbis;
                    txtSubTotal.Text = SubTotal.ToString("#,###.00;-#,###.00;0.00");
                    txtItbis.Text = Itbis.ToString("#,###.00;-#,###.00;0.00");
                    txtTotal.Text = Total.ToString("#,###.00;-#,###.00;0.00");

                    dgv.Rows.RemoveAt(obtener_num_fila);//Eliminar Fila
                    dgv.RefreshEdit();
                    txtBuscarProducto.Enabled = false;
                    SumarMontos();
                    add_to_edit = true;//Indicar que el producto que se a extraido es para editarlo y no para registrarlo como nuevo.
                    txtPrecio.Focus();                 
                }
                else { MessageBox.Show("No hay registro en esta fila", "Editar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            }
            catch (Exception)
            {

                throw;
            }         
        }
        #endregion

        #region EditarProductLista
        private bool EditarProductLista(decimal precio, decimal ganancia, int cantidad)
        {
            try
            {
                if (dgv.Rows.Count <= 0)
                {
                    return false;
                }
                //VERIFICAR SI EL ARTICULO QUE SE DESEA AGREGAR YA ESTA EN LA LISTA PARA SOLO ACTUALIZARLE LA CANTIDAD:
                foreach (DataGridViewRow dgv_comp in dgv.Rows)
                {
                    if (dgv_comp.Cells[0].Value != null)
                    {
                        //Verificar cual de las row tiene el codigo del producto que se esta buscando.
                        if (dgv_comp.Cells["colIdProducto"].Value.ToString() == this.IdProducto.ToString())
                        {
                            //Sumarle a la cantidad actual lo que se desea anadir:
                            cantidad = Int32.Parse(dgv[3, dgv_comp.Index].Value.ToString()) + cantidad;

                            //Agregar los valores actualizados a las celdas de la Row corespondiendes en el Grid:
                            dgv[3, dgv_comp.Index].Value = cantidad;
                            dgv[4, dgv_comp.Index].Value = precio;
                            dgv[5, dgv_comp.Index].Value = precio * cantidad;
                            dgv[6, dgv_comp.Index].Value = ganancia * cantidad;

                            return true;//Idicar que es un articulo que ya esta en la lista.
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
                return false;
            }
        }
        #endregion

        #region Eliminar
        private void Eliminar()
        {
            try
            {
                if (!dgvIndexSelecionado)
                {
                    MessageBox.Show("Para eliminar primero debe selecionar un producto en lista.", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (add_to_edit)
                {
                    AVISOW("Para eliminar primero debe terminar el proceso con el producto que tiene selecionado.");
                    return;
                }
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Realmente desea eliminar este producto de la lista?", "Facturar Compra", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                {
                    return;
                }

                if (dgv.Rows.Count > 0)//Verificar si hay registro en la fila para eliminar.
                {
                    var tbl = new TblProducto();
                    var get = new _Producto_get();
                    int valorInt = 0;
                    decimal monto = 0, precio = 0;
                    int.TryParse(dgv[0, obtener_num_fila].Value.ToString(), out valorInt);
                    tbl = get.GetById(valorInt);
                    this.IdProducto = valorInt;

                    //Restar valores del registro antes de sacarlo de la lista:
                    int.TryParse(dgv[3, obtener_num_fila].Value.ToString(), out valorInt);
                    decimal.TryParse(dgv[4, obtener_num_fila].Value.ToString(), out precio);
                    decimal.TryParse(dgv[5, obtener_num_fila].Value.ToString(), out monto);
                    Itbis -= (precio - (precio / (1 + (tbl.Itbis / 100)))) * valorInt;

                    Total -= monto;
                    SubTotal = Total - Itbis;
                    TotalGanancia -= Convert.ToDecimal(dgv[6, obtener_num_fila].Value.ToString());
                    txtSubTotal.Text = SubTotal.ToString("#,###.00;-#,###.00;0.00");
                    txtItbis.Text = Itbis.ToString("#,###.00;-#,###.00;0.00");
                    txtTotal.Text = Total.ToString("#,###.00;-#,###.00;0.00");

                    dgv.Rows.RemoveAt(obtener_num_fila);//Eliminar Fila
                    dgv.ClearSelection();
                    dgvIndexSelecionado = false;

                    //Limpirar Id despues de terminar el proceso:
                    this.IdProducto = 0;

                }
                else { MessageBox.Show("No hay registro en esta fila", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ImprimirFactura
        private void ImprimirFactura(string tipoPapel)
        {
            try
            {
                if (string.IsNullOrEmpty(tipoPapel))
                {
                    var tblConfig = new TblMasterConfig();
                    var getConfig = new _MasterConfig_get();
                    tblConfig = getConfig.GetById(1);
                    if (tblConfig != null)
                    {
                        if (tblConfig.PapelFactura == "NO IMPRIMIR")
                        {
                            return;
                        }
                        tipoPapel = tblConfig.PapelFactura;
                    }
                }
                 
                DateTime fecha = DateTime.Now;
                int IdCuenta = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdCuenta);
                var builder = new StringBuilder();
                builder.Append("SELECT TblFactura.Fecha, CantidadFacturada, PrecioFacturado, ItbisFacturado, MontoFacturado, TblProducto.Nombre, TblProducto.Codigo, TblProducto.PrecioCompra FROM TblFacturaDetalle");
                builder.Append(" JOIN TblFactura on TblFactura.IdFactura = TblFacturaDetalle.IdFactura");
                builder.Append(" JOIN TblProducto on TblProducto.IdProducto = TblFacturaDetalle.IdProducto");
                builder.Append(" WHERE TblFactura.IdFactura = '" + this.IdFactura + "'");
                var conexion = new Conexion();
                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);
                Imprimir();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Imprimir
        private void Imprimir()
        {
            try
            {
                FormVisor frm = new FormVisor();
                frm.reportViewer1.Reset();
                var empresa = new TblEmpresa();//BUSCAMOS LOS DATOS DE LA CUENTA DEL DOCTOR
                var get = new _Empresa_get();
                empresa = get.GetById(1);
                var tblUsuario = new TblUsuario();
                var getUsuario = new _Usuario_get();
                tblUsuario = getUsuario.GetById(this.IdUsuario);

                if (this.IdFactura > 0)
                {
                    var tblFactura = new TblFactura();
                    var getFactura = new _Factura_get();
                    tblFactura = getFactura.GetById(this.IdFactura);

                    var tblCliente = new TblCliente();
                    var getCliente = new _Cliente_get();
                    tblCliente = getCliente.GetById(this.IdCliente);

                    var tblMaster = new TblMasterConfig();
                    var getMaster = new _MasterConfig_get();
                    tblMaster = getMaster.GetById(1);

                    //PARAMETROS PARA EL REPORTE
                    ReportParameter[] paramCollection = new ReportParameter[16];
                    paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                    paramCollection[1] = new ReportParameter("Direccion", empresa.Direccion, true);
                    paramCollection[2] = new ReportParameter("Telefono", empresa.Telefono1, true);
                    paramCollection[3] = new ReportParameter("RNC", empresa.RNC, true);
                    paramCollection[4] = new ReportParameter("SubTotal", tblFactura.SubTotal.ToString("#,###.00;-#,###.00;0.00"), true);
                    paramCollection[5] = new ReportParameter("ItbisTotal", tblFactura.Itbis.ToString("#,###.00;-#,###.00;0.00"), true);
                    paramCollection[6] = new ReportParameter("Total", tblFactura.Total.ToString("#,###.00;-#,###.00;0.00"), true);
                    paramCollection[7] = new ReportParameter("NoFactura", tblFactura.Codigo.ToString(), true);
                    paramCollection[8] = new ReportParameter("NombreCliente", tblCliente.Nombre, true);
                    paramCollection[9] = new ReportParameter("Usuario", tblUsuario.Nombre, true);
                    paramCollection[10] = new ReportParameter("NCF", "NO", true);
                    paramCollection[11] = new ReportParameter("Fecha", tblFactura.Fecha.Value.ToShortDateString(), true);
                    paramCollection[12] = new ReportParameter("Hora", tblFactura.Fecha.Value.ToShortTimeString(), true);
                    paramCollection[13] = new ReportParameter("CondicionPago", tblFactura.CondicionPago, true);
                    paramCollection[14] = new ReportParameter("CodigoCliente", tblCliente.Codigo.ToString(), true);
                    paramCollection[15] = new ReportParameter("RNCCliente", tblCliente.Cedula, true);

                    ClassImprimir.ImprimirReporte("DataSetFactura", "Impresiones.FACTURA_MEDIA_PG", paramCollection, this.dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region ImprimirCotizacion
        private void ImprimirCotizacion()
        {
            try
            {
                int IdCuenta = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdCuenta);
                var builder = new StringBuilder();
                builder.Append("SELECT TblProducto.IdProducto, TblProducto.Codigo, CantidadCotizada, PrecioCotizado, MontoCotizado, ItbisCotizado, TblProducto.Nombre, TblProducto.Itbis FROM");
                builder.Append(" TblCotizacionDetalle JOIN TblProducto on TblProducto.IdProducto = TblCotizacionDetalle.IdProducto");
                builder.Append(" WHERE IdCotizacion = '" + this.IdCotizacion + "'");
                var conexion = new Conexion();
                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);

                decimal subTotal = 0, itbisTotal = 0, total = 0;
                decimal valorDecimal = 0;
                int valorInt = 0;
                var tbl = new TblProducto();
                var get = new _Producto_get();
                foreach (DataRow item in dt.Rows)
                {
                    int.TryParse(item["IdProducto"].ToString(), out valorInt);
                    tbl = get.GetById(valorInt);
                    int.TryParse(item["CantidadCotizada"].ToString(), out valorInt);
                    decimal.TryParse(item["PrecioCotizado"].ToString(), out valorDecimal);
                    itbisTotal += ((valorDecimal - (valorDecimal / (1 + (tbl.Itbis / 100)))) * valorInt);
                    decimal.TryParse(item["MontoCotizado"].ToString(), out valorDecimal);
                    total += valorDecimal;
                }
                subTotal = total - itbisTotal;
                ImprimirCT(subTotal, itbisTotal, total);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ImprimirCT
        private void ImprimirCT(decimal subTotal, decimal itbisTotal, decimal total)
        {
            try
            {
                var form = new FormModoImpresion();
                form.factura = false;
                form.ShowDialog();

                FormVisor frm = new FormVisor();
                frm.reportViewer1.Reset();
                var empresa = new TblEmpresa();//BUSCAMOS LOS DATOS DE LA CUENTA DEL DOCTOR
                var get = new _Empresa_get();
                empresa = get.GetById(1);
                var tblUsuario = new TblUsuario();
                var getUsuario = new _Usuario_get();
                tblUsuario = getUsuario.GetById(ClaseGetCuenta.GetIdUsuario());

                var tblCliente = new TblCliente();
                var getCliente = new _Cliente_get();
                tblCliente = getCliente.GetById(this.IdCliente);

                var tblCotizacion = new TblCotizacion();
                var getCotizacion = new _Cotizacion_get();
                tblCotizacion = getCotizacion.GetById(this.IdCotizacion);

                var tblMaster = new TblMasterConfig();
                var getMaster = new _MasterConfig_get();
                tblMaster = getMaster.GetById(1);
                if (tblMaster == null)
                {
                    tblMaster.ContizacionLogo = "NO APLICADO";
                }
                //PARAMETROS PARA EL REPORTE
                ReportParameter[] paramCollection = new ReportParameter[15];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("RNC", empresa.RNC, true);
                paramCollection[2] = new ReportParameter("Direccion", empresa.Direccion, true);
                paramCollection[3] = new ReportParameter("Telefono", empresa.Telefono1, true);
                paramCollection[4] = new ReportParameter("SubTotal", subTotal.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[5] = new ReportParameter("ItbisTotal", itbisTotal.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[6] = new ReportParameter("Total", total.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[7] = new ReportParameter("NoCotizacion", tblCotizacion.Codigo.ToString(), true);
                paramCollection[8] = new ReportParameter("NombreCliente", txtNombreCliente.Text, true);
                paramCollection[9] = new ReportParameter("Usuario", tblUsuario.Nombre, true);
                paramCollection[10] = new ReportParameter("Fecha", tblCotizacion.Fecha.Value.ToShortDateString(), true);
                paramCollection[11] = new ReportParameter("Hora", tblCotizacion.Fecha.Value.ToShortTimeString(), true);
                paramCollection[12] = new ReportParameter("CodigoCliente", tblCliente.Codigo.ToString(), true);
                paramCollection[13] = new ReportParameter("Logo", Application.StartupPath + "\\Imagenes\\" + empresa.Logo, true);
                paramCollection[14] = new ReportParameter("Actividad", empresa.Actividad, true);


                if (tblMaster.ContizacionLogo == "APLICADO")
                {
                    if(form.modoImpresion == "MEDIA PAGINA")
                    {
                        ClassImprimir.ImprimirRecibo("DataSetCotizacion", "Impresiones.COTIZACION_MEDIA_PG", paramCollection, this.dt, "MEDIA PAGINA", "FACTURA");
                    }
                    else if (form.modoImpresion == "DIGITAL")
                    {
                        ClassImprimir.ImprimirReporte("DataSetCotizacion", "Impresiones.COTIZACION_LOGO", paramCollection, this.dt);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (form.modoImpresion == "MEDIA PAGINA")
                    {
                        ClassImprimir.ImprimirRecibo("DataSetCotizacion", "Impresiones.COTIZACION_MEDIA_PG", paramCollection, this.dt, "MEDIA PAGINA", "FACTURA");
                    }
                    else if (form.modoImpresion == "DIGITAL")
                    {
                        ClassImprimir.ImprimirReporte("DataSetCotizacion", "Impresiones.COTIZACIONSINITBI", paramCollection, this.dt);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        private void TxtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Condiciones para que solo acepte valores numericos:
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    if (string.IsNullOrEmpty(txtBuscarProducto.Text))
                    {
                        this.IdProducto = 0;
                        this.CodigoProducto = 0;
                        var form = new FormCatalogoProductos();
                        form.txtBuscar.Text = txtBuscarProducto.Text;
                        form.ShowDialog();
                        if (form.Id > 0)
                        {
                            txtBuscarProducto.Text = form.Id.ToString();
                            this.IdProducto = form.Id;
                            this.CodigoProducto = form.codigo;
                            txtDescriccion.Text = form.descripcion;
                            txtPM.Text = form.precioMinimo.ToString();
                            if(TipoCliente == "DISTRIBUIDOR")
                            {
                                txtPrecio.Text = form.precioMinimo.ToString();
                            }
                            else
                            {
                                txtPrecio.Text = form.precioVenta.ToString();
                            }                        
                        }
                        else
                        {
                            this.IdProducto = 0;
                            this.CodigoProducto = 0;
                            txtDescriccion.Text = string.Empty;
                            txtPM.Text = string.Empty;
                            txtPrecio.Text = string.Empty;
                        }
                    }
                    else
                    {
                        var tbl = new TblProducto();
                        var get = new _Producto_get();
                        int codigoProducto = 0;
                        int.TryParse(txtBuscarProducto.Text, out codigoProducto);
                        tbl = get.GetByCodigo(codigoProducto);
                        if(tbl != null)
                        {
                            txtBuscarProducto.Text = codigoProducto.ToString();
                            this.IdProducto = tbl.IdProducto;
                            this.CodigoProducto = tbl.Codigo;
                            txtDescriccion.Text = tbl.Nombre;
                            txtPM.Text = tbl.PrecioMinimo.ToString("#,###.00;-#,###.00;0.00");
                            if (TipoCliente == "DISTRIBUIDOR")
                            {
                                txtPrecio.Text = tbl.PrecioMinimo.ToString("#,###.00;-#,###.00;0.00");
                            }
                            else
                            {
                                txtPrecio.Text = tbl.PrecioVenta.ToString("#,###.00;-#,###.00;0.00");
                            }
                        }
                        else
                        {
                            AVISOW("Su peticion no a producido resultados.");
                            return;
                        }
                    }

                    add_to_edit = false;
                    //Enfocar a tb_precio:
                    if (!string.IsNullOrEmpty(txtDescriccion.Text))
                        //txtPrecio.Focus();
                        txtCantidad.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPrecio.Text))
                    return;

                //Condiciones para que solo acepte valores numericos:
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    if (!string.IsNullOrEmpty(txtDescriccion.Text))
                    {
                        decimal precio = 0;
                        decimal.TryParse(txtPrecio.Text, out precio);
                        decimal precioM = 0;
                        decimal.TryParse(txtPM.Text, out precioM);
                        //Aseguarar que no se ingrese un precio menor al precio minimo:
                        if (precio >= precioM)
                        {
                            txtCantidad.Focus();
                        }

                        else if (precio < precioM)
                        {
                            MessageBox.Show("El precio ingresado es menor al precio minimo.", "Ingreso de precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            precio = precioM;
                            txtPrecio.Text = precio.ToString("#,###.00;-#,###.00;0.00");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe llenar todo los campos.", "Ingreso de precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Condiciones para que solo acepte valores numericos:
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    if (string.IsNullOrEmpty(txtCantidad.Text))
                    {
                        AVISOW("Para agregar un producto a la lista debe especificar la cantidad.");
                        return;
                    }
                    //Carcular el monto del articulo ha agregar:
                    var tblProducto = new TblProducto();
                    var get = new _Producto_get();
                    decimal precio = 0, precioM = 0, itbisAdelantado = 0;
                    tblProducto = get.GetById(this.IdProducto);
                    decimal.TryParse(txtPrecio.Text, out precio);
                    decimal.TryParse(txtPM.Text, out precioM);
                    int cantidad = Int32.Parse(txtCantidad.Text);
                    itbisAdelantado = (tblProducto.PrecioCompra - (tblProducto.PrecioCompra / (1 + (tblProducto.Itbis / 100))));
                    this.gananciaProducto = (precio - (tblProducto.PrecioCompra + (precio - (precio / (1 + (tblProducto.Itbis / 100)))))) + itbisAdelantado;
                    //this.gananciaProducto = ((precio - tblProducto.PrecioCompra) * cantidad);

                    if (string.IsNullOrEmpty(txtDescriccion.Text) || string.IsNullOrEmpty(txtCantidad.Text))
                    {
                        MessageBox.Show("Debe llenar todo los campos", "Ingreso de precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (cantidad <= 0)
                    {
                        MessageBox.Show("El valor de la cantidad no es aceptable.", "Ingreso de precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Aseguarar que no se ingrese un precio menor al precio minimo:
                    if (precio < precioM)
                    {
                        MessageBox.Show("El precio ingresado es menor al precio minimo.", "Ingreso de precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        precio = precioM;
                        txtPrecio.Text = precio.ToString();
                        return;
                    }
                    //AGREGADO DE ARTICULO A LA LISTA DE LA FACTURA:
                    if (!EditarProductLista(precio, this.gananciaProducto, cantidad))//Si el articula no esta en lista, proceder a anadir el articulo a la lista del Grid.
                    {
                        dgv.Rows.Add(this.IdProducto.ToString(), this.CodigoProducto.ToString(), txtDescriccion.Text, txtCantidad.Text, txtPrecio.Text, precio * cantidad, (this.gananciaProducto * cantidad).ToString("#,###.00;-#,###.00;0.00"));
                        dgv.ClearSelection();
                    }
                    //Sumar el total de la compra:
                    Total = 0;
                    Itbis = 0;
                    SubTotal = 0;

                    //Limpiar TexBox despues de agregar un articulo a la lista:
                    txtBuscarProducto.Clear();
                    txtBuscarProducto.Enabled = true;
                    txtDescriccion.Clear();
                    txtCantidad.Clear();
                    txtPM.Clear();
                    txtPrecio.Clear();
                    add_to_edit = false;
                    dgv.Refresh();

                    //Sumar los montos de la lista:
                    SumarMontos();

                    //Limpirar Id despues de terminar el proceso:
                    this.IdProducto = 0;

                    //Enfocar al texbox de busqueda:
                    txtBuscarProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {      
                Editar();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Eliminar();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cotizar();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.RowCount <= 0)
                {
                    MessageBox.Show("No hay articulos para facturar.", "Facturar Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtCondicionPago.SelectedIndex == 1 && this.IdCliente <= 1)
                {
                    MessageBox.Show("Para facturar a credito primero debe buscar el cliente.", "Facturar Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Facturar();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnBuscarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoCliente();
                form.ShowDialog();
                if(form.IdCliente > 1)
                {
                    this.IdCliente = form.IdCliente;
                    txtNombreCliente.Text = form.Nombre;
                    TipoCliente = form.Tipo;
                    txtNombreCliente.Enabled = false;
                    txtBuscarProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    if(string.IsNullOrEmpty(txtNombreCliente.Text))
                    {
                        this.IdCliente = 1;
                        txtNombreCliente.Text = "Consumidor Final";
                    }
                }
                else
                {
                    if (this.IdCliente > 1)
                    {
                        this.IdCliente = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnBuscarFacturas_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoFacturas();
                form.buscarTodo = true;
                form.ShowDialog();
                this.IdFactura = form.IdFactura;
                this.IdCliente = form.IdCliente;
                this.IdCotizacion = form.IdCotizacion;
                var tblCliente = new TblCliente();
                var get = new _Cliente_get();
                tblCliente = get.GetById(this.IdCliente);
                if(tblCliente != null)
                {
                    TipoCliente = tblCliente.Tipo;
                }
                if (this.IdFactura > 0)
                {
                    Limpiar2();
                    //Cargar los valores extraidos de la busqueda de la factura o cotizacion:
                    btnEditarFactura.Enabled = true;

                    txtNombreCliente.Text = form.Nombre;
                    txtFecha.Value = form.Fecha;
                    txtNota.Text = form.Nota;
                    txtNombreCliente.Enabled = false;
                    txtNota.Enabled = false;
                    txtBuscarProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    txtPrecio.Enabled = false;
                    txtCondicionPago.Enabled = false;
                    btnFacturar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnImprimir.Enabled = true;
                    btnBuscarFacturas.Enabled = false;
                    btnBuscarClientes.Enabled = false;
                    
                    //Cargar los articulos facturados o cotizados al Grid:
                    txtNoFactura.Text = "FT-" + form.Codigo.ToString();
                    txtCondicionPago.Text = form.CondicionPago;
  
                    var MiConexion = new Conexion();
                    var builder = new StringBuilder();
                    var dt = new DataTable();
                    builder.Append("SELECT IdFacturaDetalle, IdFactura, TblFacturaDetalle.IdProducto, TblProducto.Codigo, TblProducto.Nombre, CantidadFacturada, PrecioFacturado, MontoFacturado, Ganancia FROM TblFacturaDetalle JOIN TblProducto on TblProducto.IdProducto =  TblFacturaDetalle.IdProducto WHERE IdFactura = '" + this.IdFactura + "'");
                    dt = MiConexion.BuscarTabla(builder);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            dgv.Rows.Add(item["IdProducto"].ToString(), item["Codigo"].ToString(), item["Nombre"].ToString(), item["CantidadFacturada"].ToString(), item["PrecioFacturado"].ToString(), item["MontoFacturado"].ToString(), item["Ganancia"].ToString());
                        }
                    }
                    dgv.ClearSelection();
                }
                else if (this.IdCotizacion > 0)
                {
                    Limpiar2();
                    btnBuscarClientes.Enabled = true;
                    txtNoFactura.Text = "CT-" + form.Codigo.ToString();
                    txtCondicionPago.SelectedIndex = 0;
                    //Cargar los valores extraidos de la busqueda de la factura o cotizacion:
                    txtNombreCliente.Text = tblCliente.Nombre;
                    txtFecha.Value = form.Fecha;
                    txtNota.Text = form.Nota;

                    var MiConexion = new Conexion();
                    var builder = new StringBuilder();
                    var dt = new DataTable();
                    builder.Append("SELECT IdCotizacionDetalle, IdCotizacion, TblCotizacionDetalle.IdProducto, TblProducto.Codigo, TblProducto.Nombre, CantidadCotizada, PrecioCotizado, MontoCotizado, ItbisCotizado, Ganancia FROM TblCotizacionDetalle JOIN TblProducto on TblProducto.IdProducto =  TblCotizacionDetalle.IdProducto WHERE IdCotizacion = '" + this.IdCotizacion + "'");
                    dt = MiConexion.BuscarTabla(builder);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            dgv.Rows.Add(item["IdProducto"].ToString(), item["Codigo"].ToString(), item["Nombre"].ToString(), item["CantidadCotizada"].ToString(), item["PrecioCotizado"].ToString(), item["MontoCotizado"].ToString(), item["Ganancia"].ToString());
                        }
                    }
                    dgv.ClearSelection();
                }
                //Sumar los montos de la lista:
                SumarMontos();               
                txtBuscarProducto.Focus();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBuscarProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.IdFactura > 0)
                {
                    return;
                }
                if (e.RowIndex >= 0)
                {
                    //Obtener fila:
                    obtener_num_fila = this.dgv.CurrentRow.Index;
                    dgvIndexSelecionado = true;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtPrecio_Validated(object sender, EventArgs e)
        {
            try
            {
                if (this.IdProducto > 0)
                {
                    decimal precio = 0;
                    decimal.TryParse(txtPrecio.Text, out precio);
                    txtPrecio.Text = precio.ToString("#,###.00;-#,###.00;0.00");
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnCerrarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Realmente desea ir al cierre de Caja?", "Facturar Compra", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                Limpiar();
                var form = new FormCierreCaja();
                this.Close();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormFacturacion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyData == Keys.F1)
                {
                    Limpiar();
                }
                if (e.KeyData == Keys.F2 && this.IdFactura == 0)
                {
                    Editar();
                }
                if (e.KeyData == Keys.F3 && this.IdFactura == 0)
                {
                    Eliminar();
                }
                if (e.KeyData == Keys.F4)
                {
                    Cotizar();
                }
                if (e.KeyData == Keys.F5 && this.IdFactura == 0)
                {
                    Facturar();
                }
                if (e.KeyData == Keys.F6)
                {
                    if (this.IdFactura > 0)
                    {
                        var form = new FormModoImpresion();
                        form.factura = true;
                        form.ShowDialog();
                        if (!string.IsNullOrEmpty(form.modoImpresion))
                        {
                            ImprimirFactura(form.modoImpresion);
                        }
                    }
                    if (this.IdCotizacion > 0)
                    {
                        ImprimirCotizacion();
                    }
                }
                if (e.KeyData == Keys.F7)
                {
                    try
                    {
                        var form = new FormCxC();
                        form.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        AVISOW(ex.ToString());
                    }
                }
                if (e.KeyData == Keys.F12)
                {
                    try
                    {
                        DialogResult result = new DialogResult();
                        result = MessageBox.Show("Realmente desea ir al cierre de Caja?", "Facturar Compra", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                        Limpiar();
                        var form = new FormCierreCaja();
                        form.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        AVISOW(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDescriccion.Text))
                {
                    this.IdProducto = 0;
                    this.CodigoProducto = 0;
                    txtDescriccion.Text = string.Empty;
                    txtPM.Text = string.Empty;
                    txtPrecio.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnAgregarListRap_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoProductos();
                form.ShowDialog();
                if (form.Id > 0)
                {
                    var objeto = new TblListaRapida();
                    var get = new _ListaRapida_get();
                    if(!get.Validar(form.Id))
                    {
                        objeto.IdProducto = form.Id;
                        objeto.Descripcion = form.descripcion;
                        _ListaRapida.Save(objeto);
                        GetListaRapida();
                    }
                    else
                    {
                        AVISOW("El Producto ya esta registrado en la lista.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnElimProdLista_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormListaRapida();
                form.ShowDialog();
                GetListaRapida();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnCxC_Click(object sender, EventArgs e)
        {
            try
            {
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 2) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormCxC();
                    form.ShowDialog();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.IdFactura > 0)
                {
                    var form = new FormModoImpresion();
                    form.factura = true;
                    form.ShowDialog();
                    if (!string.IsNullOrEmpty(form.modoImpresion))
                    {
                        ImprimirFactura(form.modoImpresion);
                    }
                }
                if (this.IdCotizacion > 0)
                {
                    ImprimirCotizacion();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if(this.IdFactura > 0)
                {
                    return;
                }
                Editar();
                txtCantidad.Focus();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }


        private void btnEditarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.IdFactura > 0)
                {
                    var tblFact = new TblFactura();
                    var getFact = new _Factura_get();
                    tblFact = getFact.GetById(this.IdFactura);
                    if (tblFact.IdCajaApertura != ClaseGetCuenta.GetIdCajaApertura())
                    {
                        AVISOI("No se puede modificar una factura que haya sido elaborada en otra apertura de caja.");
                        return;
                    }
                    txtNota.Enabled = true;
                    txtBuscarProducto.Enabled = true;
                    txtCantidad.Enabled = true;
                    txtPrecio.Enabled = true;
                    txtCondicionPago.Enabled = true;
                    btnFacturar.Enabled = true;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnBuscarFacturas.Enabled = true;
                    btnBuscarClientes.Enabled = true;
                    dgv.Enabled = true;
                    btnCxC.Enabled = false;
                    btnEditarFactura.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
