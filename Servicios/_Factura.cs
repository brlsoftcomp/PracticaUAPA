using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRL_SVentas.Model;

namespace BRL_SVentas.Servicios
{
    class _Factura
    {

        static Conexion Miconexion = new Conexion();

        #region SaveXML
        public static int SaveXML(TblFactura Objeto)
        {
            try
            {
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblFactura") + 1;
                var dt = new DataTable();

                dt.Columns.Add("IdFactura");
                dt.Columns.Add("IdUsuario");
                dt.Columns.Add("IdCliente");
                dt.Columns.Add("IdCajaApertura");
                dt.Columns.Add("IdFormaPago");
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Fecha");
                dt.Columns.Add("CondicionPago");
                dt.Columns.Add("SubTotal");
                dt.Columns.Add("Itbis");
                dt.Columns.Add("Total");
                dt.Columns.Add("Nota");
                dt.Columns.Add("Estado");
                dt.Columns.Add("TotalGanancia");            

                DataRow newRow = dt.NewRow();
                newRow["IdFactura"] = Objeto.IdFactura;
                newRow["IdUsuario"] = Objeto.IdUsuario;
                newRow["IdCliente"] = Objeto.IdCliente;
                newRow["IdCajaApertura"] = Objeto.IdCajaApertura;
                newRow["IdFormaPago"] = Objeto.IdFormaPago;
                newRow["Codigo"] = Objeto.Codigo;
                newRow["Fecha"] = Objeto.Fecha;
                newRow["CondicionPago"] = Objeto.CondicionPago;
                newRow["SubTotal"] = Objeto.SubTotal;
                newRow["Itbis"] = Objeto.Itbis;
                newRow["Total"] = Objeto.Total;
                newRow["Nota"] = Objeto.Nota;
                newRow["Estado"] = Objeto.Estado;
                newRow["TotalGanancia"] = Objeto.TotalGanancia;
                dt.Rows.Add(newRow);

                Objeto.IdFactura = Miconexion.GuardaXmlInt("GuardaFactura", dt);
                return Objeto.IdFactura;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public static bool Delete(int Id)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("DELETE FROM TblFactura WHERE IdFactura = '" + Id + "' ");
                return Miconexion.Guardar(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
