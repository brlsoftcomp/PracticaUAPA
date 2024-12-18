using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BRL_SVentas.Model;
using BRL_SVentas.Servicios;

namespace BRL_SVentas.Catalogos
{
    public partial class FormCatalogoAjusteInventario : Form
    {
        public String articulos_selecionado;

        public bool seleccionado = false;
        private bool cerrarEnter = false;

        public string codigo { get; set; }
        public string usuario { get; set; }
        public string nota { get; set; }

        public FormCatalogoAjusteInventario()
        {
            InitializeComponent();
        }
        private void FormCatalogoAjusteInventario_Load(object sender, EventArgs e)
        {
            try
            {
                this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
                                       //Ajusta el tamano del a tabla al Datagriview:
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                BuscarFecha();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }

        }

        #region BuscarFecha
        private void BuscarFecha()
        {
            try
            {
                dgv.Rows.Clear();
                var tbl = new List<TblHistAjusteInventario>();
                var get = new _HistAjusteInventario_get();
                tbl = get.GetByFiltradoFecha(txtFechaDesde.Value, txtFechaHasta.Value);
                foreach (var item in tbl)
                {
                    dgv.Rows.Add(item.Fecha, item.IdHistAjustInventario, item.Codigo, item.NombreUsuario, item.Nota);
                }
                dgv.ClearSelection();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(dgv.CurrentRow.Cells[1].Value.ToString()))
                {
                    codigo = dgv.CurrentRow.Cells[1].Value.ToString();
                    nota = dgv.CurrentRow.Cells[4].Value.ToString();
                    txtNota.Text = nota;
                    seleccionado = true;
                }

                else
                {
                    //Limpiar el cargado de registro:
                    codigo = string.Empty;
                    seleccionado = false;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgv.Rows.Clear();
                var tbl = new List<TblHistAjusteInventario>();
                var get = new _HistAjusteInventario_get();
                string texto = txtBuscar.Text;
                tbl = get.GetByFiltrado(texto);
                if (!string.IsNullOrEmpty(txtBuscar.Text) && tbl != null)
                {
                    foreach (var item in tbl)
                    {
                        dgv.Rows.Add(item.Fecha, item.IdHistAjustInventario, item.Codigo, item.NombreUsuario, item.Nota);
                    }
                }
                dgv.ClearSelection();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormCatalogoAjusteInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Limpiar el cargado de registro:
            if (!cerrarEnter)
            {
                codigo = string.Empty;
                seleccionado = false;
            }
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void FormCatalogoAjusteInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cerrarEnter = false;
                this.Close();
            }
        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (seleccionado)
                {
                    //e.SuppressKeyPress = true;
                    cerrarEnter = true;
                    this.Close();
                }
                else
                {
                    AVISOW("DEBE SELECCIONAR UN REGISTRO.");
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (seleccionado)
            {
                cerrarEnter = true;
                this.Close();
            }
            else
            {
                AVISOW("DEBE SELECCIONAR UN REGISTRO.");
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
    }
}
