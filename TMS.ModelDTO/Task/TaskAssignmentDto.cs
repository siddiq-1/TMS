using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO.Task
{
    public class TaskAssignmentDto
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int AssignedTo { get; set; }
        public int AssignedBy { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
