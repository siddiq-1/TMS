using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO
{
    public class AppSettingDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
