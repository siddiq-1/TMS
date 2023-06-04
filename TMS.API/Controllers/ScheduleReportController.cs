using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.ModelDTO;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleReportController : BaseApiController
    {
        private readonly IScheduleReportService _scheduleReportService;

        public ScheduleReportController(IScheduleReportService scheduleReportService)
        {
            _scheduleReportService = scheduleReportService;
        }
        [HttpGet]
        public async Task<ServiceResponse<PageResult<ScheduleReportDto>>> ScheduleReports()
        {
            return Response(await _scheduleReportService.GetAllAsync());
        }

        [HttpPost]
        public async Task<ServiceResponse<bool>> AddScheduleReport(ScheduleReportDto scheduleReport)
        {
            return Response(await _scheduleReportService.AddAsync(userId, scheduleReport));
        }
    }
}
