using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Utility
{
    public class SQLHelper
    {
        public static string TMSConnectionString = "Data Source=DESKTOP-0V6LNT4;Initial Catalog=TaskManagementSystem;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(TMSConnectionString);
        }
        public async static Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(string commandText, List<SqlParameter> sqlParameters)
        {
            var ds = new DataSet();
            using (var conn = GetConnection())
            {
                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddRange(sqlParameters.ToArray());

                    using (var sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = command;
                        sqlAdapter.Fill(ds);
                    }
                    await conn.CloseAsync();
                    string jsonString = string.Empty;
                    if (ds?.Tables.Count > 0)
                        jsonString = JsonConvert.SerializeObject(ds.Tables[0]);
                    IEnumerable<T> list = !string.IsNullOrEmpty(jsonString) ? await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString)!) : Enumerable.Empty<T>();
                    return list;
                }
            }
        }
    }
}
