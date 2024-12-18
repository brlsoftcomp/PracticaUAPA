using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace BRL_SVentas
{
    public static class ClassImagen2
    {
        static SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["Main.ConnectionString"]);
                
        /// Consigue las imagenes desde la base de datos
        /// </summary>
        public static System.IO.MemoryStream GetImagesFromDatabase(int imageID, string tabla)
        {
            Byte[] img = null;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            SqlCommand cmd = new SqlCommand("Select fImagen FROM "+ tabla + " WHERE fImagenID=" + imageID.ToString(), conn);
            SqlDataAdapter a = new SqlDataAdapter("Select fImagen FROM " + tabla + " WHERE fImageID=" + imageID.ToString(), conn);
            try
            {
                conn.Open();
                img = (byte[])cmd.ExecuteScalar();
                ms = new System.IO.MemoryStream(img);
            }
            catch (Exception e)
            {
                MessageBox.Show("Se produjo un error en GetImagesFromDatabase()\n\n" + e.Message);
            }
            finally
            {
                conn.Close();
            }
            if (ms.Length <= 0)
                return null;

            return ms;
        }

        public static void GuardarScanner(string ruta, int iWidth, int iHeight, int codigo, string tipo, string referencia)
        {
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("[GuardarScanner]", conn);
          
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fImagen ", ReadFile(ruta));
            cmd.Parameters.AddWithValue("@fNombre", GetFileName(ruta));
            cmd.Parameters.AddWithValue("@fcodigo", codigo);
            cmd.Parameters.AddWithValue("@fExtension", GetFileExtension(ruta));
            cmd.Parameters.AddWithValue("@fTamano", FileSize(ruta));
            cmd.Parameters.AddWithValue("@fWidth", iWidth);
            cmd.Parameters.AddWithValue("@fHeight", iHeight);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@referencia", referencia);            

            SqlParameter retValue = new SqlParameter("@retVal", SqlDbType.Int, 4);
            retValue.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(retValue);  //Este el parametro OUTPUT para saber que ID le puso en la DB
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Imagen Guardada con el ID:" + retValue.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        
        /// <summary>
        /// Permite guardar una imagen en sql server usando
        /// stored procedures
        /// </summary>
        /// <param name="ruta"></param>
        public static void GuardarImagenSqlServer2008(string ruta, int iWidth, int iHeight, int codigo, int tabla)
        {
            SqlCommand cmd = new SqlCommand();
            if (tabla == 1)
            {
                cmd = new SqlCommand("Guardar_sp_tblImagenes", conn);
            }
            else
            {
                cmd = new SqlCommand("Guardar_sp_tblImagenesEmpresa", conn);
            }            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fImagen ", ReadFile(ruta));
            cmd.Parameters.AddWithValue("@fNombre", GetFileName(ruta));
            cmd.Parameters.AddWithValue("@fcodigo", codigo);
            cmd.Parameters.AddWithValue("@fExtension", GetFileExtension(ruta));
            cmd.Parameters.AddWithValue("@fTamano", FileSize(ruta));
            cmd.Parameters.AddWithValue("@fWidth", iWidth);
            cmd.Parameters.AddWithValue("@fHeight", iHeight);
            //cmd.Parameters.AddWithValue("@tabla", tabla);

            SqlParameter retValue = new SqlParameter("@retVal", SqlDbType.Int, 4);
            retValue.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(retValue);  //Este el parametro OUTPUT para saber que ID le puso en la DB
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Imagen Guardada con el ID:" + retValue.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Se le pasa el ID de la imagen y devuelve el memory stream
        /// que contiene la informacion de la fotografia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MemoryStream GetImagesFromDatabase(string id, string tabla)
        {
            Byte[] img = null;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            SqlCommand cmd = new SqlCommand("Select fImagen FROM "+ tabla + " WHERE fcodigo=" + id.ToString(), conn);
            try
            {
                conn.Open();
                img = (byte[])cmd.ExecuteScalar();
                if (img != null)
                {
                    ms = new System.IO.MemoryStream(img);
                }
               
            }
            catch (Exception e)
            {
                MessageBox.Show("Se produjo un error en GetImagesFromDatabase()\n\n" + e.Message);
            }
            finally
            {
                conn.Close();
            }            
            return ms;            
        }

        public static byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            if (FileExists(sPath))  //esta funcion verifica si el archivo existe o no
            {
                FileInfo fInfo = new FileInfo(sPath);
                long numBytes = fInfo.Length;

                //Open FileStream to read file
                FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

                //Use BinaryReader to read file stream into byte array.
                BinaryReader br = new BinaryReader(fStream);

                //When you use BinaryReader, you need to 

                //supply number of bytes to read from file.
                //In this case we want to read entire file. 

                //So supplying total number of bytes.
                data = br.ReadBytes((int)numBytes);
            }
            return data;
        }

        /// <summary>
        /// Determina si un archivo existe o no. Se le debe de pasar la ruta completa
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool FileExists(string path)
        {
            if (path != string.Empty || path != null)
            {
                System.IO.FileInfo file;
                try
                {
                    file = new System.IO.FileInfo(path);
                }
                catch
                {
                    return false;
                }
                return file.Exists;
            }
            return false;
        }

        /// <summary>
        /// Retorna el tamano en bytes de un archivo.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static long FileSize(string path)
        {
            if (FileExists(path))
            {
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                return file.Length;
            }
            return 0;
        }

        /// <summary>
        /// Retorna la extension de un archivo con el punto.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileExtension(string path)
        {
            if (FileExists(path))
                return System.IO.Path.GetExtension(path);
            return "";
        }

        /// <summary>
        /// Retorna el nombre del archivo con la extensión
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileName(string path)
        {
            if (FileExists(path))
                return System.IO.Path.GetFileName(path);
            return "";
        }

        /// <summary>
        /// Retorna el nombre del directorio
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDirectoryName(string path)
        {
            return System.IO.Path.GetDirectoryName(path);
        }

        /// <summary>
        /// Retorna el nombre del archivo sin la extensión
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileNameWithoutExtension(string path)
        {
            return System.IO.Path.GetFileNameWithoutExtension(path);
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        #region GetToArray
        public static Byte[] GetToArray(Byte[] Imagen)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ms = new System.IO.MemoryStream((System.Byte[])Imagen);
                Bitmap bmp1 = (Bitmap)Image.FromStream(ms);

                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 25L);
                myEncoderParameters.Param[0] = myEncoderParameter;

                System.IO.MemoryStream ms2 = new System.IO.MemoryStream();
                bmp1.Save(ms2, jpgEncoder, myEncoderParameters);
                return ms2.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetToArray
        public static Byte[] GetToArray(System.Drawing.Image Imagen)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ms = new System.IO.MemoryStream(imageToByteArray(Imagen));
                Bitmap bmp1 = (Bitmap)Image.FromStream(ms);

                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 25L);
                myEncoderParameters.Param[0] = myEncoderParameter;

                System.IO.MemoryStream ms2 = new System.IO.MemoryStream();
                bmp1.Save(ms2, jpgEncoder, myEncoderParameters);
                return ms2.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public static Image GetImage(byte[] Imagen)
        {
            PictureBox img = new PictureBox();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ms = new System.IO.MemoryStream((System.Byte[])Imagen);
            return img.Image = Image.FromStream(ms);
        }
    }
}
