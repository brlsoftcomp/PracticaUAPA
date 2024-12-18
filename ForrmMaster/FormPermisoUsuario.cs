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

namespace BRL_SVentas
{
    public partial class FormPermisoUsuario : Form
    {
        public int IdUsuario = 0;
        bool tienePermisos = false;
        public FormPermisoUsuario()
        {
            InitializeComponent();
        }
        private void FormPermisoUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                GetAllUsuario();
            }
            catch (Exception ex)
            {
                Aviso(ex.ToString());
            }
        }

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

        #region Limpiar
        private void Limpiar()
        {
            try
            {
                btnGuardar.Enabled = true;
                flowLayoutPanel1.Enabled = true;
                GetPermisos();
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
                    txtCodigo.Text = usuario.IdUsuario.ToString();
                    txtNombre.Text = usuario.Nombre;
                    txtCategoria.Text = usuario.Categoria;
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

        #region GetPermisos
        private void GetPermisos()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Enabled = false;
                var get = new _UsuarioPermiso_get();
                var list = new List<TblPermiso>();
                var factory = new _Permiso_get();
                list = factory.GetAll();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        var che = new CheckBox();
                        che.AutoSize = true;
                        che.Text = item.Descripcion.ToString();
                        che.Tag = item.IdPermiso.ToString();
                        if (get.Validar(this.IdUsuario, item.IdPermiso))
                        {
                            che.Checked = true;
                            tienePermisos = true;
                        }
                        flowLayoutPanel1.Controls.Add(che);
                    }
                }
            }
            catch (Exception ex)
            {
                Aviso(ex.ToString());
            }
        }

        #endregion

        #region GuardarPermisos
        private void GuardarPermisos()
        {
            try
            {
                string getId = string.Empty;
                int Id = 0;
                var listaDetalle = new List<TblUsuarioPermiso>();
                TblUsuarioPermiso detalle;
                foreach (Control item in flowLayoutPanel1.Controls)
                {
                    if (item.GetType() == typeof(CheckBox))
                    {
                        if (((CheckBox)item).Checked)
                        {
                            detalle = new TblUsuarioPermiso();
                            getId = ((CheckBox)item).Tag.ToString();
                            int.TryParse(getId, out Id);
                            detalle.IdPermiso = Id;
                            detalle.IdUsuario = this.IdUsuario;
                            listaDetalle.Add(detalle);
                        }
                    }
                }
                if (listaDetalle.Count == 0)
                {
                    Aviso("Los permisos son requeridos.");
                    return;
                }
                if (MessageBox.Show("Confirme que desea guardar los permisos?", "PERMISOS DE USUARIO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (tienePermisos)
                    {
                        _UsuarioPermiso.Delete(this.IdUsuario);
                    }
                    foreach (var item in listaDetalle)
                    {
                        _UsuarioPermiso.Save(item);
                    }
                    btnGuardar.Enabled = false;
                    flowLayoutPanel1.Enabled = false;
                    Aviso("DATOS GUARDADOS!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarPermisos();
                GetPermisos();
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
            }
            catch (Exception ex)
            {
                Aviso(ex.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardar.Enabled = true;
                flowLayoutPanel1.Enabled = true;
                btnEditar.Enabled = false;
            }
            catch (Exception ex)
            {
                Aviso(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1)
                {
                    if (e.ColumnIndex == 2)
                    {
                        int.TryParse(dataGridView1.CurrentRow.Cells["colId"].Value.ToString(), out this.IdUsuario);
                        GetUsuario();
                        GetPermisos();
                    }
                }
            }
            catch (Exception ex)
            {
                Aviso(ex.ToString());
            }
        }
    }
}
