using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRL_SVentas.Model;

namespace BRL_SVentas.Servicios
{
    class _Factura_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblFactura GetById(int Id)
        {
            try
            {
                var Objeto = new TblFactura();
                SqlDataReader reader;
                DateTime fecha;
                int IdOtros = 0;
                decimal valor = 0;
                reader = Miconexion.Buscar("SELECT * FROM TblFactura WHERE IdFactura = '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Objeto.IdFactura = Id;
                        int.TryParse(reader["IdUsuario"].ToString(), out IdOtros);
                        Objeto.IdUsuario = IdOtros;
                        int.TryParse(reader["IdCliente"].ToString(), out IdOtros);
                        Objeto.IdCliente = IdOtros;
                        int.TryParse(reader["IdCajaApertura"].ToString(), out IdOtros);
                        Objeto.IdCajaApertura = IdOtros;
                        int.TryParse(reader["IdFormaPago"].ToString(), out IdOtros);
                        Objeto.IdFormaPago = IdOtros;
                        int.TryParse(reader["Codigo"].ToString(), out IdOtros);
                        Objeto.Codigo = IdOtros;
                        DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                        Objeto.Fecha = fecha;
                        Objeto.CondicionPago = reader["CondicionPago"].ToString();
                        decimal.TryParse(reader["SubTotal"].ToString(), out valor);
                        Objeto.SubTotal = valor;
                        decimal.TryParse(reader["Itbis"].ToString(), out valor);
                        Objeto.Itbis = valor;
                        decimal.TryParse(reader["Total"].ToString(), out valor);
                        Objeto.Total = valor;
                        Objeto.Nota = reader["Nota"].ToString();
                        Objeto.Estado = reader["Estado"].ToString();
                        decimal.TryParse(reader["TotalGanancia"].ToString(), out valor);
                        Objeto.TotalGanancia = valor;
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
        public List<TblFactura> GetAll()
        {
            try
            {
                TblFactura Objeto;
                var list = new List<TblFactura>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblFactura ORDER BY Fecha");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valor = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblFactura();
                    int.TryParse(reader["IdFactura"].ToString(), out valorInt);
                    Objeto.IdFactura = valorInt;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    int.TryParse(reader["IdCliente"].ToString(), out valorInt);
                    Objeto.IdCliente = valorInt;
                    int.TryParse(reader["IdCajaApertura"].ToString(), out valorInt);
                    Objeto.IdCajaApertura = valorInt;
                    int.TryParse(reader["IdFormaPago"].ToString(), out valorInt);
                    Objeto.IdFormaPago = valorInt;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.CondicionPago = reader["CondicionPago"].ToString();
                    decimal.TryParse(reader["SubTotal"].ToString(), out valor);
                    Objeto.SubTotal = valor;
                    decimal.TryParse(reader["Itbis"].ToString(), out valor);
                    Objeto.Itbis = valor;
                    decimal.TryParse(reader["Total"].ToString(), out valor);
                    Objeto.Total = valor;
                    Objeto.Nota = reader["Nota"].ToString();
                    Objeto.Estado = reader["Estado"].ToString();
                    decimal.TryParse(reader["TotalGanancia"].ToString(), out valor);
                    Objeto.TotalGanancia = valor;
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
        public List<TblFactura> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblFactura Objeto;
                var list = new List<TblFactura>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblFactura WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int IdOtros = 0;
                decimal valor = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblFactura();
                    Objeto.IdFactura = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out IdOtros);
                    Objeto.IdUsuario = IdOtros;
                    int.TryParse(reader["IdCliente"].ToString(), out IdOtros);
                    Objeto.IdCliente = IdOtros;
                    int.TryParse(reader["IdCajaApertura"].ToString(), out IdOtros);
                    Objeto.IdCajaApertura = IdOtros;
                    int.TryParse(reader["IdFormaPago"].ToString(), out IdOtros);
                    Objeto.IdFormaPago = IdOtros;
                    int.TryParse(reader["Codigo"].ToString(), out IdOtros);
                    Objeto.Codigo = IdOtros;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.CondicionPago = reader["CondicionPago"].ToString();
                    decimal.TryParse(reader["SubTotal"].ToString(), out valor);
                    Objeto.SubTotal = valor;
                    decimal.TryParse(reader["Itbis"].ToString(), out valor);
                    Objeto.Itbis = valor;
                    decimal.TryParse(reader["Total"].ToString(), out valor);
                    Objeto.Total = valor;
                    Objeto.Nota = reader["Nota"].ToString();
                    Objeto.Estado = reader["Estado"].ToString();
                    decimal.TryParse(reader["TotalGanancia"].ToString(), out valor);
                    Objeto.TotalGanancia = valor;
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
        public List<TblFactura> GetByFiltrado(string texto)
        {
            try
            {
                TblFactura Objeto;
                var list = new List<TblFactura>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT IdFactura, IdUsuario, TblFactura.IdCliente, TblFactura.IdCajaApertura, TblFactura.IdFormaPago, TblFacturaTblFactura.Codigo, Fecha, CondicionPago, Total, Nota FROM TblFactura WHERE IdFactura LIKE '" + texto + "' + '%' OR NombreCliente LIKE '" + texto + "' + '%' ORDER BY Fecha DESC"));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int IdOtros = 0;
                decimal valor = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblFactura();
                    int.TryParse(reader["IdFactura"].ToString(), out Id);
                    Objeto.IdFactura = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out IdOtros);
                    Objeto.IdUsuario = IdOtros;
                    int.TryParse(reader["IdCliente"].ToString(), out IdOtros);
                    Objeto.IdCliente = IdOtros;
                    int.TryParse(reader["IdCajaApertura"].ToString(), out IdOtros);
                    Objeto.IdCajaApertura = IdOtros;
                    int.TryParse(reader["IdFormaPago"].ToString(), out IdOtros);
                    Objeto.IdFormaPago = IdOtros;
                    int.TryParse(reader["Codigo"].ToString(), out IdOtros);
                    Objeto.Codigo = IdOtros;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.CondicionPago = reader["CondicionPago"].ToString();
                    decimal.TryParse(reader["Total"].ToString(), out valor);
                    Objeto.Total = valor;
                    Objeto.Nota = reader["Nota"].ToString();
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
