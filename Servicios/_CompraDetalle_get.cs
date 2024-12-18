using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class _CompraDetalle_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCompraDetalle GetById(int Id)
        {
            try
            {
                decimal valorDecimal = 0;
                var Objeto = new TblCompraDetalle();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblCompraDetalle WHERE IdCompraDetalle= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCompraDetalle"].ToString(), out Id);
                        Objeto.IdCompraDetalle = Id;
                        int.TryParse(reader["IdCompra"].ToString(), out Id);
                        Objeto.IdCompra = Id;
                        int.TryParse(reader["IdProducto"].ToString(), out Id);
                        Objeto.IdProducto = Id;
                        int.TryParse(reader["Cantidad"].ToString(), out Id);
                        Objeto.Cantidad = Id;
                        decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                        Objeto.Itbis = valorDecimal;
                        decimal.TryParse(reader["Precio"].ToString(), out valorDecimal);
                        Objeto.Precio = valorDecimal;
                        decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                        Objeto.Monto = valorDecimal;
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

        #region GetByIdCompra
        public List<TblCompraDetalle> GetByIdCompra(int Id)
        {
            try
            {
                decimal valorDecimal = 0;
                TblCompraDetalle Objeto;
                var list = new List<TblCompraDetalle>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCompraDetalle WHERE IdCompra = '" + Id + "'");
                dt = Miconexion.BuscarTabla(builder);
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCompraDetalle();
                    int.TryParse(reader["IdCompraDetalle"].ToString(), out Id);
                    Objeto.IdCompraDetalle = Id;
                    int.TryParse(reader["IdCompra"].ToString(), out Id);
                    Objeto.IdCompra = Id;
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    int.TryParse(reader["Cantidad"].ToString(), out Id);
                    Objeto.Cantidad = Id;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    decimal.TryParse(reader["Precio"].ToString(), out valorDecimal);
                    Objeto.Precio = valorDecimal;
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
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
        public List<TblCompraDetalle> GetAll()
        {
            try
            {
                decimal valorDecimal = 0;
                TblCompraDetalle Objeto;
                var list = new List<TblCompraDetalle>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCompraDetalle ORDER BY IdCompraDetalle");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCompraDetalle();
                    int.TryParse(reader["IdCompraDetalle"].ToString(), out Id);
                    Objeto.IdCompraDetalle = Id;
                    int.TryParse(reader["IdCompra"].ToString(), out Id);
                    Objeto.IdCompra = Id;
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    int.TryParse(reader["Cantidad"].ToString(), out Id);
                    Objeto.Cantidad = Id;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    decimal.TryParse(reader["Precio"].ToString(), out valorDecimal);
                    Objeto.Precio = valorDecimal;
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
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
        public List<TblCompraDetalle> GetBy(string Campo, string Parametro)
        {
            try
            {
                decimal valorDecimal = 0;
                TblCompraDetalle Objeto;
                var list = new List<TblCompraDetalle>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCompraDetalle WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCompraDetalle();
                    int.TryParse(reader["IdCompraDetalle"].ToString(), out Id);
                    Objeto.IdCompraDetalle = Id;
                    int.TryParse(reader["IdCompra"].ToString(), out Id);
                    Objeto.IdCompra = Id;
                    int.TryParse(reader["IdProducto"].ToString(), out Id);
                    Objeto.IdProducto = Id;
                    int.TryParse(reader["Cantidad"].ToString(), out Id);
                    Objeto.Cantidad = Id;
                    decimal.TryParse(reader["Itbis"].ToString(), out valorDecimal);
                    Objeto.Itbis = valorDecimal;
                    decimal.TryParse(reader["Precio"].ToString(), out valorDecimal);
                    Objeto.Precio = valorDecimal;
                    decimal.TryParse(reader["Monto"].ToString(), out valorDecimal);
                    Objeto.Monto = valorDecimal;
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
