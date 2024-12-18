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
    public partial class FormFormaPago : Form
    {
        public decimal montoFactura = 0;
        public decimal pagoTotal = 0;
        public bool acredito = false;
        public bool pagado = false;
        public int IdNCF = 0;
        public FormFormaPago()
        {
            InitializeComponent();
        }

        private void FormCobrarFactura_Load(object sender, EventArgs e)
        {
            txtImprimir.SelectedIndex = 0;

            Sender();

            if (acredito)
            {
                lb_pago.Text = "Monto Abonar:";
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

        #region Sender
        private void Sender()
        {
            try
            {
                SendKeys.Send("{tab}");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region DATOS
        public decimal Devuelta { get; set; }
        public decimal MontoEfectivo { get; set; }
        public decimal MontoTarjeta { get; set; }
        public decimal MontoCheque { get; set; }
        public decimal MontoDevTransf { get; set; }
        public int NoBoucher { get; set; }
        public int NoCheque { get; set; }
        public int IdNotaCredito { get; set; }
        public int IdDevolucion { get; set; }

        #endregion

        private void BtnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                int noBoucher = 0, noCheque = 0;
                decimal montoEfectivo = 0, montoTarjeta = 0, montoCheque = 0;
                decimal.TryParse(txtMontoEfectivo.Text, out montoEfectivo);
                decimal.TryParse(txtMontoTarjeta.Text, out montoTarjeta);
                decimal.TryParse(txtMontoCheque.Text, out montoCheque);
                this.pagoTotal = montoEfectivo + montoTarjeta + montoCheque;
                MontoEfectivo = montoEfectivo;
                MontoTarjeta = montoTarjeta;
                MontoCheque = montoCheque;
                int.TryParse(txtNoBoucher.Text, out noBoucher);
                NoBoucher = noBoucher;
                int.TryParse(txtNoCheque.Text, out noCheque);
                NoCheque = noCheque;

                if (!acredito)
                {
                    if (montoTarjeta > montoFactura)
                    {
                        AVISOW("El Monto del pago con TARJETA no puede ser mayor al monto de la Factura.");
                        return;
                    }
                    if (montoTarjeta <= 0 && !string.IsNullOrEmpty(txtNoBoucher.Text))
                    {
                        AVISOW("El Monto del pago con TARJETA es requerido.");
                        return;
                    }
                    if (montoTarjeta > 0 && string.IsNullOrEmpty(txtNoBoucher.Text))
                    {
                        AVISOW("El numero del BOUCHER es requerido.");
                        return;
                    }
                    if (montoCheque > montoFactura)
                    {
                        AVISOW("El Monto del pago con CHEQUE no puede ser mayor al monto de la Factura.");
                        return;
                    }
                    if (montoCheque <= 0 && !string.IsNullOrEmpty(txtNoCheque.Text))
                    {
                        AVISOW("El Monto del CHEQUE es requerido.");
                        return;
                    }
                    if (montoCheque > 0 && string.IsNullOrEmpty(txtNoCheque.Text))
                    {
                        AVISOW("El numero del CHEQUE requerido.");
                        return;
                    }
                    if (this.pagoTotal < montoFactura)
                    {
                        AVISOW("El monto a pagar es menor al monto de la factura.");
                        return;
                    }
                    if (montoTarjeta == 0 && montoCheque  == 0 && montoEfectivo == 0)
                    {
                        AVISOW("El Monto a Cobrar es requerido.");
                        return;
                    }

                    DialogResult result = new DialogResult();
                    result = MessageBox.Show("Realmente desea cobrar esta factura?", "Cobrar Facturar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    Devuelta = this.pagoTotal - montoFactura;
                    this.pagoTotal = this.pagoTotal - Devuelta;
                    pagado = true;
                    this.Close();
                }
                else
                {
                    if (montoTarjeta <= 0 && !string.IsNullOrEmpty(txtNoBoucher.Text))
                    {
                        AVISOW("El Monto del pago con TARJETA es requerido.");
                        return;
                    }
                    if (montoTarjeta > 0 && string.IsNullOrEmpty(txtNoBoucher.Text))
                    {
                        AVISOW("El numero del BOUCHER es requerido.");
                        return;
                    }
                    if (montoCheque <= 0 && !string.IsNullOrEmpty(txtNoCheque.Text))
                    {
                        AVISOW("El Monto del CHEQUE es requerido.");
                        return;
                    }
                    if (montoCheque > 0 && string.IsNullOrEmpty(txtNoCheque.Text))
                    {
                        AVISOW("El numero del CHEQUE requerido.");
                        return;
                    }
                    if (pagoTotal >= montoFactura)
                    {
                        AVISOI("El monto para abonar no puede ser mayor o igual al monto de la factura.");
                        return;
                    }
                    DialogResult result = new DialogResult();
                    result = MessageBox.Show("Realmente desea cobrar esta factura?", "Cobrar Facturar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    pagado = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Cobrar Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtPagoCon_Validated(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txtMontoEfectivo.Text))
                {
                    decimal efectivo = 0, tarjeta = 0, cheque = 0, notaCredito = 0, total = 0;
                    decimal.TryParse(txtMontoEfectivo.Text, out efectivo);
                    decimal.TryParse(txtMontoTarjeta.Text, out tarjeta);
                    decimal.TryParse(txtMontoCheque.Text, out cheque);
                    txtMontoEfectivo.Text = efectivo.ToString("#,###.00;-#,###.00;0.00");
                    total = efectivo + tarjeta + cheque + notaCredito;
                    txtTotal.Text = total.ToString("#,###.00;-#,###.00;0.00");
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtMontoTarjeta_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal efectivo = 0, tarjeta = 0, cheque = 0, notaCredito = 0, total = 0;
                decimal.TryParse(txtMontoEfectivo.Text, out efectivo);
                decimal.TryParse(txtMontoTarjeta.Text, out tarjeta);
                decimal.TryParse(txtMontoCheque.Text, out cheque);
                txtMontoTarjeta.Text = tarjeta.ToString("#,###.00;-#,###.00;0.00");
                total = efectivo + tarjeta + cheque + notaCredito;
                txtTotal.Text = total.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtMontoCheque_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal efectivo = 0, tarjeta = 0, cheque = 0, notaCredito = 0, total = 0;
                decimal.TryParse(txtMontoEfectivo.Text, out efectivo);
                decimal.TryParse(txtMontoTarjeta.Text, out tarjeta);
                decimal.TryParse(txtMontoCheque.Text, out cheque);
                txtMontoCheque.Text = cheque.ToString("#,###.00;-#,###.00;0.00");
                total = efectivo + tarjeta + cheque + notaCredito;
                txtTotal.Text = total.ToString("#,###.00;-#,###.00;0.00");

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtMontoEfectivo_KeyPress(object sender, KeyPressEventArgs e)
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
                    btnCobrar.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtNoBoucher_KeyPress(object sender, KeyPressEventArgs e)
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
                else
                {
                    e.Handled = true;
                }

                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                   txtMontoEfectivo.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtMontoTarjeta_KeyPress(object sender, KeyPressEventArgs e)
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
                    txtNoBoucher.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtNoCheque_KeyPress(object sender, KeyPressEventArgs e)
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
                else
                {
                    e.Handled = true;
                }

                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    txtMontoTarjeta.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtMontoCheque_KeyPress(object sender, KeyPressEventArgs e)
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
                    txtNoCheque.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtImprimir_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var tbl = new TblMasterConfig();
                var get = new _MasterConfig_get();
                tbl = get.GetById(1);
                tbl.PapelFactura = txtImprimir.Text;
                _MasterConfig.Update(tbl);
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
