using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class TblCompraDetalle
    {
        #region DATOS
        public int IdCompraDetalle { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Itbis { get; set; }
        public decimal Precio { get; set; }
        public decimal Monto { get; set; }
        #endregion
    }
}
