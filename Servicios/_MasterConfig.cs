using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _MasterConfig
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static bool Save(TblMasterConfig Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblMasterConfig VALUES(");
                builder.Append("'" + Objeto.Fecha + "',");
                builder.Append("'" + Objeto.VentasNCF + "',");
                builder.Append("'" + Objeto.NotificacionNCF + "',");
                builder.Append("'" + Objeto.PapelFactura + "',");
                builder.Append("'" + Objeto.ContizacionLogo + "',");
                builder.Append("'" + Objeto.ImprimirCopiaFact + "')");
                return Miconexion.Guardar(builder.ToString());               
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblMasterConfig Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblMasterConfig SET ");
                builder.Append("Fecha = '" + Objeto.Fecha + "',");
                builder.Append("VentasNCF = '" + Objeto.VentasNCF + "',");
                builder.Append("NotificacionNCF = '" + Objeto.NotificacionNCF + "',");
                builder.Append("PapelFactura = '" + Objeto.PapelFactura + "',");
                builder.Append("ContizacionLogo = '" + Objeto.ContizacionLogo + "',");
                builder.Append("ImprimirCopiaFact = '" + Objeto.ImprimirCopiaFact + "'");
                builder.Append(" WHERE IdMasterConfig = '" + Objeto.IdMasterConfig + "'");
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
                builder.Append("DELETE FROM TblMasterConfig WHERE IdMasterConfig = '" + Id + "' ");
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
