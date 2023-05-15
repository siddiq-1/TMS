using System;
using System.Collections.Generic;

namespace TMS.Model
{
    public partial class Role
    {
        public Role()
        {
            UserRoleMappings = new HashSet<UserRoleMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<UserRoleMapping> UserRoleMappings { get; set; }
    }
}
