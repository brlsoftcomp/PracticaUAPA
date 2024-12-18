using BRL_SVentas.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Servicios
{
    class _Cobro_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCobro GetById(int Id)
        {
            try
            {
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                var Objeto = new TblCobro();           
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblCobro WHERE IdCobro= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCobro"].ToString(), out Id);
                        Objeto.IdCobro = Id;
                        int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                        Objeto.IdCxC = valorInt;
                        int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                        Objeto.IdUsuario = valorInt;
                        int.TryParse(reader["Codigo"].ToString(), out valorInt);
                        Objeto.Codigo = valorInt;
                        DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                        Objeto.Fecha = Fecha;
                        decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                        Objeto.Monto = valorDecimal;
                        decimal.TryParse(reader["Abono"].ToString(), out valorDecimal);
                        Objeto.Abono = valorDecimal;
                        decimal.TryParse(reader["Balance"].ToString(), out valorDecimal);
                        Objeto.Balance = valorDecimal;
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

        #region GetByCodigo
        public TblCobro GetByCodigo(int Id)
        {
            try
            {
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                var Objeto = new TblCobro();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblCobro WHERE Codigo= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCobro"].ToString(), out Id);
                        Objeto.IdCobro = Id;
                        int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                        Objeto.IdCxC = valorInt;
                        int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                        Objeto.IdUsuario = valorInt;
                        int.TryParse(reader["Codigo"].ToString(), out valorInt);
                        Objeto.Codigo = valorInt;
                        DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                        Objeto.Fecha = Fecha;
                        decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                        Objeto.Monto = valorDecimal;
                        decimal.TryParse(reader["Abono"].ToString(), out valorDecimal);
                        Objeto.Abono = valorDecimal;
                        decimal.TryParse(reader["Balance"].ToString(), out valorDecimal);
                        Objeto.Balance = valorDecimal;
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

        #region GetByCxC
        public decimal GetByCxC(int Id)
        {
            try
            {
                decimal valorDecimal = 0;
                var Objeto = new TblCobro();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT SUM(Abono) as Abono FROM TblCobro WHERE IdCxC= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        decimal.TryParse(reader["Abono"].ToString(), out valorDecimal);
                        Objeto.Abono = valorDecimal;
                    }
                }
                else
                {
                    Objeto.Abono = 0;
                }
                Miconexion.Cerrar();
                return Objeto.Abono;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetAll
        public List<TblCobro> GetAll(int IdCxC)
        {
            try
            {
                TblCobro Objeto;
                var list = new List<TblCobro>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT IdCobro, IdCxC, TblCobro.IdUsuario, TblCobro.Codigo, Fecha, TblUsuario.Nombre As NombreUsaurio, Abono, Monto, Balance, Nota FROM TblCobro JOIN TblUsuario on TblUsuario.IdUsuario = TblCobro.IdUsuario WHERE IdCxC = '" + IdCxC + "'ORDER BY Fecha");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCobro();
                    int.TryParse(reader["IdCobro"].ToString(), out Id);
                    Objeto.IdCobro = Id;
                    int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                    Objeto.IdCxC = valorInt;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    Objeto.NombreUsuario = reader["NombreUsaurio"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    decimal.TryParse(reader["Abono"].ToString(), out valorDecimal);
                    Objeto.Abono = valorDecimal;
                    decimal.TryParse(reader["Balance"].ToString(), out valorDecimal);
                    Objeto.Balance = valorDecimal;
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
        public List<TblCobro> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblCobro Objeto;
                var list = new List<TblCobro>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCobro WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCobro();
                    int.TryParse(reader["IdCobro"].ToString(), out Id);
                    Objeto.IdCobro = Id;
                    int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                    Objeto.IdCxC = valorInt;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    decimal.TryParse(reader["Abono"].ToString(), out valorDecimal);
                    Objeto.Abono = valorDecimal;
                    decimal.TryParse(reader["Balance"].ToString(), out valorDecimal);
                    Objeto.Balance = valorDecimal;
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
        public List<TblCobro> GetByFiltrado(string texto)
        {
            try
            {
                TblCobro Objeto;
                var list = new List<TblCobro>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCobro JOIN TblCxC ON TblCxC.IdCxC = TblCobro.IdCxC WHERE TblCxC.Nombre LIKE '" + texto + "' + '%' or IdCobro LIKE '" + texto + "' + '%'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCobro();
                    int.TryParse(reader["IdCobro"].ToString(), out Id);
                    Objeto.IdCobro = Id;
                    int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                    Objeto.IdCxC = valorInt;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    decimal.TryParse(reader["Abono"].ToString(), out valorDecimal);
                    Objeto.Abono = valorDecimal;
                    decimal.TryParse(reader["Balance"].ToString(), out valorDecimal);
                    Objeto.Balance = valorDecimal;
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
