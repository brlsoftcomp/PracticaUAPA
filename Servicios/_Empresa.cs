using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _Empresa
    {
        static Conexion Miconexion = new Conexion();

        #region SaveXML
        public static int SaveXML(TblEmpresa Objeto)
        {
            try
            {
                var list = new List<TblEmpresa>();
                list.Add(Objeto);

                Objeto.IdEmpresa = Miconexion.GuardaXmlInt("GuardaEmpresa", ClassConversion.CreateDataTable(list));
                return Objeto.IdEmpresa;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Save
        public static bool Save(TblEmpresa Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblEmpresa VALUES(");
                builder.Append("'" + Objeto.RNC + "',");
                builder.Append("'" + Objeto.Nombre + "',");
                builder.Append("'" + Objeto.Actividad + "',");
                builder.Append("'" + Objeto.Direccion + "',");
                builder.Append("'" + Objeto.Telefono1 + "',");
                builder.Append("'" + Objeto.Telefono2 + "',");
                builder.Append("'" + Objeto.Logo + "')");
                return Miconexion.Guardar(builder.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public static bool Update(TblEmpresa Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblEmpresa SET ");
                builder.Append("RNC = '" + Objeto.RNC + "',");
                builder.Append("Nombre = '" + Objeto.Nombre + "',");
                builder.Append("Actividad = '" + Objeto.Actividad + "',");
                builder.Append("Direccion = '" + Objeto.Direccion + "',");
                builder.Append("Telefono1 = '" + Objeto.Telefono1 + "',");
                builder.Append("Telefono2 = '" + Objeto.Telefono2 + "',");
                builder.Append("Logo = '" + Objeto.Logo + "'");
                builder.Append(" WHERE IdEmpresa = '" + Objeto.IdEmpresa + "'");
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
                builder.Append("DELETE FROM TblEmpresa WHERE IdEmpresa = '" + Id + "' ");
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
