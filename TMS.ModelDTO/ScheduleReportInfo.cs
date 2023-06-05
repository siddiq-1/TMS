using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO
{
    public class ScheduleReportInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string CronExpression { get; set; } = null!;
        public string JobName { get; set; } = null!;
        public string ReportName { get; set; } = null!;
    }
}
