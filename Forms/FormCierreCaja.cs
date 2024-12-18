using BRL_SVentas.Catalogos;
using BRL_SVentas.Model;
using BRL_SVentas.Servicios;
using DoctConsults;
using Microsoft.Reporting.WinForms;
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
    public partial class FormCierreCaja : Form
    {
        bool cerrarGuardar = false;
        int IdCajaCierre = 0;
        public DataTable dt;
        public FormCierreCaja()
        {
            InitializeComponent();
            this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
        }
        private void FormCierreCaja_Load(object sender, EventArgs e)
        {
            try
            {
               ClaseGetCuenta.FormCierreCaja = true;//Indicar que el formulario del cierre esta abierto.

                BuscarFondoInicial();
                BuscarVentas();
                BuscarCobros();
                BuscarGastos();
                BuscarCompras();
                SumarMovimientoCaja();
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

        #region Bloquear
        private void Bloquear()
        {
            try
            {
                txtD1.Enabled = false;
                txtD5.Enabled = false;
                txtD10.Enabled = false;
                txtD25.Enabled = false;
                txtD50.Enabled = false;
                txtD100.Enabled = false;
                txtD200.Enabled = false;
                txtD500.Enabled = false;
                txtD1000.Enabled = false;
                txtD2000.Enabled = false;
                txtBouchers.Enabled = false;
                txtCheques.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Desbloquear
        private void Desbloquear()
        {
            try
            {
                txtD1.Enabled = true;
                txtD5.Enabled = true;
                txtD10.Enabled = true;
                txtD25.Enabled = true;
                txtD50.Enabled = true;
                txtD100.Enabled = true;
                txtD200.Enabled = true;
                txtD500.Enabled = true;
                txtD1000.Enabled = true;
                txtD2000.Enabled = true;
                txtBouchers.Enabled = true;
                txtCheques.Enabled = true;
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
            try
            {
                this.IdCajaCierre = 0;
                txtCodigo.Text = string.Empty;
                BuscarFondoInicial();
                BuscarVentas();
                BuscarCobros();
                BuscarGastos();
                BuscarCompras();
                SumarMovimientoCaja();
                txtD1.Text = "0";
                txtD5.Text = "0";
                txtD10.Text = "0";
                txtD25.Text = "0";
                txtD50.Text = "0";
                txtD100.Text = "0"; 
                txtD200.Text = "0";
                txtD500.Text = "0";
                txtD1000.Text = "0";
                txtD2000.Text = "0";

                txtMD1.Text = "0.00";
                txtMD5.Text = "0.00";
                txtMD10.Text = "0.00";
                txtMD25.Text = "0.00";
                txtMD50.Text = "0.00";
                txtMD100.Text = "0.00";
                txtMD200.Text = "0.00";
                txtMD500.Text = "0.00";
                txtMD1000.Text = "0.00";
                txtMD2000.Text = "0.00";

                txtCheques.Text = "0.00";
                txtBouchers.Text = "0.00";
                txtTotalConteo.Text = "0.00";
                txtDiferencia.Text = "0.00";
                txtResultCierre.Text = "*";
                btnGuardar.Enabled = false;
                btnValidar.Enabled = true;
                btnLimpiar.Enabled = true;
                btnImiprimir.Enabled = false;
                Desbloquear();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region MontoConteo
        private void MontoConteo()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtD1.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD1.Text, out valor);
                    valorMonto = 1 * valor;
                    txtD1.Text = valor.ToString();
                    txtMD1.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD1.Text = "0";
                    txtMD1.Text = "0.00";
                }
                if (!string.IsNullOrEmpty(txtD5.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD5.Text, out valor);
                    valorMonto = 5 * valor;
                    txtD5.Text = valor.ToString();
                    txtMD5.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD5.Text = "0";
                    txtMD5.Text = "0.00";
                }
                if (!string.IsNullOrEmpty(txtD10.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD10.Text, out valor);
                    valorMonto = 10 * valor;
                    txtD10.Text = valor.ToString();
                    txtMD10.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD10.Text = "0";
                    txtMD10.Text = "0.00";
                }
                if (!string.IsNullOrEmpty(txtD25.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD25.Text, out valor);
                    valorMonto = 25 * valor;
                    txtD25.Text = valor.ToString();
                    txtMD25.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD25.Text = "0";
                    txtMD25.Text = "0.00";
                }
                if (!string.IsNullOrEmpty(txtD50.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD50.Text, out valor);
                    valorMonto = 50 * valor;
                    txtD50.Text = valor.ToString();
                    txtMD50.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD50.Text = "0";
                    txtMD50.Text = "0.00";
                }
                if (!string.IsNullOrEmpty(txtD100.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD100.Text, out valor);
                    valorMonto = 100 * valor;
                    txtD100.Text = valor.ToString();
                    txtMD100.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD100.Text = "0";
                    txtMD100.Text = "0.00";
                }
                if (!string.IsNullOrEmpty(txtD200.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD200.Text, out valor);
                    valorMonto = 200 * valor;
                    txtD200.Text = valor.ToString();
                    txtMD200.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD200.Text = "0";
                    txtMD200.Text = "0.00";
                }
                if (!string.IsNullOrEmpty(txtD500.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD500.Text, out valor);
                    valorMonto = 500 * valor;
                    txtD500.Text = valor.ToString();
                    txtMD500.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD500.Text = "0";
                    txtMD500.Text = "0.00";
                }
                if (!string.IsNullOrEmpty(txtD1000.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD1000.Text, out valor);
                    valorMonto = 1000 * valor;
                    txtD1000.Text = valor.ToString();
                    txtMD1000.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD1000.Text = "0";
                    txtMD1000.Text = "0.00";
                }
                if (!string.IsNullOrEmpty(txtD2000.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD2000.Text, out valor);
                    valorMonto = 2000 * valor;
                    txtD2000.Text = valor.ToString();
                    txtMD2000.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD2000.Text = "0";
                    txtMD2000.Text = "0.00";
                }
                SumarConteo();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
        #endregion

        #region SumarConteo
        private void SumarConteo()
        {
            try
            {
                decimal valor = 0;
                decimal valorTotal = 0;
                decimal.TryParse(txtMD1.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtMD5.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtMD10.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtMD25.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtMD50.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtMD100.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtMD200.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtMD500.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtMD1000.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtMD2000.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtCheques.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtBouchers.Text, out valor);
                valorTotal += valor;
                txtTotalConteo.Text = valorTotal.ToString("#,###.00;-#,###.00;0.00");
                btnGuardar.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region SumarMovimientoCaja
        private void SumarMovimientoCaja()
        {
            try
            {
                decimal valor = 0;
                decimal valorTotal = 0;
                decimal valorTotalEnCaja = 0;
                //ENTRADA:
                decimal.TryParse(txtFondoInicial.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtCobrosCxC.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtVentas.Text, out valor);
                valorTotal += valor;
                txtTotalEntrada.Text = valorTotal.ToString("#,###.00;-#,###.00;0.00");
                valorTotalEnCaja += valorTotal;

                //SALIDA:
                valorTotal = 0;
                decimal.TryParse(txtCompras.Text, out valor);
                valorTotal += valor;
                decimal.TryParse(txtGastos.Text, out valor);
                valorTotal += valor;
                txtTotalSalida.Text = valorTotal.ToString("#,###.00;-#,###.00;0.00");
                valorTotalEnCaja -= valorTotal;

                txtTotalEfectivo.Text = valorTotalEnCaja.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region BuscarFondoInicial
        private void BuscarFondoInicial()
        {
            try
            {
                var tblCajaAp = new TblCajaApertura();
                var get = new _CajaApertura_get();
                tblCajaAp = get.GetByEstado();
                txtFondoInicial.Text = tblCajaAp.Monto.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region BuscarVentas
        private void BuscarVentas()
        {
            try
            {
                int Id = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out Id);
                var tbl = new List<TblCaja>();
                var get = new _Caja_get();
                tbl = get.GetMovimiento("FACTURACION", Id);
                decimal valor = 0;
                foreach (var item in tbl)
                {
                    valor += item.Monto;
                }
                txtVentas.Text = valor.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region BuscarCobros
        private void BuscarCobros()
        {
            try
            {
                int Id = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out Id);
                var tbl = new List<TblCaja>();
                var get = new _Caja_get();
                tbl = get.GetMovimiento("COBRO CXC", Id);
                decimal valor = 0;
                foreach (var item in tbl)
                {
                    valor += item.Monto;
                }
                txtCobrosCxC.Text = valor.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region BuscarGastos
        private void BuscarGastos()
        {
            try
            {
                int Id = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out Id);
                var tbl = new List<TblCaja>();
                var get = new _Caja_get();
                tbl = get.GetMovimiento("GASTOS", Id);
                decimal valor = 0;
                foreach (var item in tbl)
                {
                    valor += item.Monto;
                }
                txtGastos.Text = valor.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region BuscarCompras
        private void BuscarCompras()
        {
            try
            {
                int Id = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out Id);
                var tbl = new List<TblCaja>();
                var get = new _Caja_get();
                tbl = get.GetMovimiento("COMPRAS", Id);
                decimal valor = 0;
                foreach (var item in tbl)
                {
                    valor += item.Monto;
                }
                txtCompras.Text = valor.ToString("#,###.00;-#,###.00;0.00");
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

                var tblConfig = new TblMasterConfig();
                var getConfig = new _MasterConfig_get();
                tblConfig = getConfig.GetById(1);

                var empresa = new TblEmpresa();//BUSCAMOS LOS DATOS DE LA CUENTA DEL DOCTOR
                var get = new _Empresa_get();
                empresa = get.GetById(1);

                var tblUsuario = new TblUsuario();
                var getUsuario = new _Usuario_get();
                tblUsuario = getUsuario.GetById(ClaseGetCuenta.GetIdUsuario());

                var tblCajaCierre = new TblCajaCierre();
                var getCajaCierre = new _CajaCierre_get();
                tblCajaCierre = getCajaCierre.GetById(this.IdCajaCierre);

                var tblCajaConteo = new TblCajaConteo();
                var getCajaConteo = new _CajaConteo_get();
                tblCajaConteo = getCajaConteo.GetById(this.IdCajaCierre);

                //PARAMETROS PARA EL REPORTE
                ReportParameter[] paramCollection = new ReportParameter[36];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Direccion", empresa.Direccion, true);
                paramCollection[2] = new ReportParameter("Telefono", empresa.Telefono1, true);
                paramCollection[3] = new ReportParameter("RNC", empresa.RNC, true);
                paramCollection[4] = new ReportParameter("SubTotal", (tblCajaCierre.TotalEntrada - tblCajaCierre.TotalSalida - (tblCajaConteo.Vaucher + tblCajaConteo.Cheque)).ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[5] = new ReportParameter("ItbisTotal", tblCajaCierre.TotalEntrada.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[6] = new ReportParameter("Total", (tblCajaCierre.TotalEntrada - tblCajaCierre.TotalSalida).ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[7] = new ReportParameter("Usuario", tblUsuario.Nombre, true);
                paramCollection[8] = new ReportParameter("Fecha", tblCajaCierre.Fecha.Value.ToShortDateString(), true);
                paramCollection[9] = new ReportParameter("Hora", tblCajaCierre.Fecha.Value.ToShortTimeString(), true);
                paramCollection[10] = new ReportParameter("Caja", tblCajaCierre.Caja, true);
                paramCollection[11] = new ReportParameter("TotalEntrada", tblCajaCierre.TotalEntrada.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[12] = new ReportParameter("TotalSalida", tblCajaCierre.TotalSalida.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[13] = new ReportParameter("TotalConteo", tblCajaCierre.TotalConteo.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[14] = new ReportParameter("Diferencia", tblCajaCierre.Diferencia.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[15] = new ReportParameter("Resultado", tblCajaCierre.Resultado, true);
                paramCollection[16] = new ReportParameter("Ventas", tblCajaCierre.Ventas.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[17] = new ReportParameter("CobrosCxC", tblCajaCierre.CobrosCxC.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[18] = new ReportParameter("Compras", tblCajaCierre.Compras.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[19] = new ReportParameter("Gastos", tblCajaCierre.Gastos.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[20] = new ReportParameter("DevVentas", tblCajaCierre.DevVentas.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[21] = new ReportParameter("PagosCxP", tblCajaCierre.PagosCxP.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[22] = new ReportParameter("FondoInical", tblCajaCierre.TotalEntrada.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[23] = new ReportParameter("Uno", tblCajaConteo.Uno.ToString(), true);
                paramCollection[24] = new ReportParameter("Cinco", tblCajaConteo.Cinco.ToString(), true);
                paramCollection[25] = new ReportParameter("Diez", tblCajaConteo.Diez.ToString(), true);
                paramCollection[26] = new ReportParameter("Veinticinco", tblCajaConteo.Veinticinco.ToString(), true);
                paramCollection[27] = new ReportParameter("Cincuenta", tblCajaConteo.Cincuenta.ToString(), true);
                paramCollection[28] = new ReportParameter("Cien", tblCajaConteo.Cien.ToString(), true);
                paramCollection[29] = new ReportParameter("Docientos", tblCajaConteo.Docientos.ToString(), true);
                paramCollection[30] = new ReportParameter("Quientos", tblCajaConteo.Quientos.ToString(), true);
                paramCollection[31] = new ReportParameter("Mil", tblCajaConteo.Mil.ToString(), true);
                paramCollection[32] = new ReportParameter("Dosmil", tblCajaConteo.Dosmil.ToString(), true);
                paramCollection[33] = new ReportParameter("Vaucher", tblCajaConteo.Vaucher.ToString(), true);
                paramCollection[34] = new ReportParameter("Cheque", tblCajaConteo.Cheque.ToString(), true);
                paramCollection[35] = new ReportParameter("NoCierreCaja", tblCajaCierre.Codigo.ToString(), true);

                if (tblConfig.PapelFactura == "NO IMPRIMIR")
                {
                    return;
                }
                else if (tblConfig.PapelFactura == "PAPEL ROLLO")
                {                    
                    ClassImprimir.ImprimirRecibo(null, "Impresiones.CIERRE_CAJA", paramCollection, this.dt, tblConfig.PapelFactura, "CIERRE_CAJA");
                }
                else if (tblConfig.PapelFactura == "MEDIA PAGINA")
                {
                    ClassImprimir.ImprimirRecibo(null, "Impresiones.CIERRE_CAJA_MEDIA_PG", paramCollection, this.dt, tblConfig.PapelFactura, "CIERRE_CAJA");
                }
                else if (tblConfig.PapelFactura == "DIGITAL")
                {
                    ClassImprimir.ImprimirReporte(null, "Impresiones.CIERRE_CAJA", paramCollection, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Validar
        private void Validar()
        {
            try
            {
                decimal valorContado = 0;
                decimal valorCaja = 0;
                decimal diferencia = 0;
                decimal.TryParse(txtTotalConteo.Text, out valorContado);
                decimal.TryParse(txtTotalEfectivo.Text, out valorCaja);
                diferencia = valorContado - valorCaja;
                txtDiferencia.Text = diferencia.ToString("#,###.00;-#,###.00;0.00");
                if (diferencia == 0)
                {
                    txtResultCierre.ForeColor = Color.Green;
                    txtResultCierre.Text = "CUADRE PERFECTO";
                }
                if (diferencia > 0)
                {
                    txtResultCierre.ForeColor = Color.Blue;
                    txtResultCierre.Text = "CUADRE SOBRANTE";
                }
                if (diferencia < 0)
                {
                    txtResultCierre.ForeColor = Color.Red;
                    txtResultCierre.Text = "CUADRE FALTANTE";
                }
                btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
        #endregion

        #region Guardar
        private void Guardar()
        {
            try
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Realmente desea Guardar el Cierre de Caja?", "Cierre de Caja", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                int valorInt = 0;
                decimal valorDecimal = 0;
                var tblCajaCierre = new TblCajaCierre();
                int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out valorInt);
                tblCajaCierre.IdCajaApertura = valorInt;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out valorInt);
                tblCajaCierre.IdUsuario = valorInt;
                tblCajaCierre.Fecha = DateTime.Now;
                tblCajaCierre.Caja = "Caja #1";
                decimal.TryParse(txtTotalEntrada.Text, out valorDecimal);
                tblCajaCierre.TotalEntrada = valorDecimal;
                decimal.TryParse(txtTotalSalida.Text, out valorDecimal);
                tblCajaCierre.TotalSalida = valorDecimal;
                decimal.TryParse(txtTotalConteo.Text, out valorDecimal);
                tblCajaCierre.TotalConteo = valorDecimal;
                decimal.TryParse(txtDiferencia.Text, out valorDecimal);
                tblCajaCierre.Diferencia = valorDecimal;
                if (valorDecimal != 0)
                {
                    var form = new FormNotaCierreCaja();
                    form.ShowDialog();
                    tblCajaCierre.Nota = form.texto;
                }
                else
                {
                    tblCajaCierre.Nota = string.Empty;
                }
                tblCajaCierre.Resultado = txtResultCierre.Text;

                decimal.TryParse(txtVentas.Text, out valorDecimal);
                tblCajaCierre.Ventas = valorDecimal;
                decimal.TryParse(txtCobrosCxC.Text, out valorDecimal);
                tblCajaCierre.CobrosCxC = valorDecimal;
                decimal.TryParse(txtCompras.Text, out valorDecimal);
                tblCajaCierre.Compras = valorDecimal;
                decimal.TryParse(txtGastos.Text, out valorDecimal);
                tblCajaCierre.Gastos = valorDecimal;


                this.IdCajaCierre = _CajaCierre.Save(tblCajaCierre);
                if (this.IdCajaCierre > 0)
                {
                    var tblConteo = new TblCajaConteo();
                    tblConteo.IdCajaCierre = this.IdCajaCierre;
                    int.TryParse(txtD1.Text, out valorInt);
                    tblConteo.Uno = valorInt;
                    int.TryParse(txtD5.Text, out valorInt);
                    tblConteo.Cinco = valorInt;
                    int.TryParse(txtD10.Text, out valorInt);
                    tblConteo.Diez = valorInt;
                    int.TryParse(txtD25.Text, out valorInt);
                    tblConteo.Veinticinco = valorInt;
                    int.TryParse(txtD50.Text, out valorInt);
                    tblConteo.Cincuenta = valorInt;
                    int.TryParse(txtD100.Text, out valorInt);
                    tblConteo.Cien = valorInt;
                    int.TryParse(txtD200.Text, out valorInt);
                    tblConteo.Docientos = valorInt;
                    int.TryParse(txtD500.Text, out valorInt);
                    tblConteo.Quientos = valorInt;
                    int.TryParse(txtD1000.Text, out valorInt);
                    tblConteo.Mil = valorInt;
                    int.TryParse(txtD2000.Text, out valorInt);
                    tblConteo.Dosmil = valorInt;
                    decimal.TryParse(txtBouchers.Text, out valorDecimal);
                    tblConteo.Vaucher = valorDecimal;
                    decimal.TryParse(txtCheques.Text, out valorDecimal);
                    tblConteo.Cheque = valorDecimal;
                    _CajaConteo.Save(tblConteo);

                    //GUARDAD CAMBIOS EN APERTURA
                    var tblCajaApertura = new TblCajaApertura();
                    var getCajaApertura = new _CajaApertura_get();
                    int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out valorInt);
                    tblCajaApertura = getCajaApertura.GetById(valorInt);
                    tblCajaApertura.IdCajaApertura = valorInt;
                    int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out valorInt);
                    tblCajaApertura.IdUsuario = valorInt;
                    tblCajaApertura.Fecha = DateTime.Now;
                    tblCajaApertura.Caja = "Caja #1";
                    decimal.TryParse(txtFondoInicial.Text, out valorDecimal);
                    tblCajaApertura.Monto = valorDecimal;
                    tblCajaApertura.Estado = "CERRADA";
                    valorInt = _CajaApertura.SaveXML(tblCajaApertura);
                    if (valorInt > 0)
                    {
                        ConfigurationManager.AppSettings["IdCajaApertura"] = "0";
                        cerrarGuardar = true;
                        if (MessageBox.Show("Desea imprimir el cierre de caja?", "Imprimir cierre de caja.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Imprimir();
                        }
                        //AVISOI("DATOS GUARDADOS!");
                        this.Close();
                    }


                }
                else
                {
                    AVISOW("ERROR EN EL GUARDADO DE DATOS!");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
        #endregion
        private void TxtD1_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtD1.Text))
                    {
                        int valor = 0;
                        decimal valorMonto = 0;
                        int.TryParse(txtD1.Text, out valor);
                        valorMonto = 1 * valor;
                        txtD1.Text = valor.ToString();
                        txtMD1.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtD1.Text = "0";
                        txtMD1.Text = "0.00";
                    }
                    SumarConteo();
                    txtD5.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD5_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtD5.Text))
                    {
                        int valor = 0;
                        decimal valorMonto = 0;
                        int.TryParse(txtD5.Text, out valor);
                        valorMonto = 5 * valor;
                        txtD5.Text = valor.ToString();
                        txtMD5.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtD5.Text = "0";
                        txtMD5.Text = "0.00";
                    }
                    SumarConteo();
                    txtD10.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD10_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtD10.Text))
                    {
                        int valor = 0;
                        decimal valorMonto = 0;
                        int.TryParse(txtD10.Text, out valor);
                        valorMonto = 10 * valor;
                        txtD10.Text = valor.ToString();
                        txtMD10.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtD10.Text = "0";
                        txtMD10.Text = "0.00";
                    }
                    SumarConteo();
                    txtD25.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD25_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtD25.Text))
                    {
                        int valor = 0;
                        decimal valorMonto = 0;
                        int.TryParse(txtD25.Text, out valor);
                        valorMonto = 25 * valor;
                        txtD25.Text = valor.ToString();
                        txtMD25.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtD25.Text = "0";
                        txtMD25.Text = "0.00";
                    }
                    SumarConteo();
                    txtD50.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD50_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtD50.Text))
                    {
                        int valor = 0;
                        decimal valorMonto = 0;
                        int.TryParse(txtD50.Text, out valor);
                        valorMonto = 50 * valor;
                        txtD50.Text = valor.ToString();
                        txtMD50.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtD50.Text = "0";
                        txtMD50.Text = "0.00";
                    }
                    SumarConteo();
                    txtD100.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD100_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtD100.Text))
                    {
                        int valor = 0;
                        decimal valorMonto = 0;
                        int.TryParse(txtD100.Text, out valor);
                        valorMonto = 100 * valor;
                        txtD100.Text = valor.ToString();
                        txtMD100.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtD100.Text = "0";
                        txtMD100.Text = "0.00";
                    }
                    SumarConteo();
                    txtD200.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD200_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtD200.Text))
                    {
                        int valor = 0;
                        decimal valorMonto = 0;
                        int.TryParse(txtD200.Text, out valor);
                        valorMonto = 200 * valor;
                        txtD200.Text = valor.ToString();
                        txtMD200.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtD200.Text = "0";
                        txtMD200.Text = "0.00";
                    }
                    SumarConteo();
                    txtD500.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD500_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtD500.Text))
                    {
                        int valor = 0;
                        decimal valorMonto = 0;
                        int.TryParse(txtD500.Text, out valor);
                        valorMonto = 500 * valor;
                        txtD500.Text = valor.ToString();
                        txtMD500.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtD500.Text = "0";
                        txtMD500.Text = "0.00";
                    }
                    SumarConteo();
                    txtD1000.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD1000_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtD1000.Text))
                    {
                        int valor = 0;
                        decimal valorMonto = 0;
                        int.TryParse(txtD1000.Text, out valor);
                        valorMonto = 1000 * valor;
                        txtD1000.Text = valor.ToString();
                        txtMD1000.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtD1000.Text = "0";
                        txtMD1000.Text = "0.00";
                    }
                    SumarConteo();
                    txtD2000.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD2000_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtD2000.Text))
                    {
                        int valor = 0;
                        decimal valorMonto = 0;
                        int.TryParse(txtD2000.Text, out valor);
                        valorMonto = 2000 * valor;
                        txtD2000.Text = valor.ToString();
                        txtMD2000.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtD2000.Text = "0";
                        txtMD2000.Text = "0.00";
                    }
                    SumarConteo();
                    txtCheques.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtCheques_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtCheques.Text))
                    {
                        decimal valor = 0;
                        decimal.TryParse(txtCheques.Text, out valor);
                        txtCheques.Text = valor.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtCheques.Text = "0.00";
                    }
                    SumarConteo();
                    txtBouchers.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtBouchers_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtBouchers.Text))
                    {
                        decimal valor = 0;
                        decimal.TryParse(txtBouchers.Text, out valor);
                        txtBouchers.Text = valor.ToString("#,###.00;-#,###.00;0.00");
                    }
                    else
                    {
                        txtBouchers.Text = "0.00";
                    }
                    SumarConteo();
                    btnValidar.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtD1.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD1.Text, out valor);
                    valorMonto = 1 * valor;
                    txtD1.Text = valor.ToString();
                    txtMD1.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD1.Text = "0";
                    txtMD1.Text = "0.00";
                }
                SumarConteo();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD5_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtD5.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD5.Text, out valor);
                    valorMonto = 5 * valor;
                    txtD5.Text = valor.ToString();
                    txtMD5.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD5.Text = "0";
                    txtMD5.Text = "0.00";
                }
                SumarConteo();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD10_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtD10.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD10.Text, out valor);
                    valorMonto = 10 * valor;
                    txtD10.Text = valor.ToString();
                    txtMD10.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD10.Text = "0";
                    txtMD10.Text = "0.00";
                }
                SumarConteo();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD25_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtD25.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD25.Text, out valor);
                    valorMonto = 25 * valor;
                    txtD25.Text = valor.ToString();
                    txtMD25.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD25.Text = "0";
                    txtMD25.Text = "0.00";
                }
                SumarConteo();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD50_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtD50.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD50.Text, out valor);
                    valorMonto = 50 * valor;
                    txtD50.Text = valor.ToString();
                    txtMD50.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD50.Text = "0";
                    txtMD50.Text = "0.00";
                }
                SumarConteo();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD100_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtD100.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD100.Text, out valor);
                    valorMonto = 100 * valor;
                    txtD100.Text = valor.ToString();
                    txtMD100.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD100.Text = "0";
                    txtMD100.Text = "0.00";
                }
                SumarConteo();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD200_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtD200.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD200.Text, out valor);
                    valorMonto = 200 * valor;
                    txtD200.Text = valor.ToString();
                    txtMD200.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD200.Text = "0";
                    txtMD200.Text = "0.00";
                }
                SumarConteo();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD500_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtD500.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD500.Text, out valor);
                    valorMonto = 500 * valor;
                    txtD500.Text = valor.ToString();
                    txtMD500.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD500.Text = "0";
                    txtMD500.Text = "0.00";
                }
                SumarConteo();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD1000_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtD1000.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD1000.Text, out valor);
                    valorMonto = 1000 * valor;
                    txtD1000.Text = valor.ToString();
                    txtMD1000.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD1000.Text = "0";
                    txtMD1000.Text = "0.00";
                }
                SumarConteo();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtD2000_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtD2000.Text))
                {
                    int valor = 0;
                    decimal valorMonto = 0;
                    int.TryParse(txtD2000.Text, out valor);
                    valorMonto = 2000 * valor;
                    txtD2000.Text = valor.ToString();
                    txtMD2000.Text = valorMonto.ToString("#,###.00;-#,###.00;0.00");
                }
                else
                {
                    txtD2000.Text = "0";
                    txtMD2000.Text = "0.00";
                }
                SumarConteo();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
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
                Guardar();
                ClaseGetCuenta.FormCierreCaja = false;//Indicar que el formulario del cierre esta cerrado.
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormCierreCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!cerrarGuardar)
                {
                    DialogResult result = new DialogResult();
                    result = MessageBox.Show("Realmente desea cerrar el Formulario?", "Cierre de Caja", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                    ClaseGetCuenta.FormCierreCaja = false;//Indicar que el formulario ya esta cerrado.
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoCierresCaja();
                form.ShowDialog();
                if(form.IdCierreCaja > 0)
                {
                    Limpiar();
                    txtCodigo.Text = form.Codigo;
                    btnImiprimir.Enabled = true;

                    var tblCierre = new TblCajaCierre();
                    var getCierre = new _CajaCierre_get();
                    tblCierre = getCierre.GetById(form.IdCierreCaja);
                    txtFondoInicial.Text = getCierre.GetMontoApertura(form.IdCierreCaja).ToString();
                    txtDiferencia.Text = tblCierre.Diferencia.ToString();
                    txtResultCierre.Text = tblCierre.Resultado.ToString();
                    txtVentas.Text = tblCierre.Ventas.ToString();
                    txtCobrosCxC.Text = tblCierre.CobrosCxC.ToString();
                    txtCompras.Text = tblCierre.Compras.ToString();
                    txtGastos.Text = tblCierre.Gastos.ToString();
                    if (txtResultCierre.Text == "CUADRE PERFECTO")
                    {
                        txtResultCierre.ForeColor = Color.Green;
                    }
                    if (txtResultCierre.Text == "CUADRE SOBRANTE")
                    {
                        txtResultCierre.ForeColor = Color.Blue;
                    }
                    if (txtResultCierre.Text == "CUADRE FALTANTE")
                    {
                        txtResultCierre.ForeColor = Color.Red;
                    }
                    SumarMovimientoCaja();

                    var tbl = new TblCajaConteo();
                    var get = new _CajaConteo_get();
                    tbl = get.GetById(form.IdCierreCaja);
                    if (tbl != null)
                    {
                        this.IdCajaCierre = form.IdCierreCaja;
                        txtD1.Text = tbl.Uno.ToString();
                        txtD5.Text = tbl.Cinco.ToString();
                        txtD10.Text = tbl.Diez.ToString();
                        txtD25.Text = tbl.Veinticinco.ToString();
                        txtD50.Text = tbl.Cincuenta.ToString();
                        txtD100.Text = tbl.Cien.ToString();
                        txtD200.Text = tbl.Docientos.ToString();
                        txtD500.Text = tbl.Quientos.ToString();
                        txtD1000.Text = tbl.Mil.ToString();
                        txtD2000.Text = tbl.Dosmil.ToString();
                        txtCheques.Text = tbl.Cheque.ToString();
                        txtBouchers.Text = tbl.Vaucher.ToString();
                        btnValidar.Enabled = false;
                        MontoConteo();
                        Bloquear();
                        btnLimpiar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnImiprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Imprimir();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormCierreCaja_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F5)
                {
                    Limpiar();
                }
                if (e.KeyData == Keys.F6)
                {
                    Validar();
                }
                if (e.KeyData == Keys.F7)
                {
                    Guardar();
                }
                if (e.KeyData == Keys.F8)
                {
                    Imprimir();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
