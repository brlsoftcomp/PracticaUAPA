using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class TblCompFiscalConf
    {
        #region DATOS
        public int IdConfComprobante { get; set; }
        public int IdCompFiscal { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public int Cantidad { get; set; }
        public DateTime? Fecha { get; set; }

        #endregion
    }
}
