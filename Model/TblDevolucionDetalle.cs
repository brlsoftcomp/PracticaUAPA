using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblDevolucionDetalle
    {
        #region DATOS
        public int IdDevolucionDetalle { get; set; }
        public int IdDevolucion { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal ItbisFacturado { get; set; }
        public decimal PrecioFacturado { get; set; }
        public decimal MontoFacturado { get; set; }
        #endregion
    }
}
