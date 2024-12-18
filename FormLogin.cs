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

namespace BRL_SVentas
{
    public partial class FormLogin : Form
    {
        int IdUsuario = 0;
        public FormLogin()
        {
            InitializeComponent();

            label3.Parent = pictureBox3;
            label3.BackColor = Color.Transparent;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

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

        #region GetUsuario
        private void GetUsuario()
        {
            try
            {
                //txtMensaje.Text = string.Empty;
                if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    MessageBox.Show("El Usuario es requerido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtContrasena.Text))
                {
                    MessageBox.Show("La Contraseña es requerida", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasena.Focus();
                    return;
                }
                var get = new _Usuario_get();
                var usuario = new TblUsuario();
                var list = new List<TblUsuario>();
                list = get.GetBy("Usuario", txtUsuario.Text);
                if (list.Count > 0)
                {
                    if (list[0].Password == txtContrasena.Text)
                    {
                        IdUsuario = list[0].IdUsuario;
                        ConfigurationManager.AppSettings["IdUsuario"] = list[0].IdUsuario.ToString();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario Invalido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Usuario Invalido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                GetUsuario();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtUsuario.Text))
                {
                    Sender();
                }
                else
                {
                    MessageBox.Show("Debe ingresar un nombre de usuario.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txtContrasena.Text))
                    {
                        GetUsuario();
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un nombre de usuario.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
