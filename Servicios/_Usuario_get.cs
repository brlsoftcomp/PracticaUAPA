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
    class _Usuario_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblUsuario GetById(int Id)
        {
            try
            {
                var Objeto = new TblUsuario();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblUsuario WHERE IdUsuario= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Objeto.IdUsuario = Id;
                        Objeto.Nombre = reader["Nombre"].ToString();
                        Objeto.Usuario = reader["Usuario"].ToString();
                        Objeto.Password = reader["Password"].ToString();
                        Objeto.Estado = reader["Estado"].ToString();
                        Objeto.Categoria = reader["Categoria"].ToString();
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
        public List<TblUsuario> GetAll()
        {
            try
            {
                TblUsuario Objeto;
                var list = new List<TblUsuario>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblUsuario WHERE IdUsuario > 1 ORDER BY Nombre");
                dt = Miconexion.BuscarTabla(builder);
                int id = 0;
                foreach (DataRow item in dt.Rows)
                {
                    Objeto = new TblUsuario();
                    int.TryParse(item["IdUsuario"].ToString(), out id);
                    Objeto.IdUsuario = id;
                    Objeto.Nombre = item["Nombre"].ToString();
                    Objeto.Usuario = item["Usuario"].ToString();
                    Objeto.Password = item["Password"].ToString();
                    Objeto.Estado = item["Estado"].ToString();
                    Objeto.Categoria = item["Categoria"].ToString();
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
        public List<TblUsuario> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblUsuario Objeto;
                var list = new List<TblUsuario>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblUsuario WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int id = 0;
                foreach (DataRow item in dt.Rows)
                {
                    Objeto = new TblUsuario();
                    int.TryParse(item["IdUsuario"].ToString(), out id);
                    Objeto.IdUsuario = id;
                    Objeto.Nombre = item["Nombre"].ToString();
                    Objeto.Usuario = item["Usuario"].ToString();
                    Objeto.Password = item["Password"].ToString();
                    Objeto.Estado = item["Estado"].ToString();
                    Objeto.Categoria = item["Categoria"].ToString();
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
