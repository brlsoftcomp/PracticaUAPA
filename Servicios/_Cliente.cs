using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _Cliente
    {
        static Conexion Miconexion = new Conexion();

        #region SaveXML
        public static int SaveXML(TblCliente Objeto)
        {
            try
            {
                var list = new List<TblCliente>();
                list.Add(Objeto);

                Objeto.IdCliente = Miconexion.GuardaXmlInt("GuardaCliente", ClassConversion.CreateDataTable(list));
                return Objeto.IdCliente;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Save
        public static int Save(TblCliente Objeto)
        {
            try
            {
                int Id = 0;
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblCliente") + 1;
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblCliente VALUES(");
                builder.Append("'" + Objeto.Codigo+ "',");
                builder.Append("'" + Objeto.Nombre + "',");
                builder.Append("'" + Objeto.Cedula + "',");
                builder.Append("'" + Objeto.Direccion + "',");
                builder.Append("'" + Objeto.Telefono + "',");
                builder.Append("'" + Objeto.Telefono2 + "',");
                builder.Append("'" + Objeto.Tipo + "')");
                //return Miconexion.Guardar(builder.ToString());
                if (Miconexion.Guardar(builder.ToString()))
                {
                    Miconexion.Cerrar();
                    SqlDataReader reader;
                    reader = Miconexion.Buscar("SELECT MAX(IdCliente)as Id FROM TblCliente");
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
        public static bool Update(TblCliente Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblCliente SET ");
                builder.Append("Nombre = '" + Objeto.Nombre + "',");
                builder.Append("Cedula = '" + Objeto.Cedula + "',");
                builder.Append("Direccion = '" + Objeto.Direccion + "',");
                builder.Append("Telefono = '" + Objeto.Telefono + "',");
                builder.Append("Telefono2 = '" + Objeto.Telefono2 + "',");
                builder.Append("Tipo = '" + Objeto.Tipo + "'");
                builder.Append(" WHERE IdCliente = '" + Objeto.IdCliente + "'");
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
                builder.Append("DELETE FROM TblCliente WHERE IdCliente = '" + Id + "' ");
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
