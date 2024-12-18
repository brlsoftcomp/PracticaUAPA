using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblFacturaDetalle
    {
        #region DATOS
        public int IdFacturaDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int CantidadFacturada { get; set; }
        public decimal PrecioFacturado { get; set; }
        public decimal ItbisFacturado { get; set; }
        public decimal MontoFacturado { get; set; }
        public decimal Ganancia { get; set; }
        #endregion
    }
}
