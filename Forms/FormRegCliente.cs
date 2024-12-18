using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRL_SVentas.Servicios;
using BRL_SVentas.Catalogos;

namespace BRL_SVentas.Forms
{
    public partial class FormRegCliente : Form
    {
        int IdCliente = 0;
        int IdClienteCredito = 0;
        public FormRegCliente()
        {
            InitializeComponent();
            this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
        }

        #region Desbloquear
        private void Desbloquear()
        {
            try
            {
                txtNombre.Enabled = true;
                txtCedula.Enabled = true;
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
                txtTelefono2.Enabled = true;
                txtTipoCliente.Enabled = true;
                txtCredito.Enabled = true;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ValidarGuardar
        private bool ValidarGuardar()
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    AVISOW("El nombre es requerido.");
                    return true;
                }
                if (!string.IsNullOrEmpty(txtCedula.Text))
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
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGuardar())
                {
                    Guardar();
                }
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
                btnEditar.Enabled = false;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }


        private void BtnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtCedula.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtTelefono2.Enabled = true;
            txtTipoCliente.Enabled = true;
            txtCredito.Enabled = true;
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoCliente();
                form.texto = txtBuscar.Text;
                form.ShowDialog();
                if (form.IdCliente > 0)
                {
                    this.IdCliente = form.IdCliente;
                    txtNombre.Text = form.Nombre;
                    txtCedula.Text = form.Cedula;
                    txtDireccion.Text = form.Direccion;
                    txtTelefono.Text = form.Telefono;
                    txtTelefono2.Text = form.Telefono2;
                    txtTipoCliente.Text = form.Tipo;

                    var tbl = new TblClienteCredito();
                    var get = new _ClienteCredito_get();
                    tbl = get.GetByIdCliente(this.IdCliente);
                    if (tbl != null)
                    {
                        this.IdClienteCredito = tbl.IdClienteCredito;
                        txtCredito.Text = tbl.Credito.ToString("#,###.00;-#,###.00;0.00");
                    }

                    txtNombre.Enabled = false;
                    txtCedula.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtTelefono2.Enabled = false;
                    txtTipoCliente.Enabled = false;
                    txtCredito.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        #region GUARDAR
        private void Guardar()
        {
            try
            {
                if (this.IdCliente == 0)
                {
                    var tbl = new TblCliente();
                    tbl.Nombre = txtNombre.Text;
                    tbl.Cedula = txtCedula.Text;
                    tbl.Direccion = txtDireccion.Text;
                    tbl.Telefono = txtTelefono.Text;
                    tbl.Telefono2 = txtTelefono2.Text;
                    tbl.Tipo = txtTipoCliente.Text;
                    this.IdCliente = _Cliente.Save(tbl);
                    if(this.IdCliente > 0)
                    {
                        decimal valorDecimal = 0;
                        var tbl2 = new TblClienteCredito();
                        tbl2.IdCliente = this.IdCliente;
                        decimal.TryParse(txtCredito.Text, out valorDecimal);
                        tbl2.Credito = valorDecimal;
                        _ClienteCredito.Save(tbl2);
                    }
                }
                else
                {
                    var tbl = new TblCliente();
                    tbl.IdCliente = this.IdCliente;
                    tbl.Nombre = txtNombre.Text;
                    tbl.Cedula = txtCedula.Text;
                    tbl.Direccion = txtDireccion.Text;
                    tbl.Telefono = txtTelefono.Text;
                    tbl.Telefono2 = txtTelefono2.Text;
                    tbl.Tipo = txtTipoCliente.Text;
                    _Cliente.Update(tbl);
                    decimal valorDecimal = 0;

                    var tbl2 = new TblClienteCredito();
                    var get = new _ClienteCredito_get();
                    tbl2.IdClienteCredito = this.IdClienteCredito;
                    tbl2.IdCliente = this.IdCliente;
                    decimal.TryParse(txtCredito.Text, out valorDecimal);
                    tbl2.Credito = valorDecimal;
                    if (get.Validar(this.IdCliente))
                    {
                        _ClienteCredito.Update(tbl2);
                    }
                    else
                    {
                        _ClienteCredito.Save(tbl2);
                    }
                }

                Limpiar();
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
            this.IdCliente = 0;
            this.IdClienteCredito = 0;
            txtNombre.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtTelefono2.Text = string.Empty;
            txtTipoCliente.SelectedIndex = 0;
            txtCredito.Text = "0.00";

            txtNombre.Enabled = true;
            txtCedula.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtTelefono2.Enabled = true;
            txtCredito.Enabled = true;
            btnGuardar.Enabled = true;
        }
        #endregion

        private void TxtCedula_KeyPress(object sender, KeyPressEventArgs e)
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
                    txtDireccion.Focus();
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

        private void TxtTelefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    txtCredito.Focus();
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
                    if (form.IdCliente > 0)
                    {
                        this.IdCliente = form.IdCliente;
                        txtNombre.Text = form.Nombre;
                        txtCedula.Text = form.Cedula;
                        txtDireccion.Text = form.Direccion;
                        txtTelefono.Text = form.Telefono;
                        txtTelefono2.Text = form.Telefono2;
                        txtTipoCliente.Text = form.Tipo;

                        var tbl = new TblClienteCredito();
                        var get = new _ClienteCredito_get();
                        tbl = get.GetByIdCliente(this.IdCliente);
                        if (tbl != null)
                        {
                            this.IdClienteCredito = tbl.IdClienteCredito;
                            txtCredito.Text = tbl.Credito.ToString("#,###.00;-#,###.00;0.00");
                        }
                        txtNombre.Enabled = false;
                        txtCedula.Enabled = false;
                        txtDireccion.Enabled = false;
                        txtTelefono.Enabled = false;
                        txtTelefono2.Enabled = false;
                        txtTipoCliente.Enabled = false;
                        txtCredito.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCredito_Validated(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCredito.Text))
                {
                    txtCredito.Text = "0.00";
                }
                else
                {
                    decimal valorDecimal = 0;
                    decimal.TryParse(txtCredito.Text, out valorDecimal);
                    txtCredito.Text = valorDecimal.ToString("#,###.00;-#,###.00;0.00");
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormRegCliente_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F5)
                {
                    Limpiar();
                    btnEditar.Enabled = false;
                }
                if (e.KeyData == Keys.F6)
                {
                    Desbloquear();
                }
                if (e.KeyData == Keys.F8)
                {
                    if (!ValidarGuardar())
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

        private void FormRegCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
