using BRL_SVentas.Catalogos;
using BRL_SVentas.Model;
using BRL_SVentas.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRL_SVentas.Forms
{
    public partial class FormRegCxC : Form
    {
        private int IdUsuario = 0;
        int IdCliente = 0;
        int IdCxC = 0;
        public FormRegCxC()
        {
            InitializeComponent();
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
        private void Limpiar()
        {
            this.IdCliente = 0;
            this.IdCxC = 0;
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtConsepto.Text = string.Empty;
            txtMonto.Text = string.Empty;
            txtAbonar.Text = string.Empty;
            txtBalance.Text = string.Empty;
            txtNota.Text = string.Empty;
        } 
        #endregion

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoCliente();
                form.texto = txtBuscar.Text;
                form.ShowDialog();
                this.IdCliente = form.IdCliente;
                txtCodigo.Text = this.IdCliente.ToString();
                txtNombre.Text = form.Nombre;
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
                Limpiar();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Registrar CxC:      
                decimal monto = 0, abonar = 0;
                decimal.TryParse(txtMonto.Text, out monto);
                decimal.TryParse(txtAbonar.Text, out abonar);
                var tblCxC = new TblCxC();
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out this.IdUsuario);
                tblCxC.IdUsuario = this.IdUsuario;
                tblCxC.IdFactura = 0;
                tblCxC.IdCliente = this.IdCliente;
                tblCxC.Fecha = DateTime.Now;
                tblCxC.Concepto = txtConsepto.Text;
                tblCxC.Monto = monto;
                tblCxC.Balance = monto - abonar;
                tblCxC.Estado = "PENDIENTE";
                tblCxC.Nota = txtNota.Text;
                tblCxC.ClienteNombre = txtNombre.Text;
                if (this.IdCliente == 0)
                {
                    AVISOW("El Cliente es requerido.");
                    return;
                }
                decimal valorDecimal = 0;
                decimal.TryParse(txtMonto.Text, out valorDecimal);
                if (valorDecimal <= 0)
                {
                    AVISOI("El monto debe ser mayor que cero.");
                    txtMonto.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtConsepto.Text))
                {
                    AVISOW("El Consepto es requerido.");
                    return;
                }
                if (tblCxC.Balance <= 0)
                {
                    AVISOW("El Abono no puede ser mayor o igual al Monto Pendiente.");
                    return;
                }
                this.IdCxC = _CxC.SaveXML(tblCxC);

                //Registrar abono de inicial:
                if (abonar > 0)
                {
                    int Id = 0;
                    var tblCobro = new TblCobro();
                    tblCobro.IdCxC = IdCxC;
                    int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out this.IdUsuario);
                    tblCobro.IdUsuario = this.IdUsuario;
                    tblCobro.Fecha = DateTime.Now;
                    tblCobro.Abono = abonar;
                    tblCobro.Monto = monto;
                    tblCobro.Balance = tblCobro.Monto - tblCobro.Abono;
                    tblCobro.Nota = txtNota.Text;
                    Id = _Cobros.SaveXML(tblCobro);

                    //Registrar en Movimeinto de Caja:
                    var tblCaja = new TblCaja();
                    tblCaja.IdUsuario = this.IdUsuario;
                    tblCaja.Fecha = DateTime.Now;
                    tblCaja.Registro = Id;
                    tblCaja.Modulo = "COBRO CXC";
                    tblCaja.Monto = abonar;
                    tblCaja.Caja = "#1";
                    tblCaja.Estado = "ABIERTA";
                    int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out Id);
                    tblCaja.IdCajaApertura = Id;
                    _Caja.Save(tblCaja);
                }
                Limpiar();
                AVISOI("DATOS GUARDADOS.");
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
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
                else if (Char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    txtAbonar.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtAbonar_KeyPress(object sender, KeyPressEventArgs e)
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
                else if (Char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    btnGuardar.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtAbonar_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal monto = 0, abonar = 0;
                decimal.TryParse(txtMonto.Text, out monto);
                decimal.TryParse(txtAbonar.Text, out abonar);
                monto = monto - abonar;
                txtBalance.Text = monto.ToString("#,###.00;-#,###.00;0.00");

                decimal valor = 0;
                decimal.TryParse(txtAbonar.Text, out valor);
                txtAbonar.Text = valor.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtMonto_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal monto = 0;
                decimal.TryParse(txtMonto.Text, out monto);
                txtMonto.Text = monto.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormRegCxC_Load(object sender, EventArgs e)
        {
            txtConsepto.SelectedIndex = 0;
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
                    var form = new FormCatalogoCliente();
                    form.texto = txtBuscar.Text;
                    form.ShowDialog();
                    this.IdCliente = form.IdCliente;
                    txtCodigo.Text = this.IdCliente.ToString();
                    txtNombre.Text = form.Nombre;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
