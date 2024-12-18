using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblPrestamo
    {
        public int IdPrestamo { get; set; }
        public int Codigo { get; set; }
        public int IdProveedor { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal Taza { get; set; }
        public decimal Capital { get; set; }
        public int CantidadCuota { get; set; }
        public decimal MontoCuota { get; set; }
        public decimal Total { get; set; }
        public string Nota { get; set; }
    }
}
