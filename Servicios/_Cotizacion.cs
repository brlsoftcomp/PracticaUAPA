using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _Cotizacion
    {
        static Conexion Miconexion = new Conexion();

        #region SaveXML
        public static int SaveXML(TblCotizacion Objeto)
        {
            try
            {
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblCotizacion") + 1;
                var dt = new DataTable();

                dt.Columns.Add("IdCotizacion");
                dt.Columns.Add("IdUsuario");
                dt.Columns.Add("IdCliente");
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Fecha");
                dt.Columns.Add("SubTotal");
                dt.Columns.Add("Itbis");
                dt.Columns.Add("Total");
                dt.Columns.Add("Nota");
                dt.Columns.Add("TotalGanancia");

                DataRow newRow = dt.NewRow();
                newRow["IdCotizacion"] = Objeto.IdCotizacion;
                newRow["IdUsuario"] = Objeto.IdUsuario;
                newRow["IdCliente"] = Objeto.IdCliente;
                newRow["Codigo"] = Objeto.Codigo;
                newRow["Fecha"] = Objeto.Fecha;
                newRow["SubTotal"] = Objeto.SubTotal;
                newRow["Itbis"] = Objeto.Itbis;
                newRow["Total"] = Objeto.Total;
                newRow["Nota"] = Objeto.Nota;
                newRow["TotalGanancia"] = Objeto.TotalGanancia;
                dt.Rows.Add(newRow);

                Objeto.IdCotizacion = Miconexion.GuardaXmlInt("GuardaCotizacion", dt);
                return Objeto.IdCotizacion;
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
                builder.Append("DELETE FROM TblCotizacion WHERE IdCotizacion = '" + Id + "' ");
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
