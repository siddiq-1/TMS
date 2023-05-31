using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;

namespace TMS.Data.Repositories.Interface
{
    public interface IEmailTemplateRepository : IRepository<EmailTemplate>
    {
        Dictionary<string, string> GetEmailTemplates();
        Task<string> GetEmailTemplatesByName(string name);
    }
}
