using System;
using System.Collections.Generic;

namespace TMS.Model
{
    public partial class User
    {
        public User()
        {
            ScheduleReports = new HashSet<ScheduleReport>();
            TaskAssignmentAssignedByNavigations = new HashSet<TaskAssignment>();
            TaskAssignmentAssignedToNavigations = new HashSet<TaskAssignment>();
            UserManagerMappings = new HashSet<UserManagerMapping>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string FirstName { get; set; } = null!;
        public string? SecondName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ContactNo { get; set; }
        public string? AlternateContactNo { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifyBy { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ScheduleReport> ScheduleReports { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignmentAssignedByNavigations { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignmentAssignedToNavigations { get; set; }
        public virtual ICollection<UserManagerMapping> UserManagerMappings { get; set; }
        public virtual UserRoleMapping UserRoleMappings { get; set; }
    }
}
