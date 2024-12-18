using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _Compra
    {
        static Conexion Miconexion = new Conexion();

        #region SaveXML
        public static int SaveXML(TblCompra Objeto)
        {
            try
            {
                var list = new List<TblCompra>();
                list.Add(Objeto);

                Objeto.IdCompra = Miconexion.GuardaXmlInt("GuardaCompra", ClassConversion.CreateDataTable(list));
                return Objeto.IdCompra;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Save
        public static bool Save(TblCompra Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblCompra VALUES(");
                builder.Append("'" + Objeto.IdUsuario + "',");
                builder.Append("'" + Objeto.IdProveedor + "',");
                builder.Append("'" + Objeto.IdFormaPago + "',");
                builder.Append("'" + Objeto.Fecha + "',");
                builder.Append("'" + Objeto.NoFactura + "',");
                builder.Append("'" + Objeto.NCF + "',");
                builder.Append("'" + Objeto.CondicionCompra + "',");
                builder.Append("'" + Objeto.Itbis + "',");
                builder.Append("'" + Objeto.SubTotal + "',");
                builder.Append("'" + Objeto.Total + "',");
                builder.Append("'" + Objeto.Nota + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblCompra Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblCompra SET ");
                builder.Append("IdUsuario = '" + Objeto.IdUsuario + "',");
                builder.Append("IdProveedor = '" + Objeto.IdProveedor + "',");
                builder.Append("IdFormaPago = '" + Objeto.IdFormaPago + "',");
                builder.Append("Fecha = '" + Objeto.Fecha + "',");
                builder.Append("NoFactura = '" + Objeto.NoFactura + "',");
                builder.Append("NCF = '" + Objeto.NCF + "',");
                builder.Append("CondicionCompra = '" + Objeto.CondicionCompra + "',");
                builder.Append("Itbis = '" + Objeto.Itbis + "',");
                builder.Append("SubTotal = '" + Objeto.SubTotal + "',");
                builder.Append("Total = '" + Objeto.Total + "',");
                builder.Append("Nota = '" + Objeto.Nota + "'");
                builder.Append(" WHERE IdCompra = '" + Objeto.IdCompra + "'");
                return Miconexion.Guardar(builder.ToString());
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
                builder.Append("DELETE FROM TblCompra WHERE IdCompra = '" + Id + "' ");
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
