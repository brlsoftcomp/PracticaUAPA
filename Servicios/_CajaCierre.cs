using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _CajaCierre
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
        public static int Save(TblCajaCierre Objeto)
        {
            try
            {
                int Id = 0;
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblCajaCierre") + 1;
                var builder = new StringBuilder();
                builder.Append("INSERT INTO TblCajaCierre VALUES(");
                builder.Append("'" + Objeto.IdCajaApertura + "',");
                builder.Append("'" + Objeto.IdUsuario + "',");
                builder.Append("'" + Objeto.Codigo + "',");
                builder.Append("'" + Objeto.Fecha + "',");
                builder.Append("'" + Objeto.Caja + "',");
                builder.Append("'" + Objeto.TotalEntrada + "',");
                builder.Append("'" + Objeto.TotalSalida + "',");
                builder.Append("'" + Objeto.TotalConteo + "',");
                builder.Append("'" + Objeto.Diferencia + "',");
                builder.Append("'" + Objeto.Resultado + "',");
                builder.Append("'" + Objeto.Ventas + "',");
                builder.Append("'" + Objeto.CobrosCxC + "',");
                builder.Append("'" + Objeto.Compras + "',");
                builder.Append("'" + Objeto.Gastos + "',");
                builder.Append("'" + Objeto.DevVentas + "',");
                builder.Append("'" + Objeto.PagosCxP + "',");
                builder.Append("'" + Objeto.Nota + "')");
                //return Miconexion.Guardar(builder.ToString());
                if (Miconexion.Guardar(builder.ToString()))
                {
                    Miconexion.Cerrar();
                    SqlDataReader reader;
                    reader = Miconexion.Buscar("SELECT MAX(IdCajaCierre)as Id FROM TblCajaCierre");
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
        public static bool Update(TblCajaCierre Objeto)
        {
            try
            {
                var builder = new StringBuilder();
                builder.Append("UPDATE TblCajaCierre SET ");
                builder.Append("IdCajaApertura = '" + Objeto.IdCajaApertura + "',");
                builder.Append("IdUsuario = '" + Objeto.IdUsuario + "',");
                builder.Append("Fecha = '" + Objeto.Fecha + "',");
                builder.Append("Caja = '" + Objeto.Caja + "',");
                builder.Append("TotalEntrada = '" + Objeto.TotalEntrada + "',");
                builder.Append("TotalSalida = '" + Objeto.TotalSalida + "',");
                builder.Append("TotalConteo = '" + Objeto.TotalConteo + "',");
                builder.Append("Diferrencia = '" + Objeto.Diferencia + "',");
                builder.Append("Resultado = '" + Objeto.Resultado + "',");
                builder.Append("Ventas = '" + Objeto.Ventas + "',");
                builder.Append("CobrosCxC = '" + Objeto.CobrosCxC + "',");
                builder.Append("Compras = '" + Objeto.Compras + "',");
                builder.Append("Gastos = '" + Objeto.Gastos + "',");
                builder.Append("DevVentas = '" + Objeto.DevVentas + "',");
                builder.Append("PagosCxP = '" + Objeto.PagosCxP + "',");
                builder.Append("Nota = '" + Objeto.Nota + "'");
                builder.Append(" WHERE IdCajaCierre = '" + Objeto.IdCajaCierre + "'");
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
                builder.Append("DELETE FROM TblCajaCierre WHERE IdCajaCierre = '" + Id + "' ");
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
