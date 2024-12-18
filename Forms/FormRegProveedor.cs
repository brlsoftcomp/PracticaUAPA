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
    public partial class FormRegProveedor : Form
    {
        int IdProveedor = 0;
        public FormRegProveedor()
        {
            InitializeComponent();
            this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
            txtItbis.SelectedIndex = 0;
        }

        #region GUARDAR
        private void Guardar()
        {
            try
            {
                if (this.IdProveedor == 0)
                {
                    var tbl = new TblProveedor();
                    tbl.Nombre = txtNombre.Text;
                    tbl.RNC = txtCedula.Text;
                    tbl.Direccion = txtDireccion.Text;
                    tbl.Telefono = txtTelefono.Text;
                    tbl.Telefono2 = txtTelefono2.Text;
                    tbl.Correo = txtCorreo.Text;
                    tbl.ItbisIncluido = txtItbis.Text;
                    _Proveedor.Save(tbl);
                }
                else
                {
                    var tbl = new TblProveedor();
                    tbl.IdProveedor = this.IdProveedor;
                    tbl.Nombre = txtNombre.Text;
                    tbl.RNC = txtCedula.Text;
                    tbl.Direccion = txtDireccion.Text;
                    tbl.Telefono = txtTelefono.Text;
                    tbl.Telefono2 = txtTelefono2.Text;
                    tbl.Correo = txtCorreo.Text;
                    tbl.ItbisIncluido = txtItbis.Text;
                    _Proveedor.Update(tbl);
                }

                Bloquear();
                //Limpiar();
                AVISOI("DATOS GUARDADOS.");
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

        #region LIMPIAR
        public void Limpiar()
        {
            this.IdProveedor = 0;
            txtNombre.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtTelefono2.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtItbis.SelectedIndex = 0;

            txtNombre.Enabled = true;
            txtCedula.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtTelefono2.Enabled = true;
            txtCorreo.Enabled = true;
            txtItbis.Enabled = true;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
        }
        #endregion

        #region ValidarGuardado
        private bool ValidarGuardado()
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    AVISOW("El nombre es requerido.");
                    return true;
                }
                if (string.IsNullOrEmpty(txtCedula.Text))
                {
                    AVISOW("La Cedula/RNC es requerido.");
                    txtCedula.Focus();
                    return true;
                }
                else
                {
                    if (txtCedula.Text.Length != 9 && txtCedula.Text.Length != 11)
                    {
                        AVISOW("La Cedula/RNC es incorrecto.");
                        txtCedula.Focus();
                        return true;
                    }
                }
                if (string.IsNullOrEmpty(txtDireccion.Text))
                {
                    AVISOW("La Direccion es requerida.");
                    return true;
                }
                if (!txtTelefono.MaskCompleted)
                {
                    AVISOW("El Telefono es requerido.");
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Bloquear
        private void Bloquear()
        {
            try
            {
                txtNombre.Enabled = false;
                txtCedula.Enabled = false;
                txtDireccion.Enabled = false;
                txtTelefono.Enabled = false;
                txtTelefono2.Enabled = false;
                txtCorreo.Enabled = false;
                txtItbis.Enabled = false;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
        #endregion

        #region DesBloquear
        private void DesBloquear()
        {
            try
            {
                txtNombre.Enabled = true;
                txtCedula.Enabled = true;
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
                txtTelefono2.Enabled = true;
                txtCorreo.Enabled = true;
                txtItbis.Enabled = true;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
        #endregion
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

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                DesBloquear();
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
                if (!ValidarGuardado())
                {
                    Guardar();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoProveedor();
                form.texto = txtBuscar.Text;
                form.ShowDialog();
                if (form.IdProveedor > 0)
                {
                    this.IdProveedor = form.IdProveedor;
                    txtNombre.Text = form.Nombre;
                    txtCedula.Text = form.RNC;
                    txtDireccion.Text = form.Direccion;
                    txtTelefono.Text = form.Telefono;
                    txtTelefono2.Text = form.Telefono2;
                    txtCorreo.Text = form.Correo;
                    txtItbis.Text = form.ItbisIncluido;
                    Bloquear();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    txtCedula.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtCedula_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    txtDireccion.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    txtTelefono.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    txtTelefono2.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtTelefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    txtCorreo.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
                    var form = new FormCatalogoProveedor();
                    form.texto = txtBuscar.Text;
                    form.ShowDialog();
                    if (form.IdProveedor > 0)
                    {
                        this.IdProveedor = form.IdProveedor;
                        txtNombre.Text = form.Nombre;
                        txtCedula.Text = form.RNC;
                        txtDireccion.Text = form.Direccion;
                        txtTelefono.Text = form.Telefono;
                        txtTelefono2.Text = form.Telefono2;
                        txtCorreo.Text = form.Correo;
                        Bloquear();
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void FormRegProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F5)
                {
                    Limpiar();
                }
                if (e.KeyData == Keys.F6)
                {
                    DesBloquear();
                }
                if (e.KeyData == Keys.F8)
                {
                    if (!ValidarGuardado())
                    {
                        Guardar();
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }

        }
    }
}
