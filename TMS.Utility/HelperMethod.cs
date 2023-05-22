using Newtonsoft.Json;

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
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(item)!);
        }
    }
}