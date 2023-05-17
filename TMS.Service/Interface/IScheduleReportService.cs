using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface IScheduleReportService
    {
        Task<IEnumerable<ScheduleReport>> GetAllAsync();
        Task<ScheduleReport> GetByIdAsync(int id);
        Task AddAsync(ScheduleReport model);
        void UpdateAsync(ScheduleReport model);
        void DeleteAsync(ScheduleReport model);
        Task<ScheduleReport> GetFirtOrDefaultAsync(Expression<Func<ScheduleReport, bool>> predicate);
    }
}
