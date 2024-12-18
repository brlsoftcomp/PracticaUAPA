using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _CxCAjuste
    {
        static Conexion Miconexion = new Conexion();

        //#region SaveXML
        //public static int SaveXML(TblCobro Objeto)
        //{
        //    try
        //    {
        //        var list = new List<TblCobro>();
        //        list.Add(Objeto);

        //        Objeto.IdCxC = Miconexion.GuardaXmlInt("GuardaCobro", ClassConversion.CreateDataTable(list));
        //        return Objeto.IdCxC;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //#endregion

        #region Save
        public static bool Save(TblCxCAjuste Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblCxCAjuste VALUES(");
                builder.Append("'" + Objeto.IdCxC + "',");
                builder.Append("'" + Objeto.IdUsuario + "',");
                builder.Append("'" + Objeto.Fecha + "',");
                builder.Append("'" + Objeto.MontoAjuste + "',");
                builder.Append("'" + Objeto.Monto + "',");
                builder.Append("'" + Objeto.Balance + "',");
                builder.Append("'" + Objeto.Concepto + "',");
                builder.Append("'" + Objeto.Nota + "'");
                builder.Append("'" + Objeto.IdCxCAjuste + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblCxCAjuste Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblCxCAjuste SET ");
                builder.Append("IdCxC = '" + Objeto.IdCxC + "',");
                builder.Append("IdUsuario = '" + Objeto.IdUsuario + "',");
                builder.Append("Fecha = '" + Objeto.Fecha + "',");
                builder.Append("MontoAjuste = '" + Objeto.MontoAjuste + "',");
                builder.Append("Monto = '" + Objeto.Monto + "',");
                builder.Append("Balance = '" + Objeto.Balance + "',");
                builder.Append("Concepto = '" + Objeto.Concepto + "',");
                builder.Append("Nota = '" + Objeto.Nota + "'");
                builder.Append(" WHERE IdCxCAjuste = '" + Objeto.IdCxCAjuste + "'");
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
                builder.Append("DELETE FROM TblCxCAjuste WHERE IdCxCAjuste = '" + Id + "' ");
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
