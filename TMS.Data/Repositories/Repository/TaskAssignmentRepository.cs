using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.Utility;

namespace TMS.Data.Repositories.Repository
{
    public class TaskAssignmentRepository : Repository<TaskAssignment>, ITaskAssignmentRepository
    {
        private readonly TaskManagementSystemContext _tmsContext;
        public TaskAssignmentRepository(TaskManagementSystemContext tmsContext) : base(tmsContext)
        {
            _tmsContext = tmsContext;
        }

        public async Task<PageResult<TaskInfoView>> GetTaskListAsync(TaskInfoViewDto taskInfoViewDto)
        {
            int totalRecords = 0;
            var fromParameter = DataProvider.GetIntSqlParameter("@From", taskInfoViewDto.From);
            var toParameter = DataProvider.GetIntSqlParameter("@To", taskInfoViewDto.To);
            var searchParameter = DataProvider.GetStringSqlParameter("@Search", taskInfoViewDto.Search);
            var sortColumnParameter = DataProvider.GetStringSqlParameter("@SortColumn", taskInfoViewDto.SortColumn);
            var sortOrderParameter = DataProvider.GetStringSqlParameter("@SortOrder", taskInfoViewDto.SortOrder);
            var totalRecordsParameter = DataProvider.GetIntSqlParameter("@TotalRecords", totalRecords, true);
            var parameters = new List<SqlParameter>()
            {
                fromParameter,
                toParameter,
                searchParameter,
                sortColumnParameter,
                sortOrderParameter,
                totalRecordsParameter
            };
            var result = await SQLHelper.ExecuteStoredProcedureAsync<TaskInfoView>("USP_ViewTaskList", parameters);
            totalRecords = Convert.IsDBNull(totalRecordsParameter.Value) ? 0 : Convert.ToInt32(totalRecordsParameter.Value);
            return new PageResult<TaskInfoView>(totalRecords, result);
        }
        public async Task<List<TaskCoverageDto>> GetTaskStatusAsync(int taskId)
        {
            var result = (from ta in _tmsContext.TaskAssignments
                          join tsm in _tmsContext.TaskStatusMasters on ta.StatusId equals tsm.Id into tsmGroup
                          join u in _tmsContext.Users on ta.AssignedTo equals u.Id
                          where ta.TaskId == taskId
                          select new TaskCoverageDto()
                          {
                              TaskId = ta.TaskId,
                              UserName = u.UserName,
                              Status = tsmGroup.Select(tsm => new TaskStatusMaster()
                              {
                                  Status = (ta.StatusId == tsm.Id) ? "100" : "0"
                              }).ToList()
                          }).ToList();

            return result;
        }
    }
}
