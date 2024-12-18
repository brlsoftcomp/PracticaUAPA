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
    class _CxCAjuste_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCxCAjuste GetById(int Id)
        {
            try
            {
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                var Objeto = new TblCxCAjuste();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblCxCAjuste WHERE IdCxCAjuste= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCxCAjuste"].ToString(), out Id);
                        Objeto.IdCxCAjuste = Id;
                        int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                        Objeto.IdCxC = valorInt;
                        int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                        Objeto.IdUsuario = valorInt;
                        DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                        Objeto.Fecha = Fecha;
                        decimal.TryParse(reader["MontoAjuste"].ToString(), out valorDecimal);
                        Objeto.MontoAjuste = valorDecimal;
                        decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                        Objeto.Monto = valorDecimal;
                        decimal.TryParse(reader["Balance"].ToString(), out valorDecimal);
                        Objeto.Balance = valorDecimal;
                        Objeto.Concepto = reader["Concepto"].ToString();
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
        public List<TblCxCAjuste> GetAll(int IdCxC)
        {
            try
            {
                TblCxCAjuste Objeto;
                var list = new List<TblCxCAjuste>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT IdCxCAjuste, IdCxC, TblCxCAjuste.IdUsuario, Fecha, TblUsuario.Nombre As NombreUsaurio, Abono, Monto, Balance, Nota FROM TblCxCAjuste JOIN TblUsuario on TblUsuario.IdUsuario = TblCxCAjuste.IdUsuario WHERE IdCxC = '" + IdCxC + "'ORDER BY Fecha");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCxCAjuste();
                    int.TryParse(reader["IdCxCAjuste"].ToString(), out Id);
                    Objeto.IdCxCAjuste = Id;
                    int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                    Objeto.IdCxC = valorInt;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    Objeto.NombreUsuario = reader["NombreUsaurio"].ToString();
                    decimal.TryParse(reader["MontoAjuste"].ToString(), out valorDecimal);
                    Objeto.MontoAjuste = valorDecimal;
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    decimal.TryParse(reader["Balance"].ToString(), out valorDecimal);
                    Objeto.Balance = valorDecimal;
                    Objeto.Concepto = reader["Concepto"].ToString();
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
        public List<TblCxCAjuste> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblCxCAjuste Objeto;
                var list = new List<TblCxCAjuste>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCxCAjuste WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCxCAjuste();
                    int.TryParse(reader["IdCxCAjuste"].ToString(), out Id);
                    Objeto.IdCxCAjuste = Id;
                    int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                    Objeto.IdCxC = valorInt;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    decimal.TryParse(reader["MontoAjuste"].ToString(), out valorDecimal);
                    Objeto.MontoAjuste = valorDecimal;
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    decimal.TryParse(reader["Balance"].ToString(), out valorDecimal);
                    Objeto.Balance = valorDecimal;
                    Objeto.Concepto = reader["Concepto"].ToString();
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
        public List<TblCxCAjuste> GetByFiltrado(string texto)
        {
            try
            {
                TblCxCAjuste Objeto;
                var list = new List<TblCxCAjuste>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCxCAjuste WHERE Fecha LIKE '" + texto + "' + '%' or IdCxCAjuste LIKE '" + texto + "' + '%'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valorDecimal = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCxCAjuste();
                    int.TryParse(reader["IdCxCAjuste"].ToString(), out Id);
                    Objeto.IdCxCAjuste = Id;
                    int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                    Objeto.IdCxC = valorInt;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
                    decimal.TryParse(reader["MontoAjuste"].ToString(), out valorDecimal);
                    Objeto.MontoAjuste = valorDecimal;
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
                    decimal.TryParse(reader["Balance"].ToString(), out valorDecimal);
                    Objeto.Balance = valorDecimal;
                    Objeto.Concepto = reader["Concepto"].ToString();
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
