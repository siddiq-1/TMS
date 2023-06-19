using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO.Task
{
    public class TaskInfoData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int PriorityId { get; set; }
        public string UserIds { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
    }
}
