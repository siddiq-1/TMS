using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class ScheduleReportService : IScheduleReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOverdueService _overdueService;

        public ScheduleReportService(IUnitOfWork unitOfWork, IMapper mapper, IOverdueService overdueService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _overdueService = overdueService;
        }
        public async Task<bool> AddAsync(ScheduleReportDto model)
        {
            var scheduleReport = _mapper.Map<ScheduleReportDto, ScheduleReport>(model);
            await _unitOfWork.ScheduleReportRepository.AddAsync(scheduleReport);
            _overdueService.RemindTask(scheduleReport);

            return HelperMethod.Commit(await _unitOfWork.CommitAsync());
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var ScheduleReport = await _unitOfWork.ScheduleReportRepository.GetByIdAsync(id);
            _unitOfWork.ScheduleReportRepository.Delete(ScheduleReport);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<ScheduleReportDto>> GetAllAsync(Expression<Func<ScheduleReport, bool>>? filter = null,
                Func<IQueryable<ScheduleReport>, IOrderedQueryable<ScheduleReport>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            var result = await _unitOfWork.ScheduleReportRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<ScheduleReport>, PageResult<ScheduleReportDto>>(result);
        }
        public async Task<ScheduleReportDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.ScheduleReportRepository.GetByIdAsync(id);
            return _mapper.Map<ScheduleReport, ScheduleReportDto>(result);
        }

        public async Task<ScheduleReportDto> GetFirtOrDefaultAsync(Expression<Func<ScheduleReport, bool>> predicate)
        {
            var result = await _unitOfWork.ScheduleReportRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<ScheduleReport, ScheduleReportDto>(result);
        }
        public async Task<bool> UpdateAsync(int userId, int scheduleReportId, ScheduleReportDto model)
        {
            var scheduleReport = await _unitOfWork.ScheduleReportRepository.GetByIdAsync(scheduleReportId);
            scheduleReport.CronExpression = model.CronExpression;
            scheduleReport.ScheduleTime = model.ScheduleTime;
            scheduleReport.ReportTypeId = model.ReportTypeId;
            scheduleReport.RecurringJobId = model.RecurringJobId;
            scheduleReport.ModifiedDate = DateTime.UtcNow;
            scheduleReport.ModifiedBy = userId;
            scheduleReport.IsActive = model.IsActive;
            _unitOfWork.ScheduleReportRepository.Update(scheduleReport);
            return HelperMethod.Commit(await _unitOfWork.CommitAsync());
        }
    }
}
