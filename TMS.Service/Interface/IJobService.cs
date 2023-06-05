using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO.Task;

namespace TMS.Service.Interface
{
    public interface IJobService
    {
        void ScheduleTaskReminder(string recurringJobId, int userId, TaskInfoData taskInfo, TaskAssignment task, string cronExpression);
    }
}
