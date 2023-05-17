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
    public interface IUserManagerService
    {
        Task<IEnumerable<UserManagerMapping>> GetAllAsync();
        Task<UserManagerMapping> GetByIdAsync(int id);
        Task AddAsync(UserManagerMapping model);
        void UpdateAsync(UserManagerMapping model);
        void DeleteAsync(UserManagerMapping model);
        Task<UserManagerMapping> GetFirtOrDefaultAsync(Expression<Func<UserManagerMapping, bool>> predicate);
    }
}
