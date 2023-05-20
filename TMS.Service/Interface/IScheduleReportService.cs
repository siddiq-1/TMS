using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.User;
using TMS.Utility;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface IScheduleReportService
    {
        Task<PageResult<ScheduleReportDto>> GetAllAsync(Expression<Func<ScheduleReport, bool>>? filter = null,
                           Func<IQueryable<ScheduleReport>, IOrderedQueryable<ScheduleReport>>? orderBy = null,
                           int page = 1,
                           int take = 10);
        Task<ScheduleReportDto> GetByIdAsync(int id);
        Task<ScheduleReport> AddAsync(ScheduleReportDto model);
        Task<ScheduleReport> UpdateAsync(int userId, int scheduleReportId, ScheduleReportDto model);
        Task<bool> DeleteAsync(int id);
        Task<ScheduleReportDto> GetFirtOrDefaultAsync(Expression<Func<ScheduleReport, bool>> predicate);
    }
}
