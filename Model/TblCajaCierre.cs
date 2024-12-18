using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblCajaCierre
    {
        #region DATOS
        public int IdCajaCierre { get; set; }
        public int IdCajaApertura { get; set; }
        public int IdUsuario { get; set; }
        public int Codigo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Caja { get; set; }
        public decimal TotalEntrada { get; set; }
        public decimal TotalSalida { get; set; }
        public decimal TotalConteo { get; set; }
        public decimal Diferencia { get; set; }
        public decimal MontoApertura { get; set; }
        public string Resultado { get; set; }
        public string NombreUsuario { get; set; }
        public decimal Ventas { get; set; }
        public decimal CobrosCxC { get; set; }
        public decimal Compras { get; set; }
        public decimal Gastos { get; set; }
        public decimal DevVentas { get; set; }
        public decimal PagosCxP { get; set; }
        public string Nota { get; set; }

        #endregion
    }
}
