using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class TblCompFiscalSecuencia
    {
        #region DATOS
        public int IdCompFiscalSecuencia { get; set; }
        public int IdCompFiscal { get; set; }
        public int IdFactura { get; set; }
        public string NCF { get; set; }
        public string NCFModificado { get; set; } 
        #endregion
    }
}
