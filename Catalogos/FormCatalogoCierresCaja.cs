using BRL_SVentas.Forms;
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

namespace BRL_SVentas.Catalogos
{
    public partial class FormCatalogoCierresCaja : Form
    {
        public string texto = string.Empty;
        private bool salirAceptar = false;
        public int IdCierreCaja = 0;
        public string Codigo = string.Empty;
        public DataTable dt;
        public FormCatalogoCierresCaja()
        {
            InitializeComponent();
        }

        private void FormCatalogoCierresCaja_Load(object sender, EventArgs e)
        {
            try
            {
                this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
                txtBuscar.Text = texto;
                BuscarFecha();
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

        #region Buscar
        private void Buscar()
        {
            try
            {
                dgv.Rows.Clear();
                var tbl = new List<TblCajaCierre>();
                var get = new _CajaCierre_get();
                string texto = txtBuscar.Text;
                tbl = get.GetByFiltrado2(texto);

                if (!string.IsNullOrEmpty(txtBuscar.Text) && tbl != null)
                {
                    foreach (var item in tbl)
                    {
                        dgv.Rows.Add(item.Fecha, item.IdCajaCierre, item.Codigo, item.Caja, item.MontoApertura, item.TotalEntrada, item.TotalSalida, item.TotalConteo, item.Diferencia, item.Resultado, item.NombreUsuario, item.Nota);
                    }
                }

                dgv.ClearSelection();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region BuscarFecha
        private void BuscarFecha()
        {
            try
            {
                dgv.Rows.Clear();
                //var tbl = new List<TblCajaCierre>();
                //var get = new _CajaCierre_get();
                //tbl = get.GetByFiltradoFecha(txtFechaDesde.Value, txtFechaHasta.Value);
                //foreach (var item in tbl)
                //{
                //    dgv.Rows.Add(item.Fecha, item.IdCajaCierre, item.Codigo, item.Caja, item.MontoApertura, item.TotalEntrada, item.TotalSalida, item.TotalConteo, item.Diferencia, item.Resultado, item.NombreUsuario, item.Nota);
                //}
                //dgv.ClearSelection();


                var Miconexion = new Conexion();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT IdCajaCierre, TblCajaCierre.IdCajaApertura As IdCajaApert, TblCajaCierre.IdUsuario As CodigoUsuario,TblCajaCierre.Codigo, TblCajaCierre.Fecha, TblCajaCierre.Caja, TblCajaApertura.Monto As MontoApertura, TotalEntrada, TotalSalida, TotalConteo, Diferencia, Resultado, TblUsuario.Nombre, TblCajaCierre.Nota As nota FROM TblCajaCierre JOIN TblUsuario on TblUsuario.IdUsuario = TblCajaCierre.IdUsuario");
                builder.Append(" JOIN TblCajaApertura on TblCajaApertura.IdCajaApertura = TblCajaCierre.IdCajaApertura");
                builder.Append(" WHERE TblCajaCierre.Fecha >='" + ClassFecha.GetFecha(txtFechaDesde.Value, 1) + "' AND TblCajaCierre.Fecha <= '" + ClassFecha.GetFecha(txtFechaHasta.Value, 2) + "'");
                dt = Miconexion.BuscarTabla(builder);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow reader in dt.Rows)
                    {
                        dgv.Rows.Add(reader["Fecha"], reader["IdCajaCierre"].ToString(), reader["Codigo"].ToString(), reader["Caja"].ToString(), reader["MontoApertura"].ToString(), reader["TotalEntrada"].ToString(), reader["TotalSalida"].ToString(), reader["TotalConteo"].ToString(), reader["Diferencia"].ToString(), reader["Resultado"].ToString(), reader["Nombre"].ToString(), reader["nota"].ToString());
                    }
                }
                dgv.ClearSelection();
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
                var getCajaCierre= new _CajaCierre_get();
                tblCajaCierre = getCajaCierre.GetById(this.IdCierreCaja);

                var tblCajaConteo = new TblCajaConteo();
                var getCajaConteo = new _CajaConteo_get();
                tblCajaConteo = getCajaConteo.GetById(this.IdCierreCaja);

                //PARAMETROS PARA EL REPORTE
                ReportParameter[] paramCollection = new ReportParameter[36];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Direccion", empresa.Direccion, true);
                paramCollection[2] = new ReportParameter("Telefono", empresa.Telefono1, true);
                paramCollection[3] = new ReportParameter("RNC", empresa.RNC, true);
                paramCollection[4] = new ReportParameter("SubTotal", (tblCajaCierre.TotalEntrada - tblCajaCierre.TotalSalida-(tblCajaConteo.Vaucher + tblCajaConteo.Cheque)).ToString("#,###.00;-#,###.00;0.00"), true);
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


                if (ClaseGetCuenta.GetProyectConf() == 0)
                {
                    ClassImprimir.ImprimirRecibo(null, "Impresiones.CIERRE_CAJA", paramCollection, this.dt, tblConfig.PapelFactura, "CIERRE_CAJA");
                    ClassImprimir.ImprimirRecibo(null, "Impresiones.CIERRE_CAJA", paramCollection, this.dt, tblConfig.PapelFactura, "CIERRE_CAJA");
                }
                else if (ClaseGetCuenta.GetProyectConf() == 1)
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
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Buscar();
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
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsWhiteSpace(e.KeyChar))
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
                    if (dgv.Rows.Count <= 0)
                    {
                        AVISOW("Para seleccionar primero debe buscar el producto.");
                        return;
                    }
                    dgv.Focus();
                    this.dgv.CurrentRow.Selected = true;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnAceptar.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormCatalogoCierresCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.IdCierreCaja = 0;
                this.Close();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (IdCierreCaja > 0)
            {
                salirAceptar = true;
                this.Close();
            }
            else
            {
                AVISOI("Para Aceptar primero debe seleccionar un producto.");
            }
        }

        private void FormCatalogoCierresCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!salirAceptar)
                    this.IdCierreCaja = 0;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.IdCierreCaja = 0;
            this.Close();
        }

        private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.dgv.CurrentRow.Cells[1].Value.ToString()))
                {
                    int valor = 0;
                    int.TryParse(dgv.CurrentRow.Cells[1].Value.ToString(), out valor);
                    this.IdCierreCaja = valor;
                    this.Codigo = dgv.CurrentRow.Cells[2].Value.ToString();
                    txtNota.Text = dgv.CurrentRow.Cells[11].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                BuscarFecha();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                BuscarFecha();
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
    }
}
