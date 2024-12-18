using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas.Model
{
    class TblHistAICuerpo
    {      
        #region Datos
        public int IdHistAICuerpo { get; set; }
        public int FkeyHistAI { get; set; }
        public int FkeyProducto { get; set; }
        public string Descripcion { get; set; }
        public string TipoAjuste { get; set; }
        public int CantidadExistenet { get; set; }
        public int CantidadAjuste { get; set; }
        public int Ajuste { get; set; }
        #endregion
    }
}
