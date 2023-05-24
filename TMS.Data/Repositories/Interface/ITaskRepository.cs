﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.Utility;
using Task = TMS.Model.Task;

namespace TMS.Data.Repositories.Interface
{
    public interface ITaskRepository : IRepository<Task>
    {
    }
}
