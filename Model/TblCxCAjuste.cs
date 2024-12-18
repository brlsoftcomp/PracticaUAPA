using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblCxCAjuste
    {
        #region DATOS
        public int IdCxCAjuste { get; set; }
        public int IdCxC { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal MontoAjuste { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
        public string Concepto { get; set; }
        public string NombreUsuario { get; set; }
        public string Nota { get; set; }

        #endregion
    }
}
