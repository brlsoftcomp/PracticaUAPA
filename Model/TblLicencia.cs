using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalPro.Model
{
    class TblLicencia
    {
        public int IdLicencia { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool Estado { get; set; }
        public int Dias { get; set; }
    }
}
