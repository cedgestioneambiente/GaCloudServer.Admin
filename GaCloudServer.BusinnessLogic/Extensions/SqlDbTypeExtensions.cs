
using System.Collections.Specialized;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;

namespace GaCloudServer.BusinnessLogic.Extensions
{
    public static class SqlDbTypeExtensions
    {
        public static SqlParameter LIST_OF_STRING(List<string> valori,string parameterName)
        {
            var dataTable = new DataTable();
            dataTable.TableName = "dbo.LIST_OF_STRING";
            dataTable.Columns.Add("Valore", typeof(string));

            foreach (var itm in valori)
            {
                dataTable.Rows.Add(itm);
            }

            SqlParameter parameter = new SqlParameter(parameterName, SqlDbType.Structured);
            parameter.TypeName = "dbo.LIST_OF_STRING";
            parameter.Value = dataTable;

            return parameter;
        }

        public static SqlParameter TableValuedListOfString(List<string> values, string parameterName)
        {
            //var tvp = new TableValuedParameterBuilder("dbo.LIST_OF_STRING", new SqlMetaData("Valore", SqlDbType.Text));
            //foreach (var itm in values)
            //{
            //    tvp.AddRow(itm);
            //}
            ////tvp.CreateParameter(parameterName);

            //return tvp.CreateParameter(parameterName);

            var tableSchema = new List<SqlMetaData>(values.Count)
            {
                new SqlMetaData("Valore",SqlDbType.NVarChar,SqlMetaData.Max)
            }.ToArray();

            var tableRow = new SqlDataRecord(tableSchema);
            int i = 0;
            foreach (var itm in values)
            {
                tableRow.SetString(i, itm);
                i++;
            }

            var table = new List<SqlDataRecord>(values.Count)
            {
                tableRow
            };

            var parameter = new SqlParameter();
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.ParameterName = parameterName;
            parameter.Value = table;

            return parameter;

        }

        public static SqlParameter StringCollectionToParameter(List<string> values, string parameterName)
        {
            StringCollection strColl = new StringCollection();
            foreach (var itm in values)
            {
                strColl.Add(itm);
            }

            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.TypeName = "dbo.LIST_OF_STRING";
            param.SqlDbType = SqlDbType.Structured;
            param.Value = strColl;
            param.Direction = ParameterDirection.Input;

            return param;
        }
    }

    
}
