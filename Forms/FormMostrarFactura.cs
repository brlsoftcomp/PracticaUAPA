using BRL_SVentas.Model;
using BRL_SVentas.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRL_SVentas
{
    public partial class FormMostrarFactura : Form
    {
        public int IdFactura = 0;
        public int IdCompra = 0;
        public int IdUsuario = 0;
        public string Modulo = string.Empty;
        public string Cliente = string.Empty;

        public FormMostrarFactura()
        {
            InitializeComponent();
        }

        private void FormMostrarFactura_Load(object sender, EventArgs e)
        {
            try
            {
                if (Modulo == "CXC")
                {
                    BuscarFactura();
                    BuscarDetalle();
                    BuscarUsuario();
                    txtCliente.Text = Cliente;
                }
                else if(Modulo == "CXP")
                {
                    BuscarCompra();
                    BuscarDetalleCompra();
                    label5.Text = "Nombre Proveedor: ";
                    txtCliente.Text = Cliente;
                    label8.Visible = false;
                    txtVendedor.Visible = false;
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
                    txtVendedor.Text = tbl.Nombre;
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
                        dgv.Rows.Add(item["IdProducto"].ToString(), item["Codigo"].ToString(), item["Nombre"].ToString(), item["CantidadFacturada"].ToString(), item["PrecioFacturado"].ToString(), item["MontoFacturado"].ToString(), item["Ganancia"].ToString());
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

        #region BuscarCompra
        private void BuscarCompra()
        {
            try
            {
                var tbl = new TblCompra();
                var get = new _Compra_get();
                tbl = get.GetById(this.IdCompra);

                this.IdUsuario = tbl.IdUsuario;
                txtNoFactura.Text = tbl.NoFactura.ToString();
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

        #region BuscarDetalleCompra
        private void BuscarDetalleCompra()
        {
            try
            {
                var MiConexion = new Conexion();
                var builder = new StringBuilder();
                var dt = new DataTable();
                builder.Append("SELECT IdCompraDetalle, IdCompra, TblCompraDetalle.IdProducto, TblProducto.Codigo, TblProducto.Nombre, Cantidad, Precio, Monto FROM TblCompraDetalle JOIN TblProducto on TblProducto.IdProducto =  TblCompraDetalle.IdProducto WHERE IdCompra = '" + this.IdCompra + "'");
                dt = MiConexion.BuscarTabla(builder);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        dgv.Rows.Add(item["IdProducto"].ToString(), item["Codigo"].ToString(), item["Nombre"].ToString(), item["Cantidad"].ToString(), item["Precio"].ToString(), item["Monto"].ToString());
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
    }
}
