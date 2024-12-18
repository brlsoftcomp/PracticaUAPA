using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class TblMasterConfig
    {
        #region DATOS
        public int IdMasterConfig { get; set; }
        public DateTime? Fecha { get; set; }
        public string VentasNCF { get; set; }
        public int NotificacionNCF { get; set; }
        public string PapelFactura { get; set; }
        public string ContizacionLogo { get; set; }
        public string ImprimirCopiaFact { get; set; }

        #endregion
    }
}
