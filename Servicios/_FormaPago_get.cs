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
    class _FormaPago_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetById
        public TblFormaPago GetById(int Id)
        {
            try
            {
                int valorInt = 0;
                decimal valorDecimal = 0;
                var Objeto = new TblFormaPago();
                SqlDataReader reader;
                reader = Miconexion.Buscar("SELECT * FROM TblFormaPago WHERE IdFormaPago= '" + Id + "'");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                        Objeto.IdFormaPago = Id;
                        int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                        Objeto.IdUsuario = valorInt;
                        decimal.TryParse(reader["MontoEfectivo"].ToString(), out valorDecimal);
                        Objeto.MontoEfectivo = valorDecimal;
                        decimal.TryParse(reader["MontoTarjeta"].ToString(), out valorDecimal);
                        Objeto.MontoTarjeta = valorDecimal;
                        decimal.TryParse(reader["MontoCheque"].ToString(), out valorDecimal);
                        Objeto.MontoCheque = valorDecimal;
                        int.TryParse(reader["NoBoucher"].ToString(), out valorInt);
                        Objeto.NoBoucher = valorInt;
                        int.TryParse(reader["NoCheque"].ToString(), out valorInt);
                        Objeto.NoCheque = valorInt;
                        decimal.TryParse(reader["MontoNotaCredito"].ToString(), out valorDecimal);
                        Objeto.MontoNotaCredito = valorDecimal;
                        Objeto.Concepto = reader["Concepto"].ToString();
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

        //#region GetByIdFactura
        //public int GetByIdFactura(int Id)
        //{
        //    try
        //    {
        //        int valorInt = 0;
        //        var Objeto = new TblFormaPago();
        //        SqlDataReader reader;
        //        reader = Miconexion.Buscar("SELECT * FROM TblFormaPago WHERE IdFactura= '" + Id + "'");
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                int.TryParse(reader["IdFormaPago"].ToString(), out valorInt);
        //                Objeto.IdFormaPago = valorInt;

        //            }
        //        }
        //        else
        //        {
        //            Objeto = null;
        //        }
        //        Miconexion.Cerrar();
        //        return valorInt;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //#endregion

        #region GetAll
        public List<TblFormaPago> GetAll()
        {
            try
            {
                TblFormaPago Objeto;
                var list = new List<TblFormaPago>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT * FROM TblFormaPago");
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valorDecimal = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblFormaPago();
                    int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                    Objeto.IdFormaPago = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    decimal.TryParse(reader["MontoEfectivo"].ToString(), out valorDecimal);
                    Objeto.MontoEfectivo = valorDecimal;
                    decimal.TryParse(reader["MontoTarjeta"].ToString(), out valorDecimal);
                    Objeto.MontoTarjeta = valorDecimal;
                    decimal.TryParse(reader["MontoCheque"].ToString(), out valorDecimal);
                    Objeto.MontoCheque = valorDecimal;
                    int.TryParse(reader["NoBoucher"].ToString(), out valorInt);
                    Objeto.NoBoucher = valorInt;
                    int.TryParse(reader["NoCheque"].ToString(), out valorInt);
                    Objeto.NoCheque = valorInt;
                    decimal.TryParse(reader["MontoNotaCredito"].ToString(), out valorDecimal);
                    Objeto.MontoNotaCredito = valorDecimal;
                    Objeto.Concepto = reader["Concepto"].ToString();
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
        public List<TblFormaPago> GetBy(string Campo, string Parametro)
        {
            try
            {
                TblFormaPago Objeto;
                var list = new List<TblFormaPago>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append(string.Format("SELECT * FROM TblFormaPago WHERE {0} = '" + Parametro + "'", Campo));
                dt = Miconexion.BuscarTabla(builder);
                int Id = 0;
                int valorInt = 0;
                decimal valorDecimal = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblFormaPago();
                    int.TryParse(reader["IdFormaPago"].ToString(), out Id);
                    Objeto.IdFormaPago = Id;
                    int.TryParse(reader["IdUsuario"].ToString(), out valorInt);
                    Objeto.IdUsuario = valorInt;
                    decimal.TryParse(reader["MontoEfectivo"].ToString(), out valorDecimal);
                    Objeto.MontoEfectivo = valorDecimal;
                    decimal.TryParse(reader["MontoTarjeta"].ToString(), out valorDecimal);
                    Objeto.MontoTarjeta = valorDecimal;
                    decimal.TryParse(reader["MontoCheque"].ToString(), out valorDecimal);
                    Objeto.MontoCheque = valorDecimal;
                    int.TryParse(reader["NoBoucher"].ToString(), out valorInt);
                    Objeto.NoBoucher = valorInt;
                    int.TryParse(reader["NoCheque"].ToString(), out valorInt);
                    Objeto.NoCheque = valorInt;
                    decimal.TryParse(reader["MontoNotaCredito"].ToString(), out valorDecimal);
                    Objeto.MontoNotaCredito = valorDecimal;
                    Objeto.Concepto = reader["Concepto"].ToString();
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
