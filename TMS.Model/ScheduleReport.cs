using System;
using System.Collections.Generic;

namespace TMS.Model
{
    public partial class ScheduleReport
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ScheduleTime { get; set; } = null!;
        public string CronExpression { get; set; } = null!;
        public int RecurringJobId { get; set; }
        public int ReportTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public virtual ReportTypeMaster ReportType { get; set; } = null!;
        public virtual RecurringJob RecurringJob { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
