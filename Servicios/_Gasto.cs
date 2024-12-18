using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _Gasto
    {
        static Conexion Miconexion = new Conexion();

        #region SaveXML
        public static int SaveXML(TblGasto Objeto)
        {
            try
            {
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblGasto") + 1;
                var list = new List<TblGasto>();
                list.Add(Objeto);

                Objeto.IdGasto = Miconexion.GuardaXmlInt("GuardaGasto", ClassConversion.CreateDataTable(list));
                return Objeto.IdGasto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Save
        public static int Save(TblGasto Objeto)
        {
            try
            {
                int Id = 0;
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblGasto") + 1;
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblGasto VALUES(");
                builder.Append("'" + Objeto.IdUsuario + "',");
                builder.Append("'" + Objeto.IdProveedor + "',");
                builder.Append("'" + Objeto.IdFormaPago + "',");
                builder.Append("'" + Objeto.Codigo + "',");
                builder.Append("'" + Objeto.NoFactura + "',");
                builder.Append("'" + Objeto.NCF + "',");
                builder.Append("'" + Objeto.Fecha + "',");
                builder.Append("'" + Objeto.Concepto + "',");
                builder.Append("'" + Objeto.SubTotal + "',");
                builder.Append("'" + Objeto.Itbis + "',");
                builder.Append("'" + Objeto.Monto + "',");
                builder.Append("'" + Objeto.Nota + "')");

                //return Miconexion.Guardar(builder.ToString());
                if (Miconexion.Guardar(builder.ToString()))
                {
                    Miconexion.Cerrar();
                    SqlDataReader reader;
                    reader = Miconexion.Buscar("SELECT MAX(IdGasto)as Id FROM TblGasto");
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
        public static bool Update(TblGasto Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblGasto SET ");
                builder.Append("IdUsuario = '" + Objeto.IdUsuario + "',");
                builder.Append("IdProveedor = '" + Objeto.IdProveedor + "',");
                builder.Append("Codigo = '" + Objeto.Codigo + "',");
                builder.Append("Fecha = '" + Objeto.Fecha + "',");
                builder.Append("Concepto = '" + Objeto.Concepto + "',");
                builder.Append("Monto = '" + Objeto.Monto + "',");
                builder.Append("Nota = '" + Objeto.Nota + "',");
                builder.Append("NoFactura = '" + Objeto.NoFactura + "',");
                builder.Append("NCF = '" + Objeto.NCF + "',");
                builder.Append("SubTotal = '" + Objeto.SubTotal + "',");
                builder.Append("Itbis = '" + Objeto.Itbis + "',");
                builder.Append("IdFormaPago = '" + Objeto.IdFormaPago + "'");
                builder.Append(" WHERE IdGasto = '" + Objeto.IdGasto + "'");
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
                builder.Append("DELETE FROM TblGasto WHERE IdGasto = '" + Id + "' ");
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
