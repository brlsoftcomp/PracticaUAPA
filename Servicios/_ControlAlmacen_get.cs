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
    class _ControlAlmacen_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblControlAlmacen GetById(int Id)
        {
            try
            {
                var Objeto = new TblControlAlmacen();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblControlAlmacen WHERE IdControlAlmacen= '" + Id + "'");
                DateTime Fecha;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdControlAlmacen"].ToString(), out Id);
                        Objeto.IdControlAlmacen = Id;
                        int.TryParse(reader["IdUsuario"].ToString(), out Id);
                        Objeto.IdUsuario = Id;
                        int.TryParse(reader["IdRegistro"].ToString(), out Id);
                        Objeto.IdRegistro = Id;
                        int.TryParse(reader["IdProducto"].ToString(), out Id);
                        Objeto.IdProducto = Id;
                        Objeto.Descripcion = reader["Descripcion"].ToString();
                        Objeto.Modulo = reader["Modulo"].ToString();
                        Objeto.Movimiento = reader["Movimiento"].ToString();
                        int.TryParse(reader["Cantidad"].ToString(), out Id);
                        Objeto.Cantidad = Id;
                        DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                        Objeto.Fecha = Fecha;
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
        public List<TblControlAlmacen> GetAll()
        {
            try
            {
                TblControlAlmacen Objeto;
                var list = new List<TblControlAlmacen>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblControlAlmacen ORDER BY Fecha DESC");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblControlAlmacen();
                    int.TryParse(reader["IdControlAlmacen"].ToString(), out Id);
                    Objeto.IdControlAlmacen = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdRegistro"].ToString(), out Id);
                    Objeto.IdRegistro = Id;
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    Objeto.Descripcion = reader["Descripcion"].ToString();
                    Objeto.Modulo = reader["Modulo"].ToString();
                    Objeto.Movimiento = reader["Movimiento"].ToString();
                    int.TryParse(reader["Cantidad"].ToString(), out Id);
                    Objeto.Cantidad = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
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
        public List<TblControlAlmacen> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblControlAlmacen Objeto;
                var list = new List<TblControlAlmacen>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblControlAlmacen WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblControlAlmacen();
                    int.TryParse(reader["IdControlAlmacen"].ToString(), out Id);
                    Objeto.IdControlAlmacen = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdRegistro"].ToString(), out Id);
                    Objeto.IdRegistro = Id;
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    Objeto.Descripcion = reader["Descripcion"].ToString();
                    Objeto.Modulo = reader["Modulo"].ToString();
                    Objeto.Movimiento = reader["Movimiento"].ToString();
                    int.TryParse(reader["Cantidad"].ToString(), out Id);
                    Objeto.Cantidad = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
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
        public List<TblControlAlmacen> GetByFiltrado(string texto, string TipoMov)
        {
            try
            {
                TblControlAlmacen Objeto;
                var list = new List<TblControlAlmacen>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                if (TipoMov != "TODOS")
                {
                    builder.Append(string.Format("SELECT * FROM TblControlAlmacen WHERE IdProducto LIKE '" + texto + "' + '%' or Descripcion LIKE '" + texto + "' + '%' or TipoMov LIKE '" + TipoMov + "' + '%'"));
                }
                else
                {
                    builder.Append(string.Format("SELECT * FROM TblControlAlmacen WHERE IdProducto LIKE '" + texto + "' + '%' or Descripcion LIKE '" + texto + "' + '%'"));
                }
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblControlAlmacen();
                    int.TryParse(reader["IdControlAlmacen"].ToString(), out Id);
                    Objeto.IdControlAlmacen = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdRegistro"].ToString(), out Id);
                    Objeto.IdRegistro = Id;
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    Objeto.Descripcion = reader["Descripcion"].ToString();
                    Objeto.Modulo = reader["Modulo"].ToString();
                    Objeto.Movimiento = reader["Movimiento"].ToString();
                    int.TryParse(reader["Cantidad"].ToString(), out Id);
                    Objeto.Cantidad = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
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
        public List<TblControlAlmacen> GetByFiltradoFecha(DateTime desde, DateTime hasta)
        {
            try
            {
                TblControlAlmacen Objeto;
                var list = new List<TblControlAlmacen>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblControlAlmacen WHERE Fecha >='" + ClassFecha.GetFecha(desde, 1) + "' AND Fecha <= '" + ClassFecha.GetFecha(hasta, 2) + "'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                DateTime Fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblControlAlmacen();
                    int.TryParse(reader["IdControlAlmacen"].ToString(), out Id);
                    Objeto.IdControlAlmacen = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out Id);
                    Objeto.IdUsuario = Id;
                    int.TryParse(reader["IdRegistro"].ToString(), out Id);
                    Objeto.IdRegistro = Id;
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    Objeto.Descripcion = reader["Descripcion"].ToString();
                    Objeto.Modulo = reader["Modulo"].ToString();
                    Objeto.Movimiento = reader["Movimiento"].ToString();
                    int.TryParse(reader["Cantidad"].ToString(), out Id);
                    Objeto.Cantidad = Id;
                    DateTime.TryParse(reader["Fecha"].ToString(), out Fecha);
                    Objeto.Fecha = Fecha;
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
