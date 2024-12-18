using BRL_SVentas.Catalogos;
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

namespace BRL_SVentas.Forms
{
    public partial class FormCxC : Form
    {
        DataTable dt = new DataTable();
        int IdCliente = 0;
        int IdCxC = 0;
        public FormCxC()
        {
            InitializeComponent();
        }

        private void FormCxC_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
            Buscar();
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

        #region Buscar
        private void Buscar()
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("SELECT SUM(Balance) as Balance, TblCxC.IdCliente, TblCliente.Nombre FROM TblCxC");
                builder.Append(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente");
                builder.Append(" WHERE TblCxC.Estado != 'ANULADA' AND Balance > 0 group by TblCxC.IdCliente, TblCliente.Nombre");
                var conexion = new Conexion();
                this.dt = conexion.BuscarTabla(builder);
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = this.dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private void TxtBuscarCuenta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtBuscarCuenta.Text))
                {
                    (dgv.DataSource as DataTable).DefaultView.RowFilter = "Nombre LIKE '%" + txtBuscarCuenta.Text + "%'";
                }
                else
                {
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void BtnAbonar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.IdCxC > 0)
                //{
                //    var tbl = new TblCxC();
                //    var get = new _CxC_get();
                //    tbl = get.GetById(this.IdCxC);
                //    if (tbl.Estado != "SALDA")
                //    {
                //        var form = new FormCobrarCxC();
                //        form.IdCxC = codigo;
                //        form.txtCodigo.Text = codigo.ToString();
                //        form.txtNombre.Text = NombreCliente;
                //        form.txtBalance.Text = Balance.ToString("#,###.00;-#,###.00;0.00");
                //        form.txtMonto.Text = Monto.ToString("#,###.00;-#,###.00;0.00");
                //        form.ShowDialog();
                //        BuscarCxC();
                //    }
                //    else
                //    {
                //        AVISOW("No se puede aplicar cobros a una cuenta Salda!");
                //        return;
                //    }
                //}
                //else
                //{
                //    AVISOI("Para aplicar pagos primero debe selecionar una Cuenta por Cobrar.");
                //    return;
                //}
            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormRegCxC();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnVerHist_Click(object sender, EventArgs e)
        {
            try
            {
                //if(this.IdCxC <= 0)
                //{
                //    AVISOW("Primero debe seleccionar una Cuenta para ver el Historial de Pagos.");
                //    return;
                //}
                //var form = new FormHistCobros();
                //form.IdCxC = this.IdCxC;
                //form.txtCodigo.Text = this.IdCxC.ToString();
                //form.txtCliente.Text = txtNombre.Text;
                //form.ShowDialog();
            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }
        }

        private void TxtBuscarCuenta_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 4)
                    {
                        int.TryParse(dgv.CurrentRow.Cells["colIdCliente"].Value.ToString(), out this.IdCliente);

                        if (this.IdCliente > 1)
                        {
                            var form = new FormCobrarCxC();
                            form.IdCliente = this.IdCliente;
                            form.IdCxC = this.IdCxC;
                            form.txtNombre.Text = dgv.CurrentRow.Cells["colNombre"].Value.ToString();
                            form.ShowDialog();
                            Buscar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgv_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                    this.Cursor = Cursors.Hand;
                else
                    this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscarRecibo_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCobrarCxC();
                form.IdCliente = 0;
                form.IdCxC = 0;
                form.txtNombre.Text = string.Empty;
                form.txtCodigo.Enabled = true;
                form.btnBuscar.Enabled = true;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormCxC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F1)
                {
                    var form = new FormCobrarCxC();
                    form.IdCliente = 0;
                    form.IdCxC = 0;
                    form.txtNombre.Text = string.Empty;
                    form.txtCodigo.Enabled = true;
                    form.btnBuscar.Enabled = true;
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
