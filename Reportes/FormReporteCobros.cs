using BRL_SVentas.Catalogos;
using BRL_SVentas.Forms;
using BRL_SVentas.Model;
using BRL_SVentas.Servicios;
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

namespace BRL_SVentas
{
    public partial class FormReporteCobros : Form
    {
        public bool server = false;
        Conexion conexion;
        DataTable dt;
        decimal montoTotal = 0;
        decimal balanceTotal = 0;
        decimal cobradoTotal = 0;
        string orden = string.Empty;
        private int IdCliente = 0;
        public FormReporteCobros()
        {
            conexion = new Conexion();
            InitializeComponent();
        }

        private void FormReporteCobros_Load(object sender, EventArgs e)
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
                montoTotal = 0;
                balanceTotal = 0;
                cobradoTotal = 0;
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();
                if (txtFiltroFecha.Checked)
                {
                    if (this.IdCliente > 0)//BUSCAR POR CLIENTE
                    {
                        builder.Append("SELECT TblCobro.*,  TblCxC.Concepto, TblFactura.Codigo As NoFactura, TblCliente.Nombre FROM TblCobro JOIN TblCxC ON TblCxC.IdCxC = TblCobro.IdCxC");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura");
                        builder.Append(" WHERE TblCxC.IdCliente = '" + this.IdCliente + "'");
                        builder.Append(" AND TblCobro.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND TblCobro.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        builder.Append(" ORDER BY " + orden);
                        
                        Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                        Filtro.Append(", Cliente: " + txtNombre.Text);
                        Filtro.Append(", Agrupado: " + txtAgrupar.Text);
                    }
                    else
                    {
                        builder.Append("SELECT TblCobro.*,  TblCxC.Concepto, TblFactura.Codigo As NoFactura, TblCliente.Nombre FROM TblCobro JOIN TblCxC ON TblCxC.IdCxC = TblCobro.IdCxC");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura");
                        builder.Append(" WHERE TblCobro.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND TblCobro.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        builder.Append(" ORDER BY " + orden);
                        

                        Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                        Filtro.Append(", Agrupado: " + txtAgrupar.Text);
                    }
                }
                else
                {
                    if (this.IdCliente > 0)//BUSCAR POR CLIENTE
                    {
                        builder.Append("SELECT TblCobro.*,  TblCxC.Concepto, TblFactura.Codigo As NoFactura, TblCliente.Nombre FROM TblCobro JOIN TblCxC ON TblCxC.IdCxC = TblCobro.IdCxC");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura");
                        builder.Append(" WHERE TblCxC.IdCliente = '" + this.IdCliente + "'");
                        builder.Append(" ORDER BY " + orden);
                        Filtro.Append("Cliente: " + txtNombre.Text);
                        Filtro.Append(", Agrupado: " + txtAgrupar.Text);
                    }
                    else
                    {
                        builder.Append("SELECT TblCobro.*, TblFactura.Codigo As NoFactura, TblCliente.Nombre, TblCxC.Concepto FROM TblCobro JOIN TblCxC ON TblCxC.IdCxC = TblCobro.IdCxC");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura");      
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
                    decimal.TryParse(item["Monto"].ToString(), out valorDecimal);
                    montoTotal += valorDecimal;
                    decimal.TryParse(item["Balance"].ToString(), out valorDecimal);
                    balanceTotal += valorDecimal;
                    decimal.TryParse(item["Abono"].ToString(), out valorDecimal);
                    cobradoTotal += valorDecimal;
                    
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
                paramCollection[3] = new ReportParameter("Monto", montoTotal.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[4] = new ReportParameter("Balance", balanceTotal.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[5] = new ReportParameter("TotalCobrado", cobradoTotal.ToString("#,###.00;-#,###.00;0.00"), true);

                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetCobro", this.dt));
                if (txtAgrupar.SelectedIndex == 0)
                {
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptCobro.rdlc";
                }
                else if (txtAgrupar.SelectedIndex == 1)
                {
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptCobroAgrFact.rdlc";
                }
                else if (txtAgrupar.SelectedIndex == 2)
                {
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptCobroAgrNomb.rdlc";
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
                var form = new FormCatalogoCliente();
                form.ShowDialog();
                if (form.IdCliente > 0)
                {
                    this.IdCliente = form.IdCliente;
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
                this.IdCliente = 0;
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
                if (txtOrdenarPor.SelectedIndex == 0)
                {
                    orden = "Fecha";
                }
                else if (txtOrdenarPor.SelectedIndex == 1)
                {
                    orden = "TblFactura.Codigo";
                }
                else if (txtOrdenarPor.SelectedIndex == 2)
                {
                    orden = "TblCliente.Nombre";
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
