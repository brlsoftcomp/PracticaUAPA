using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _MasterConfig_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblMasterConfig GetById(int Id)
        {
            try
            {
                DateTime Fecha;
                var Objeto = new TblMasterConfig();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblMasterConfig WHERE IdMasterConfig= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdMasterConfig"].ToString(), out Id);
                        Objeto.IdMasterConfig = Id;
                        DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                        Objeto.Fecha = Fecha;
                        Objeto.PapelFactura = reader["VentasNCF"].ToString();
                        int.TryParse(reader["NotificacionNCF"].ToString(), out Id);
                        Objeto.NotificacionNCF = Id;
                        Objeto.PapelFactura = reader["PapelFactura"].ToString();
                        Objeto.PapelFactura = reader["ContizacionLogo"].ToString();
                        Objeto.ImprimirCopiaFact = reader["ImprimirCopiaFact"].ToString();
                    }
                }
                else
                {
                    Objeto = null;
                }
                Miconexion.Cerrar();
                return Objeto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
