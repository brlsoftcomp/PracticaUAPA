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
    public partial class FormCatalogoFacturas : Form
    {
        public bool buscarTodo = false;
        private bool salirAceptar = false;
        public FormCatalogoFacturas()
        {
            InitializeComponent();
        }

        private void FormCatalogoFacturas_Load(object sender, EventArgs e)
        {
            try
            {
                if (!buscarTodo)
                {
                    label1.Text = "          Lista de Facturas";
                    rbtnCotizacion.Enabled = false;
                    rbtnFactura.Checked = true;
                    rbtnFactura.Enabled = false;
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

        #region Limpiar
        public void Limpiar()
        {
            try
            {
                this.IdFactura = 0;
                Nombre = string.Empty;
                Nota = string.Empty;
                CondicionPago = string.Empty;
                txtBuscar.Text = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region DATOS
        public int IdFactura { get; set; }
        public int IdCotizacion { get; set; }
        public int IdCliente { get; set; }
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string NCF { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Nota { get; set; }
        public string CondicionPago { get; set; }
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

        #region Buscar
        private void Buscar()
        {
            try
            {
                if (rbtnFactura.Checked)
                {
                    dgv.Rows.Clear();
                    this.IdFactura = 0;
                    this.IdCotizacion = 0;
                    string texto = txtBuscar.Text;
                    var Miconexion = new Conexion();
                    var dt = new DataTable();
                    var builder = new StringBuilder();
                    if (ValidarUsoNCF())
                    {
                        builder.Append("SELECT TblFactura.IdFactura, IdUsuario, TblFactura.IdCliente, TblFactura.Codigo, Fecha, TblCompFiscalSecuencia.NCF, TblCliente.Nombre, TblCliente.Cedula, CondicionPago, Total, Nota FROM TblFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" JOIN TblCompFiscalSecuencia ON TblCompFiscalSecuencia.IdFactura = TblFactura.IdFactura");
                        builder.Append(" WHERE TblFactura.Codigo LIKE '" + texto + "' + '%' OR TblCliente.Nombre LIKE '" + texto + "' + '%' ORDER BY Fecha DESC");
                        dt = Miconexion.BuscarTabla(builder);
                        if (!string.IsNullOrEmpty(txtBuscar.Text) && dt.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dt.Rows)
                            {
                                dgv.Rows.Add(reader["Fecha"], reader["IdFactura"].ToString(), reader["Codigo"].ToString(), reader["Nombre"].ToString(), reader["CondicionPago"].ToString(), reader["Total"].ToString(), reader["Nota"].ToString(), reader["IdCliente"].ToString(), reader["NCF"].ToString());
                            }
                        }
                    }
                    else
                    {
                        builder.Append("SELECT TblFactura.IdFactura, IdUsuario, TblFactura.IdCliente, TblFactura.Codigo, Fecha, TblCliente.Nombre, TblCliente.Cedula, CondicionPago, Total, Nota FROM TblFactura");
                        builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblFactura.IdCliente");
                        builder.Append(" WHERE TblFactura.Codigo LIKE '" + texto + "' + '%' OR TblCliente.Nombre LIKE '" + texto + "' + '%' ORDER BY Fecha DESC");
                        dt = Miconexion.BuscarTabla(builder);
                        if (!string.IsNullOrEmpty(txtBuscar.Text) && dt.Rows.Count > 0)
                        {
                            foreach (DataRow reader in dt.Rows)
                            {
                                dgv.Rows.Add(reader["Fecha"], reader["IdFactura"].ToString(), reader["Codigo"].ToString(), reader["Nombre"].ToString(), reader["CondicionPago"].ToString(), reader["Total"].ToString(), reader["Nota"].ToString(), reader["IdCliente"].ToString(), "");
                            }
                        }                         
                    }
                    dgv.ClearSelection();
                }
                else
                {
                    dgv.Rows.Clear();
                    this.IdFactura = 0;
                    this.IdCotizacion = 0;
                    string texto = txtBuscar.Text;
                    var Miconexion = new Conexion();
                    var dt = new DataTable();
                    var builder = new StringBuilder();
                    builder.Append("SELECT IdCotizacion, IdUsuario, TblCotizacion.IdCliente, TblCotizacion.Codigo, Fecha, TblCliente.Nombre, Total, Nota FROM TblCotizacion");
                    builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCotizacion.IdCliente");
                    builder.Append(" WHERE TblCotizacion.Codigo LIKE '" + texto + "' + '%' OR TblCliente.Nombre LIKE '" + texto + "' + '%' ORDER BY Fecha DESC");
                    dt = Miconexion.BuscarTabla(builder);
                    if (!string.IsNullOrEmpty(txtBuscar.Text) && dt.Rows.Count > 0)
                    {
                        foreach (DataRow reader in dt.Rows)
                        {
                            dgv.Rows.Add(reader["Fecha"], reader["IdCotizacion"].ToString(), reader["Codigo"].ToString(), reader["Nombre"].ToString(), null, reader["Total"].ToString(), reader["Nota"].ToString(), reader["IdCliente"].ToString());
                        }
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

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.IdFactura > 0)
                {
                    salirAceptar = true;
                    this.Close();
                }
                else if (this.IdCotizacion > 0)
                {
                    salirAceptar = true;
                    this.Close();
                }
                else
                {
                    AVISOI("Para poder cargar un registro primero debe seleccionar uno.");
                    return;
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
                txtBuscar.Text = string.Empty;
                this.Close();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormCatalogoFacturas_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if(!salirAceptar)
                this.IdFactura = 0;
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

        private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (rbtnFactura.Checked)
                {
                    if (this.dgv.CurrentRow.Cells[1].Value != null)
                    {
                        int valor = 0;
                        DateTime fecha;
                        DateTime.TryParse(dgv.CurrentRow.Cells[0].Value.ToString(), out fecha);
                        Fecha = fecha;
                        int.TryParse(dgv.CurrentRow.Cells[1].Value.ToString(), out valor);
                        this.IdFactura = valor;
                        int.TryParse(dgv.CurrentRow.Cells[2].Value.ToString(), out valor);
                        this.Codigo = valor;
                        int.TryParse(dgv.CurrentRow.Cells[7].Value.ToString(), out valor);
                        this.IdCliente = valor;
                        Nombre = dgv.CurrentRow.Cells[3].Value.ToString();
                        CondicionPago = dgv.CurrentRow.Cells[4].Value.ToString();
                        Nota = dgv.CurrentRow.Cells[6].Value.ToString();
                        this.NCF = dgv.CurrentRow.Cells[8].Value.ToString();
                    }
                }
                else
                {
                    if (this.dgv.CurrentRow.Cells[1].Value != null)
                    {
                        int valor = 0;
                        DateTime fecha;
                        DateTime.TryParse(dgv.CurrentRow.Cells[0].Value.ToString(), out fecha);
                        Fecha = fecha;
                        int.TryParse(dgv.CurrentRow.Cells[1].Value.ToString(), out valor);
                        this.IdCotizacion = valor;
                        int.TryParse(dgv.CurrentRow.Cells[2].Value.ToString(), out valor);
                        this.Codigo = valor;
                        int.TryParse(dgv.CurrentRow.Cells[7].Value.ToString(), out valor);
                        this.IdCliente = valor;
                        Nombre = dgv.CurrentRow.Cells[3].Value.ToString();
                        Nota = dgv.CurrentRow.Cells[6].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void RbtnFactura_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnFactura.Checked)
                {
                    this.IdCotizacion = 0;
                    txtBuscar.Text = string.Empty;
                    dgv.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void RbtnCotizacion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnCotizacion.Checked)
                {
                    this.IdFactura = 0;
                    txtBuscar.Text = string.Empty;
                    dgv.Rows.Clear();
                }
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
