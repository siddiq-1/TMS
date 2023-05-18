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
    }
}