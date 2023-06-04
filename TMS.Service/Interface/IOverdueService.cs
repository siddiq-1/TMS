using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;
using Task = System.Threading.Tasks.Task;

namespace TMS.Service.Interface
{
    public interface IOverdueService
    {
        Task RemindTask(int userId, ScheduleReport scheduleReportDto);   
    }
}
