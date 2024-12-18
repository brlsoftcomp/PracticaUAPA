using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _Caja
    {
        static Conexion Miconexion = new Conexion();

        #region SaveXML
        //public static int SaveXML(TblCliente Objeto)
        //{
        //    try
        //    {
        //        var list = new List<TblCliente>();
        //        list.Add(Objeto);

        //        Objeto.IdCliente = Miconexion.GuardaXmlInt("GuardaCliente", ClassConversion.CreateDataTable(list));
        //        return Objeto.IdCliente;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        #region Save
        public static bool Save(TblCaja Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblCaja VALUES(");
                builder.Append("'" + Objeto.IdUsuario + "',");
                builder.Append("'" + Objeto.Fecha + "',");
                builder.Append("'" + Objeto.Registro + "',");
                builder.Append("'" + Objeto.Modulo + "',");
                builder.Append("'" + Objeto.Monto + "',");
                builder.Append("'" + Objeto.Caja + "',");
                builder.Append("'" + Objeto.Estado + "',");
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
        public static bool Update(TblCaja Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblCaja SET ");
                builder.Append("IdUsuario = '" + Objeto.IdUsuario + "',");
                builder.Append("Fecha = '" + Objeto.Fecha + "',");
                builder.Append("Registro = '" + Objeto.Registro + "',");
                builder.Append("Modulo = '" + Objeto.Modulo + "',");
                builder.Append("Monto = '" + Objeto.Monto + "',");
                builder.Append("Caja = '" + Objeto.Caja + "',");
                builder.Append("Estado = '" + Objeto.Estado + "'");
                builder.Append(" WHERE IdCaja = '" + Objeto.IdCaja + "'");
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
                builder.Append("DELETE FROM TblCaja WHERE IdCaja = '" + Id + "' ");
                return Miconexion.Guardar(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public static bool DeleteByModulo(int Id, string modulo)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("DELETE FROM TblCaja WHERE Registro = '" + Id + "' AND Modulo = '" + modulo + "'");
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
