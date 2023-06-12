using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO.User;

namespace TMS.Service.Interface
{
    public interface ITokenService
    {
        string GetToken(User user);
        string GetToken(UserDto user);
    }
}
