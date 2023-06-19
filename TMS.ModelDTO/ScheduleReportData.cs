using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO
{
    public class ScheduleReportData
    {
        public int From { get; set; }
        public int To { get; set; }
        public string SortColumn { get; set; } = string.Empty;
        public string SortOrder { get; set; } = string.Empty;
        public string Search { get; set; } = string.Empty;
    }
}
