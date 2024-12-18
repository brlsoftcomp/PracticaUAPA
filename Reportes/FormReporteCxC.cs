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

namespace BRL_SVentas.Reportes
{
    public partial class FormReporteCxC : Form
    {
        Conexion conexion;
        DataTable dt;
        decimal montoTotal = 0;
        decimal balanceTotal = 0;
        string orden = string.Empty;
        private int IdCliente = 0;
        public FormReporteCxC()
        {
            conexion = new Conexion();
            InitializeComponent();
        }
        private void FormReporteCxC_Load(object sender, EventArgs e)
        {
            try
            {
                txtEstado.SelectedIndex = 0;
                txtOrdenarPor.SelectedIndex = 0;
                this.orden = "Fecha DESC";
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
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();

                if (txtFiltroFecha.Checked)
                {
                    if(this.IdCliente > 0)//BUSCAR POR CLIENTE
                    {
                        builder.Append("SELECT TblCxC.*, TblFactura.Codigo As NoFactura, TblCliente.Nombre FROM TblCxC");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura");
                        builder.Append(" WHERE TblCxC.IdCliente = '" + this.IdCliente + "'");
                        builder.Append(" AND TblCxC.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND TblCxC.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        if (txtEstado.SelectedIndex != 3)
                        {
                            builder.Append(" AND TblCxC.Estado = '" + txtEstado.Text + "'");
                            builder.Append(" ORDER BY " + orden);
                        }
                        else
                        {
                            builder.Append(" ORDER BY " + orden);
                        }
                        Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                        Filtro.Append(", Estado: " + txtEstado.Text);
                    }
                    else if (txtEstado.SelectedIndex != 3)
                    {
                        builder.Append("SELECT TblCxC.*, TblFactura.Codigo As NoFactura, TblCliente.Nombre FROM TblCxC");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura");
                        builder.Append(" WHERE TblCxC.Estado = '" + txtEstado.Text + "'");
                        builder.Append(" AND TblCxC.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND TblCxC.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        builder.Append(" ORDER BY "+ orden);
                        Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                        Filtro.Append(", Estado: " + txtEstado.Text);
                    }
                    else if (txtEstado.SelectedIndex == 3)
                    {
                        builder.Append("SELECT TblCxC.*, TblFactura.Codigo As NoFactura, TblCliente.Nombre FROM TblCxC");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura");
                        builder.Append(" WHERE TblCxC.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND TblCxC.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        builder.Append(" ORDER BY " + orden);
                        Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                        Filtro.Append(", Estado: TODOS");
                    }
                }
                else
                {
                    if (this.IdCliente > 0)//BUSCAR POR CLIENTE
                    {
                        builder.Append("SELECT TblCxC.*, TblFactura.Codigo As NoFactura, TblCliente.Nombre FROM TblCxC");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura");
                        builder.Append(" WHERE TblCxC.IdCliente = '" + this.IdCliente + "'");
                        if (txtEstado.SelectedIndex != 3)
                        {
                            builder.Append(" AND TblCxC.Estado = '" + txtEstado.Text + "'");
                            builder.Append(" ORDER BY " + orden);
                        }
                        else
                        {
                            builder.Append(" ORDER BY " + orden);
                        }
                        Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                        Filtro.Append(", Estado: " + txtEstado.Text);
                    }
                    else if (txtEstado.SelectedIndex != 3)
                    {
                        builder.Append("SELECT TblCxC.*, TblFactura.Codigo As NoFactura, TblCliente.Nombre FROM TblCxC");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura");
                        builder.Append(" WHERE TblCxC.Estado = '" + txtEstado.Text + "'");
                        builder.Append(" ORDER BY " + orden);
                        Filtro.Append(", Estado: " + txtEstado.Text);
                    }
                    else if (txtEstado.SelectedIndex == 3)
                    {
                        builder.Append("SELECT TblCxC.*, TblFactura.Codigo As NoFactura, TblCliente.Nombre FROM TblCxC");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura");
                        builder.Append(" ORDER BY " + orden);
                        Filtro.Append(", Estado: TODOS");
                    }
                }
                
               
                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);
                decimal importeMonto = 0;
                decimal importeBalnce = 0;
                foreach (DataRow item in dt.Rows)
                {
                    decimal.TryParse(item["Monto"].ToString(), out importeMonto);
                    montoTotal += importeMonto;
                    decimal.TryParse(item["Balance"].ToString(), out importeBalnce);
                    balanceTotal += importeBalnce;
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
                int IdUsuario = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdUsuario);
                FormVisor frm = new FormVisor();
                frm.reportViewer1.Reset();
                var empresa = new TblEmpresa();//BUSCAMOS LOS DATOS DE LA CUENTA DEL DOCTOR
                var get = new _Empresa_get();
                empresa = get.GetById(1);
                //PARAMETROS PARA EL REPORTE
                ReportParameter[] paramCollection = new ReportParameter[5];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Actividad", empresa.Actividad, true);
                paramCollection[2] = new ReportParameter("Filtro", Filtro.ToString(), true);
                paramCollection[3] = new ReportParameter("Monto", montoTotal.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[4] = new ReportParameter("Balance", balanceTotal.ToString("#,###.00;-#,###.00;0.00"), true);

                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetCxC", this.dt));
                frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptCxC.rdlc";
                frm.reportViewer1.LocalReport.SetParameters(paramCollection);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        private void BtnConsultar_Click(object sender, EventArgs e)
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

        private void TxtTipoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtOrdenarPor.Items.Clear();
            //txtOrdenarPor.Items.Add("FECHA");
            //txtOrdenarPor.Items.Add("NOMBRE DEUDOR");
            //txtOrdenarPor.Items.Add("CONCEPTO");
            //txtOrdenarPor.SelectedIndex = 0;
            //txtEstado.Enabled = true;           
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

        private void txtOrdenarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtOrdenarPor.Text == "FECHA")
                {
                    orden = "TblCxC.Fecha DESC";
                }
                else if (txtOrdenarPor.Text == "NOMBRE DEUDOR")
                {
                    orden = "TblCliente.Nombre";
                }
                else if (txtOrdenarPor.Text == "ESTADO")
                {
                    orden = "TblCxC.Estado";
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
                    //txtOrdenarPor.Enabled = false;
                    if (txtEstado.SelectedIndex == 3)
                    {
                        txtOrdenarPor.Items.Clear();
                        txtOrdenarPor.Items.Add("FECHA");
                        txtOrdenarPor.Items.Add("ESTADO");
                        txtOrdenarPor.SelectedIndex = 0;
                    }
                    else
                    {
                        //txtOrdenarPor.Items.Clear();
                        //txtOrdenarPor.Items.Add("FECHA");
                        //txtOrdenarPor.Items.Add("ESTADO");
                        txtOrdenarPor.SelectedIndex = 0;
                        txtOrdenarPor.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                this.IdCliente = 0;
                txtNombre.Text = string.Empty;
                txtOrdenarPor.Items.Clear();
                txtOrdenarPor.Items.Add("FECHA");
                txtOrdenarPor.Items.Add("NOMBRE DEUDOR");
                txtOrdenarPor.Items.Add("ESTADO");
                txtOrdenarPor.SelectedIndex = 0;
                txtOrdenarPor.Enabled = true;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.IdCliente > 0)
                {
                    if (txtEstado.SelectedIndex == 3)
                    {
                        txtOrdenarPor.Items.Clear();
                        txtOrdenarPor.Items.Add("FECHA");
                        txtOrdenarPor.Items.Add("ESTADO");
                        txtOrdenarPor.SelectedIndex = 0;
                        txtOrdenarPor.Enabled = true;
                    }
                    else
                    {
                        txtOrdenarPor.SelectedIndex = 0;
                        txtOrdenarPor.Enabled = false;
                    }
                }
                else
                {
                    if (txtEstado.SelectedIndex == 3)
                    {
                        txtOrdenarPor.Items.Clear();
                        txtOrdenarPor.Items.Add("FECHA");
                        txtOrdenarPor.Items.Add("NOMBRE DEUDOR");
                        txtOrdenarPor.Items.Add("ESTADO");
                        txtOrdenarPor.SelectedIndex = 0;
                        txtOrdenarPor.Enabled = true;
                    }
                    else
                    {
                        txtOrdenarPor.Items.Clear();
                        txtOrdenarPor.Items.Add("FECHA");
                        txtOrdenarPor.Items.Add("NOMBRE DEUDOR");
                        txtOrdenarPor.SelectedIndex = 0;
                        txtOrdenarPor.Enabled = true;
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
