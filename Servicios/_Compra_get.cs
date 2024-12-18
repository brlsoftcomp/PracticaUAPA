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
    class _Compra_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCompra GetById(int Id)
        {
            try
            {
                var Objeto = new TblCompra();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblCompra WHERE IdCompra= '" + Id + "'");
                decimal valorDecimal = 0;
                DateTime Fecha;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCompra"].ToString(), out Id);
                        Objeto.IdCompra = Id;
                        int.TryParse(reader["IdUsuario"].ToString(), out Id);
                        Objeto.IdUsuario = Id;
                        int.TryParse(reader["IdProveedor"].ToString(), out Id);
                        Objeto.IdProveedor = Id;
                        int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                        Objeto.IdFormaPago = Id;
                        DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                        Objeto.Fecha = Fecha;
                        int.TryParse(reader["NoFactura"].ToString(), out Id);
                        Objeto.NoFactura = Id;
                        Objeto.NCF = reader["NCF"].ToString();
                        Objeto.CondicionCompra = reader["CondicionCompra"].ToString();
                        decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                        Objeto.Itbis = valorDecimal;
                        decimal.TryParse(reader["SubTotal"].ToString(), out valorDecimal);
                        Objeto.SubTotal = valorDecimal;
                        decimal.TryParse(reader["Total"].ToString(), out valorDecimal);
                        Objeto.Total = valorDecimal;
                        Objeto.Nota = reader["Nota"].ToString();
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
        public List<TblCompra> GetAll()
        {
            try
            {
                TblCompra Objeto;
                var list = new List<TblCompra>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCompra ORDER BY Fecha");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCompra();
                    int.TryParse(reader["IdCompra"].ToString(), out Id);
                    Objeto.IdCompra = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                    Objeto.IdFormaPago = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    int.TryParse(reader["NoFactura"].ToString(), out Id);
                    Objeto.NoFactura = Id;
                    Objeto.NCF = reader["NCF"].ToString();
                    Objeto.CondicionCompra = reader["CondicionCompra"].ToString();
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    decimal.TryParse(reader["SubTotal"].ToString(), out valorDecimal);
                    Objeto.SubTotal = valorDecimal;
                    decimal.TryParse(reader["Total"].ToString(), out valorDecimal);
                    Objeto.Total = valorDecimal;
                    Objeto.Nota = reader["Nota"].ToString();
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
        public List<TblCompra> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblCompra Objeto;
                var list = new List<TblCompra>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCompra WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCompra();
                    int.TryParse(reader["IdCompra"].ToString(), out Id);
                    Objeto.IdCompra = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                    Objeto.IdFormaPago = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    int.TryParse(reader["NoFactura"].ToString(), out Id);
                    Objeto.NoFactura = Id;
                    Objeto.NCF = reader["NCF"].ToString();
                    Objeto.CondicionCompra = reader["CondicionCompra"].ToString();
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    decimal.TryParse(reader["SubTotal"].ToString(), out valorDecimal);
                    Objeto.SubTotal = valorDecimal;
                    decimal.TryParse(reader["Total"].ToString(), out valorDecimal);
                    Objeto.Total = valorDecimal;
                    Objeto.Nota = reader["Nota"].ToString();
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
        public List<TblCompra> GetByFiltrado(string texto)
        {
            try
            {
                TblCompra Objeto;
                var list = new List<TblCompra>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT *,  TblProveedor.Nombre FROM TblCompra JOIN TblProveedor ON TblProveedor.IdProveedor = TblCompra.IdProveedor"));
                builder.Append(string.Format(" WHERE IdCompra LIKE '" + texto + "' + '%' or NoFactura LIKE '" + texto + "' + '%' or Proveedor LIKE '" + texto + "' + '%'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCompra();
                    int.TryParse(reader["IdCompra"].ToString(), out Id);
                    Objeto.IdCompra = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                    Objeto.IdFormaPago = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    int.TryParse(reader["NoFactura"].ToString(), out Id);
                    Objeto.NoFactura = Id;
                    Objeto.NCF = reader["NCF"].ToString();
                    Objeto.CondicionCompra = reader["CondicionCompra"].ToString();
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    decimal.TryParse(reader["SubTotal"].ToString(), out valorDecimal);
                    Objeto.SubTotal = valorDecimal;
                    decimal.TryParse(reader["Total"].ToString(), out valorDecimal);
                    Objeto.Total = valorDecimal;
                    Objeto.Nota = reader["Nota"].ToString();
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
        public List<TblCompra> GetByFiltradoFecha(DateTime desde, DateTime hasta)
        {
            try
            {
                TblCompra Objeto;
                var list = new List<TblCompra>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCompra WHERE Fecha >='" + ClassFecha.GetFecha(desde, 1) + "' AND Fecha <= '" + ClassFecha.GetFecha(hasta, 2) + "'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCompra();
                    int.TryParse(reader["IdCompra"].ToString(), out Id);
                    Objeto.IdCompra = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                    Objeto.IdFormaPago = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    int.TryParse(reader["NoFactura"].ToString(), out Id);
                    Objeto.NoFactura = Id;
                    Objeto.NCF = reader["NCF"].ToString();
                    Objeto.CondicionCompra = reader["CondicionCompra"].ToString();
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    decimal.TryParse(reader["SubTotal"].ToString(), out valorDecimal);
                    Objeto.SubTotal = valorDecimal;
                    decimal.TryParse(reader["Total"].ToString(), out valorDecimal);
                    Objeto.Total = valorDecimal;
                    Objeto.Nota = reader["Nota"].ToString();
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
