using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _FacturaDetalle
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static bool Save(TblFacturaDetalle Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblFacturaDetalle VALUES(");
                builder.Append("'" + Objeto.IdFactura + "',");
                builder.Append("'" + Objeto.IdProducto + "',");
                builder.Append("'" + Objeto.CantidadFacturada + "',");
                builder.Append("'" + Objeto.PrecioFacturado + "',");
                builder.Append("'" + Objeto.MontoFacturado + "',");
                builder.Append("'" + Objeto.ItbisFacturado + "',");
                builder.Append("'" + Objeto.Ganancia + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblFacturaDetalle Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblFacturaDetalle SET ");
                builder.Append("IdFactura = '" + Objeto.IdFactura + "',");
                builder.Append("IdProducto = '" + Objeto.IdProducto + "',");
                builder.Append("CantidadFacturada = '" + Objeto.CantidadFacturada + "',");
                builder.Append("PrecioFacturado = '" + Objeto.PrecioFacturado + "',");
                builder.Append("ItbisFacturado = '" + Objeto.ItbisFacturado + "',");
                builder.Append("MontoFacturado = '" + Objeto.MontoFacturado + "',");
                builder.Append("Ganancia = '" + Objeto.Ganancia + "'");
                builder.Append(" WHERE IdFacturaDetalle= '" + Objeto.IdFacturaDetalle + "'");
                return Miconexion.Guardar(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region UpdateOnProducto
        public static bool UpdateOnProducto(TblFacturaDetalle Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblFacturaDetalle SET ");
                builder.Append("CantidadFacturada = '" + Objeto.CantidadFacturada + "',");
                builder.Append("PrecioFacturado = '" + Objeto.PrecioFacturado + "',");
                builder.Append("ItbisFacturado = '" + Objeto.ItbisFacturado + "',");
                builder.Append("MontoFacturado = '" + Objeto.MontoFacturado + "',");
                builder.Append("Ganancia = '" + Objeto.Ganancia + "'");
                builder.Append(" WHERE IdProducto= '" + Objeto.IdProducto + "'");
                builder.Append(" AND IdFactura= '" + Objeto.IdFactura + "'");
                return Miconexion.Guardar(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public static bool Delete(int IdFactura, int IdProducto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("DELETE FROM TblFacturaDetalle WHERE IdFactura = '" + IdFactura + "' AND IdProducto= '" + IdProducto + "'");
                return Miconexion.Guardar(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public static bool DeleteByFactura(int IdFactura)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("DELETE FROM TblFacturaDetalle WHERE IdFactura = '" + IdFactura + "'");
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
