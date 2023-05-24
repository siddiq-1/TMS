using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    public class TaskPriorityTypeMaster
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifyBy { get; set; }
        public bool IsActive { get; set; }
    }
}
