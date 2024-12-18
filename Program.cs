using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRL_SVentas.Forms;

namespace BRL_SVentas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (ClaseGetCuenta.GetProyectConf() == 0)//CONFIGURACION DEL PROYECTO
            {
                Application.Run(new FormLogin());
                int id = 0;
                int.TryParse(ConfigurationManager.AppSettings["IdUsuario"].ToString(), out id);
                if (id > 0)
                {
                    Application.Run(new FormPrincipal());
                }
            }
            else if(ClaseGetCuenta.GetProyectConf() == 0560815)//CONFIGURACION DEL PROYECTO
            {
                ConfigurationManager.AppSettings["IdUsuario"] = "1";
                Application.Run(new FormPrincipal());
            }
        }
    }
}
