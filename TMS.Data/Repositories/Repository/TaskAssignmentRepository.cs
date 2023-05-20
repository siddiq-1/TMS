using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.Utility;

namespace TMS.Data.Repositories.Repository
{
    public class TaskAssignmentRepository : Repository<TaskAssignment>, ITaskAssignmentRepository
    {
        private readonly TaskManagementSystemContext _tmsContext;
        public TaskAssignmentRepository(TaskManagementSystemContext tmsContext) : base(tmsContext)
        {
            _tmsContext = tmsContext;
        }

        public async PageResult<TaskInfoData> GetAllAsync()
        {
            return await (from tms in _tmsContext.TaskAssignments
                          join t in _tmsContext.Tasks on tms.TaskId equals t.Id
                          join tc in _tmsContext.TaskCategories on tms.CategoryId equals tc.Id
                          join ts in _tmsContext.TaskStatusMasters on tms.StatusId equals ts.Id
                          join at in _tmsContext.Users on tms.AssignedBy equals at.Id
                          join ab in _tmsContext.Users on tms.AssignedTo equals ab.Id
                          where tms.IsActive && tc.IsActive && ts.IsActive && at.IsActive && ab.IsActive
                          select new TaskInfoData
                          {
                              Id = tms.Id,
                              Name = t.Title,
                              AssignedBy = at.UserName,
                              AssignedTo = ab.UserName,
                              Category = tc.Name,
                              Status = ts.Status
                          }).ToListAsync();
        }
    }
}
