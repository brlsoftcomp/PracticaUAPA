using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _CxC
    {
        static Conexion Miconexion = new Conexion();

        #region SaveXML
        public static int SaveXML(TblCxC Objeto)
        {
            try
            {
                Objeto.Codigo = _LastCodigo_get.GetLastCodigo("TblCxC") + 1;

                var dt = new DataTable();
                dt.Columns.Add("IdCxC");
                dt.Columns.Add("Codigo");
                dt.Columns.Add("IdUsuario");
                dt.Columns.Add("IdCliente");
                dt.Columns.Add("IdFactura");
                dt.Columns.Add("Fecha");
                dt.Columns.Add("Concepto");
                dt.Columns.Add("Monto");
                dt.Columns.Add("Balance");
                dt.Columns.Add("Estado");
                dt.Columns.Add("Nota");

                DataRow newRow = dt.NewRow();
                newRow["IdCxC"] = Objeto.IdCxC;
                newRow["Codigo"] = Objeto.Codigo;
                newRow["IdUsuario"] = Objeto.IdUsuario;
                newRow["IdCliente"] = Objeto.IdCliente;
                newRow["IdFactura"] = Objeto.IdFactura;
                newRow["Fecha"] = Objeto.Fecha;
                newRow["Concepto"] = Objeto.Concepto;
                newRow["Monto"] = Objeto.Monto;
                newRow["Balance"] = Objeto.Balance;
                newRow["Estado"] = Objeto.Estado;
                newRow["Nota"] = Objeto.Nota;
                dt.Rows.Add(newRow);

                Objeto.IdCxC = Miconexion.GuardaXmlInt("GuardaCxC", dt);
                return Objeto.IdCxC;
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
                builder.Append("DELETE FROM TblCxC WHERE IdCxC = '" + Id + "' ");
                return Miconexion.Guardar(builder.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region DeleteCxCyCobros
        public static bool DeleteCxCyCobros(int Id)
        {
            try
            {
                //ELIMINAR REGISTRO DE CAJA:
                var tblCobro = new List<TblCobro>();
                var get = new _Cobro_get();
                tblCobro = get.GetBy("IdCxC",Id.ToString());
                foreach (var item in tblCobro)
                {
                    _Caja.DeleteByModulo(item.IdCobro, "COBRO CXC");
                }
                //ELIMINAR COBRO:
                var builder = new StringBuilder();
                builder.Append("DELETE FROM TblCobro WHERE IdCxC = '" + Id + "' ");               
                if (Miconexion.Guardar(builder.ToString()))
                {
                    //ELIMINAR CXC:
                    builder = new StringBuilder();
                    builder.Append("DELETE FROM TblCxC WHERE IdCxC = '" + Id + "' ");
                    return Miconexion.Guardar(builder.ToString());
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
