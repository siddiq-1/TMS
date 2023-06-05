using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.Utility;

namespace TMS.Data.Repositories.Repository
{
    public class ScheduleReportRepository : Repository<ScheduleReport>, IScheduleReportRepository
    {
        public ScheduleReportRepository(TaskManagementSystemContext tmsContext) : base(tmsContext)
        {

        }

        public async Task<PageResult<ScheduleReportInfo>> GetScheduleReports(ScheduleReportData scheduleReportData)
        {
            int totalRecords = 0;
            var fromParameter = DataProvider.GetIntSqlParameter("@From", scheduleReportData.From);
            var toParameter = DataProvider.GetIntSqlParameter("@To", scheduleReportData.To);
            var searchParameter = DataProvider.GetStringSqlParameter("@Search", scheduleReportData.Search);
            var sortColumnParameter = DataProvider.GetStringSqlParameter("@SortColumn", scheduleReportData.SortColumn);
            var sortOrderParameter = DataProvider.GetStringSqlParameter("@SortOrder", scheduleReportData.SortOrder);
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
            var result = await SQLHelper.ExecuteStoredProcedureAsync<ScheduleReportInfo>("USP_ViewScheduleReportList", parameters);
            totalRecords = Convert.IsDBNull(totalRecordsParameter.Value) ? 0 : Convert.ToInt32(totalRecordsParameter.Value);
            return new PageResult<ScheduleReportInfo>(totalRecords, result);
        }
    }
}