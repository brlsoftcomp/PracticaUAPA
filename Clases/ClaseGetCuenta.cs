using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL_SVentas
{
    class ClaseGetCuenta
    {
        public static bool FormCierreCaja = false;
        public static int GetIdServidor()
        {
            try
            {
                int IdServidor = 0;
                int.TryParse(ConfigurationManager.AppSettings["Logo"].ToString(), out IdServidor);
                return IdServidor;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int GetIdUsuario()
        {
            try
            {
                int IdUsuario = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out IdUsuario);
                return IdUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int GetProyectConf()
        {
            try
            {
                int ProyectConfi = 0;
                int.TryParse(ConfigurationManager.AppSettings["ProyectConfi"].ToString(), out ProyectConfi);
                return ProyectConfi;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int GetIdCajaApertura()
        {
            try
            {
                int IdCajaApertura = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdCajaApertura"].ToString(), out IdCajaApertura);
                return IdCajaApertura;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
