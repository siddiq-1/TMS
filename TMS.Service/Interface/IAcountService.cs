using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.ModelDTO.User;

namespace TMS.Service.Interface
{
    public interface IAcountService
    {
        Task<string> Authentication(UserDto user);
    }
}
