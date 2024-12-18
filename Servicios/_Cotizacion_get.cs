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
    class _Cotizacion_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCotizacion GetById(int Id)
        {
            try
            {
                var Objeto = new TblCotizacion();
                SqlDataReader reader;
                DateTime fecha;
                int IdOtros = 0;
                decimal valor = 0;
                reader = Miconexion.Buscar("SELECT * FROM TblCotizacion WHERE IdCotizacion = '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Objeto.IdCotizacion = Id;
                        int.TryParse(reader["IdUsuario"].ToString(), out IdOtros);
                        Objeto.IdUsuario = IdOtros;
                        int.TryParse(reader["IdCliente"].ToString(), out IdOtros);
                        Objeto.IdCliente = IdOtros;
                        int.TryParse(reader["Codigo"].ToString(), out IdOtros);
                        Objeto.Codigo = IdOtros;
                        DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                        Objeto.Fecha = fecha;
                        decimal.TryParse(reader["SubTotal"].ToString(), out valor);
                        Objeto.SubTotal = valor;
                        decimal.TryParse(reader["Itbis"].ToString(), out valor);
                        Objeto.Itbis = valor;
                        decimal.TryParse(reader["Total"].ToString(), out valor);
                        Objeto.Total = valor;
                        Objeto.Nota = reader["Nota"].ToString();
                        decimal.TryParse(reader["TotalGanancia"].ToString(), out valor);
                        Objeto.TotalGanancia = valor;
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
        public List<TblCotizacion> GetAll()
        {
            try
            {
                TblCotizacion Objeto;
                var list = new List<TblCotizacion>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCotizacion ORDER BY Fecha");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int IdOtros = 0;
                decimal valor = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCotizacion();
                    Objeto.IdCotizacion = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out IdOtros);
                    Objeto.IdUsuario = IdOtros;
                    int.TryParse(reader["IdCliente"].ToString(), out IdOtros);
                    Objeto.IdCliente = IdOtros;
                    int.TryParse(reader["Codigo"].ToString(), out IdOtros);
                    Objeto.Codigo = IdOtros;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    decimal.TryParse(reader["SubTotal"].ToString(), out valor);
                    Objeto.SubTotal = valor;
                    decimal.TryParse(reader["Itbis"].ToString(), out valor);
                    Objeto.Itbis = valor;
                    decimal.TryParse(reader["Total"].ToString(), out valor);
                    Objeto.Total = valor;
                    Objeto.Nota = reader["Nota"].ToString();
                    decimal.TryParse(reader["TotalGanancia"].ToString(), out valor);
                    Objeto.TotalGanancia = valor;
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
        public List<TblCotizacion> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblCotizacion Objeto;
                var list = new List<TblCotizacion>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCotizacion WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int IdOtros = 0;
                decimal valor = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCotizacion();
                    Objeto.IdCotizacion = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out IdOtros);
                    Objeto.IdUsuario = IdOtros;
                    int.TryParse(reader["IdCliente"].ToString(), out IdOtros);
                    Objeto.IdCliente = IdOtros;
                    int.TryParse(reader["Codigo"].ToString(), out IdOtros);
                    Objeto.Codigo = IdOtros;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    decimal.TryParse(reader["SubTotal"].ToString(), out valor);
                    Objeto.SubTotal = valor;
                    decimal.TryParse(reader["Itbis"].ToString(), out valor);
                    Objeto.Itbis = valor;
                    decimal.TryParse(reader["Total"].ToString(), out valor);
                    Objeto.Total = valor;
                    Objeto.Nota = reader["Nota"].ToString();
                    decimal.TryParse(reader["TotalGanancia"].ToString(), out valor);
                    Objeto.TotalGanancia = valor;
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
        public List<TblCotizacion> GetByFiltrado(string texto)
        {
            try
            {
                TblCotizacion Objeto;
                var list = new List<TblCotizacion>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT IdCotizacion, IdUsuario, IdCliente, Codigo, Fecha, Total, TotalGanancia FROM TblCotizacion WHERE IdCotizacion LIKE '" + texto + "' + '%' OR NombreCliente LIKE '" + texto + "' + '%' ORDER BY Fecha DESC"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int IdOtros = 0;
                decimal valor = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCotizacion();
                    int.TryParse(reader["IdCotizacion"].ToString(), out Id);
                    Objeto.IdCotizacion = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out IdOtros);
                    Objeto.IdUsuario = IdOtros;
                    int.TryParse(reader["IdCliente"].ToString(), out IdOtros);
                    Objeto.IdCliente = IdOtros;
                    int.TryParse(reader["Codigo"].ToString(), out IdOtros);
                    Objeto.Codigo = IdOtros;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    decimal.TryParse(reader["Total"].ToString(), out valor);
                    Objeto.Total = valor;
                    decimal.TryParse(reader["TotalGanancia"].ToString(), out valor);
                    Objeto.TotalGanancia = valor;
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
