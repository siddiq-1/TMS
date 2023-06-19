using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.ModelDTO;

namespace TMS.Service.Interface
{
    public interface ISendEmailService
    {
        bool SendEmail(EmailData emailData);
    }
}
