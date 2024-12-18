using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblCaja
    {
        #region DATOS
        public int IdCaja { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public int Registro { get; set; }
        public string Modulo { get; set; }
        public decimal Monto { get; set; }
        public string Caja { get; set; }
        public string Estado { get; set; }
        public int IdCajaApertura { get; set; }

        #endregion
    }
}
