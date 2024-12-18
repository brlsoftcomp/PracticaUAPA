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
    class _Proveedor_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblProveedor GetById(int Id)
        {
            try
            {
                var Objeto = new TblProveedor();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblProveedor WHERE IdProveedor= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdProveedor"].ToString(), out Id);
                        Objeto.IdProveedor = Id;
                        int.TryParse(reader["Codigo"].ToString(), out Id);
                        Objeto.Codigo = Id;
                        Objeto.RNC = reader["RNC"].ToString();
                        Objeto.Nombre = reader["Nombre"].ToString();
                        Objeto.Direccion = reader["Direccion"].ToString();
                        Objeto.Telefono = reader["Telefono"].ToString();
                        Objeto.Telefono2 = reader["Telefono2"].ToString();
                        Objeto.Correo = reader["Correo"].ToString();
                        Objeto.ItbisIncluido = reader["ItbisIncluido"].ToString();                 
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
        public List<TblProveedor> GetAll()
        {
            try
            {
                TblProveedor Objeto;
                var list = new List<TblProveedor>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblProveedor ORDER BY Nombre");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblProveedor();
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    Objeto.RNC = reader["RNC"].ToString();
                    Objeto.Nombre = reader["Nombre"].ToString();
                    Objeto.Direccion = reader["Direccion"].ToString();
                    Objeto.Telefono = reader["Telefono"].ToString();
                    Objeto.Telefono2 = reader["Telefono2"].ToString();
                    Objeto.Correo = reader["Correo"].ToString();
                    Objeto.ItbisIncluido = reader["ItbisIncluido"].ToString();
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
        public List<TblProveedor> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblProveedor Objeto;
                var list = new List<TblProveedor>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblProveedor WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblProveedor();
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    Objeto.RNC = reader["RNC"].ToString();
                    Objeto.Nombre = reader["Nombre"].ToString();
                    Objeto.Direccion = reader["Direccion"].ToString();
                    Objeto.Telefono = reader["Telefono"].ToString();
                    Objeto.Telefono2 = reader["Telefono2"].ToString();
                    Objeto.Correo = reader["Correo"].ToString();
                    Objeto.ItbisIncluido = reader["ItbisIncluido"].ToString();
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
        public List<TblProveedor> GetByFiltrado(string texto)
        {
            try
            {
                TblProveedor Objeto;
                var list = new List<TblProveedor>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblProveedor WHERE Nombre LIKE '" + texto + "' + '%' or IdProveedor LIKE '" + texto + "' + '%'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblProveedor();
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    Objeto.RNC = reader["RNC"].ToString();
                    Objeto.Nombre = reader["Nombre"].ToString();
                    Objeto.Direccion = reader["Direccion"].ToString();
                    Objeto.Telefono = reader["Telefono"].ToString();
                    Objeto.Telefono2 = reader["Telefono2"].ToString();
                    Objeto.Correo = reader["Correo"].ToString();
                    Objeto.ItbisIncluido = reader["ItbisIncluido"].ToString();
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
