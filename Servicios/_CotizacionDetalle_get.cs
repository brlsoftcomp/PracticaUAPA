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
    class _CotizacionDetalle_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCotizacionDetalle GetById(int Id)
        {
            try
            {
                var Objeto = new TblCotizacionDetalle();
                SqlDataReader reader;
                int IdOtros = 0;
                decimal valor = 0;
                reader = Miconexion.Buscar("SELECT * FROM TblCotizacionDetalle WHERE IdCotizacionDetalle = '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCotizacionDetalle"].ToString(), out IdOtros);
                        Objeto.IdCotizacionDetalle = IdOtros;
                        int.TryParse(reader["IdCotizacion"].ToString(), out IdOtros);
                        Objeto.IdCotizacion = IdOtros;
                        int.TryParse(reader["IdProducto"].ToString(), out IdOtros);
                        Objeto.IdProducto = IdOtros;
                        int.TryParse(reader["CantidadCotizada"].ToString(), out IdOtros);
                        Objeto.CantidadCotizada = IdOtros;
                        decimal.TryParse(reader["PrecioCotizado"].ToString(), out valor);
                        Objeto.PrecioCotizado = valor;
                        decimal.TryParse(reader["MontoCotizado"].ToString(), out valor);
                        Objeto.MontoCotizado = valor;
                        decimal.TryParse(reader["ItbisCotizado"].ToString(), out valor);
                        Objeto.ItbisCotizado = valor;
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
        public List<TblCotizacionDetalle> GetByIdFK(int Id)
        {
            try
            {
                TblCotizacionDetalle Objeto;
                var list = new List<TblCotizacionDetalle>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT IdCotizacionDetalle, IdCotizacion, TblCotizacionDetalle.IdProducto, TblProducto.Nombre, CantidadCotizada, PrecioCotizado, MontoCotizado, ItbisCotizado, Ganancia FROM TblCotizacionDetalle JOIN TblProducto on TblProducto.IdProducto =  TblCotizacionDetalle.IdProducto WHERE IdCotizacion = '" + Id + "'");
                dt = Miconexion.BuscarTabla(builder);
                int IdOtros = 0;
                decimal valor = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCotizacionDetalle();
                    int.TryParse(reader["IdCotizacionDetalle"].ToString(), out IdOtros);
                    Objeto.IdCotizacionDetalle = IdOtros;                    
                    int.TryParse(reader["IdCotizacion"].ToString(), out IdOtros);
                    Objeto.IdCotizacion = IdOtros;
                    int.TryParse(reader["IdProducto"].ToString(), out IdOtros);
                    Objeto.IdProducto = IdOtros;
                    Objeto.Descripcion = reader["Nombre"].ToString();
                    int.TryParse(reader["CantidadCotizada"].ToString(), out IdOtros);
                    Objeto.CantidadCotizada = IdOtros;
                    decimal.TryParse(reader["PrecioCotizado"].ToString(), out valor);
                    Objeto.PrecioCotizado = valor;
                    decimal.TryParse(reader["MontoCotizado"].ToString(), out valor);
                    Objeto.MontoCotizado = valor;
                    decimal.TryParse(reader["ItbisCotizado"].ToString(), out valor);
                    Objeto.ItbisCotizado = valor;
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
        public List<TblCotizacionDetalle> GetAll()
        {
            try
            {
                TblCotizacionDetalle Objeto;
                var list = new List<TblCotizacionDetalle>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCotizacionDetalle ORDER BY Fecha");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int IdOtros = 0;
                decimal valor = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCotizacionDetalle();
                    int.TryParse(reader["IdCotizacionDetalle"].ToString(), out IdOtros);
                    Objeto.IdCotizacionDetalle = IdOtros;
                    int.TryParse(reader["IdCotizacion"].ToString(), out IdOtros);
                    Objeto.IdCotizacion = IdOtros;
                    int.TryParse(reader["IdProducto"].ToString(), out IdOtros);
                    Objeto.IdProducto = IdOtros;
                    int.TryParse(reader["CantidadCotizada"].ToString(), out IdOtros);
                    Objeto.CantidadCotizada = IdOtros;
                    decimal.TryParse(reader["PrecioCotizado"].ToString(), out valor);
                    Objeto.PrecioCotizado = valor;
                    decimal.TryParse(reader["MontoCotizado"].ToString(), out valor);
                    Objeto.MontoCotizado = valor;
                    decimal.TryParse(reader["ItbisCotizado"].ToString(), out valor);
                    Objeto.ItbisCotizado = valor;
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
        public List<TblCotizacionDetalle> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblCotizacionDetalle Objeto;
                var list = new List<TblCotizacionDetalle>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCotizacionDetalle WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int IdOtros = 0;
                decimal valor = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCotizacionDetalle();
                    int.TryParse(reader["IdCotizacionDetalle"].ToString(), out IdOtros);
                    Objeto.IdCotizacionDetalle = IdOtros;
                    int.TryParse(reader["IdCotizacion"].ToString(), out IdOtros);
                    Objeto.IdCotizacion = IdOtros;
                    int.TryParse(reader["IdProducto"].ToString(), out IdOtros);
                    Objeto.IdProducto = IdOtros;
                    int.TryParse(reader["CantidadCotizada"].ToString(), out IdOtros);
                    Objeto.CantidadCotizada = IdOtros;
                    decimal.TryParse(reader["PrecioCotizado"].ToString(), out valor);
                    Objeto.PrecioCotizado = valor;
                    decimal.TryParse(reader["MontoCotizado"].ToString(), out valor);
                    Objeto.MontoCotizado = valor;
                    decimal.TryParse(reader["ItbisCotizado"].ToString(), out valor);
                    Objeto.ItbisCotizado = valor;
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
    }
}
