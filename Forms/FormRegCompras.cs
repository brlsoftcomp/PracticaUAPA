using BRL_SVentas.Catalogos;
using BRL_SVentas.Model;
using BRL_SVentas.Servicios;
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

namespace BRL_SVentas.Forms
{
    public partial class FormRegCompras : Form
    {

        private int IdProveedor = 0;
        private int IdCompra = 0;
        private int IdProducto = 0;
        private int IdFormaPago = 0;
        private int CodigoProducto = 0;


        private decimal Total = 0;
        private decimal Itbis = 0;
        private decimal SubTotal = 0;
        private int obtener_num_fila = 0;
        private bool dgvIndexSelecionado = false;
        private bool add_to_edit = false;//Indica cuando un articulo se extrae de la lista para editar si es true y false para registrar como nuevo.
        private bool btnEdit = false;
        public FormRegCompras()
        {
            InitializeComponent();
            this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
        }

        private void FormRegCompras_Load(object sender, EventArgs e)
        {

        }

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
        private void Limpiar()
        {
            this.IdProveedor = 0;
            this.IdCompra = 0;
            this.IdFormaPago = 0;
            this.IdProducto = 0;
            dgv.Rows.Clear();
            txtFecha.Value = DateTime.Now;
            txtNoFactura.Text = string.Empty;
            txtBuscarProducto.Text = string.Empty;
            txtDescriccion.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtItbis.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtNota.Text = string.Empty;
            txtNota.Enabled = true;
            btnEdit = false;
            DesBloquear();
        }
        #endregion

        #region Bloquear
        private void Bloquear()
        {
            try
            {
                dgv.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = false;
                txtFecha.Enabled = false;
                txtNoFactura.Enabled = false;
                txtSubTotal.Enabled = false;
                txtItbis.Enabled = false;
                txtTotal.Enabled = false;

                txtBuscarProducto.Enabled = false;
                txtCantidad.Enabled = false;
                txtNota.Enabled = false;
                btnBuscarClientes.Enabled = false;
                btnBuscarFacturas.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region DesBloquear
        private void DesBloquear()
        {
            try
            {
                dgv.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnGuardar.Enabled = true;
                txtFecha.Enabled = true;
                txtNoFactura.Enabled = true;
                txtSubTotal.Enabled = true;
                txtItbis.Enabled = true;
                txtTotal.Enabled = true;

                txtBuscarProducto.Enabled = true;
                txtCantidad.Enabled = true;
                txtNota.Enabled = true;
                btnBuscarClientes.Enabled = true;
                btnBuscarFacturas.Enabled = true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region GUARDAR
        private void Guardar(decimal montoCaja)
        {
            try
            {
                var tbl = new TblCompra();
                int valorInt = 0;
                decimal valorDecimal = 0;

                tbl.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                tbl.IdProveedor = this.IdProveedor;
                tbl.IdFormaPago = this.IdFormaPago;
                tbl.Fecha = DateTime.Now;
                int.TryParse(txtNoFactura.Text, out valorInt);
                tbl.NoFactura = valorInt;
                decimal.TryParse(txtItbis.Text, out valorDecimal);
                tbl.Itbis = valorDecimal;
                decimal.TryParse(txtSubTotal.Text, out valorDecimal);
                tbl.SubTotal = valorDecimal;
                decimal.TryParse(txtTotal.Text, out valorDecimal);
                tbl.Total = valorDecimal;
                tbl.Nota = txtNota.Text;
                this.IdCompra = _Compra.SaveXML(tbl);
                if (this.IdCompra > 0)
                {
                    var tblDetalle = new TblCompraDetalle();
                    var tblProducto = new TblProducto();
                    var tblControlAlmacen = new TblControlAlmacen();
                    var get = new _Producto_get();
                    foreach (DataGridViewRow dgv in dgv.Rows)
                    {
                        //GET PRODUCTO:
                        int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);
                        tblProducto = get.GetById(valorInt);

                        tblDetalle.IdCompra = this.IdCompra;
                        int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);
                        tblDetalle.IdProducto = valorInt;
                        int.TryParse(dgv.Cells[3].Value.ToString(), out valorInt);
                        tblDetalle.Cantidad = valorInt;

                        tblDetalle.Itbis = tblProducto.Itbis * valorInt;
                        decimal.TryParse(dgv.Cells[4].Value.ToString(), out valorDecimal);
                        tblDetalle.Precio = valorDecimal;
                        decimal.TryParse(dgv.Cells[5].Value.ToString(), out valorDecimal);
                        tblDetalle.Monto = valorDecimal;
                        _CompraDetalle.Save(tblDetalle);

                        //ACTUALIZAR LA CANTIDAD EXISTENTE DEL PRODUCTO:
                        int.TryParse(dgv.Cells[3].Value.ToString(), out valorInt);
                        if(valorInt == 0)
                        {
                            AVISOW("El valor a descontar del inventario es 0.");
                        }
                        tblProducto.CantidadExistente += valorInt;
                        tblProducto.Estado = "ACTIVO";
                        _Productos.Update(tblProducto);

                        //REGISTRAR EL CONTROL DE ALMACEN:
                        tblControlAlmacen.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                        tblControlAlmacen.IdRegistro = this.IdCompra;
                        int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);
                        tblControlAlmacen.IdProducto = valorInt;
                        tblControlAlmacen.Descripcion = tblProducto.Nombre;
                        tblControlAlmacen.Modulo = "COMPRA";
                        tblControlAlmacen.Movimiento = "ENTRADA";
                        int.TryParse(dgv.Cells[3].Value.ToString(), out valorInt);
                        tblControlAlmacen.Cantidad = valorInt;
                        tblControlAlmacen.Fecha = DateTime.Now;
                        _ControlAlmacen.Save(tblControlAlmacen);
                    }
                    //Registrar en Movimeinto de Caja:
                    if (montoCaja > 0)
                    {
                        var tblCaja = new TblCaja();
                        tblCaja.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                        tblCaja.Fecha = DateTime.Now;
                        tblCaja.Registro = this.IdCompra;
                        tblCaja.Modulo = "COMPRAS";
                        tblCaja.Monto = montoCaja;
                        tblCaja.Caja = "#1";
                        tblCaja.Estado = "ABIERTA";
                        int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out valorInt);
                        tblCaja.IdCajaApertura = valorInt;
                        _Caja.Save(tblCaja);
                    }
                    AVISOI("DATOS GUARDADOS.");
                }
                if (this.IdCompra == 0)
                {
                    AVISOW("ERROR AL GUARDAR LOS DATOS.");
                    return;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region EditarCompra
        private void EditarCompra()
        {
            try
            {
                var tblComp = new TblCompra();
                var getComp = new _Compra_get();
                tblComp = getComp.GetById(this.IdCompra);

                //========COBRAR COMPRA=========//
                int valorInt = 0;
                decimal valorDecimal = 0;
                decimal.TryParse(txtTotal.Text, out valorDecimal);
                var form = new FormPagoCompra();
                form.montoFactura = valorDecimal;
                form.txtEfectivoOtros.Focus();
                form.ShowDialog();
                if (!form.pagado)
                {
                    return;
                }

                //========REGISTRAR COMPRA=========//
                var tbl = new TblCompra();
                tbl.IdCompra = this.IdCompra;
                tbl.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                tbl.IdProveedor = this.IdProveedor;
                tbl.IdFormaPago = this.IdFormaPago;
                tbl.Fecha = DateTime.Now;
                int.TryParse(txtNoFactura.Text, out valorInt);
                tbl.NoFactura = valorInt;
                decimal.TryParse(txtItbis.Text, out valorDecimal);
                tbl.Itbis = valorDecimal;
                decimal.TryParse(txtSubTotal.Text, out valorDecimal);
                tbl.SubTotal = valorDecimal;
                decimal.TryParse(txtTotal.Text, out valorDecimal);
                tbl.Total = valorDecimal;
                tbl.Nota = txtNota.Text;
                this.IdCompra = _Compra.SaveXML(tbl);

                //========ELIMINAR DETALLE COMPRA===========//
                var tblCompraDetalle = new TblCompraDetalle();
                var tblCompraDetalleDelete = new List<TblCompraDetalle>();
                var tblProducto = new TblProducto();
                var tblControlAlmacen = new TblControlAlmacen();
                var get = new _Producto_get();
                var getDetalleCompra = new _CompraDetalle_get();
                tblCompraDetalleDelete = getDetalleCompra.GetByIdCompra(this.IdCompra);

                foreach (var item in tblCompraDetalleDelete)
                {
                    //ACTUALIZAR LA CANTIDAD EXISTENTE DEL PRODUCTO:
                    tblProducto = get.GetById(item.IdProducto);
                    tblProducto.CantidadExistente -= item.Cantidad;
                    _Productos.Update(tblProducto);

                    //=====REGISTRAR EL CONTROL DE ALMACEN======//
                    tblControlAlmacen.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                    tblControlAlmacen.IdRegistro = this.IdCompra;
                    tblControlAlmacen.IdProducto = item.IdProducto;
                    tblControlAlmacen.Descripcion = tblProducto.Nombre;
                    tblControlAlmacen.Modulo = "COMPRA-MODIFICACION";
                    tblControlAlmacen.Movimiento = "SALIDA";
                    tblControlAlmacen.Cantidad = item.Cantidad;
                    tblControlAlmacen.Fecha = DateTime.Now;
                    _ControlAlmacen.Save(tblControlAlmacen);
                }
                _CompraDetalle.DeleteByIdCompra(this.IdCompra);//Eliminar detalle.


                //========REGISTRAR DETALLE FACTURA===========//
                tblProducto = new TblProducto();
                foreach (DataGridViewRow dgv in dgv.Rows)
                {
                    //GET PRODUCTO:
                    int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);
                    tblProducto = get.GetById(valorInt);

                    tblCompraDetalle.IdCompra = this.IdCompra;
                    int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);
                    tblCompraDetalle.IdProducto = valorInt;
                    int.TryParse(dgv.Cells[3].Value.ToString(), out valorInt);
                    tblCompraDetalle.Cantidad = valorInt;
                    decimal.TryParse(dgv.Cells[4].Value.ToString(), out valorDecimal);
                    tblCompraDetalle.Precio = valorDecimal;
                    tblCompraDetalle.Itbis = ((valorDecimal - (valorDecimal / (1 + (tblProducto.Itbis / 100)))) * valorInt);
                    decimal.TryParse(dgv.Cells[5].Value.ToString(), out valorDecimal);
                    tblCompraDetalle.Monto = valorDecimal;
                    _CompraDetalle.Save(tblCompraDetalle);

                    //ACTUALIZAR LA CANTIDAD EXISTENTE DEL PRODUCTO:
                    int.TryParse(dgv.Cells[3].Value.ToString(), out valorInt);
                    tblProducto.CantidadExistente -= valorInt;
                    _Productos.Update(tblProducto);

                    //=====REGISTRAR EL CONTROL DE ALMACEN======//
                    tblControlAlmacen.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                    tblControlAlmacen.IdRegistro = this.IdCompra;
                    int.TryParse(dgv.Cells[0].Value.ToString(), out valorInt);
                    tblControlAlmacen.IdProducto = valorInt;
                    tblControlAlmacen.Descripcion = tblProducto.Nombre;
                    tblControlAlmacen.Modulo = "COMPRAS";
                    tblControlAlmacen.Movimiento = "ENTRADA";
                    int.TryParse(dgv.Cells[3].Value.ToString(), out valorInt);
                    tblControlAlmacen.Cantidad = valorInt;
                    tblControlAlmacen.Fecha = DateTime.Now;
                    _ControlAlmacen.Save(tblControlAlmacen);
                }

                //===========ELIMINAR FORMA PAGO===========//
                if (tblComp.IdFormaPago > 0)
                {
                    _FormaPago.Delete(tblComp.IdFormaPago);
                }
                //===========REGISTRAR FORMA PAGO===========//
                var tblFormaPago = new TblFormaPago();
                tblFormaPago.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                tblFormaPago.MontoEfectivo = form.MontoEfectivo - form.Devuelta;
                tblFormaPago.MontoTarjeta = form.MontoTarjeta;
                tblFormaPago.MontoCheque = form.MontoCheque;
                tblFormaPago.NoBoucher = form.NoBoucher;
                tblFormaPago.NoCheque = form.NoCheque;
                this.IdFormaPago = _FormaPago.Save(tblFormaPago);

                //===========REGISTRAR CXC===========//
                var tblCaja = new TblCaja();
                var tblCxP = new TblCxP();

                //============REGISTRAR CAJA===========//
                if (form.MontoEfectivo > 0)
                {
                    tblCaja = new TblCaja();
                    tblCaja.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                    tblCaja.Fecha = DateTime.Now;
                    tblCaja.Registro = this.IdCompra;
                    tblCaja.Modulo = "COMPRAS";
                    tblCaja.Monto = form.MontoEfectivo;
                    tblCaja.Caja = "#1";
                    tblCaja.Estado = "ABIERTA";
                    tblCaja.IdCajaApertura = ClaseGetCuenta.GetIdCajaApertura();
                    _Caja.Save(tblCaja);
                }
                Limpiar();
                
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
                    decimal valor = 0;
                    int.TryParse(dgv[0, obtener_num_fila].Value.ToString(), out valorInt);
                    this.IdProducto = valorInt;
                    tbl = get.GetById(valorInt);
                    int.TryParse(dgv[1, obtener_num_fila].Value.ToString(), out valorInt);
                    CodigoProducto = valorInt;
                    txtBuscarProducto.Text = dgv[1, obtener_num_fila].Value.ToString();
                    txtDescriccion.Text = dgv[2, obtener_num_fila].Value.ToString();
                    txtCantidad.Text = dgv[3, obtener_num_fila].Value.ToString();
                    txtPrecio.Text = dgv[4, obtener_num_fila].Value.ToString();

                    //Restar valores del registro antes de sacarlo de la lista:
                    int.TryParse(dgv[3, obtener_num_fila].Value.ToString(), out valorInt);
                    decimal.TryParse(dgv[5, obtener_num_fila].Value.ToString(), out valor);
                    Total -= valor;
                    Itbis -= (tbl.PrecioCompra - (tbl.PrecioCompra / (1 + (tbl.Itbis / 100)))) * valorInt;
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
                    int.TryParse(dgv[0, obtener_num_fila].Value.ToString(), out valorInt);
                    tbl = get.GetById(valorInt);
                    this.IdProducto = valorInt;

                    //Restar valores del registro antes de sacarlo de la lista:
                    int.TryParse(dgv[3, obtener_num_fila].Value.ToString(), out valorInt);
                    Total -= Convert.ToDecimal(dgv[5, obtener_num_fila].Value.ToString());
                    Itbis -= (tbl.PrecioCompra - (tbl.PrecioCompra / (1 + (tbl.Itbis / 100)))) * valorInt;
                    SubTotal = Total - Itbis;

                    txtSubTotal.Text = SubTotal.ToString("#,###.00;-#,###.00;0.00");
                    txtItbis.Text = Itbis.ToString("#,###.00;-#,###.00;0.00");
                    txtTotal.Text = Total.ToString("#,###.00;-#,###.00;0.00");

                    dgv.Rows.RemoveAt(obtener_num_fila);//Eliminar Fila
                    dgv.ClearSelection();
                    dgvIndexSelecionado = false;

                }
                else { MessageBox.Show("No hay registro en esta fila", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region SumarMontos
        private void SumarMontos()
        {
            try
            {
                var tbl = new TblProducto();
                var get = new _Producto_get();
                int id = 0;
                Total = 0;
                Itbis = 0;
                SubTotal = 0;
                int cantidadFact = 0;

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(dgv[5, i].Value.ToString());

                    int.TryParse(dgv[0, i].Value.ToString(), out id);
                    tbl = get.GetById(id);
                    int.TryParse(dgv[3, i].Value.ToString(), out cantidadFact);
                    Itbis += (tbl.PrecioCompra - (tbl.PrecioCompra / (1 + (tbl.Itbis / 100)))) * cantidadFact;
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

        #region EditarProductLista
        private bool EditarProductLista(decimal precio, int cantidad)
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoProveedor();
                form.texto = txtNombre.Text;
                form.ShowDialog();
                this.IdProveedor = form.IdProveedor;
                txtNombre.Text = form.Nombre;
                txtNombre.Enabled = false;
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valor = 0;
                decimal.TryParse(txtTotal.Text, out valor);
                if (string.IsNullOrEmpty(txtNoFactura.Text))
                {
                    AVISOW("El numero de factura es requerido.");
                    return;
                }
                if (this.IdProveedor == 0)
                {
                    AVISOW("El Proveedor es requerido.");
                    return;
                }
                if (valor <= 0)
                {
                    AVISOW("El Monto es requerido.");
                    return;
                }
                if (this.IdProveedor > 0)
                {
                    if(this.IdCompra > 0)
                    {
                        if (this.IdFormaPago > 0)
                        {
                            EditarCompra();
                        }
                    }
                    else
                    {
                        decimal valorDecimal = 0;
                        decimal.TryParse(txtTotal.Text, out valorDecimal);
                        var form = new FormPagoCompra();
                        form.montoFactura = valorDecimal;
                        form.txtEfectivoOtros.Focus();
                        form.ShowDialog();
                        if (form.pagado)
                        {
                            //========REGISTRAR FORMA PAGO===========//
                            var tblFormaPago = new TblFormaPago();
                            tblFormaPago.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                            tblFormaPago.MontoEfectivo = form.MontoEfectivo + form.MontoEfectivoOtro;
                            tblFormaPago.MontoTarjeta = form.MontoTarjeta;
                            tblFormaPago.MontoCheque = form.MontoCheque;
                            tblFormaPago.NoBoucher = form.NoBoucher;
                            tblFormaPago.NoCheque = form.NoCheque;
                            tblFormaPago.Concepto = "PAGO POR COMPRA";
                            this.IdFormaPago = _FormaPago.Save(tblFormaPago);
                            if (this.IdFormaPago == 0)
                            {
                                AVISOW("ERROR AL MOMENTO DE APLICAR EL PAGO DE LA FACTURA..");
                                return;
                            }
                            Guardar(form.MontoEfectivo);
                            Limpiar();
                        }
                    }                    
                }
                else
                {
                    AVISOW("El Proveedor es requerido.");
                    return;
                }
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
                if (IdCompra > 0 && !btnEdit)
                {
                    DesBloquear();
                    btnEdit = true;
                }
                else
                {
                    Editar();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Condiciones para que solo acepte valores numericos:
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    txtNombre.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
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
                    btnGuardar.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoProveedor();
                form.ShowDialog();
                if(form.IdProveedor > 0) 
                {
                    this.IdProveedor = form.IdProveedor;
                    txtNombre.Text = form.Nombre;
                    txtBuscarProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDescriccion.Text))
                {
                    this.IdProducto = 0;
                    this.CodigoProducto = 0;
                    txtDescriccion.Text = string.Empty;
                    txtPrecio.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
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
                //else if (Char.IsWhiteSpace(e.KeyChar))
                //{
                //    e.Handled = false;
                //}
                //else if (Char.IsLetter(e.KeyChar))
                //{
                //    e.Handled = false;
                //}
                else
                {
                    e.Handled = true;
                }
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    if (this.IdProveedor == 0)
                    {
                        AVISOI("Para agregar productos a la lista, primero debe seleccionar el proveedor de la compra.");
                        return;
                    }

                    var tbl = new TblProducto();
                    var get = new _Producto_get();
                    if (string.IsNullOrEmpty(txtBuscarProducto.Text))
                    {
                        this.IdProducto = 0;
                        this.CodigoProducto = 0;
                        var form = new FormCatalogoProductos();
                        form.IdProveedor = this.IdProveedor;
                        form.txtBuscar.Text = txtBuscarProducto.Text;
                        form.ShowDialog();                        
                        if (form.Id > 0)
                        {
                            if (form.IdProveedor != this.IdProveedor)
                            {
                                AVISOI("Los productos a seleccionar deben ser provenientes del proveedor seleccionado.");
                                return;
                            }

                            tbl = get.GetById(form.Id);
                            if (tbl != null)
                            {
                                txtBuscarProducto.Text = form.Id.ToString();
                                this.IdProducto = form.Id;
                                this.CodigoProducto = form.codigo;
                                txtDescriccion.Text = form.descripcion;
                                txtPrecio.Text = tbl.PrecioCompra.ToString("#,###.00;-#,###.00;0.00");
                                if (this.IdProveedor == 0)
                                {
                                    this.IdProveedor = form.IdProveedor;
                                    var tblProveedor = new TblProveedor();
                                    var getProveedor = new _Proveedor_get();
                                    tblProveedor = getProveedor.GetById(this.IdProveedor);
                                    txtNombre.Text = tblProveedor.Nombre;
                                }
                            }
                        }
                        else
                        {
                            this.IdProducto = 0;
                            this.CodigoProducto = 0;
                            txtDescriccion.Text = string.Empty;
                            txtPrecio.Text = string.Empty;
                        }
                    }
                    else
                    {
                        int codigoProducto = 0;
                        int.TryParse(txtBuscarProducto.Text, out codigoProducto);
                        tbl = get.GetByCodigo(codigoProducto);
                        if (tbl != null)
                        {
                            if (tbl.IdProveedor != this.IdProveedor)
                            {
                                AVISOI("Los productos a seleccionar deben ser provenientes del proveedor seleccionado.");
                                return;
                            }
                            txtBuscarProducto.Text = codigoProducto.ToString();
                            this.IdProducto = tbl.IdProducto;
                            this.CodigoProducto = tbl.Codigo;
                            txtDescriccion.Text = tbl.Nombre;
                            txtPrecio.Text = tbl.PrecioCompra.ToString("#,###.00;-#,###.00;0.00");
                            if (this.IdProveedor == 0)
                            {
                                this.IdProveedor = tbl.IdProveedor;
                                var tblProveedor = new TblProveedor();
                                var getProveedor = new _Proveedor_get();
                                tblProveedor = getProveedor.GetById(this.IdProveedor);
                                txtNombre.Text = tblProveedor.Nombre;
                            }
                        }
                        else
                        {
                            AVISOW("Su peticion no a producido resultados.");
                            return;
                        }
                    }

                   // add_to_edit = false;
                    //Enfocar a tb_precio:
                    if (!string.IsNullOrEmpty(txtDescriccion.Text))
                        txtCantidad.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnBuscarFacturas_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoCompras();
                form.ShowDialog();
                if (form.IdCompra > 0)
                {
                    Limpiar();
                    Bloquear();
                    btnEditar.Enabled = true;
                    DateTime fecha = DateTime.Now;
                    var Miconexion = new Conexion();
                    this.IdCompra = form.IdCompra;
                    this.IdProveedor = form.Idproveedor;
                    int valorInt = 0;
                    var dt = new DataTable();
                    var builder = new StringBuilder();
                    builder.Append("SELECT TblCompra.IdFormaPago, TblCompra.Fecha, TblProveedor.RNC, TblProveedor.Nombre, TblCompra.NoFactura, TblCompra.NCF, TblCompra.CondicionCompra, TblCompra.Itbis, TblCompra.SubTotal, TblCompra.Total FROM TblCompra");
                    builder.Append(" INNER JOIN dbo.TblProveedor ON TblProveedor.IdProveedor = TblCompra.IdProveedor");
                    builder.Append(" WHERE IdCompra = '" + this.IdCompra + "'");
                    dt = Miconexion.BuscarTabla(builder);
                    foreach (DataRow item in dt.Rows)
                    {
                        
                        int.TryParse(item["IdFormaPago"].ToString(), out valorInt);
                        this.IdFormaPago = valorInt;
                        DateTime.TryParse(item["Fecha"].ToString(), out fecha);
                        txtFecha.Value = fecha;
                        txtNoFactura.Text = item["NoFactura"].ToString();
                        txtNombre.Text = item["Nombre"].ToString();
                        txtSubTotal.Text = item["SubTotal"].ToString();
                        txtItbis.Text = item["Itbis"].ToString();
                        txtTotal.Text = item["Total"].ToString();
                    }
                    dt = new DataTable();
                    builder = new StringBuilder();
                    builder.Append("SELECT TblCompraDetalle.IdProducto, TblCompraDetalle.Cantidad, TblProducto.Codigo, TblProducto.Nombre, TblCompraDetalle.Precio, TblCompraDetalle.Monto FROM TblCompraDetalle");
                    builder.Append(" INNER JOIN dbo.TblProducto ON TblProducto.IdProducto = TblCompraDetalle.IdProducto");
                    builder.Append(" WHERE IdCompra = '" + this.IdCompra + "'");
                    dt = Miconexion.BuscarTabla(builder);
                    foreach (DataRow item in dt.Rows)
                    {
                        dgv.Rows.Add(item["IdProducto"].ToString(), item["Codigo"].ToString(), item["Nombre"].ToString(), item["Cantidad"].ToString(), item["Precio"].ToString(), item["Monto"].ToString());
                    }
                    SumarMontos();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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
                    tblProducto = get.GetById(this.IdProducto);
                    decimal precio = 0;
                    decimal.TryParse(txtPrecio.Text, out precio);
                    int cantidad = Int32.Parse(txtCantidad.Text);

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
                    //AGREGADO DE ARTICULO A LA LISTA DE LA FACTURA:
                    if (!EditarProductLista(precio, cantidad))//Si el articula no esta en lista, proceder a anadir el articulo a la lista del Grid.
                    {
                        dgv.Rows.Add(this.IdProducto.ToString(), this.CodigoProducto.ToString(), txtDescriccion.Text, txtCantidad.Text, txtPrecio.Text, precio * cantidad);
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
                    txtPrecio.Clear();
                    add_to_edit = false;
                    dgv.Refresh();

                    //Sumar los montos de la lista:
                    SumarMontos();

                    //Enfocar al texbox de busqueda:
                    txtBuscarProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
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

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Obtener fila:
                obtener_num_fila = this.dgv.CurrentRow.Index;
                dgvIndexSelecionado = true;
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
                Editar();
                txtCantidad.Focus();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void MoveFocus(object sender, KeyPressEventArgs e)
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
                else if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            try
            {
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 8) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormRegProducto();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormRegCompras_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F5)
                {
                    Limpiar();
                }
                if (e.KeyData == Keys.F6)
                {
                    if (IdCompra > 0 && !btnEdit)
                    {
                        DesBloquear();
                        btnEdit = true;
                    }
                    else
                    {
                        Editar();
                    }
                }
                if (e.KeyData == Keys.F7)
                {
                    Eliminar();
                }
                if (e.KeyData == Keys.F8)
                {
                    decimal valor = 0;
                    decimal.TryParse(txtTotal.Text, out valor);
                    if (string.IsNullOrEmpty(txtNoFactura.Text))
                    {
                        AVISOW("El numero de factura es requerido.");
                        return;
                    }
                    if (this.IdProveedor == 0)
                    {
                        AVISOW("El Proveedor es requerido.");
                        return;
                    }
                    if (valor <= 0)
                    {
                        AVISOW("El Monto es requerido.");
                        return;
                    }
                    if (this.IdProveedor > 0)
                    {
                        if (this.IdCompra > 0)
                        {
                            if (this.IdFormaPago > 0)
                            {
                                EditarCompra();
                            }
                        }
                        else
                        {
                            decimal valorDecimal = 0;
                            decimal.TryParse(txtTotal.Text, out valorDecimal);
                            var form = new FormPagoCompra();
                            form.montoFactura = valorDecimal;
                            form.txtEfectivoOtros.Focus();
                            form.ShowDialog();
                            if (form.pagado)
                            {
                                //========REGISTRAR FORMA PAGO===========//
                                var tblFormaPago = new TblFormaPago();
                                tblFormaPago.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                                tblFormaPago.MontoEfectivo = form.MontoEfectivo + form.MontoEfectivoOtro;
                                tblFormaPago.MontoTarjeta = form.MontoTarjeta;
                                tblFormaPago.MontoCheque = form.MontoCheque;
                                tblFormaPago.NoBoucher = form.NoBoucher;
                                tblFormaPago.NoCheque = form.NoCheque;
                                tblFormaPago.Concepto = "PAGO POR COMPRA";
                                this.IdFormaPago = _FormaPago.Save(tblFormaPago);
                                if (this.IdFormaPago == 0)
                                {
                                    AVISOW("ERROR AL MOMENTO DE APLICAR EL PAGO DE LA FACTURA..");
                                    return;
                                }
                                Guardar(form.MontoEfectivo);
                                Limpiar();
                            }
                        }
                    }
                    else
                    {
                        AVISOW("El Proveedor es requerido.");
                        return;
                    }
                }
                if (e.KeyData == Keys.F9)
                {
                    var getPermiso = new _UsuarioPermiso_get();
                    if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 8) || ClaseGetCuenta.GetIdUsuario() == 1)
                    {
                        var form = new FormRegProducto();
                        form.Show();
                    }
                    else
                    {
                        AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtNCF_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
