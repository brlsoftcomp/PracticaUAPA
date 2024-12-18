using BRL_SVentas.Model;
using BRL_SVentas.Servicios;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using BRL_SVentas.Catalogos;
using DoctConsults;

namespace BRL_SVentas.Forms
{
    public partial class FormCobrarCxC : Form
    {
        public int IdFactura = 0;
        public int IdCxC = 0;
        public int IdCobro = 0;
        private int IdUsuario = 0;
        public string nombreCliente = string.Empty;
        DataTable dt;
        public int IdCliente = 0;
        public bool ControlImprimir = false;
  
        public FormCobrarCxC()
        {
            InitializeComponent();
            this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
        }

        private void FormCobrarCxC_Load(object sender, EventArgs e)
        {
            try
            {
                GetCxC();
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

        #region Limpiar
        private void Limpiar()
        {
            try
            {
                this.IdCxC = 0;
                this.IdCobro = 0;
                this.IdFactura = 0;
                this.IdUsuario = 0;
                this.IdCliente = 0;
                dataGridView2.Rows.Clear();
                txtCodigo.Text = string.Empty;
                txtCodigo.Enabled = true;
                txtNombre.Text = string.Empty;
                txtTotalBalance.Text = "0.00";
                txtTotalCobrado.Text = "0.00";
                txtTotalItems.Text = "0.00";
                txtNota.Text = string.Empty;
                btnBuscar.Enabled = true;
                btnAbonar.Enabled = true;
                txtNota.ReadOnly = false;
                btnImprimir.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Cobrar
        private void Cobrar()
        {
            try
            {
                decimal cobrar = 0;
                decimal cobrarAcumulado = 0;
                decimal balance = 0;
                var tblCxC = new TblCxC();
                var get = new _CxC_get();
                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        int.TryParse(dataGridView2["colIdCxC", i].Value.ToString(), out this.IdCxC);
                        tblCxC = get.GetById(this.IdCxC);

                        decimal.TryParse(dataGridView2["colMontoCobrado", i].Value.ToString(), out cobrar);
                        decimal.TryParse(dataGridView2["colBalance", i].Value.ToString(), out balance);
                        cobrarAcumulado += cobrar; 
                        if (cobrar > 0)
                        {
                            balance = balance - cobrar;

                            if (balance == 0)
                            {
                                tblCxC.Estado = "SALDA";
                            }
                            else
                            {
                                tblCxC.Estado = "PENDIENTE";
                            }
                            tblCxC.ClienteNombre = txtNombre.Text;
                            tblCxC.Balance = balance;
                            _CxC.SaveXML(tblCxC);

                            //Registrar abono de inicial:
                            var tblCobro = new TblCobro();
                            tblCobro.IdCxC = IdCxC;
                            tblCobro.IdUsuario = ClaseGetCuenta.GetIdUsuario();
                            int Id = 0;
                            int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out Id);
                            tblCobro.IdCajaApertura = Id;
                            tblCobro.Fecha = DateTime.Now;
                            tblCobro.Abono = cobrar;
                            tblCobro.Monto = tblCxC.Monto;
                            tblCobro.Balance = balance;
                            tblCobro.Nota = txtNota.Text;
                            Id = _Cobros.SaveXML(tblCobro);
                            this.IdCobro = Id;

                            //Registrar en Movimeinto de Caja:
                            var tblCaja = new TblCaja();
                            tblCaja.IdUsuario = this.IdUsuario;
                            tblCaja.Fecha = DateTime.Now;
                            tblCaja.Registro = Id;
                            tblCaja.Modulo = "COBRO CXC";
                            tblCaja.Monto = cobrar;
                            tblCaja.Caja = "#1";
                            tblCaja.Estado = "ABIERTA";
                            int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out Id);
                            tblCaja.IdCajaApertura = Id;
                            _Caja.Save(tblCaja);
                            ImprimirRecibo();
                        }                       
                    }
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ImprimirFactura
        private void ImprimirRecibo()
        {
            try
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Desea imprimir el recibo?", "Cobros CxC", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int IdCuenta = 0;
                    int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdCuenta);
                    var builder = new StringBuilder();
                    builder.Append("SELECT TblCobro.IdCobro, TblCxC.IdFactura, TblFactura.Codigo As NoFactura, TblCobro.Fecha, TblCliente.Nombre As ClienteNombre, TblCobro.Abono, TblCobro.Balance FROM");
                    builder.Append(" TblCobro JOIN TblCxC on TblCxC.IdCxC = TblCobro.IdCxC");
                    builder.Append(" JOIN TblFactura on TblFactura.IdFactura = TblCxC.IdFactura");
                    builder.Append(" JOIN TblCliente on TblCliente.IdCliente = TblCxC.IdCliente");
                    builder.Append(" WHERE TblCobro.IdCobro = '" + this.IdCobro + "'");
                    var conexion = new Conexion();
                    dt = new DataTable();
                    dt = conexion.BuscarTabla(builder);
                    Imprimir();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Imprimir
        private void Imprimir()
        {
            try
            {
                int IdUsuario = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdUsuario);
                FormVisor frm = new FormVisor();
                frm.reportViewer1.Reset();
                var empresa = new TblEmpresa();//BUSCAMOS LOS DATOS DE LA CUENTA DEL DOCTOR
                var get = new _Empresa_get();
                empresa = get.GetById(1);
                var tblUsuario = new TblUsuario();
                var getUsuario = new _Usuario_get();
                tblUsuario = getUsuario.GetById(IdUsuario);

                var tblCxC = new TblCxC();
                var getCxC = new _CxC_get();
                tblCxC = getCxC.GetById(this.IdCxC);

                var tblCobro = new TblCobro();
                var getCobro = new _Cobro_get();
                tblCobro = getCobro.GetById(this.IdCobro);
                //PARAMETROS PARA EL REPORTE
                ReportParameter[] paramCollection = new ReportParameter[11];
                paramCollection[0] = new ReportParameter("Empresa", empresa.Nombre, true);
                paramCollection[1] = new ReportParameter("Direccion", empresa.Direccion, true);
                paramCollection[2] = new ReportParameter("Telefono", empresa.Telefono1, true);
                paramCollection[3] = new ReportParameter("RNC", empresa.RNC, true);
                paramCollection[4] = new ReportParameter("NoRecibo", tblCobro.Codigo.ToString(), true);
                paramCollection[5] = new ReportParameter("NombreCliente", txtNombre.Text, true);
                paramCollection[6] = new ReportParameter("Usuario", tblUsuario.Nombre, true);
                paramCollection[7] = new ReportParameter("Monto", tblCxC.Monto.ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[8] = new ReportParameter("Balance", (tblCobro.Balance + tblCobro.Abono).ToString("#,###.00;-#,###.00;0.00"), true);
                paramCollection[9] = new ReportParameter("Fecha", tblCobro.Fecha.Value.ToShortDateString(), true);
                paramCollection[10] = new ReportParameter("Hora", tblCobro.Fecha.Value.ToShortTimeString(), true);
                
                //frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetReciboCxC", this.dt));
                //frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas.Impresiones.RECIBO_CXC.rdlc";
                //frm.reportViewer1.LocalReport.SetParameters(paramCollection);
                //frm.ShowDialog();

                var form = new FormModoImpresion();
                form.factura = true;
                form.ShowDialog();

                if (form.modoImpresion == "PAPEL ROLLO")
                {
                    ClassImprimir.ImprimirRecibo("DataSetReciboCxC", "Impresiones.RECIBO_CXC", paramCollection, this.dt, form.modoImpresion, "FACTURA");
                    ClassImprimir.ImprimirRecibo("DataSetReciboCxC", "Impresiones.RECIBO_CXC", paramCollection, this.dt, form.modoImpresion, "FACTURA");                 
                }
                else if (form.modoImpresion == "DIGITAL")
                {
                  ClassImprimir.ImprimirReporte("DataSetReciboCxC", "Impresiones.RECIBO_CXC_MEDIA_PG", paramCollection, this.dt);               
                }
                else if (form.modoImpresion == "MEDIA PAGINA")
                {
                   ClassImprimir.ImprimirRecibo("DataSetReciboCxC", "Impresiones.RECIBO_CXC_MEDIA_PG", paramCollection, this.dt, form.modoImpresion, "FACTURA");                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region SumaCxC
        private void SumaCxC()
        {
            try
            {
                decimal balance = 0, valorCobrado = 0;
                decimal Totalbalance = 0, Totalcobrado = 0;
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    decimal.TryParse(dataGridView2["colBalance2", i].Value.ToString(), out balance);
                    Totalbalance += balance;
                    dataGridView2["colBalance", i].Value = balance.ToString("#,###.00;-#,###.00;0.00");
                    decimal.TryParse(dataGridView2["colMontoCobrado", i].Value.ToString(), out valorCobrado);
                    Totalcobrado += valorCobrado;
                }
                txtTotalItems.Text = dataGridView2.RowCount.ToString();
                txtTotalBalance.Text = Totalbalance.ToString("#,###.00;-#,###.00;0.00");
                txtTotalCobrado.Text = Totalcobrado.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region GetCxC
        private void GetCxC()
        {
            try
            {
                if (this.IdCliente > 0)
                {
                    decimal monto = 0, balance = 0, totalBalance = 0;
                    Conexion Miconexion = new Conexion();
                    var dt = new DataTable();
                    var builder = new StringBuilder();
                    builder.Append("SELECT *, TblFactura.Codigo As CodigoFactura FROM TblCxC JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura");
                    builder.Append(" WHERE TblCxC.IdCliente = '" + this.IdCliente + "' AND TblCxC.Estado = 'PENDIENTE'");
                    dt = Miconexion.BuscarTabla(builder);
                    if (dt.Rows.Count > 0)
                    {
                        foreach(DataRow item in dt.Rows)
                        {
                            decimal.TryParse(item["Monto"].ToString(), out monto);
                            decimal.TryParse(item["Balance"].ToString(), out balance);

                            dataGridView2.Rows.Add(item["IdCxC"].ToString(), item["IdFactura"].ToString(), item["CodigoFactura"].ToString(), item["Fecha"], monto.ToString("#,###.00;-#,###.00;0.00"), balance.ToString("#,###.00;-#,###.00;0.00"), "0.00");

                            totalBalance += balance;
                        }
                        txtTotalItems.Text = dataGridView2.RowCount.ToString();
                        txtTotalBalance.Text = totalBalance.ToString("#,###.00;-#,###.00;0.00");
                    }
                }
                //SumaCxC();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetCobro
        private void GetCobro()
        {
            try
            {
                var Miconexion = new Conexion();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT TblCobro.IdCobro, TblCobro.IdCxC, TblCxC.IdFactura, TblFactura.Codigo As NoFactura, TblCobro.Fecha, TblCobro.Monto, TblCobro.Balance, TblCobro.Abono, TblCliente.Nombre, TblCobro.Nota FROM TblCobro JOIN TblCxC ON TblCxC.IdCxC = TblCobro.IdCxC"));
                builder.Append(string.Format(" JOIN TblFactura ON TblFactura.IdFactura = TblCxC.IdFactura"));
                builder.Append(string.Format(" JOIN TblCliente ON TblCliente.IdCliente = TblCxC.IdCliente"));
                builder.Append(string.Format(" WHERE TblCobro.Codigo = '" + txtCodigo.Text + "'"));
                dt = Miconexion.BuscarTabla(builder);
                if (dt.Rows.Count > 0)
                {
                    txtCodigo.Enabled = false;
                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns[5].ReadOnly = true;
                    btnBuscar.Enabled = false;

                    foreach (DataRow item in dt.Rows)
                    {
                        dataGridView2.Rows.Add(item["IdCxC"].ToString(), item["IdFactura"].ToString(), item["NoFactura"].ToString(), item["Fecha"], item["Monto"].ToString(), item["Balance"].ToString(), item["Abono"].ToString());
                        int.TryParse(item["IdCxC"].ToString(), out this.IdCxC);
                        int.TryParse(item["IdCobro"].ToString(), out this.IdCobro);
                        txtNombre.Text = item["Nombre"].ToString();
                        txtTotalItems.Text = dataGridView2.RowCount.ToString();
                        txtTotalBalance.Text = item["Balance"].ToString();
                        txtTotalCobrado.Text = item["Abono"].ToString();
                        txtNota.Text = item["Nota"].ToString();
                    }
                    dataGridView2.ClearSelection();
                }
                else
                {
                    AVISOI("Su busqueda no a producido resultados.");
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        private void BtnAbonar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal monto = 0;
                decimal.TryParse(txtTotalCobrado.Text, out monto);
                if (monto > 0)
                {
                    if (MessageBox.Show("Realmente desea aplicar el cobro?", "Imprimir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Cobrar();
                    }
                }
                else
                {
                    AVISOI("El monto a cobrar es requerido.");
                    return;
                }

            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                btnBuscar.Enabled = true;
                Limpiar();
            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }
        }

        private void TxtAbonar_KeyPress(object sender, KeyPressEventArgs e)
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
                    btnAbonar.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtAbonar_Validated(object sender, EventArgs e)
        {
            try
            {
                //decimal monto = 0;
                //decimal.TryParse(txtAbonar.Text, out monto);
                //txtAbonar.Text = monto.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void dataGridView2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    decimal totalCobrado = 0, totalBalance = 0;
                    decimal cobro = 0;
                    decimal.TryParse(dataGridView2.CurrentRow.Cells["colMontoCobrado"].Value.ToString(), out cobro);
                    decimal pendiente = 0;
                    decimal.TryParse(dataGridView2.CurrentRow.Cells["colBalance"].Value.ToString(), out pendiente);
                    decimal reciduo = 0;
                    if (cobro > pendiente)
                    {
                        dataGridView2.CurrentRow.Cells["colMontoCobrado"].Value = pendiente.ToString("#,###.00;-#,###.00;0.00");
                        reciduo = cobro - pendiente;
                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            decimal.TryParse(dataGridView2["colMontoCobrado", i].Value.ToString(), out cobro);
                            if (cobro == 0)
                            {
                                decimal.TryParse(dataGridView2["colBalance", i].Value.ToString(), out pendiente);
                                if (reciduo > pendiente)
                                {
                                    dataGridView2["colMontoCobrado", i].Value = pendiente;
                                }
                                else
                                {
                                    dataGridView2["colMontoCobrado", i].Value = reciduo;
                                    break;
                                }
                                reciduo = reciduo - pendiente;
                            }
                        }
                    }
                    decimal.TryParse(dataGridView2.CurrentRow.Cells["colMontoCobrado"].Value.ToString(), out cobro);
                    dataGridView2.CurrentRow.Cells["colMontoCobrado"].Value = cobro.ToString("#,###.00;-#,###.00;0.00");

                    for (int i = 0; i < dataGridView2.RowCount; i++)
                    {
                        decimal.TryParse(dataGridView2["colMontoCobrado", i].Value.ToString(), out cobro);
                        decimal.TryParse(dataGridView2["colBalance", i].Value.ToString(), out pendiente);
                        totalCobrado += cobro;
                        totalBalance += pendiente;
                    }
                    txtTotalCobrado.Text = totalCobrado.ToString("#,###.00;-#,###.00;0.00");
                    txtTotalBalance.Text = totalBalance.ToString("#,###.00;-#,###.00;0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView2_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7 || e.ColumnIndex == 8)
                    this.Cursor = Cursors.Hand;
                else
                    this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int codigo = 0;
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 7)
                    {
                        int.TryParse(dataGridView2.CurrentRow.Cells[0].Value.ToString(), out this.IdCxC);
                        int.TryParse(dataGridView2.CurrentRow.Cells[1].Value.ToString(), out this.IdFactura);
                        int.TryParse(dataGridView2.CurrentRow.Cells[2].Value.ToString(), out codigo);
                        if (this.IdCxC > 0 && this.IdFactura > 0)
                        {
                            var form = new FormHistCobros();
                            form.IdFactura = this.IdFactura;
                            form.txtCodigo.Text = codigo.ToString();
                            form.IdCxC = this.IdCxC;
                            form.Nombre = txtNombre.Text;
                            form.ShowDialog();
                        }
                    }
                    //if (e.ColumnIndex == 8)
                    //{
                    //    int.TryParse(dataGridView2.CurrentRow.Cells[1].Value.ToString(), out this.IdFactura);
                    //    int.TryParse(dataGridView2.CurrentRow.Cells[2].Value.ToString(), out codigo);
                    //    if (this.IdFactura > 0)
                    //    {
                    //        var form = new FormMostrarFactura();
                    //        form.Modulo = "CXC";
                    //        form.Cliente = txtNombre.Text;
                    //        form.txtNoFactura.Text = codigo.ToString();
                    //        form.IdFactura = this.IdFactura;
                    //        form.ShowDialog();
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int valorInt = 0;
                var form = new FormCatalogoCobro();
                form.ShowDialog();             
                if(form.IdCobro > 0 && form.Codigo > 0)
                {
                    valorInt = form.Codigo;
                    this.IdCobro = form.IdCobro;
                    txtCodigo.Text = valorInt.ToString();
                    txtNombre.Text = form.nombreCliente;
                    GetCobro();
                    btnImprimir.Enabled = true;
                    btnAbonar.Enabled = false;
                    txtNota.ReadOnly = true;
                    dataGridView2.Columns[6].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.IdCobro > 0 && this.IdCxC > 0)
                {
                    ImprimirRecibo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!string.IsNullOrEmpty(txtCodigo.Text))
                    {
                        GetCobro();
                        btnImprimir.Enabled = true;
                        btnAbonar.Enabled = false;
                        txtNota.ReadOnly = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormCobrarCxC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F5)
                {
                    Limpiar();
                }
                if (e.KeyData == Keys.F6)
                {
                    if (this.IdCobro > 0 && this.IdCxC > 0)
                    {
                        ImprimirRecibo();
                    }
                }
                if (e.KeyData == Keys.F7)
                {
                    decimal monto = 0;
                    decimal.TryParse(txtTotalCobrado.Text, out monto);
                    if (monto > 0)
                    {
                        if (MessageBox.Show("Realmente desea aplicar el cobro?", "Imprimir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Cobrar();
                        }
                    }
                    else
                    {
                        AVISOI("El monto a cobrar es requerido.");
                        return;
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
