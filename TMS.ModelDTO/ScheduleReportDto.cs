using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO
{
    public class ScheduleReportDto
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public DateTime ScheduleTime { get; set; }
    }
}
