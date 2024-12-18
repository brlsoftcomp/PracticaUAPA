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
    class _CxC_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblCxC GetById(int Id)
        {
            try
            {
                var Objeto = new TblCxC();
                SqlDataReader reader;
                DateTime fecha;
                int valorInt = 0;
                decimal valor = 0;
                reader = Miconexion.Buscar("SELECT * FROM TblCxC WHERE IdCxC = '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Objeto.IdCxC = Id;
                        int.TryParse(reader["Codigo"].ToString(), out valorInt);
                        Objeto.Codigo = valorInt;
                        int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                        Objeto.IdUsuario = valorInt;
                        int.TryParse(reader["IdCliente"].ToString(), out valorInt);
                        Objeto.IdCliente = valorInt;
                        int.TryParse(reader["IdFactura"].ToString(), out valorInt);
                        Objeto.IdFactura = valorInt;
                        DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                        Objeto.Fecha = fecha;
                        Objeto.Concepto = reader["Concepto"].ToString();
                        decimal.TryParse(reader["Monto"].ToString(), out valor);
                        Objeto.Monto = valor;
                        decimal.TryParse(reader["Balance"].ToString(), out valor);
                        Objeto.Balance = valor;
                        Objeto.Estado = reader["Estado"].ToString();
                        Objeto.Nota = reader["Nota"].ToString();
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

        #region GetByIdFactura
        public TblCxC GetByIdFactura(int Id)
        {
            try
            {
                var Objeto = new TblCxC();
                SqlDataReader reader;
                DateTime fecha;
                int valorInt = 0;
                decimal valor = 0;
                reader = Miconexion.Buscar("SELECT * FROM TblCxC WHERE IdFactura = '" + Id + "' AND TblCxC.Estado != 'ANULADA'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                        Objeto.IdCxC = valorInt;
                        int.TryParse(reader["Codigo"].ToString(), out valorInt);
                        Objeto.Codigo = valorInt;
                        int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                        Objeto.IdUsuario = valorInt;
                        int.TryParse(reader["IdCliente"].ToString(), out valorInt);
                        Objeto.IdCliente = valorInt;
                        Objeto.IdFactura = Id;
                        DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                        Objeto.Fecha = fecha;
                        Objeto.Concepto = reader["Concepto"].ToString();
                        decimal.TryParse(reader["Monto"].ToString(), out valor);
                        Objeto.Monto = valor;
                        decimal.TryParse(reader["Balance"].ToString(), out valor);
                        Objeto.Balance = valor;
                        Objeto.Estado = reader["Estado"].ToString();
                        Objeto.Nota = reader["Nota"].ToString();
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

        #region GetByIdCliente
        public List<TblCxC> GetByIdCliente(int Id)
        {
            try
            {
                TblCxC Objeto;
                var list = new List<TblCxC>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCxC WHERE IdCliente = '" + Id + "' AND Estado = 'PENDIENTE'");
                dt = Miconexion.BuscarTabla(builder);
                int valorInt = 0;
                decimal valor = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCxC();
                    int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                    Objeto.IdCxC = valorInt;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    int.TryParse(reader["IdCliente"].ToString(), out valorInt);
                    Objeto.IdCliente = valorInt;
                    int.TryParse(reader["IdFactura"].ToString(), out valorInt);
                    Objeto.IdFactura = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.Concepto = reader["Concepto"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valor);
                    Objeto.Monto = valor;
                    decimal.TryParse(reader["Balance"].ToString(), out valor);
                    Objeto.Balance = valor;
                    Objeto.Estado = reader["Estado"].ToString();
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

        #region GetAll
        public List<TblCxC> GetAll()
        {
            try
            {
                TblCxC Objeto;
                var list = new List<TblCxC>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblCxC ORDER BY Fecha");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valor = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCxC();
                    Objeto.IdCxC = Id;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    int.TryParse(reader["IdCliente"].ToString(), out valorInt);
                    Objeto.IdCliente = valorInt;
                    int.TryParse(reader["IdFactura"].ToString(), out valorInt);
                    Objeto.IdFactura = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.Concepto = reader["Concepto"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valor);
                    Objeto.Monto = valor;
                    decimal.TryParse(reader["Balance"].ToString(), out valor);
                    Objeto.Balance = valor;
                    Objeto.Estado = reader["Estado"].ToString();
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

        #region GetBy
        public List<TblCxC> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblCxC Objeto;
                var list = new List<TblCxC>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblCxC WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valor = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCxC();
                    Objeto.IdCxC = Id;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    int.TryParse(reader["IdCliente"].ToString(), out valorInt);
                    Objeto.IdCliente = valorInt;
                    int.TryParse(reader["IdFactura"].ToString(), out valorInt);
                    Objeto.IdFactura = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.Concepto = reader["Concepto"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valor);
                    Objeto.Monto = valor;
                    decimal.TryParse(reader["Balance"].ToString(), out valor);
                    Objeto.Balance = valor;
                    Objeto.Estado = reader["Estado"].ToString();
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

        #region GetByFiltrado
        public List<TblCxC> GetByFiltrado(string texto, string buscarPor)
        {
            try
            {
                TblCxC Objeto;
                var list = new List<TblCxC>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                if (buscarPor == "CUENTAS PENDIENTES")
                {
                    builder.Append("SELECT IdCxC, TblCxC.Codigo, TblCxC.IdUsuario, TblCxC.IdCliente, TblUsuario.Nombre As NombreUsuario,");
                    builder.Append(" TblCliente.Nombre As NombreCliente, TblCxC.IdFactura, TblCxC.Fecha, Concepto, Monto, Balance,");
                    builder.Append(" TblCxC.Estado, TblCxC.Nota FROM TblCxC JOIN TblCliente on TblCliente.IdCliente = TblCxC.IdCliente");
                    builder.Append(" JOIN TblUsuario on TblUsuario.IdUsuario = TblCxC.IdUsuario WHERE TblCxC.Estado = 'PENDIENTE'");
                    builder.Append(" AND (IdCxC LIKE '" + texto + "' OR TblCxC.IdFactura LIKE '" + texto + "' + '%' OR");
                    builder.Append(" TblCliente.Nombre LIKE '" + texto + "' + '%')");
                }
                else if (buscarPor == "CUENTAS SALDAS")
                {
                    builder.Append("SELECT IdCxC, TblCxC.Codigo, TblCxC.IdUsuario, TblCxC.IdCliente, TblUsuario.Nombre As NombreUsuario,");
                    builder.Append(" TblCliente.Nombre As NombreCliente, TblCxC.IdFactura, TblCxC.Fecha, Concepto, Monto, Balance,");
                    builder.Append(" TblCxC.Estado, TblCxC.Nota FROM TblCxC JOIN TblCliente on TblCliente.IdCliente = TblCxC.IdCliente");
                    builder.Append(" JOIN TblUsuario on TblUsuario.IdUsuario = TblCxC.IdUsuario WHERE TblCxC.Estado = 'SALDA'");
                    builder.Append(" AND (IdCxC LIKE '" + texto + "' OR TblCxC.IdFactura LIKE '" + texto + "' + '%' OR");
                    builder.Append(" TblCliente.Nombre LIKE '" + texto + "' + '%')");                 
                }
                else
                {
                    builder.Append(string.Format("SELECT IdCxC, TblCxC.IdUsuario, TblCxC.IdCliente, TblUsuario.Nombre As NombreUsuario, TblCliente.Nombre As NombreCliente, TblCxC.IdFactura, TblCxC.Fecha, Concepto, Monto, Balance, TblCxC.Estado, TblCxC.Nota FROM TblCxC JOIN TblCliente on TblCliente.IdCliente = TblCxC.IdCliente JOIN TblUsuario on TblUsuario.IdUsuario = TblCxC.IdUsuario WHERE IdCxC LIKE '" + texto + "' or TblCxC.IdFactura LIKE '" + texto + "' + '%' or TblCliente.Nombre LIKE '" + texto + "' + '%'"));
                }
                dt = Miconexion.BuscarTabla(builder);
                int valorInt = 0;
                decimal valor = 0;
                DateTime fecha;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblCxC();
                    int.TryParse(reader["IdCxC"].ToString(), out valorInt);
                    Objeto.IdCxC = valorInt;
                    int.TryParse(reader["Codigo"].ToString(), out valorInt);
                    Objeto.Codigo = valorInt;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    int.TryParse(reader["IdCliente"].ToString(), out valorInt);
                    Objeto.IdCliente = valorInt;
                    int.TryParse(reader["IdFactura"].ToString(), out valorInt);
                    Objeto.IdFactura = valorInt;
                    DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
                    Objeto.Fecha = fecha;
                    Objeto.UsuarioNombre = reader["NombreUsuario"].ToString();
                    Objeto.ClienteNombre = reader["NombreCliente"].ToString();
                    Objeto.Concepto = reader["Concepto"].ToString();
                    decimal.TryParse(reader["Monto"].ToString(), out valor);
                    Objeto.Monto = valor;
                    decimal.TryParse(reader["Balance"].ToString(), out valor);
                    Objeto.Balance = valor;
                    Objeto.Estado = reader["Estado"].ToString();
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

        //#region GetByIdFK
        //public TblFactura GetByIdFK(int Id)
        //{
        //    try
        //    {
        //        var Objeto = new TblFactura();
        //        SqlDataReader reader;
        //        int IdOtros = 0;
        //        float valor = 0;
        //        DateTime fecha;
        //        reader = Miconexion.Buscar("SELECT * FROM TblFactura JOIN TblFacturaDetalle WHERE IdFactura = '" + Id + "'");
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                Objeto.IdFactura = Id;
        //                int.TryParse(reader["IdUsuario"].ToString(), out IdOtros);
        //                Objeto.IdUsuario = IdOtros;
        //                int.TryParse(reader["IdCliente"].ToString(), out IdOtros);
        //                Objeto.IdCliente = IdOtros;
        //                DateTime.TryParse(reader["Fecha"].ToString(), out fecha);
        //                Objeto.Fecha = fecha;
        //                Objeto.NombreCliente = reader["NombreCliente"].ToString();
        //                Objeto.TelefonoCliente = reader["TelefonoCliente"].ToString();
        //                Objeto.CondicionPago = reader["CondicionPago"].ToString();
        //                float.TryParse(reader["SubTotal"].ToString(), out valor);
        //                Objeto.SubTotal = valor;
        //                float.TryParse(reader["Itbis"].ToString(), out valor);
        //                Objeto.Itbis = valor;
        //                float.TryParse(reader["Total"].ToString(), out valor);
        //                Objeto.Total = valor;
        //                Objeto.Nota = reader["Nota"].ToString();
        //            }
        //        }
        //        else
        //        {
        //            Objeto = null;
        //        }
        //        Miconexion.Cerrar();
        //        return Objeto;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //#endregion
    }
}
