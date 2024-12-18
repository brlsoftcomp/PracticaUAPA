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
    public partial class FormCatalogoBanco : Form
    {
        public bool server = false;
        public string texto = string.Empty;
        private bool salirAceptar = false;
        DataTable dt = new DataTable();

        #region DATOS
        public int IdBanco { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        #endregion
        public FormCatalogoBanco()
        {
            InitializeComponent();
        }

        #region BuscarBanco
        private void BuscarBanco()
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblBanco WHERE IdBanco >= 1");
                var conexion = new Conexion();
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
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text.Length > 0 && dgv.DataSource != null)
                {
                    (dgv.DataSource as DataTable).DefaultView.RowFilter = "Convert([Codigo], System.String) like'%" + txtBuscar.Text + "%'" + " OR Nombre like'%" + txtBuscar.Text + "%'";
                }
                else
                {
                    BuscarBanco();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormCatalogoBanco_Load(object sender, EventArgs e)
        {
            try
            {
                this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
                txtBuscar.Text = texto;
                BuscarBanco();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.dgv.CurrentRow.Cells[0].Value.ToString()))
                {
                    int valor = 0;
                    int.TryParse(dgv.CurrentRow.Cells[0].Value.ToString(), out valor);
                    this.IdBanco = valor;
                    int.TryParse(dgv.CurrentRow.Cells[1].Value.ToString(), out valor);
                    this.Codigo = valor;
                    Nombre = dgv.CurrentRow.Cells[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdBanco != 0)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.IdBanco = 0;
            this.Close();
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

        private void FormCatalogoBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(string.IsNullOrEmpty(this.Nombre))
            this.IdBanco = 0;
        }
    }
}
