using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO.Task
{
    public class TaskRequestDto
    {
        public int From { get; set; }
        public int To { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string Search { get; set; }
    }
}
