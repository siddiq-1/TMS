using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;
using TMS.Model;

namespace TMS.Data.Repositories.Repository
{
    public class EmailTemplateRepository : Repository<EmailTemplate>, IEmailTemplateRepository
    {
        private readonly TaskManagementSystemContext _tmsContext;
        public EmailTemplateRepository(TaskManagementSystemContext tmsContext) : base(tmsContext)
        {
            _tmsContext = tmsContext;
        }
        public Dictionary<string, string> GetEmailTemplates()
        {
            var emailTemplates = _tmsContext.EmailTemplates.AsNoTracking()
                .Select(x => new { x.Name, x.Value })
                .ToDictionary(x => x.Name, x => x.Value);

            return emailTemplates;
        }
        public async Task<string> GetEmailTemplatesByName(string name)
        {
            var emailTemplates = await GetByNameAsync(e => e.Name == name);
            return emailTemplates.Value;
        }
    }
}
