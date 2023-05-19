namespace TMS.Utility
{
    public class PageResult<T>
    {
        public int TotalRecords { get; set; }
        public IEnumerable<T> List { get; set; }

        public PageResult(int totalRecords, IEnumerable<T> data)
        {
            TotalRecords = totalRecords;
            List = data;
        }
    }
}
