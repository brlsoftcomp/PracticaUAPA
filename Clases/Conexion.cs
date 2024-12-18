using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Configuration;

namespace BRL_SVentas
{   
    public class Conexion
    {
        SqlConnection conn;
        private SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
        private SqlDataAdapter adapter;
        private SqlDataReader datalector;
        SqlTransaction sqlTran;

        public Conexion()
        {
            conn = new SqlConnection(GetConnectionString());
        }

        public void CopiaSeguridad(string ruta)
        {
            SqlCommand cmd = new SqlCommand("CopiaSeguridad", conn, sqlTran);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ruta ", ruta);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        #region BuscarServidor
        public string BuscarServidor() // Busca el nombre de instancia del servidor SQl SERVER instalado en la PC Actual
        {
            try
            {
                string Servidor = "";
                string query = "SELECT CAST( SERVERPROPERTY( 'InstanceName' ) AS varchar( 30 ) ) AS Instance";//NOMBRE DE INSTANCIA DEL SERVIDOR
                datalector = Buscar(query);
                if (datalector.HasRows)
                {
                    while (datalector.Read())
                    {
                        Servidor = datalector["Instance"].ToString();
                    }
                }
                Cerrar();
                return Servidor;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion             
       
        #region Abrir
        public void Abrir() // Metodo para Abrir la Conexion
        {
            conn.Open();
        }
        #endregion

        #region GetConnectionString
        public static string GetConnectionString()
        {
            if(ConfigurationManager.AppSettings["Logo"] == "1")
                return "Data Source=SQL5106.site4now.net;Initial Catalog=db_a95a77_brlsventas;User Id=db_a95a77_brlsventas_admin;Password=BRL0560815";
            else
                return ConfigurationManager.AppSettings["Main.ConnectionString"];
        }
        #endregion

        #region Cerrar
        public void Cerrar() // Metodo para Cerrar la Conexion
        {
            conn.Close();
        }
        #endregion
      
        #region Buscar
        public SqlDataReader Buscar(string query)
        {
            try
            {
                Cerrar();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.CommandText = query;
                conn.Open();
                datalector = cmd.ExecuteReader();
                return datalector;
            }
            catch (Exception)
            {                
                throw;
            }          
        } 
        #endregion
              
        #region BuscarTabla

        public DataTable BuscarTabla(StringBuilder sql) //Metodo para Buscar Registros Multiples
        {
            Cerrar();
            dt = new DataTable();
            //conn = new SqlConnection(CadenaConexion());//Creando la conexion a la base de datos
            cmd = new SqlCommand(sql.ToString(), conn); //El comando que manejara el query.
            adapter = new SqlDataAdapter(cmd); //El objeto que llenara el datagridview
            try
            {
                Abrir();
                adapter.Fill(dt);//Rellena el datatable con la data que capture producto del query.
                Cerrar();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Cerrar();
            }            
        }
        #endregion

        #region BuscarTabla
        public DataTable BuscarTabla(string Tabla) //Metodo para Buscar Registros Multiples
        {
            dt = new DataTable();
            string query = string.Format("SELECT * FROM {0}",Tabla );
            cmd = new SqlCommand(query.ToString(), conn); //El comando que manejara el query.
            adapter = new SqlDataAdapter(cmd); //El objeto que llenara el datagridview
            try
            {
                Abrir();
                adapter.Fill(dt);//Rellena el datatable con la data que capture producto del query.
                Cerrar();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Cerrar();
            }
        }
        #endregion

        #region BuscarTabla
        public DataTable BuscarTabla(string Tabla, string Campo, string Dato) //Metodo para Buscar Registros Multiples
        {
            dt = new DataTable();
            string query = string.Format("SELECT * FROM {0} WHERE {1} = {2}",Tabla, Campo, Dato);
            cmd = new SqlCommand(query.ToString(), conn); //El comando que manejara el query.
            adapter = new SqlDataAdapter(cmd); //El objeto que llenara
            try
            {
                Abrir();
                adapter.Fill(dt);//Rellena el datatable con la data que capture producto del query.
                Cerrar();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Cerrar();
            }
        }
        #endregion

        #region Guardar
        public bool Guardar(string query)
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.CommandText = query;
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;
            }
            finally { conn.Close(); }
        } 
        #endregion

        #region IniciarTransaccion
        public void IniciarTransaccion()//Metodo para Guardar Registros en Transacciones
        {
            //conn.Open();
            //this.sqlTran = conn.BeginTransaction();
            //cmd = new SqlCommand();
            //cmd.Connection = conn;
        }
        #endregion       

        #region GuardarTransaccion
        public void GuardarTransaccion(string query)//Metodo para Guardar Registros en Transacciones
        {
            //new SqlCommand(query, conn, sqlTran).ExecuteNonQuery();
        }
        #endregion

        #region BorrarRegistro
        public void BorrarRegistro(string Tabla)
        {
            //SqlCommand cmd = new SqlCommand("Borra_Registro", conn, sqlTran);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Tabla ", Tabla);
            //try
            //{
            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally
            //{
            //    conn.Close();
            //}
        }
        #endregion

        #region CerrarTransaccion
        public bool CerrarTransaccion()//Metodo para Cerrar la Transacciones
        {
            //this.sqlTran.Commit();
            //conn.Close();
            return true;
        }
        #endregion

        #region Rollback
        public void Rollback()//Metodo para Cerrar la Transacciones
        {
            //sqlTran.Rollback();
        }
        #endregion
        //////////////////////////////////////////////////

        #region GuardaXml
        /// <summary>
        /// Metodo que sube datos en formato xml
        /// </summary>
        /// <param name="Procedure"></param>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="IdVendedor"></param>
        /// <returns></returns>
        public int GuardaXml(string Procedure, DataTable dt)
        {
            conn.Open();
            var command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = Procedure;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 30;           
            command.Parameters.AddWithValue("@xml", ClassConversion.GetXmlFile(dt).ToString());
            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, 0));
            
            try
            {
                command.ExecuteNonQuery();
                return (int)command.Parameters["@ID"].Value;                
            }
            catch (Exception)
            {
                throw;
            }
           finally { conn.Close(); }
        }
        #endregion

        #region GuardaXml
        /// <summary>
        /// Metodo que sube datos de los cobros a la web en formato xml
        /// </summary>
        /// <param name="Procedure"></param>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="IdVendedor"></param>
        /// <returns></returns>
        public bool GuardaXml(string Procedure, DataTable dt1, DataTable dt2)
        {
            conn.Open();
            var command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = Procedure;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 30;
            command.Parameters.AddWithValue("@xml1", ClassConversion.GetXmlFile(dt1).ToString());
            command.Parameters.AddWithValue("@xml2", ClassConversion.GetXmlFile(dt2).ToString());
            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return false;
        }
        #endregion

        #region GuardaXml
        /// <summary>
        /// Metodo que sube datos de los cobros a la web en formato xml
        /// </summary>
        /// <param name="Procedure"></param>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="IdVendedor"></param>
        /// <returns></returns>
        public int GuardaXmlInt(string Procedure, DataTable dt1)
        {
            conn.Open();
            var command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = Procedure;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 30;
            command.Parameters.AddWithValue("@xml", ClassConversion.GetXmlFile(dt1).ToString());
            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, 0));
            try
            {
                command.ExecuteNonQuery();
                return (int)command.Parameters["@ID"].Value;  
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
        }
        #endregion

        #region GuardaXmlInt
        /// <summary>
        /// Metodo que sube datos de los cobros a la web en formato xml
        /// </summary>
        /// <param name="Procedure"></param>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="IdVendedor"></param>
        /// <returns></returns>
        public int GuardaXmlInt(string Procedure, DataTable dt, int IdCuenta, string Ars, string NumeroAfiliado)
        {
            conn.Open();
            var command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = Procedure;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 30;
            command.Parameters.AddWithValue("@xml1", ClassConversion.GetXmlFile(dt).ToString());
            command.Parameters.AddWithValue("@IdCuenta", IdCuenta);
            command.Parameters.AddWithValue("@Ars", Ars);
            command.Parameters.AddWithValue("@NumeroAfiliado", NumeroAfiliado);
            command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, 0));
            try
            {
                command.ExecuteNonQuery();
                return (int)command.Parameters["@ID"].Value;
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
        }
        #endregion

        //METODOS ASYNC
        public async void AbrirAsync() // Metodo asincrono para Abrir la Conexion
        {
            await conn.OpenAsync();
        }
        public async Task<bool> GuardarAsync(string query)
        {
            //conn = new SqlConnection(CadenaConexion());
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;            
            cmd.CommandText = query;
            try
            {
                await conn.OpenAsync();
                if (await cmd.ExecuteNonQueryAsync() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
        } //Metodo asincrono para Guardar Registros Siple y eliminar registros
        public async Task<SqlDataReader> BuscarAsync(string query)
        {
            Cerrar();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.CommandText = query;
            await conn.OpenAsync();
            datalector = await cmd.ExecuteReaderAsync();

            return datalector;

        } //Metodo asincorono para Buscar Registros Simples
        public async Task<DataTable> BuscarTablaAsync(StringBuilder sql) //Metodo para Buscar Registros Multiples
        {
            Cerrar();
            dt = new DataTable();
            //conn = new SqlConnection(CadenaConexion());//Creando la conexion a la base de datos
            cmd = new SqlCommand(sql.ToString(), conn); //El comando que manejara el query.
            adapter = new SqlDataAdapter(cmd); //El objeto que llenara el datagridview
            try
            {
                Abrir();
                await Task.Run(() => { adapter.Fill(dt); });//Rellena el datatable con la data que capture producto del query.
                
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Cerrar();
            }
        }

        public List<string> GetLista(string procedure, string value)
        {
            try
            {
                conn.Close();
                int IdCuenta = 0;
                int.TryParse("1", out IdCuenta);
                List<string> Nombres = new List<string>();
                var cmd = new SqlCommand(procedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", value);
                cmd.Parameters.AddWithValue("@IdCuenta", IdCuenta);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Nombres.Add("["+ rdr["IdAsignado"].ToString()+"] " + rdr["Nombre"].ToString());
                }
                conn.Close();
                return Nombres;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public List<string> GetListaCxC(string procedure, string value)
        {
            try
            {
                conn.Close();
                int IdCuenta = 0;
                int.TryParse("1", out IdCuenta);
                List<string> Nombres = new List<string>();
                var cmd = new SqlCommand(procedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", value);
                cmd.Parameters.AddWithValue("@IdCuenta", IdCuenta);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Nombres.Add("[" + rdr["IdCliente"].ToString() + "] " + rdr["Nombre"].ToString());
                }
                conn.Close();
                return Nombres;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
