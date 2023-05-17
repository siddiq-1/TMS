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
    public interface IReportTypeService
    {
        Task<IEnumerable<ReportTypeMaster>> GetAllAsync();
        Task<ReportTypeMaster> GetByIdAsync(int id);
        Task AddAsync(ReportTypeMaster model);
        void UpdateAsync(ReportTypeMaster model);
        void DeleteAsync(ReportTypeMaster model);
        Task<ReportTypeMaster> GetFirtOrDefaultAsync(Expression<Func<ReportTypeMaster, bool>> predicate);
    }
}
