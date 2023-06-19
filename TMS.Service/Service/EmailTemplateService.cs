using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class EmailTemplateService : IEmailTemplateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmailTemplateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(EmailTemplateDto model)
        {
            var emailTemplate = _mapper.Map<EmailTemplateDto, EmailTemplate>(model);
            await _unitOfWork.EmailTemplateRepository.AddAsync(emailTemplate);
            return HelperMethod.Commit(await _unitOfWork.CommitAsync());
        }

        public async Task<PageResult<EmailTemplateDto>> GetAllAsync(Expression<Func<EmailTemplate, bool>>? filter = null, Func<IQueryable<EmailTemplate>, IOrderedQueryable<EmailTemplate>>? orderBy = null, int page = 1, int take = 10)
        {
            var emailTemplates = await _unitOfWork.EmailTemplateRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<EmailTemplate>, PageResult<EmailTemplateDto>>(emailTemplates);
        }

        public Dictionary<string, string> GetEmailTemplates()
        {
            return _unitOfWork.EmailTemplateRepository.GetEmailTemplates();
        }

        public async Task<EmailTemplateDto> GetEmailTemplateByName(string name)
        {
            var emailTemplate = await _unitOfWork.EmailTemplateRepository.GetByNameAsync(a => a.Name == name);
            return _mapper.Map<EmailTemplate, EmailTemplateDto>(emailTemplate);
        }
        public async Task<string> GetEmailTemplateValueByName(string name)
        {
            return await _unitOfWork.EmailTemplateRepository.GetEmailTemplatesByName(name);
        }
        public async Task<EmailTemplateDto> GetByIdAsync(int id)
        {
            var emailTemplate = await _unitOfWork.EmailTemplateRepository.GetByIdAsync(id);
            return _mapper.Map<EmailTemplate, EmailTemplateDto>(emailTemplate);
        }
        public async Task<bool> UpdateAsync(int userId, int emailTemplateId, EmailTemplateDto model)
        {
            var emailTemplate = await _unitOfWork.EmailTemplateRepository.GetByIdAsync(emailTemplateId);
            if (emailTemplate != null)
            {
                emailTemplate.Name = model.Name;
                emailTemplate.Value = model.Value;
                emailTemplate.ModifyBy = userId;
                emailTemplate.ModifiedDate = DateTime.UtcNow;

                _unitOfWork.EmailTemplateRepository.Update(emailTemplate);
                return HelperMethod.Commit(await _unitOfWork.CommitAsync());
            }
            return false;
        }
    }
}
