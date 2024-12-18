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
    class _ListaRapida_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblListaRapida GetById(int Id)
        {
            try
            {
                var Objeto = new TblListaRapida();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblListaRapida WHERE IdProductoLista= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdProductoLista"].ToString(), out Id);
                        Objeto.IdProductoLista = Id;
                        int.TryParse(reader["IdProducto"].ToString(), out Id);
                        Objeto.IdProducto = Id;
                        Objeto.Descripcion = reader["Descripcion"].ToString();
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
        public List<TblListaRapida> GetAll()
        {
            try
            {
                TblListaRapida Objeto;
                var list = new List<TblListaRapida>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblListaRapida ORDER BY Descripcion");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblListaRapida();
                    int.TryParse(reader["IdProductoLista"].ToString(), out Id);
                    Objeto.IdProductoLista = Id;
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    Objeto.Descripcion = reader["Descripcion"].ToString();
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
        public List<TblListaRapida> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblListaRapida Objeto;
                var list = new List<TblListaRapida>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblListaRapida WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblListaRapida();
                    int.TryParse(reader["IdProductoLista"].ToString(), out Id);
                    Objeto.IdProductoLista = Id;
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    Objeto.Descripcion = reader["Descripcion"].ToString();
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

        #region ValidaTurno
        public bool Validar(int IdProducto)
        {
            try
            {
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM dbo.TblListaRapida ");
                builder.Append("WHERE IdProducto = '" + IdProducto + "'");
                dt = Miconexion.BuscarTabla(builder);
                if (dt.Rows.Count > 0)
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

    }
}
