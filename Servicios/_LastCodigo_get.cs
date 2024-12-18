using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _LastCodigo_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetLastId
        public static int GetLastCodigo(string Tabla)
        {
            try
            {
                SqlDataReader reader;
                int Id = 0;
                reader = Miconexion.Buscar("SELECT MAX(Codigo) AS CodigoIndex FROM "+ Tabla);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["CodigoIndex"].ToString(), out Id);
                    }
                }
                else
                {
                    Id = 1;
                }
                Miconexion.Cerrar();
                return Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
