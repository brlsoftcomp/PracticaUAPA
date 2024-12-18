using BRL_SVentas.Catalogos;
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

namespace BRL_SVentas.Forms
{
    public partial class FormReporteVentas : Form
    {
        Conexion conexion;
        DataTable dt;
        decimal precioVenta = 0;
        decimal precioCompra = 0;
        decimal totalImporte = 0;
        decimal totalGanancia = 0;
        int IdProducto = 0;
        int IdProveedor = 0;
        int IdCliente = 0;
        public FormReporteVentas()
        {
            conexion = new Conexion();
            InitializeComponent();
        }

        private void FormReporteVentas_Load(object sender, EventArgs e)
        {
            try
            {
                txtTipoBusqueda.SelectedIndex = 0;
                txtCondicionPago.SelectedIndex = 0;

                if (ValidarUsoNCF())
                {
                    txtTipoComprob.SelectedIndex = 0;
                }
                else
                {
                    txtTipoComprob.Text = string.Empty;
                    txtTipoComprob.Enabled = false;
                }
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

        #region GetIdNCF
        private int GetIdNCF()
        {
            try
            {
                int Id = 0;

                if(txtTipoComprob.SelectedIndex == 1)
                {
                    Id = 2;
                }
                if (txtTipoComprob.SelectedIndex == 2)
                {
                    Id = 1;
                }
                if (txtTipoComprob.SelectedIndex == 3)
                {
                    Id = 6;
                }
                if (txtTipoComprob.SelectedIndex == 4)
                {
                    Id = 5;
                }
                if (txtTipoComprob.SelectedIndex == 5)
                {
                    Id = 7;
                }
                if (txtTipoComprob.SelectedIndex == 6)
                {
                    Id = 8;
                }
                if (txtTipoComprob.SelectedIndex == 7)
                {
                    Id = 4;
                }
                if (txtTipoComprob.SelectedIndex == 8)
                {
                    Id = 3;
                }

                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Buscar
        private void Buscar()
        {
            try
            {
                this.precioVenta = 0;
                this.precioCompra = 0;
                this.totalImporte = 0;
                this.totalGanancia = 0;
                int IdCuenta = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdCuenta);
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();
                if (txtCondicionPago.SelectedIndex == 2)
                {
                    if (ValidarUsoNCF())
                    {
                        builder.Append("SELECT *, TblCompFiscalSecuencia.NCF, TblCompFiscalSecuencia.NCFModificado, TblCliente.Nombre, TblCliente.Cedula FROM TblFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" JOIN TblCompFiscalSecuencia ON TblCompFiscalSecuencia.IdFactura = TblFactura.IdFactura");
                        if (txtTipoComprob.SelectedIndex > 0)
                        {
                            builder.Append(" WHERE TblCompFiscalSecuencia.IdCompFiscal = '" + GetIdNCF() + "'");
                            builder.Append(" AND Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                            builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        }
                        else
                        {
                            builder.Append(" WHERE Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                            builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        }
                    }
                    else
                    {
                        builder.Append("SELECT *, TblCliente.Nombre FROM TblFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" WHERE Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                    }


                    Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                    Filtro.Append(", Condicion Pago: " + txtCondicionPago.Text);
                }
                else
                {
                    if (ValidarUsoNCF())
                    {
                        builder.Append("SELECT *, TblCompFiscalSecuencia.NCF, TblCompFiscalSecuencia.NCFModificado, TblCliente.Nombre FROM TblFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" JOIN TblCompFiscalSecuencia ON TblCompFiscalSecuencia.IdFactura = TblFactura.IdFactura");
                        if (txtTipoComprob.SelectedIndex > 0)
                        {
                            builder.Append(" WHERE CondicionPago = '" + txtCondicionPago.Text + "' AND TblCompFiscalSecuencia.IdCompFiscal = '" + GetIdNCF() + "'");
                        }
                        else
                        {
                            builder.Append(" WHERE CondicionPago = '" + txtCondicionPago.Text + "'");
                        }
                        builder.Append(" AND Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                    }
                    else
                    {
                        builder.Append("SELECT *, TblCliente.Nombre FROM TblFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" WHERE CondicionPago = '" + txtCondicionPago.Text + "'");
                        builder.Append(" AND Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                    }

                    Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                    Filtro.Append(", Condicion Pago: " + txtCondicionPago.Text + ", NCF: " + txtTipoComprob.Text);
                }
                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);
                decimal importeSubTotal = 0;
                decimal importeItbis = 0;
                decimal importeTotal = 0;
                decimal importeGanancia = 0;
                foreach (DataRow item in dt.Rows)
                {
                    decimal.TryParse(item["SubTotal"].ToString(), out importeSubTotal);
                    this.precioVenta += importeSubTotal;
                    decimal.TryParse(item["Itbis"].ToString(), out importeItbis);
                    this.precioCompra += importeItbis;
                    decimal.TryParse(item["Total"].ToString(), out importeTotal);
                    this.totalImporte += importeTotal;
                    decimal.TryParse(item["TotalGanancia"].ToString(), out importeGanancia);
                    this.totalGanancia += importeGanancia;
                }
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
                this.precioVenta = 0;
                this.precioCompra = 0;
                this.totalImporte = 0;
                this.totalGanancia = 0;
                int IdCuenta = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdCuenta);
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();

                builder.Append("SELECT *, TblCliente.Nombre As Cliente, TblFactura.Codigo AS CodigoFactura, TblFactura.CondicionPago, TblProducto.PrecioVenta, TblProducto.PrecioCompra, TblFacturaDetalle.CantidadFacturada FROM TblFacturaDetalle");
                builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblFacturaDetalle.IdFactura");
                builder.Append(" JOIN TblProducto ON TblProducto.IdProducto = TblFacturaDetalle.IdProducto");
                builder.Append(" JOIN TblCliente ON TblFactura.IdCliente = TblCliente.IdCliente");
                builder.Append(" WHERE TblFacturaDetalle.IdProducto = '" + this.IdProducto + "'");
                if (txtCondicionPago.Text != "TODAS")
                {
                    builder.Append(" AND TblFactura.CondicionPago = '" + txtCondicionPago.Text + "'");
                }
                builder.Append(" AND TblFactura.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                builder.Append(" AND TblFactura.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                    
                Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                Filtro.Append(", Condicion Pago: " + txtCondicionPago.Text);

                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);
                decimal precioVenta = 0;
                decimal precioCompra = 0;
                int cantidad = 0;
                foreach (DataRow item in dt.Rows)
                {
                    int.TryParse(item["CantidadFacturada"].ToString(), out cantidad);
                    decimal.TryParse(item["PrecioVenta"].ToString(), out precioVenta);
                    this.precioVenta += (precioVenta * cantidad);
                    decimal.TryParse(item["PrecioCompra"].ToString(), out precioCompra);
                    this.precioCompra += (precioCompra * cantidad);
                    this.totalGanancia += ((precioVenta * cantidad) - (precioCompra * cantidad));
                }

                //ImprimirRptProducto(Filtro.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region BuscarProductoProveedor
        private void BuscarProductoProveedor()
        {
            try
            {
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();

                DataTable dt2;
                builder.Append("SELECT IdProducto, TblProducto.Codigo, TblProducto.Nombre FROM TblProducto");
                builder.Append(" JOIN TblProveedor ON TblProveedor.IdProveedor = TblProducto.IdProveedor");
                builder.Append(" WHERE TblProducto.IdProveedor = '" + this.IdProveedor + "'");
                builder.Append(" ORDER BY TblProducto.Nombre");
                dt2 = new DataTable();
                dt2 = conexion.BuscarTabla(builder);

                if (dt2 != null)
                {
                    int id = 0;

                    var dt3 = new DataTable();
                    var dt4 = new DataTable();
                    dt4.Columns.Add("Codigo");
                    dt4.Columns.Add("Nombre");
                    dt4.Columns.Add("CantidadFacturada");
                    DataRow newRow;

                    foreach (DataRow item in dt2.Rows)
                    {
                        int.TryParse(item["IdProducto"].ToString(), out id);

                        builder = new StringBuilder();
                        builder.Append("SELECT TblProducto.Codigo, TblProducto.Nombre, TblFacturaDetalle.CantidadFacturada FROM TblFacturaDetalle");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblFacturaDetalle.IdFactura");
                        builder.Append(" JOIN TblProducto ON TblProducto.IdProducto = TblFacturaDetalle.IdProducto");
                        builder.Append(" WHERE TblFacturaDetalle.IdProducto = '" + id + "'");
                        builder.Append(" AND TblFactura.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND TblFactura.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");

                        dt3 = new DataTable();
                        dt3 = conexion.BuscarTabla(builder);
                        if (dt3 != null)
                        {
                            int valorInt = 0, cantidad = 0;
                            string nombre = string.Empty;
                            foreach (DataRow item2 in dt3.Rows)
                            {
                                int.TryParse(item2["CantidadFacturada"].ToString(), out valorInt);
                                cantidad += valorInt;
                            }
                            newRow = dt4.NewRow();
                            newRow["Codigo"] = item["Codigo"].ToString();
                            newRow["Nombre"] = item["Nombre"];
                            newRow["CantidadFacturada"] = cantidad.ToString();

                            dt4.Rows.Add(newRow);
                        }
                    }

                    Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                    Filtro.Append(", Condicion Pago: " + txtCondicionPago.Text);

                    ImprimirRptProducto(Filtro.ToString(), dt4);
                }
                else
                {
                    MessageBox.Show("ERROR");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region BuscarVentasCliente
        private void BuscarVentasCliente()
        {
            try
            {
                this.precioVenta = 0;
                this.precioCompra = 0;
                this.totalImporte = 0;
                this.totalGanancia = 0;
                int IdCuenta = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdCuenta);
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();
                if (txtCondicionPago.SelectedIndex == 2)
                {
                    if (ValidarUsoNCF())
                    {
                        builder.Append("SELECT *, TblCompFiscalSecuencia.NCF, TblCompFiscalSecuencia.NCFModificado, TblCliente.Nombre FROM TblFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" JOIN TblCompFiscalSecuencia ON TblCompFiscalSecuencia.IdFactura = TblFactura.IdFactura");
                        if (txtTipoComprob.SelectedIndex > 0)
                        {
                            builder.Append(" WHERE TblCompFiscalSecuencia.IdCompFiscal = '" + GetIdNCF() + "'");
                            builder.Append(" AND Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                            builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                            builder.Append(" AND TblFactura.IdCliente = '" + this.IdCliente + "'");
                        }
                        else
                        {
                            builder.Append(" WHERE Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                            builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                            builder.Append(" AND TblFactura.IdCliente = '" + this.IdCliente + "'");
                        }
                    }
                    else
                    {
                        builder.Append("SELECT *, TblCliente.Nombre FROM TblFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" WHERE Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        builder.Append(" AND TblFactura.IdCliente = '" + this.IdCliente + "'");
                    }


                    Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                    Filtro.Append(", Condicion Pago: " + txtCondicionPago.Text);
                }
                else
                {
                    if (ValidarUsoNCF())
                    {
                        builder.Append("SELECT *, TblCompFiscalSecuencia.NCF, TblCompFiscalSecuencia.NCFModificado, TblCliente.Nombre FROM TblFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" JOIN TblCompFiscalSecuencia ON TblCompFiscalSecuencia.IdFactura = TblFactura.IdFactura");
                        if (txtTipoComprob.SelectedIndex > 0)
                        {
                            builder.Append(" WHERE CondicionPago = '" + txtCondicionPago.Text + "' AND TblCompFiscalSecuencia.IdCompFiscal = '" + GetIdNCF() + "'");
                        }
                        else
                        {
                            builder.Append(" WHERE CondicionPago = '" + txtCondicionPago.Text + "'");
                        }
                        builder.Append(" AND Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        builder.Append(" AND TblFactura.IdCliente = '" + this.IdCliente + "'");
                    }
                    else
                    {
                        builder.Append("SELECT *, TblCliente.Nombre FROM TblFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" WHERE CondicionPago = '" + txtCondicionPago.Text + "'");
                        builder.Append(" AND Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        builder.Append(" AND TblFactura.IdCliente = '" + this.IdCliente + "'");
                    }

                    Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                    Filtro.Append(", Condicion Pago: " + txtCondicionPago.Text + ", NCF: " + txtTipoComprob.Text);
                }
                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);
                decimal importeSubTotal = 0;
                decimal importeItbis = 0;
                decimal importeTotal = 0;
                decimal importeGanancia = 0;
                foreach (DataRow item in dt.Rows)
                {
                    decimal.TryParse(item["SubTotal"].ToString(), out importeSubTotal);
                    this.precioVenta += importeSubTotal;
                    decimal.TryParse(item["Itbis"].ToString(), out importeItbis);
                    this.precioCompra += importeItbis;
                    decimal.TryParse(item["Total"].ToString(), out importeTotal);
                    this.totalImporte += importeTotal;
                    decimal.TryParse(item["TotalGanancia"].ToString(), out importeGanancia);
                    this.totalGanancia += importeGanancia;
                }
                Imprimir(Filtro.ToString());


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region BuscarDevoluciones
        private void BuscarDevoluciones()
        {
            try
            {
                this.precioVenta = 0;
                this.precioCompra = 0;
                this.totalImporte = 0;
                this.totalGanancia = 0;
                int IdCuenta = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdCuenta);
                var Filtro = new StringBuilder();
                Filtro.Append("Filtro de Busqueda: ");
                var builder = new StringBuilder();
                if (txtCondicionPago.SelectedIndex == 2)
                {
                    if (ValidarUsoNCF())
                    {
                        builder.Append("SELECT *, TblCompFiscalSecuencia.NCF, TblCliente.Nombre FROM TblDevolucion");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblDevolucion.IdFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" JOIN TblCompFiscalSecuencia ON TblCompFiscalSecuencia.IdFactura = TblFactura.IdFactura");
                        if (txtTipoComprob.SelectedIndex > 0)
                        {
                            builder.Append(" WHERE TblCompFiscalSecuencia.IdCompFiscal = '" + GetIdNCF() + "'");
                            builder.Append(" AND TblDevolucion.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                            builder.Append(" AND TblDevolucion.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        }
                        else
                        {
                            builder.Append(" WHERE TblDevolucion.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                            builder.Append(" AND TblDevolucion.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                        }
                    }
                    else
                    {
                        builder.Append("SELECT *, TblCliente.Nombre FROM TblDevolucion");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblDevolucion.IdFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" WHERE TblDevolucion.Fecha >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND TblDevolucion.Fecha <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");

                    }
                    Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                    Filtro.Append(", Condicion Pago: " + txtCondicionPago.Text);
                }
                else
                {
                    if (ValidarUsoNCF())
                    {
                        builder.Append("SELECT *, TblCompFiscalSecuencia.NCF, TblCliente.Nombre FROM TblDevolucion");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblDevolucion.IdFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" JOIN TblCompFiscalSecuencia ON TblCompFiscalSecuencia.IdFactura = TblFactura.IdFactura");
                        if (txtTipoComprob.SelectedIndex > 0)
                        {
                            builder.Append(" WHERE TblFactura.CondicionPago = '" + txtCondicionPago.Text + "' AND TblCompFiscalSecuencia.IdCompFiscal = '" + GetIdNCF() + "'");
                        }
                        else
                        {
                            builder.Append(" WHERE TblFactura.CondicionPago = '" + txtCondicionPago.Text + "'");
                        }
                        builder.Append(" AND TblDevolucion.Fecha  >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND TblDevolucion.Fecha  <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                    }
                    else
                    {
                        builder.Append("SELECT *, TblCliente.Nombre FROM TblDevolucion");
                        builder.Append(" JOIN TblFactura ON TblFactura.IdFactura = TblDevolucion.IdFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" WHERE TblFactura.CondicionPago = '" + txtCondicionPago.Text + "'");
                        builder.Append(" AND TblDevolucion.Fecha  >= '" + ClassFecha.GetFecha(txtDesde.Value, 1) + "'");
                        builder.Append(" AND TblDevolucion.Fecha  <= '" + ClassFecha.GetFecha(txtHasta.Value, 2) + "'");
                    }
                    Filtro.Append("Fecha Desde: " + txtDesde.Value.ToString("dd/MM/yyyy") + ", Fecha Hasta: " + txtHasta.Value.ToString("dd/MM/yyyy"));
                    Filtro.Append(", Condicion Pago: " + txtCondicionPago.Text + ", NCF: " + txtTipoComprob.Text);
                }
                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);
                decimal importeSubTotal = 0;
                decimal importeItbis = 0;
                decimal importeTotal = 0;
                decimal importeGanancia = 0;
                foreach (DataRow item in dt.Rows)
                {
                    decimal.TryParse(item["SubTotal"].ToString(), out importeSubTotal);
                    this.precioVenta += importeSubTotal;
                    decimal.TryParse(item["Itbis"].ToString(), out importeItbis);
                    this.precioCompra += importeItbis;
                    decimal.TryParse(item["Total"].ToString(), out importeTotal);
                    this.totalImporte += importeTotal;
                    decimal.TryParse(item["TotalGanancia"].ToString(), out importeGanancia);
                    this.totalGanancia += importeGanancia;
                }
                ImprimirDevolucion(Filtro.ToString());


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
                ReportParameter[] paramCollection = new ReportParameter[7];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Actividad", empresa.Actividad, true);
                paramCollection[2] = new ReportParameter("Filtro", Filtro.ToString(), true);
                paramCollection[3] = new ReportParameter("SubTotal", precioVenta.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[4] = new ReportParameter("ItbisTotal", precioCompra.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[5] = new ReportParameter("TotalImporte", totalImporte.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[6] = new ReportParameter("TotalGanancia", totalGanancia.ToString("#,###.00;-#,###.00;0.00"), true);

                var tblUsuario = new TblUsuario();
                var getUsuario = new _Usuario_get();
                tblUsuario = getUsuario.GetById(IdUsuario);

                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetVentas", this.dt));
                if (tblUsuario.Categoria == "CAJERO")
                {
                    if (ValidarUsoNCF())
                    {
                        if (txtTipoComprob.SelectedIndex == 3 || txtTipoComprob.SelectedIndex == 4)
                        {
                            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptVentasNCFM.rdlc";
                        }
                        else
                        {
                            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptVentasNCF.rdlc";
                        }
                    }
                    else
                    {
                        frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptVentas.rdlc";
                    }
                }
                if (tblUsuario.Categoria == "ADMINISTRADOR" || tblUsuario.Categoria == "MASTER")
                {
                    if (ValidarUsoNCF())
                    {
                        if (txtTipoComprob.SelectedIndex == 3 || txtTipoComprob.SelectedIndex == 4)
                        {
                            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptVentasGananciasNCFM.rdlc";
                        }
                        else
                        {
                            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptVentasGananciasNCF.rdlc";
                        }
                    }
                    else
                    {
                        frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptVentasGanancias.rdlc";
                    }
                }
                frm.reportViewer1.LocalReport.SetParameters(paramCollection);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region ImprimirRptProducto
        private void ImprimirRptProducto(string Filtro, DataTable dt3)
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
                ReportParameter[] paramCollection = new ReportParameter[6];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Actividad", empresa.Actividad, true);
                paramCollection[2] = new ReportParameter("Filtro", Filtro.ToString(), true);
                paramCollection[3] = new ReportParameter("TotalCosto", precioCompra.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[4] = new ReportParameter("TotalVenta", precioVenta.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[5] = new ReportParameter("TotalGanancia", totalGanancia.ToString("#,###.00;-#,###.00;0.00"), true);

                var tblUsuario = new TblUsuario();
                var getUsuario = new _Usuario_get();
                tblUsuario = getUsuario.GetById(IdUsuario);

                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetVentas", dt3));
                frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptVentasProducto.rdlc";

                frm.reportViewer1.LocalReport.SetParameters(paramCollection);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region ImprimirDevolucion
        private void ImprimirDevolucion(string Filtro)
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
                paramCollection[3] = new ReportParameter("SubTotal", precioVenta.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[4] = new ReportParameter("ItbisTotal", precioCompra.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[5] = new ReportParameter("TotalImporte", totalImporte.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[6] = new ReportParameter("TotalGanancia", totalGanancia.ToString("#,###.00;-#,###.00;0.00"), true);

                var tblUsuario = new TblUsuario();
                var getUsuario = new _Usuario_get();
                tblUsuario = getUsuario.GetById(IdUsuario);

                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetVentas", this.dt));
                if (ValidarUsoNCF())
                {
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptDevolucionNCF.rdlc";
                }
                else
                {
                    frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Reportes.RptDevolucion.rdlc";
                }

                frm.reportViewer1.LocalReport.SetParameters(paramCollection);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region ValidarUsoNCF
        private bool ValidarUsoNCF()
        {
            try
            {
                var tbl = new TblMasterConfig();
                var get = new _MasterConfig_get();
                tbl = get.GetById(1);
                if (tbl.VentasNCF == "APLICADO")
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTipoBusqueda.SelectedIndex == 0)
                {
                    if(IdProducto > 0)
                    {
                        BuscarProducto();
                    }
                    else if(IdProveedor > 0)
                    {
                        BuscarProductoProveedor();
                    }
                    else if (IdCliente > 0)
                    {
                        BuscarVentasCliente();
                    }
                    else
                    {
                        Buscar();
                    }
                }
                else if (txtTipoBusqueda.SelectedIndex == 1)
                {
                    BuscarDevoluciones();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTipoBusqueda.SelectedIndex == 0)
                {
                    txtTipoComprob.Enabled = true;
                }
                else if (txtTipoBusqueda.SelectedIndex == 1)
                {
                    txtTipoComprob.Enabled = false;
                    txtTipoComprob.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                    txtTipoComprob.Enabled = false;

                    this.IdCliente = 0;
                    txtCliente.Text = string.Empty;
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
                txtTipoComprob.Enabled = true;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoCliente();
                form.ShowDialog();
                if (form.IdCliente > 0)
                {
                    this.IdCliente = form.IdCliente;
                    txtCliente.Text = form.Nombre;
                    txtTipoComprob.Enabled = false;

                    this.IdProveedor = 0;
                    txtProveedor.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnQuitarClieente_Click(object sender, EventArgs e)
        {
            try
            {
                this.IdCliente = 0;
                txtCliente.Text = string.Empty;
                txtTipoComprob.Enabled = true;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
