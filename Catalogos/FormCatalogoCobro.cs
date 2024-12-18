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
    public partial class FormCatalogoCobro : Form
    {
        public string nombreCliente = string.Empty;
        public int IdCobro = 0;
        public int Codigo = 0;
        private bool salirAceptar = false;
        public FormCatalogoCobro()
        {
            InitializeComponent();
        }

        private void FormCatalogoCobro_Load(object sender, EventArgs e)
        {
            try
            {
                GetAll();
                this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
            }
            catch (Exception)
            {

                throw;
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

        #region GetAll
        private void GetAll()
        {
            try
            {
                var MiConexion = new Conexion();
                TblCobro Objeto = new TblCobro();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT dbo.TblCobro.*,dbo.TblCliente.Nombre FROM dbo.TblCobro ");
                builder.Append("INNER JOIN dbo.TblCxC ");
                builder.Append("ON dbo.TblCobro.IdCxC = dbo.TblCxC.IdCxC ");
                builder.Append("INNER JOIN dbo.TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente ");
                builder.Append("ORDER BY TblCobro.Fecha DESC ");
                dt = MiConexion.BuscarTabla(builder);
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = dt;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.dgv.CurrentRow.Cells[0].Value.ToString()))
                {
                    int.TryParse(dgv.CurrentRow.Cells[0].Value.ToString(), out this.IdCobro);
                    int.TryParse(dgv.CurrentRow.Cells[1].Value.ToString(), out this.Codigo);
                    this.nombreCliente = dgv.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.IdCobro = 0;
            this.Codigo = 0;
            this.Close();
        }

        private void FormCatalogoCobro_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!salirAceptar)
                {
                    this.IdCobro = 0;
                    this.Codigo = 0;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.IdCobro != 0 && this.Codigo != 0)
            {
                salirAceptar = true;
                this.Close();
            }
            else
            {
                AVISOI("Para Aceptar primero debe seleccionar un producto.");
            }
        }

        private void FormCatalogoCobro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.IdCobro = 0;
                this.Codigo = 0;
                this.Close();
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text.Length > 0)
                {
                  (dgv.DataSource as DataTable).DefaultView.RowFilter = "Nombre like'%" + txtBuscar.Text + "%'" + " OR Convert([Codigo], System.String) like'%" + txtBuscar.Text + "%'";
                }
                else
                {
                    GetAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
