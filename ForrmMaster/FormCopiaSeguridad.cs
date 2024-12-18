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
    public partial class FormCopiaSeguridad : Form
    {
        int Salir = 0;
        public FormCopiaSeguridad()
        {
            InitializeComponent();
        }

        private void FormCopiaSeguridad_Load(object sender, EventArgs e)
        {
            try
            {
                if (ConfigurationManager.AppSettings["Logo"] == "0")
                {
                    timer1.Start();
                    var conexion = new Conexion();
                    conexion.CopiaSeguridad("D:\\BRLSVentas_BackUp");
                }
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
                MessageBox.Show(Mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Salir++;
                txtPuntos.Text = txtPuntos.Text + ".";
                if (this.Salir == 5)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Aviso(ex.ToString());
            }
        }
    }
}
