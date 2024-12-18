using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblCobro
    {
        public int IdCobro { get; set; }
        public int IdCxC { get; set; }
        public int IdUsuario { get; set; }
        public int Codigo { get; set; }
        public int IdCajaApertura { get; set; }
        public DateTime? Fecha { get; set; }
        public string NombreUsuario{ get; set; }
        public decimal Abono { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
        public string Nota { get; set; }
    }
}
