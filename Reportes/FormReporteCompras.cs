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
    public partial class FormReporteCompras : Form
    {
        public bool server = false;
        Conexion conexion;
        DataTable dt;
        decimal TotalCompras = 0;
        string orden = "";
        int IdProveedor = 0;
        int IdProducto = 0;
        public FormReporteCompras()
        {
            InitializeComponent();
        }

        private void FormReporteCompras_Load(object sender, EventArgs e)
        {
            try
            {
                orden = "Fecha DESC";
                txtOrdenarPor.SelectedIndex = 0;
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
                this.TotalCompras = 0;
                int IdCuenta = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdCuenta);
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();
                builder.Append("SELECT TblCompra.*, TblProveedor.Nombre FROM TblCompra");
                builder.Append(" JOIN TblProveedor on TblProveedor.IdProveedor = TblCompra.IdProveedor");
                if (txtFiltroFecha.Checked)
                {
                    if (this.IdProveedor > 0) 
                    {
                        builder.Append(" WHERE TblProveedor.IdProveedor = '" + this.IdProveedor + "'");
                        builder.Append(" AND Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                    }
                    else
                    {
                        builder.Append(" WHERE Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                    }

                    builder.Append(" ORDER BY " + orden);
                    Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                }
                else
                {
                    if (this.IdProveedor > 0)
                    {
                        builder.Append(" WHERE TblProveedor.IdProveedor = '" + this.IdProveedor + "'");
                    }
                    builder.Append(" ORDER BY " + orden);
                }
                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);
                Imprimir(Filtro.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region BuscarProducto
        private void BuscarProducto()
        {
            try
            {
                this.TotalCompras = 0;
                int IdCuenta = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdCuenta);
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();
                builder.Append("SELECT TblCompra.*, TblProveedor.Nombre As Proveedor, TblCompra.NoFactura AS CodigoFactura, TblCompra.CondicionCompra, TblCompraDetalle.Precio, TblCompraDetalle.Monto, TblCompraDetalle.Cantidad FROM TblCompraDetalle");
                builder.Append(" JOIN TblCompra ON TblCompra.IdCompra = TblCompraDetalle.IdCompra");
                builder.Append(" JOIN TblProducto ON TblProducto.IdProducto = TblCompraDetalle.IdProducto");
                builder.Append(" JOIN TblProveedor ON TblCompra.IdProveedor = TblProveedor.IdProveedor");
                builder.Append(" WHERE TblCompraDetalle.IdProducto = '" + this.IdProducto + "'");
                if (txtFiltroFecha.Checked)
                {
                    builder.Append(" AND TblCompra.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                    builder.Append(" AND TblCompra.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                }
                builder.Append(" ORDER BY TblCompra.Fecha DESC");

                Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));

                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);

                ImprimirRptProducto(Filtro.ToString());
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
                ReportParameter[] paramCollection = new ReportParameter[4];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Actividad", empresa.Actividad, true);
                paramCollection[2] = new ReportParameter("Filtro", Filtro.ToString(), true);
                paramCollection[3] = new ReportParameter("TotalCompras", TotalCompras.ToString("#,###.00;-#,###.00;0.00"), true);

                var tblUsuario = new TblUsuario();
                var getUsuario = new _Usuario_get();
                tblUsuario = getUsuario.GetById(IdUsuario);

                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetGastos", this.dt));
                frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptCompras.rdlc";
                frm.reportViewer1.LocalReport.SetParameters(paramCollection);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region ImprimirRptProducto
        private void ImprimirRptProducto(string Filtro)
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
                ReportParameter[] paramCollection = new ReportParameter[4];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Actividad", empresa.Actividad, true);
                paramCollection[2] = new ReportParameter("Filtro", Filtro.ToString(), true);
                paramCollection[3] = new ReportParameter("TotalCompras", TotalCompras.ToString("#,###.00;-#,###.00;0.00"), true);

                var tblUsuario = new TblUsuario();
                var getUsuario = new _Usuario_get();
                tblUsuario = getUsuario.GetById(IdUsuario);

                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetGastos", this.dt));
                frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptComprasProducto.rdlc";
                frm.reportViewer1.LocalReport.SetParameters(paramCollection);
                frm.Show();
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
                if(this.IdProducto > 0)
                {
                    BuscarProducto();
                }
                else
                {
                    Buscar();
                }
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

        private void txtOrdenarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtOrdenarPor.SelectedIndex == 0)
                {
                    orden = "Fecha DESC";
                }
                else if (txtOrdenarPor.SelectedIndex == 1)
                {
                    orden = "TblProveedor.Nombre";
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
                if(form.IdProveedor > 0)
                {
                    this.IdProveedor = form.IdProveedor;
                    txtNombre.Text = form.Nombre;
                    txtOrdenarPor.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                this.IdProveedor = 0;
                txtNombre.Text = string.Empty;
                txtOrdenarPor.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLimpiarProd_Click(object sender, EventArgs e)
        {
            try
            {
                this.IdProducto = 0;
                txtProducto.Text = string.Empty;
                txtOrdenarPor.Enabled = true;
                btnBuscarClientes.Enabled = true;
                pictureBox2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoProductos();
                form.ShowDialog();
                if (form.Id > 0)
                {
                    this.IdProducto = form.Id;
                    txtProducto.Text = form.codigo + "-" + form.descripcion;
                    txtOrdenarPor.SelectedIndex = 0;
                    txtOrdenarPor.Enabled = false;
                    btnBuscarClientes.Enabled = false;
                    pictureBox2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
