using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO.Task
{
    public class TaskInfoView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string AssignedTo { get; set; }
        public string AssignedBy { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
    }
}
