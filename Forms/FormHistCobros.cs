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
    public partial class FormHistCobros : Form
    {
        public int IdCxC = 0;
        public int IdCobro = 0;
        public int IdFactura = 0;
        public int IdUsuario = 0;
        DataTable dt;

        public FormHistCobros()
        {
            InitializeComponent();
        }

        private void FormCatalogoCobros_Load(object sender, EventArgs e)
        {
            try
            {
                this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
                dgv.ClearSelection();
                txtCliente.Text = Nombre;
                Buscar();

                //CXC
                BuscarFactura();
                BuscarDetalle();
                //BuscarUsuario();
                txtCliente.Text = Nombre;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        #region DATOS
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        #endregion

        #region Buscar
        private void Buscar()
        {
            try
            {
                dgv.Rows.Clear();
                var tbl = new List<TblCobro>();
                var get = new _Cobro_get();
                string texto = txtCodigo.Text;
                tbl = get.GetAll(this.IdCxC);
                decimal monto = 0, balance = 0, pagos = 0;
                if (tbl != null)
                {
                    foreach (var item in tbl)
                    {
                        dgv.Rows.Add(item.Fecha, item.IdCobro, item.Codigo, item.Monto, (item.Balance + item.Abono).ToString("#,###.00;-#,###.00;0.00"), item.Abono, item.Balance,  item.Nota);
                        monto = item.Monto;
                        balance = item.Balance;
                        pagos += item.Abono;
                    }
                }
                txtMonto.Text = monto.ToString("#,###.00;-#,###.00;0.00");
                txtBalance.Text = balance.ToString("#,###.00;-#,###.00;0.00");
                txtTotalPagos.Text = pagos.ToString("#,###.00;-#,###.00;0.00");
                txtNota.Text = string.Empty;
                dgv.ClearSelection();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region BuscarUsuario
        private void BuscarUsuario()
        {
            try
            {
                if (this.IdUsuario > 0)
                {
                    var tbl = new TblUsuario();
                    var get = new _Usuario_get();
                    tbl = get.GetById(this.IdUsuario);
                    //txtVendedor.Text = tbl.Nombre;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region BuscarFactura
        private void BuscarFactura()
        {
            try
            {
                var tbl = new TblFactura();
                var get = new _Factura_get();
                tbl = get.GetById(this.IdFactura);

                this.IdUsuario = tbl.IdUsuario;
                //txtNoFactura.Text = this.IdFactura.ToString();
                txtFecha.Value = tbl.Fecha.Value;
                txtSubTotal.Text = tbl.SubTotal.ToString("#,###.00;-#,###.00;0.00");
                txtItbis.Text = tbl.Itbis.ToString("#,###.00;-#,###.00;0.00");
                txtTotal.Text = tbl.Total.ToString("#,###.00;-#,###.00;0.00");

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region BuscarDetalle
        private void BuscarDetalle()
        {
            try
            {
                var MiConexion = new Conexion();
                var builder = new StringBuilder();
                var dt = new DataTable();
                builder.Append("SELECT IdFacturaDetalle, IdFactura, TblFacturaDetalle.IdProducto, TblProducto.Codigo, TblProducto.Nombre, CantidadFacturada, PrecioFacturado, MontoFacturado, Ganancia FROM TblFacturaDetalle JOIN TblProducto on TblProducto.IdProducto =  TblFacturaDetalle.IdProducto WHERE IdFactura = '" + this.IdFactura + "'");
                dt = MiConexion.BuscarTabla(builder);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        dataGridView1.Rows.Add(item["IdProducto"].ToString(), item["Codigo"].ToString(), item["Nombre"].ToString(), item["CantidadFacturada"].ToString(), item["PrecioFacturado"].ToString(), item["MontoFacturado"].ToString(), item["Ganancia"].ToString());
                    }
                }
                dataGridView1.ClearSelection();

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

        #region Imprimir
        private void Imprimir()
        {
            try
            {
                int IdUsuario = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdUsuario);
                FormVisor frm = new FormVisor();
                frm.reportViewer1.Reset();
                var empresa = new TblEmpresa();//BUSCAMOS LOS DATOS DE LA CUENTA DEL DOCTOR
                var get = new _Empresa_get();
                empresa = get.GetById(1);
                var tblUsuario = new TblUsuario();
                var getUsuario = new _Usuario_get();
                tblUsuario = getUsuario.GetById(IdUsuario);

                var tblCxC = new TblCxC();
                var getCxC = new _CxC_get();
                tblCxC = getCxC.GetById(this.IdCxC);

                var tblCobro = new TblCobro();
                var getCobro = new _Cobro_get();
                tblCobro = getCobro.GetById(this.IdCobro);
                //PARAMETROS PARA EL REPORTE
                ReportParameter[] paramCollection = new ReportParameter[11];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Direccion", empresa.Direccion, true);
                paramCollection[2] = new ReportParameter("Telefono", empresa.Telefono1, true);
                paramCollection[3] = new ReportParameter("RNC", empresa.RNC, true);
                paramCollection[4] = new ReportParameter("NoRecibo", tblCobro.Codigo.ToString(), true);
                paramCollection[5] = new ReportParameter("NombreCliente", Nombre, true);
                paramCollection[6] = new ReportParameter("Usuario", tblUsuario.Nombre, true);
                paramCollection[7] = new ReportParameter("Monto", tblCxC.Monto.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[8] = new ReportParameter("Balance", (tblCobro.Balance + tblCobro.Abono).ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[9] = new ReportParameter("Fecha", tblCobro.Fecha.Value.ToShortDateString(), true);
                paramCollection[10] = new ReportParameter("Hora", tblCobro.Fecha.Value.ToShortTimeString(), true);

                //frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetReciboCxC", this.dt));
                //frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Impresiones.RECIBO_CXC.rdlc";
                //frm.reportViewer1.LocalReport.SetParameters(paramCollection);
                //frm.ShowDialog();

                var form = new FormModoImpresion();
                form.factura = true;
                form.ShowDialog();

                if (form.modoImpresion == "PAPEL ROLLO")
                {
                    ClassImprimir.ImprimirRecibo("DataSetReciboCxC", "Impresiones.RECIBO_CXC", paramCollection, this.dt, form.modoImpresion, "FACTURA");
                    ClassImprimir.ImprimirRecibo("DataSetReciboCxC", "Impresiones.RECIBO_CXC", paramCollection, this.dt, form.modoImpresion, "FACTURA");
                }
                else if (form.modoImpresion == "DIGITAL")
                {
                    ClassImprimir.ImprimirReporte("DataSetReciboCxC", "Impresiones.RECIBO_CXC_MEDIA_PG", paramCollection, this.dt);
                }
                else if (form.modoImpresion == "MEDIA PAGINA")
                {
                    ClassImprimir.ImprimirRecibo("DataSetReciboCxC", "Impresiones.RECIBO_CXC_MEDIA_PG", paramCollection, this.dt, form.modoImpresion, "FACTURA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region ImprimirRecibo
        private void ImprimirRecibo()
        {
            try
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Desea imprimir el recibo?", "Cobros CxC", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int IdCuenta = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdCuenta);
                var builder = new StringBuilder();
                builder.Append("SELECT TblCobro.IdCobro, TblCxC.IdFactura, TblFactura.Codigo As NoFactura, TblCobro.Fecha, TblCliente.Nombre As ClienteNombre, TblCobro.Abono, TblCobro.Balance FROM");
                builder.Append(" TblCobro JOIN TblCxC on TblCxC.IdCxC = TblCobro.IdCxC");
                builder.Append(" JOIN TblFactura on TblFactura.IdFactura = TblCxC.IdFactura");
                builder.Append(" JOIN TblCliente on TblCliente.IdCliente = TblCxC.IdCliente");
                builder.Append(" WHERE TblCobro.IdCobro = '" + this.IdCobro + "'");
                var conexion = new Conexion();
                dt = new DataTable();
                dt = conexion.BuscarTabla(builder);
                Imprimir();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int.TryParse(this.dgv.CurrentRow.Cells[1].Value.ToString(), out this.IdCobro);

                if (this.dgv.CurrentRow.Cells[7].Value != null)
                {
                    txtNota.Text = dgv.CurrentRow.Cells[7].Value.ToString();
                }
            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.IdCobro > 0 && this.IdCxC > 0)
                {
                    ImprimirRecibo();
                }
            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }
        }

        private void FormHistCobros_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F7)
                {
                    this.Close();
                }
                if (e.KeyData == Keys.F8)
                {
                    if (this.IdCobro > 0 && this.IdCxC > 0)
                    {
                        ImprimirRecibo();
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
