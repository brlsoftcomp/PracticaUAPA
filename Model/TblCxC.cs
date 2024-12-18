using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblCxC
    {
        #region DATOS
        public int IdCxC { get; set; }
        public int Codigo { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public int IdFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public string UsuarioNombre { get; set; }
        public string ClienteNombre { get; set; }
        public string Concepto { get; set; }
        public decimal Balance { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
        public string Nota { get; set; }
        #endregion
    }
}
