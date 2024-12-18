using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblHistAjusteInventario
    {
        #region Datos
        public int IdHistAjustInventario { get; set; }
        public int Codigo { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Nota { get; set; }
        public DateTime? Fecha { get; set; }
        #endregion
    }
}
