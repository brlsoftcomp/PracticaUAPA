using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _CajaApertura
    {
        static Conexion Miconexion = new Conexion();

        #region SaveXML
        public static int SaveXML(TblCajaApertura Objeto)
        {
            try
            {
                var list = new List<TblCajaApertura>();
                list.Add(Objeto);

                Objeto.IdCajaApertura = Miconexion.GuardaXmlInt("GuardaCajaApertura", ClassConversion.CreateDataTable(list));
                return Objeto.IdCajaApertura;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Save
        public static bool Save(TblCajaApertura Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblCajaApertura VALUES(");
                builder.Append("'" + Objeto.IdUsuario + "',");
                builder.Append("'" + Objeto.Fecha + "',");
                builder.Append("'" + Objeto.Caja + "',");
                builder.Append("'" + Objeto.Monto + "',");
                builder.Append("'" + Objeto.Estado + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblCajaApertura Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblCajaApertura SET ");
                builder.Append("IdUsuario = '" + Objeto.IdUsuario + "',");
                builder.Append("Fecha = '" + Objeto.Fecha + "',");
                builder.Append("Caja = '" + Objeto.Caja + "',");
                builder.Append("Monto = '" + Objeto.Monto + "',");
                builder.Append("Estado = '" + Objeto.Estado + "'");
                builder.Append(" WHERE IdCajaApertura = '" + Objeto.IdCajaApertura + "'");
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
                builder.Append("DELETE FROM TblCajaApertura WHERE IdCajaApertura = '" + Id + "' ");
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
