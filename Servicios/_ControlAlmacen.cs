using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _ControlAlmacen
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static bool Save(TblControlAlmacen Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblControlAlmacen VALUES(");
                builder.Append("'" + Objeto.IdUsuario + "',");
                builder.Append("'" + Objeto.IdRegistro + "',");
                builder.Append("'" + Objeto.IdProducto + "',");
                builder.Append("'" + Objeto.Descripcion + "',");
                builder.Append("'" + Objeto.Modulo + "',");
                builder.Append("'" + Objeto.Movimiento + "',");
                builder.Append("'" + Objeto.Cantidad + "',");
                builder.Append("'" + Objeto.Fecha + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblControlAlmacen Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblControlAlmacen SET ");
                builder.Append("IdUsuario = '" + Objeto.IdUsuario + "',");
                builder.Append("IdRegistro = '" + Objeto.IdRegistro + "',");
                builder.Append("IdProducto = '" + Objeto.IdProducto + "',");
                builder.Append("Descripcion = '" + Objeto.Descripcion + "',");
                builder.Append("Modulo = '" + Objeto.Modulo + "',");
                builder.Append("Movimiento = '" + Objeto.Movimiento + "',");
                builder.Append("Cantidad = '" + Objeto.Cantidad + "',");
                builder.Append("Fecha = '" + Objeto.Fecha + "'");
                builder.Append(" WHERE IdControlAlmacen = '" + Objeto.IdControlAlmacen + "'");
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
                builder.Append("DELETE FROM TblControlAlmacen WHERE IdControlAlmacen = '" + Id + "' ");
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
