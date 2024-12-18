using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _CotizacionDetalle
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static bool Save(TblCotizacionDetalle Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblCotizacionDetalle VALUES(");
                builder.Append("'" + Objeto.IdCotizacion + "',");
                builder.Append("'" + Objeto.IdProducto + "',");
                builder.Append("'" + Objeto.CantidadCotizada + "',");
                builder.Append("'" + Objeto.PrecioCotizado + "',");
                builder.Append("'" + Objeto.MontoCotizado + "',");
                builder.Append("'" + Objeto.ItbisCotizado + "',");
                builder.Append("'" + Objeto.Ganancia + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblCotizacionDetalle Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblCotizacionDetalle SET ");
                builder.Append("IdCotizacion = '" + Objeto.IdCotizacion + "',");
                builder.Append("IdProducto = '" + Objeto.IdProducto + "',");
                builder.Append("CantidadCotizada = '" + Objeto.CantidadCotizada + "',");
                builder.Append("PrecioCotizado = '" + Objeto.PrecioCotizado + "',");
                builder.Append("MontoCotizado = '" + Objeto.MontoCotizado + "',");
                builder.Append("ItbisCotizado = '" + Objeto.ItbisCotizado + "',");
                builder.Append("Ganancia = '" + Objeto.Ganancia + "'");
                builder.Append(" WHERE IdCotizacionDetalle= '" + Objeto.IdCotizacionDetalle + "'");
                return Miconexion.Guardar(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region UpdateOnProducto
        public static bool UpdateOnProducto(TblCotizacionDetalle Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblCotizacionDetalle SET ");
                builder.Append("CantidadCotizada = '" + Objeto.CantidadCotizada + "',");
                builder.Append("PrecioCotizado = '" + Objeto.PrecioCotizado + "',");
                builder.Append("MontoCotizado = '" + Objeto.MontoCotizado + "',");
                builder.Append("ItbisCotizado = '" + Objeto.ItbisCotizado + "',");
                builder.Append("Ganancia = '" + Objeto.Ganancia + "'");
                builder.Append(" WHERE IdProducto= '" + Objeto.IdProducto + "'");
                builder.Append(" AND IdCotizacion= '" + Objeto.IdCotizacion + "'");
                return Miconexion.Guardar(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public static bool Delete(int IdCotizacion, int IdProducto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("DELETE FROM TblCotizacionDetalle WHERE IdCotizacion = '" + IdCotizacion + "' AND IdProducto= '" + IdProducto + "'");
                return Miconexion.Guardar(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region DeleteAll
        public static bool DeleteAll(int IdCotizacion)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("DELETE FROM TblCotizacionDetalle WHERE IdCotizacion = '" + IdCotizacion + "'");
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
