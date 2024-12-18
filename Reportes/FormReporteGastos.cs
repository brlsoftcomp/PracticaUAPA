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
    public partial class FormReporteGastos : Form
    {
        public bool server = false;
        Conexion conexion;
        DataTable dt;
        decimal TotalGastos = 0;

        public FormReporteGastos()
        {
            conexion = new Conexion();
            InitializeComponent();
        }

        private void FormReporteGastos_Load(object sender, EventArgs e)
        {
            try
            {
                txtConcepto.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                this.TotalGastos = 0;
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();

                builder.Append("SELECT *, TblProveedor.Nombre FROM TblGasto JOIN TblProveedor ON TblProveedor.IdProveedor = TblGasto.IdProveedor WHERE");
                builder.Append(" Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                if (txtConcepto.SelectedIndex != 0)
                {
                    builder.Append(" AND Concepto = '" + txtConcepto.Text+"'");
                }
                builder.Append(" ORDER BY Fecha DESC");
                Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));

                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);
                decimal importeTotal = 0;
                foreach (DataRow item in dt.Rows)
                {
                    decimal.TryParse(item["Monto"].ToString(), out importeTotal);
                    this.TotalGastos += importeTotal;
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
                ReportParameter[] paramCollection = new ReportParameter[4];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Actividad", empresa.Actividad, true);
                paramCollection[2] = new ReportParameter("Filtro", Filtro.ToString(), true);
                paramCollection[3] = new ReportParameter("TotalGastos", TotalGastos.ToString("#,###.00;-#,###.00;0.00"), true);

                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetGastos", this.dt));
                frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptGastos.rdlc";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtHasta_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
