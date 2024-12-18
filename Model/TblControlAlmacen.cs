using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class TblControlAlmacen
    {
        #region DATOS
        public int IdControlAlmacen { get; set; }
        public int IdUsuario { get; set; }
        public int IdRegistro { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public string Modulo { get; set; }
        public string Movimiento { get; set; }
        public int Cantidad { get; set; }
        public DateTime? Fecha { get; set; }

        #endregion
    }
}
