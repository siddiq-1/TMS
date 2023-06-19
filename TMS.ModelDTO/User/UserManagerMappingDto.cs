using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO.User
{
    public class UserManagerMappingDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ManagerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
