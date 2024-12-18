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
    class _CajaCierre_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCajaCierre GetById(int Id)
        {
            try
            {
                var Objeto = new TblCajaCierre();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblCajaCierre WHERE IdCajaCierre= '" + Id + "'");
                decimal valorDecimal = 0;
                DateTime fecha;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCajaCierre"].ToString(), out Id);
                        Objeto.IdCajaCierre = Id;
                        int.TryParse(reader["IdCajaApertura"].ToString(), out Id);
                        Objeto.IdCajaApertura = Id;
                        int.TryParse(reader["IdUsuario"].ToString(), out Id);
                        Objeto.IdUsuario = Id;
                        int.TryParse(reader["Codigo"].ToString(), out Id);
                        Objeto.Codigo = Id;
                        DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                        Objeto.Fecha = fecha;
                        Objeto.Caja = reader["Caja"].ToString();
                        decimal.TryParse(reader["TotalEntrada"].ToString(), out valorDecimal);
                        Objeto.TotalEntrada = valorDecimal;
                        decimal.TryParse(reader["TotalSalida"].ToString(), out valorDecimal);
                        Objeto.TotalSalida = valorDecimal;
                        decimal.TryParse(reader["TotalConteo"].ToString(), out valorDecimal);
                        Objeto.TotalConteo = valorDecimal;
                        decimal.TryParse(reader["Diferencia"].ToString(), out valorDecimal);
                        Objeto.Diferencia = valorDecimal;
                        Objeto.Resultado = reader["Resultado"].ToString();

                        decimal.TryParse(reader["Ventas"].ToString(), out valorDecimal);
                        Objeto.Ventas = valorDecimal;
                        decimal.TryParse(reader["CobrosCxC"].ToString(), out valorDecimal);
                        Objeto.CobrosCxC = valorDecimal;
                        decimal.TryParse(reader["Compras"].ToString(), out valorDecimal);
                        Objeto.Compras = valorDecimal;
                        decimal.TryParse(reader["Gastos"].ToString(), out valorDecimal);
                        Objeto.Gastos = valorDecimal;
                        decimal.TryParse(reader["DevVentas"].ToString(), out valorDecimal);
                        Objeto.DevVentas = valorDecimal;
                        decimal.TryParse(reader["PagosCxP"].ToString(), out valorDecimal);
                        Objeto.PagosCxP = valorDecimal;
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

        #region GetMontoApertura
        public decimal GetMontoApertura(int Id)
        {
            try
            {
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT TblCajaApertura.Monto FROM TblCajaCierre JOIN TblCajaApertura ON TblCajaCierre.IdCajaApertura = TblCajaApertura.IdCajaApertura WHERE IdCajaCierre= '" + Id + "'");
                decimal valorDecimal = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    }
                }
                else
                {
                    valorDecimal = 0;
                }
                Miconexion.Cerrar();
                return valorDecimal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetAll
        public List<TblCajaCierre> GetAll()
        {
            try
            {
                TblCajaCierre Objeto;
                var list = new List<TblCajaCierre>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCajaCierre ORDER BY IdCajaApertura");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCajaCierre();
                    int.TryParse(reader["IdCajaCierre"].ToString(), out Id);
                    Objeto.IdCajaCierre = Id;
                    int.TryParse(reader["IdCajaApertura"].ToString(), out Id);
                    Objeto.IdCajaApertura = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.Caja = reader["Caja"].ToString();
                    decimal.TryParse(reader["TotalEntrada"].ToString(), out valorDecimal);
                    Objeto.TotalEntrada = valorDecimal;
                    decimal.TryParse(reader["TotalSalida"].ToString(), out valorDecimal);
                    Objeto.TotalSalida = valorDecimal;
                    decimal.TryParse(reader["TotalConteo"].ToString(), out valorDecimal);
                    Objeto.TotalConteo = valorDecimal;
                    decimal.TryParse(reader["Diferencia"].ToString(), out valorDecimal);
                    Objeto.Diferencia = valorDecimal;
                    Objeto.Resultado = reader["Resultado"].ToString();

                    decimal.TryParse(reader["Ventas"].ToString(), out valorDecimal);
                    Objeto.Ventas = valorDecimal;
                    decimal.TryParse(reader["CobrosCxC"].ToString(), out valorDecimal);
                    Objeto.CobrosCxC = valorDecimal;
                    decimal.TryParse(reader["Compras"].ToString(), out valorDecimal);
                    Objeto.Compras = valorDecimal;
                    decimal.TryParse(reader["Gastos"].ToString(), out valorDecimal);
                    Objeto.Gastos = valorDecimal;
                    decimal.TryParse(reader["DevVentas"].ToString(), out valorDecimal);
                    Objeto.DevVentas = valorDecimal;
                    decimal.TryParse(reader["PagosCxP"].ToString(), out valorDecimal);
                    Objeto.PagosCxP = valorDecimal;
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
        public List<TblCajaCierre> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblCajaCierre Objeto;
                var list = new List<TblCajaCierre>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCajaCierre WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCajaCierre();
                    int.TryParse(reader["IdCajaCierre"].ToString(), out Id);
                    Objeto.IdCajaCierre = Id;
                    int.TryParse(reader["IdCajaApertura"].ToString(), out Id);
                    Objeto.IdCajaApertura = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.Caja = reader["Caja"].ToString();
                    decimal.TryParse(reader["TotalEntrada"].ToString(), out valorDecimal);
                    Objeto.TotalEntrada = valorDecimal;
                    decimal.TryParse(reader["TotalSalida"].ToString(), out valorDecimal);
                    Objeto.TotalSalida = valorDecimal;
                    decimal.TryParse(reader["TotalConteo"].ToString(), out valorDecimal);
                    Objeto.TotalConteo = valorDecimal;
                    decimal.TryParse(reader["Diferencia"].ToString(), out valorDecimal);
                    Objeto.Diferencia = valorDecimal;
                    Objeto.Resultado = reader["Resultado"].ToString();

                    decimal.TryParse(reader["Ventas"].ToString(), out valorDecimal);
                    Objeto.Ventas = valorDecimal;
                    decimal.TryParse(reader["CobrosCxC"].ToString(), out valorDecimal);
                    Objeto.CobrosCxC = valorDecimal;
                    decimal.TryParse(reader["Compras"].ToString(), out valorDecimal);
                    Objeto.Compras = valorDecimal;
                    decimal.TryParse(reader["Gastos"].ToString(), out valorDecimal);
                    Objeto.Gastos = valorDecimal;
                    decimal.TryParse(reader["DevVentas"].ToString(), out valorDecimal);
                    Objeto.DevVentas = valorDecimal;
                    decimal.TryParse(reader["PagosCxP"].ToString(), out valorDecimal);
                    Objeto.PagosCxP = valorDecimal;
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
        public List<TblCajaCierre> GetByFiltrado(DateTime dateTime)
        {
            try
            {
                DateTime fecha;
                fecha = dateTime;
                TblCajaCierre Objeto;
                var list = new List<TblCajaCierre>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCajaCierre WHERE Fecha = '"+ fecha + "'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCajaCierre();
                    int.TryParse(reader["IdCajaCierre"].ToString(), out Id);
                    Objeto.IdCajaCierre = Id;
                    int.TryParse(reader["IdCajaApertura"].ToString(), out Id);
                    Objeto.IdCajaApertura = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.Caja = reader["Caja"].ToString();
                    decimal.TryParse(reader["TotalEntrada"].ToString(), out valorDecimal);
                    Objeto.TotalEntrada = valorDecimal;
                    decimal.TryParse(reader["TotalSalida"].ToString(), out valorDecimal);
                    Objeto.TotalSalida = valorDecimal;
                    decimal.TryParse(reader["TotalConteo"].ToString(), out valorDecimal);
                    Objeto.TotalConteo = valorDecimal;
                    decimal.TryParse(reader["Diferencia"].ToString(), out valorDecimal);
                    Objeto.Diferencia = valorDecimal;
                    Objeto.Resultado = reader["Resultado"].ToString();

                    decimal.TryParse(reader["Ventas"].ToString(), out valorDecimal);
                    Objeto.Ventas = valorDecimal;
                    decimal.TryParse(reader["CobrosCxC"].ToString(), out valorDecimal);
                    Objeto.CobrosCxC = valorDecimal;
                    decimal.TryParse(reader["Compras"].ToString(), out valorDecimal);
                    Objeto.Compras = valorDecimal;
                    decimal.TryParse(reader["Gastos"].ToString(), out valorDecimal);
                    Objeto.Gastos = valorDecimal;
                    decimal.TryParse(reader["DevVentas"].ToString(), out valorDecimal);
                    Objeto.DevVentas = valorDecimal;
                    decimal.TryParse(reader["PagosCxP"].ToString(), out valorDecimal);
                    Objeto.PagosCxP = valorDecimal;
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

        #region GetByFiltrado2
        public List<TblCajaCierre> GetByFiltrado2(string texto)
        {
            try
            {
                DateTime fecha;
                TblCajaCierre Objeto;
                var list = new List<TblCajaCierre>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT IdCajaCierre, TblCajaCierre.IdCajaApertura As IdCajaApert, TblCajaCierre.IdUsuario As CodigoUsuario, TblCajaCierre.Codigo, TblCajaCierre.Fecha, TblCajaCierre.Caja, TblCajaApertura.Monto As MontoApertura, TotalEntrada, TotalSalida, TotalConteo, Diferencia, Resultado, TblUsuario.Nombre, TblCajaCierre.Nota As nota FROM TblCajaCierre JOIN TblUsuario on TblUsuario.IdUsuario = TblCajaCierre.IdUsuario");
                builder.Append(" JOIN TblCajaApertura on TblCajaApertura.IdCajaApertura = TblCajaCierre.IdCajaApertura");
                builder.Append(" WHERE Codigo LIKE '" + texto + "'");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCajaCierre();
                    int.TryParse(reader["IdCajaCierre"].ToString(), out Id);
                    Objeto.IdCajaCierre = Id;
                    int.TryParse(reader["IdCajaApert"].ToString(), out Id);
                    Objeto.IdCajaApertura = Id;
                    int.TryParse(reader["CodigoUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.Caja = reader["Caja"].ToString();
                    decimal.TryParse(reader["TotalEntrada"].ToString(), out valorDecimal);
                    Objeto.TotalEntrada = valorDecimal;
                    decimal.TryParse(reader["TotalSalida"].ToString(), out valorDecimal);
                    Objeto.TotalSalida = valorDecimal;
                    decimal.TryParse(reader["TotalConteo"].ToString(), out valorDecimal);
                    Objeto.TotalConteo = valorDecimal;
                    decimal.TryParse(reader["Diferencia"].ToString(), out valorDecimal);
                    Objeto.Diferencia = valorDecimal;
                    Objeto.Resultado = reader["Resultado"].ToString();
                    Objeto.NombreUsuario = reader["Nombre"].ToString();
                    Objeto.Nota = reader["nota"].ToString();
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
        public List<TblCajaCierre> GetByFiltradoFecha(DateTime desde, DateTime hasta)
        {
            try
            {
                TblCajaCierre Objeto;
                var list = new List<TblCajaCierre>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT IdCajaCierre, TblCajaCierre.IdCajaApertura As IdCajaApert, TblCajaCierre.IdUsuario As CodigoUsuario,TblCajaCierre.Codigo, TblCajaCierre.Fecha, TblCajaCierre.Caja, TblCajaApertura.Monto As MontoApertura, TotalEntrada, TotalSalida, TotalConteo, Diferencia, Resultado, TblUsuario.Nombre, TblCajaCierre.Nota As nota FROM TblCajaCierre JOIN TblUsuario on TblUsuario.IdUsuario = TblCajaCierre.IdUsuario");
                builder.Append(" JOIN TblCajaApertura on TblCajaApertura.IdCajaApertura = TblCajaCierre.IdCajaApertura");
                builder.Append(" WHERE TblCajaCierre.Fecha >='" + ClassFecha.GetFecha(desde, 1) + "' AND TblCajaCierre.Fecha <= '" + ClassFecha.GetFecha(hasta, 2) + "'");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                DateTime fecha = DateTime.Now;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCajaCierre();
                    int.TryParse(reader["IdCajaCierre"].ToString(), out Id);
                    Objeto.IdCajaCierre = Id;
                    int.TryParse(reader["IdCajaApert"].ToString(), out Id);
                    Objeto.IdCajaApertura = Id;
                    int.TryParse(reader["CodigoUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.Caja = reader["Caja"].ToString();
                    decimal.TryParse(reader["TotalEntrada"].ToString(), out valorDecimal);
                    Objeto.TotalEntrada = valorDecimal;
                    decimal.TryParse(reader["TotalSalida"].ToString(), out valorDecimal);
                    Objeto.TotalSalida = valorDecimal;
                    decimal.TryParse(reader["TotalConteo"].ToString(), out valorDecimal);
                    Objeto.TotalConteo = valorDecimal;
                    decimal.TryParse(reader["Diferencia"].ToString(), out valorDecimal);
                    Objeto.Diferencia = valorDecimal;
                    decimal.TryParse(reader["MontoApertura"].ToString(), out valorDecimal);
                    Objeto.MontoApertura = valorDecimal;
                    Objeto.Resultado = reader["Resultado"].ToString();
                    Objeto.NombreUsuario = reader["Nombre"].ToString();
                    Objeto.Nota = reader["nota"].ToString();

                    //decimal.TryParse(reader["Ventas"].ToString(), out valorDecimal);
                    //Objeto.Ventas = valorDecimal;
                    //decimal.TryParse(reader["CobrosCxC"].ToString(), out valorDecimal);
                    //Objeto.CobrosCxC = valorDecimal;
                    //decimal.TryParse(reader["Compras"].ToString(), out valorDecimal);
                    //Objeto.Compras = valorDecimal;
                    //decimal.TryParse(reader["Gastos"].ToString(), out valorDecimal);
                    //Objeto.Gastos = valorDecimal;
                    //decimal.TryParse(reader["DevVentas"].ToString(), out valorDecimal);
                    //Objeto.DevVentas = valorDecimal;
                    //decimal.TryParse(reader["PagosCxP"].ToString(), out valorDecimal);
                    //Objeto.PagosCxP = valorDecimal;
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
