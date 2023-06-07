using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO.Task
{
    public class BulkUploadDto
    {
        public string FileName { get; set; } = null!;
        public string FileData { get; set; } = null!;
    }
}
