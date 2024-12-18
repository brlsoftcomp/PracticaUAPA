using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRL_SVentas.Model;
using BRL_SVentas.Catalogos;
using BRL_SVentas.Servicios;
using System.Configuration;

namespace BRL_SVentas.Forms
{
    public partial class FormAjusteInventario : Form
    {
        private int IdProducto = 0;
        private int CodigoProducto = 0;
        private int IdUsuario = 0;
        private bool edit = false;
        private int indexRow = 0;
        public FormAjusteInventario()
        {
            InitializeComponent();
        }

        private void FormHistAjusteInventario_Load(object sender, EventArgs e)
        {
            try
            {
                this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
                txtTipoAjuste.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
         }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {

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
                    var form = new FormCatalogoProductos();
                    form.txtBuscar.Text = txtBuscar.Text;
                    form.ShowDialog();
                    if (form.Id != 0)
                    {
                        this.IdProducto = form.Id;
                        this.CodigoProducto = form.codigo;
                        txtBuscar.Text = form.codigo.ToString();
                        txtDescripcion.Text = form.descripcion;
                        txtCantExist.Text = form.cantidad.ToString();
                        txtCantidad.Focus();
                    }
                    else
                    {
                        txtBuscar.Text = string.Empty;
                        txtDescripcion.Text = string.Empty;
                        txtCantExist.Text = string.Empty;
                    }
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
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                AplicarAjuste();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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
                try
                {
                    if (string.IsNullOrEmpty(txtCantidad.Text) || Int32.Parse(txtCantidad.Text) <= 0)
                    {
                        AVISOW("El valor digitado en el campo cantidad no es valido.");
                        return;
                    }                       
                    dgv.Rows.Add();
                    int cantfilas = dgv.Rows.Count - 1;
                    int cantExist = 0, cantAjuste = 0;

                    dgv[0, cantfilas].Value = this.IdProducto;
                    dgv[1, cantfilas].Value = this.CodigoProducto;
                    dgv[2, cantfilas].Value = txtDescripcion.Text;
                    dgv[3, cantfilas].Value = txtCantExist.Text;
                    dgv[4, cantfilas].Value = txtCantidad.Text;

                    cantExist = int.Parse(txtCantExist.Text);
                    cantAjuste = int.Parse(txtCantidad.Text);
                    if (txtTipoAjuste.Text == "SALIDA" || txtTipoAjuste.Text == "ZAFACON")
                    {
                        cantAjuste = -cantAjuste;
                    }
                    dgv[5, cantfilas].Value = cantExist + cantAjuste;
                    dgv[6, cantfilas].Value = txtTipoAjuste.Text;

                    this.IdProducto = 0;
                    txtBuscar.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtCantExist.Text = string.Empty;
                    txtCantidad.Text = string.Empty;
                    txtBuscar.ReadOnly = false;
                    if (edit)
                    {
                       edit = false;
                    }

                    txtBuscar.Focus();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {            
            try
            {
                var form = new FormCatalogoAjusteInventario();
                form.txtBuscar.Text = txtBuscarHist.Text;
                form.ShowDialog();
                if (form.seleccionado)
                {
                    dgv.Rows.Clear();
                    int valorId = 0;
                    //var tbl = new List<TblHistAICuerpo>();
                    //var get = new _HistAICuerpo_get();
                    int.TryParse(form.codigo, out valorId);
                    //tbl = get.GetById(valorId);
                    //foreach (var item in tbl)
                    //{
                    //    dgv.Rows.Add(item.FkeyProducto, item.Descripcion, item.CantidadExistenet, item.CantidadAjuste, item.Ajuste, item.TipoAjuste);
                    //}
                    Conexion Miconexion = new Conexion();
                    var dt = new DataTable();
                    var builder = new StringBuilder();
                    builder.Append("SELECT IdHistAICuerpo, FkeyProducto, TblProducto.Codigo, TblProducto.Nombre, CantidadExistenet, CantidadAjuste, Ajuste, TipoAjuste FROM TblHistAICuerpo JOIN TblProducto on FkeyProducto = IdProducto AND FkeyHistAI = '" + valorId + "'");
                    dt = Miconexion.BuscarTabla(builder);
                    foreach (DataRow reader in dt.Rows)
                    {
                        dgv.Rows.Add(reader["FkeyProducto"].ToString(), reader["Codigo"].ToString(), reader["Nombre"].ToString(), reader["CantidadExistenet"].ToString(), reader["CantidadAjuste"].ToString(), reader["Ajuste"].ToString(), reader["TipoAjuste"].ToString());
                    }

                    txtNota.Text = form.nota;
                    txtBuscarHist.Text = form.codigo;

                    txtBuscar.Enabled = false;
                    txtCantidad.Enabled = false;
                    btnAplicar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    txtTipoAjuste.Enabled = false;
                    txtNota.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Eliminar();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //registrar_articulo.id_articulo_seleccionado = this.dgv_ajus_inventario.CurrentRow.Cells[0].Value.ToString();
            //Obtener fila:
            indexRow = this.dgv.CurrentRow.Index;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Editar();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        #region AplicarAjuste
        private void AplicarAjuste()
        {
            if (dgv.RowCount < 1)//Verificar si hay registro en la fila para editar.
            {
                MessageBox.Show("La lista no contiene registros para aplicar el ajuste.", "Ajustes de Articulos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Realmente desea realizar este ajuste?", "Ajustes de Articulos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                var tblHistAICuerpo = new TblHistAICuerpo();
                var tblHistAI = new TblHistAjusteInventario();
                int valor = 0;
                int valorIdHistAI = 0;
                tblHistAI.Fecha = DateTime.Now;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out this.IdUsuario);
                tblHistAI.IdUsuario = this.IdUsuario;
                tblHistAI.Nota = txtNota.Text;
                valorIdHistAI = _HistAjusteInventario.SaveXML(tblHistAI);
                //MessageBox.Show(valor.ToString());
                var tblControlAlmacen = new TblControlAlmacen();
                var tblProducto = new TblProducto();
                var get = new _Producto_get();
                //Actualizar el DataGriView:
                foreach (DataGridViewRow dgv in dgv.Rows)
                {

                    tblHistAICuerpo.FkeyHistAI = valorIdHistAI;
                    int.TryParse(dgv.Cells[0].Value.ToString(), out valor);
                    tblHistAICuerpo.FkeyProducto = valor;
                    int.TryParse(dgv.Cells[3].Value.ToString(), out valor);
                    tblHistAICuerpo.CantidadExistenet = valor;
                    int.TryParse(dgv.Cells[4].Value.ToString(), out valor);
                    tblHistAICuerpo.CantidadAjuste = valor;
                    int.TryParse(dgv.Cells[5].Value.ToString(), out valor);
                    tblHistAICuerpo.Ajuste = valor;
                    tblHistAICuerpo.TipoAjuste = dgv.Cells[6].Value.ToString();
                    _HistAICuerpo.Save(tblHistAICuerpo);
                    //ACTUALIZAR LA CANTIDAD EXISTENTE DEL PRODUCTO:
                    int.TryParse(dgv.Cells[0].Value.ToString(), out valor);
                    tblProducto = get.GetById(valor);
                    int.TryParse(dgv.Cells[5].Value.ToString(), out valor);
                    tblProducto.CantidadExistente = valor;
                    _Productos.Update(tblProducto);

                    //REGISTRAR EL CONTROL DE ALMACEN:
                    tblControlAlmacen.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                    tblControlAlmacen.IdRegistro = valorIdHistAI;
                    int.TryParse(dgv.Cells[0].Value.ToString(), out valor);
                    tblControlAlmacen.IdProducto = valor;
                    tblControlAlmacen.Descripcion = tblProducto.Nombre;
                    tblControlAlmacen.Modulo = "AJUSTE INVENTARIO";
                    tblControlAlmacen.Movimiento = dgv.Cells[5].Value.ToString();
                    int.TryParse(dgv.Cells[3].Value.ToString(), out valor);
                    tblControlAlmacen.Cantidad = valor;
                    tblControlAlmacen.Fecha = DateTime.Now;
                    _ControlAlmacen.Save(tblControlAlmacen);
                }
                Limpiar();
                AVISOI("DATOS GUARDADOS");
                txtBuscar.Focus();
            }
        }
        #endregion

        #region Editar
        private void Editar()
        {
            try
            {
                txtBuscar.ReadOnly = true;
                if (edit)
                {
                    MessageBox.Show("Solo puede editar un registro a la ves.", "Editar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgv.Rows.Count > 0)//Verificar si hay registro en la fila para editar.
                {

                    int cantfilas = dgv.Rows.Count - 2;
                    int valor = 0;
                    int.TryParse(dgv[0, indexRow].Value.ToString(), out valor);
                    this.IdProducto = valor;
                    txtBuscar.Text = dgv[1, indexRow].Value.ToString();
                    txtDescripcion.Text = dgv[2, indexRow].Value.ToString();
                    txtCantExist.Text = dgv[3, indexRow].Value.ToString();
                    txtCantidad.Text = dgv[4, indexRow].Value.ToString();

                    //lista_de_articulos.set_codigo(dgv[0, indexRow].Value.ToString());
                    //lista_de_articulos.set_nombre(dgv[1, indexRow].Value.ToString());
                    //lista_de_articulos.set_cantidad_exist(dgv[2, indexRow].Value.ToString());

                    dgv.Rows.RemoveAt(indexRow);//Eliminar Fila
                    dgv.RefreshEdit();
                    //lista_de_articulos.registro_encontrado = true;
                    edit = true;
                    txtCantidad.Focus();
                }
                else { MessageBox.Show("No hay registro en esta fila", "Editar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Eliminar
        private void Eliminar()
        {
            try
            {
                if (dgv.Rows.Count > 0)//Verificar si hay registro en la fila para eliminar.
                {
                    dgv.Rows.RemoveAt(indexRow);//Eliminar Fila
                    dgv.RefreshEdit();
                }
                else
                {
                    MessageBox.Show("No hay registro en esta fila", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            this.CodigoProducto = 0;
            this.IdProducto = 0;
            dgv.Rows.Clear();
            txtTipoAjuste.SelectedIndex = 0;
            txtBuscarHist.Text = string.Empty;
            txtBuscar.Text = string.Empty;
            txtCantExist.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNota.Text = string.Empty;
            //get_art_edit = false;
            //obtener_num_fila = 0;
            txtBuscar.Enabled = true;
            txtCantidad.Enabled = true;
            btnAplicar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            txtTipoAjuste.Enabled = true;
            txtNota.ReadOnly = false;
            txtBuscar.ReadOnly = false;
            txtBuscar.Focus();
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

        private void TxtBuscarHist_KeyPress(object sender, KeyPressEventArgs e)
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
                    var form = new FormCatalogoAjusteInventario();
                    form.txtBuscar.Text = txtBuscarHist.Text;
                    form.ShowDialog();
                    if (form.seleccionado)
                    {
                        dgv.Rows.Clear();
                        int valorId = 0;
                        //var tbl = new List<TblHistAICuerpo>();
                        //var get = new _HistAICuerpo_get();
                        int.TryParse(form.codigo, out valorId);
                        //tbl = get.GetById(valorId);
                        //foreach (var item in tbl)
                        //{
                        //    dgv.Rows.Add(item.FkeyProducto, item.Descripcion, item.CantidadExistenet, item.CantidadAjuste, item.Ajuste, item.TipoAjuste);
                        //}
                        Conexion Miconexion = new Conexion();
                        var dt = new DataTable();
                        var builder = new StringBuilder();
                        builder.Append("SELECT IdHistAICuerpo, FkeyProducto, TblProducto.Codigo, TblProducto.Nombre, CantidadExistenet, CantidadAjuste, Ajuste, TipoAjuste FROM TblHistAICuerpo JOIN TblProducto on FkeyProducto = IdProducto AND FkeyHistAI = '" + valorId + "'");
                        dt = Miconexion.BuscarTabla(builder);
                        foreach (DataRow reader in dt.Rows)
                        {
                            dgv.Rows.Add(reader["FkeyProducto"].ToString(), reader["Codigo"].ToString(), reader["Nombre"].ToString(), reader["CantidadExistenet"].ToString(), reader["CantidadAjuste"].ToString(), reader["Ajuste"].ToString(), reader["TipoAjuste"].ToString());
                        }
                        txtNota.Text = form.nota;
                        txtBuscarHist.Text = form.codigo;

                        txtBuscar.Enabled = false;
                        txtCantidad.Enabled = false;
                        btnAplicar.Enabled = false;
                        btnEditar.Enabled = false;
                        btnEliminar.Enabled = false;
                        txtTipoAjuste.Enabled = false;
                        txtNota.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormAjusteInventario_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F5)
                {
                    Limpiar();
                }
                if (e.KeyData == Keys.F6)
                {
                    Editar();
                }
                if (e.KeyData == Keys.F7)
                {
                    Eliminar();
                }
                if (e.KeyData == Keys.F9)
                {
                    AplicarAjuste();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
