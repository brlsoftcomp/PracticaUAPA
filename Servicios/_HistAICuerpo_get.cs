using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRL_SVentas.Model;

namespace BRL_SVentas.Servicios
{
    class _HistAICuerpo_get
    {
        static Conexion Miconexion = new Conexion();

        #region GetAll
        public List<TblHistAICuerpo> GetById(int Id)
        {
            try
            {
                TblHistAICuerpo Objeto;
                var list = new List<TblHistAICuerpo>();
                var dt = new DataTable();
                var builder = new StringBuilder();
                builder.Append("SELECT IdHistAICuerpo, FkeyProducto, TblProducto.Nombre, CantidadExistenet, CantidadAjuste, Ajuste, TipoAjuste FROM TblHistAICuerpo JOIN TblProducto on FkeyProducto = IdProducto AND FkeyHistAI = '" + Id + "'");
                dt = Miconexion.BuscarTabla(builder);
                int valor = 0;
                foreach (DataRow reader in dt.Rows)
                {
                    Objeto = new TblHistAICuerpo();

                    int.TryParse(reader["IdHistAICuerpo"].ToString(), out valor);
                    Objeto.IdHistAICuerpo = valor;
                    int.TryParse(reader["FkeyProducto"].ToString(), out valor);
                    Objeto.FkeyProducto = valor;
                    Objeto.Descripcion = reader["Nombre"].ToString();
                    Objeto.TipoAjuste = reader["TipoAjuste"].ToString();
                    int.TryParse(reader["CantidadExistenet"].ToString(), out valor);
                    Objeto.CantidadExistenet = valor;
                    int.TryParse(reader["CantidadAjuste"].ToString(), out valor);
                    Objeto.CantidadAjuste = valor;
                    int.TryParse(reader["Ajuste"].ToString(), out valor);
                    Objeto.Ajuste = valor;
                    list.Add(Objeto);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
