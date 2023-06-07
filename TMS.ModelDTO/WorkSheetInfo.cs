using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO
{
    public class WorkSheetInfo
    {
        public DataTable DataTable { get; set; } = null!;
        public string WorkSheetName { get; set; } = string.Empty;
        public string ReportHeading { get; set; } = string.Empty;
    }
}
