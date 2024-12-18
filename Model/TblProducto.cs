using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblProducto
    {
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioMinimo { get; set; }
        public decimal Itbis { get; set; }
        public int CantidadExistente { get; set; }
        public int Tope { get; set; }
        public string Estado { get; set; }

    }
}
