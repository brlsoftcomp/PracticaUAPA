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

namespace BRL_SVentas.Catalogos
{
    public partial class FormCatalogoCompras : Form
    {
        public string texto = string.Empty;
        private bool salirAceptar = false;
        public FormCatalogoCompras()
        {
            InitializeComponent();
        }

        private void FormCatalogoCompras_Load(object sender, EventArgs e)
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


        #region DATOS
        public int IdCompra { get; set; }
        public int Idproveedor { get; set; }
        public string NoFactura { get; set; }
        public string Proveedor { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; }
        #endregion

        #region Buscar
        private void Buscar()
        {
            try
            {
                dgv.Rows.Clear();
                var Miconexion = new Conexion();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT *, TblProveedor.IdProveedor As idProveedor, TblProveedor.Nombre FROM TblCompra JOIN TblProveedor ON TblProveedor.IdProveedor = TblCompra.IdProveedor"));
                builder.Append(string.Format(" WHERE IdCompra LIKE '" + txtBuscar.Text + "' + '%' or NoFactura LIKE '" + txtBuscar.Text + "' + '%' or TblProveedor.Nombre LIKE '" + txtBuscar.Text + "' + '%'"));
                builder.Append(string.Format(" ORDER BY Fecha DESC"));
                dt = Miconexion.BuscarTabla(builder);
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        dgv.Rows.Add(item["IdCompra"].ToString(), item["idProveedor"].ToString(), item["Fecha"], item["NoFactura"].ToString(), item["Nombre"].ToString(), item["CondicionCompra"].ToString(), item["Total"].ToString());
                    }
                    dgv.ClearSelection();
                }
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
                var Miconexion = new Conexion();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT *, TblProveedor.IdProveedor As idProveedor, TblProveedor.Nombre FROM TblCompra JOIN TblProveedor ON TblProveedor.IdProveedor = TblCompra.IdProveedor"));
                builder.Append(string.Format(" WHERE Fecha >='" + ClassFecha.GetFecha(txtFechaDesde.Value, 1) + "' AND Fecha <= '" + ClassFecha.GetFecha(txtFechaHasta.Value, 2) + "'"));
                builder.Append(string.Format(" ORDER BY Fecha DESC"));
                dt = Miconexion.BuscarTabla(builder);
                foreach (DataRow item in dt.Rows)
                {
                    dgv.Rows.Add(item["IdCompra"].ToString(), item["idProveedor"].ToString(), item["Fecha"], item["NoFactura"].ToString(), item["Nombre"].ToString(), item["CondicionCompra"].ToString(), item["Total"].ToString());
                }
                dgv.ClearSelection();
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

        private void FormCatalogoCompras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.IdCompra = 0;
                this.Close();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (IdCompra != 0)
            {
                salirAceptar = true;
                this.Close();
            }
            else
            {
                AVISOI("Para Aceptar primero debe seleccionar un producto.");
            }
        }

        private void FormCatalogoCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!salirAceptar)
                    this.IdCompra = 0;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.IdCompra = 0;
            this.Close();
        }

        private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.dgv.CurrentRow.Cells[1].Value.ToString()))
                {
                    int valor = 0;
                    decimal valorDecimal = 0;
                    int.TryParse(dgv.CurrentRow.Cells[0].Value.ToString(), out valor);
                    this.IdCompra = valor;
                    int.TryParse(dgv.CurrentRow.Cells[1].Value.ToString(), out valor);
                    this.Idproveedor = valor;
                    this.NoFactura = dgv.CurrentRow.Cells[3].Value.ToString();
                    this.Concepto = dgv.CurrentRow.Cells[4].Value.ToString();
                    decimal.TryParse(dgv.CurrentRow.Cells[5].Value.ToString(), out valorDecimal);
                    this.Monto = valorDecimal;
                    this.Proveedor = dgv.CurrentRow.Cells[6].Value.ToString();
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
    }
}
