using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _Cliente_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCliente GetById(int Id)
        {
            try
            {
                var Objeto = new TblCliente();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblCliente WHERE IdCliente= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCliente"].ToString(), out Id);
                        Objeto.IdCliente = Id;
                        int.TryParse(reader["Codigo"].ToString(), out Id);
                        Objeto.Codigo = Id;
                        Objeto.Nombre = reader["Nombre"].ToString();
                        Objeto.Cedula = reader["Cedula"].ToString();
                        Objeto.Direccion = reader["Direccion"].ToString();
                        Objeto.Telefono = reader["Telefono"].ToString();
                        Objeto.Telefono2 = reader["Telefono2"].ToString();
                        Objeto.Tipo = reader["Tipo"].ToString();
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
        public List<TblCliente> GetAll()
        {
            try
            {
                TblCliente Objeto;
                var list = new List<TblCliente>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCliente ORDER BY Nombre");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCliente();
                    int.TryParse(reader["IdCliente"].ToString(), out Id);
                    Objeto.IdCliente = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    Objeto.Nombre = reader["Nombre"].ToString();
                    Objeto.Cedula = reader["Cedula"].ToString();
                    Objeto.Direccion = reader["Direccion"].ToString();
                    Objeto.Telefono = reader["Telefono"].ToString();
                    Objeto.Telefono2 = reader["Telefono2"].ToString();
                    Objeto.Tipo = reader["Tipo"].ToString();
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
        public List<TblCliente> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblCliente Objeto;
                var list = new List<TblCliente>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCliente WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCliente();
                    int.TryParse(reader["IdCliente"].ToString(), out Id);
                    Objeto.IdCliente = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    Objeto.Nombre = reader["Nombre"].ToString();
                    Objeto.Cedula = reader["Cedula"].ToString();
                    Objeto.Direccion = reader["Direccion"].ToString();
                    Objeto.Telefono = reader["Telefono"].ToString();
                    Objeto.Telefono2 = reader["Telefono2"].ToString();
                    Objeto.Tipo = reader["Tipo"].ToString();
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
        public List<TblCliente> GetByFiltrado(string texto)
        {
            try
            {
                TblCliente Objeto;
                var list = new List<TblCliente>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCliente WHERE IdCliente > 1 AND (Nombre LIKE '" + texto + "' + '%' or IdCliente LIKE '" + texto + "' + '%')"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCliente();
                    int.TryParse(reader["IdCliente"].ToString(), out Id);
                    Objeto.IdCliente = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    Objeto.Nombre = reader["Nombre"].ToString();
                    Objeto.Cedula = reader["Cedula"].ToString();
                    Objeto.Direccion = reader["Direccion"].ToString();
                    Objeto.Telefono = reader["Telefono"].ToString();
                    Objeto.Telefono2 = reader["Telefono2"].ToString();
                    Objeto.Tipo = reader["Tipo"].ToString();
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
