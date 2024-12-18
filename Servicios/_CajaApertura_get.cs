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
    class _CajaApertura_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCajaApertura GetById(int Id)
        {
            try
            {
                var Objeto = new TblCajaApertura();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblCajaApertura WHERE IdCajaApertura= '" + Id + "'");
                decimal valorDecimal = 0;
                DateTime fecha;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCajaApertura"].ToString(), out Id);
                        Objeto.IdCajaApertura = Id;
                        int.TryParse(reader["IdUsuario"].ToString(), out Id);
                        Objeto.IdUsuario = Id;
                        DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                        Objeto.Fecha = fecha;
                        Objeto.Caja = reader["Caja"].ToString();
                        decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                        Objeto.Monto = valorDecimal;
                        Objeto.Estado = reader["Estado"].ToString();
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
        public List<TblCajaApertura> GetAll()
        {
            try
            {
                TblCajaApertura Objeto;
                var list = new List<TblCajaApertura>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCajaApertura ORDER BY Usuario");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCajaApertura();
                    int.TryParse(reader["IdCajaApertura"].ToString(), out Id);
                    Objeto.IdCajaApertura = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.Caja = reader["Caja"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    Objeto.Estado = reader["Estado"].ToString();
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
        public List<TblCajaApertura> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblCajaApertura Objeto;
                var list = new List<TblCajaApertura>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCajaApertura WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCajaApertura();
                    int.TryParse(reader["IdCajaApertura"].ToString(), out Id);
                    Objeto.IdCajaApertura = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.Caja = reader["Caja"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    Objeto.Estado = reader["Estado"].ToString();
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
        public List<TblCajaApertura> GetByFiltrado(string texto)
        {
            try
            {
                TblCajaApertura Objeto;
                var list = new List<TblCajaApertura>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCajaApertura WHERE Usuario LIKE '" + texto + "' + '%' or IdCajaApertura LIKE '" + texto + "' + '%'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCajaApertura();
                    int.TryParse(reader["IdCajaApertura"].ToString(), out Id);
                    Objeto.IdCajaApertura = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.Caja = reader["Caja"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    Objeto.Estado = reader["Estado"].ToString();
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

        #region GetByEstado
        public TblCajaApertura GetByEstado()
        {
            try
            {
                var Objeto = new TblCajaApertura();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT TOP 1 * FROM TblCajaApertura ORDER BY IdCajaApertura DESC");
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCajaApertura"].ToString(), out valorInt);
                        Objeto.IdCajaApertura = valorInt;
                        int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                        Objeto.IdUsuario = valorInt;
                        DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                        Objeto.Fecha = fecha;
                        Objeto.Caja = reader["Caja"].ToString();
                        decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                        Objeto.Monto = valorDecimal;
                        Objeto.Estado = reader["Estado"].ToString();
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

    }
}
