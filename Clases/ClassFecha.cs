using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace BRL_SVentas
{
    public class ClassFecha
    {
        // 1 local
        // 2 servidor
        //int FormatoFecha = 1;

        #region NumeroMes
        public int NumeroMes(string Mes)
        {

            int Munero = 0;
            try
            {
                if (Mes == "ENERO")
                {
                    Munero = 1;
                }
                else if (Mes == "FEBRERO")
                {
                    Munero = 2;
                }
                else if (Mes == "MARZO")
                {
                    Munero = 3;
                }
                else if (Mes == "ABRIL")
                {
                    Munero = 4;
                }
                else if (Mes == "MAYO")
                {
                    Munero = 5;
                }
                else if (Mes == "JUNIO")
                {
                    Munero = 6;
                }
                else if (Mes == "JULIO")
                {
                    Munero = 7;
                }
                else if (Mes == "AGOSTO")
                {
                    Munero = 8;
                }
                else if (Mes == "SEPTIEMBRE")
                {
                    Munero = 9;
                }
                else if (Mes == "OCTUBRE")
                {
                    Munero = 10;
                }
                else if (Mes == "NOVIEMBRE")
                {
                    Munero = 11;
                }
                else if (Mes == "DICIEMBRE")
                {
                    Munero = 12;
                }

                return Munero;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ObtenerDiaMes

      
        public int ObtenerDiaMes(int ano, int mes)
        {
            int cantDias = 0;
            try
            {

                //CultureInfo espanich = new CultureInfo("es-ES");
                //string sunday = espanich.DateTimeFormat.DayNames[(int)DayOfWeek.Sunday];

                DateTime dateValue = new DateTime(ano, mes, 1);
                if (dateValue.ToString("dddd", new CultureInfo("es-ES")) == "lunes")
                {
                    cantDias = 1;
                }
                else if (dateValue.ToString("dddd", new CultureInfo("es-ES")) == "martes")
                {
                    cantDias = 2;
                }
                else if (dateValue.ToString("dddd", new CultureInfo("es-ES")) == "miercoles")
                {
                    cantDias = 3;
                }
                else if (dateValue.ToString("dddd", new CultureInfo("es-ES")) == "jueves")
                {
                    cantDias = 4;
                }
                else if (dateValue.ToString("dddd", new CultureInfo("es-ES")) == "viernes")
                {
                    cantDias = 5;
                }
                else if (dateValue.ToString("dddd", new CultureInfo("es-ES")) == "sábado")
                {
                    cantDias = 6;
                }
                else
                {
                    cantDias = 0;
                }
                return cantDias;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetNombreMes
        public string GetNombreMes(int Mes)
        {
            switch (Mes)
            {
                case 1:
                    return "Ene";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Abr";
                case 5:
                    return "May";
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Ago";
                case 9:
                    return "Sep";
                case 10:
                    return "Oct";
                case 11:
                    return "Nov";
                default:
                    return "Dic";
            }
        }
        #endregion

        #region GetFechaPreview
        public DateTime GetFechaPreview(DateTime fecha)
        {
            try
            {                
                int dia = 0;
                int mes = 0;
                int year = 0;
                dia = fecha.Day;
                mes = fecha.Month;
                year = fecha.Year;
                if (mes == 1)
                {
                    year--;
                    mes = 12;
                }
                else
                {
                    mes--;
                }               
                DateTime fecha2 = new DateTime(year, mes, dia);
                return fecha2;
            }
            catch (Exception)
            {                
                throw;
            }
        }
        #endregion

        #region GetFechaNext
        public DateTime GetFechaNext(DateTime fecha)
        {
            try
            {
                int dia = 0;
                int mes = 0;
                int year = 0;
                dia = fecha.Day;
                mes = fecha.Month;
                year = fecha.Year;
                if (mes == 12)
                {
                    year++;
                    mes = 1;
                }
                else
                {
                    mes++;
                }
                DateTime fecha2 = new DateTime(year, mes, dia);
                return fecha2;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetFecha
        public DateTime GetFecha(string Fecha)
        {
            try
            {
                //return GetFechaServidor(Fecha);
                //if (this.FormatoFecha == 2)
                //{
                //    return GetFechaServidor(Fecha);
                //}
                //else
                //{
                return GetFechaServidor(Fecha);
                //}
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
        
        //#region GetFecha
        //public string GetFecha(DateTime Fecha)
        //{
        //    try
        //    {
        //        string fecha = Fecha.Day.ToString() + "/" + Fecha.Month.ToString() + "/" + Fecha.Year.ToString();
        //        return fecha;               
        //    }
        //    catch (Exception)
        //    {                
        //        throw;
        //    }
 
        //}
        //#endregion

        #region GetFechaServidor
        private DateTime GetFechaServidor(string Fecha)
        {
            try
            {               
                string dia, mes, ano;
                if (char.IsDigit(Convert.ToChar(Fecha.Substring(1, 1))))
                {
                    dia = Fecha.Substring(0, 2);
                    if (char.IsNumber(Convert.ToChar(Fecha.Substring(4, 1))))
                    {
                        mes = Fecha.Substring(3, 2);
                        ano = Fecha.Substring(6, 4);
                    }
                    else
                    {
                        mes = Fecha.Substring(3, 1);
                        ano = Fecha.Substring(5, 4);
                    }
                }
                else
                {
                    dia = Fecha.Substring(0, 1);
                    if (char.IsNumber(Convert.ToChar(Fecha.Substring(3, 1))))
                    {
                        mes = Fecha.Substring(2, 2);
                        ano = Fecha.Substring(5, 4);
                    }
                    else
                    {
                        mes = Fecha.Substring(2, 1);
                        ano = Fecha.Substring(4, 4);
                    }
                }
                return new DateTime(Convert.ToInt32(ano), Convert.ToInt32(mes), Convert.ToInt32(dia));
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region GetFechaLocal
        private DateTime GetFechaLocal(string Fecha)
        {
            try
            {
                string dia, mes, ano;
                if (Fecha.Substring(0, 1) == "0")
                {
                    dia = Fecha.Substring(1, 1);
                    if (Fecha.Substring(3, 1) == "0")
                    {
                        mes = Fecha.Substring(4, 1);
                        ano = Fecha.Substring(6, 4);
                    }
                    else
                    {
                        mes = Fecha.Substring(3, 2);
                        ano = Fecha.Substring(5, 4);
                    }
                }
                else
                {
                    dia = Fecha.Substring(0, 2);
                    if (Fecha.Substring(3, 1) == "0")
                    {
                        mes = Fecha.Substring(4, 1);
                        ano = Fecha.Substring(6, 4);
                    }
                    else
                    {
                        mes = Fecha.Substring(3, 2);
                        ano = Fecha.Substring(6, 4);
                    }
                }
                return new DateTime(Convert.ToInt32(ano), Convert.ToInt32(mes), Convert.ToInt32(dia));
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region GetEdad
        public string GetEdad(DateTime fecha)
        {
            try
            {
                //DateTime Fecha = DateTime.Now;
                //DateTime.TryParse(fecha, out Fecha);
                int edad = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
                return "Edad: " + edad + " Años";
            }
            catch (Exception)
            {                
                throw;
            }
        }
        #endregion

        //SE AGREO ESTA FUNCION:
        #region GetFecha
        public static string GetFecha(DateTime Fecha, int tipo)
        {
            try
            {
                //var confg = new TblConfiguracionMiscelaneos();
                //var factory = new TblConfiguracionMiscelaneosFactory();
                //var key = new TblConfiguracionMiscelaneosKeys(1);
                //confg = factory.GetByPrimaryKey(key);

                int dia, mes, year;
                String FechaGet = string.Empty;
                int.TryParse(Fecha.Day.ToString(), out dia);
                int.TryParse(Fecha.Month.ToString(), out mes);
                int.TryParse(Fecha.Year.ToString(), out year);
                if (tipo == 1)
                {
                    //if (confg.FechaIngles.Value == true)
                    //{
                    //    //ingles
                    //FechaGet = mes.ToString() + "/" + dia.ToString() + "/" + year.ToString() + " 00:00:00";
                    //}
                    //else
                    //{
                    //espanol
                    FechaGet = dia.ToString() + "/" + mes.ToString() + "/" + year.ToString() + " 00:00:00";
                    //}                   
                    //2018 - 12 - 03 15:06:03.117
                }
                else
                {
                    //if (confg.FechaIngles.Value == true)
                    //{
                    //    //ingles
                    //FechaGet = mes.ToString() + "/" + dia.ToString() + "/" + year.ToString() + " 23:59:59";
                    //}
                    //else
                    //{
                    //    //espanol
                    FechaGet = dia.ToString() + "/" + mes.ToString() + "/" + year.ToString() + " 23:59:59";
                    //}                       
                    //2018 - 12 - 03 23:59:59.9999
                }
                return FechaGet;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetFechaUSA
        public static string GetFechaUSA(DateTime Fecha, int tipo)
        {
            try
            {
                //var confg = new TblConfiguracionMiscelaneos();
                //var factory = new TblConfiguracionMiscelaneosFactory();
                //var key = new TblConfiguracionMiscelaneosKeys(1);
                //confg = factory.GetByPrimaryKey(key);

                int dia, mes, year;
                String FechaGet = string.Empty;
                int.TryParse(Fecha.Day.ToString(), out dia);
                int.TryParse(Fecha.Month.ToString(), out mes);
                int.TryParse(Fecha.Year.ToString(), out year);
                if (tipo == 1)
                {
                    //if (confg.FechaIngles.Value == true)
                    //{
                    //    //ingles
                    //    FechaGet = mes.ToString() + "/" + dia.ToString() + "/" + year.ToString() + " 00:00:00";
                    //}
                    //else
                    //{
                    //espanol
                    FechaGet = year.ToString() + "/" + mes.ToString() + "/" + dia.ToString() + " 00:00:00";
                    //}                   
                    //2018 - 12 - 03 15:06:03.117
                }
                else
                {
                    //if (confg.FechaIngles.Value == true)
                    //{
                    //    //ingles
                    //    FechaGet = mes.ToString() + "/" + dia.ToString() + "/" + year.ToString() + " 23:59:59";
                    //}
                    //else
                    //{
                    //    //espanol
                    FechaGet = year.ToString() + "/" + mes.ToString() + "/" + dia.ToString() + " 23:59:59";
                    //}                       
                    //2018 - 12 - 03 23:59:59.9999
                }
                return FechaGet;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}