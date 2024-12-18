using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _ClienteCredito
    {
        static Conexion Miconexion = new Conexion();

        #region Save
        public static bool Save(TblClienteCredito Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblClienteCredito VALUES(");
                builder.Append("'" + Objeto.IdCliente + "',");
                builder.Append("'" + Objeto.Credito + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblClienteCredito Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblClienteCredito SET ");
                builder.Append("Credito = '" + Objeto.Credito + "'");
                builder.Append(" WHERE IdClienteCredito = '" + Objeto.IdClienteCredito + "'");
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
                builder.Append("DELETE FROM TblClienteCredito WHERE IdClienteCredito = '" + Id + "' ");
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
