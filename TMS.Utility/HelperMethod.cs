using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using TMS.Model;
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
            await context.Response.WriteAsync(exceptionDetails.ToString() ?? "");
        }
        public static async Task HandleModelValidation(HttpContext context, IEnumerable<string> errors)
        {
            var result = new ServiceResponse<List<string>>()
            {
                Data = errors.ToList(),
                Message = "Invalid Models ! For more kindly check the data",
                StatusCode = (int)HttpStatusCode.BadRequest
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var responseMessage = await Serialize(result);
            await context.Response.WriteAsync(responseMessage);
        }

        private static ServiceResponse<List<string>> GetExceptionDetails(Exception ex)
        {
            var exceptionList = new List<string>
            {
                ex.InnerException?.Message ?? "",
                ex.StackTrace ?? "",
                ex.Message
            };
            return new ServiceResponse<List<string>>
            {
                Data = exceptionList,
                StatusCode = GetExceptionType(ex),
                Message = "Something Went Wrong! For more information, see the Data"
            };
        }
        private static int GetExceptionType(Exception ex)
        {
            var exceptionType = ex.GetType();
            Dictionary<ExceptionType, int> data = typeof(ExceptionType).GetEnumValues().Cast<ExceptionType>().ToDictionary(key => key, value => (int)value);

            return data.FirstOrDefault(x => x.Key.ToString() == exceptionType.ToString()).Value;
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
    }
}