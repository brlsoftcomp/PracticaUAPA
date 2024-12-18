using BRL_SVentas.Model;
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
    public partial class FormConfVentas : Form
    {
        public FormConfVentas()
        {
            InitializeComponent();
        }

        private void FormConfVentas_Load(object sender, EventArgs e)
        {
            try
            {
                var tbl = new TblMasterConfig();
                var get = new _MasterConfig_get();
                tbl = get.GetById(1);
                txtNCF.Text = tbl.VentasNCF;
                txtNotificacion.Text = tbl.NotificacionNCF.ToString();
                txtContizLogo.Text = tbl.ContizacionLogo;
                txtImprimir.Text = tbl.PapelFactura;
                txtCopiaFactura.Text = tbl.ImprimirCopiaFact;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        #region Guardar
        private void Guardar()
        {
            try
            {
                var tbl = new TblMasterConfig();
                var get = new _MasterConfig_get();
                tbl = get.GetById(1);
                int valorInt = 0;
                if (tbl != null)
                {
                    //if(txtNCF.Text == "NO APLICADO")
                    //ConfigurationManager.AppSettings["Main.ConnectionString"] = "Data Source=SQL5106.site4now.net;Initial Catalog=db_a95a77_brlsventas;User Id=db_a95a77_brlsventas_admin;Password=BRL0560815";
                    //else
                    //ConfigurationManager.AppSettings["Main.ConnectionString"] = "Server=DESKTOP-TP3F8EN\\SQLEXPRESS;Database=BRL_SVentas;User Id=sa;Password=0560815;";

                    tbl.IdMasterConfig = 1;
                    tbl.Fecha = DateTime.Now;
                    tbl.VentasNCF = txtNCF.Text;
                    int.TryParse(txtNotificacion.Text,out valorInt);
                    tbl.NotificacionNCF = valorInt;
                    tbl.ContizacionLogo = txtContizLogo.Text;
                    tbl.ImprimirCopiaFact = txtCopiaFactura.Text;
                    if (_MasterConfig.Update(tbl))
                    {
                        AVISOI("DATOS GUARDADOS!");
                    }
                }
                else
                {
                    tbl = new TblMasterConfig();
                    tbl.IdMasterConfig = 1;
                    tbl.Fecha = DateTime.Now;
                    tbl.VentasNCF = txtNCF.Text;
                    int.TryParse(txtNotificacion.Text, out valorInt);
                    tbl.NotificacionNCF = valorInt;
                    tbl.ContizacionLogo = txtContizLogo.Text;
                    tbl.ImprimirCopiaFact = txtCopiaFactura.Text;
                    if (_MasterConfig.Save(tbl))
                    {
                        AVISOI("DATOS GUARDADOS!");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        private void btnVentasNcf_Click(object sender, EventArgs e)
        {
            try
            {
                Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtNotificacion_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
