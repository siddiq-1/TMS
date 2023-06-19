using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model
{
    public class AppSetting
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifyBy { get; set; }
    }
}
