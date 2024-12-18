using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _Proveedor
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static bool Save(TblProveedor Objeto)
        {
            try
            {
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblProveedor") + 1;
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblProveedor VALUES(");
                builder.Append("'" + Objeto.Codigo + "',");
                builder.Append("'" + Objeto.RNC + "',");
                builder.Append("'" + Objeto.Nombre + "',");
                builder.Append("'" + Objeto.Direccion + "',");
                builder.Append("'" + Objeto.Telefono + "',");
                builder.Append("'" + Objeto.Telefono2 + "',");
                builder.Append("'" + Objeto.Correo + "',");
                builder.Append("'" + Objeto.ItbisIncluido + "')");          
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblProveedor Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblProveedor SET ");
                builder.Append("RNC = '" + Objeto.RNC + "',");
                builder.Append("Nombre = '" + Objeto.Nombre + "',");
                builder.Append("Direccion = '" + Objeto.Direccion + "',");
                builder.Append("Telefono = '" + Objeto.Telefono + "',");
                builder.Append("Telefono2 = '" + Objeto.Telefono2 + "',");
                builder.Append("Correo = '" + Objeto.Correo + "',");
                builder.Append("ItbisIncluido = '" + Objeto.ItbisIncluido + "'");
                builder.Append(" WHERE IdProveedor = '" + Objeto.IdProveedor + "'");
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
                builder.Append("DELETE FROM TblProveedor WHERE IdProveedor = '" + Id + "' ");
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
