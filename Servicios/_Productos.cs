using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using BRL_SVentas.Model;

namespace BRL_SVentas
{
    class _Productos
    {

        static Conexion Miconexion = new Conexion();

        #region Save
        public static int Save(TblProducto Objeto)
        {
            try
            {
                int Id = 0;
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblProducto") + 1;
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblProducto VALUES(");
                builder.Append("'" + Objeto.IdProveedor + "',");
                builder.Append("'" + Objeto.Codigo + "',");
                builder.Append("'" + Objeto.Nombre + "',");
                builder.Append("'" + Objeto.PrecioCompra + "',");
                builder.Append("'" + Objeto.PrecioVenta + "',");
                builder.Append("'" + Objeto.PrecioMinimo + "',");
                builder.Append("'" + Objeto.Itbis + "',");
                builder.Append("'" + Objeto.CantidadExistente + "',");
                builder.Append("'" + Objeto.Tope + "',");
                builder.Append("'" + Objeto.Estado + "')");
                //return Miconexion.Guardar(builder.ToString());
                if (Miconexion.Guardar(builder.ToString()))
                {
                    Miconexion.Cerrar();
                    SqlDataReader reader;
                    reader = Miconexion.Buscar("SELECT MAX(IdProducto)as Id FROM TblProducto");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int.TryParse(reader["Id"].ToString(), out Id);
                        }
                    }
                    Miconexion.Cerrar();
                }
                return Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblProducto Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblProducto SET ");
                builder.Append("IdProveedor = '" + Objeto.IdProveedor + "',");
                builder.Append("Nombre = '" + Objeto.Nombre + "',");
                builder.Append("PrecioCompra = '" + Objeto.PrecioCompra + "',");
                builder.Append("PrecioVenta = '" + Objeto.PrecioVenta + "',");
                builder.Append("PrecioMinimo = '" + Objeto.PrecioMinimo + "',");
                builder.Append("CantidadExistente = '" + Objeto.CantidadExistente + "',");
                builder.Append("Itbis = '" + Objeto.Itbis + "',");
                builder.Append("Tope = '" + Objeto.Tope + "',");
                builder.Append("Estado = '" + Objeto.Estado + "'");
                builder.Append(" WHERE IdProducto = '" + Objeto.IdProducto + "'");
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
                builder.Append("DELETE FROM TblProducto WHERE IdProducto = '" + Id + "' ");
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
