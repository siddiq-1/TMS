using System;
using System.Collections.Generic;

namespace TMS.Model
{
    public partial class TaskCategory
    {
        public TaskCategory()
        {
            TaskAssignments = new HashSet<TaskAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
    }
}
