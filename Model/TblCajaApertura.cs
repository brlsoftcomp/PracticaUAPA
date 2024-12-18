﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblCajaApertura
    {
        #region DATOS
        public int IdCajaApertura { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string Caja { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }

        #endregion
    }
}
