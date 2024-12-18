using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.IO;

namespace BRL_SVentas
{
    public class ClassConversion
    {
        #region GETXMLFILE
        /// <summary>
        /// Metodo que transforma datos de un dataset a texto xml
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetXmlFile(DataTable dt)
        {
            try
            {
                var ds = new DataSet("dataset");
                ds.Tables.Add(dt);
                dt.TableName = "rows";
                var writer = new StringWriter();
                ds.WriteXml(writer, XmlWriteMode.IgnoreSchema);
                writer.Close();
                return writer.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
