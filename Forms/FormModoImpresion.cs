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
    public partial class FormModoImpresion : Form
    {
        public string modoImpresion = string.Empty;
        public bool factura = false;
        public FormModoImpresion()
        {
            InitializeComponent();
        }

        private void FormModoImpresion_Load(object sender, EventArgs e)
        {
            try
            {
                if (factura)
                {
                    txtImprimir.Items.Clear();
                    txtImprimir.Items.Add("PAPEL ROLLO");
                    txtImprimir.Items.Add("MEDIA PAGINA");
                    txtImprimir.Items.Add("DIGITAL");
                    txtImprimir.Items.Add("NO IMPRIMIR");
                    var tbl = new TblMasterConfig();
                    var get = new _MasterConfig_get();
                    tbl = get.GetById(1);
                    if (tbl != null)
                    {
                        txtImprimir.Text = tbl.PapelFactura;
                    }
                    else
                    {
                        txtImprimir.SelectedIndex = 0;
                    }
                }
                else
                {
                    txtImprimir.Items.Clear();
                    txtImprimir.Items.Add("MEDIA PAGINA");
                    txtImprimir.Items.Add("DIGITAL");
                    txtImprimir.Items.Add("NO IMPRIMIR");
                    txtImprimir.SelectedIndex = 0;
                }

                modoImpresion = txtImprimir.Text;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                modoImpresion = string.Empty;
                this.Close();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtImprimir_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!factura)
                {
                    if (txtImprimir.SelectedIndex == 2)
                    {
                        modoImpresion = string.Empty;
                    }
                    else
                    {
                        modoImpresion = txtImprimir.Text;
                    }
                }
                else
                {
                    if (txtImprimir.SelectedIndex == 3)
                    {
                        modoImpresion = string.Empty;
                    }
                    else
                    {
                        modoImpresion = txtImprimir.Text;
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
