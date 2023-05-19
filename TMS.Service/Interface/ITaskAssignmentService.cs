﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
using TMS.Utility;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface ITaskAssignmentService
    {
        Task<PageResult<TaskAssignmentDto>> GetAllAsync(Expression<Func<TaskAssignment, bool>>? filter = null,
              Func<IQueryable<TaskAssignment>, IOrderedQueryable<TaskAssignment>>? orderBy = null,
              int page = 0,
              int take = 10);
        Task<TaskAssignmentDto> GetByIdAsync(int id);
        Task<TaskAssignment> AddAsync(TaskAssignmentDto model);
        Task<TaskAssignment> UpdateAsync(int userId, int taskAssignmentId, TaskAssignmentDto model);
        Task<bool> DeleteAsync(int id);
        Task<TaskAssignmentDto> GetFirtOrDefaultAsync(Expression<Func<TaskAssignment, bool>> predicate);
    }
}