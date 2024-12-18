using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblDevolucion
    {
        #region DATOS
        public int IdDevolucion { get; set; }
        public int IdUsuario { get; set; }
        public int IdFactura { get; set; }
        public int IdNotaCredito { get; set; }
        public int Codigo { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
        public string Nota { get; set; }
        public string TipoDevolucion { get; set; }
        #endregion
    }
}
