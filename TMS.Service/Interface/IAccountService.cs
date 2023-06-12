using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.ModelDTO;
using TMS.ModelDTO.User;

namespace TMS.Service.Interface
{
    public interface IAccountService
    {
        Task<string> Authentication(LoginDto user);
        Task<bool> ResetPassword(string email_UserName);
    }
}
