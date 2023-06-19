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
        void ScheduleTaskReminder(string recurringJobId, int userId, TaskInfoData taskInfo, string cronExpression);
        void ScheduleTaskReminder(string recurringJobId, int userId, int taskId, TaskInfoView taskInfoView, string cronExpression);
    }
}
