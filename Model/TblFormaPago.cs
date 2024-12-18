using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblFormaPago
    {
        #region DATOS
        public int IdFormaPago { get; set; }
        public int IdUsuario { get; set; }
        public decimal MontoEfectivo { get; set; }
        public decimal MontoTarjeta { get; set; }
        public decimal MontoCheque { get; set; }
        public int NoBoucher { get; set; }
        public int NoCheque { get; set; }
        public decimal MontoNotaCredito { get; set; }
        public string Concepto { get; set; }        
        #endregion
    }
}
