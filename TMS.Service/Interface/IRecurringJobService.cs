using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface IRecurringJobService
    {
        Task<IEnumerable<RecurringJobDto>> GetAllAsync();
        Task<RecurringJobDto> GetByIdAsync(int id);
        Task<RecurringJob> AddAsync(RecurringJobDto model);
        Task<RecurringJob> UpdateAsync(RecurringJobDto model);
        Task DeleteAsync(RecurringJobDto model);
        Task<RecurringJobDto> GetFirtOrDefaultAsync(Expression<Func<RecurringJobDto, bool>> predicate);
    }
}
