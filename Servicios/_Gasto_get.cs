using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _Gasto_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblGasto GetById(int Id)
        {
            try
            {
                var Objeto = new TblGasto();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblGasto WHERE IdGasto= '" + Id + "'");
                decimal valorDecimal = 0;
                DateTime Fecha;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdGasto"].ToString(), out Id);
                        Objeto.IdGasto = Id;
                        int.TryParse(reader["IdUsuario"].ToString(), out Id);
                        Objeto.IdUsuario = Id;
                        int.TryParse(reader["IdProveedor"].ToString(), out Id);
                        Objeto.IdProveedor = Id;
                        int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                        Objeto.IdFormaPago = Id;
                        int.TryParse(reader["Codigo"].ToString(), out Id);
                        Objeto.Codigo = Id;
                        DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                        Objeto.Fecha = Fecha;
                        Objeto.Concepto = reader["Concepto"].ToString();
                        decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                        Objeto.Monto = valorDecimal;
                        Objeto.Nota = reader["Nota"].ToString();
                        Objeto.NCF = reader["NCF"].ToString();
                        int.TryParse(reader["NoFactura"].ToString(), out Id);
                        Objeto.NoFactura = Id;
                        decimal.TryParse(reader["SubTotal"].ToString(), out valorDecimal);
                        Objeto.SubTotal = valorDecimal;
                        decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                        Objeto.Itbis = valorDecimal;

                    }
                }
                else
                {
                    Objeto = null;
                }
                Miconexion.Cerrar();
                return Objeto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetAll
        public List<TblGasto> GetAll()
        {
            try
            {
                TblGasto Objeto;
                var list = new List<TblGasto>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblGasto ORDER BY Fecha");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblGasto();
                    int.TryParse(reader["IdGasto"].ToString(), out Id);
                    Objeto.IdGasto = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                    Objeto.IdFormaPago = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    Objeto.Concepto = reader["Concepto"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    Objeto.Nota = reader["Nota"].ToString();
                    Objeto.NCF = reader["NCF"].ToString();
                    int.TryParse(reader["NoFactura"].ToString(), out Id);
                    Objeto.NoFactura = Id;
                    decimal.TryParse(reader["SubTotal"].ToString(), out valorDecimal);
                    Objeto.SubTotal = valorDecimal;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    list.Add(Objeto);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetBy
        public List<TblGasto> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblGasto Objeto;
                var list = new List<TblGasto>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblGasto WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblGasto();
                    int.TryParse(reader["IdGasto"].ToString(), out Id);
                    Objeto.IdGasto = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                    Objeto.IdFormaPago = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    Objeto.Concepto = reader["Concepto"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    Objeto.Nota = reader["Nota"].ToString();
                    Objeto.NCF = reader["NCF"].ToString();
                    int.TryParse(reader["NoFactura"].ToString(), out Id);
                    Objeto.NoFactura = Id;
                    decimal.TryParse(reader["SubTotal"].ToString(), out valorDecimal);
                    Objeto.SubTotal = valorDecimal;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    list.Add(Objeto);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetByFiltrado
        public List<TblGasto> GetByFiltrado(string texto)
        {
            try
            {
                TblGasto Objeto;
                var list = new List<TblGasto>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblGasto WHERE IdGasto LIKE '" + texto + "' + '%' or Concepto LIKE '" + texto + "' + '%' or Proveedor LIKE '" + texto + "' + '%'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblGasto();
                    int.TryParse(reader["IdGasto"].ToString(), out Id);
                    Objeto.IdGasto = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                    Objeto.IdFormaPago = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    Objeto.Concepto = reader["Concepto"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    Objeto.Nota = reader["Nota"].ToString();
                    Objeto.NCF = reader["NCF"].ToString();
                    int.TryParse(reader["NoFactura"].ToString(), out Id);
                    Objeto.NoFactura = Id;
                    decimal.TryParse(reader["SubTotal"].ToString(), out valorDecimal);
                    Objeto.SubTotal = valorDecimal;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    list.Add(Objeto);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetByFiltradoFecha
        public List<TblGasto> GetByFiltradoFecha(DateTime desde, DateTime hasta)
        {
            try
            {
                TblGasto Objeto;
                var list = new List<TblGasto>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblGasto WHERE Fecha >='" + ClassFecha.GetFecha(desde, 1) + "' AND Fecha <= '" + ClassFecha.GetFecha(hasta, 2) + "'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblGasto();
                    int.TryParse(reader["IdGasto"].ToString(), out Id);
                    Objeto.IdGasto = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                    Objeto.IdFormaPago = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    Objeto.Concepto = reader["Concepto"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    Objeto.Nota = reader["Nota"].ToString();
                    Objeto.NCF = reader["NCF"].ToString();
                    int.TryParse(reader["NoFactura"].ToString(), out Id);
                    Objeto.NoFactura = Id;
                    decimal.TryParse(reader["SubTotal"].ToString(), out valorDecimal);
                    Objeto.SubTotal = valorDecimal;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    list.Add(Objeto);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
