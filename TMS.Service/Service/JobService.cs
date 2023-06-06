using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.Service.Interface;
using Task = System.Threading.Tasks.Task;

namespace TMS.Service.Service
{
    public class JobService : IJobService
    {
        private readonly IOverdueService _overdueService;

        public JobService(IOverdueService overdueService)
        {
            _overdueService = overdueService;
        }
        public void ScheduleTaskReminder(string recurringJobId, int userId, TaskInfoData taskInfo, string cronExpression)
        {
            if (taskInfo.DueDate > DateTime.Now)
            {
                Hangfire.RecurringJob.RemoveIfExists(recurringJobId);
            }
            Hangfire.RecurringJob.AddOrUpdate(recurringJobId, () => _overdueService.RemindTask(userId, taskInfo), cronExpression);
        }
    }
}
