using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _CajaConteo_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCajaConteo GetById(int Id)
        {
            try
            {
                var Objeto = new TblCajaConteo();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblCajaConteo WHERE IdCajaCierre= '" + Id + "'");
                int valorInt = 0;
                decimal valorDecimal = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCajaConteo"].ToString(), out valorInt);
                        Objeto.IdCajaConteo = valorInt;
                        int.TryParse(reader["IdCajaCierre"].ToString(), out valorInt);
                        Objeto.IdCajaCierre = valorInt;
                        int.TryParse(reader["Uno"].ToString(), out valorInt);
                        Objeto.Uno = valorInt;
                        int.TryParse(reader["Cinco"].ToString(), out valorInt);
                        Objeto.Cinco = valorInt;
                        int.TryParse(reader["Diez"].ToString(), out valorInt);
                        Objeto.Diez = valorInt;
                        int.TryParse(reader["Veinticinco"].ToString(), out valorInt);
                        Objeto.Veinticinco = valorInt;
                        int.TryParse(reader["Cincuenta"].ToString(), out valorInt);
                        Objeto.Cincuenta = valorInt;
                        int.TryParse(reader["Cien"].ToString(), out valorInt);
                        Objeto.Cien = valorInt;
                        int.TryParse(reader["Docientos"].ToString(), out valorInt);
                        Objeto.Docientos = valorInt;
                        int.TryParse(reader["Quientos"].ToString(), out valorInt);
                        Objeto.Quientos = valorInt;
                        int.TryParse(reader["Mil"].ToString(), out valorInt);
                        Objeto.Mil = valorInt;
                        int.TryParse(reader["Dosmil"].ToString(), out valorInt);
                        Objeto.Dosmil = valorInt;
                        decimal.TryParse(reader["Vaucher"].ToString(), out valorDecimal);
                        Objeto.Vaucher = valorDecimal;
                        decimal.TryParse(reader["Cheque"].ToString(), out valorDecimal);
                        Objeto.Cheque = valorDecimal;
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
