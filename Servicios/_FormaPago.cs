using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _FormaPago
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static int Save(TblFormaPago Objeto)
        {
            try
            {
                int Id = 0;
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblFormaPago VALUES(");
                builder.Append("'" + Objeto.IdUsuario + "',");
                builder.Append("'" + Objeto.MontoEfectivo + "',");
                builder.Append("'" + Objeto.MontoTarjeta + "',");
                builder.Append("'" + Objeto.MontoCheque + "',");
                builder.Append("'" + Objeto.MontoNotaCredito + "',");
                builder.Append("'" + Objeto.NoBoucher + "',");
                builder.Append("'" + Objeto.NoCheque + "',");
                builder.Append("'" + Objeto.Concepto + "')");
                //return Miconexion.Guardar(builder.ToString());
                if (Miconexion.Guardar(builder.ToString()))
                {
                    Miconexion.Cerrar();
                    SqlDataReader reader;
                    reader = Miconexion.Buscar("SELECT MAX(IdFormaPago)as Id FROM TblFormaPago");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int.TryParse(reader["Id"].ToString(), out Id);
                        }
                    }
                    Miconexion.Cerrar();
                }
                return Id;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblFormaPago Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblFormaPago SET ");
                builder.Append("IdUsuario = '" + Objeto.IdUsuario + "',");
                builder.Append("MontoEfectivo = '" + Objeto.MontoEfectivo + "',");
                builder.Append("MontoTarjeta = '" + Objeto.MontoTarjeta + "',");
                builder.Append("MontoCheque = '" + Objeto.MontoCheque + "',");
                builder.Append("MontoNotaCredito = '" + Objeto.MontoNotaCredito + ",");
                builder.Append("NoBoucher = '" + Objeto.NoBoucher + "',");
                builder.Append("NoCheque = '" + Objeto.NoCheque + "',");
                builder.Append("Concepto = '" + Objeto.Concepto + "'");
                builder.Append(" WHERE IdFormaPago = '" + Objeto.IdFormaPago + "'");
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
                builder.Append("DELETE FROM TblFormaPago WHERE IdFormaPago = '" + Id + "' ");
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
