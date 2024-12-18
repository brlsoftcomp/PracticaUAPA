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
    public partial class FormCajaApertura : Form
    {
        public bool CajaAbierta = false;
        int IdUsuario = 0;
        public FormCajaApertura()
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
        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirme que desea iniciar la Apertura de Caja?", "Apertura de Caja", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                int valorInt = 0;
                decimal valorDecima = 0;
                var tblCajaAp = new TblCajaApertura();
                decimal.TryParse(txtMontoInicial.Text, out valorDecima);
                if(valorDecima < 0)
                {
                    AVISOW("El Monto digitado no es Valido!.");
                    return;
                }
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out this.IdUsuario);
                tblCajaAp.IdUsuario = IdUsuario;
                tblCajaAp.Fecha = DateTime.Now;
                tblCajaAp.Caja = "Caja #1";
                decimal.TryParse(txtMontoInicial.Text, out valorDecima);
                tblCajaAp.Monto = valorDecima;
                tblCajaAp.Estado = "ABIERTA";
                valorInt =_CajaApertura.SaveXML(tblCajaAp);
                if (valorInt > 0)
                {
                    ConfigurationManager.AppSettings["IdCajaApertura"] = valorInt.ToString();
                    CajaAbierta = true;
                    this.Close();                  
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtMontoInicial_KeyPress(object sender, KeyPressEventArgs e)
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
                    decimal valor = 0;
                    decimal.TryParse(txtMontoInicial.Text, out valor);
                    txtMontoInicial.Text = valor.ToString("#,###.00;-#,###.00;0.00");
                    btnIniciar.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormCajaApertura_Load(object sender, EventArgs e)
        {
            try
            {
                txtCaja.Text = "CAJA #1";
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
