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
    public partial class FormCatalogoGasto : Form
    {
        public string texto = string.Empty;
        private bool salirAceptar = false;
        public FormCatalogoGasto()
        {
            InitializeComponent();
        }

        private void FormCatalogoGasto_Load(object sender, EventArgs e)
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
        public int IdGasto { get; set; }
        public int IdProveedor { get; set; }
        public int Codigo { get; set; }
        public int RNC { get; set; }
        public int NoFactura { get; set; }
        public string Proveedor { get; set; }
        public string NCF { get; set; }
        public decimal Itbis { get; set; }
        public decimal SubTotal { get; set; }
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
                builder.Append("SELECT TblGasto.*, TblProveedor.Nombre, TblProveedor.RNC FROM TblGasto");
                builder.Append(" JOIN TblProveedor ON TblProveedor.IdProveedor = TblGasto.IdProveedor");
                builder.Append(" WHERE TblProveedor.Nombre LIKE '" + txtBuscar.Text + "' + '%'");
                builder.Append(" ORDER BY Fecha DESC");
                dt = Miconexion.BuscarTabla(builder);
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        dgv.Rows.Add(item["IdGasto"].ToString(), item["IdProveedor"].ToString(), item["Fecha"], item["Codigo"].ToString(), item["NCF"].ToString(), item["Concepto"].ToString(), item["Nombre"].ToString(), item["RNC"].ToString(), item["SubTotal"].ToString(), item["Itbis"].ToString(), item["Monto"].ToString());
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
                builder.Append("SELECT TblGasto.*, TblProveedor.Nombre, TblProveedor.RNC FROM TblGasto");
                builder.Append(" JOIN TblProveedor ON TblProveedor.IdProveedor = TblGasto.IdProveedor WHERE");
                //builder.Append(" TblGasto.Fecha >= '" + ClassFecha.GetFechaUSA(txtFechaDesde.Value, 1) + "'");
                //builder.Append(" AND TblGasto.Fecha <= '" + ClassFecha.GetFechaUSA(txtFechaHasta.Value, 2) + "'");
                builder.Append(" TblGasto.Fecha >='" + ClassFecha.GetFecha(txtFechaDesde.Value, 1) + "' AND TblGasto.Fecha <= '" + ClassFecha.GetFecha(txtFechaHasta.Value, 2) + "'");
                builder.Append(" ORDER BY TblGasto.Fecha DESC");
                dt = Miconexion.BuscarTabla(builder);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        dgv.Rows.Add(item["IdGasto"].ToString(), item["IdProveedor"].ToString(), item["Fecha"], item["Codigo"].ToString(), item["NCF"].ToString(), item["Concepto"].ToString(), item["Nombre"].ToString(), item["RNC"].ToString(), item["SubTotal"].ToString(), item["Itbis"].ToString(), item["Monto"].ToString(), item["NoFactura"].ToString(), item["Nota"].ToString());
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

        private void FormCatalogoGasto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.IdGasto = 0;
                this.Close();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (IdGasto != 0)
            {
                salirAceptar = true;
                this.Close();
            }
            else
            {
                AVISOI("Para Aceptar primero debe seleccionar un producto.");
            }
        }

        private void FormCatalogoGasto_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!salirAceptar)
                    this.IdGasto = 0;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.IdGasto = 0;
            this.Close();
        }

        private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.dgv.CurrentRow.Cells[0].Value.ToString()))
                {
                    int valor = 0;
                    decimal valorDecimal = 0;
                    int.TryParse(dgv.CurrentRow.Cells[0].Value.ToString(), out valor);
                    IdGasto = valor;
                    int.TryParse(dgv.CurrentRow.Cells[1].Value.ToString(), out valor);
                    IdProveedor = valor;
                    int.TryParse(dgv.CurrentRow.Cells[3].Value.ToString(), out valor);
                    Codigo = valor;
                    NCF = dgv.CurrentRow.Cells[4].Value.ToString();
                    Concepto = dgv.CurrentRow.Cells[5].Value.ToString();
                    Proveedor = dgv.CurrentRow.Cells[6].Value.ToString();
                    int.TryParse(dgv.CurrentRow.Cells[7].Value.ToString(), out valor);
                    RNC = valor;
                    decimal.TryParse(dgv.CurrentRow.Cells[8].Value.ToString(), out valorDecimal);
                    SubTotal = valorDecimal;
                    decimal.TryParse(dgv.CurrentRow.Cells[9].Value.ToString(), out valorDecimal);
                    Itbis = valorDecimal;
                    decimal.TryParse(dgv.CurrentRow.Cells[10].Value.ToString(), out valorDecimal);
                    Monto = valorDecimal;
                    int.TryParse(dgv.CurrentRow.Cells[11].Value.ToString(), out valor);
                    NoFactura = valor;

                    txtNota.Text = dgv.CurrentRow.Cells[12].Value.ToString();
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
