using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly ISendEmailService _sendEmailService;
        private readonly IEmailTemplateService _emailTemplateService;

        public AccountService(IUserService userService, ITokenService tokenService, ISendEmailService sendEmailService, IEmailTemplateService emailTemplateService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _sendEmailService = sendEmailService;
            _emailTemplateService = emailTemplateService;
        }
        public async Task<string> Authentication(LoginDto loginDto)
        {
            var user = await _userService.GetFirtOrDefaultAsync(model => model.UserRoleMappings.Role,
                u => u.UserName == loginDto.UserName);

            if (user == null)
            {
                return "User Not Found";
            }

            var isVerified = HelperMethod.VerifyHashPassword(loginDto.Password, user.Password);
            return isVerified ? _tokenService.GetToken(user) : "Invalid Credentials";
        }

        public async Task<bool> ResetPassword(string email_UserName)
        {
            var user = await _userService.GetFirtOrDefaultAsync(model => model.Email == email_UserName || model.UserName == email_UserName);
            if (user == null || user.Email == null)
            {
                return false;
            }
            var resetPasswordTemplate = await _emailTemplateService.GetEmailTemplateValueByName(TemplateIdentifier.RESET_PASSWORD.ToString());

            var mailBody = new StringBuilder();
            mailBody.Append(resetPasswordTemplate);
            mailBody.Replace(@"<a class=""btn"" href=""https://example.com/resetpassword?token={resetToken}"">Reset Password</a>", $@"<a class=""btn"" href=""https://localhost:7121/api/Account/ResetPassword?email={user.Email}"">Reset Password</a>");

            EmailData emailData = new EmailData();

            emailData.MailBody = mailBody.ToString();
            emailData.MailSubject = await _emailTemplateService.GetEmailTemplateValueByName(TemplateIdentifier.RESET_PASSWORD_SUBJECT.ToString());
            emailData.Mailcc = "";
            emailData.MailTo = user.Email;
            emailData.FilePath = "";
            emailData.MailBcc = "";
            return _sendEmailService.SendEmail(emailData);
        }
    }
}
