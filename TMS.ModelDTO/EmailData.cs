using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ModelDTO
{
    public class EmailData
    {
        public string MailTo { get; set; } = null!;
        public string MailBody { get; set; } = null!;
        public string MailSubject { get; set; } = null!;
        public string MailBcc { get; set; } = string.Empty;
        public string Mailcc { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
    }
}
