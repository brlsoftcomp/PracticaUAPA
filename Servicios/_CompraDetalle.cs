using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _CompraDetalle
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static bool Save(TblCompraDetalle Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblCompraDetalle VALUES(");
                builder.Append("'" + Objeto.IdCompra + "',");
                builder.Append("'" + Objeto.IdProducto + "',");
                builder.Append("'" + Objeto.Cantidad + "',");
                builder.Append("'" + Objeto.Itbis + "',");
                builder.Append("'" + Objeto.Precio + "',");
                builder.Append("'" + Objeto.Monto + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblCompraDetalle Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblCompraDetalle SET ");
                builder.Append("IdCompra = '" + Objeto.IdCompra + "',");
                builder.Append("IdProducto = '" + Objeto.IdProducto + "',");
                builder.Append("Cantidad = '" + Objeto.Cantidad + "',");
                builder.Append("Itbis = '" + Objeto.Itbis + "',");
                builder.Append("Precio = '" + Objeto.Precio + "',");
                builder.Append("Monto = '" + Objeto.Monto + "'");
                builder.Append(" WHERE TblCompraDetalle = '" + Objeto.IdCompraDetalle + "'");
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
                builder.Append("DELETE FROM TblCompraDetalle WHERE IdCompraDetalle = '" + Id + "' ");
                return Miconexion.Guardar(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region DeleteByIdCompra
        public static bool DeleteByIdCompra(int Id)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("DELETE FROM TblCompraDetalle WHERE IdCompra = '" + Id + "' ");
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
