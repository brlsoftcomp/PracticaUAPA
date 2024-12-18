using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblPago
    {
        #region DATOS
        public int IdPago { get; set; }
        public int IdCxP { get; set; }
        public int IdUsuario { get; set; }
        public int Codigo { get; set; }
        public DateTime? Fecha { get; set; }
        public string NombreUsuario { get; set; }
        public decimal PagoCaja { get; set; }
        public decimal PagoOtros { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
        public string Nota { get; set; }
        #endregion
    }
}
