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
            var password = appSettings[ConfigurationKey.SMPT_PASSWORD.ToString()];
            var smtpPort = Convert.ToInt32(appSettings[ConfigurationKey.SMPT_SERVER_PORT.ToString()]);
            var smtpHost = appSettings[ConfigurationKey.SMPT_SERVER_HOST.ToString()];

            using (SmtpClient mailClient = new SmtpClient(smtpHost, smtpPort))
            using (MailMessage message = new MailMessage())
            {
                try
                {
                    if (string.IsNullOrEmpty(emailData.MailTo)) { return false; }

                    message.To.Add(emailData.MailTo);
                    message.Subject = emailData.MailSubject;
                    message.Body = emailData.MailBody;
                    message.IsBodyHtml = true;

                    if (!string.IsNullOrEmpty(emailData.MailBcc))
                    {
                        message.Bcc.Add(emailData.MailBcc);
                    }

                    if (!string.IsNullOrEmpty(emailData.FilePath))
                    {
                        message.Attachments.Add(new Attachment(Path.Combine(Directory.GetCurrentDirectory(), emailData.FilePath)));
                    }

                    mailClient.Credentials = new System.Net.NetworkCredential(userName, password);
                    message.From = new MailAddress(userName);

                    mailClient.EnableSsl = true;
                    mailClient.Send(message);

                    return true;
                }
                catch (Exception ex)
                {
                    // Handle and log the exception appropriately
                    // Add your custom error handling logic here
                    return false;
                }
            }
        }

    }
}
