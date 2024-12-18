using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    public class TblCapital
    {
        public int IdCapital { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal CapitalMercancia { get; set; }
        public decimal CapitalPopular { get; set; }
        public decimal CapitalReservas { get; set; }
        public decimal CapitalBHD { get; set; }
        public decimal CapitalCxC { get; set; }
        public decimal CapitalCxP { get; set; }
    }
}
