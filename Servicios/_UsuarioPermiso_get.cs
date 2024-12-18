using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _UsuarioPermiso_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblUsuarioPermiso GetById(int Id)
        {
            try
            {
                var Objeto = new TblUsuarioPermiso();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblUsuarioPermiso WHERE IdUsuarioPermiso= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdUsuarioPermiso"].ToString(), out Id);
                        Objeto.IdUsuarioPermiso = Id;
                        int.TryParse(reader["IdUsuario"].ToString(), out Id);
                        Objeto.IdUsuario = Id;
                        int.TryParse(reader["IdPermiso"].ToString(), out Id);
                        Objeto.IdPermiso = Id;
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
        public bool Validar(int IdUsuario, int Id)
        {
            try
            {
                var Objeto = new TblUsuarioPermiso();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblUsuarioPermiso WHERE IdUsuario = '" + IdUsuario + "' AND IdPermiso = '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return true;
                    }
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
        public List<TblUsuarioPermiso> GetAll()
        {
            try
            {
                TblUsuarioPermiso Objeto;
                var list = new List<TblUsuarioPermiso>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblUsuarioPermiso ORDER BY IdUsuarioPermiso");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblUsuarioPermiso();
                    int.TryParse(reader["IdUsuarioPermiso"].ToString(), out Id);
                    Objeto.IdUsuarioPermiso = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdPermiso"].ToString(), out Id);
                    Objeto.IdPermiso = Id;
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
        public List<TblUsuarioPermiso> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblUsuarioPermiso Objeto;
                var list = new List<TblUsuarioPermiso>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblUsuarioPermiso WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblUsuarioPermiso();
                    int.TryParse(reader["IdUsuarioPermiso"].ToString(), out Id);
                    Objeto.IdUsuarioPermiso = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdPermiso"].ToString(), out Id);
                    Objeto.IdPermiso = Id;
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
        public List<TblUsuarioPermiso> GetAllbyIdUsuario(int IdUsuario)
        {
            try
            {
                TblUsuarioPermiso Objeto;
                var list = new List<TblUsuarioPermiso>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblUsuarioPermiso WHERE IdUsuario = "+ IdUsuario);
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblUsuarioPermiso();
                    int.TryParse(reader["IdUsuarioPermiso"].ToString(), out Id);
                    Objeto.IdUsuarioPermiso = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdPermiso"].ToString(), out Id);
                    Objeto.IdPermiso = Id;
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
