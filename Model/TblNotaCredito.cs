using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblNotaCredito
    {
        #region DATOS
        public int IdNotaCredito { get; set; }
        public int IdFactura { get; set; }
        public int IdUsuario { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; }
        public string Estado { get; set; }

        #endregion
    }
}
