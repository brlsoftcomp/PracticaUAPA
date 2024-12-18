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
    public partial class FormRegGastos : Form
    {

        private int IdProveedor = 0;
        private int IdGasto = 0;
        private int IdUsuario = 0;

        private int IdFormaPago = 0;

        public FormRegGastos()
        {
            InitializeComponent();
            this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
        }

        private void FormRegGastos_Load(object sender, EventArgs e)
        {
            try
            {
                txtConcepto.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
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

        #region Desbloquear
        private void Desbloquear()
        {
            try
            {
                txtNota.ReadOnly = false;
                btnEditar.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Limpiar
        private void Limpiar()
        {
            this.IdProveedor = 0;
            this.IdGasto = 0;
            IdUsuario = 0;
            this.IdFormaPago = 0;
            txtFecha.Value = DateTime.Now;
            txtCodigoGasto.Text = string.Empty;
            txtNCF.Text = "B0100000000";
            txtNombre.Text = string.Empty;
            txtRnc.Text = string.Empty;
            txtItbis.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtNota.Text = string.Empty;
            txtNota.Enabled = true;
            txtConcepto.SelectedIndex = 0;
            DesBloquear();
        }
        #endregion

        #region Bloquear
        private void Bloquear()
        {
            try
            {
                btnEditar.Enabled = false;
                btnGuardar.Enabled = false;
                txtFecha.Enabled = false;
                txtCodigoGasto.Enabled = false;
                txtNCF.Enabled = false;
                txtSubTotal.Enabled = false;
                txtItbis.Enabled = false;
                txtTotal.Enabled = false;
                txtNota.Enabled = false;
                btnBuscarProveedor.Enabled = false;
                btnBuscarRegistro.Enabled = false;
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
                
                btnEditar.Enabled = true;
                btnGuardar.Enabled = true;
                txtFecha.Enabled = true;
                txtCodigoGasto.Enabled = true;
                txtNCF.Enabled = true;
                txtSubTotal.Enabled = true;
                txtItbis.Enabled = true;
                txtTotal.Enabled = true;
                txtNota.Enabled = true;
                btnBuscarProveedor.Enabled = true;
                btnBuscarRegistro.Enabled = true;
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
                var tbl = new TblGasto();
                int valorInt = 0;
                decimal valorDecimal = 0;

                tbl.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                tbl.IdProveedor = this.IdProveedor;
                tbl.IdFormaPago = this.IdFormaPago;
                tbl.Fecha = DateTime.Now;
                int.TryParse(txtCodigoGasto.Text, out valorInt);
                tbl.NoFactura = valorInt;
                tbl.NCF = txtNCF.Text;
                tbl.Concepto = txtConcepto.Text;
                decimal.TryParse(txtItbis.Text, out valorDecimal);
                tbl.Itbis = valorDecimal;
                decimal.TryParse(txtSubTotal.Text, out valorDecimal);
                tbl.SubTotal = valorDecimal;
                decimal.TryParse(txtTotal.Text, out valorDecimal);
                tbl.Monto = valorDecimal;
                tbl.Nota = txtNota.Text;
                this.IdGasto = _Gasto.Save(tbl);
                if (this.IdGasto > 0)
                {
                    //Registrar en Movimeinto de Caja:
                    if (montoCaja > 0)
                    {
                        var tblCaja = new TblCaja();
                        tblCaja.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                        tblCaja.Fecha = DateTime.Now;
                        tblCaja.Registro = this.IdGasto;
                        tblCaja.Modulo = "GASTOS";
                        tblCaja.Monto = montoCaja;
                        tblCaja.Caja = "#1";
                        tblCaja.Estado = "ABIERTA";
                        int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out valorInt);
                        tblCaja.IdCajaApertura = valorInt;
                        _Caja.Save(tblCaja);
                    }
                    AVISOI("DATOS GUARDADOS.");
                }
                if (this.IdGasto == 0)
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

        #region Editar
        private void Editar(decimal montoCaja)
        {
            try
            {
                var tbl = new TblGasto();
                int valorInt = 0;
                decimal valorDecimal = 0;
                tbl.IdGasto = this.IdGasto;
                tbl.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                tbl.IdProveedor = this.IdProveedor;
                tbl.IdFormaPago = this.IdFormaPago;
                tbl.Fecha = DateTime.Now;
                int.TryParse(txtCodigoGasto.Text, out valorInt);
                tbl.NoFactura = valorInt;
                tbl.NCF = txtNCF.Text;
                tbl.Concepto = txtConcepto.Text;
                decimal.TryParse(txtItbis.Text, out valorDecimal);
                tbl.Itbis = valorDecimal;
                decimal.TryParse(txtSubTotal.Text, out valorDecimal);
                tbl.SubTotal = valorDecimal;
                decimal.TryParse(txtTotal.Text, out valorDecimal);
                tbl.Monto = valorDecimal;
                tbl.Nota = txtNota.Text;
                _Gasto.Update(tbl);
                if (this.IdGasto > 0)
                {
                    
                    //Registrar en Movimeinto de Caja:
                    if (montoCaja > 0)
                    {
                        var tblCaja = new TblCaja();
                        var get = new _Caja_get();
                        tblCaja = get.GetByIdRegModulo(this.IdGasto, "GASTOS");
                        tblCaja.Monto = montoCaja;
                        _Caja.Save(tblCaja);
                    }
                    AVISOI("DATOS GUARDADOS.");
                }
                if (this.IdGasto == 0)
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoProveedor();
                form.ShowDialog();
                if (form.IdProveedor > 0)
                {
                    this.IdProveedor = form.IdProveedor;
                    txtNombre.Text = form.Nombre;
                    txtNombre.Enabled = false;
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valor = 0;
                decimal.TryParse(txtTotal.Text, out valor);
                if (txtConcepto.SelectedIndex == 0)
                {
                    AVISOW("El concepto es requerido.");
                    return;
                }
                if (string.IsNullOrEmpty(txtNoFactura.Text))
                {
                    AVISOW("El numero de factura es requerido.");
                    return;
                }
                if (string.IsNullOrEmpty(txtSubTotal.Text))
                {
                    AVISOW("El subtotal es requerido.");
                    return;
                }
                if (string.IsNullOrEmpty(txtItbis.Text))
                {
                    AVISOW("El itbis es requerido.");
                    return;
                }
                if (string.IsNullOrEmpty(txtSubTotal.Text))
                {
                    AVISOW("El total es requerido.");
                    return;
                }
                if (this.IdProveedor == 0)
                {
                    AVISOW("El Proveedor es requerido.");
                    return;
                }
                if (!string.IsNullOrEmpty(txtNCF.Text))
                {
                    //validando el NCF
                    if (txtNCF.Text.Length != 11 && txtNCF.Text.Length != 13)
                    {
                        MessageBox.Show("El NCF no es valido.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //txtNCF.Text = string.Empty;
                        txtNCF.Focus();
                        return;
                    }
                }
                if (valor <= 0)
                {
                    AVISOW("El Monto es requerido.");
                    return;
                }
                if (this.IdProveedor > 0)
                {
                    if (this.IdGasto > 0)
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
                            tblFormaPago.Concepto = "PAGO POR GASTOS";
                            this.IdFormaPago = _FormaPago.Save(tblFormaPago);
                            if (this.IdFormaPago == 0)
                            {
                                AVISOW("ERROR AL MOMENTO DE APLICAR EL PAGO DE LA FACTURA..");
                                return;
                            }
                            Editar(form.MontoEfectivo);
                            Limpiar();
                        }
                    }
                    else
                    {
                        decimal valorDecimal = 0;
                        decimal.TryParse(txtTotal.Text, out valorDecimal);
                        var form = new FormPagoCompra();
                        //if (txtCondicionPago.SelectedIndex == 1)
                        //{
                        //    form.acredito = true;
                        //}
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
                            tblFormaPago.Concepto = "PAGO POR GASTOS";
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
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnBuscarGastos_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoGasto();
                form.ShowDialog();
                if (form.IdGasto > 0)
                {
                    var tbl = new TblGasto();
                    var get = new _Gasto_get();
                    tbl = get.GetById(form.IdGasto);
                    this.IdGasto = form.IdGasto;
                    this.IdProveedor = form.IdProveedor;
                    txtCodigoGasto.Text = form.Codigo.ToString();
                    txtNombre.Text = form.Proveedor;
                    txtConcepto.Text = form.Concepto;
                    txtTotal.Text = form.Monto.ToString();
                    txtNota.Text = tbl.Nota;
                    txtNombre.Enabled = false;
                    txtConcepto.Enabled = false;
                    txtTotal.Enabled = false;
                    txtTotal.Enabled = false;
                    txtNota.ReadOnly = true;
                    btnEditar.Enabled = true;
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
                Desbloquear();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtMonto_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal monto = 0;
                //decimal.TryParse(txtMonto.Text, out monto);
                //txtMonto.Text = monto.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtBuscarGastos_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Condiciones para que solo acepte valores numericos:
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    //txtBuscar.Focus();
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

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Condiciones para que solo acepte valores numericos:
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    txtConcepto.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtConsepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Condiciones para que solo acepte valores numericos:
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    //txtMonto.Focus();
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
                    //txtMontoCaja.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormRegGastos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F5)
                {
                    Limpiar();
                }
                if (e.KeyData == Keys.F6)
                {
                    Desbloquear();
                }
                if (e.KeyData == Keys.F8)
                {
                    if (string.IsNullOrEmpty(txtNombre.Text))
                    {
                        AVISOW("El Proveedor es requerido.");
                        return;
                    }
                    if (string.IsNullOrEmpty(txtConcepto.Text))
                    {
                        AVISOW("El Concepto es requerido.");
                        return;
                    }
                    decimal valor = 0;
                    decimal.TryParse(txtTotal.Text, out valor);
                    if (valor <= 0)
                    {
                        AVISOW("El Monto es requerido.");
                        return;
                    }
                    Guardar(0);
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtMontoCaja_KeyPress(object sender, KeyPressEventArgs e)
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


        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoProveedor();
                form.ShowDialog();
                if (form.IdProveedor > 0)
                {
                    this.IdProveedor = form.IdProveedor;
                    txtNombre.Text = form.Nombre;
                    txtRnc.Text = form.RNC;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnBuscarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoGasto();
                form.ShowDialog();
                if (form.IdGasto > 0)
                {
                    this.IdGasto = form.IdGasto;
                    this.IdProveedor = form.IdProveedor;
                    txtNombre.Text = form.Proveedor;
                    txtRnc.Text = form.RNC.ToString();
                    txtNCF.Text = form.NCF;
                    txtConcepto.Text = form.Concepto;
                    txtSubTotal.Text = form.SubTotal.ToString("#,###.00;-#,###.00;0.00");
                    txtItbis.Text = form.Itbis.ToString("#,###.00;-#,###.00;0.00");
                    txtTotal.Text = form.Monto.ToString("#,###.00;-#,###.00;0.00");
                    txtNoFactura.Text = form.NoFactura.ToString();

                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
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
                if (!string.IsNullOrEmpty(txtNCF.Text))
                {
                    //validando el NCF
                    if (txtNCF.Text.Length != 11 && txtNCF.Text.Length != 13)
                    {
                        MessageBox.Show("El NCF no es valido.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //txtNCF.Text = string.Empty;
                        txtNCF.Focus();
                        return;
                    }
                }
                if (valor <= 0)
                {
                    AVISOW("El Monto es requerido.");
                    return;
                }
                if (this.IdProveedor > 0)
                {
                    if (this.IdGasto > 0)
                    {
                        if (this.IdFormaPago > 0)
                        {
                            //EditarCompra();
                        }
                    }
                    else
                    {
                        decimal valorDecimal = 0;
                        decimal.TryParse(txtTotal.Text, out valorDecimal);
                        var form = new FormPagoCompra();
                        //if (txtCondicionPago.SelectedIndex == 1)
                        //{
                        //    form.acredito = true;
                        //
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
                            tblFormaPago.Concepto = "PAGO POR GASTOS";
                            _FormaPago.Delete(this.IdFormaPago);
                            this.IdFormaPago = _FormaPago.Save(tblFormaPago);
                            if (this.IdFormaPago == 0)
                            {
                                AVISOW("ERROR AL MOMENTO DE APLICAR EL PAGO DE LA FACTURA..");
                                return;
                            }
                            Editar(form.MontoEfectivo);
                            Limpiar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtSubTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSubTotal.Text))
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
                    decimal valorDecimal = 0;
                    decimal.TryParse(txtSubTotal.Text, out valorDecimal);
                    txtSubTotal.Text = valorDecimal.ToString("#,###.00;-#,###.00;0.00");
                    txtItbis.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtItbis_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtSubTotal.Text))
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
                    decimal valorDecimal = 0;
                    decimal.TryParse(txtItbis.Text, out valorDecimal);
                    txtItbis.Text = valorDecimal.ToString("#,###.00;-#,###.00;0.00");
                    txtTotal.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
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
                    decimal valorDecimal = 0, itbis = 0, taza = 18;
                    decimal.TryParse(txtTotal.Text, out valorDecimal);
                    itbis = valorDecimal - (valorDecimal / (1 + (taza / 100)));
                    txtSubTotal.Text = (valorDecimal - itbis).ToString("#,###.00;-#,###.00;0.00");
                    txtItbis.Text = itbis.ToString("#,###.00;-#,###.00;0.00");
                    txtTotal.Text = valorDecimal.ToString("#,###.00;-#,###.00;0.00");
                    btnGuardar.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtTotal_Validated(object sender, EventArgs e)
        {
            try
            {

                //Condiciones para que solo acepte valores numericos:
                decimal valorDecimal = 0, itbis = 0, taza = 18;
                decimal.TryParse(txtTotal.Text, out valorDecimal);
                itbis = valorDecimal - (valorDecimal / (1 + (taza / 100)));
                txtSubTotal.Text = (valorDecimal - itbis).ToString("#,###.00;-#,###.00;0.00");
                txtItbis.Text = itbis.ToString("#,###.00;-#,###.00;0.00");
                txtTotal.Text = valorDecimal.ToString("#,###.00;-#,###.00;0.00");
                btnGuardar.Focus();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
