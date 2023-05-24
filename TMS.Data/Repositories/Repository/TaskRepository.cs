using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.Utility;
using Task = TMS.Model.Task;

namespace TMS.Data.Repositories.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(TaskManagementSystemContext tmsContext):base(tmsContext)
        {
            
        }
      
    }
}
