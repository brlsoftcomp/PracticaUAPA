using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _ListaRapida
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static bool Save(TblListaRapida Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblListaRapida VALUES(");
                builder.Append("'" + Objeto.IdProducto + "',");
                builder.Append("'" + Objeto.Descripcion + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblListaRapida Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblGasto SET ");
                builder.Append("IdProducto = '" + Objeto.IdProducto + "'");
                builder.Append("Descripcion = '" + Objeto.Descripcion + "'");
                builder.Append(" WHERE IdProductoLista = '" + Objeto.IdProductoLista + "'");
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
                builder.Append("DELETE FROM TblListaRapida WHERE IdProductoLista = '" + Id + "' ");
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
