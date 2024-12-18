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
    public partial class FormListaRapida : Form
    {
        private int IdProductoList = 0;
        public FormListaRapida()
        {
            InitializeComponent();
        }

        private void FormListaRapida_Load(object sender, EventArgs e)
        {
            try
            {
                this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
                BuscarProductos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region BuscarProductos
        private void BuscarProductos()
        {
            try
            {
                dgv.Rows.Clear();
                var tbl = new List<TblListaRapida>();
                var get = new _ListaRapida_get();
                tbl = get.GetAll();
                foreach (var item in tbl)
                {
                  dgv.Rows.Add(item.IdProductoLista, item.Descripcion);
                }
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

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int.TryParse(dgv.CurrentRow.Cells[0].Value.ToString(), out this.IdProductoList);
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > 0 && e.RowIndex >= 0)
                {

                    if (e.ColumnIndex == 2)//ELIM
                    {
                        if (!string.IsNullOrEmpty(this.dgv.CurrentRow.Cells[0].Value.ToString()))
                        {

                            if (this.IdProductoList > 0)
                            {
                                if(MessageBox.Show("Confirme que desea eliminar este producto de la lista?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    _ListaRapida.Delete(this.IdProductoList);
                                    BuscarProductos();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void dgv_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                    this.Cursor = Cursors.Hand;
                else
                    this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
