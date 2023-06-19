using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO.Task
{
    public class TaskPriorityTypesDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
