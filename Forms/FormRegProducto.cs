using BRL_SVentas.Catalogos;
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
    public partial class FormRegProducto : Form
    {
        public int IdProducto = 0;
        public int IdProveedor = 0;
        public int Codigo = 0;
        int cantidad = 0;

        public FormRegProducto()
        {
            InitializeComponent();
            this.KeyPreview = true;//Esto es para que KeyPress se activen desde form completo.
        }

        private void FormRegProducto_Load(object sender, EventArgs e)
        {
            try
            {
                txtItbisTasa.SelectedIndex = 0;
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

        #region Limpiar
        private void Limpiar()
        {
            //Limpiamos los textbox
            this.IdProducto = 0;
            this.IdProveedor = 0;
            this.Codigo = 0;
            this.cantidad = 0;
            txtCodigo.Clear();
            //txtCodigo.Enabled = true;
            txtProveedor.Text = string.Empty;
            txtDescripcion.Clear();
            txtCosto.Text = "0.00";
            txtCostoItbis.Text = "0.00";
            txtPrecVenta.Text = "0.00";
            txtPrecVenta.Enabled = true;
            txtPrecMinimo.Text = "0.00";
            txtItbis.Text = "0.00";
            txtPGanancia.Text = "30.00";
            txtItbisTasa.Text = "18";
            txtGannaciaNeta.Text = "0.00";
            txtEstado.SelectedIndex = 0;
            DesBloquear();
        }
        #endregion

        #region Limpiar2
        private void Limpiar2()
        {
            //Limpiamos los textbox
            this.IdProducto = 0;
            this.Codigo = 0;
            this.cantidad = 0;
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtCosto.Text = "0.00";
            txtCostoItbis.Text = "0.00";
            txtPrecVenta.Text = "0.00";
            txtPrecVenta.Enabled = true;
            txtPrecMinimo.Text = "0.00";
            txtItbis.Text = "0.00";
            txtPGanancia.Text = "30.00";
            txtItbisTasa.Text = "18";
            txtGannaciaNeta.Text = "0.00";
            txtEstado.SelectedIndex = 0;
            DesBloquear();
        }
        #endregion

        #region Bloquear
        private void Bloquear()
        {
            try
            {
                //txtCodigo.Enabled = true;
                txtDescripcion.Enabled = false;
                txtCosto.Enabled = false;
                txtCostoItbis.Enabled = false;
                txtPrecVenta.Enabled = false;
                txtPrecMinimo.Enabled = false;
                txtItbis.Enabled = false;
                txtPGanancia.Enabled = false;
                txtItbisTasa.Enabled = false;
                txtEstado.Enabled = false;
                //txtGannaciaNeta.Enabled = false;
                //txtItbisInculido.Enabled = false;
                btnBuscarProveedor.Enabled = false;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region DesBloquear
        private void DesBloquear()
        {
            try
            {
                //txtCodigo.Enabled = true;
                txtDescripcion.Enabled = true;
                txtCosto.Enabled = true;
                txtCostoItbis.Enabled = true;
                txtPrecVenta.Enabled = true;
                txtPrecMinimo.Enabled = true;
                txtItbis.Enabled = true;
                txtPGanancia.Enabled = true;
                txtItbisTasa.Enabled = true;
                txtEstado.Enabled = true;
                //txtGannaciaNeta.Enabled = true;
                //txtItbisInculido.Enabled = true;
                btnBuscarProveedor.Enabled = true;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region GUARDAR
        private void Guardar()
        {

            try
            {
                var tblControlAlmacen = new TblControlAlmacen(); 
                TblProducto producto = new TblProducto();
                var guardar = new _Productos();
                var get = new _Producto_get();
                DialogResult result = new DialogResult();

                decimal getPminimo = 0;
                decimal getCosto = 0;
                decimal costoItebis = 0;
                decimal getpventa = 0;
                decimal tasaItbis = 0;
                decimal.TryParse(txtCosto.Text, out getCosto);
                decimal.TryParse(txtCostoItbis.Text, out costoItebis);
                decimal.TryParse(txtPrecVenta.Text, out getpventa);
                decimal.TryParse(txtPrecMinimo.Text, out getPminimo);
                decimal.TryParse(txtItbisTasa.Text, out tasaItbis);
                //Itbis = getpventa - (getpventa / (1 + (tasaItbis / 100)));

                if (tasaItbis > 18 || tasaItbis < 0)
                {
                    AVISOW("El valor del Itbis no puede ser mayor que el 18% o menor que 0.");
                    return;
                }
                if (getpventa <= costoItebis)
                {
                    AVISOW("El valor del precio de venta no puede ser menor o igual al costo total del producto.");
                    return;
                }
                if (getPminimo <= costoItebis || getPminimo > getpventa)
                {
                    MessageBox.Show("El precio minimo ingresado es menor que el costo del producto, o mayor que el precio de la venta.", "Registrar Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Condision que verifica si todos el formulario esta lleno
                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    AVISOI("Faltan datos por ingresar en el formulario!");
                    return;
                }
                if (string.IsNullOrEmpty(txtCosto.Text))
                {
                    AVISOI("Faltan datos por ingresar en el formulario!");
                    return;
                }
                if (string.IsNullOrEmpty(txtPrecVenta.Text))
                {
                    AVISOI("Faltan datos por ingresar en el formulario!");
                    return;
                }
                if (string.IsNullOrEmpty(txtPrecMinimo.Text))
                {
                    AVISOI("Faltan datos por ingresar en el formulario!");
                    return;
                }
                if (string.IsNullOrEmpty(txtItbisTasa.Text))
                {
                    AVISOI("Faltan datos por ingresar en el formulario!");
                    return;
                }
                if (this.IdProveedor <= 0)
                {
                    AVISOI("El Proveedor es requerido.");
                    return;
                }
                result = MessageBox.Show("Realmente desea registrar este Producto?", "Registrar Producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {

                    //Insertar los datos ingresado:
                    int valorInt = 0;
                    decimal valorFloat = 0;
                    producto.IdProducto = this.IdProducto;
                    producto.IdProveedor = this.IdProveedor;
                    producto.Codigo = this.Codigo;
                    producto.Nombre = txtDescripcion.Text;
                    decimal.TryParse(txtCostoItbis.Text.ToString(), out valorFloat);
                    producto.PrecioCompra = valorFloat;
                    decimal.TryParse(txtPrecVenta.Text.ToString(), out valorFloat);
                    producto.PrecioVenta = valorFloat;
                    decimal.TryParse(txtPrecMinimo.Text.ToString(), out valorFloat);
                    producto.PrecioMinimo = valorFloat;
                    producto.CantidadExistente = this.cantidad;
                    producto.Itbis = tasaItbis;
                    producto.Tope = 0;
                    producto.Estado = txtEstado.Text;
                    if (this.IdProducto == 0)
                    {
                        this.IdProducto = _Productos.Save(producto);
                        AVISOI("DATOS GUARDADOS!!");
                    }
                    else if (this.IdProducto > 0)
                    {
                        if (_Productos.Update(producto))
                        {
                            AVISOI("DATOS GUARDADOS!!");
                        }
                    }
                    txtCodigo.Text = this.IdProducto.ToString();
                    Limpiar2();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error en el Ingreso de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtDescripcion.Focus();
        }

        #endregion

        #region GetProducto
        public void GetProducto()
        {
            try
            {
                if (this.IdProducto != 0)//Verificar si hay registro en la fila para editar.
                {
                    Conexion Miconexion = new Conexion();
                    var dt = new DataTable();
                    var builder = new StringBuilder();
                    builder.Append("SELECT *, TblProveedor.Nombre As Proveedor, TblProveedor.ItbisIncluido FROM TblProducto");
                    builder.Append(" JOIN TblProveedor ON TblProveedor.IdProveedor = TblProducto.IdProveedor WHERE IdProducto = '" + this.IdProducto + "'");
                    dt = Miconexion.BuscarTabla(builder);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            int.TryParse(item["Codigo"].ToString(), out this.Codigo);
                            int.TryParse(item["IdProveedor"].ToString(), out this.IdProveedor);
                            txtCodigo.Text = this.Codigo.ToString();
                            txtProveedor.Text = item["Proveedor"].ToString();
                            txtDescripcion.Text = item["Nombre"].ToString();
                            txtCosto.Text = item["PrecioCompra"].ToString();
                            txtCostoItbis.Text = item["PrecioCompra"].ToString();
                            txtItbisTasa.Text = item["Itbis"].ToString();
                            txtPrecVenta.Text = item["PrecioVenta"].ToString();
                            txtPrecMinimo.Text = item["PrecioMinimo"].ToString();
                            txtEstado.Text = item["Estado"].ToString();
                            if (item["ItbisIncluido"].ToString() == "SI")
                            {
                                txtItbisInculido.Checked = true;
                            }
                            else if (item["ItbisIncluido"].ToString() == "NO")
                            {
                                txtItbisInculido.Checked = false;
                            }
                        }
                    }
                    decimal precio, itebisTasa, itbis, itbisAdelantado, pganancia, costoItebis, gananciaNeta;
                    decimal.TryParse(txtPrecVenta.Text, out precio);
                    decimal.TryParse(txtItbisTasa.Text, out itebisTasa);
                    decimal.TryParse(txtCostoItbis.Text, out costoItebis);
                    if (precio > costoItebis)
                    {
                        itbisAdelantado = (costoItebis - (costoItebis / (1 + (itebisTasa / 100))));

                        itbis = precio - (precio / (1 + (itebisTasa / 100)));
                        gananciaNeta = (precio - (costoItebis + (precio - (precio / (1 + (itebisTasa / 100)))))) + itbisAdelantado;
                        pganancia = ((precio - costoItebis) / costoItebis * 100);
                        txtPGanancia.Text = pganancia.ToString("#,###.00;-#,###.00;0.00");
                        txtGannaciaNeta.Text = gananciaNeta.ToString("#,###.00;-#,###.00;0.00");
                        txtPrecVenta.Text = precio.ToString("#,###.00;-#,###.00;0.00");
                        txtItbis.Text = itbis.ToString("#,###.00;-#,###.00;0.00");
                        txtPrecMinimo.Text = txtPrecVenta.Text;
                        btnGuardar.Focus();
                    }
                    else
                    {
                        AVISOI("El precio de venta debe ser mayor que el costo.");
                        return;
                    }
                }
                else
                {
                    AVISOI("Para editar un producto primero debe seleccionarlo.");
                    return;
                }
            }
            catch (Exception ex)
            {

                AVISOW(ex.ToString());
            }
        }
        #endregion

        private void Tb_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
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
                txtDescripcion.Focus();
            }
        }

        private void TxtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtCosto.Focus();
            }
        }

        private void TxtCosto_KeyPress(object sender, KeyPressEventArgs e)
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
                    //CARCULAR  COSTO MAS ITBS:
                    txtPrecVenta.Text = "0.00";
                    txtItbis.Text = "0.00";
                    txtPrecMinimo.Text = "0.00";
                    txtGannaciaNeta.Text = "0.00";
                    decimal valorDecimal = 0, tasa = 0, costoMasItebis = 0;
                    decimal.TryParse(txtCosto.Text, out valorDecimal);
                    decimal.TryParse(txtItbisTasa.Text, out tasa);
                    if (tasa > 0 && !txtItbisInculido.Checked)
                    {
                        costoMasItebis = valorDecimal + (valorDecimal * tasa / 100);
                    }
                    else
                    {
                        costoMasItebis = valorDecimal;
                    }
                    txtPGanancia.Text = "30.00";
                    txtPrecVenta.Text = "0.00";
                    txtPrecMinimo.Text = "0.00";
                    txtCosto.Text = valorDecimal.ToString("#,###.00;-#,###.00;0.00");
                    txtCostoItbis.Text = costoMasItebis.ToString("#,###.00;-#,###.00;0.00");

                    if (valorDecimal <= 0)
                    {
                        AVISOW("El valor del Consto es Invalido.");
                        return;
                    }
                    txtPGanancia.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtItbis_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                float valor = 0;
                float.TryParse(txtItbisTasa.Text, out valor);
                if (valor > 18)
                {
                    AVISOW("El valor del Itbis no puede ser mayor que el 18%.");
                    return;
                }
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
                    decimal costo = 0, itebis = 0, costoMasItebis = 0;
                    decimal.TryParse(txtCosto.Text, out costo);
                    decimal.TryParse(txtItbisTasa.Text, out itebis);
                    if (itebis > 0)
                    {
                        costoMasItebis = costo + (costo * itebis / 100);
                    }
                    else
                    {
                        costoMasItebis = costo;
                    }
                    txtPGanancia.Text = "30.00";
                    txtPrecVenta.Text = "0.00";
                    txtItbis.Text = "0.00";
                    txtPrecMinimo.Text = "0.00";
                    txtCostoItbis.Text = costoMasItebis.ToString("#,###.00;-#,###.00;0.00");
                    txtPGanancia.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtPGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
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
                    decimal precio, itebisTasa, itbis, itbisAdelantado, pganancia, costoItebis, gananciaNeta;
                    decimal.TryParse(txtPrecVenta.Text, out precio);
                    decimal.TryParse(txtItbisTasa.Text, out itebisTasa);
                    decimal.TryParse(txtPGanancia.Text, out pganancia);
                    decimal.TryParse(txtCostoItbis.Text, out costoItebis);
                    if (pganancia == 0)
                    {
                        AVISOW("El % de la ganacia debe ser mayor que cero (0).");
                        return;
                    }
                    itbisAdelantado = (costoItebis - (costoItebis / (1 + (itebisTasa / 100))));
                    precio = ((costoItebis / 100 * pganancia) + costoItebis);
                    itbis = precio - (precio / (1 + (itebisTasa / 100)));
                    gananciaNeta = (precio - (costoItebis + (precio - (precio / (1 + (itebisTasa / 100)))))) + itbisAdelantado;
                    txtGannaciaNeta.Text = gananciaNeta.ToString("#,###.00;-#,###.00;0.00");
                    txtPrecVenta.Text = precio.ToString("#,###.00;-#,###.00;0.00");
                    txtItbis.Text = itbis.ToString("#,###.00;-#,###.00;0.00");
                    txtPGanancia.Text = pganancia.ToString("#,###.00;-#,###.00;0.00");
                    txtPrecVenta.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtPrecVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
                    decimal precio, itebisTasa, itbis, itbisAdelantado, pganancia, costoItebis, gananciaNeta;
                    decimal.TryParse(txtPrecVenta.Text, out precio);
                    decimal.TryParse(txtItbisTasa.Text, out itebisTasa);
                    decimal.TryParse(txtPGanancia.Text, out pganancia);
                    decimal.TryParse(txtCostoItbis.Text, out costoItebis);
                    if (precio > costoItebis)
                    {
                        itbisAdelantado = (costoItebis - (costoItebis / (1 + (itebisTasa / 100))));

                        itbis = precio - (precio / (1 + (itebisTasa / 100)));
                        gananciaNeta = (precio - (costoItebis + (precio - (precio / (1 + (itebisTasa / 100)))))) + itbisAdelantado;
                        pganancia = ((precio - costoItebis) / costoItebis * 100);
                        txtPGanancia.Text = pganancia.ToString("#,###.00;-#,###.00;0.00");
                        txtGannaciaNeta.Text = gananciaNeta.ToString("#,###.00;-#,###.00;0.00");
                        txtPrecVenta.Text = precio.ToString("#,###.00;-#,###.00;0.00");
                        txtItbis.Text = itbis.ToString("#,###.00;-#,###.00;0.00");
                        
                        float valorF1 = 0, valorF2 = 0.1f;
                        float.TryParse(precio.ToString(), out valorF1);
                        valorF1 = valorF1 * valorF2;

                        float.TryParse(precio.ToString(), out valorF2);
                        valorF2 = valorF2 - valorF1;

                        txtPrecMinimo.Text = valorF2.ToString("#,###.00;-#,###.00;0.00");
                        btnGuardar.Focus();
                    }
                    else
                    {
                        AVISOI("El procio de venta debe ser mayor que el costo.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }          
        }

        private void TxtPrecMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
                    decimal valor = 0, valor2 = 0, costo = 0;
                    decimal.TryParse(txtPrecVenta.Text, out valor);
                    decimal.TryParse(txtPrecMinimo.Text, out valor2);
                    decimal.TryParse(txtCostoItbis.Text, out costo);
                    if (valor < valor2)
                    {
                        AVISOI("El precio minimo no puede ser mayor al precio de venta.");
                        return;
                    }
                    if (valor2 <= costo)
                    {
                        AVISOI("El precio minimo no puede ser menor o igual al costo del producto.");
                        return;
                    }
                    txtPrecMinimo.Text = valor2.ToString("#,###.00;-#,###.00;0.00");
                    txtEstado.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }

        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
                    Guardar();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }

        }

        private void FormRegProducto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //LIMPIAR:
                if (e.KeyData == Keys.F5)
                {
                    Limpiar();
                }
                //EDITAR:
                if (e.KeyData == Keys.F6)
                {
                    DesBloquear();
                }
                //GUARDAR:
                if (e.KeyData == Keys.F8)
                {
                    Guardar();
                    txtDescripcion.Focus();
                }

            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Guardar();
                txtDescripcion.Focus();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtCosto_Validated(object sender, EventArgs e)
        {
            try
            {
                //CARCULAR  COSTO MAS ITBS:
                txtPrecVenta.Text = "0.00";
                txtPrecMinimo.Text = "0.00";
                txtItbis.Text = "0.00";
                txtGannaciaNeta.Text = "0.00";
                decimal valorDecimal = 0, tasa = 0, costoMasItebis = 0;
                decimal.TryParse(txtCosto.Text, out valorDecimal);
                decimal.TryParse(txtItbisTasa.Text, out tasa);
                if (tasa > 0 && !txtItbisInculido.Checked)
                {
                    costoMasItebis = valorDecimal + (valorDecimal * tasa / 100);
                }
                else
                {
                    costoMasItebis = valorDecimal;
                }
                txtPGanancia.Text = "30.00";
                txtPrecVenta.Text = "0.00";
                txtPrecMinimo.Text = "0.00";
                txtCosto.Text = valorDecimal.ToString("#,###.00;-#,###.00;0.00");
                txtCostoItbis.Text = costoMasItebis.ToString("#,###.00;-#,###.00;0.00");

                if (valorDecimal <= 0)
                {
                    //AVISOW("El valor del Consto es Invalido.");
                    return;
                }
                txtPGanancia.Focus();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtPrecVenta_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal precio, itebisTasa, itbis, itbisAdelantado, pganancia, costoItebis, gananciaNeta;
                decimal.TryParse(txtPrecVenta.Text, out precio);
                decimal.TryParse(txtItbisTasa.Text, out itebisTasa);
                decimal.TryParse(txtPGanancia.Text, out pganancia);
                decimal.TryParse(txtCostoItbis.Text, out costoItebis);
                if (precio > costoItebis)
                {
                    itbisAdelantado = (costoItebis - (costoItebis / (1 + (itebisTasa / 100))));

                    itbis = precio - (precio / (1 + (itebisTasa / 100)));
                    gananciaNeta = (precio - (costoItebis + (precio - (precio / (1 + (itebisTasa / 100)))))) + itbisAdelantado;
                    pganancia = ((precio - costoItebis) / costoItebis * 100);
                    txtPGanancia.Text = pganancia.ToString("#,###.00;-#,###.00;0.00");
                    txtGannaciaNeta.Text = gananciaNeta.ToString("#,###.00;-#,###.00;0.00");
                    txtPrecVenta.Text = precio.ToString("#,###.00;-#,###.00;0.00");
                    txtItbis.Text = itbis.ToString("#,###.00;-#,###.00;0.00");
                    
                    float valorF1 = 0, valorF2 = 0.1f;
                    float.TryParse(precio.ToString(), out valorF1);
                    valorF1 = valorF1 * valorF2;

                    float.TryParse(precio.ToString(), out valorF2);
                    valorF2 = valorF2 - valorF1;

                    txtPrecMinimo.Text = valorF2.ToString("#,###.00;-#,###.00;0.00");
                    txtPrecMinimo.Focus();
                }
                else
                {
                    //AVISOI("El procio de venta debe ser mayor que el costo.");
                    return;
                }
                //txtPrecMinimo.Focus();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtPrecMinimo_Validated(object sender, EventArgs e)
        {
            try
            {
                //decimal valor = 0, valor2 = 0, costo = 0;
                //decimal.TryParse(txtPrecVenta.Text, out valor);
                //decimal.TryParse(txtPrecMinimo.Text, out valor2);
                //decimal.TryParse(txtCostoItbis.Text, out costo);
                //if (valor <= valor2)
                //{
                //    AVISOI("El precio minimo no puede ser mayor o igual al precio de venta.");
                //    return;
                //}
                //if (valor2 <= costo)
                //{
                //    AVISOI("El precio minimo no puede ser menor o igual al costo del producto.");
                //    return;
                //}
                //txtPrecMinimo.Text = valor2.ToString("#,###.00;-#,###.00;0.00");
                //txtPrecMinimo.Focus();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void TxtItbis_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal costo = 0, itbisTasa = 0, costoMasItebis = 0;
                decimal.TryParse(txtCosto.Text, out costo);
                decimal.TryParse(txtItbisTasa.Text, out itbisTasa);
                if (itbisTasa > 0 && !txtItbisInculido.Checked)
                {
                    costoMasItebis = costo + (costo * itbisTasa / 100);
                }
                else
                {
                    costoMasItebis = costo;
                }
                txtPGanancia.Text = "30.00";
                txtPrecVenta.Text = string.Empty;
                txtItbis.Text = "0.00";
                txtPrecMinimo.Text = string.Empty;
                txtCostoItbis.Text = costoMasItebis.ToString("#,###.00;-#,###.00;0.00");
                txtPGanancia.Focus();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoProductos();
                form.ShowDialog();
                if(form.Id > 0)
                {
                    btnEditar.Enabled = true;
                    Bloquear();
                    this.IdProducto = form.Id;
                    this.Codigo = form.codigo;
                    this.cantidad = form.cantidad;
                    GetProducto();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }



        private void txtCosto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItbisInculido_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //CARCULAR  COSTO MAS ITBS:
                txtPrecVenta.Text = "0.00";
                txtPrecMinimo.Text = "0.00";
                txtGannaciaNeta.Text = "0.00";
                decimal valorDecimal = 0, tasa = 0, costoMasItebis = 0;
                decimal.TryParse(txtCosto.Text, out valorDecimal);
                decimal.TryParse(txtItbisTasa.Text, out tasa);
                if (tasa > 0 && !txtItbisInculido.Checked)
                {
                    costoMasItebis = (valorDecimal * (1 + (tasa / 100)));
                    //costoMasItebis = valorDecimal + (valorDecimal * tasa / 100);
                }
                else
                {
                    costoMasItebis = valorDecimal;
                }
                txtItbis.Text = "0.00";
                txtPGanancia.Text = "30.00";
                txtPrecVenta.Text = "0.00";
                txtPrecMinimo.Text = "0.00";
                txtCosto.Text = valorDecimal.ToString("#,###.00;-#,###.00;0.00");
                txtCostoItbis.Text = costoMasItebis.ToString("#,###.00;-#,###.00;0.00");

                if (costoMasItebis <= 0)
                {
                    AVISOW("El valor del Consto es Invalido.");
                    return;
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtPGanancia_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal precio, itebisTasa, itbis, itbisAdelantado, pganancia, costoItebis, gananciaNeta;
                decimal.TryParse(txtPrecVenta.Text, out precio);
                decimal.TryParse(txtItbisTasa.Text, out itebisTasa);
                decimal.TryParse(txtPGanancia.Text, out pganancia);
                decimal.TryParse(txtCostoItbis.Text, out costoItebis);
                if (pganancia == 0)
                {
                    AVISOW("El % de la ganacia debe ser mayor que cero (0).");
                    return;
                }
                itbisAdelantado = (costoItebis - (costoItebis / (1 + (itebisTasa / 100))));
                precio = ((costoItebis / 100 * pganancia) + costoItebis);
                itbis = precio - (precio / (1 + (itebisTasa / 100)));
                gananciaNeta = (precio - (costoItebis + (precio - (precio / (1 + (itebisTasa / 100)))))) + itbisAdelantado;
                txtGannaciaNeta.Text = gananciaNeta.ToString("#,###.00;-#,###.00;0.00");
                txtPrecVenta.Text = precio.ToString("#,###.00;-#,###.00;0.00");
                txtItbis.Text = itbis.ToString("#,###.00;-#,###.00;0.00");
                txtPGanancia.Text = pganancia.ToString("#,###.00;-#,###.00;0.00");
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                DesBloquear();
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new FormCatalogoProveedor();
                form.ShowDialog();
                if(form.IdProveedor > 0)
                {
                    this.IdProveedor = form.IdProveedor;
                    txtProveedor.Text = form.Nombre;
                    if(form.ItbisIncluido == "SI")
                    {
                        txtItbisInculido.Checked = true;
                    }
                    else if (form.ItbisIncluido == "NO")
                    {
                        txtItbisInculido.Checked = false;
                    }
                    txtDescripcion.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }

        private void txtTope_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
                    btnGuardar.Focus();
                }
            }
            catch (Exception ex)
            {
                AVISOW(ex.ToString());
            }
        }
    }
}
