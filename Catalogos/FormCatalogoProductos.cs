using BRL_SVentas.Model;
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
    public partial class FormCatalogoProductos : Form
    {
        private bool salirAceptar = false;
        DataTable dt;
        public FormCatalogoProductos()
        {
            InitializeComponent();
        }

        private void FormCatalogoProductos_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
            BuscarProductos();
        }

        #region BuscarProductos
        private void BuscarProductos()
        {
            try
            {
                var builder = new StringBuilder();
                if (this.IdProveedor > 0)
                {
                    builder.Append("SELECT IdProducto, IdProveedor, Codigo, Nombre, PrecioVenta, PrecioMinimo, CantidadExistente FROM TblProducto WHERE IdProveedor = '" + this.IdProveedor + "'");
                }
                else
                {
                    builder.Append("SELECT IdProducto, IdProveedor, Codigo, Nombre, PrecioVenta, PrecioMinimo, CantidadExistente FROM TblProducto");
                }
                var conexion = new Conexion();
                this.dt = new DataTable();
                this.dt = conexion.BuscarTabla(builder);
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = this.dt;
                dgv.ClearSelection();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region DatosProducto
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int codigo { get; set; }
        public decimal Costo { get; set; }
        public string descripcion { get; set; }
        public decimal precioMinimo { get; set; }
        public decimal precioVenta { get; set; }
        public int cantidad { get; set; }
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
                if (txtBuscar.Text.Length > 0 && dgv.DataSource != null)
                {
                    if ((dgv.DataSource as DataTable).DefaultView.Count > 0)
                    {
                        (dgv.DataSource as DataTable).DefaultView.RowFilter = "Convert([Codigo], System.String) like'%" + txtBuscar.Text + "%'";
                    }
                    else
                    {
                        (dgv.DataSource as DataTable).DefaultView.RowFilter = "Nombre like'%" + txtBuscar.Text + "%'";
                    }
                }
                if (string.IsNullOrEmpty(txtBuscar.Text))
                {
                    BuscarProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.dgv.CurrentRow.Cells[0].Value.ToString()))
                {
                    int valor = 0;
                    decimal valor2 = 0;
                    int.TryParse(dgv.CurrentRow.Cells[0].Value.ToString(), out valor);
                    Id = valor;
                    int.TryParse(dgv.CurrentRow.Cells[1].Value.ToString(), out valor);
                    codigo = valor;
                    descripcion = dgv.CurrentRow.Cells[2].Value.ToString();
                    int.TryParse(dgv.CurrentRow.Cells[3].Value.ToString(), out valor);
                    cantidad = valor;
                    decimal.TryParse(dgv.CurrentRow.Cells[4].Value.ToString(), out valor2);
                    precioMinimo = valor2;
                    decimal.TryParse(dgv.CurrentRow.Cells[5].Value.ToString(), out valor2);
                    precioVenta = valor2;
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
                Id = 0;
                IdProveedor = 0;
                codigo = 0;
                descripcion = string.Empty;
                cantidad = 0;
                precioMinimo = 0;
                precioVenta = 0;
                salirAceptar = false;
                this.Close();
            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Id != 0)
                {
                    salirAceptar = true;
                    this.Close();
                }
                else
                {
                    AVISOI("Para Aceptar primero debe seleccionar un producto.");
                }
            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }

        }
        private void FormCatalogoProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Id = 0;
                IdProveedor = 0;
                codigo = 0;
                descripcion = string.Empty;
                cantidad = 0;
                precioMinimo = 0;
                precioVenta = 0;
                this.Close();
            }
        }
        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnAceptar.Focus();
            }
        }

        private void FormCatalogoProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (!salirAceptar)
                {
                    Id = 0;
                    IdProveedor = 0;
                    codigo = 0;
                    descripcion = string.Empty;
                    cantidad = 0;
                    precioMinimo = 0;
                    precioVenta = 0;
                }
                this.Close();
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
    }
}
