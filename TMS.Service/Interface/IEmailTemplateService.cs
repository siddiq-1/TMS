using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;
using TMS.Utility;

namespace TMS.Service.Interface
{
    public interface IEmailTemplateService
    {
        Task<PageResult<EmailTemplateDto>> GetAllAsync(Expression<Func<EmailTemplate, bool>>? filter = null,
       Func<IQueryable<EmailTemplate>, IOrderedQueryable<EmailTemplate>>? orderBy = null,
       int page = 1,
       int take = 10);
        Task<EmailTemplateDto> GetByIdAsync(int id);
        Task<bool> AddAsync(EmailTemplateDto model);
        Task<bool> UpdateAsync(int userId, int emailTemplateId, EmailTemplateDto model);
        Task<EmailTemplateDto> GetEmailTemplateByName(string name);
        Task<string> GetEmailTemplateValueByName(string name);
        Dictionary<string, string> GetEmailTemplates();
    }
}
