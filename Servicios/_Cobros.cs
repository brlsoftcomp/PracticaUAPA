using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRL_SVentas.Model;

namespace BRL_SVentas.Servicios
{
    class _Cobros
    {
        static Conexion Miconexion = new Conexion();

        #region SaveXML
        public static int SaveXML(TblCobro Objeto)
        {
            try
            {
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblCobro") + 1;
                var list = new List<TblCobro>();
                list.Add(Objeto);

                Objeto.IdCxC = Miconexion.GuardaXmlInt("GuardaCobro", ClassConversion.CreateDataTable(list));
                return Objeto.IdCxC;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Save
        public static bool Save(TblCobro Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblCobro VALUES(");
                builder.Append("'" + Objeto.IdCxC + "',");
                builder.Append("'" + Objeto.IdUsuario + "',");
                builder.Append("'" + Objeto.Codigo + "',");
                builder.Append("'" + Objeto.Fecha + "',");
                builder.Append("'" + Objeto.Monto + "',");
                builder.Append("'" + Objeto.Abono + "',");
                builder.Append("'" + Objeto.Balance + "',");
                builder.Append("'" + Objeto.Nota + "',");
                builder.Append("'" + Objeto.IdCajaApertura + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblCobro Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblCobro SET ");
                builder.Append("IdCxC = '" + Objeto.IdCxC + "',");
                builder.Append("IdUsuario = '" + Objeto.IdUsuario + "',");
                builder.Append("Fecha = '" + Objeto.Fecha + "',");
                builder.Append("Monto = '" + Objeto.Monto + "',");
                builder.Append("Abono = '" + Objeto.Abono + "',");
                builder.Append("Balance = '" + Objeto.Balance + "',");
                builder.Append("Nota = '" + Objeto.Nota + "',");
                builder.Append("IdCajaApertura = '" + Objeto.IdCajaApertura + "'");
                builder.Append(" WHERE IdCobro = '" + Objeto.IdCobro + "'");
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
                builder.Append("DELETE FROM TblCobro WHERE IdCobro = '" + Id + "' ");
                return Miconexion.Guardar(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public static bool DeleteByCxC(int Id)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("DELETE FROM TblCobro WHERE IdCxC = '" + Id + "' ");
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
