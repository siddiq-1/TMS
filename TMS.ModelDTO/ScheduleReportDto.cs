using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO
{
    public class ScheduleReportDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ScheduleTime { get; set; } = null!;
        public string CronExpression { get; set; } = null!;
        public int RecurringJobId { get; set; }
        public int ReportTypeId { get; set; }
        public bool? IsActive { get; set; }
    }
}
