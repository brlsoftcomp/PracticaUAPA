using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblGasto
    {
        #region DATOS
        public int IdGasto { get; set; }
        public int IdUsuario { get; set; }
        public int IdProveedor { get; set; }
        public int IdFormaPago { get; set; }
        public int Codigo { get; set; }
        public int NoFactura { get; set; }
        public string NCF { get; set; }
        public DateTime? Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itbis { get; set; }
        public decimal Monto { get; set; }
        public string Nota { get; set; }

        #endregion
    }
}
