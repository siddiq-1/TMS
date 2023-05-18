﻿using System;
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
        Task<IEnumerable<RecurringJobDto>> GetAllAsync(Expression<Func<RecurringJob, bool>>? filter = null,
                Func<IQueryable<RecurringJob>, IOrderedQueryable<RecurringJob>>? orderBy = null,
                int page = 0,
                int take = 10);
        Task<RecurringJobDto> GetByIdAsync(int id);
        Task<RecurringJob> AddAsync(RecurringJobDto model);
        Task<RecurringJob> UpdateAsync(int userId, int recurringJobId, RecurringJobDto model);
        Task<bool> DeleteAsync(int id);
        Task<RecurringJobDto> GetFirtOrDefaultAsync(Expression<Func<RecurringJob, bool>> predicate);
    }
}
