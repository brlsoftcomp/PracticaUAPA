using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblEmpresa
    {
        #region DATOS
        public int IdEmpresa { get; set; }
        public string RNC { get; set; }
        public string Nombre { get; set; }
        public string Actividad { get; set; }
        public string Direccion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Logo { get; set; }
        #endregion
    }
}
