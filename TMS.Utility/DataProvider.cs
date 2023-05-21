using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Utility
{
    public class DataProvider
    {
        public static SqlParameter GetStringSqlParameter(string parameterName, string value, bool output = false)
        {
            var parameter = value != null ?
                                            new SqlParameter(parameterName, value) :
                                            new SqlParameter(parameterName, DBNull.Value);
            if (output)
                parameter.Direction = ParameterDirection.Output;

            return parameter;
        }
        public static SqlParameter GetDateSqlParameter(string parameterName, DateTime? value, bool output = false)
        {
            var parameter = value != null ?
                                            new SqlParameter(parameterName, value) :
                                            new SqlParameter(parameterName, SqlDbType.DateTime);
            if (output)
                parameter.Direction = ParameterDirection.Output;

            return parameter;
        }
        public static SqlParameter GetIntSqlParameter(string parameterName, int? value, bool output = false)
        {
            var parameter = value.HasValue ?
                                            new SqlParameter(parameterName, value) :
                                            new SqlParameter(parameterName, SqlDbType.Int);
            if (output)
                parameter.Direction = ParameterDirection.Output;

            return parameter;
        }
        public static SqlParameter GetIntSqlParameter_DefaultNull(string parameterName, int? value, bool output = false)
        {
            var parameter = value.HasValue && value != 0 ?
                                            new SqlParameter(parameterName, value) :
                                            new SqlParameter(parameterName, SqlDbType.Int);
            if (output)
                parameter.Direction = ParameterDirection.Output;

            return parameter;
        }
        public static SqlParameter GetDecimalSqlParameter(string parameterName, decimal? value, bool output = false)
        {
            var parameter = value.HasValue ?
                                            new SqlParameter(parameterName, value) :
                                            new SqlParameter(parameterName, SqlDbType.Decimal);
            if (output)
                parameter.Direction = ParameterDirection.Output;

            return parameter;
        }
        public static SqlParameter GetBoolSqlParameter(string parameterName, bool? value, bool output = false)
        {
            var parameter = value.HasValue ?
                                            new SqlParameter(parameterName, value) :
                                            new SqlParameter(parameterName, DBNull.Value);
            if (output)
                parameter.Direction = ParameterDirection.Output;

            return parameter;
        }
        public static SqlParameter GetStringSqlParameter_DefaulNull(string parameterName, string value, bool output = false)
        {
            var parameter = !string.IsNullOrEmpty(value) ?
                                                        new SqlParameter(parameterName, value) :
                                                        new SqlParameter(parameterName, DBNull.Value);
            if (output)
                parameter.Direction = ParameterDirection.Output;

            return parameter;
        }
    }
}
