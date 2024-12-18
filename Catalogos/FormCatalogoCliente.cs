using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRL_SVentas.Servicios;

namespace BRL_SVentas.Catalogos
{
    public partial class FormCatalogoCliente : Form
    {    
        public string texto = string.Empty;
        private bool salirAceptar = false;
        DataTable dt = new DataTable();

        #region DATOS
        public int IdCliente { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Tipo { get; set; }
        #endregion
        public FormCatalogoCliente()
        {
            InitializeComponent();
        }

        private void FormCatalogoCliente_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
            txtBuscar.Text = texto;
            BuscarCliente();
        }

        #region BuscarCliente
        private void BuscarCliente()
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCliente WHERE IdCliente > 1");
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

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text.Length > 0 && dgv.DataSource != null)
                {
                    (dgv.DataSource as DataTable).DefaultView.RowFilter = "Convert([Codigo], System.String) like'%" + txtBuscar.Text + "%'" + " OR Nombre like'%" + txtBuscar.Text + "%'";
                }
                else
                {
                    BuscarCliente();
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
                    int.TryParse(dgv.CurrentRow.Cells[0].Value.ToString(), out valor);
                    this.IdCliente = valor;
                    int.TryParse(dgv.CurrentRow.Cells[1].Value.ToString(), out valor);
                    this.Codigo = valor;
                    Cedula = dgv.CurrentRow.Cells[2].Value.ToString();
                    Nombre = dgv.CurrentRow.Cells[3].Value.ToString();
                    Telefono = dgv.CurrentRow.Cells[4].Value.ToString();
                    Direccion = dgv.CurrentRow.Cells[5].Value.ToString();                   
                    Telefono2 = dgv.CurrentRow.Cells[6].Value.ToString();
                    Tipo = dgv.CurrentRow.Cells[7].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.IdCliente = 0;
            this.Close();
        }

        private void FormCatalogoCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if(!salirAceptar)
                    this.IdCliente = 0;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (IdCliente != 0)
            {
                salirAceptar = true;
                this.Close();
            }
            else
            {
                AVISOI("Para Aceptar primero debe seleccionar un producto.");
            }
        }

        private void FormCatalogoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.IdCliente = 0;
                this.Close();
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
