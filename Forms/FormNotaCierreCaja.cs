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
    public partial class FormNotaCierreCaja : Form
    {
        public string texto = string.Empty;
        public FormNotaCierreCaja()
        {
            InitializeComponent();
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.texto = txtNota.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
