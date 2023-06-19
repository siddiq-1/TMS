using System;
using System.Collections.Generic;

namespace TMS.Model
{
    public partial class UserManagerMapping
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ManagerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
