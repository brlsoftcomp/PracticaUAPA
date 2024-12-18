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
    class _FacturaDetalle_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblFacturaDetalle GetById(int Id)
        {
            try
            {
                var Objeto = new TblFacturaDetalle();
                SqlDataReader reader;
                int IdOtros = 0;
                decimal valor = 0;
                reader = Miconexion.Buscar("SELECT * FROM TblFacturaDetalle WHERE IdFacturaDetalle = '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdFacturaDetalle"].ToString(), out IdOtros);
                        Objeto.IdFacturaDetalle = IdOtros;
                        int.TryParse(reader["IdFactura"].ToString(), out IdOtros);
                        Objeto.IdFactura = IdOtros;
                        int.TryParse(reader["IdProducto"].ToString(), out IdOtros);
                        Objeto.IdProducto = IdOtros;
                        int.TryParse(reader["CantidadFacturada"].ToString(), out IdOtros);
                        Objeto.CantidadFacturada = IdOtros;
                        decimal.TryParse(reader["PrecioFacturado"].ToString(), out valor);
                        Objeto.PrecioFacturado = valor;
                        decimal.TryParse(reader["ItbisFacturado"].ToString(), out valor);
                        Objeto.ItbisFacturado = valor;
                        decimal.TryParse(reader["MontoFacturado"].ToString(), out valor);
                        Objeto.MontoFacturado = valor;
                        decimal.TryParse(reader["Ganancia"].ToString(), out valor);
                        Objeto.Ganancia = valor;
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

        #region GetByIdFK
        public List<TblFacturaDetalle> GetByIdFK(int Id)
        {
            try
            {
                TblFacturaDetalle Objeto;
                var list = new List<TblFacturaDetalle>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT IdFacturaDetalle, IdFactura, TblFacturaDetalle.IdProducto, TblProducto.Codigo AS CodigoProduct, TblProducto.Nombre, CantidadFacturada, PrecioFacturado, MontoFacturado, Ganancia FROM TblFacturaDetalle JOIN TblProducto on TblProducto.IdProducto =  TblFacturaDetalle.IdProducto WHERE IdFactura = '" + Id + "'");
                dt = Miconexion.BuscarTabla(builder);
                int IdOtros = 0;
                decimal valor = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblFacturaDetalle();
                    int.TryParse(reader["IdFacturaDetalle"].ToString(), out IdOtros);
                    Objeto.IdFacturaDetalle = IdOtros;
                    int.TryParse(reader["IdFactura"].ToString(), out IdOtros);
                    Objeto.IdFactura = IdOtros;
                    int.TryParse(reader["IdProducto"].ToString(), out IdOtros);
                    Objeto.IdProducto = IdOtros;
                    int.TryParse(reader["CodigoProduct"].ToString(), out IdOtros);
                    Objeto.Codigo = IdOtros;
                    Objeto.Descripcion = reader["Nombre"].ToString();
                    int.TryParse(reader["CantidadFacturada"].ToString(), out IdOtros);
                    Objeto.CantidadFacturada = IdOtros;
                    decimal.TryParse(reader["PrecioFacturado"].ToString(), out valor);
                    Objeto.PrecioFacturado = valor;
                    decimal.TryParse(reader["MontoFacturado"].ToString(), out valor);
                    Objeto.MontoFacturado = valor;
                    decimal.TryParse(reader["Ganancia"].ToString(), out valor);
                    Objeto.Ganancia = valor;
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

        #region GetAll
        public List<TblFacturaDetalle> GetAll()
        {
            try
            {
                TblFacturaDetalle Objeto;
                var list = new List<TblFacturaDetalle>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblFacturaDetalle ORDER BY Fecha");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int IdOtros = 0;
                decimal valor = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblFacturaDetalle();
                    int.TryParse(reader["IdFacturaDetalle"].ToString(), out IdOtros);
                    Objeto.IdFacturaDetalle = IdOtros;
                    int.TryParse(reader["IdFactura"].ToString(), out IdOtros);
                    Objeto.IdFactura = IdOtros;
                    int.TryParse(reader["IdProducto"].ToString(), out IdOtros);
                    Objeto.IdProducto = IdOtros;
                    int.TryParse(reader["CantidadFacturada"].ToString(), out IdOtros);
                    Objeto.CantidadFacturada = IdOtros;
                    decimal.TryParse(reader["PrecioFacturado"].ToString(), out valor);
                    Objeto.PrecioFacturado = valor;
                    decimal.TryParse(reader["ItbisFacturado"].ToString(), out valor);
                    Objeto.ItbisFacturado = valor;
                    decimal.TryParse(reader["MontoFacturado"].ToString(), out valor);
                    Objeto.PrecioFacturado = valor;
                    decimal.TryParse(reader["Ganancia"].ToString(), out valor);
                    Objeto.Ganancia = valor;
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
        public List<TblFacturaDetalle> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblFacturaDetalle Objeto;
                var list = new List<TblFacturaDetalle>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblFacturaDetalle WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int IdOtros = 0;
                decimal valor = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblFacturaDetalle();
                    int.TryParse(reader["IdFacturaDetalle"].ToString(), out IdOtros);
                    Objeto.IdFacturaDetalle = IdOtros;
                    int.TryParse(reader["IdFactura"].ToString(), out IdOtros);
                    Objeto.IdFactura = IdOtros;
                    int.TryParse(reader["IdProducto"].ToString(), out IdOtros);
                    Objeto.IdProducto = IdOtros;
                    int.TryParse(reader["CantidadFacturada"].ToString(), out IdOtros);
                    Objeto.CantidadFacturada = IdOtros;
                    decimal.TryParse(reader["PrecioFacturado"].ToString(), out valor);
                    Objeto.PrecioFacturado = valor;
                    decimal.TryParse(reader["ItbisFacturado"].ToString(), out valor);
                    Objeto.ItbisFacturado = valor;
                    decimal.TryParse(reader["MontoFacturado"].ToString(), out valor);
                    Objeto.MontoFacturado = valor;
                    decimal.TryParse(reader["Ganancia"].ToString(), out valor);
                    Objeto.Ganancia = valor;
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

        #region GetTotalFactByFecha
        public int GetTotalFactByFecha(int Id, DateTime desde, DateTime hasta)
        {
            try
            {
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT SUM(TblFacturaDetalle.CantidadFacturada) AS TotalFacturado FROM TblFacturaDetalle JOIN");
                builder.Append(" TblFactura ON TblFacturaDetalle.IdFactura = TblFactura.IdFactura");
                builder.Append(" JOIN TblProducto ON TblFacturaDetalle.IdProducto = TblProducto.IdProducto");
                builder.Append(" WHERE TblProducto.IdProducto = '" + Id + "'");
                //builder.Append(" AND TblFactura.Fecha >= '" + ClassFecha.GetFechaUSA(desde, 1) + "'");
                //builder.Append(" AND TblFactura.Fecha <= '" + ClassFecha.GetFechaUSA(hasta, 2) + "'");
                builder.Append(" AND TblFactura.Fecha >= '" + ClassFecha.GetFecha(desde, 1) + "'");
                builder.Append(" AND TblFactura.Fecha <= '" + ClassFecha.GetFecha(hasta, 2) + "'");
                dt = Miconexion.BuscarTabla(builder);
                int TotalCantidad = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    int.TryParse(reader["TotalFacturado"].ToString(), out TotalCantidad);
                }
                return TotalCantidad;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
