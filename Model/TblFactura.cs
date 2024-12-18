using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblFactura
    {
        #region DATOS
        public int IdFactura { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public int IdCajaApertura { get; set; }
        public int IdFormaPago { get; set; }
        public int Codigo { get; set; }
        public DateTime? Fecha { get; set; }
        public string CondicionPago { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
        public string Nota { get; set; }
        public string Estado { get; set; }
        public decimal TotalGanancia { get; set; }
        #endregion
    }
}
