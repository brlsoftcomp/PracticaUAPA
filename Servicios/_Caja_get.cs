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
    class _Caja_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCaja GetById(int Id)
        {
            try
            {
                var Objeto = new TblCaja();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblCaja WHERE IdCaja= '" + Id + "'");
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCaja"].ToString(), out Id);
                        Objeto.IdCaja = Id;
                        int.TryParse(reader["IdUsuario"].ToString(), out Id);
                        Objeto.IdUsuario = Id;
                        DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                        Objeto.Fecha = fecha;
                        int.TryParse(reader["Registro"].ToString(), out valorInt);
                        Objeto.Registro = valorInt;
                        Objeto.Modulo = reader["Modulo"].ToString();
                        decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                        Objeto.Monto = valorDecimal;
                        
                        Objeto.Caja = reader["Caja"].ToString();
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

        #region GetById
        public TblCaja GetByIdRegModulo(int Id, string modulo)
        {
            try
            {
                var Objeto = new TblCaja();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblCaja WHERE Registro= '" + Id + "' AND Modulo ='"+ modulo + "'");
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCaja"].ToString(), out Id);
                        Objeto.IdCaja = Id;
                        int.TryParse(reader["IdUsuario"].ToString(), out Id);
                        Objeto.IdUsuario = Id;
                        DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                        Objeto.Fecha = fecha;
                        int.TryParse(reader["Registro"].ToString(), out valorInt);
                        Objeto.Registro = valorInt;
                        Objeto.Modulo = reader["Modulo"].ToString();
                        decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                        Objeto.Monto = valorDecimal;

                        Objeto.Caja = reader["Caja"].ToString();
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

        #region GetMovimiento
        public List<TblCaja> GetMovimiento(string Modulo, int IdCajaApertura)
        {
            try
            {
                TblCaja Objeto;
                var list = new List<TblCaja>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCaja WHERE Modulo ='" + Modulo + "' AND IdCajaApertura = '" + IdCajaApertura + "'");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCaja();
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

        #region GetAll
        public List<TblCaja> GetAll()
        {
            try
            {
                TblCaja Objeto;
                var list = new List<TblCaja>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCaja ORDER BY Usuario");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCaja();
                    int.TryParse(reader["IdCaja"].ToString(), out Id);
                    Objeto.IdCaja = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    int.TryParse(reader["Registro"].ToString(), out valorInt);
                    Objeto.Registro = valorInt;
                    Objeto.Modulo = reader["Modulo"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    Objeto.Caja = reader["Caja"].ToString();
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
        public List<TblCaja> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblCaja Objeto;
                var list = new List<TblCaja>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCaja WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCaja();
                    int.TryParse(reader["IdCaja"].ToString(), out Id);
                    Objeto.IdCaja = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    int.TryParse(reader["Registro"].ToString(), out valorInt);
                    Objeto.Registro = valorInt;
                    Objeto.Modulo = reader["Modulo"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    Objeto.Caja = reader["Caja"].ToString();
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
        public List<TblCaja> GetByFiltrado(string texto)
        {
            try
            {
                TblCaja Objeto;
                var list = new List<TblCaja>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCaja WHERE Usuario LIKE '" + texto + "' + '%' or IdCaja LIKE '" + texto + "' + '%'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCaja();
                    int.TryParse(reader["IdCaja"].ToString(), out Id);
                    Objeto.IdCaja = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    int.TryParse(reader["Registro"].ToString(), out valorInt);
                    Objeto.Registro = valorInt;
                    Objeto.Modulo = reader["Modulo"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    Objeto.Caja = reader["Caja"].ToString();
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
    }
}
