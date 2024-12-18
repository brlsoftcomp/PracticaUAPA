using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _Permiso_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetAll
        public List<TblPermiso> GetAll()
        {
            try
            {
                TblPermiso Objeto;
                var list = new List<TblPermiso>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblPermiso ORDER BY IdPermiso");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblPermiso();
                    int.TryParse(reader["IdPermiso"].ToString(), out Id);
                    Objeto.IdPermiso = Id;
                    Objeto.Descripcion = reader["Descripcion"].ToString();
                    list.Add(Objeto);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
