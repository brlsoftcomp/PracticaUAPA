using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblCotizacionDetalle
    {
        #region DATOS
        public int IdCotizacionDetalle { get; set; }
        public int IdCotizacion { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int CantidadCotizada { get; set; }
        public decimal PrecioCotizado { get; set; }
        public decimal MontoCotizado { get; set; }
        public decimal ItbisCotizado { get; set; }
        public decimal Ganancia { get; set; }

        #endregion
    }
}
