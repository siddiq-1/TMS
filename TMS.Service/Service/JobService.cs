using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.Service.Interface;

namespace TMS.Service.Service
{
    public class JobService : IJobService
    {
        private readonly IOverdueService _overdueService;

        public JobService(IOverdueService overdueService)
        {
            _overdueService = overdueService;
        }
        public void ScheduleTaskReminder(string recurringJobId, int userId, TaskInfoData taskInfo, TaskAssignment task, string cronExpression)
        {
            Hangfire.RecurringJob.AddOrUpdate(recurringJobId, () => _overdueService.RemindTask(userId, taskInfo, task), cronExpression);
        }
    }
}
