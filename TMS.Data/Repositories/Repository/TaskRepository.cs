using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
using TMS.Utility;
using Task = TMS.Model.Task;

namespace TMS.Data.Repositories.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(TaskManagementSystemContext tmsContext):base(tmsContext)
        {
            
        }
        //public async Task<PageResult<Task>> GetTasks(TaskRequestDto taskRequestDto)
        //{
        //    int totalRecords = 0;
        //    var fromParameter = DataProvider.GetIntSqlParameter("@From", taskRequestDto.From);
        //    var toParameter = DataProvider.GetIntSqlParameter("@To", taskRequestDto.To);
        //    var searchParameter = DataProvider.GetStringSqlParameter("@Search", taskRequestDto.Search);
        //    var sortColumnParameter = DataProvider.GetStringSqlParameter("@SortColumn", taskRequestDto.SortColumn);
        //    var sortOrderParameter = DataProvider.GetStringSqlParameter("@SortOrder", taskRequestDto.SortOrder);
        //    var totalRecordsParameter = DataProvider.GetIntSqlParameter("@TotalRecords", totalRecords, true);
        //    var parameters = new List<SqlParameter>()
        //    {
        //        fromParameter,
        //        toParameter,
        //        searchParameter,
        //        sortColumnParameter,
        //        sortOrderParameter,
        //        totalRecordsParameter
        //    };
        //    var result = await SQLHelper.ExecuteStoredProcedureAsync<Task>("USP_AllTasks", parameters);
        //    totalRecords = Convert.IsDBNull(totalRecordsParameter.Value) ? 0 : Convert.ToInt32(totalRecordsParameter.Value);
        //    return new PageResult<Task>(totalRecords, result);
        //}

    }
}
