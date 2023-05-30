using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TMS.ModelDTO;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IAppSettingService _appSettingService;

        public SendEmailService(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;
        }
        public bool SendEmail(EmailData emailData)
        {
            var appSettings = _appSettingService.GetAppSetings();
            var userName = appSettings[ConfigurationKey.SMPT_USERNAME.ToString()];
            var Password = appSettings[ConfigurationKey.SMPT_PASSWORD.ToString()];
            var smptPort = Convert.ToInt32(appSettings[ConfigurationKey.SMPT_SERVER_PORT.ToString()]);
            var smptHost = appSettings[ConfigurationKey.SMPT_SERVER_HOST.ToString()];

            var mailbody = new StringBuilder();
            using (SmtpClient mailClient = new SmtpClient())
            {
                mailClient.Port = smptPort;
                mailClient.Host = smptHost;
                MailMessage message = new MailMessage();

                if (string.IsNullOrEmpty(emailData.MailTo)) { return false; }

                message.To.Add(emailData.MailTo);
                message.Subject = emailData.MailSubject;
                mailbody.Append(emailData.MailBody);
                mailbody.Append("<div> </br></br> This mail is auto generated do not reply</br></br></div>");

                message.Body = mailbody.ToString();
                message.IsBodyHtml = true;

                if (!string.IsNullOrEmpty(emailData.MailBcc))
                {
                    message.Bcc.Add(emailData.MailBcc);
                }

                if (!string.IsNullOrEmpty(emailData.FilePath))
                {
                    message.Attachments.Add(new Attachment(Path.Combine(Directory.GetCurrentDirectory(), emailData.FilePath)));
                }
                mailClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = userName,
                    Password = Password
                };
                mailClient.UseDefaultCredentials = true;
                mailClient.EnableSsl = true;
                mailClient.Send(message);
                mailClient.Dispose();
                return true;
            }
        }
    }
}
