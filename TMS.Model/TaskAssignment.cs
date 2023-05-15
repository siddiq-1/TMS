using System;
using System.Collections.Generic;

namespace TMS.Model
{
    public partial class TaskAssignment
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
        public bool? IsActive { get; set; }

        public virtual User AssignedByNavigation { get; set; } = null!;
        public virtual User AssignedToNavigation { get; set; } = null!;
        public virtual TaskCategory Category { get; set; } = null!;
        public virtual TaskStatusMaster Status { get; set; } = null!;
        public virtual Task Task { get; set; } = null!;
    }
}
