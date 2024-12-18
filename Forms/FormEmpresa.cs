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
    public partial class FormEmpresa : Form
    {
        int IdContribuyente = 0;
        public FormEmpresa()
        {
            InitializeComponent();
        }

        private void FormEmpresa_Load(object sender, EventArgs e)
        {
            try
            {
                GetContribuyente();
            }
            catch (Exception ex)
            {
                Aviso(ex.ToString());
            }
        }

        #region Limpiar
        public void Limpiar()
        {
            this.IdContribuyente = 0;
            txtNombre.Text = string.Empty;
            txtActividad.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtRnc.Text = string.Empty;
            txtTelefono1.Text = string.Empty;
            txtTelefono2.Text = string.Empty;

        }
        #endregion

        #region Aviso
        private void Aviso(string Mensaje)
        {
            try
            {
                MessageBox.Show(Mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region GetContribuyente
        public void GetContribuyente()
        {

            try
            {
                var empresa = new TblEmpresa();
                var get = new _Empresa_get();
                empresa = get.GetById(1);
                if (empresa != null)
                {
                    this.IdContribuyente = empresa.IdEmpresa;
                    txtNombre.Text = empresa.Nombre;
                    txtActividad.Text = empresa.Actividad;
                    txtDireccion.Text = empresa.Direccion;
                    txtRnc.Text = empresa.RNC;
                    txtTelefono1.Text = empresa.Telefono1;
                    txtTelefono2.Text = empresa.Telefono2;
                    if (!string.IsNullOrEmpty(empresa.Logo))
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Imagenes\\" + empresa.Logo);
                    }
                    else
                    {
                        pictureBox1.Image = global::BRL_SVentas.Properties.Resources.empresa;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Guardar
        public void Guardar()
        {

            try
            {
                var empresa = new TblEmpresa();
                empresa.Nombre = txtNombre.Text;
                empresa.Actividad = txtActividad.Text;
                empresa.Direccion = txtDireccion.Text;
                empresa.RNC = txtRnc.Text;
                empresa.Telefono1 = txtTelefono1.Text;
                empresa.Telefono2 = txtTelefono2.Text;
                empresa.Logo = "Logo.png";
                //if (!string.IsNullOrEmpty(pictureBox1.ImageLocation))
                //{
                //    string fotoName = string.Empty;
                //    fotoName = "Logo.png";
                //    pictureBox1.Image.Save(Application.StartupPath + "\\Imagenes\\" + fotoName);
                //    empresa.Logo = fotoName;
                //}
                empresa.IdEmpresa = this.IdContribuyente;
                _Empresa.SaveXML(empresa);

                Aviso("DATOS GUARDADOS");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    Aviso("El nombre es requerido.");
                    return;
                }
                if (string.IsNullOrEmpty(txtActividad.Text))
                {
                    Aviso("La Actividad es requerida.");
                    return;
                }
                if (string.IsNullOrEmpty(txtDireccion.Text))
                {
                    Aviso("La Direccion es requerida.");
                    return;
                }
                if (string.IsNullOrEmpty(txtRnc.Text))
                {
                    Aviso("El RNC es requerido.");
                    return;
                }
                else
                {
                    if (txtRnc.Text.Length != 9 && txtRnc.Text.Length != 11)
                    {
                        Aviso("La Cedula/RNC es incorrecto.");
                        txtRnc.Focus();
                        return;
                    }
                }
                Guardar();
            }
            catch (Exception ex)
            {
                Aviso(ex.ToString());
            }
        }

        private void TxtRnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
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
                txtTelefono1.Focus();
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtActividad.Focus();
            }
        }

        private void TxtActividad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtDireccion.Focus();
            }
        }

        private void TxtTelefono1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtTelefono2.Focus();
            }
        }

        private void TxtTelefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                btnGuardar.Focus();
            }
        }

        private void TxtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtRnc.Focus();
            }
        }

        private void txtImagen_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
