using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;

namespace TMS.Service.Interface
{
    public interface IOverdueService
    {
        void RemindTask(int userId, ScheduleReport scheduleReportDto);   
    }
}
