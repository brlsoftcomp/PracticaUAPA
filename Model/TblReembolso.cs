using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class TblReembolso
    {
        public int IdReembolso { get; set; }
        public int IdDevolucion { get; set; }
        public int IdFormaPago { get; set; }
        public int Codigo { get; set; }
        public decimal Monto { get; set; }
        public string Nota { get; set; }
    }
}
