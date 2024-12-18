using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblCompra
    {
        #region DATOS
        public int IdCompra { get; set; }
        public int IdUsuario { get; set; }
        public int IdProveedor { get; set; }
        public int IdFormaPago { get; set; }
        public DateTime? Fecha { get; set; }
        public int NoFactura { get; set; }
        public string NCF { get; set; }
        public string CondicionCompra { get; set; }      
        public decimal Itbis { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string Nota { get; set; }

        #endregion
    }
}
