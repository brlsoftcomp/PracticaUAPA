using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _Usuario
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static int Save(TblUsuario Objeto)
        {
            try
            {
                int Id = 0;
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblUsuario VALUES(");
                builder.Append("'" + Objeto.Nombre + "',");
                builder.Append("'" + Objeto.Usuario + "',");
                builder.Append("'" + Objeto.Password + "',");
                builder.Append("'" + Objeto.Categoria + "',");
                builder.Append("'" + Objeto.Estado + "')");
                if (Miconexion.Guardar(builder.ToString()))
                {
                    Miconexion.Cerrar();
                    SqlDataReader reader;
                    reader = Miconexion.Buscar("SELECT MAX(IdUsuario)as Id FROM TblUsuario");
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
        public static bool Update(TblUsuario Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblUsuario SET ");
                builder.Append("Nombre = '" + Objeto.Nombre + "',");
                builder.Append("Usuario = '" + Objeto.Usuario + "',");
                builder.Append("Password = '" + Objeto.Password + "',");               
                builder.Append("Categoria = '" + Objeto.Categoria + "',");
                builder.Append("Estado = '" + Objeto.Estado + "'");
                builder.Append(" WHERE IdUsuario = '" + Objeto.IdUsuario + "'");
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
                builder.Append("DELETE FROM TblUsuario WHERE IdUsuario = '" + Id + "' ");
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
