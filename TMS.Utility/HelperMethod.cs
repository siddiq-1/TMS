﻿using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Reflection;
using TMS.Model;
using TMS.ModelDTO;
using Task = System.Threading.Tasks.Task;

namespace TMS.Utility
{
    public static class HelperMethod
    {

        public static bool Commit(int result)
        {
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        public static async Task<string> Serialize<T>(T item)
        {
            return await Task.Run(() => JsonConvert.SerializeObject(item));
        }
        public static async Task<T> Deserialize<T>(string item)
        {
            var result = await Task.Run(() => JsonConvert.DeserializeObject<T>(item)!);
            return result;
        }

        public static async Task LogExcepion(HttpContext context, Exception ex)
        {

            var createDateParameter = DataProvider.GetDateSqlParameter("@CreateDate", DateTime.UtcNow);
            var messageParameter = DataProvider.GetStringSqlParameter("@Message", ex.Message.ToString());
            var sourceParameter = DataProvider.GetStringSqlParameter("@Source", ex.StackTrace?.ToString() ?? "");
            var typeParameter = DataProvider.GetStringSqlParameter("@Type", ex.GetType().ToString());
            var urlParameter = DataProvider.GetStringSqlParameter("@Url", context.Request?.Path.Value?.ToString() ?? "");

            var exceptionParameterList = new List<SqlParameter>()
            {
                createDateParameter,messageParameter,sourceParameter,typeParameter,urlParameter
            };

            await SQLHelper.ExecuteStoredProcedureAsync<ExceptionLog>("USP_AddExceptionLog", exceptionParameterList);
        }

        public static async Task HandleException(HttpContext context, Exception ex)
        {
            var exceptionDetails = GetExceptionDetails(ex);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exceptionDetails.StatusCode;
            await context.Response.WriteAsync(await Serialize(exceptionDetails) ?? "");
        }

        private static ServiceResponse<List<string>> GetExceptionDetails(Exception ex)
        {
            try
            {
                var exceptionList = new List<string>
                {
                    ex.InnerException?.Message ?? "",
                    ex.StackTrace ?? "",
                    ex.Message
                };

                return new ServiceResponse<List<string>>()
                {
                    Data = exceptionList,
                    StatusCode = GetExceptionType(ex),
                    Message = "Something Went Wrong! For more information, see the Data"
                };
            }
            catch (Exception)
            {

            }
            return new ServiceResponse<List<string>>();
        }
        private static int GetExceptionType(Exception ex)
        {
            var exceptionType = ex.GetType();

            if (exceptionType.Name.ToString() == "ArgumentException" || exceptionType.Name.ToString() == "IndexOutOfRangeException" || exceptionType.Name.ToString() == "DivideByZeroException" || exceptionType.Name.ToString() == "ArgumentOutOfRangeException" || exceptionType.Name.ToString() == "ArgumentNullException" || exceptionType.Name.ToString() == "FormatException" || exceptionType.Name.ToString() == "InvalidCastException" || exceptionType.Name.ToString() == "InvalidOperationException")
            {
                return 400;
            }
            else if (exceptionType.Name.ToString() == "KeyNotFoundException" || exceptionType.Name.ToString() == "FileNotFoundException")
            {
                return 404;
            }
            else if (exceptionType.Name.ToString() == "UnauthorizedAccessException")
            {
                return 403;
            }
            else
            {
                return 500;
            }
        }

        public static string GetHashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashPassword;
        }
        public static bool VerifyHashPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        public static List<int> SplitString(string data)
        {
            return data.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();
        }
        public static string CommaSeperatedString(List<string> stringList)
        {
            return string.Join(",", stringList);
        }
        public static string GetCronExpressionByDateTime(DateTime time)
        {
            return $"{time.Minute} {time.Hour} {time.Day} {time.Month} *";
        }
        public static DataTable ToDataTable<T>(this List<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                var type = (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(property.PropertyType) : property.PropertyType);
                dataTable.Columns.Add(property.Name, type);
            }
            foreach (T item in items)
            {
                var value = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    value[i] = properties[i].GetValue(item, null);
                }
                dataTable.Rows.Add(value);
            }
            return dataTable;
        }
    }
}