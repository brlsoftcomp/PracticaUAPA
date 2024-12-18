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
    public partial class FormDevuelta : Form
    {
        public FormDevuelta()
        {
            InitializeComponent();
        }

        private void FormDevuelta_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
        }
        private void FormDevuelta_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    this.Close();
                }
                if (e.KeyData == Keys.Escape)
                {
                    this.Close();
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
    }
}
