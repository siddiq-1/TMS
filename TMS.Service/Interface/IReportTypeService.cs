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
    public interface IReportTypeService
    {
        Task<IEnumerable<ReportTypeMasterDto>> GetAllAsync(Expression<Func<ReportTypeMaster, bool>>? filter = null,
                Func<IQueryable<ReportTypeMaster>, IOrderedQueryable<ReportTypeMaster>>? orderBy = null,
                int page = 0,
                int take = 10);
        Task<ReportTypeMasterDto> GetByIdAsync(int id);
        Task<ReportTypeMaster> AddAsync(ReportTypeMasterDto model);
        Task<ReportTypeMaster> UpdateAsync(int userId, int reportTypeId, ReportTypeMasterDto model);
        Task<bool> DeleteAsync(int id);
        Task<ReportTypeMasterDto> GetFirtOrDefaultAsync(Expression<Func<ReportTypeMaster, bool>> predicate);
    }
}
