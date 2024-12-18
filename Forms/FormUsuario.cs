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
    public partial class FormUsuario : Form
    {
        int IdUsuario = 0;
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                txtCategoria.SelectedIndex = 0;
                txtEstado.SelectedIndex = 0;
                GetAllUsuario();
            }
            catch (Exception ex)
            {
                Aviso(ex.ToString());
            }
        }

        #region Limpiar
        public void Limpiar()
        {
            this.IdUsuario = 0;
            txtUsuario.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            txtRepetirContrasena.Text = string.Empty;
            txtEstado.SelectedIndex = 0;
            txtCategoria.SelectedIndex = 0;

            txtContrasena.Enabled = true;
            txtRepetirContrasena.Enabled = true;
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

        #region GetUsuario
        public void GetUsuario()
        {

            try
            {
                var usuario = new TblUsuario();
                var get = new _Usuario_get();
                usuario = get.GetById(this.IdUsuario);
                if (usuario != null)
                {
                    this.IdUsuario = usuario.IdUsuario;
                    txtNombre.Text = usuario.Nombre;
                    txtUsuario.Text = usuario.Usuario;
                    txtContrasena.Text = usuario.Password;
                    txtRepetirContrasena.Text = usuario.Password;
                    txtEstado.Text = usuario.Estado;
                    txtCategoria.Text = usuario.Categoria;

                    txtContrasena.Enabled = false;
                    txtRepetirContrasena.Enabled = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region GetAllUsuario
        public void GetAllUsuario()
        {
            try
            {
                dataGridView1.Rows.Clear();
                var usuario = new List<TblUsuario>();
                var get = new _Usuario_get();
                usuario = get.GetAll();
                foreach (var item in usuario)
                {
                    dataGridView1.Rows.Add(item.IdUsuario, item.Nombre);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region GuardarPermiso
        public void GuardarPermiso(string texto)
        {
            try
            {
                var tbl = new TblUsuarioPermiso();
                if(texto == "CAJERO")
                {
                    tbl.IdUsuario = this.IdUsuario;
                    tbl.IdPermiso = 1;//VENTAS
                    _UsuarioPermiso.Save(tbl);
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
                var usuario = new TblUsuario();
                usuario.Nombre = txtNombre.Text;
                usuario.Usuario = txtUsuario.Text;
                usuario.Password = txtContrasena.Text;
                usuario.Estado = txtEstado.Text;
                usuario.Categoria = txtCategoria.Text;

                if (this.IdUsuario == 0)
                {
                    this.IdUsuario = _Usuario.Save(usuario);
                    //GuardarPermiso(usuario.Categoria);
                }
                else
                {
                    usuario.IdUsuario = this.IdUsuario;
                    _Usuario.Update(usuario);
                }
                Aviso("DATOS GUARDADOS");
                Limpiar();
                GetAllUsuario();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Aviso("El nombre es requerido.");
                return;
            }
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                Aviso("El usuario es requerido.");
                return;
            }
            if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                Aviso("La contraseña es requerida.");
                return;
            }
            if (string.IsNullOrEmpty(txtRepetirContrasena.Text))
            {
                Aviso("Repetir contraseña es requerido.");
                return;
            }
            if (txtContrasena.Text != txtRepetirContrasena.Text)
            {
                Aviso("Las contraseñas no son iguales.");
                return;
            }
            Guardar();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1)
                {
                    if (e.ColumnIndex == 2)
                    {
                        int.TryParse(dataGridView1.CurrentRow.Cells["colId"].Value.ToString(), out this.IdUsuario);
                        GetUsuario();
                    }
                }
            }
            catch (Exception ex)
            {
                Aviso(ex.ToString());
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
                Aviso(ex.ToString());
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtUsuario.Focus();
            }
        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtContrasena.Focus();
            }
        }

        private void TxtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtRepetirContrasena.Focus();
            }
        }
    }
}
