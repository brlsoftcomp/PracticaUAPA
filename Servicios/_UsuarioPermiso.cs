using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _UsuarioPermiso
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static bool Save(TblUsuarioPermiso Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblUsuarioPermiso VALUES(");
                builder.Append("'" + Objeto.IdUsuario + "',");
                builder.Append("'" + Objeto.IdPermiso + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblUsuarioPermiso Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblUsuarioPermiso SET ");
                builder.Append("IdUsuario = '" + Objeto.IdUsuario + "',");
                builder.Append("IdPermiso = '" + Objeto.IdPermiso + "'");
                builder.Append(" WHERE IdUsuarioPermiso = '" + Objeto.IdUsuarioPermiso + "'");
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
                builder.Append("DELETE FROM TblUsuarioPermiso WHERE IdUsuario = '" + Id + "' ");
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
