using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.Service.Interface;
using TMS.Utility;
using Task = System.Threading.Tasks.Task;

namespace TMS.Service.Service
{
    public class OverdueService : IOverdueService
    {
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly ISendEmailService _sendEmailService;
        private readonly IUserService _userService;

        public OverdueService(IEmailTemplateService emailTemplateService, ISendEmailService sendEmailService, IUserService userService)
        {
            _emailTemplateService = emailTemplateService;
            _sendEmailService = sendEmailService;
            _userService = userService;
        }
        public async Task RemindTask(int userId, TaskInfoData taskInfo, TaskAssignment task)
        {
            //var priority = await _unitOfWork.TaskPriorityRepository.GetByIdAsync(task.PriorityId);
            var user = await _userService.GetByIdAsync(userId);
            if (user != null && !string.IsNullOrEmpty(user.Email))
            {
                var mailBody = new StringBuilder();
                var emailTemplates = await _emailTemplateService.GetEmailTemplateValueByName(TemplateIdentifier.TASK_REMINDER.ToString());
                mailBody.Append(emailTemplates);


                EmailData emailData = new EmailData();
                emailData.MailBody = mailBody.ToString();
                emailData.FilePath = "";
                emailData.MailSubject = await _emailTemplateService.GetEmailTemplateValueByName(TemplateIdentifier.TASK_REMINDER_SUBJECT.ToString());
                emailData.Mailcc = "";
                emailData.MailBcc = "";
                emailData.MailTo = user.Email;

                await Task.Run(() => _sendEmailService.SendEmail(emailData));
            }
        }
    }
}
