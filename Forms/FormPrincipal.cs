using BRL_SVentas.Model;
using BRL_SVentas.Reportes;
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
    public partial class FormPrincipal : Form
    {
        private int childFormNumber = 0;
        private int IdUsuario = 0;
        public bool server = false;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                var tblUsuario = new TblUsuario();
                var getUsuario = new _Usuario_get();
                this.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                tblUsuario = getUsuario.GetById(this.IdUsuario);
                txtUsuario.Text = tblUsuario.Nombre;

                var tblCajaAp = new TblCajaApertura();
                var get = new _CajaApertura_get();
                tblCajaAp = get.GetByEstado();
                if (tblCajaAp != null)
                {
                    if (tblCajaAp.Estado == "CERRADA")
                    {
                        btnCobrosPagos.Enabled = false;
                    }
                    else if (tblCajaAp.Estado == "ABIERTA")
                    {
                        ConfigurationManager.AppSettings["IdCajaApertura"] = tblCajaAp.IdCajaApertura.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
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

        #region GetPermiso
        private bool GetPermiso(int IdModulo)
        {
            try
            {
                var tbl = new List<TblUsuarioPermiso>();
                var get = new _UsuarioPermiso_get();
                tbl = get.GetAllbyIdUsuario(ClaseGetCuenta.GetIdUsuario());
                if (tbl.Count > 0)
                {
                    foreach (var item in tbl)
                    {
                        if (IdModulo == item.IdPermiso)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }
        #endregion

        #region ValidarUsoNCF
        private bool ValidarUsoNCF()
        {
            try
            {
                var tbl = new TblMasterConfig();
                var get = new _MasterConfig_get();
                tbl = get.GetById(1);
                if (tbl.VentasNCF == "APLICADO")
                {
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

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void RegistroDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var getPermiso = new _UsuarioPermiso_get();
            if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 8) || ClaseGetCuenta.GetIdUsuario() == 1)
            {
                var form = new FormRegProducto();
                form.Show();
            }
            else
            {
                AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                return;
            }
        }

        private void ToolStripSplitButton4_ButtonClick(object sender, EventArgs e)
        {
            var getPermiso = new _UsuarioPermiso_get();
            if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 8) || ClaseGetCuenta.GetIdUsuario() == 1)
            {
                var form = new FormRegProducto();
                form.Show();
            }
            else
            {
                AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                return;
            }
        }

        private void AjusteDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var getPermiso = new _UsuarioPermiso_get();
            if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 9) || ClaseGetCuenta.GetIdUsuario() == 1)
            {
                var form = new FormAjusteInventario();
                form.Show();
            }
            else
            {
                AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                return;
            }
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var getPermiso = new _UsuarioPermiso_get();
            if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 5) || ClaseGetCuenta.GetIdUsuario() == 1) 
            {
                var form = new FormRegCliente();
                form.Show();
            }
            else
            {
                AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                return;
            }
        }

        private void ToolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            var getPermiso = new _UsuarioPermiso_get();
            if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 5) || ClaseGetCuenta.GetIdUsuario() == 1)
            {
                var form = new FormRegCliente();
                form.Show();
            }
            else
            {
                AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                return;
            }
        }

        private void ToolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (ClaseGetCuenta.FormCierreCaja)
                {
                    AVISOI("No se puede acceder a este modulo si el formulario del cierre de caja esta abierto.");
                    return;
                }
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 1) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var tblCajaAp = new TblCajaApertura();
                    var get = new _CajaApertura_get();
                    tblCajaAp = get.GetByEstado();
                    if (tblCajaAp != null)
                    {
                        if (tblCajaAp.Estado == "CERRADA")
                        {
                            var formCajaAp = new FormCajaApertura();
                            formCajaAp.txtCaja.Text = tblCajaAp.Monto.ToString("#,###.00;-#,###.00;0.00");
                            formCajaAp.txtMontoInicial.Text = "0.00";
                            formCajaAp.ShowDialog();
                            if (formCajaAp.CajaAbierta)
                            {
                                btnCobrosPagos.Enabled = true;
                                var form = new FormFacturacion();
                                form.Show();
                            }
                        }
                        else if (tblCajaAp.Estado == "ABIERTA")
                        {
                            ConfigurationManager.AppSettings["IdCajaApertura"] = tblCajaAp.IdCajaApertura.ToString();
                            var form = new FormFacturacion();
                            form.Show();
                        }
                    }
                    else
                    {
                        var formCajaAp = new FormCajaApertura();
                        formCajaAp.txtCaja.Text = "0.00";
                        formCajaAp.txtMontoInicial.Text = "0.00";
                        formCajaAp.ShowDialog();
                        if (formCajaAp.CajaAbierta)
                        {
                            btnCobrosPagos.Enabled = true;
                            var form = new FormFacturacion();
                            form.Show();
                        }
                    }
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FacturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClaseGetCuenta.FormCierreCaja)
                {
                    AVISOI("No se puede acceder a este modulo si el formulario del cierre de caja esta abierto.");
                    return;
                }
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 1) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var tblCajaAp = new TblCajaApertura();
                    var get = new _CajaApertura_get();
                    tblCajaAp = get.GetByEstado();
                    if (tblCajaAp != null)
                    {
                        if (tblCajaAp.Estado == "CERRADA")
                        {
                            var formCajaAp = new FormCajaApertura();
                            formCajaAp.txtCaja.Text = tblCajaAp.Monto.ToString("#,###.00;-#,###.00;0.00");
                            formCajaAp.txtMontoInicial.Text = "0.00";
                            formCajaAp.ShowDialog();
                            if (formCajaAp.CajaAbierta)
                            {
                                btnCobrosPagos.Enabled = true;
                                var form = new FormFacturacion();
                                form.Show();
                            }
                        }
                        else if (tblCajaAp.Estado == "ABIERTA")
                        {
                            ConfigurationManager.AppSettings["IdCajaApertura"] = tblCajaAp.IdCajaApertura.ToString();
                            var form = new FormFacturacion();
                            form.Show();
                        }
                    }
                    else
                    {
                        var formCajaAp = new FormCajaApertura();
                        formCajaAp.txtCaja.Text = "0.00";
                        formCajaAp.txtMontoInicial.Text = "0.00";
                        formCajaAp.ShowDialog();
                        if (formCajaAp.CajaAbierta)
                        {
                            btnCobrosPagos.Enabled = true;
                            var form = new FormFacturacion();
                            form.Show();
                        }
                    }
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void CobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCxC();
                form.Show();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void ProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 7) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormRegProveedor();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }

        }

        private void CobrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClaseGetCuenta.FormCierreCaja)
                {
                    AVISOI("No se puede acceder a este modulo si el formulario del cierre de caja esta abierto.");
                    return;
                }

                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 2) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormCxC();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void ToolStripSplitButton5_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (ClaseGetCuenta.FormCierreCaja)
                {
                    AVISOI("No se puede acceder a este modulo si el formulario del cierre de caja esta abierto.");
                    return;
                }
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 2) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormCxC();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void EmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 4) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormEmpresa();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void ToolStripSplitButton3_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 15) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormReporteVentas();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void VentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 15) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormReporteVentas();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void CXCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 16) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormReporteCxC();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void InventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 20) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormReporteInventario();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 4) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormUsuario();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void ComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClaseGetCuenta.FormCierreCaja)
                {
                    AVISOI("No se puede acceder a este modulo si el formulario del cierre de caja esta abierto.");
                    return;
                }

                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 13) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormRegCompras();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 18) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormReporteCompras();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void toolStripSplitButton1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                toolStripSplitButton1.ShowDropDown();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void toolStripSplitButton1_MouseLeave(object sender, EventArgs e)
        {
            //toolStripSplitButton1.HideDropDown();
        }

        private void toolStripSplitButton2_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripSplitButton2.ShowDropDown();
        }

        private void toolStripSplitButton2_MouseLeave(object sender, EventArgs e)
        {
            //toolStripSplitButton2.HideDropDown();
        }

        private void btnCobrosPagos_MouseMove(object sender, MouseEventArgs e)
        {
            btnCobrosPagos.ShowDropDown();
        }

        private void btnCobrosPagos_MouseLeave(object sender, EventArgs e)
        {
            //btnCobrosPagos.HideDropDown();
        }

        private void btnReportes_MouseMove(object sender, MouseEventArgs e)
        {
            btnReportes.ShowDropDown();
        }

        private void btnReportes_MouseLeave(object sender, EventArgs e)
        {
            //btnReportes.HideDropDown();
        }

        private void btnMantenimiento_MouseMove(object sender, MouseEventArgs e)
        {
            btnMantenimiento.ShowDropDown();
        }

        private void btnMantenimiento_MouseLeave(object sender, EventArgs e)
        {
            //btnMantenimiento.HideDropDown();
        }

        private void cobrosCxCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var getPermiso = new _UsuarioPermiso_get();
                if (getPermiso.Validar(ClaseGetCuenta.GetIdUsuario(), 16) || ClaseGetCuenta.GetIdUsuario() == 1)
                {
                    var form = new FormReporteCobros();
                    form.Show();
                }
                else
                {
                    AVISOI("El usuario no tiene permiso para acceder a este modulo.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Esta seguro que desea salir del Sistema?", "BRL-SVentas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
