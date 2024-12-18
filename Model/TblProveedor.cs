using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblProveedor
    {
        #region DATOS

        public int IdProveedor { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string RNC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Correo { get; set; }
        public string ItbisIncluido { get; set; }
        
        #endregion
    }
}
