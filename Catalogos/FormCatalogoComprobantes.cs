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
    public partial class FormCatalogoComprobantes : Form
    {
        public int IdConfComprobante = 0;
        bool salirAceptar = false;
        public FormCatalogoComprobantes()
        {
            InitializeComponent();
        }

        private void FormCatalogoComprobantes_Load(object sender, EventArgs e)
        {
            try
            {
                GetComprobantesByFecha();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        #region GetComprobantes
        private void GetComprobantes()
        {
            try
            {
                dataGridView1.Rows.Clear();
                Conexion Miconexion = new Conexion();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT TblCompFiscalConf.IdConfComprobante, TblCompFiscalConf.IdCompFiscal, TblCompFiscalConf.Fecha,");
                builder.Append(" TblCompFiscal.Tipo, TblCompFiscalConf.Desde, TblCompFiscalConf.Hasta, TblCompFiscalConf.Cantidad");
                builder.Append(" FROM TblCompFiscalConf JOIN TblCompFiscal ON TblCompFiscal.IdCompFiscal = TblCompFiscalConf.IdCompFiscal");
                builder.Append(" WHERE TblCompFiscal.Tipo LIKE '" + txtTipoComprobante.Text + "' + '%'");
                builder.Append(" ORDER BY TblCompFiscalConf.Fecha DESC");
                dt = Miconexion.BuscarTabla(builder);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        dataGridView1.Rows.Add(item["IdConfComprobante"].ToString(), item["IdCompFiscal"].ToString(), item["Fecha"], item["Tipo"].ToString(), item["Desde"].ToString(), item["Hasta"].ToString(), item["Cantidad"].ToString());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region GetComprobantesByFecha
        private void GetComprobantesByFecha()
        {
            try
            {
                dataGridView1.Rows.Clear();
                Conexion Miconexion = new Conexion();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT TblCompFiscalConf.IdConfComprobante, TblCompFiscalConf.IdCompFiscal, TblCompFiscalConf.Fecha,");
                builder.Append(" TblCompFiscal.Tipo, TblCompFiscalConf.Desde, TblCompFiscalConf.Hasta, TblCompFiscalConf.Cantidad");
                builder.Append(" FROM TblCompFiscalConf JOIN TblCompFiscal ON TblCompFiscal.IdCompFiscal = TblCompFiscalConf.IdCompFiscal");
                builder.Append(" WHERE Fecha >='" + ClassFecha.GetFecha(txtFechaDesde.Value, 1) + "' AND Fecha <= '" + ClassFecha.GetFecha(txtFechaHasta.Value, 2) + "'");
                builder.Append(" ORDER BY TblCompFiscalConf.IdCompFiscal");
                dt = Miconexion.BuscarTabla(builder);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        dataGridView1.Rows.Add(item["IdConfComprobante"].ToString(), item["IdCompFiscal"].ToString(), item["Fecha"], item["Tipo"].ToString(), item["Desde"].ToString(), item["Hasta"].ToString(), item["Cantidad"].ToString());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GetComprobantes();
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
                GetComprobantesByFecha();
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
                GetComprobantesByFecha();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()))
                {
                    int.TryParse(dataGridView1.CurrentRow.Cells[0].Value.ToString(), out this.IdConfComprobante);
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.IdConfComprobante = 0;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (IdConfComprobante != 0)
            {
                salirAceptar = true;
                this.Close();
            }
            else
            {
                AVISOI("Para Aceptar primero debe seleccionar un producto.");
            }
        }

        private void FormCatalogoComprobantes_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!salirAceptar)
                    this.IdConfComprobante = 0;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormCatalogoComprobantes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.IdConfComprobante = 0;
                this.Close();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IdConfComprobante != 0)
                {
                    salirAceptar = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetComprobantes();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
