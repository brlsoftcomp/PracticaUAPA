using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _ClienteCredito_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblClienteCredito GetById(int Id)
        {
            try
            {
                var Objeto = new TblClienteCredito();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblClienteCredito WHERE IdClienteCredito = '" + Id + "'");
                decimal valorDecimal = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdClienteCredito"].ToString(), out Id);
                        Objeto.IdCliente = Id;
                        int.TryParse(reader["IdCliente"].ToString(), out Id);
                        Objeto.IdCliente = Id;
                        decimal.TryParse(reader["Credito"].ToString(), out valorDecimal);
                        Objeto.Credito = valorDecimal;
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

        #region GetByIdCliente
        public TblClienteCredito GetByIdCliente(int Id)
        {
            try
            {
                var Objeto = new TblClienteCredito();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblClienteCredito WHERE IdCliente = '" + Id + "'");
                decimal valorDecimal = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdClienteCredito"].ToString(), out Id);
                        Objeto.IdClienteCredito = Id;
                        int.TryParse(reader["IdCliente"].ToString(), out Id);
                        Objeto.IdCliente = Id;
                        decimal.TryParse(reader["Credito"].ToString(), out valorDecimal);
                        Objeto.Credito = valorDecimal;
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

        #region Validar
        public bool Validar(int Id)
        {
            try
            {
                var Objeto = new TblClienteCredito();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblClienteCredito WHERE IdCliente = '" + Id + "'");
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetAll
        public List<TblClienteCredito> GetAll()
        {
            try
            {
                TblClienteCredito Objeto;
                var list = new List<TblClienteCredito>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblClienteCredito ORDER BY IdClienteCredito");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblClienteCredito();
                    int.TryParse(reader["IdClienteCredito"].ToString(), out Id);
                    Objeto.IdClienteCredito = Id;
                    int.TryParse(reader["IdCliente"].ToString(), out Id);
                    Objeto.IdCliente = Id;
                    decimal.TryParse(reader["Credito"].ToString(), out valorDecimal);
                    Objeto.Credito = valorDecimal;
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
        public List<TblClienteCredito> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblClienteCredito Objeto;
                var list = new List<TblClienteCredito>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblClienteCredito WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblClienteCredito();
                    int.TryParse(reader["IdClienteCredito"].ToString(), out Id);
                    Objeto.IdClienteCredito = Id;
                    int.TryParse(reader["IdCliente"].ToString(), out Id);
                    Objeto.IdCliente = Id;
                    decimal.TryParse(reader["Credito"].ToString(), out valorDecimal);
                    Objeto.Credito = valorDecimal;
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
