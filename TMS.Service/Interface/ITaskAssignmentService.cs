using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
using TMS.Utility;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface ITaskAssignmentService
    {
        Task<byte[]> GetTaskExport(TaskInfoViewDto taskInfoViewDto);
        Task<PageResult<TaskInfoView>> GetTaskListAsync(TaskInfoViewDto taskInfoViewDto);
        Task<bool> AddAsync(int userId, TaskInfoData model);
        Task<bool> UpdateAsync(int userId, TaskInfoData model);
        Task<bool> UpdateTaskStatus(int userId, int taskId, int statusId);
        Task<bool> DeleteAsync(int id);
        Task<List<TaskCoverageDto>> TaskCoverage(int taskId);
        Task<bool> ScheduleTask(int userId, ScheduleReportDto scheduleReportDto);
    }
}
