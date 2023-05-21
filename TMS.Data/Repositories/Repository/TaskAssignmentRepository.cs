using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public TaskAssignmentRepository(TaskManagementSystemContext tmsContext) : base(tmsContext)
        {
        }

        public async Task<PageResult<TaskInfoData>> GetTaskListAsync()
        {
            int totalRecords = 0;
            var totalRecordsParameter = DataProvider.GetIntSqlParameter("@TotalRecords", totalRecords, true);
            var parameters = new List<SqlParameter>()
            {
                totalRecordsParameter
            };
            var result = await SQLHelper.ExecuteStoredProcedureAsync<TaskInfoData>("USP_ViewTaskList", parameters);
            totalRecords = Convert.IsDBNull(totalRecordsParameter.Value) ? 0 : Convert.ToInt32(totalRecordsParameter.Value);
            return new PageResult<TaskInfoData>(totalRecords, result);
        }
    }
}
