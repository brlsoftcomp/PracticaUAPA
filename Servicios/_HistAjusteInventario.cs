using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _HistAjusteInventario
    {

        static Conexion Miconexion = new Conexion();

        #region SaveXML
        public static int SaveXML(TblHistAjusteInventario Objeto)
        {
            try
            {
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblHistAjusteInventario") + 1;
                var list = new List<TblHistAjusteInventario>();
                list.Add(Objeto);

                Objeto.IdHistAjustInventario = Miconexion.GuardaXmlInt("GuardaHistAI", ClassConversion.CreateDataTable(list));
                return Objeto.IdHistAjustInventario;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Save
        public static bool Save(TblHistAjusteInventario Objeto)
        {
            try
            {
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblHistAjusteInventario") + 1;
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblHistAjusteInventario VALUES(");
                builder.Append("'" + Objeto.Codigo + "',");
                builder.Append("'" + Objeto.Fecha.Value.ToString() + "',");
                builder.Append("'" + Objeto.IdUsuario + "',");
                builder.Append("'" + Objeto.Nota + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblHistAjusteInventario Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblHistAjusteInventario SET ");
                builder.Append("Fecha = '" + Objeto.Fecha.Value.ToString() + "',");
                builder.Append("IdUsuario = '" + Objeto.IdUsuario + "',");
                builder.Append("Nota = '" + Objeto.Nota + "'");
                builder.Append(" WHERE IdHistAjustInventario = '" + Objeto.IdHistAjustInventario + "'");
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
                builder.Append("DELETE FROM TblHistAjusteInventario WHERE IdHistAjustInventario = '" + Id + "' ");
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
