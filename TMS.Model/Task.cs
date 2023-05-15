using System;
using System.Collections.Generic;

namespace TMS.Model
{
    public partial class Task
    {
        public Task()
        {
            TaskAssignments = new HashSet<TaskAssignment>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
    }
}
