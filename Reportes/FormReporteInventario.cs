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
    public partial class FormReporteInventario : Form
    {
        public bool server = false;
        Conexion conexion;
        DataTable dt;
        int IdProveedor = 0;
        decimal PrecioCompra = 0;
        decimal PrecioVenta = 0;
        decimal TotalValorInv = 0;
        decimal Itbis = 0;
        public FormReporteInventario()
        {
            conexion = new Conexion();
            InitializeComponent();
        }

        private void FormReporteInventario_Load(object sender, EventArgs e)
        {
            try
            {
                txtEstado.SelectedIndex = 0;
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
                PrecioCompra = 0;
                PrecioVenta = 0;
                Itbis = 0;
                TotalValorInv = 0;
                int IdCuenta = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdCuenta);
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();
                if (this.IdProveedor > 0)
                {
                    if (txtEstado.SelectedIndex == 0)
                    {
                        builder.Append("SELECT * FROM TblProducto WHERE IdProveedor = '" + this.IdProveedor + "' AND CantidadExistente > 0");
                        Filtro.Append("Estado: " + txtEstado.Text);
                    }
                    if (txtEstado.SelectedIndex == 2)
                    {
                        builder.Append("SELECT * FROM TblProducto WHERE IdProveedor = '" + this.IdProveedor + "' AND CantidadExistente <= 0");
                        Filtro.Append("Estado: " + txtEstado.Text);
                    }
                    if (txtEstado.SelectedIndex == 3)
                    {
                        builder.Append("SELECT * FROM TblProducto WHERE IdProveedor = '" + this.IdProveedor + "'");
                        Filtro.Append("Estado: " + txtEstado.Text);
                    }
                }
                else
                {
                    if (txtEstado.SelectedIndex == 0)
                    {
                        builder.Append("SELECT * FROM TblProducto WHERE CantidadExistente > 0");
                        Filtro.Append("Estado: " + txtEstado.Text);
                    }
                    if (txtEstado.SelectedIndex == 2)
                    {
                        builder.Append("SELECT * FROM TblProducto WHERE CantidadExistente <= 0");
                        Filtro.Append("Estado: " + txtEstado.Text);
                    }
                    if (txtEstado.SelectedIndex == 3)
                    {
                        builder.Append("SELECT * FROM TblProducto");
                        Filtro.Append("Estado: " + txtEstado.Text);
                    }
                }
                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);
                decimal precioCompra = 0;
                decimal precioVenta = 0;
                decimal itbis = 0;
                int cantidad = 0;
                foreach (DataRow item in dt.Rows)
                {
                    int.TryParse(item["CantidadExistente"].ToString(), out cantidad);
                    decimal.TryParse(item["PrecioCompra"].ToString(), out precioCompra);
                    PrecioCompra += precioCompra;
                    decimal.TryParse(item["PrecioVenta"].ToString(), out precioVenta);
                    PrecioVenta += precioVenta;
                    decimal.TryParse(item["Itbis"].ToString(), out itbis);
                    Itbis += itbis;
                    //Sumar valor total de inventario:
                    TotalValorInv += precioCompra * cantidad;
                }
                Imprimir(Filtro.ToString());


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region GetProductosTermino
        private void GetProductosTermino()
        {
            try
            {
                var tbl = new List<TblProducto>();
                var get = new _Producto_get();
                tbl = get.GetAll();
                this.dt = new DataTable();
                this.dt.Columns.Add("IdProducto");
                this.dt.Columns.Add("IdProveedor");
                this.dt.Columns.Add("Codigo");
                this.dt.Columns.Add("Nombre");
                this.dt.Columns.Add("PrecioCompra");
                this.dt.Columns.Add("PrecioVenta");
                this.dt.Columns.Add("PrecioMinimo");
                this.dt.Columns.Add("Itbis");
                this.dt.Columns.Add("CantidadExistente");
                this.dt.Columns.Add("Tope");
                foreach (var item in tbl)
                {
                    if (item.Tope > 0 && item.CantidadExistente <= item.Tope)
                    {

                        DataRow newRow = this.dt.NewRow();
                        newRow["IdProducto"] = item.IdProducto;
                        newRow["IdProveedor"] = item.IdProveedor;
                        newRow["Codigo"] = item.Codigo;
                        newRow["Nombre"] = item.Nombre;
                        newRow["PrecioCompra"] = item.PrecioCompra;
                        newRow["PrecioVenta"] = item.PrecioVenta;
                        newRow["PrecioMinimo"] = item.PrecioMinimo;
                        newRow["Itbis"] = item.Itbis;
                        newRow["CantidadExistente"] = item.CantidadExistente;
                        newRow["Tope"] = item.Tope;
                        dt.Rows.Add(newRow);
                    }
                }

                decimal precioCompra = 0;
                decimal precioVenta = 0;
                decimal itbis = 0;
                int cantidad = 0;
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                Filtro.Append("Estado: " + txtEstado.Text);
                foreach (DataRow item in this.dt.Rows)
                {
                    int.TryParse(item["CantidadExistente"].ToString(), out cantidad);
                    decimal.TryParse(item["PrecioCompra"].ToString(), out precioCompra);
                    PrecioCompra += precioCompra;
                    decimal.TryParse(item["PrecioVenta"].ToString(), out precioVenta);
                    PrecioVenta += precioVenta;
                    decimal.TryParse(item["Itbis"].ToString(), out itbis);
                    Itbis += itbis;
                    //Sumar valor total de inventario:
                    TotalValorInv += precioCompra * cantidad;
                }
                Imprimir(Filtro.ToString());
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
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
                ReportParameter[] paramCollection = new ReportParameter[7];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Actividad", empresa.Actividad, true);
                paramCollection[2] = new ReportParameter("Filtro", Filtro.ToString(), true);
                paramCollection[3] = new ReportParameter("PrecioCompra", PrecioCompra.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[4] = new ReportParameter("PrecioVenta", PrecioVenta.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[5] = new ReportParameter("Itbis", Itbis.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[6] = new ReportParameter("TotalValorInv", TotalValorInv.ToString("#,###.00;-#,###.00;0.00"), true);


                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetInventario", this.dt));
                if (txtEstado.SelectedIndex != 1)
                {
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptInventario.rdlc";
                }
                else
                {
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptInventarioTope.rdlc";
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

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEstado.SelectedIndex != 1)
                {
                    Buscar();
                }
                else
                {
                    GetProductosTermino();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {

        }

        private void txtEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoProveedor();
                form.ShowDialog();
                if (form.IdProveedor > 0)
                {
                    this.IdProveedor = form.IdProveedor;
                    txtProveedor.Text = form.Nombre;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnQuitarPorveedor_Click(object sender, EventArgs e)
        {
            try
            {
                this.IdProveedor = 0;
                txtProveedor.Text = string.Empty;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
