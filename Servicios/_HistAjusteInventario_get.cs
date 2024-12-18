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
    class _HistAjusteInventario_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblHistAjusteInventario GetById(int Id)
        {
            try
            {
                int valorInt = 0;
                var Objeto = new TblHistAjusteInventario();
                SqlDataReader reader;
                DateTime fecha;
                reader = Miconexion.Buscar("SELECT * FROM TblHistAjusteInventario WHERE IdHistAjustInventario= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Objeto.IdHistAjustInventario = Id;
                        int.TryParse(reader["Codigo"].ToString(), out valorInt);
                        Objeto.Codigo = valorInt;
                        DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                        int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                        Objeto.IdUsuario = valorInt;
                        Objeto.Nota = reader["Nota"].ToString();
                        Objeto.Fecha = fecha;
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

        #region GetByIdFK
        public TblHistAjusteInventario GetByIdFK(int Id)
        {
            try
            {
                int valorInt = 0;
                var Objeto = new TblHistAjusteInventario();
                SqlDataReader reader;
                DateTime fecha;
                reader = Miconexion.Buscar("SELECT * FROM TblHistAjusteInventario JOIN TblProductos WHERE FkeyProducto = '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Objeto.IdHistAjustInventario = Id;
                        int.TryParse(reader["Codigo"].ToString(), out valorInt);
                        Objeto.Codigo = valorInt;
                        DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                        int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                        Objeto.IdUsuario = valorInt;
                        Objeto.Nota = reader["Nota"].ToString();
                        Objeto.Fecha = fecha;
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
        public List<TblHistAjusteInventario> GetAll()
        {
            try
            {
                int valorInt = 0;
                TblHistAjusteInventario Objeto;
                var list = new List<TblHistAjusteInventario>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblHistAjusteInventario ORDER BY Nombre");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblHistAjusteInventario();
                    Objeto.IdHistAjustInventario = Id;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    Objeto.Nota = reader["Nota"].ToString();
                    Objeto.Fecha = fecha;
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
        public List<TblHistAjusteInventario> GetBy(string Campo, string Parametro)
        {
            try
            {
                int valorInt = 0;
                TblHistAjusteInventario Objeto;
                var list = new List<TblHistAjusteInventario>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblHistAjusteInventario WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblHistAjusteInventario();
                    Objeto.IdHistAjustInventario = Id;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    Objeto.Nota = reader["Nota"].ToString();
                    Objeto.Fecha = fecha;
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
        public List<TblHistAjusteInventario> GetByFiltrado(string texto)
        {
            try
            {
                int valorInt = 0;
                TblHistAjusteInventario Objeto;
                var list = new List<TblHistAjusteInventario>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT IdHistAjustInventario, Codigo, Fecha, TblHistAjusteInventario.IdUsuario, TblUsuario.Nombre, Nota FROM TblHistAjusteInventario JOIN TblUsuario on TblUsuario.IdUsuario =  TblHistAjusteInventario.IdUsuario WHERE Usuario LIKE '" + texto + "' + '%' or Codigo LIKE '" + texto + "' + '%'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblHistAjusteInventario();
                    int.TryParse(reader["IdHistAjustInventario"].ToString(), out Id);
                    Objeto.IdHistAjustInventario = Id;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    Objeto.NombreUsuario = reader["Nombre"].ToString();
                    Objeto.Nota = reader["Nota"].ToString();
                    Objeto.Fecha = fecha;
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
        public List<TblHistAjusteInventario> GetByFiltradoFecha(DateTime desde, DateTime hasta)
        {
            try
            {
                int valorInt = 0;
                TblHistAjusteInventario Objeto;
                var list = new List<TblHistAjusteInventario>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT IdHistAjustInventario, Codigo, Fecha, TblHistAjusteInventario.IdUsuario, TblUsuario.Nombre, Nota FROM TblHistAjusteInventario JOIN TblUsuario on TblUsuario.IdUsuario =  TblHistAjusteInventario.IdUsuario WHERE Fecha >='"+ClassFecha.GetFecha(desde, 1)+"' AND Fecha <= '"+ClassFecha.GetFecha(hasta, 2)+"'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblHistAjusteInventario();
                    int.TryParse(reader["IdHistAjustInventario"].ToString(), out Id);
                    Objeto.IdHistAjustInventario = Id;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    Objeto.NombreUsuario = reader["Nombre"].ToString();
                    Objeto.Nota = reader["Nota"].ToString();
                    Objeto.Fecha = fecha;
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
