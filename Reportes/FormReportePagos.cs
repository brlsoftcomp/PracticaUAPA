using BRL_SVentas.Catalogos;
using BRL_SVentas.Forms;
using BRL_SVentas.Model;
using BRL_SVentas.Servicios;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRL_SVentas.Reportes
{
    public partial class FormReportePagos : Form
    {
        public bool server = false;
        Conexion conexion;
        DataTable dt;
        decimal totalPago = 0;
        decimal totalMonto = 0;
        decimal totalBalance = 0;
        string orden = string.Empty;
        private int IdProveedor = 0;
        public FormReportePagos()
        {
            conexion = new Conexion();
            InitializeComponent();
        }

        private void FormReportePagos_Load(object sender, EventArgs e)
        {
            try
            {
                txtAgrupar.SelectedIndex = 0;
                txtOrdenarPor.SelectedIndex = 0;
                this.orden = "Fecha";
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
                totalPago = 0;
                totalMonto = 0;
                totalBalance = 0;
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();
                if (txtFiltroFecha.Checked)
                {
                    if (this.IdProveedor > 0)//BUSCAR POR CLIENTE
                    {
                        builder.Append("SELECT TblPago.IdPago, TblPago.Codigo, TblCompra.NoFactura, TblPago.IdCxP, TblPago.Fecha, TblPago.PagoCaja, TblPago.PagoOtros, TblPago.Monto, TblPago.Balance, TblProveedor.Nombre, TblCxP.Concepto FROM TblPago JOIN TblCxP on TblCxP.IdCxP = TblPago.IdCxP");
                        builder.Append(" JOIN TblProveedor on TblProveedor.IdProveedor = TblCxP.IdProveedor");
                        builder.Append(" JOIN TblCompra on TblCompra.IdCompra = TblCxP.IdCompra");
                        builder.Append(" WHERE TblCxP.IdProveedor = '" + this.IdProveedor + "'");
                        builder.Append(" AND TblPago.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND TblPago.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        builder.Append(" ORDER BY " + orden);

                        Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                        Filtro.Append(", Proveedor: " + txtNombre.Text);
                        Filtro.Append(", Agrupado: " + txtAgrupar.Text);
                    }
                    else
                    {
                        builder.Append("SELECT TblPago.IdPago, TblPago.Codigo, TblCompra.NoFactura, TblPago.IdCxP, TblPago.Fecha, TblPago.PagoCaja, TblPago.PagoOtros,TblPago.Monto, TblPago.Balance, TblProveedor.Nombre, TblCxP.Concepto FROM TblPago JOIN TblCxP on TblCxP.IdCxP = TblPago.IdCxP");
                        builder.Append(" JOIN TblProveedor on TblProveedor.IdProveedor = TblCxP.IdProveedor");
                        builder.Append(" JOIN TblCompra on TblCompra.IdCompra = TblCxP.IdCompra");
                        builder.Append(" WHERE TblPago.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND TblPago.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        builder.Append(" ORDER BY " + orden);


                        Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                        Filtro.Append(", Agrupado: " + txtAgrupar.Text);
                    }
                }
                else
                {
                    if (this.IdProveedor > 0)//BUSCAR POR CLIENTE
                    {
                        builder.Append("SELECT TblPago.IdPago, TblPago.Codigo, TblCompra.NoFactura, TblPago.IdCxP, TblPago.Fecha, TblPago.PagoCaja, TblPago.PagoOtros,TblPago.Monto, TblPago.Balance, TblProveedor.Nombre, TblCxP.Concepto FROM TblPago JOIN TblCxP on TblCxP.IdCxP = TblPago.IdCxP");
                        builder.Append(" JOIN TblProveedor on TblProveedor.IdProveedor = TblCxP.IdProveedor");
                        builder.Append(" JOIN TblCompra on TblCompra.IdCompra = TblCxP.IdCompra");
                        builder.Append(" WHERE TblCxP.IdProveedor = '" + this.IdProveedor + "'");
                        builder.Append(" ORDER BY " + orden);
                        Filtro.Append("Proveedor: " + txtNombre.Text);
                        Filtro.Append(", Agrupado: " + txtAgrupar.Text);
                    }
                    else
                    {
                        builder.Append("SELECT TblPago.IdPago, TblPago.Codigo, TblCompra.NoFactura, TblPago.IdCxP, TblPago.Fecha, TblPago.PagoCaja, TblPago.PagoOtros,TblPago.Monto, TblPago.Balance, TblProveedor.Nombre, TblCxP.Concepto FROM TblPago JOIN TblCxP on TblCxP.IdCxP = TblPago.IdCxP");
                        builder.Append(" JOIN TblProveedor on TblProveedor.IdProveedor = TblCxP.IdProveedor");
                        builder.Append(" JOIN TblCompra on TblCompra.IdCompra = TblCxP.IdCompra");
                        builder.Append(" ORDER BY " + orden);

                        Filtro.Append("Agrupado: " + txtAgrupar.Text);
                        Filtro.Append("Fecha: TODAS");
                    }
                }

                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);
                decimal valorDecimal = 0;
                foreach (DataRow item in dt.Rows)
                {
                    decimal.TryParse(item["PagoCaja"].ToString(), out valorDecimal);
                    totalPago += valorDecimal;
                    decimal.TryParse(item["PagoOtros"].ToString(), out valorDecimal);
                    totalPago += valorDecimal;
                }
                Imprimir(Filtro.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Imprimir
        private void Imprimir(string Filtro)
        {
            try
            {
                FormVisor frm = new FormVisor();
                frm.reportViewer1.Reset();
                var empresa = new TblEmpresa();//BUSCAMOS LOS DATOS DE LA CUENTA DEL DOCTOR
                var get = new _Empresa_get();
                empresa = get.GetById(1);
                //PARAMETROS PARA EL REPORTE
                ReportParameter[] paramCollection = new ReportParameter[6];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Actividad", empresa.Actividad, true);
                paramCollection[2] = new ReportParameter("Filtro", Filtro.ToString(), true);
                paramCollection[3] = new ReportParameter("TotalPago", totalPago.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[4] = new ReportParameter("TotalMonto", totalMonto.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[5] = new ReportParameter("TotalBalance", totalBalance.ToString("#,###.00;-#,###.00;0.00"), true);

                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetPagos", this.dt));
                if (txtAgrupar.SelectedIndex == 0)
                {
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptPago.rdlc";
                }
                else if (txtAgrupar.SelectedIndex == 1)
                {
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptPagoAgrFact.rdlc";
                }
                else if (txtAgrupar.SelectedIndex == 2)
                {
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptPagoAgrNomb.rdlc";
                }

                frm.reportViewer1.LocalReport.SetParameters(paramCollection);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltroFecha_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFiltroFecha.Checked)
                {
                    txtDesde.Enabled = true;
                    txtHasta.Enabled = true;
                }
                else
                {
                    txtDesde.Enabled = false;
                    txtHasta.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoProveedor();
                form.ShowDialog();
                if (form.IdProveedor > 0)
                {
                    this.IdProveedor = form.IdProveedor;
                    txtNombre.Text = form.Nombre;

                    txtAgrupar.Items.Clear();
                    txtAgrupar.Items.Add("NO AGRUPADO");
                    txtAgrupar.Items.Add("NO. FACTURA");
                    txtAgrupar.SelectedIndex = 0;

                    txtOrdenarPor.Items.Clear();
                    txtOrdenarPor.Items.Add("FECHA");
                    txtOrdenarPor.Items.Add("NO. FACTURA");
                    txtOrdenarPor.SelectedIndex = 0;
                    //txtOrdenarPor.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.IdProveedor = 0;
                txtNombre.Text = string.Empty;
                //txtOrdenarPor.Enabled = true;
                txtAgrupar.Enabled = true;
                txtAgrupar.SelectedIndex = 0;

                txtAgrupar.Items.Clear();
                txtAgrupar.Items.Add("NO AGRUPADO");
                txtAgrupar.Items.Add("NO. FACTURA");
                txtAgrupar.Items.Add("NOMBRE CLIENTE");
                txtAgrupar.SelectedIndex = 0;

                txtOrdenarPor.Items.Clear();
                txtOrdenarPor.Items.Add("FECHA");
                txtOrdenarPor.Items.Add("NO. FACTURA");
                txtOrdenarPor.Items.Add("NOMBRE CLIENTE");
                txtOrdenarPor.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtAgrupar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAgrupar.SelectedIndex == 0)
                {
                    txtOrdenarPor.Items.Clear();
                    txtOrdenarPor.Items.Add("FECHA");
                    txtOrdenarPor.Items.Add("NO. FACTURA");
                    txtOrdenarPor.Items.Add("NOMBRE CLIENTE");
                    txtOrdenarPor.SelectedIndex = 0;
                    txtOrdenarPor.Enabled = true;
                }
                else if (txtAgrupar.SelectedIndex == 1)
                {
                    txtOrdenarPor.Items.Clear();
                    txtOrdenarPor.Items.Add("FECHA");
                    txtOrdenarPor.Items.Add("NO. FACTURA");
                    txtOrdenarPor.Items.Add("NOMBRE CLIENTE");
                    txtOrdenarPor.SelectedIndex = 0;
                    txtOrdenarPor.Enabled = false;
                }
                else
                {
                    txtOrdenarPor.Items.Clear();
                    txtOrdenarPor.Items.Add("FECHA");
                    txtOrdenarPor.Items.Add("NO. FACTURA");
                    txtOrdenarPor.SelectedIndex = 0;
                    txtOrdenarPor.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtOrdenarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtOrdenarPor.Text == "FECHA")
                {
                    orden = "Fecha";
                }
                else if (txtOrdenarPor.Text == "NO. FACTURA")
                {
                    orden = "TblCompra.NoFactura";
                }
                else if (txtOrdenarPor.Text == "NOMBRE PROVEEDOR")
                {
                    orden = "TblProveedor.Nombre";
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
