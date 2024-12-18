using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRL_SVentas.Model;

namespace BRL_SVentas.Servicios
{
    class _HistAICuerpo
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static bool Save(TblHistAICuerpo Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblHistAICuerpo VALUES(");
                builder.Append("'" + Objeto.FkeyHistAI + "',");
                builder.Append("'" + Objeto.FkeyProducto + "',");
                builder.Append("'" + Objeto.TipoAjuste + "',");
                builder.Append("'" + Objeto.CantidadExistenet + "',");
                builder.Append("'" + Objeto.CantidadAjuste + "',");
                builder.Append("'" + Objeto.Ajuste + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblHistAICuerpo Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblHistAICuerpo SET ");
                builder.Append("FkeyProducto = '" + Objeto.FkeyProducto + "',");
                builder.Append("TipoAjuste = '" + Objeto.TipoAjuste + "',");
                builder.Append("CantidadExistenet = '" + Objeto.CantidadExistenet + "',");
                builder.Append("CantidadAjuste = '" + Objeto.CantidadAjuste + "',");
                builder.Append("Ajuste = '" + Objeto.Ajuste + "'");
                builder.Append(" WHERE IdHistAICuerpo = '" + Objeto.IdHistAICuerpo + "'");
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
                builder.Append("DELETE FROM TblHistAICuerpo WHERE IdHistAICuerpo = '" + Id + "' ");
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
