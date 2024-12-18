using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _CajaConteo
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static bool Save(TblCajaConteo Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblCajaConteo VALUES(");
                builder.Append("'" + Objeto.IdCajaCierre + "',");
                builder.Append("'" + Objeto.Uno + "',");
                builder.Append("'" + Objeto.Cinco + "',");
                builder.Append("'" + Objeto.Diez + "',");
                builder.Append("'" + Objeto.Veinticinco + "',");
                builder.Append("'" + Objeto.Cincuenta + "',");
                builder.Append("'" + Objeto.Cien + "',");
                builder.Append("'" + Objeto.Docientos + "',");
                builder.Append("'" + Objeto.Quientos + "',");
                builder.Append("'" + Objeto.Mil + "',");
                builder.Append("'" + Objeto.Dosmil + "',");
                builder.Append("'" + Objeto.Vaucher + "',");
                builder.Append("'" + Objeto.Cheque + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblCajaConteo Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblCajaConteo SET ");
                builder.Append("IdCajaCierre = '" + Objeto.IdCajaCierre + "',");
                builder.Append("Uno = '" + Objeto.Uno + "',");
                builder.Append("Cinco = '" + Objeto.Cinco + "',");
                builder.Append("Diez = '" + Objeto.Diez + "',");
                builder.Append("Veinticinco = '" + Objeto.Veinticinco + "',");
                builder.Append("Cincuenta = '" + Objeto.Cincuenta + "',");
                builder.Append("Cien = '" + Objeto.Cien + "',");
                builder.Append("Docientos = '" + Objeto.Docientos + "',");
                builder.Append("Quientos = '" + Objeto.Quientos + "',");
                builder.Append("Mil = '" + Objeto.Mil + "',");
                builder.Append("Dosmil = '" + Objeto.Dosmil + "',");
                builder.Append("Vaucher = '" + Objeto.Vaucher + "',");
                builder.Append("Cheque = '" + Objeto.Cheque + "'");
                builder.Append(" WHERE IdCajaConteo = '" + Objeto.IdCajaConteo + "'");
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
                builder.Append("DELETE FROM TblCajaConteo WHERE IdCajaConteo = '" + Id + "' ");
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
