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
    class _Empresa_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblEmpresa GetById(int Id)
        {
            try
            {
                var Objeto = new TblEmpresa();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblEmpresa WHERE IdEmpresa= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdEmpresa"].ToString(), out Id);
                        Objeto.IdEmpresa = Id;
                        Objeto.RNC = reader["RNC"].ToString();
                        Objeto.Nombre = reader["Nombre"].ToString();
                        Objeto.Actividad = reader["Actividad"].ToString();
                        Objeto.Direccion = reader["Direccion"].ToString();
                        Objeto.Telefono1 = reader["Telefono1"].ToString();
                        Objeto.Telefono2 = reader["Telefono2"].ToString();
                        Objeto.Logo = reader["Logo"].ToString();
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
        public List<TblEmpresa> GetAll()
        {
            try
            {
                TblEmpresa Objeto;
                var list = new List<TblEmpresa>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblEmpresa ORDER BY IdEmpresa");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblEmpresa();
                    int.TryParse(reader["IdEmpresa"].ToString(), out Id);
                    Objeto.IdEmpresa = Id;
                    Objeto.RNC = reader["RNC"].ToString();
                    Objeto.Nombre = reader["Nombre"].ToString();
                    Objeto.Actividad = reader["Actividad"].ToString();
                    Objeto.Direccion = reader["Direccion"].ToString();
                    Objeto.Telefono1 = reader["Telefono1"].ToString();
                    Objeto.Telefono2 = reader["Telefono2"].ToString();
                    Objeto.Logo = reader["Logo"].ToString();
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
        public List<TblEmpresa> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblEmpresa Objeto;
                var list = new List<TblEmpresa>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblEmpresa WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblEmpresa();
                    int.TryParse(reader["IdEmpresa"].ToString(), out Id);
                    Objeto.IdEmpresa = Id;
                    Objeto.RNC = reader["RNC"].ToString();
                    Objeto.Nombre = reader["Nombre"].ToString();
                    Objeto.Actividad = reader["Actividad"].ToString();
                    Objeto.Direccion = reader["Direccion"].ToString();
                    Objeto.Telefono1 = reader["Telefono1"].ToString();
                    Objeto.Telefono2 = reader["Telefono2"].ToString();
                    Objeto.Logo = reader["Logo"].ToString();
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
