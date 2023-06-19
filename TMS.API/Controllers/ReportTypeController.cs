using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Data.MODEL;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTypeController : BaseApiController
    {
        private readonly IReportTypeService _reportTypeService;

        public ReportTypeController(IReportTypeService reportTypeService)
        {
            _reportTypeService = reportTypeService;
        }

        [HttpGet]
        public async Task<ServiceResponse<PageResult<ReportTypeMasterDto>>> GetReportTypeMasters()
        {
            return Response(await _reportTypeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<ReportTypeMasterDto>> GetReportTypeMasterById(int id)
        {
            return Response(await _reportTypeService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<ReportTypeMaster>> UpdateReportTypeMaster(int id, ReportTypeMasterDto reportTypeMaster)
        {
            return Response(await _reportTypeService.UpdateAsync(userId, id, reportTypeMaster));
        }

        [HttpPost]
        public async Task<ServiceResponse<ReportTypeMaster>> CreateReportTypeMaster(ReportTypeMasterDto reportTypeMaster)
        {
            return Response(await _reportTypeService.AddAsync(reportTypeMaster));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteReportTypeMaster(int id)
        {
            return Response(await _reportTypeService.DeleteAsync(id));
        }
    }
}
