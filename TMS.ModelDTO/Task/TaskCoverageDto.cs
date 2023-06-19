using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;

namespace TMS.ModelDTO.Task
{
    public class TaskCoverageDto
    {
        public int TaskId { get; set; }
        public string UserName { get; set; }
        public List<TaskStatusMaster> Status { get; set; }

    }
}
