using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRL_SVentas.Model;

namespace BRL_SVentas
{
    class _Producto_get
    {

        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblProducto GetById(int Id)
        {
            try
            {
                var Objeto = new TblProducto();
                SqlDataReader reader;
                decimal valorDecimal = 0;
                int valorint = 0;
                reader = Miconexion.Buscar("SELECT * FROM TblProducto WHERE IdProducto= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Objeto.IdProducto = Id;
                        int.TryParse(reader["IdProveedor"].ToString(), out valorint);
                        Objeto.IdProveedor = valorint;
                        int.TryParse(reader["Codigo"].ToString(), out valorint);
                        Objeto.Codigo = valorint;
                        Objeto.Nombre = reader["Nombre"].ToString();
                        decimal.TryParse(reader["PrecioCompra"].ToString(), out valorDecimal);
                        Objeto.PrecioCompra = valorDecimal;
                        decimal.TryParse(reader["PrecioVenta"].ToString(), out valorDecimal);
                        Objeto.PrecioVenta = valorDecimal;
                        decimal.TryParse(reader["PrecioMinimo"].ToString(), out valorDecimal);
                        Objeto.PrecioMinimo = valorDecimal;
                        decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                        Objeto.Itbis = valorDecimal;
                        int.TryParse(reader["CantidadExistente"].ToString(), out valorint);
                        Objeto.CantidadExistente = valorint;
                        int.TryParse(reader["Tope"].ToString(), out valorint);
                        Objeto.Tope = valorint;
                        Objeto.Estado = reader["Estado"].ToString();
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

        #region GetByCodigo
        public TblProducto GetByCodigo(int Id)
        {
            try
            {
                var Objeto = new TblProducto();
                SqlDataReader reader;
                decimal valorDecimal = 0;
                int valorint = 0;
                reader = Miconexion.Buscar("SELECT * FROM TblProducto WHERE Codigo= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdProducto"].ToString(), out valorint);
                        Objeto.IdProducto = valorint;
                        int.TryParse(reader["IdProveedor"].ToString(), out valorint);
                        Objeto.IdProveedor = valorint;
                        int.TryParse(reader["Codigo"].ToString(), out valorint);
                        Objeto.Codigo = valorint;
                        Objeto.Nombre = reader["Nombre"].ToString();
                        decimal.TryParse(reader["PrecioCompra"].ToString(), out valorDecimal);
                        Objeto.PrecioCompra = valorDecimal;
                        decimal.TryParse(reader["PrecioVenta"].ToString(), out valorDecimal);
                        Objeto.PrecioVenta = valorDecimal;
                        decimal.TryParse(reader["PrecioMinimo"].ToString(), out valorDecimal);
                        Objeto.PrecioMinimo = valorDecimal;
                        decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                        Objeto.Itbis = valorDecimal;
                        int.TryParse(reader["CantidadExistente"].ToString(), out valorint);
                        Objeto.CantidadExistente = valorint;
                        int.TryParse(reader["Tope"].ToString(), out valorint);
                        Objeto.Tope = valorint;
                        Objeto.Estado = reader["Estado"].ToString();
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
        public List<TblProducto> GetAll()
        {
            try
            {
                TblProducto Objeto;
                var list = new List<TblProducto>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblProducto ORDER BY Nombre");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                int valorInt = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblProducto();
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    Objeto.Nombre = reader["Nombre"].ToString();
                    decimal.TryParse(reader["PrecioCompra"].ToString(), out valorDecimal);
                    Objeto.PrecioCompra = valorDecimal;
                    decimal.TryParse(reader["PrecioVenta"].ToString(), out valorDecimal);
                    Objeto.PrecioVenta = valorDecimal;
                    decimal.TryParse(reader["PrecioMinimo"].ToString(), out valorDecimal);
                    Objeto.PrecioMinimo = valorDecimal;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    int.TryParse(reader["CantidadExistente"].ToString(), out valorInt);
                    Objeto.CantidadExistente = valorInt;
                    int.TryParse(reader["Tope"].ToString(), out valorInt);
                    Objeto.Tope = valorInt;
                    Objeto.Estado = reader["Estado"].ToString();
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
        public List<TblProducto> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblProducto Objeto;
                var list = new List<TblProducto>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblProducto WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                int valorInt = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblProducto();
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    Objeto.Nombre = reader["Nombre"].ToString();
                    decimal.TryParse(reader["PrecioCompra"].ToString(), out valorDecimal);
                    Objeto.PrecioCompra = valorDecimal;
                    decimal.TryParse(reader["PrecioVenta"].ToString(), out valorDecimal);
                    Objeto.PrecioVenta = valorDecimal;
                    decimal.TryParse(reader["PrecioMinimo"].ToString(), out valorDecimal);
                    Objeto.PrecioMinimo = valorDecimal;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    int.TryParse(reader["CantidadExistente"].ToString(), out valorInt);
                    Objeto.CantidadExistente = valorInt;
                    int.TryParse(reader["Tope"].ToString(), out valorInt);
                    Objeto.Tope = valorInt;
                    Objeto.Estado = reader["Estado"].ToString();
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
        public List<TblProducto> GetByFiltrado(string texto)
        {
            try
            {
                TblProducto Objeto;
                var list = new List<TblProducto>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT IdProducto, IdProveedor, Codigo, Nombre, PrecioVenta, PrecioMinimo, CantidadExistente FROM TblProducto WHERE Nombre LIKE '" + texto+ "' + '%' or Codigo LIKE '" + texto+"' + '%'"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                int valorInt = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblProducto();
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["Codigo"].ToString(), out Id);
                    Objeto.Codigo = Id;
                    Objeto.Nombre = reader["Nombre"].ToString();
                    decimal.TryParse(reader["PrecioVenta"].ToString(), out valorDecimal);
                    Objeto.PrecioVenta = valorDecimal;
                    decimal.TryParse(reader["PrecioMinimo"].ToString(), out valorDecimal);
                    Objeto.PrecioMinimo = valorDecimal;
                    int.TryParse(reader["CantidadExistente"].ToString(), out valorInt);
                    Objeto.CantidadExistente = valorInt;
                    int.TryParse(reader["Tope"].ToString(), out valorInt);
                    Objeto.Tope = valorInt;
                    Objeto.Estado = reader["Estado"].ToString();
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
        public List<TblProducto> GetAllByProveedor(int IdProveedor)
        {
            try
            {
                TblProducto Objeto;
                var list = new List<TblProducto>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblProducto WHERE IdProveedor = '" + IdProveedor + "' ORDER BY Nombre");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                int valorInt = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblProducto();
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    Objeto.Nombre = reader["Nombre"].ToString();
                    decimal.TryParse(reader["PrecioCompra"].ToString(), out valorDecimal);
                    Objeto.PrecioCompra = valorDecimal;
                    decimal.TryParse(reader["PrecioVenta"].ToString(), out valorDecimal);
                    Objeto.PrecioVenta = valorDecimal;
                    decimal.TryParse(reader["PrecioMinimo"].ToString(), out valorDecimal);
                    Objeto.PrecioMinimo = valorDecimal;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    int.TryParse(reader["CantidadExistente"].ToString(), out valorInt);
                    Objeto.CantidadExistente = valorInt;
                    int.TryParse(reader["Tope"].ToString(), out valorInt);
                    Objeto.Tope = valorInt;
                    Objeto.Estado = reader["Estado"].ToString();
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

        #region GetAllActivo
        public List<TblProducto> GetAllActivo()
        {
            try
            {
                TblProducto Objeto;
                var list = new List<TblProducto>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblProducto WHERE Estado = 'ACTIVO' ORDER BY Nombre");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                int valorInt = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblProducto();
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    Objeto.Nombre = reader["Nombre"].ToString();
                    decimal.TryParse(reader["PrecioCompra"].ToString(), out valorDecimal);
                    Objeto.PrecioCompra = valorDecimal;
                    decimal.TryParse(reader["PrecioVenta"].ToString(), out valorDecimal);
                    Objeto.PrecioVenta = valorDecimal;
                    decimal.TryParse(reader["PrecioMinimo"].ToString(), out valorDecimal);
                    Objeto.PrecioMinimo = valorDecimal;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    int.TryParse(reader["CantidadExistente"].ToString(), out valorInt);
                    Objeto.CantidadExistente = valorInt;
                    int.TryParse(reader["Tope"].ToString(), out valorInt);
                    Objeto.Tope = valorInt;
                    Objeto.Estado = reader["Estado"].ToString();
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
        #region GetAllActivoByProveedor
        public List<TblProducto> GetAllActivoByProveedor(int IdProveedor)
        {
            try
            {
                TblProducto Objeto;
                var list = new List<TblProducto>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblProducto WHERE IdProveedor = '" + IdProveedor + "' AND Estado = 'ACTIVO' ORDER BY Nombre");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                decimal valorDecimal = 0;
                int valorInt = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblProducto();
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    int.TryParse(reader["IdProveedor"].ToString(), out Id);
                    Objeto.IdProveedor = Id;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    Objeto.Nombre = reader["Nombre"].ToString();
                    decimal.TryParse(reader["PrecioCompra"].ToString(), out valorDecimal);
                    Objeto.PrecioCompra = valorDecimal;
                    decimal.TryParse(reader["PrecioVenta"].ToString(), out valorDecimal);
                    Objeto.PrecioVenta = valorDecimal;
                    decimal.TryParse(reader["PrecioMinimo"].ToString(), out valorDecimal);
                    Objeto.PrecioMinimo = valorDecimal;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    int.TryParse(reader["CantidadExistente"].ToString(), out valorInt);
                    Objeto.CantidadExistente = valorInt;
                    int.TryParse(reader["Tope"].ToString(), out valorInt);
                    Objeto.Tope = valorInt;
                    Objeto.Estado = reader["Estado"].ToString();
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
